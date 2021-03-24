using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Office.Interop.Excel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using cExcel = Microsoft.Office.Interop.Excel;
using Workbook = Microsoft.Office.Interop.Excel.Workbook;
using Worksheet = Microsoft.Office.Interop.Excel.Worksheet;

namespace Tool1
{
    public class Form1Presenter : IForm1Contract.IPresenter
    {
        private IForm1Contract.IView views;

        public void readFile(string path)
        {
            try
            {
                Request[] queueRequest = readFileEx(path);
                Response[] responses = sendRequest(queueRequest);
                createFileOutput(queueRequest, responses);
                views.showDialog("test api ok.");
            }
            catch (SecurityException ex)
            {
                views.showDialog($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
            catch (Exception e)
            {
                views.showDialog(e.Message);
            }
        }

        public void setView(IForm1Contract.IView view)
        {
            this.views = view;
        }

        private Request[] readFileEx(string path)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

            // số hàng có dữ liệu của file exel
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            Request[] queueRequest = new Request[rowCount - 1];
            // vị trí hàng đầu tiên bắt đầu từ 1 nhưng do hàng 1 dùng cho title lên nó sẽ bắt đầu từ 2
            for (int i = 2; i <= rowCount; i++)
            {
                Request request = new Request();
                request.method = xlRange.Cells[i, 1] == null || xlRange.Cells[i, 1].Value2 == null ? "" : xlRange.Cells[i, 1].Value2.ToString().ToLower();
                request.requestUrl = xlRange.Cells[i, 2] == null || xlRange.Cells[i, 2].Value2 == null ? "" : xlRange.Cells[i, 2].Value2.ToString();
                request.headers = xlRange.Cells[i, 3] == null || xlRange.Cells[i, 3].Value2 == null ? "" : xlRange.Cells[i, 3].Value2.ToString();
                request.body = xlRange.Cells[i, 4] == null || xlRange.Cells[i, 4].Value2 == null ? "" : xlRange.Cells[i, 4].Value2.ToString();
                queueRequest[i - 2] = request;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);
           
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            return queueRequest;
        }

        /** thực hiện request tới web*/
        private Response[] sendRequest(Request[] queueRequest)
        {
            Response []responses = new Response[queueRequest.Length];
            for (int i = 0; i < queueRequest.Length; i++)
            {
                var request = queueRequest[i];

                if (request.requestUrl.Length == 0)
                {
                    responses[i] =new Response
                    {
                        body = "error data request"
                    };
                    continue;
                }
                if (request.method.Length == 0)
                {
                    responses[i] = new Response
                    {
                        body = "error data request"
                    };
                    continue;
                }
                /* thực hiện request get hoặc các request tương tự get*/
                if (request.method.Equals("get"))
                {
                    //var temp = sendRequest(request.requestUrl, request.method, request.headers);
                    responses[i] = sendRequest(request.requestUrl, request.method, request.headers);
                }
                else
                {
                    /* thực hiện request post, put, delete hoặc tương tự như vậy*/
                    //var temp = sendRequestBody(request.requestUrl, request.body, request.method, request.headers);
                    responses[i] = sendRequestBody(request.requestUrl, request.body, request.method, request.headers);
                }
            }

            return responses;
        }



        /** sử dụng cho các requet có truyền body lên như post, delete **/
        private Response sendRequestBody(string url, string body, string method, string header)
        {
            Response response = new Response();
            // data body of request
            var data = Encoding.ASCII.GetBytes(body);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Headers = getHeader(header);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
                
            return GetResponse((HttpWebResponse)request.GetResponse());
        }

        private Response GetResponse(HttpWebResponse myHttpWebResponse)
        {
            Response response = new Response();
            StringBuilder stringHeader = new StringBuilder();
            stringHeader.Append(string.Format("Status: {0}, \n", myHttpWebResponse.StatusCode.ToString()));
            stringHeader.Append(string.Format("CharacterSet: {0}, \n", myHttpWebResponse.CharacterSet.ToString()));
            stringHeader.Append(string.Format("ContentType: {0}, \n", myHttpWebResponse.ContentType.ToString()));
            stringHeader.Append(string.Format("Cookies: {0}, \n", myHttpWebResponse.Cookies.ToString()));
            stringHeader.Append(string.Format("Headers: {0}, \n", myHttpWebResponse.Headers.ToString()));
            stringHeader.Append(string.Format("IsFromCache: {0}, \n", myHttpWebResponse.IsFromCache.ToString()));
            stringHeader.Append(string.Format("Method: {0}, \n", myHttpWebResponse.Method.ToString()));
            stringHeader.Append(string.Format("ResponseUri: {0}, \n", myHttpWebResponse.ResponseUri.ToString()));
            stringHeader.Append(string.Format("StatusDescription: {0}, \n", myHttpWebResponse.StatusDescription.ToString()));
            stringHeader.Append(string.Format("SupportsHeaders: {0}, \n", myHttpWebResponse.SupportsHeaders.ToString()));
            response.responseheader = stringHeader.ToString();
            response.responseData = new StreamReader(myHttpWebResponse.GetResponseStream()).ReadToEnd();
            myHttpWebResponse.Close();

            return response;
        }

        /** tạo file lưu kết quả test api*/
        private void createFileOutput(Request[] queueRequest, Response[] responses)
        {

            for (int i = 0; i < queueRequest.Length; i++)
            {
                responses[i].method = queueRequest[i].method;
                responses[i].requestUrl = queueRequest[i].requestUrl;
                responses[i].headers = queueRequest[i].headers;
                responses[i].body = queueRequest[i].body;
            }
            // khởi tạo wb rỗng
            XSSFWorkbook wb = new XSSFWorkbook();

            // Tạo ra 1 sheet
            ISheet sheet = wb.CreateSheet();

            // Bắt đầu ghi lên sheet

            // Tạo row
            var row0 = sheet.CreateRow(0);
            // Merge lại row đầu 3 cột
            row0.CreateCell(0); // tạo ra cell trc khi merge
            CellRangeAddress cellMerge = new CellRangeAddress(0, 0, 0, 2);
            sheet.AddMergedRegion(cellMerge);
            row0.GetCell(0).SetCellValue("Kêt quả test api");

            // Ghi tên cột ở row 1
            var row1 = sheet.CreateRow(1);
            row1.CreateCell(0).SetCellValue("method");
            row1.CreateCell(1).SetCellValue("request url");
            row1.CreateCell(2).SetCellValue("header");
            row1.CreateCell(3).SetCellValue("body");
            row1.CreateCell(4).SetCellValue("data response");
            row1.CreateCell(5).SetCellValue("header response");

            // bắt đầu duyệt mảng và ghi tiếp tục
            int rowIndex = 2;
            foreach (var item in responses)
            {
                // tao row mới
                var newRow = sheet.CreateRow(rowIndex);

                // set giá trị
                newRow.CreateCell(0).SetCellValue(item.method ?? "Error");
                newRow.CreateCell(1).SetCellValue(item.requestUrl ?? "Error" );
                newRow.CreateCell(2).SetCellValue(item.headers ?? "Error");
                newRow.CreateCell(3).SetCellValue(item.body ?? "Error");
                newRow.CreateCell(4).SetCellValue((item.responseData ?? "Error").Substring( 0, 32760));
                newRow.CreateCell(5).SetCellValue(item.responseheader ?? "Error");

                // tăng index
                rowIndex++;
            }

            if (File.Exists(@""+ views.getPathOutput()))
            {
                File.Delete(@"" + views.getPathOutput());
            }

            // xong hết thì save file lại
            FileStream fs = new FileStream(@""+ views.getPathOutput(), FileMode.CreateNew);
            wb.Write(fs);
            fs.Close();
        }


        /** cấu trúc header sử dụng trong file: 
         * key1:value1;key2:valus2
         *
         * thực hiện tách chuỗi để lấy header cho request
         *
         */
        private WebHeaderCollection getHeader(string header)
        {
            WebHeaderCollection webHeaderCollection = new WebHeaderCollection();
            try
            {
                string[] arrayHeader = header.Split(';');
                string[] itemHeader;
                foreach (var item in arrayHeader)
                {
                    itemHeader = item.Split(':');
                    webHeaderCollection.Add(itemHeader[0].Trim(), itemHeader[1].Trim().ToString());
                }

                return webHeaderCollection;
            }
            catch (Exception)
            {
                return webHeaderCollection;
            }
        }


        /** sử dụng cho resquet không có truyền body ví dụ như get **/
        private Response sendRequest(string url, string method, string header)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Headers = getHeader(header);
            request.ContentType = "application/x-www-form-urlencoded";
            var response = (HttpWebResponse)request.GetResponse();
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)request.GetResponse();
            return GetResponse((HttpWebResponse)request.GetResponse());
        }
    }
}

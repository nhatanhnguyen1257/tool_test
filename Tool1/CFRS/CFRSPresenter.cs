using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Tool1.CFRS
{
    class CFRSPresenter : ICFRSContract.IPresenter
    {
        private ICFRSContract.IView views;
        private string pathController { get; set; }
        private string pathJsp { get; set; }
        private string pathXML { get; set; }

        public void createFileTest(string pathFileTest)
        {
            try { 
                CFRS.FormInput[] dataForm = readFileTest(pathFileTest);
                if (views.getTypeTest() == TYPE_TEST.HTML)
                {
                    if (!Directory.Exists(this.views.getPathOutput()))
                    {
                        Directory.CreateDirectory(this.views.getPathOutput());
                    }
                    createFileHtml(dataForm);
                } 
                else if (views.getTypeTest() == TYPE_TEST.SERVER)
                {
                    createDirectory();
                    createFileController(dataForm);
                    createFileMenuTest(dataForm);
                    createFileJsp(dataForm);
                    createFileTiles(dataForm);
                }
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

        private void createFileHtml(CFRS.FormInput[] dataForm)
        {
            foreach (var data in dataForm)
            {
                Task.Run(()=> {
                    new FileHtml().createFileHtml(views.getPathOutput(), data);
                });
            }
        }

        public void setView(ICFRSContract.IView view)
        {
            this.views = view;
        }

        /** đọc dữ liệu trong file test*/
        private CFRS.FormInput[] readFileTest(string path)
        {

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

            // số hàng có dữ liệu của file exel
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            CFRS.FormInput[] arryCFRS = new CFRS.FormInput[rowCount - 1];
            try
            {
                // vị trí hàng đầu tiên bắt đầu từ 1 nhưng do hàng 1 dùng cho title lên nó sẽ bắt đầu từ 2
                for (int i = 2; i <= rowCount; i++)
                {
                    CFRS.FormInput form = new CFRS.FormInput();
                    form.name = xlRange.Cells[i, 1] == null || xlRange.Cells[i, 1].Value2 == null ? "" : xlRange.Cells[i, 1].Value2.ToString();
                    form.method = xlRange.Cells[i, 2] == null || xlRange.Cells[i, 2].Value2 == null ? "" : xlRange.Cells[i, 2].Value2.ToString().ToLower();
                    form.url = xlRange.Cells[i, 3] == null || xlRange.Cells[i, 3].Value2 == null ? "" : xlRange.Cells[i, 3].Value2.ToString();
                    form.dataOfForm = xlRange.Cells[i, 4] == null || xlRange.Cells[i, 4].Value2 == null ? "" : xlRange.Cells[i, 4].Value2.ToString();
                    arryCFRS[i - 2] = form;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            return arryCFRS;
        }

        /** tạ thư mục chứa file test**/
        private void createDirectory()
        {
            if (!Directory.Exists(this.views.getPathOutput()))
            {
                createDirectoryChild();
            }
            
        }

        /** tạo các thư mục con*/
        private void createDirectoryChild()
        {
            this.pathController = this.views.getPathOutput() + "\\control";
            this.pathJsp = this.views.getPathOutput() + "\\jsp";
            this.pathXML = this.views.getPathOutput() + "\\xml";
            Directory.CreateDirectory(this.views.getPathOutput());
            Directory.CreateDirectory(pathController);
            Directory.CreateDirectory(pathJsp);
            Directory.CreateDirectory(pathXML);
        }

        #region thực hiện ghi file control java
        private void createFileController(CFRS.FormInput[] dataForm)
        {
            string path = this.pathController + "\\ControllerTestCFRS.java";

            StringBuilder data = new StringBuilder();
            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(createTextFileController(dataForm));
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }


        /** tạo text của file control*/
        private string createTextFileController(CFRS.FormInput[] dataForm)
        {
            StringBuilder data = new StringBuilder();
            data.Append("package demo.controller;\n");
            data.Append("\n");
            data.Append("import org.springframework.stereotype.Controller;\n");
            data.Append("import org.springframework.web.bind.annotation.RequestMapping;\n");
            data.Append("\n");
            data.Append("@Controller\n");
            data.Append("public class ControllerTestCFRS {\n");
            data.Append("\n\n");
            data.Append("\n");
            data.Append("\t@RequestMapping(\"/\")\n");
            data.Append("\tpublic String index() {\n");
            data.Append("\t\treturn \"index\";\n");
            data.Append("\t}\n");
            data.Append("\n");
            foreach (var form in dataForm)
            {
                if (form.name.Length == 0) continue;
                data.Append("");
                data.Append("\t@RequestMapping(\""+form.name+ "\")\n");
                data.Append("\tpublic String "+ form.name+"() {\n");
                data.Append("\t\treturn \"" + form.name + "\";\n");
                data.Append("\t}\n");
                data.Append("\n");
            }

            data.Append("}\n");

            return data.ToString();
        }
        #endregion

        #region thực hiện tạo file menu.jsp 

        /** tạo file chứa menu các case test CFRS **/
        private void createFileMenuTest(CFRS.FormInput[] dataForm)
        {
            string path = this.pathJsp + "\\menu.jsp";

            StringBuilder data = new StringBuilder();
            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(createFileMenuJsp(dataForm));
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }

        private string createFileMenuJsp(CFRS.FormInput[] dataForm)
        {
            StringBuilder data = new StringBuilder();
            data.Append("<%@ page language=\"java\" contentType=\"text/html; charset=utf-8\" pageEncoding=\"utf-8\" %>");
            data.Append("\n");
            //data.Append("<nav id=\"sidebar\">\n");
            data.Append("<ul class=\"list - unstyled components\">\n");
            data.Append("<li class=\"active\">\n");
            //data.Append("<a data-toggle=\"collapse\"\n");
            //data.Append("aria-expanded=\"false\" class=\"dropdown - toggle\">Test CFRS các chức năng sau</a>");
            data.Append("\n<ul>\n");

            foreach(var item in dataForm)
            {
                if (item.name.Length == 0) continue;
                data.Append("<li><a href=\""+ item .name+ "\">"+ item.name + "</a></li>\n");
            }

            data.Append("</ul>\n");
            data.Append("</li>\n");
            data.Append("</ul>\n");
            //data.Append("</nav>\n");

            return data.ToString();
        }

        #endregion

        #region thực hiện tạo các file giao diện jsp cho các màn hình cần test CFRS
        private void createFileJsp(CFRS.FormInput[] dataForm)
        {
            string path = this.pathJsp;
            Queue<string> queue = createListFileJsp(dataForm);
            for(int i = 0; i < queue.Count; i++)
            {
                var item = dataForm[i];
                if (item.name.Length == 0) continue;
                Task.Run(() => {
                    // Create the file, or overwrite if the file exists.
                    using (FileStream fs = File.Create(path + "\\" + item.name + ".jsp"))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(queue.Peek());
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                });
            }
        }

        /** tạo các file thực hiện test*/
        public Queue<string> createListFileJsp(CFRS.FormInput[] dataForm)
        {
            Queue<string> queue = new Queue<string>();

            foreach (var item in dataForm)
            {
                StringBuilder data = new StringBuilder();
                data.Append("<%@ page language=\"java\" contentType=\"text/html; charset=utf-8\" pageEncoding=\"utf-8\" %>");
                data.Append("");
                data.Append("<form action=\""+item.url+ "\" method=\""+item.method+"\">\n" );
                data.Append(item.dataOfForm);
                data.Append("\n<input type=\"submit\" value=\"Submit\">");
                data.Append("</form>\n");
                queue.Enqueue(data.ToString());
            }
            return queue;
        }

        #endregion

        #region tạo file tiles để chưa config 
        private void createFileTiles(CFRS.FormInput[] dataForm)
        {
            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(this.pathXML + "\\tiles.xml"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(fileTilesXml(dataForm));
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }

        private string fileTilesXml(CFRS.FormInput[] dataForm)
        {
            StringBuilder data = new StringBuilder();

            data.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            data.Append("\n");
            data.Append("<!DOCTYPE tiles-definitions PUBLIC\n\"-//Apache Software Foundation//DTD Tiles Configuration 2.0//EN\"\n\"http://tiles.apache.org/dtds/tiles-config_2_0.dtd\" >\n");
            data.Append("\n<tiles-definitions>\n");
            data.Append("<definition name=\"base.definition\" template=\"/WEB-INF/jsp/layout.jsp\">\n");
            data.Append("<put-attribute name=\"title\" value=\"\"/>\n");
            data.Append("<put-attribute name=\"menu\" value=\"/WEB-INF/jsp/menu.jsp\"/>\n");
            data.Append("<put-attribute name=\"body\" value=\"\" />\n");
            data.Append("<put-attribute name=\"footer\" value=\"/WEB-INF/jsp/footer.jsp\" />\n");
            data.Append("</definition>\n");
            data.Append("<definition name=\"index\" extends=\"base.definition\">\n");
            data.Append("<put-attribute name=\"title\" value=\"Home\" />\n");
            data.Append("<put-attribute name=\"menu\" value=\"/WEB-INF/jsp/menu.jsp\" />\n");
            data.Append("<put-attribute name=\"body\" value=\"/WEB-INF/jsp/index.jsp\" />\n");
            data.Append("<put-attribute name=\"footer\" value=\"/WEB-INF/jsp/footer.jsp\" />\n");
            data.Append("</definition>\n");

            foreach(var item in dataForm)
            {
                if (item.name.Length == 0) continue;
                data.Append("<definition name=\""+item.name+ "\" extends=\"base.definition\">\n");
                data.Append("<put-attribute name=\"title\" value=\""+item.name+ "\" />\n");
                data.Append("<put-attribute name=\"body\" value=\"/WEB-INF/jsp/"+ item.name + ".jsp\" />\n");
                data.Append("</definition>\n");
            }
            data.Append("</tiles-definitions>");
            return data.ToString();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool1.CFRS
{
    class FileHtml
    {
        private Dictionary<string, string> readDataOfForm(string data)
        {
            Dictionary<string, string> dataInputForm = new Dictionary<string, string>();
            if (data.Trim().Length == 0) return dataInputForm;

            string[] dataForm = data.Split('&');
            string []temp;
            foreach(var str in dataForm)
            {
                temp = str.Split('=');
                dataInputForm.Add(temp[0], temp[1]);
            }
            return dataInputForm;
        }


        public void createFileHtml(string pathUrl, CFRS.FormInput formInput)
        {
            string path = pathUrl + "\\"+ formInput .name.Trim()+ ".html";
            if (formInput.name == null || formInput.name.Length == 0)
            {
                return;
            }

            if (formInput.url == null || formInput.url.Length == 0)
            {
                return;
            }
            if (formInput.method == null || formInput.method.Length == 0)
            {
                return;
            }

            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(createTextHtml(formInput));
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        } 

        private string createTextHtml(CFRS.FormInput formInput)
        {
            Dictionary<string, string> dataInputForm = readDataOfForm(formInput.dataOfForm);
            StringBuilder stringHtml = new StringBuilder();
            stringHtml.Append("<html>\n"
                             + "<body>\n"
                            +"<script> history.pushState('','','/') </script>\n");
            stringHtml.Append("<form action=\""+ formInput.url + "\" method=\""+ formInput .method+ "\" >\n");
            foreach (var data in dataInputForm)
            {
                stringHtml.Append("<input type=\"hidden\" name=\""+data.Key+"\" value=\"" + data.Value + "\" />\n");
            }

            stringHtml.Append("<input type=\"submit\" value=\"Submit request\" />\n");
            stringHtml.Append("</form>\n");
            stringHtml.Append("</body>\n");
            stringHtml.Append("</html>\n");

            return stringHtml.ToString();
        }
    }
}

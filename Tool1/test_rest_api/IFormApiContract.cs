using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool1.test_rest_api
{
    public interface IFormApiContract
    {
        public interface IView
        {
            public void showFileDialog();

            public void showDialog(string msg);

            public void doNotCickSend();

            public string getPathOutput();
        }

        public interface IPresenter
        {
            public void readFile(string path);

            public void setView(IFormApiContract.IView view);

        }
    }
}

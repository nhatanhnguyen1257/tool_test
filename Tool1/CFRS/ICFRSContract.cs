using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool1.CFRS
{
    public interface ICFRSContract
    {
        public interface IView
        {
            void showDialog(string mgs);

            string getPathOutput();
        }

        public interface IPresenter
        {
            void setView(ICFRSContract.IView view);
            void createFileTest(string pathFileTest);
        }

    }
}

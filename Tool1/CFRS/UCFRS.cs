using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool1.CFRS
{
    public partial class UCFRS : UserControl, ICFRSContract.IView
    {
        private ICFRSContract.IPresenter presenter;
        public UCFRS()
        {
            InitializeComponent();
            presenter = new CFRSPresenter();
        }

        private void UCFRS_Load(object sender, EventArgs e)
        {
            presenter.setView(this);
        }

        private void tb_input_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                this.tb_input.Text = path;
                this.tb_output.Text = System.IO.Path.GetDirectoryName(openFileDialog.FileName) + "\\output" ;
            }
        }

        private void bt_sendRequest_Click(object sender, EventArgs e)
        {
            this.bt_sendRequest.Text = "Đang tao file test";
            this.bt_sendRequest.Enabled = false;
            presenter.createFileTest(this.tb_input.Text);
            this.bt_sendRequest.Text = "Thực hiện test";
            this.bt_sendRequest.Enabled = true;
        }

        public void showDialog(string mgs)
        {
            MessageBox.Show(mgs);
        }

        public string getPathOutput()
        {
            return this.tb_output.Text;
        }
    }
}

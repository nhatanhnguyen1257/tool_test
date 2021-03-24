using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool1.test_rest_api
{
    public partial class UApi : UserControl, IFormApiContract.IView
    {

        private IFormApiContract.IPresenter presenters;
        public UApi()
        {
            InitializeComponent();
            presenters = new FormApiPresenter();
        }

        public void showFileDialog()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                this.tb_input.Text = path;
                this.tb_output.Text = System.IO.Path.GetDirectoryName(openFileDialog.FileName) + "\\output_" + openFileDialog.SafeFileName;
            }

        }

        private void tb_input_Click(object sender, EventArgs e)
        {
            showFileDialog();
        }

        public void showDialog(string msg)
        {
            MessageBox.Show(msg);
        }

        public void doNotCickSend()
        {
            this.bt_sendRequest.Text = "Đang thực hiện test";
            this.bt_sendRequest.Enabled = false;
        }

        private void bt_sendRequest_Click(object sender, EventArgs e)
        {
            doNotCickSend();

            presenters.readFile(this.tb_input.Text);

            this.bt_sendRequest.Text = "Thực hiện test";
            this.bt_sendRequest.Enabled = true;
        }

        public string getPathOutput()
        {
            return this.tb_output.Text;
        }

        private void FormApi_Load(object sender, EventArgs e)
        {
            this.presenters.setView(this);
        }
    }
}


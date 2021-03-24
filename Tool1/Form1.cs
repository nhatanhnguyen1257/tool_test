using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool1.CFRS;
using Tool1.test_rest_api;

namespace Tool1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bt_restApi_Click(null, null);
        }

        private void bt_restApi_Click(object sender, EventArgs e)
        {
            this.panel_main1.Controls.Clear();
            this.panel_main1.Controls.Add(new UApi());
            this.Text = "Test rest API";
        }

        private void bt_cfrs_Click(object sender, EventArgs e)
        {
            this.panel_main1.Controls.Clear();
            this.panel_main1.Controls.Add(new UCFRS());
            this.Text = "Test tấn công CFRS";
        }
    }
}

using System.Windows.Forms;

namespace Tool1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_main1 = new System.Windows.Forms.Panel();
            this.bt_restApi = new System.Windows.Forms.Button();
            this.bt_cfrs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel_main1
            // 
            this.panel_main1.Location = new System.Drawing.Point(105, 1);
            this.panel_main1.Name = "panel_main1";
            this.panel_main1.Size = new System.Drawing.Size(802, 404);
            this.panel_main1.TabIndex = 0;
            // 
            // bt_restApi
            // 
            this.bt_restApi.Location = new System.Drawing.Point(1, 23);
            this.bt_restApi.Name = "bt_restApi";
            this.bt_restApi.Size = new System.Drawing.Size(98, 23);
            this.bt_restApi.TabIndex = 1;
            this.bt_restApi.Text = "Test API";
            this.bt_restApi.UseVisualStyleBackColor = true;
            this.bt_restApi.Click += new System.EventHandler(this.bt_restApi_Click);
            // 
            // bt_cfrs
            // 
            this.bt_cfrs.Location = new System.Drawing.Point(1, 52);
            this.bt_cfrs.Name = "bt_cfrs";
            this.bt_cfrs.Size = new System.Drawing.Size(98, 23);
            this.bt_cfrs.TabIndex = 2;
            this.bt_cfrs.Text = "Test CFRS";
            this.bt_cfrs.UseVisualStyleBackColor = true;
            this.bt_cfrs.Click += new System.EventHandler(this.bt_cfrs_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(909, 407);
            this.Controls.Add(this.bt_cfrs);
            this.Controls.Add(this.bt_restApi);
            this.Controls.Add(this.panel_main1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button bt_rest_api;
        private Panel panel_main1;
        private Button bt_restApi;
        private Button bt_cfrs;
    }
}


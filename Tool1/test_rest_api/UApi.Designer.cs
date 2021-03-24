namespace Tool1.test_rest_api
{
    partial class UApi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_sendRequest = new System.Windows.Forms.Button();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.tb_input = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(679, 143);
            this.label3.TabIndex = 11;
            this.label3.Text = "đây là tool thực hiện test API. Trong tool này test thông qua file excl. ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Đường dẫn tới file kết quả test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Đường dẫn tới file dữ liệu test";
            // 
            // bt_sendRequest
            // 
            this.bt_sendRequest.Location = new System.Drawing.Point(539, 183);
            this.bt_sendRequest.Name = "bt_sendRequest";
            this.bt_sendRequest.Size = new System.Drawing.Size(155, 23);
            this.bt_sendRequest.TabIndex = 8;
            this.bt_sendRequest.Text = "Thực hiện test";
            this.bt_sendRequest.UseVisualStyleBackColor = true;
            this.bt_sendRequest.Click += new System.EventHandler(this.bt_sendRequest_Click);
            // 
            // tb_output
            // 
            this.tb_output.Enabled = false;
            this.tb_output.Location = new System.Drawing.Point(18, 137);
            this.tb_output.Name = "tb_output";
            this.tb_output.Size = new System.Drawing.Size(676, 20);
            this.tb_output.TabIndex = 7;
            // 
            // tb_input
            // 
            this.tb_input.Location = new System.Drawing.Point(18, 67);
            this.tb_input.Name = "tb_input";
            this.tb_input.Size = new System.Drawing.Size(676, 20);
            this.tb_input.TabIndex = 6;
            this.tb_input.Click += new System.EventHandler(this.tb_input_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "txt files (*.xlsx)|*.xlsx|All files (*..xlsx)|*..xlsx";
            // 
            // UApi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_sendRequest);
            this.Controls.Add(this.tb_output);
            this.Controls.Add(this.tb_input);
            this.Name = "UApi";
            this.Size = new System.Drawing.Size(713, 432);
            this.Load += new System.EventHandler(this.FormApi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_sendRequest;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.TextBox tb_input;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

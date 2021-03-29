namespace Tool1.CFRS
{
    partial class UCFRS
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_sendRequest = new System.Windows.Forms.Button();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.tb_input = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioHtml = new System.Windows.Forms.RadioButton();
            this.radioServer = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(774, 34);
            this.label3.TabIndex = 11;
            this.label3.Text = "Khi chọn radio button tạo file html thì dữ liệu sẽ tạo ra 1 file html với dữ liệu" +
    " và đường dẫn muống test";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "txt files (*.xlsx)|*.xlsx|All files (*..xlsx)|*..xlsx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Đường dẫn tới thư mục chưa file thực hiện test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Đường dẫn tới file dữ liệu test";
            // 
            // bt_sendRequest
            // 
            this.bt_sendRequest.Location = new System.Drawing.Point(647, 187);
            this.bt_sendRequest.Name = "bt_sendRequest";
            this.bt_sendRequest.Size = new System.Drawing.Size(130, 23);
            this.bt_sendRequest.TabIndex = 8;
            this.bt_sendRequest.Text = "Thực hiện test";
            this.bt_sendRequest.UseVisualStyleBackColor = true;
            this.bt_sendRequest.Click += new System.EventHandler(this.bt_sendRequest_Click);
            // 
            // tb_output
            // 
            this.tb_output.Enabled = false;
            this.tb_output.Location = new System.Drawing.Point(6, 141);
            this.tb_output.Name = "tb_output";
            this.tb_output.Size = new System.Drawing.Size(771, 20);
            this.tb_output.TabIndex = 7;
            // 
            // tb_input
            // 
            this.tb_input.Location = new System.Drawing.Point(6, 71);
            this.tb_input.Name = "tb_input";
            this.tb_input.Size = new System.Drawing.Size(771, 20);
            this.tb_input.TabIndex = 6;
            this.tb_input.Click += new System.EventHandler(this.tb_input_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioHtml);
            this.panel1.Controls.Add(this.radioServer);
            this.panel1.Location = new System.Drawing.Point(6, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 66);
            this.panel1.TabIndex = 12;
            // 
            // radioHtml
            // 
            this.radioHtml.AutoSize = true;
            this.radioHtml.Checked = true;
            this.radioHtml.Location = new System.Drawing.Point(28, 40);
            this.radioHtml.Name = "radioHtml";
            this.radioHtml.Size = new System.Drawing.Size(84, 17);
            this.radioHtml.TabIndex = 1;
            this.radioHtml.TabStop = true;
            this.radioHtml.Text = "Tạo file Html";
            this.radioHtml.UseVisualStyleBackColor = true;
            // 
            // radioServer
            // 
            this.radioServer.AutoSize = true;
            this.radioServer.Location = new System.Drawing.Point(28, 17);
            this.radioServer.Name = "radioServer";
            this.radioServer.Size = new System.Drawing.Size(167, 17);
            this.radioServer.TabIndex = 0;
            this.radioServer.Text = "Tạo file sử dụng với server giả";
            this.radioServer.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(774, 34);
            this.label4.TabIndex = 13;
            this.label4.Text = "Khi chọn radion button tạo file sử dụng với server giả thì sẽ tạo ra các file htm" +
    "l sử dụng cho 1 server giả";
            // 
            // UCFRS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_sendRequest);
            this.Controls.Add(this.tb_output);
            this.Controls.Add(this.tb_input);
            this.Name = "UCFRS";
            this.Size = new System.Drawing.Size(802, 389);
            this.Load += new System.EventHandler(this.UCFRS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_sendRequest;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.TextBox tb_input;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioHtml;
        private System.Windows.Forms.RadioButton radioServer;
        private System.Windows.Forms.Label label4;
    }
}

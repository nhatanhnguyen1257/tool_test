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
            this.tb_input = new System.Windows.Forms.TextBox();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.bt_sendRequest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // tb_input
            // 
            this.tb_input.Location = new System.Drawing.Point(82, 69);
            this.tb_input.Name = "tb_input";
            this.tb_input.Size = new System.Drawing.Size(771, 20);
            this.tb_input.TabIndex = 0;
            this.tb_input.Click += new System.EventHandler(this.tb_input_Click);
            // 
            // tb_output
            // 
            this.tb_output.Enabled = false;
            this.tb_output.Location = new System.Drawing.Point(82, 139);
            this.tb_output.Name = "tb_output";
            this.tb_output.Size = new System.Drawing.Size(771, 20);
            this.tb_output.TabIndex = 1;
            // 
            // bt_sendRequest
            // 
            this.bt_sendRequest.Location = new System.Drawing.Point(723, 185);
            this.bt_sendRequest.Name = "bt_sendRequest";
            this.bt_sendRequest.Size = new System.Drawing.Size(130, 23);
            this.bt_sendRequest.TabIndex = 2;
            this.bt_sendRequest.Text = "Thực hiện test";
            this.bt_sendRequest.UseVisualStyleBackColor = true;
            this.bt_sendRequest.Click += new System.EventHandler(this.bt_sendRequest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Đường dẫn tới file dữ liệu test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đường dẫn tới file kết quả test";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(79, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(774, 143);
            this.label3.TabIndex = 5;
            this.label3.Text = "đây là tool thực hiện test API. Trong tool này test thông qua file excl. ";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "txt files (*.xlsx)|*.xlsx|All files (*..xlsx)|*..xlsx";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_sendRequest);
            this.Controls.Add(this.tb_output);
            this.Controls.Add(this.tb_input);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_input;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.Button bt_sendRequest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private OpenFileDialog openFileDialog;
    }
}


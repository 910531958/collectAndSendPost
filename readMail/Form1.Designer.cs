namespace readMail
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_usn = new System.Windows.Forms.TextBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.webView = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // txt_usn
            // 
            this.txt_usn.Location = new System.Drawing.Point(5, 4);
            this.txt_usn.Name = "txt_usn";
            this.txt_usn.Size = new System.Drawing.Size(660, 21);
            this.txt_usn.TabIndex = 1;
            this.txt_usn.Text = "http://www.isapt.com/article/51902.html";
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(671, 2);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 23);
            this.btn_submit.TabIndex = 5;
            this.btn_submit.Text = "登  录";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // txt_output
            // 
            this.txt_output.Location = new System.Drawing.Point(3, 31);
            this.txt_output.Multiline = true;
            this.txt_output.Name = "txt_output";
            this.txt_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_output.Size = new System.Drawing.Size(1376, 327);
            this.txt_output.TabIndex = 6;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(752, 2);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 8;
            this.btn_send.Text = "发  表";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // webView
            // 
            this.webView.Location = new System.Drawing.Point(5, 364);
            this.webView.MinimumSize = new System.Drawing.Size(20, 20);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(1374, 398);
            this.webView.TabIndex = 9;
            this.webView.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webView_DocumentCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 762);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txt_output);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.txt_usn);
            this.Name = "Form1";
            this.Text = "邮件阅读器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_usn;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.TextBox txt_output;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.WebBrowser webView;
    }
}


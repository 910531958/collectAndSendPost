namespace readMail
{
    partial class index
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
            this.btn_set = new System.Windows.Forms.Button();
            this.btn_getList = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_set
            // 
            this.btn_set.Location = new System.Drawing.Point(13, 13);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(75, 23);
            this.btn_set.TabIndex = 0;
            this.btn_set.Text = "设  置";
            this.btn_set.UseVisualStyleBackColor = true;
            // 
            // btn_getList
            // 
            this.btn_getList.Location = new System.Drawing.Point(95, 13);
            this.btn_getList.Name = "btn_getList";
            this.btn_getList.Size = new System.Drawing.Size(75, 23);
            this.btn_getList.TabIndex = 1;
            this.btn_getList.Text = "采集列表";
            this.btn_getList.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "采集并发布";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_getList);
            this.Controls.Add(this.btn_set);
            this.Name = "index";
            this.Text = "小菜采集器";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.Button btn_getList;
        private System.Windows.Forms.Button button1;
    }
}
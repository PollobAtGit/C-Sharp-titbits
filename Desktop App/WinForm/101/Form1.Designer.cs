namespace _101
{
    partial class DownloadFromUrl
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
            this.mainUrl = new System.Windows.Forms.TextBox();
            this.URL = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.defaultUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contentPlaceHolder = new System.Windows.Forms.RichTextBox();
            this.download = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainUrl
            // 
            this.mainUrl.Location = new System.Drawing.Point(71, 16);
            this.mainUrl.Name = "mainUrl";
            this.mainUrl.Size = new System.Drawing.Size(100, 20);
            this.mainUrl.TabIndex = 0;
            // 
            // URL
            // 
            this.URL.AutoSize = true;
            this.URL.Location = new System.Drawing.Point(6, 19);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(29, 13);
            this.URL.TabIndex = 1;
            this.URL.Text = "URL";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.download);
            this.groupBox1.Controls.Add(this.mainUrl);
            this.groupBox1.Controls.Add(this.URL);
            this.groupBox1.Location = new System.Drawing.Point(23, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 75);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.defaultUrl);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(242, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 49);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // defaultUrl
            // 
            this.defaultUrl.Location = new System.Drawing.Point(89, 16);
            this.defaultUrl.Name = "defaultUrl";
            this.defaultUrl.Size = new System.Drawing.Size(100, 20);
            this.defaultUrl.TabIndex = 0;
            this.defaultUrl.Text = "https://www.google.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Default URL";
            // 
            // contentPlaceHolder
            // 
            this.contentPlaceHolder.Location = new System.Drawing.Point(23, 102);
            this.contentPlaceHolder.Name = "contentPlaceHolder";
            this.contentPlaceHolder.Size = new System.Drawing.Size(414, 326);
            this.contentPlaceHolder.TabIndex = 4;
            this.contentPlaceHolder.Text = "";
            // 
            // download
            // 
            this.download.Location = new System.Drawing.Point(9, 42);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(162, 23);
            this.download.TabIndex = 2;
            this.download.Text = "Download";
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // DownloadFromUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 440);
            this.Controls.Add(this.contentPlaceHolder);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DownloadFromUrl";
            this.Text = "Download (from URL)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox mainUrl;
        private System.Windows.Forms.Label URL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox defaultUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox contentPlaceHolder;
        private System.Windows.Forms.Button download;
    }
}


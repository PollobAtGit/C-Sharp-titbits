namespace Ch_3
{
    partial class dnsChecker
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
            this.txtBoxHost = new System.Windows.Forms.TextBox();
            this.checkDns = new System.Windows.Forms.Button();
            this.ipsListBox = new System.Windows.Forms.ListBox();
            this.checkDnsAsync = new System.Windows.Forms.Button();
            this.faviconListBox = new System.Windows.Forms.ListBox();
            this.faviconListBoxAn = new System.Windows.Forms.ListBox();
            this.btnLongRunningProcess = new System.Windows.Forms.Button();
            this.btnVoidReturn = new System.Windows.Forms.Button();
            this.btnLargestContent = new System.Windows.Forms.Button();
            this.lblUrl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxHost
            // 
            this.txtBoxHost.Location = new System.Drawing.Point(38, 12);
            this.txtBoxHost.Name = "txtBoxHost";
            this.txtBoxHost.Size = new System.Drawing.Size(330, 20);
            this.txtBoxHost.TabIndex = 1;
            // 
            // checkDns
            // 
            this.checkDns.Location = new System.Drawing.Point(38, 39);
            this.checkDns.Name = "checkDns";
            this.checkDns.Size = new System.Drawing.Size(157, 23);
            this.checkDns.TabIndex = 2;
            this.checkDns.Text = "Check DNS (Event Based)";
            this.checkDns.UseVisualStyleBackColor = true;
            this.checkDns.Click += new System.EventHandler(this.checkDns_Click);
            // 
            // ipsListBox
            // 
            this.ipsListBox.FormattingEnabled = true;
            this.ipsListBox.Location = new System.Drawing.Point(38, 68);
            this.ipsListBox.Name = "ipsListBox";
            this.ipsListBox.Size = new System.Drawing.Size(157, 95);
            this.ipsListBox.TabIndex = 3;
            // 
            // checkDnsAsync
            // 
            this.checkDnsAsync.Location = new System.Drawing.Point(201, 39);
            this.checkDnsAsync.Name = "checkDnsAsync";
            this.checkDnsAsync.Size = new System.Drawing.Size(167, 23);
            this.checkDnsAsync.TabIndex = 4;
            this.checkDnsAsync.Text = "Check DNS (async)";
            this.checkDnsAsync.UseVisualStyleBackColor = true;
            this.checkDnsAsync.Click += new System.EventHandler(this.checkDnsAsync_Click);
            // 
            // faviconListBox
            // 
            this.faviconListBox.FormattingEnabled = true;
            this.faviconListBox.Location = new System.Drawing.Point(201, 68);
            this.faviconListBox.Name = "faviconListBox";
            this.faviconListBox.Size = new System.Drawing.Size(157, 95);
            this.faviconListBox.TabIndex = 5;
            // 
            // faviconListBoxAn
            // 
            this.faviconListBoxAn.FormattingEnabled = true;
            this.faviconListBoxAn.Location = new System.Drawing.Point(364, 68);
            this.faviconListBoxAn.Name = "faviconListBoxAn";
            this.faviconListBoxAn.Size = new System.Drawing.Size(157, 95);
            this.faviconListBoxAn.TabIndex = 6;
            // 
            // btnLongRunningProcess
            // 
            this.btnLongRunningProcess.Location = new System.Drawing.Point(38, 184);
            this.btnLongRunningProcess.Name = "btnLongRunningProcess";
            this.btnLongRunningProcess.Size = new System.Drawing.Size(157, 23);
            this.btnLongRunningProcess.TabIndex = 7;
            this.btnLongRunningProcess.Text = "Start long running process";
            this.btnLongRunningProcess.UseVisualStyleBackColor = true;
            this.btnLongRunningProcess.Click += new System.EventHandler(this.btnLongRunningProcess_Click);
            // 
            // btnVoidReturn
            // 
            this.btnVoidReturn.Location = new System.Drawing.Point(225, 184);
            this.btnVoidReturn.Name = "btnVoidReturn";
            this.btnVoidReturn.Size = new System.Drawing.Size(210, 23);
            this.btnVoidReturn.TabIndex = 8;
            this.btnVoidReturn.Text = "Start long process (void return)";
            this.btnVoidReturn.UseVisualStyleBackColor = true;
            this.btnVoidReturn.Click += new System.EventHandler(this.btnVoidReturn_Click);
            // 
            // btnLargestContent
            // 
            this.btnLargestContent.Location = new System.Drawing.Point(38, 225);
            this.btnLargestContent.Name = "btnLargestContent";
            this.btnLargestContent.Size = new System.Drawing.Size(157, 23);
            this.btnLargestContent.TabIndex = 9;
            this.btnLargestContent.Text = "Find Page With Largest Content";
            this.btnLargestContent.UseVisualStyleBackColor = true;
            this.btnLargestContent.Click += new System.EventHandler(this.btnLargestContent_Click);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(225, 234);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(0, 13);
            this.lblUrl.TabIndex = 10;
            // 
            // dnsChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 278);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.btnLargestContent);
            this.Controls.Add(this.btnVoidReturn);
            this.Controls.Add(this.btnLongRunningProcess);
            this.Controls.Add(this.faviconListBoxAn);
            this.Controls.Add(this.faviconListBox);
            this.Controls.Add(this.checkDnsAsync);
            this.Controls.Add(this.ipsListBox);
            this.Controls.Add(this.checkDns);
            this.Controls.Add(this.txtBoxHost);
            this.Name = "dnsChecker";
            this.Text = "DNS Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxHost;
        private System.Windows.Forms.Button checkDns;
        private System.Windows.Forms.ListBox ipsListBox;
        private System.Windows.Forms.Button checkDnsAsync;
        private System.Windows.Forms.ListBox faviconListBox;
        private System.Windows.Forms.ListBox faviconListBoxAn;
        private System.Windows.Forms.Button btnLongRunningProcess;
        private System.Windows.Forms.Button btnVoidReturn;
        private System.Windows.Forms.Button btnLargestContent;
        private System.Windows.Forms.Label lblUrl;
    }
}


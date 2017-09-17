namespace DesktopClient
{
    partial class serviceClient
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
            this.txtBxName = new System.Windows.Forms.TextBox();
            this.btnInvokeService = new System.Windows.Forms.Button();
            this.lblReturnedValue = new System.Windows.Forms.Label();
            this.btnLibraryService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBxName
            // 
            this.txtBxName.Location = new System.Drawing.Point(30, 34);
            this.txtBxName.Name = "txtBxName";
            this.txtBxName.Size = new System.Drawing.Size(100, 20);
            this.txtBxName.TabIndex = 0;
            // 
            // btnInvokeService
            // 
            this.btnInvokeService.Location = new System.Drawing.Point(160, 34);
            this.btnInvokeService.Name = "btnInvokeService";
            this.btnInvokeService.Size = new System.Drawing.Size(162, 23);
            this.btnInvokeService.TabIndex = 1;
            this.btnInvokeService.Text = "Invoke Service";
            this.btnInvokeService.UseVisualStyleBackColor = true;
            this.btnInvokeService.Click += new System.EventHandler(this.btnInvokeService_Click);
            // 
            // lblReturnedValue
            // 
            this.lblReturnedValue.AutoSize = true;
            this.lblReturnedValue.Location = new System.Drawing.Point(27, 74);
            this.lblReturnedValue.Name = "lblReturnedValue";
            this.lblReturnedValue.Size = new System.Drawing.Size(97, 13);
            this.lblReturnedValue.TabIndex = 2;
            this.lblReturnedValue.Text = "Returned Message";
            // 
            // btnLibraryService
            // 
            this.btnLibraryService.Location = new System.Drawing.Point(160, 74);
            this.btnLibraryService.Name = "btnLibraryService";
            this.btnLibraryService.Size = new System.Drawing.Size(162, 23);
            this.btnLibraryService.TabIndex = 3;
            this.btnLibraryService.Text = "Invoke Library Service";
            this.btnLibraryService.UseVisualStyleBackColor = true;
            this.btnLibraryService.Click += new System.EventHandler(this.btnLibraryService_Click);
            // 
            // serviceClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 262);
            this.Controls.Add(this.btnLibraryService);
            this.Controls.Add(this.lblReturnedValue);
            this.Controls.Add(this.btnInvokeService);
            this.Controls.Add(this.txtBxName);
            this.Name = "serviceClient";
            this.Text = "Web Service Desktop Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBxName;
        private System.Windows.Forms.Button btnInvokeService;
        private System.Windows.Forms.Label lblReturnedValue;
        private System.Windows.Forms.Button btnLibraryService;
    }
}


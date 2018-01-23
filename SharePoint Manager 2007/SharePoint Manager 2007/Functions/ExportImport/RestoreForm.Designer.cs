namespace Keutmann.SharePointManager.Forms
{
    partial class RestoreForm
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
            this.lblSiteName = new System.Windows.Forms.Label();
            this.tbSiteName = new System.Windows.Forms.TextBox();
            this.cbOverride = new System.Windows.Forms.CheckBox();
            this.cbHostHeader = new System.Windows.Forms.CheckBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbFile = new System.Windows.Forms.GroupBox();
            this.cbSite = new System.Windows.Forms.GroupBox();
            this.gbFile.SuspendLayout();
            this.cbSite.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSiteName
            // 
            this.lblSiteName.AutoSize = true;
            this.lblSiteName.Location = new System.Drawing.Point(12, 16);
            this.lblSiteName.Name = "lblSiteName";
            this.lblSiteName.Size = new System.Drawing.Size(39, 13);
            this.lblSiteName.TabIndex = 0;
            this.lblSiteName.Text = "Site url";
            // 
            // tbSiteName
            // 
            this.tbSiteName.Location = new System.Drawing.Point(15, 32);
            this.tbSiteName.Name = "tbSiteName";
            this.tbSiteName.Size = new System.Drawing.Size(313, 20);
            this.tbSiteName.TabIndex = 2;
            // 
            // cbOverride
            // 
            this.cbOverride.AutoSize = true;
            this.cbOverride.Location = new System.Drawing.Point(15, 58);
            this.cbOverride.Name = "cbOverride";
            this.cbOverride.Size = new System.Drawing.Size(117, 17);
            this.cbOverride.TabIndex = 3;
            this.cbOverride.Text = "Override site if exist";
            this.cbOverride.UseVisualStyleBackColor = true;
            // 
            // cbHostHeader
            // 
            this.cbHostHeader.AutoSize = true;
            this.cbHostHeader.Location = new System.Drawing.Point(15, 81);
            this.cbHostHeader.Name = "cbHostHeader";
            this.cbHostHeader.Size = new System.Drawing.Size(146, 17);
            this.cbHostHeader.TabIndex = 4;
            this.cbHostHeader.Text = "Host header as site name";
            this.cbHostHeader.UseVisualStyleBackColor = true;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(298, 31);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(31, 20);
            this.btnFile.TabIndex = 1;
            this.btnFile.Text = "&File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(16, 16);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(111, 13);
            this.lblFileName.TabIndex = 5;
            this.lblFileName.Text = "Select site backup file";
            // 
            // tbFilename
            // 
            this.tbFilename.Location = new System.Drawing.Point(19, 32);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.Size = new System.Drawing.Size(273, 20);
            this.tbFilename.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(185, 202);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(266, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbFile
            // 
            this.gbFile.Controls.Add(this.lblFileName);
            this.gbFile.Controls.Add(this.btnFile);
            this.gbFile.Controls.Add(this.tbFilename);
            this.gbFile.Location = new System.Drawing.Point(3, 12);
            this.gbFile.Name = "gbFile";
            this.gbFile.Size = new System.Drawing.Size(338, 59);
            this.gbFile.TabIndex = 9;
            this.gbFile.TabStop = false;
            this.gbFile.Text = "Backup file";
            // 
            // cbSite
            // 
            this.cbSite.Controls.Add(this.lblSiteName);
            this.cbSite.Controls.Add(this.tbSiteName);
            this.cbSite.Controls.Add(this.cbOverride);
            this.cbSite.Controls.Add(this.cbHostHeader);
            this.cbSite.Location = new System.Drawing.Point(3, 78);
            this.cbSite.Name = "cbSite";
            this.cbSite.Size = new System.Drawing.Size(338, 109);
            this.cbSite.TabIndex = 10;
            this.cbSite.TabStop = false;
            this.cbSite.Text = "SharePoint site";
            // 
            // RestoreForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(345, 233);
            this.Controls.Add(this.cbSite);
            this.Controls.Add(this.gbFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RestoreForm";
            this.ShowIcon = false;
            this.Text = "Restore site";
            this.gbFile.ResumeLayout(false);
            this.gbFile.PerformLayout();
            this.cbSite.ResumeLayout(false);
            this.cbSite.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSiteName;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbFile;
        private System.Windows.Forms.GroupBox cbSite;
        public System.Windows.Forms.TextBox tbSiteName;
        public System.Windows.Forms.CheckBox cbOverride;
        public System.Windows.Forms.CheckBox cbHostHeader;
        public System.Windows.Forms.TextBox tbFilename;
    }
}
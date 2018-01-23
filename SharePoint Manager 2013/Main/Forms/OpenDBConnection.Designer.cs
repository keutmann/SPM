namespace Keutmann.SharePointManager.Forms
{
    partial class OpenDBConnection
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelSQLServerAuthentication = new System.Windows.Forms.Panel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.rbSQLserverAuthentication = new System.Windows.Forms.RadioButton();
            this.rbWindowsAuthentication = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSelectDatabase = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panelSQLServerAuthentication.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter information to connect to a SharePoint Configuration Database.";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(12, 36);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(69, 13);
            this.lblServerName.TabIndex = 2;
            this.lblServerName.Text = "Server Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelSQLServerAuthentication);
            this.groupBox1.Controls.Add(this.rbSQLserverAuthentication);
            this.groupBox1.Controls.Add(this.rbWindowsAuthentication);
            this.groupBox1.Location = new System.Drawing.Point(15, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 145);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log on to the server";
            // 
            // panelSQLServerAuthentication
            // 
            this.panelSQLServerAuthentication.Controls.Add(this.lblPassword);
            this.panelSQLServerAuthentication.Controls.Add(this.tbPassword);
            this.panelSQLServerAuthentication.Controls.Add(this.label2);
            this.panelSQLServerAuthentication.Controls.Add(this.tbUserName);
            this.panelSQLServerAuthentication.Enabled = false;
            this.panelSQLServerAuthentication.Location = new System.Drawing.Point(12, 66);
            this.panelSQLServerAuthentication.Name = "panelSQLServerAuthentication";
            this.panelSQLServerAuthentication.Size = new System.Drawing.Size(330, 66);
            this.panelSQLServerAuthentication.TabIndex = 7;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 38);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Password";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(84, 35);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(231, 20);
            this.tbPassword.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "User name:";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(84, 8);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(231, 20);
            this.tbUserName.TabIndex = 8;
            // 
            // rbSQLserverAuthentication
            // 
            this.rbSQLserverAuthentication.AutoSize = true;
            this.rbSQLserverAuthentication.Location = new System.Drawing.Point(12, 43);
            this.rbSQLserverAuthentication.Name = "rbSQLserverAuthentication";
            this.rbSQLserverAuthentication.Size = new System.Drawing.Size(173, 17);
            this.rbSQLserverAuthentication.TabIndex = 1;
            this.rbSQLserverAuthentication.Text = "Use SQL Server Authentication";
            this.rbSQLserverAuthentication.UseVisualStyleBackColor = true;
            this.rbSQLserverAuthentication.CheckedChanged += new System.EventHandler(this.rbWindowsAuthentication_CheckedChanged);
            // 
            // rbWindowsAuthentication
            // 
            this.rbWindowsAuthentication.AutoSize = true;
            this.rbWindowsAuthentication.Checked = true;
            this.rbWindowsAuthentication.Location = new System.Drawing.Point(12, 19);
            this.rbWindowsAuthentication.Name = "rbWindowsAuthentication";
            this.rbWindowsAuthentication.Size = new System.Drawing.Size(162, 17);
            this.rbWindowsAuthentication.TabIndex = 0;
            this.rbWindowsAuthentication.TabStop = true;
            this.rbWindowsAuthentication.Text = "Use Windows Authentication";
            this.rbWindowsAuthentication.UseVisualStyleBackColor = true;
            this.rbWindowsAuthentication.CheckedChanged += new System.EventHandler(this.rbWindowsAuthentication_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbDatabase);
            this.groupBox2.Controls.Add(this.lblSelectDatabase);
            this.groupBox2.Location = new System.Drawing.Point(15, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 76);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connect to a  SharePoint Configuration Database";
            // 
            // lblSelectDatabase
            // 
            this.lblSelectDatabase.AutoSize = true;
            this.lblSelectDatabase.Location = new System.Drawing.Point(10, 25);
            this.lblSelectDatabase.Name = "lblSelectDatabase";
            this.lblSelectDatabase.Size = new System.Drawing.Size(175, 13);
            this.lblSelectDatabase.TabIndex = 1;
            this.lblSelectDatabase.Text = "Enter configuration database name:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(288, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(207, 321);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(15, 321);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(97, 23);
            this.btnTestConnection.TabIndex = 6;
            this.btnTestConnection.Text = "&Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(15, 53);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(348, 20);
            this.tbServer.TabIndex = 9;
            // 
            // tbDatabase
            // 
            this.tbDatabase.Location = new System.Drawing.Point(12, 41);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Size = new System.Drawing.Size(315, 20);
            this.tbDatabase.TabIndex = 2;
            // 
            // OpenDBConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 354);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OpenDBConnection";
            this.ShowIcon = false;
            this.Text = "Open Connection";
            this.Load += new System.EventHandler(this.AddDBConnection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelSQLServerAuthentication.ResumeLayout(false);
            this.panelSQLServerAuthentication.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label lblSelectDatabase;
        private System.Windows.Forms.Panel panelSQLServerAuthentication;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RadioButton rbWindowsAuthentication;
        public System.Windows.Forms.RadioButton rbSQLserverAuthentication;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TextBox tbDatabase;
    }
}
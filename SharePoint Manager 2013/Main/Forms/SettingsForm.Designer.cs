namespace Keutmann.SharePointManager.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.bottomPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.panel1);
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 343);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(484, 40);
            this.bottomPanel.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(3, 6);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.splitContainer);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(484, 343);
            this.mainPanel.TabIndex = 1;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Size = new System.Drawing.Size(484, 343);
            this.splitContainer.SplitterDistance = 241;
            this.splitContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(393, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(91, 40);
            this.panel1.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(13, 6);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 383);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.bottomPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.bottomPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
    }
}
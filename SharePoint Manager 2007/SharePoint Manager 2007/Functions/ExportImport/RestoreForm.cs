using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Forms
{
    public partial class RestoreForm : Form
    {
        public RestoreForm()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                tbFilename.Text = fileDialog.FileName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if (!File.Exists(tbFilename.Text))
            {
                message += SPMLocalization.GetString("The file") + " '" + tbFilename.Text + "' " + SPMLocalization.GetString("Do_Not_Exist") + "\r\n";
            }

            if (tbSiteName.Text.Trim().Length == 0)
            {
                message += SPMLocalization.GetString("Specify_Site_Url") + "\r\n";
            }

            if (message.Length == 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
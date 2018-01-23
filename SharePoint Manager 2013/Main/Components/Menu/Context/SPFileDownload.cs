using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Keutmann.SharePointManager.ViewModel.TreeView;
using SPM2.SharePoint.Model;
using SPM2.Framework.IoC;

namespace Keutmann.SharePointManager.Components.Menu
{
    //[Export("SPM2.SharePoint.Model.SPFileNode", typeof(ToolStripItem))]
    //[ExportMetadata("Order", 100)]
    //[PartCreationPolicy(CreationPolicy.NonShared)]

    [IoCBind(typeof(SPFileNode), 100)]
    public class SPFileDownload : ToolStripMenuItem, ISPMenuItem
    {
        public SPTreeNode TreeNode { get; set; }

        public SPFileDownload()
        {
            Text = "Download";
        }


        protected override void OnClick(EventArgs e)
        {
            var model = (SPFileNode)TreeNode.Model;
            
            Stream saveStream = null;
            Stream spFileStream = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.FileName = model.File.Name;
                DialogResult result = saveDialog.ShowDialog();
                if (result == DialogResult.OK)
                {

                    saveStream = saveDialog.OpenFile();
                    if (saveStream != null)
                    {
                        spFileStream = model.File.OpenBinaryStream(); 

                        spFileStream.Position = 0;

                        CopyStream(spFileStream, saveStream);
                    }
                }
            }
            finally
            {
                if (saveStream != null)
                {
                    saveStream.Close();
                }
                if (spFileStream != null)
                {
                    spFileStream.Close();
                }

                Cursor.Current = Cursors.Default;
            }

        }

        private void CopyStream(Stream input, Stream output)
        {
            byte[] bytes = new byte[4096];

            int i;
            while ((i = input.Read(bytes, 0, bytes.Length)) != 0)
            {
                output.Write(bytes, 0, i);
            }
        }

    }
}

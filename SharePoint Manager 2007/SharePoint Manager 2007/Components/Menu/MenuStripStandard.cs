using System;
using System.Reflection;
using System.ComponentModel;

using System.Drawing;
using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager;
using Keutmann.SharePointManager.Library;


namespace Keutmann.SharePointManager.Components
{
    public class MenuStripStandard : ContextMenuStripBase
    {

        public ToolStripItem CutItem;
        public ToolStripItem CopyItem;
        public ToolStripItem PasteItem;
        public ToolStripItem DeleteItem;
        public ToolStripItem RefreshItem;


        public MenuStripStandard()
        {
            Init();
        }

        public MenuStripStandard(IContainer container)
            : base(container)
        {
            Init();
        }


        private void Init()
        {
            CutItem = SPMMenu.Items.CreateCut();
            CopyItem = SPMMenu.Items.CreateCopy();
            PasteItem = SPMMenu.Items.CreatePaste();
            DeleteItem = SPMMenu.Items.CreateDelete();
            RefreshItem = SPMMenu.Items.CreateRefresh();

            //this.Items.AddRange(new ToolStripItem[] {
            //    CutItem,
            //    CopyItem,
            //    PasteItem,
            //    DeleteItem,
            //    SPMMenu.Items.CreateSeparator(),
            //    RefreshItem
            //   });

            this.Items.AddRange(new ToolStripItem[] {
                DeleteItem,
                SPMMenu.Items.CreateSeparator(),
                RefreshItem
               });
                
               this.Name = "BasicMenuStrip";
        }

        private bool IsMethodImplementet(Type nodeType, string name)
        {
            return nodeType.GetMethod(name).DeclaringType == nodeType;
        }

        protected override void OnOpening(CancelEventArgs e)
        {
            base.OnOpening(e);

            Type nodeType = this.CurrentNode.GetType();

            CopyItem.Enabled    = IsMethodImplementet(nodeType, "CopyToClipboard");
            CutItem.Enabled     = IsMethodImplementet(nodeType, "CutToClipboard");
            PasteItem.Enabled   = Clipboard.ContainsText() && IsMethodImplementet(nodeType, "PasteFromClipboard");
            
            //DeleteItem.Enabled  = IsMethodImplementet(nodeType, "Delete");
            
            DeleteItem.Enabled = SPMReflection.DoMethodExists(this.CurrentNode.Tag.GetType(), "Delete", new Type[] { });
        }

    }
}

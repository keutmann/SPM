using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.WPF.Controls;
using SPM2.Framework.ComponentModel;
using SPM2.SharePoint.Model;
using System.ComponentModel.Composition;
using GalaSoft.MvvmLight.Command;
using SPM2.SharePoint;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using SPM2.Framework.WPF;
using ICSharpCode.TreeView;

namespace SPM2.Main.Commands.ContextMenu
{
    [ExportToContextMenu(typeof(SPNode))]
    [ExportMetadata("ID", RefeshContextMenu.AddInID)]
    [ExportMetadata("Order", 1)]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class RefeshContextMenu : SPM2.Framework.WPF.Controls.MenuItem, IContextMenuItem
    {
        public const string AddInID = "SPM2.Main.Commands.ContextMenu.RefeshContextMenu";

        public SPNode CurrentNode { get; set; }

        public RefeshContextMenu()
        {
            this.Header = "Refesh";
            this.Icon = ImageExtensions.LoadImage("/SPM2.Main;component/resources/images\\refresh3.gif");

            this.Command = new RelayCommand(Execute);
        }


        public void SetupItem(object target)
        {
            this.CurrentNode = (SPNode)target;
        }


        public void Execute()
        {
            //this.CurrentNode = this.CurrentNode.Refresh();

            //this.CurrentNode.ResetChildren(true);
        }

    }
}

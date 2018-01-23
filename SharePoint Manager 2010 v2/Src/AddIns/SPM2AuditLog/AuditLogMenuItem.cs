using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;

using SPM2.Framework.ComponentModel;
using SPM2.Framework.WPF;
using SPM2.SharePoint.Model;
using System.ComponentModel.Composition;
using SPM2.SharePoint;
using SPM2AuditLog.Model;
using SPM2AuditLog.Windows;
using SPM2AuditLog.ViewModel;

namespace SPM2AuditLog
{


    [ExportToContextMenu(typeof(SPSiteNode))]
    [ExportToContextMenu(typeof(SPWebNode))]
    [ExportToContextMenu(typeof(SPListItemNode))]
    [ExportToContextMenu(typeof(SPFileNode))]
    [ExportMetadata("ID", AuditLogMenuItem.AddInID)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AuditLogMenuItem : SPM2.Framework.WPF.Controls.MenuItem, IContextMenuItem
    {

        public const string AddInID = "SPM2AuditLog.AuditLogMenuItem";

        public SPNode CurrentNode { get; set; }

        public AuditLogMenuItem()
        {
            this.Header = "Auditlog";
            this.Icon = ImageExtensions.LoadImage(SharePointContext.GetImagePath("ICPPSDC.GIF"));

            this.Command = new RelayCommand(Execute);
        }

        public void SetupItem(object target)
        {
            this.CurrentNode = (SPNode)target;
        }


        public void Execute()
        {

            AuditLogViewerModel viewModel = new AuditLogViewerModel()
            {
                Model = new AuditLogModel(this.CurrentNode)
            };

            AuditLogViewer window = new AuditLogViewer();

            window.DataContext = viewModel;

            window.ShowDialog();
        }

    }
}

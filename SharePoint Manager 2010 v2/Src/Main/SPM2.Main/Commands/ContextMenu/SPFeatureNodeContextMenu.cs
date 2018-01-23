using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.WPF.Controls;
using SPM2.Framework.ComponentModel;
using System.ComponentModel.Composition;
using SPM2.SharePoint.Model;
using GalaSoft.MvvmLight.Command;
using SPM2.Framework.WPF.Commands;
using System.Windows.Input;

namespace SPM2.Main.Commands.ContextMenu
{
    [ExportToContextMenu(typeof(SPFeatureNode))]
    [ExportMetadata("ID", ActivateFeature.AddInID)]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class ActivateFeature : MenuItem, IContextMenuItem
    {
        public const string AddInID = "SPM2.Main.Commands.ContextMenu.ActivateFeature";

        public SPFeatureNode Node { get; set; }

        public ActivateFeature()
        {
            this.Header = "Activate Feature";
        }


        public void SetupItem(object target)
        {
            this.Node = (SPFeatureNode)target;
            this.Command = new RelayCommand(Execute, CanExecute);
        }

        private void Execute()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                this.Node.ActivateFeature();
                SPM2Commands.ObjectSelected.Execute(this.Node, null);
            }
            finally
            {
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }

        private bool CanExecute()
        {
            return !this.Node.Activated;
        }
    }

    [ExportToContextMenu(typeof(SPFeatureNode))]
    [ExportMetadata("ID", DeactivateFeature.AddInID)]
    [ExportMetadata("After", ActivateFeature.AddInID)]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class DeactivateFeature : MenuItem, IContextMenuItem
    {
        public const string AddInID = "SPM2.Main.Commands.ContextMenu.DeactivateFeature";


        public SPFeatureNode Node { get; set; }

        public DeactivateFeature()
        {
            this.Header = "Deactivate Feature";
        }


        public void SetupItem(object target)
        {
            this.Node = (SPFeatureNode)target;
            this.Command = new RelayCommand(Execute, CanExecute);
        }

        private void Execute()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                this.Node.DeactivateFeature();
                SPM2Commands.ObjectSelected.Execute(this.Node, null);
            }
            finally
            {
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }

        private bool CanExecute()
        {
            return this.Node.Activated;
        }
    }
}

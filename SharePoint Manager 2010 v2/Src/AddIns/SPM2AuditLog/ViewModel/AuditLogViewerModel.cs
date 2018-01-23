using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.ComponentModel.Composition;
using SPM2AuditLog.Model;

namespace SPM2AuditLog.ViewModel
{
    public class AuditLogViewerModel : ViewModelBase, IPartImportsSatisfiedNotification
    {
        public AuditLogModel Model { get; set; }

        public AuditLogViewerModel()
        {
            try
            {

                //_cancelCommand = ApplicationCommands.CancelPrint;

                if (IsInDesignMode)
                {
                    //this.Name = "InDesign";
                }
                else
                {
                    //this.OKCommand = new RelayCommand(OKHandler);
                    //this.CancelCommand = new RelayCommand(CancelHandler);
                    //// Code runs "for real": Connect to service, etc...
                    ////this.Name = "In Runtime : Test";
                    //CompositionProvider.Current.ComposeParts(this);

                    //this.Root = new SettingsModel();
                    //this.Root.SettingsObject = SettingsProvider.Current.Root.Clone();
                    //this.Root.IsExpanded = true;

                    //_okCommand = new RelayCommand(new Action(OKHandler));
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public void OnImportsSatisfied()
        {
            
        }
    }
}

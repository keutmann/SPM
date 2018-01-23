using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using GalaSoft.MvvmLight;
using System.ComponentModel.Composition;
using SPM2.Framework;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using SPM2.Framework.ComponentModel;
using System.Diagnostics;
using SPM2.Framework.Configuration;
using SPM2.Framework.WPF.ViewModel.TreeView;
using SPM2.Framework.Xml;

namespace SPM2.Framework.WPF.Windows.ViewModel
{
    public class SettingsDialogModel : ViewModelBase, IPartImportsSatisfiedNotification
    {

        public ICommand OKCommand { get; private set; }
        public ICommand CancelCommand {get; private set;}


        public SettingsModel Root
        {
            get;
            set;
        }


        public SettingsDialogModel()
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
                    this.OKCommand = new RelayCommand(OKHandler);
                    this.CancelCommand = new RelayCommand(CancelHandler);
                    // Code runs "for real": Connect to service, etc...
                    //this.Name = "In Runtime : Test";
                    CompositionProvider.Current.ComposeParts(this);

                    this.Root = new SettingsModel();
                    this.Root.SettingsObject = SettingsProvider.Current.Root.Clone();
                    this.Root.IsExpanded = true;

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

        private void OKHandler()
        {
            try
            {

                Stopwatch watch = new Stopwatch();
                watch.Start();

                Action save = new Action(Save);
                save.BeginInvoke(null, null);


                watch.Stop();
                Trace.WriteLine("Call to SettingsProvider.Current.Save(); = " + watch.ElapsedMilliseconds + " Milliseconds");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void CancelHandler()
        {
            // Ignore

        }

        private void Save()
        {
            // Use the changed settings instead of the current settings
            SettingsProvider.Current.Root = (SettingsRoot)this.Root.SettingsObject;
            SettingsProvider.Current.Save();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.ComponentModel.Composition;
using System.Windows.Interop;
using System.Diagnostics;

using SPM2.Framework;
using SPM2.Framework.Collections;
using System.Windows.Threading;
using SPM2.Main.ViewModel;
using System.Threading;

namespace SPM2.Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    [Export()]
    public partial class App : Application
    {

        AppModel model = null;

        Stopwatch timerWatch = new Stopwatch();
        

        public App()
        {
            timerWatch.Start();
            
            this.model = new AppModel();
        }


        void Start(object sender, StartupEventArgs e)
        {
            this.ShowWindow(this.model.MainWindow);
        }


        void ShowWindow(Window window)
        {
            // Create the main window, but on the UI thread.
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                this.MainWindow = window;
                this.MainWindow.Show();
            }));
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Trace.TraceError(e.Exception.GetMessages());

#if DEBUG
            MessageBox.Show(e.Exception.Message + "\r\n -> " + e.Exception.StackTrace, "Error! (Debug mode)", MessageBoxButton.OK, MessageBoxImage.Error);
#else
            MessageBox.Show(e.Exception.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
#endif
            e.Handled = true;
        }

    }
}

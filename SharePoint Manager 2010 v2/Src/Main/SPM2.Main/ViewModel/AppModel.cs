using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Main.GUI;
using SPM2.Framework.Collections;
using SPM2.Framework;
using System.Windows;
using System.Reflection;
using System.Diagnostics;
using SPM2.Framework.WPF;

namespace SPM2.Main.ViewModel
{

    public class AppModel
    {
        public const string SPLASHSCREEN_CONTRACT_NAME = "SplashScreen";
        public const string MAINWINDOW_CONTRACT_NAME = "MainWindow";


        private Window _mainWindow = null;
        public Window MainWindow
        {
            get
            {
                if (_mainWindow == null)
                {
                    // Setup code here!
                    OrderingCollection<Window> orderedItems = CompositionProvider.GetOrderedExports<Window>(MAINWINDOW_CONTRACT_NAME);
                    if (orderedItems.Count > 0)
                    {
                        _mainWindow = orderedItems[0].Value;
                        CommandToMessenger.Relay(_mainWindow);
                    }
                }
                return _mainWindow;
            }
            set
            {
                _mainWindow = value;
            }
        }

        public AppModel()
        {
            Application.Current.MainWindow = this.MainWindow;
        }







    }
}

using System;
using SPM2.Framework;
using SPM2.Main;
using System.Windows.Interop;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using System.Diagnostics;
using System.Windows.Threading;
using SPM2.Framework.ComponentModel;
using SPM2.Main.ComponentModel;
using System.Reflection;


namespace SPM2.StartApp
{
    public class ApplicationStarter : IDisposable
    {
        App app = null;


        public ApplicationStarter()
        {
        }

        public void OpenDebugWindow()
        {
#if DEBUG
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = true;
            ConsoleManager.Show();
            Console.WindowWidth = 120;
            Console.WindowHeight = 50;
            Trace.Listeners.Add(new ConsoleTraceListener(true));
            Debug.WriteLine("SharePoint Manager 2010 Debugger window");
#endif

        }

        public void OpenSplashScreen()
        {
            Assembly assem = Assembly.Load("SPM2.Main");
            SplashScreen screen = new SplashScreen(assem, "Resources/Images/SplashScreen.png");
            screen.Show(true);
        }


        public void Initialize()
        {
            PropertyGridTypeConverter.AddEditor(typeof(string), typeof(StringEditor));

            System.Windows.Forms.Integration.WindowsFormsHost.EnableWindowsFormsInterop();
            ComponentDispatcher.ThreadIdle -= ComponentDispatcher_ThreadIdle; // ensure we don't register twice
            ComponentDispatcher.ThreadIdle += ComponentDispatcher_ThreadIdle;

            CompositionProvider.LoadAssemblies();
        }

        public void ParseCommandline(string[] args)
        {
        }


        public void Execute(string[] args)
        {
            app = new App();
            app.InitializeComponent();
            app.Run();
        }

        #region Eventhandlers

        void ComponentDispatcher_ThreadIdle(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.RaiseIdle(e);
        }


        #endregion

        public void Dispose()
        {
            ComponentDispatcher.ThreadIdle -= ComponentDispatcher_ThreadIdle;
        }
    }
}

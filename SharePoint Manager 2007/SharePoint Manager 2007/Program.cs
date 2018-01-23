using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Keutmann.SharePointManager.Forms;
using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager
{
    static class Program
    {
        public static MainWindow Window = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Window = new MainWindow();

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(Window);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            MessageBox.Show(e.Exception.Message, SPMLocalization.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
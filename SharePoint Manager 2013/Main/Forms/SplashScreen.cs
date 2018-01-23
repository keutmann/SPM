using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SPM2.Framework.Validation;
using SPM2.SharePoint;
using System.Diagnostics;

namespace Keutmann.SharePointManager.Forms
{
    public partial class SplashScreen : Form
    {
        Func<SplashScreen, ValidationResult> Setup;
        ValidationResult result;

        public SplashScreen(Func<SplashScreen, ValidationResult> setup)
        {
            InitializeComponent();
            label1.Text = SPMEnvironment.Version.Title; 

            Setup = setup;
            Shown += SplashScreen_Shown;
        }

        void SplashScreen_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            try
            {
                result = Setup.Invoke(this);
            }
            catch(Exception ex)
            {
#if DEBUG
                Trace.TraceError(ex.Message + " : " + ex.StackTrace);
                MessageBox.Show(ex.Message+" : "+ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
            finally
            {
                this.Close();
            }
        }

        public void UpdateProgress(string message)
        {
            ProgressLabel.Text = message;
            Application.DoEvents();
        }

        static public ValidationResult ShowSplashScreen(Func<SplashScreen, ValidationResult> setup)
        {
            var screen = new SplashScreen(setup);
            Application.Run(screen);

            return screen.result;
        }
    }
}

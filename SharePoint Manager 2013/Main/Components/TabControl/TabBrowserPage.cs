using System;
using System.Diagnostics;
using System.Windows.Forms;
using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class TabBrowserPage : TabPage
    {
        private WebBrowser _browser = null;

        public WebBrowser Browser
        {
            get 
            {
                if (_browser == null)
                {
                    _browser = new WebBrowser();
                    _browser.Dock = DockStyle.Fill;
                    _browser.AllowNavigation = true;
                }
                return _browser; 
            }
        }

        public string Url
        {
            get
            {
                return Browser.Url + string.Empty;
            }
            set
            {
                Browser.Url = new Uri(value);
                Trace.WriteLine("Browser updated with url: " + value);
            }
        }

        public TabBrowserPage() : base()
        {
            this.Controls.Clear();
            this.Controls.Add(Browser);
            this.Name = "Browser";
            this.Text = SPMLocalization.GetString("Browser_Text");
            this.UseVisualStyleBackColor = true;
            
        }

        public TabBrowserPage(string titel, string url)
            : this()
        {
            this.Text = titel;
            this.Url = url;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

    }
}

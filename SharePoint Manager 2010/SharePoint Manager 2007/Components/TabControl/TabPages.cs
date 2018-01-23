using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Keutmann.SharePointManager.Components
{
    public class TabPages
    {
        #region Const 

        public const string PROPERTIES = "Properties";

        #endregion

        #region Instance members

        protected Dictionary<string, TabPage> _alPagesStore = new Dictionary<string, TabPage>();

        protected TabPage[] _standardPages = null;

        //protected TabPropertyPage _propertyPage = new TabPropertyPage();
        //protected TabBrowserPage _browserPage = new TabBrowserPage();
        //protected TabDataGridViewPage _dataGridViewPage = new TabDataGridViewPage();
        //protected TabXmlPage _xmlPage = new TabXmlPage();
        //protected TabTextPage _textPage = new TabTextPage();

        #endregion

        #region Static Members

        //public static TabTextPage TextPage
        //{
        //    get
        //    {
        //        return Instance._textPage;
        //    }
        //}

        //public static TabXmlPage XmlPage
        //{
        //    get
        //    {
        //        return Instance._xmlPage;
        //    }
        //}

        //public static TabPropertyPage PropertyPage
        //{
        //    get
        //    {
        //        return Instance._propertyPage;
        //    }
        //}

        //public static TabBrowserPage BrowserPage
        //{
        //    get
        //    {
        //        return Instance._browserPage;
        //    }
        //}

        //public static TabDataGridViewPage DataGridViewPage
        //{
        //    get
        //    {
        //        return Instance._dataGridViewPage;
        //    }
        //}


        //public static TabPage[] StandardPages
        //{
        //    get
        //    {
        //        return Instance._standardPages;
        //    }
        //}

        public static TabPropertyPage GetPropertyPage(string title, object obj)
        {
            string key = title + "PROPERTY";
            TabPage page = null;
            if (!Instance._alPagesStore.TryGetValue(key, out page))
            {
                page = new TabPropertyPage(title, obj);
                Instance._alPagesStore.Add(key, page);
            }
            else
            {
                ((TabPropertyPage)page).Grid.SelectedObject = obj;
            }
            return (TabPropertyPage)page;
        }

        public static TabBrowserPage GetBrowserPage(string title, string url)
        {
            string key = title + "BROWSER";
            TabPage page = null;
            if (!Instance._alPagesStore.TryGetValue(key, out page))
            {
                page = new TabBrowserPage(title, url);
                Instance._alPagesStore.Add(key, page);
            }
            else
            {
                ((TabBrowserPage)page).Url = url;
            }
            return (TabBrowserPage)page;
        }

        public static TabDataGridViewPage GetDataGridViewPage(string title, object obj)
        {
            string key = title + "DataGridView";
            TabPage page = null;
            if (!Instance._alPagesStore.TryGetValue(key, out page))
            {
                page = new TabDataGridViewPage(title, obj);
                Instance._alPagesStore.Add(key, page);
            }
            else
            {
                ((TabDataGridViewPage)page).GridView.DataSource = obj;
            }
            return (TabDataGridViewPage)page;
        }

        public static TabXmlPage GetXmlPage(string title, string xml)
        {
            string key = title+"XML";
            TabPage page = null;
            if (!Instance._alPagesStore.TryGetValue(key, out page))
            {
                page = new TabXmlPage(title, xml);
                Instance._alPagesStore.Add(key, page);
            }
            else
            {
                ((TabXmlPage)page).Xml = xml;
            }
            return (TabXmlPage)page;
        }

        public static TabTextPage GetTextPage(string title, string text)
        {
            string key = title + "TEXT";
            TabPage page = null;
            if (!Instance._alPagesStore.TryGetValue(key, out page))
            {
                page = new TabTextPage(title, text);
                Instance._alPagesStore.Add(key, page);
            }
            else
            {
                ((TabTextPage)page).RichTextBox.Text = text;
            }

            return (TabTextPage)page;
        }


        internal TabPages()
        {
            //_standardPages = new TabPage[] { _textPage };
        }

        #endregion

        #region Singleton

        private static readonly TabPages _instance = new TabPages();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static TabPages()
        {
        }



        protected static TabPages Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion
    }
}

using System;
using System.Windows.Forms;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class TabXmlPage : TabPage
    {
        private RichTextBox _richTextBox = null;

        public RichTextBox RichTextBox
        {
            get 
            {
                if (_richTextBox == null)
                {
                    _richTextBox = new RichTextBox();
                    _richTextBox.Dock = DockStyle.Fill;
                    _richTextBox.WordWrap = false;
                }
                return _richTextBox; 
            }
            set { _richTextBox = value; }
        }

        public string Xml
        {
            get
            {
                return RichTextBox.Text;
            }
            set
            {
                RichTextBox.Text = SPMUtility.FormatXml(value); 
            }
        }

        public TabXmlPage() : base()
        {
            this.Controls.Clear();
            this.Controls.Add(RichTextBox);
            this.Name = "Xml";
            this.Text = SPMLocalization.GetString("Xml_Text");
            this.UseVisualStyleBackColor = true;
        }

        public TabXmlPage(string titel, string xml)
            : this()
        {
            this.Text = titel;
            this.Xml = xml; 
        }

    }
}

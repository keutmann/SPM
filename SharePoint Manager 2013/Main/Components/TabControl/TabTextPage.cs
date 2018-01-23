using System;
using System.Windows.Forms;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class TabTextPage : TabPage
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
        }

        public TabTextPage() : base()
        {
            this.Controls.Clear();
            this.Controls.Add(RichTextBox);
            this.Name = "Text";
            this.Text = SPMLocalization.GetString("Text_Text");
            this.UseVisualStyleBackColor = true;
            
        }


        public TabTextPage(string titel, string text) : this()
        {
            this.Text = titel;
            this.RichTextBox.Text = text;
        }

    }
}

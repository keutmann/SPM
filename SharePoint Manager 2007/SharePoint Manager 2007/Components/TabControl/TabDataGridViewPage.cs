using System;
using System.Windows.Forms;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    public class TabDataGridViewPage : TabPage
    {
        private DataGridView _gridView = null;

        public DataGridView GridView
        {
            get 
            {
                if (_gridView == null)
                {
                    _gridView = new DataGridView();
                    _gridView.Dock = DockStyle.Fill;
                }
                return _gridView; 
            }
        }

        public TabDataGridViewPage() : base()
        {
            this.Controls.Add(GridView);
            this.Name = "GridView";
            this.Text = SPMLocalization.GetString("GridView_Text");
            this.UseVisualStyleBackColor = true;
            
        }


        public TabDataGridViewPage(string titel, object obj) : this()
        {
            this.Text = titel;
            this.GridView.DataSource = obj;
        }

    }
}

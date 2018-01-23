using System;
using System.Windows.Forms;

namespace Keutmann.SharePointManager.Components
{
    public class TabPropertyPage : TabPage
    {
        private PropertyGrid _grid = null;

        public PropertyGrid Grid
        {
            get 
            {
                if (_grid == null)
                {
                    _grid = new PropertyGrid();
                    _grid.Dock = DockStyle.Fill;
                }
                return _grid; 
            }
        }

        public TabPropertyPage() : base()
        {
            this.Controls.Clear();
            this.Controls.Add(Grid);
            this.Name = TabPages.PROPERTIES;
            this.Text = TabPages.PROPERTIES;
            this.UseVisualStyleBackColor = true;
        }


        public TabPropertyPage(string title, object obj)
            : this()
        {
            this.Text = title;
            this.Grid.SelectedObject = obj;
        }

    }
}

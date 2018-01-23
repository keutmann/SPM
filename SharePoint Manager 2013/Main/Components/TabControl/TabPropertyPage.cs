using System;
using System.Windows.Forms;
using Keutmann.SharePointManager.Components;

namespace Keutmann.SharePointManager.Components
{
    public class TabPropertyPage : TabPage
    {
        private ReadOnlyPropertyGrid _grid = null;

        public ReadOnlyPropertyGrid Grid
        {
            get 
            {
                if (_grid == null)
                {
                    _grid = new ReadOnlyPropertyGrid();
                    if (Properties.Settings.Default.ReadOnly)
                    {
                        _grid.ReadOnly = true; 
                    }
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

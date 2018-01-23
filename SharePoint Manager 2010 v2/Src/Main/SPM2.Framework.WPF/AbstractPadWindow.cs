using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AvalonDock;

namespace SPM2.Framework.WPF
{
    public class AbstractPadWindow : DockableContent, IPadWindow
    {
        public AbstractPadWindow()
        {
            
        }

        /// <summary>
        /// Returns true if the content of the window is visible.
        /// </summary>
        public bool IsWindowVisible
        {
            get
            {
                bool result = (this.IsActiveDocument || (this.State != DockableContentState.Document && this.State != DockableContentState.Hidden));
                return result;
            }
        }
    }
}

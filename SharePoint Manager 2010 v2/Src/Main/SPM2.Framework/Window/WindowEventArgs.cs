using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework
{
    public class WindowEventArgs : EventArgs
    {
        public IAddInWindow Window { get; set;}

        public WindowEventArgs()
        {
        }

        public WindowEventArgs(IAddInWindow window)
        {
            this.Window = window;
        }
    }
}

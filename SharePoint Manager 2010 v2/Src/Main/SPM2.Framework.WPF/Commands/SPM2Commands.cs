using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace SPM2.Framework.WPF.Commands
{
    public class SPM2Commands
    {
        private static RoutedUICommand _objectSelected;
        public static RoutedUICommand ObjectSelected
        {
            get { return _objectSelected; }
        }

        private static RoutedCommand _editString;
        public static RoutedCommand EditString
        {
            get { return SPM2Commands._editString; }
        }

        static SPM2Commands()
        {
            // Initialize the command.
            _objectSelected = new RoutedUICommand("ObjectSelected", "ObjectSelected", typeof(Window));
            _editString = new RoutedCommand("EditString", typeof(EditStringCommand));
        }

    }
}

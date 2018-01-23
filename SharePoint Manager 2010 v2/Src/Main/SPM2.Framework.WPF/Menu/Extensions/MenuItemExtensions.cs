using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace SPM2.Framework.WPF
{
    public static class  MenuItemExtensions
    {
        public static void BindToMessenger(this MenuItem item, RoutedCommand command)
        {
            item.Command = CommandToMessenger.Bind(item, command);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.Commands;
using SPM2.Framework.Menu;

namespace SPM2.Framework.IoC
{
    public class MenuItemViewModel  
    {
        public IEnumerable<ICommand> Commands { get; set; }

        public IEnumerable<IMenuItem> Items { get; set; }

        public MenuItemViewModel(IContainerAdapter container, Type parent)
        {
            Commands = container.ResolveBind<ICommand>(parent);
            Items = container.ResolveBind<IMenuItem>(parent);
        }
    }
}

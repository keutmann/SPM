using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC;
using SPM2.Framework.Commands;
using Keutmann.SharePointManager.Forms;
using Keutmann.SharePointManager.Components.Menu.File;

namespace Keutmann.SharePointManager.Commands
{
    [IoCBind(typeof(ExitMenuItem))]
    public class ExitCommand : ICommand
    {
        public MainWindow Form { get; set; }

        public ExitCommand(MainWindow form)
        {
            Form = form;
        }

        public void Execute()
        {
            Form.Close();
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}

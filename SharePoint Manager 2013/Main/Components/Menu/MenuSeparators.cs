using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPM2.Framework.IoC;
using SPM2.Framework.Menu;

namespace Keutmann.SharePointManager.Components.Menu.File
{
    [IoCBind(typeof(FileMenu), 2500)]
    public class MenuSeparators : ToolStripSeparator, IMenuItem
    {
    }
}

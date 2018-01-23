using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using SPM2.Framework;
using SPM2.Framework.WPF.Components;
using System.Windows.Input;
using SPM2.Framework.WPF;
using System.Windows.Media.Imaging;
using System.ComponentModel.Composition;

namespace SPM2.Main.Commands.ToolBars.Main
{
    [Export(typeof(MainToolBar))]
    public class Save : ImageButton
    {
        public Save()
        {
            this.Command = ApplicationCommands.Save;
            this.Icon.Source = ImageExtensions.LoadBitmapImage("/SPM2.Main;component/resources/images/save.png");
        }
    }
}

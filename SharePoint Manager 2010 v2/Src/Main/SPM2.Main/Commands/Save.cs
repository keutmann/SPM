using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using SPM2.Framework.WPF;
using System.Windows.Input;
using SPM2.Framework;
using System.ComponentModel.Composition;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace SPM2.Main.Commands
{
    [Export(typeof(FileMenu))]
    [ExportMetadata("Order", 20)]
    public class Save : MenuItem
    {
        public Save()
        {
            //this.Command = MessengerBinding.Bind(this, ApplicationCommands.Save);
            this.Command = ApplicationCommands.Save;
            this.Icon = ImageExtensions.LoadImage("/SPM2.Main;component/resources/images/save.png");
        }
    }
}

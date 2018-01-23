using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using SPM2.Framework;
using SPM2.Framework.WPF;
using SPM2.Main.GUI;

namespace TestAddIn
{
    //[AddInID("SPM2.Main.Commands.File")]
    //[AttachTo(MainMenu.AddInID, Index = 100)]
    public class File : MenuItem
    {

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            this.Header = "_FileTest";
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPM2.Framework.IoC;

namespace Keutmann.SharePointManager.Components
{
    [IoCLifetime(Singleton=true)]
    public class SettingsPropertyGrid : PropertyGrid
    {
        public SettingsPropertyGrid()
        {
            Dock = DockStyle.Fill;
            PropertyValueChanged +=new PropertyValueChangedEventHandler(SettingsPropertyGrid_PropertyValueChanged);
        }

        void  SettingsPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
 	        
        }
    }
}

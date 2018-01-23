using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using SPM2.Framework.WPF.Commands;
using SPM2.Framework.ComponentModel;
using System.Windows;

namespace SPM2.Main.ComponentModel
{
    public class StringEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            PropertyGridEditValue gridValue = new PropertyGridEditValue(context, provider, value);
            SPM2Commands.EditString.Execute(gridValue, Application.Current.MainWindow);
            return base.EditValue(context, provider, value);
        }

    }

}

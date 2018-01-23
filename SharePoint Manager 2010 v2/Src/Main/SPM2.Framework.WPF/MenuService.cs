using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;
using SPM2.Framework;
using SPM2.Framework.Collections;
using SPM2.Framework.Reflection;

namespace SPM2.Framework.WPF
{
    public class MenuService
    {

        public static IList<MenuItem> BuildMenu(string addInId)
        {
            //List<MenuItem> result = new List<MenuItem>();

            IList<MenuItem> result = AddInProvider.Current.CreateAttachments<MenuItem>(addInId, null);

            if (result != null)
            {
                foreach (MenuItem item in result)
                {
                    string id = item.GetType().GetAddInID();
                    item.Items.AddList(BuildMenu(id));
                }

                //IEnumerable<ClassDescriptor> list = descriptors.ClassDescriptors;
                //foreach (ClassDescriptor descriptor in list)
                //{
                //    MenuItem item = BuildItem(descriptor);
                //    if (item != null)
                //    {
                //        result.Add(item);
                //    }
                //}
            }

            return result;
        }

        //private static MenuItem BuildItem(ClassDescriptor descriptor)
        //{
        //    MenuItem item = Activator.CreateInstance(descriptor.ClassType) as MenuItem;
        //    if (item != null)
        //    {
        //        item.Items.AddList(BuildMenu(descriptor.AddInID));
        //    }
        //    return item;
        //}
    }
}

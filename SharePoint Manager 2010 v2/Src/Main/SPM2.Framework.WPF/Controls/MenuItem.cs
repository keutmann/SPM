using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.Collections;
using System.ComponentModel.Composition;

namespace SPM2.Framework.WPF.Controls
{
    public abstract class MenuItem : System.Windows.Controls.MenuItem
    {

        public MenuItem()
        {
            OrderingCollection<MenuItem> orderedItems = CompositionProvider.GetOrderedExports<MenuItem>(this.GetType());

            //string name = AttributedModelServices.GetContractName(this.GetType());

            //var result = CompositionProvider.Current.GetExports<MenuItem, IOrderMetadata>(name);

            //// Add the items to an ordered list
            //foreach (var item in result)
            //{
            //    orderedItems.Add(item);
            //}

            // now add the items to the menu child items collection in a ordered list
            foreach (var item in orderedItems)
            {
                this.Items.Add(item.Value);
            }

        }
    }
}

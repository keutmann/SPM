using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Collections;

namespace SPM2.Framework.WPF
{
    public static class UIElementCollectionExtensions
    {
        public static void AddRange(this UIElementCollection children, IEnumerable collection)
        {
            foreach (UIElement element in collection)
            {
                children.Add(element);
            }
        }
    }
}

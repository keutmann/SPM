using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace SPM2.Framework.WPF
{
    public static class DependencyObjectExtensions
    {
        public static T FindAncestor<T>(this DependencyObject d) where T : class
        {
            return AncestorsAndSelf(d).OfType<T>().FirstOrDefault();
        }

        public static IEnumerable<DependencyObject> AncestorsAndSelf(this DependencyObject d)
        {
            while (d != null)
            {
                yield return d;
                d = VisualTreeHelper.GetParent(d);
            }
        }

        //public static T FindAncestor<T>(this DependencyObject dependencyObject) where T : DependencyObject
        //{
        //    DependencyObject target = dependencyObject;
        //    do
        //    {
        //        target = VisualTreeHelper.GetParent(target);
        //    }
        //    while (target != null && !(target is T));
        //    return target as T;
        //}



        //public static T FindAncestor<T>(object dependencyObject) where T : DependencyObject
        //{
        //    var target = (DependencyObject)dependencyObject;
        //    do
        //    {
        //        var visualParent = target is Visual ? VisualTreeHelper.GetParent(target) : null;
        //        if (visualParent != null)
        //        {
        //            target = visualParent;
        //        }
        //        else
        //        {
        //            var logicalParent = LogicalTreeHelper.GetParent(target);
        //            if (logicalParent != null)
        //            {
        //                target = logicalParent;
        //            }
        //            else
        //            {
        //                return null;
        //            }
        //        }
        //    }
        //    while (!(target is T));
        //    return (T)target;
        //}
    }
}

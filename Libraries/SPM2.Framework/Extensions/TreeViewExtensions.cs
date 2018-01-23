using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace SPM2.Framework.Extensions
{
    public static class TreeViewExtensions
    {
        public static int AddImage(this TreeView treeView, string path)
        {
            int index = -1;
            if (treeView == null)
                throw new ArgumentNullException("treeView");

            if (String.IsNullOrEmpty(path))
                return index;

            if (!treeView.ImageList.Images.ContainsKey(path))
            {
                Image icon = null;
                if (File.Exists(path))
                {
                    icon = Image.FromFile(path);
                }
                else
                {
                    icon = GetImageFromResource(path);
                }

                if (icon != null)
                {
                    treeView.ImageList.Images.Add(path, icon);

                    index = treeView.ImageList.Images.Count - 1;
                }
            }
            else
            {
                index = treeView.ImageList.Images.IndexOfKey(path);
            }
            return index;
        }

        private static Image GetImageFromResource(string path)
        {
            if (String.IsNullOrEmpty(path)) return null;

            string[] parts = path.Split(';');
            if (parts.Length != 3) return null;

            AssemblyName name = new AssemblyName(parts[0]);

            var assembly = Assembly.Load(name);
            if (assembly == null) return null;

            var manager = new global::System.Resources.ResourceManager(parts[1], assembly);
            manager.IgnoreCase = true;

            var bitmap = (Bitmap)manager.GetObject(parts[2]);

            return bitmap;
        }
    }
}

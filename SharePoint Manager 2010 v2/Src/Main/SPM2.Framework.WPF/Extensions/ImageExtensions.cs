using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SPM2.Framework.WPF
{
    public class ImageExtensions
    {
        public static BitmapImage LoadBitmapImage(string uri)
        {
            BitmapImage bmImage = new BitmapImage();
            bmImage.BeginInit();
            bmImage.UriSource = new Uri(uri, UriKind.RelativeOrAbsolute);
            bmImage.EndInit();

            return bmImage;
        }

        public static Image LoadImage(string uri)
        {
            Image result = new Image();
            result.Source = LoadBitmapImage(uri);
            return result;
        }

        public static BitmapFrame LoadBitmapFrame(string uri)
        {
            Uri iconUri = new Uri(uri, UriKind.Relative);
            return BitmapFrame.Create(iconUri);
        }

        //public static Image LoadIcon(string name, string folder)
        //{
        //    var frame = BitmapFrame.Create(new Uri("pack://application:,,,/Images/" + name, UriKind.Absolute));
        //    Image result = new Image();
        //    result.Source = frame;
        //    return result;
        //}
    }
}

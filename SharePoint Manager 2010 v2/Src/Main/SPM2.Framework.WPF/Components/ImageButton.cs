using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace SPM2.Framework.WPF.Components
{
    public class ImageButton : Button
    {
        private Image _icon = null;
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }


        private TextBlock _textBlock = null;
        public TextBlock TextBlock
        {
            get { return _textBlock; }
            set { _textBlock = value; }
        }

        public ImageButton()
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            panel.Margin = new System.Windows.Thickness(0);

            _icon = new Image();
            //_icon.Margin = new System.Windows.Thickness(0, 0, 0, 0);
            panel.Children.Add(_icon);


            //_textBlock = new TextBlock();
            //panel.Children.Add(_textBlock);

            this.Content = panel;
        }

        // Properties
    }
}

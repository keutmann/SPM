using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ICSharpCode.TreeView;
using SPM2.Framework.Configuration;

namespace SPM2.Framework.WPF.ViewModel.TreeView
{
    [Serializable]
    public class SettingsModel : SharpTreeNode
    {
        private const string ResourceImagePath = "/SPM2.Framework;component/Resources/Images/";
        private ClassDescriptor _descriptor;
        private string _iconUri;
        private string _toolTipText;

        [Browsable(false)]
        public override object Text
        {
            get
            {
                if (String.IsNullOrEmpty(base.Text + string.Empty))
                {
                    base.Text = Descriptor.Title;
                }
                return base.Text;
            }
            set { base.Text = value; }
        }

        public string ToolTipText
        {
            get
            {
                if (String.IsNullOrEmpty(_toolTipText))
                {
                    _toolTipText = Descriptor.ClassType.Name;
                }
                return _toolTipText;
            }
            set { _toolTipText = value; }
        }

        [Browsable(false)]
        [XmlIgnore]
        public ClassDescriptor Descriptor
        {
            get { return _descriptor ?? (_descriptor = new ClassDescriptor(GetType())); }
            set { _descriptor = value; }
        }

        //private OrderingCollection<ISettings> _importedNodes = null;
        //[Browsable(false)]
        //[XmlIgnore]
        //public OrderingCollection<ISettings> ImportedNodes
        //{
        //    get
        //    {
        //        if (_importedNodes == null)
        //        {
        //            _importedNodes = CompositionProvider.GetOrderedExports<ISettings>(this.Descriptor.ClassType);
        //        }
        //        return _importedNodes;
        //    }
        //    set
        //    {
        //        _importedNodes = value;
        //    }
        //}


        [Browsable(false)]
        public new string IconUri
        {
            get
            {
                if (String.IsNullOrEmpty(_iconUri))
                {
                    _iconUri = GetResourceImagePath("mbllistbullet.gif");
                }
                return _iconUri;
            }
            set
            {
                if (_iconUri != value)
                {
                    _iconUri = value;
                    RaisePropertyChanged("IconUri");
                }
            }
        }

        [XmlIgnore]
        public ISettings SettingsObject { get; set; }


        public SettingsModel()
        {
        }

        public override void LoadChildren()
        {
            Children.Clear();

            foreach (ISettings item in SettingsObject.Children.AsSafeEnumable())
            {
                var modelItem = new SettingsModel {SettingsObject = item};
                //modelItem.Parent = this;
                var descriptor = new ClassDescriptor(item.GetType());
                modelItem.Text = descriptor.Title;
                modelItem.ToolTipText = descriptor.Description;

                Children.Add(modelItem);
            }
        }

        private static string GetResourceImagePath(string filename)
        {
            return ResourceImagePath + filename;
        }
    }
}
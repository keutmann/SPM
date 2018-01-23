using System.Xml.Serialization;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
    [Icon(Small = "RECUR.GIF")]
    [Title("More ... ")]
    public class MoreNode : SPNode
    {
        public override string ToolTipText
        {
            get
            {
                return "Fetch more items...";
            }
            set
            {
                base.ToolTipText = value;
            }
        }

        public MoreNode(ISPNodeCollection parentNode)
        {
            ParentNode = parentNode;
            
            SPObject = new object();
        }

        [XmlIgnore]
        public ISPNodeCollection ParentNode { get; set; }

        public override void LoadChildren()
        {
            // Load nothing
        }
    }
}
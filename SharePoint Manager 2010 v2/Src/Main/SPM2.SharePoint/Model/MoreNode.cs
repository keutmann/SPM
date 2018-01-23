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

        public ISPNodeCollection ParentNode { get; set; }

        public override void Setup(object spParent)
        {
            base.Setup(spParent);

            // Remove the expand arrow, by forcing a LoadChildren() call that will turn out empty.
            //this.IsExpanded = true;
        }

        public override void LoadChildren()
        {
            // Load nothing
        }
    }
}
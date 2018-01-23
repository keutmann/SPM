using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TreeView;

namespace SPM2.Main.ViewModel.TreeView
{
    public class DummyChild : ItemNode
    {
        public DummyChild()
        {
        }

        protected DummyChild(ISharpTreeNode parent, bool lazyLoadChildren)
        {
        }

        public override void LoadChildren()
        {
            
        }
    }
}

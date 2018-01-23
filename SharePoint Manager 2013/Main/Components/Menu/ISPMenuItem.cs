using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Keutmann.SharePointManager.ViewModel.TreeView;

namespace Keutmann.SharePointManager.Components.Menu
{
    public interface ISPMenuItem
    {
        SPTreeNode TreeNode { get; set; }
    }
}

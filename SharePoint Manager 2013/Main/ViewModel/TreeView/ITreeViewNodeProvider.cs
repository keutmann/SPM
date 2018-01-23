using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC;

namespace Keutmann.SharePointManager.ViewModel.TreeView
{
    public interface ITreeViewNodeProvider
    {
        IContainerAdapter IoCContainer { get; set; }

        IEnumerable<SPTreeNode> LoadChildren(SPTreeNode parentNode);
        SPTreeNode LoadFarmNode();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Keutmann.SharePointManager.Components;
using SPM2.Framework.IoC;

namespace Keutmann.SharePointManager.Collections
{
    [IoCOrder()]
    public class ChangedNodes : Dictionary<ExplorerNodeBase, bool>, IChangedNodes
    {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Keutmann.SharePointManager.Components;

namespace Keutmann.SharePointManager.Collections
{
    public interface IChangedNodes : IDictionary<ExplorerNodeBase, bool>
    {
    }
}

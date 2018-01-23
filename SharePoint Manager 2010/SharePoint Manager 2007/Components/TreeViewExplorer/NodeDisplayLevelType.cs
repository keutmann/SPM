using System;
using System.Collections.Generic;
using System.Text;

namespace Keutmann.SharePointManager.Components
{
    [Flags]
    public enum NodeDisplayLevelType : int
    {
        Simple = 1,
        Medium = 2,
        Advanced = 4
    }
}

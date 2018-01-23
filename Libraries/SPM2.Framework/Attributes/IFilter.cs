using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework
{
    public interface IFilter
    {
        bool Included { get; set; }
    }
}

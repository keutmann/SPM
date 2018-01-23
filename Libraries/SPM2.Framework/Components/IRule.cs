using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework.Components
{
    // The include rules is stacked up and is run through until the first rule accepts the node.
    public interface IRule<T>
    {
        // Deside if this rule will check this node.
        // The rule stack will stop here if accepted is true.
        // Otherwise this rule will be ignore and the next rule will be processed.
        bool Accept(T source);

        // Check this node is included by the result of true.
        bool Check(T source);
    }
}

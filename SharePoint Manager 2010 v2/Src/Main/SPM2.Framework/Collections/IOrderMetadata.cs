using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SPM2.Framework.Collections
{
    public interface IOrderMetadata
    {
        [DefaultValue("")]
        string ID { get; }

        [DefaultValue(null)]
        string Before { get; }

        [DefaultValue(null)]
        string After { get; }

        [DefaultValue(1000)]
        int Order { get; }
    }
}

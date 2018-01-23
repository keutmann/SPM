using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework.Threading
{
    public abstract class Task : ITask
    {
        public virtual void Do()
        {
        }
    }
}

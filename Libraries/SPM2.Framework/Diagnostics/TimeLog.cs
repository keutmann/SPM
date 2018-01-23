using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SPM2.Framework.Diagnostics
{
    public class TimeLog
    {
        public static void Messure(string name, Action action)
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            action.Invoke();
            watch.Stop();
            Trace.WriteLine(name + " used " + watch.ElapsedMilliseconds + " Milliseconds");
        }
    }
}

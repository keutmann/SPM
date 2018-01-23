using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.SharePoint.Administration;
using System.Reflection;

namespace SPM2.SharePoint.Kernel
{
    public class Owssvr
    {

        [DllImport("kernel32.dll")]
        private static extern IntPtr FreeLibrary(IntPtr library);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        public static void Recycle()
        {
            //PropertyInfo threadCtx = typeof(SPFarm).GetProperty("ThreadContext", BindingFlags.Static | BindingFlags.NonPublic);
            //var tbl = (Hashtable)threadCtx.GetValue(null, null);
            //PropertyInfo requestProp = typeof(SPFarm).GetProperty("RequestNoAuth", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            //requestProp.GetValue(SPFarm.Local, null);
            //tbl.Remove(typeof(SPFarm).Assembly.GetType("Microsoft.SharePoint.SPRequestManager"));

            //IntPtr p = GetModuleHandle("OWSSVR.DLL");
            //FreeLibrary(p);
            //string stsadmPath = SPUtility.GetGenericSetupPath("ISAPI");
            //p = LoadLibrary(stsadmPath + @"\OWSSVR.DLL");

            Type sprequestmanager = typeof(SPFarm).Assembly.GetType("Microsoft.SharePoint.SPRequestManager", true, true);
            Type spthreadcontext = sprequestmanager.Assembly.GetType("Microsoft.SharePoint.Utilities.SPThreadContext");
            MethodInfo setcontext = spthreadcontext.GetMethod("Set", BindingFlags.Static | BindingFlags.NonPublic);
            Type[] genericArguments = new Type[] { sprequestmanager };
            MethodInfo setcontextgeneric = setcontext.MakeGenericMethod(genericArguments);

            // set hte current sprequest manager to null!
            setcontextgeneric.Invoke(null, new object[] { null });


        }
    }

}

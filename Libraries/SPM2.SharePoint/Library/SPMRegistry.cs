using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Win32;

namespace SPM2.SharePoint
{
    // Will be replace by a local settings framework.
    //public static class SPMRegistry
    //{
    //    public const String SpfPath = @"SOFTWARE\Microsoft\Shared Tools\Web Server Extensions";

    //    public const string Group = @"Software\SharePoint Manager 2007\";
    //    public static void SetValue(string subgroup, string name, string val)
    //    {
    //        RegistryKey key = Registry.LocalMachine.CreateSubKey(Group + subgroup);
    //        key.SetValue(name, val);
    //    }

    //    public static object GetValue(string subgroup, string name)
    //    {
    //        try
    //        {
    //            RegistryKey key = Registry.LocalMachine.CreateSubKey(Group + subgroup);
    //            return key.GetValue(name);
    //        }
    //        catch (UnauthorizedAccessException exception)
    //        {
    //            throw new UnauthorizedAccessException(
    //                "In order to access the registry you must run SPM as Administrator.", exception);
    //        }
    //    }

    //    public static RegistryKey GetKey(string subgroup)
    //    {
    //        return Registry.LocalMachine.CreateSubKey(Group + subgroup);
    //    }
    //}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.SharePoint
{
    public class SPMEnvironment
    {
        #region Singleton logic

        #region Paths
        public static SPMPaths Paths
        {
            get
            {
                return NestedPaths.paths;
            }
        }

        class NestedPaths
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static NestedPaths()
            {
            }

            internal static readonly SPMPaths paths = new SPMPaths();
        }

        #endregion


        public static SPMVersion Version
        {
            get
            {
                return NestedVersion.version;
            }
        }

        class NestedVersion
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static NestedVersion()
            {
            }

            internal static readonly SPMVersion version = new SPMVersion();
        }

        #endregion
    }
}

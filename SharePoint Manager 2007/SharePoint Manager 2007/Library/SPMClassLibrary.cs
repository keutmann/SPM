using System;
using System.Collections;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Components;

namespace Keutmann.SharePointManager.Library
{

    public sealed class SPMClassLibrary
    {
        public const string NodeNamespace = "Keutmann.SharePointManager.Components.";
        

        private static readonly SPMClassLibrary instance = new SPMClassLibrary();

        public Hashtable Classes = new Hashtable();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static SPMClassLibrary()
        {
        }

        SPMClassLibrary()
        {
            Classes.Add(typeof(SPFieldCollection), typeof(FieldCollectionNode));
            
        }

        public static SPMClassLibrary Instance
        {
            get
            {
                return instance;
            }
        }
    }


}

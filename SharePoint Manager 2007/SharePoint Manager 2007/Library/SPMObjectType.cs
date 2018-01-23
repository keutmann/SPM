using System;
using System.Collections.Generic;
using System.Text;

namespace Keutmann.SharePointManager.Library
{
    //Test2
    public enum SPMObjectType : int
    {
        Unknown,
        SPWeb,
        SPWebCollection,
        SPListCollection,
        SPDocumentLibrary,
        SPList,
        SPListItem,
        SPFile,
        SPFolder,
        SPFolderCollection
    }
}

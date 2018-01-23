using System;
using System.Collections.Generic;
using System.Text;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components.FileListView
{
    public class LoadWorkerParameters
    {
        public string Url = string.Empty;
        public string Filter = string.Empty;
        public bool IncludeSubSites = false;
        public bool IncludeSubFolders = false;
        public Type spType = null;
    }
}

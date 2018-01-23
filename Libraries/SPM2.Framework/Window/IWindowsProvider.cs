using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.Configuration;

namespace SPM2.Framework
{
    [Provider(DefaultType = "SPM2.Framework.WindowProvider", ProviderType = ProviderTypes.Window)]
    public interface IWindowsProvider
    {
        event WindowCreatedEventHandler WindowCreated;

        IList<T> BuildWindows<T>(string id) where T : IAddInWindow;
        void OnWindowCreated(IAddInWindow window);
    }
}

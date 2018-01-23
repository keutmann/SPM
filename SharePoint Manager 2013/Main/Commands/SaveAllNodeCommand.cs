using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPM2.Framework.IoC;
using Keutmann.SharePointManager.Components.Menu;
using SPM2.Framework.Commands;
using Keutmann.SharePointManager.Components;
using Keutmann.SharePointManager.Collections;
using Keutmann.SharePointManager.Library;
using Keutmann.SharePointManager.Components.Menu.File;

namespace Keutmann.SharePointManager.Commands
{
    [IoCBind(typeof(SaveAllMenuItem))]
    public class SaveAllNodeCommand : ICommand
    {

        public IChangedNodes ChangedNodes { get; set; }
        public ISPMLocalization Localization { get; set; }
        public MainWindowStatusStrip StatusStrip { get; set; }

        public SaveAllNodeCommand(IChangedNodes changedNodes, ISPMLocalization local, MainWindowStatusStrip statusStrip)
        {
            ChangedNodes = changedNodes;
            Localization = local;
            StatusStrip = statusStrip;
        }

        public void Execute()
        {
            StatusStrip.Text = Localization.GetText("Saving_All_Changes");
            foreach (ExplorerNodeBase node in ChangedNodes.Keys)
            {
                node.Update();
                node.Setup();
            }
            ChangedNodes.Clear();

            StatusStrip.Text = Localization.GetText("Changes_Saved");
        }

        public bool CanExecute()
        {
            if (!Properties.Settings.Default.ReadOnly)
                return false;

            return ChangedNodes.Count() > 0;
        }
    }
}



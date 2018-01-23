using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class FeatureCollectionDefinitionNode : ExplorerNodeBase
    {

        public int InstalledIndex = -1;
        public int UnInstalledIndex = -1;

        public SPFeatureDefinitionCollection FeatureDefinitions;

        public FeatureCollectionDefinitionNode(object spParent, SPFeatureDefinitionCollection featureDefinitions)
        {
            this.Text = SPMLocalization.GetString("FeaturesDefinitions_Text");
            this.ToolTipText = SPMLocalization.GetString("FeaturesDefinitions_ToolTip");
            this.Name = "FeaturesDefinitions";
            this.Tag = featureDefinitions;
            this.SPParent = spParent;
            this.FeatureDefinitions = featureDefinitions;

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;

            string path = SPMPaths.ImageDirectory;
            InstalledIndex = Program.Window.Explorer.AddImage(path + "ewr217s.gif");
            UnInstalledIndex = Program.Window.Explorer.AddImage(path + "ewr238m.gif");

            this.Nodes.Add("Dummy");
        }

        public override void LoadNodes()
        {
            base.LoadNodes();
            CultureInfo cultureInfo = new CultureInfo(1033);

            foreach (SPFeatureDefinition definition in FeatureDefinitions)
            {
                try
                {
                    this.Nodes.Add(new FeatureDefinitionNode(this.Tag, definition, InstalledIndex, UnInstalledIndex));
                }
                catch 
                {
                    this.Nodes.Add(definition.Id.ToString() + " (Error)");
                }
            }

            string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string path = programFiles + @"\Common Files\Microsoft Shared\web server extensions\12\TEMPLATE\FEATURES\";

            foreach (string name in FeatureDefinitions.ScanForFeatures(Guid.Empty, true, false))
            {
                this.Nodes.Add(new FeatureDefinitionNode(this.Tag, path, name, InstalledIndex, UnInstalledIndex));
            }

        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "GenericFeature.gif";
        }
            
    }
}

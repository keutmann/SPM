using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Components
{
    class FeatureCollectionNode : ExplorerNodeBase
    {
        public int InstalledIndex = -1;
        public int UnInstalledIndex = -1;

        public SPFeatureCollection FeatureCollection
        {
            get
            {
                return this.Tag as SPFeatureCollection;
            }
        }


        private SPFeatureScope _featureScope = SPFeatureScope.ScopeInvalid;
        public SPFeatureScope FeatureScope
        {
            get
            {
                if (_featureScope == SPFeatureScope.ScopeInvalid)
                {

                    if (this.SPParent is SPFarm)
                    {
                        _featureScope = SPFeatureScope.Farm;
                    }
                    
                    if (this.SPParent is SPSite)
                    {
                        _featureScope = SPFeatureScope.Site;
                    }

                    if (this.SPParent is SPWeb)
                    {
                        _featureScope = SPFeatureScope.Web;
                    }

                    if(this.SPParent is SPWebApplication)
                    {
                        _featureScope = SPFeatureScope.WebApplication;
                    }
                }
                return _featureScope;
            }
        }




        public FeatureCollectionNode()
        {
            string path = SPMPaths.ImageDirectory;

            InstalledIndex = Program.Window.Explorer.AddImage(path + "ewr217s.gif");
            UnInstalledIndex = Program.Window.Explorer.AddImage(path + "ewr238m.gif");

            int index = Program.Window.Explorer.AddImage(this.ImageUrl());
            this.ImageIndex = index;
            this.SelectedImageIndex = index;
            
            this.Nodes.Add("Dummy");
        }

        public FeatureCollectionNode(SPWebApplication webApp) : this()
        {
            this.Text = SPMLocalization.GetString("SiteFeatures_Text");
            this.ToolTipText = SPMLocalization.GetString("SiteFeatures_ToolTip");
            this.Name = "SiteFeatures";
            this.Tag = webApp.Features;
            this.SPParent = webApp;
        }


        public FeatureCollectionNode(SPSite site) : this()
        {
            this.Text = SPMLocalization.GetString("SiteFeatures_Text");
            this.ToolTipText = SPMLocalization.GetString("SiteFeatures_ToolTip");
            this.Name = "SiteFeatures";
            this.Tag = site.Features;
            this.SPParent = site;
        }


        public FeatureCollectionNode(SPWeb web) : this()
        {
            this.Text = SPMLocalization.GetString("WebFeatures_Text");
            this.ToolTipText = SPMLocalization.GetString("WebFeatures_ToolTip");
            this.Name = "WebFeatures";
            this.Tag = web.Features;
            this.SPParent = web;

        }

        public override void LoadNodes()
        {
            base.LoadNodes();


            // Make a list of FeatureDefinitions that are available for the current scope.
            Dictionary<string, SPFeatureDefinition> featureList = new Dictionary<string,SPFeatureDefinition>();
            foreach (SPFeatureDefinition def in Program.Window.Explorer.CurrentFarm.FeatureDefinitions)
            {
                try
                {
                    // Only add features that match the scope 
                    if (def.Scope == FeatureScope)
                    {
                        featureList.Add(def.RootDirectory.ToLower(), def);
                    }
                }
                catch 
                {
                    // def.Scope throws an exception.
                    //featureList.Add(def.RootDirectory.ToLower(), def);
                }
            }

            foreach (SPFeature feature in FeatureCollection)
            {
                if (feature.Definition != null)
                {
                    // Remove known features
                    featureList.Remove(feature.Definition.RootDirectory.ToLower());

                    //ExplorerNodeBase node = CreateNode(feature.Definition, InstalledIndex);
                    this.Nodes.Add(new FeatureNode(this.SPParent, feature, InstalledIndex, true));
                }
                else
                {
                    // A feature was found but there was no definition available
                    this.Nodes.Add(new FeatureNode(this.SPParent, feature, InstalledIndex, true));
                }
            }

            // List the remaining feature definitions that may be installed on the current scope
            foreach (SPFeatureDefinition def in featureList.Values)
            {
                if (def != null)
                {
                    ExplorerNodeBase node = new FeatureNode(this.SPParent, def, UnInstalledIndex, false);
                    this.Nodes.Add(node);
                }
            }
        }

        public override string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "GenericFeature.gif";
        }
    }
}

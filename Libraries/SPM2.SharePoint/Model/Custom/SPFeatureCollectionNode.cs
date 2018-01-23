/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using System.ComponentModel;
using System.Collections.Generic;
using SPM2.Framework.Collections;
using System.Collections;

namespace SPM2.SharePoint.Model
{
    [Icon(Small = "GenericFeature.gif")]
    [View(50)]
    [ExportToNode("SPM2.SharePoint.Model.SPWebServiceNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebApplicationNode")]
    [ExportToNode("SPM2.SharePoint.Model.SPAdministrationWebApplicationNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSiteNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
    //[ExportToNode("SPM2.SharePoint.Model.SPContextNode")]
    public partial class SPFeatureCollectionNode
	{

        public override void LoadChildren()
        {

            // Load Definitions
            var definitions = GetFeatureDefinitionIndex().Distinct(new SPFeatureDefinitionComparer());

            // Load Active Features
            Dictionary<Guid, SPFeature> featureIndex = this.FeatureCollection.ToDictionary(p => p.DefinitionId);


            // Unordered List
            var unorderedList = new SerializableList<ISPNode>();

            foreach (var def in definitions)
            {
                SPFeatureNode node = new SPFeatureNode();
                node.Definition = def;
                node.Setup(this);

                if (featureIndex.ContainsKey(def.Id))
                {
                    node.SPObject = featureIndex[def.Id];
                    node.Activated = true;

                    featureIndex.Remove(def.Id);
                }

                unorderedList.Add(node);
            }

            foreach (var entry in featureIndex)
            {
                SPFeatureNode node = new SPFeatureNode();
                node.Definition = null;
                node.Setup(this);
                node.Text += " (Error: Missing definition)";

                unorderedList.Add(node);
            }


            // Add Inactive Features node from definitions
            this.Children = new SerializableList<ISPNode>(unorderedList.OrderBy( p=> p.Text));
        }

        private IEnumerable<SPFeatureDefinition> GetFeatureDefinitionIndex()
        {
            IEnumerable<SPFeatureDefinition> result = null;


            if (result == null && Parent.SPObject is SPWebService)
            {
                result = NodeProvider.Farm.FeatureDefinitions.Where(p => p.Scope == SPFeatureScope.Farm);
            }

            if (result == null && Parent.SPObject is SPWebApplication)
            {
                result = NodeProvider.Farm.FeatureDefinitions.Where(p => p.Scope == SPFeatureScope.WebApplication);
            }

            if (result == null && Parent.SPObject is SPAdministrationWebApplication)
            {
                result = NodeProvider.Farm.FeatureDefinitions.Where(p => p.Scope == SPFeatureScope.WebApplication);
            }

            if (result == null && Parent.SPObject is SPSite)
            {
                SPSite site = (SPSite)Parent.SPObject;
                List<SPFeatureDefinition> list = new List<SPFeatureDefinition>();
                list.AddRange(site.FeatureDefinitions.Where(p => p.Scope == SPFeatureScope.Site));
                list.AddRange(NodeProvider.Farm.FeatureDefinitions.Where(p => p.Scope == SPFeatureScope.Site));
                result = list;
            }

            if (result == null && Parent.SPObject is SPWeb)
            {
                SPSite site = ((SPWeb)Parent.SPObject).Site;
                List<SPFeatureDefinition> list = new List<SPFeatureDefinition>();
                list.AddRange(site.FeatureDefinitions.Where(p => p.Scope == SPFeatureScope.Web));
                list.AddRange(NodeProvider.Farm.FeatureDefinitions.Where(p => p.Scope == SPFeatureScope.Web));
                result = list;
            }

            return result;
        }


        class SPFeatureDefinitionComparer : IEqualityComparer<SPFeatureDefinition>
        {
            #region IEqualityComparer<SPFeatureDefinition> Members

            public bool Equals(SPFeatureDefinition x, SPFeatureDefinition y)
            {
                return x.Id.Equals(y.Id);
            }

            public int GetHashCode(SPFeatureDefinition obj)
            {
                return obj.Id.GetHashCode();
            }

            #endregion
        }

	}
}

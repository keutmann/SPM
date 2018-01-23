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

namespace SPM2.SharePoint.Model
{
	[Title("Features")]
    [Icon(Small = "GenericFeature.gif")]
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
            IEnumerable<SPFeatureDefinition> definitions = GetFeatureDefinitionIndex();

            // Load Active Features
            Dictionary<Guid, SPFeature> featureIndex = this.FeatureCollection.ToDictionary(p => p.DefinitionId);


            // Unordered List
            List<ISPNode> unorderedList = new List<ISPNode>();

            foreach (var def in definitions)
            {
                SPFeatureNode node = new SPFeatureNode();
                node.Definition = def;
                node.Setup(this.SPObject);

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
                node.Setup(this.SPObject);

                unorderedList.Add(node);
            }


            // Add Inactive Features node from definitions
            this.Children = unorderedList.OrderBy( p=> p.Text).ToList();
        }

        private IEnumerable<SPFeatureDefinition> GetFeatureDefinitionIndex()
        {
            IEnumerable<SPFeatureDefinition> result = null;


            if (result == null && this.SPParent is SPWebService)
            {
                result = SharePointContext.Instance.Farm.FeatureDefinitions.Where(p => p.Scope == SPFeatureScope.Farm);
            }

            if (result == null && this.SPParent is SPWebApplication)
            {
                result = SharePointContext.Instance.Farm.FeatureDefinitions.Where(p => p.Scope == SPFeatureScope.WebApplication);
            }

            if (result == null && this.SPParent is SPAdministrationWebApplication)
            {
                result = SharePointContext.Instance.Farm.FeatureDefinitions.Where(p => p.Scope == SPFeatureScope.WebApplication);
            }

            if (result == null && this.SPParent is SPSite)
            {
                SPSite site = (SPSite)this.SPParent;
                List<SPFeatureDefinition> list = new List<SPFeatureDefinition>();
                list.AddRange(site.FeatureDefinitions.Where(p => p.Scope == SPFeatureScope.Site));
                list.AddRange(SharePointContext.Instance.Farm.FeatureDefinitions.Where(p => p.Scope == SPFeatureScope.Site));
                result = list;
            }

            if (result == null && this.SPParent is SPWeb)
            {
                SPSite site = ((SPWeb)this.SPParent).Site;
                List<SPFeatureDefinition> list = new List<SPFeatureDefinition>();
                list.AddRange(site.FeatureDefinitions.Where(p => p.Scope == SPFeatureScope.Web));
                list.AddRange(SharePointContext.Instance.Farm.FeatureDefinitions.Where(p => p.Scope == SPFeatureScope.Web));
                result = list;
            }

            return result;
        }



	}
}

/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using System.Globalization;
using System.ComponentModel;

namespace SPM2.SharePoint.Model
{
	[Title("SPFeature")]
	[Icon(Small="BULLET.GIF")][View(100)]
	[ExportToNode("SPM2.SharePoint.Model.SPFeatureCollectionNode")]
	public partial class SPFeatureNode
	{

        private SPFeatureCollection _featureCollection = null;
        public SPFeatureCollection FeatureCollection
        {
            get
            {
                if (_featureCollection == null)
                {
                    _featureCollection = (SPFeatureCollection)Parent.SPObject;
                }
                return _featureCollection;
            }
            set
            {
                this._featureCollection = value;
            }
        }

        private SPFeatureDefinition _definition = null;
        public SPFeatureDefinition Definition
        {
            get
            {
                if (_definition == null)
                {
                    try
                    {
                        if (this.Feature != null)
                        {
                            _definition = this.Feature.Definition;
                        }
                    }
                    catch 
                    {
                        // Do nothing here!
                    }

                }
                return _definition;
            }
            set
            {
                _definition = value;
            }
        }

        private bool _activated = false;
        public bool Activated 
        {
            get
            {
                return this._activated;
            }
            set
            {
                if (this._activated != value)
                {
                    this._activated = value;
                    UpdateIconUri();
                    //this.RaisePropertyChanged("Activated");
                }
            }
        }


        public SPFeatureNode() : base()
        {
        }

        public override void Setup(ISPNode parent)
        {
            base.Setup(parent);
            
            try 
        	{	        
                if(this.Definition != null)
                {
                    this.Text = this.Definition.GetTitle(CultureInfo.CurrentUICulture);
                    this.ToolTipText = this.Definition.GetDescription(CultureInfo.CurrentUICulture);

                    UpdateIconUri();

                    if (this.Definition.Hidden)
                    {
                        this.Text += " (Hidden)";
                        this.State = "Gray";
                    }
                }
                else
                {
                    this.IconUri = SharePointContext.GetImagePath("ERRSM.GIF");
                    this.Text = string.Format("(Error: Missing definition {0})", this.Feature.DefinitionId);
                }
	        }
	        catch (Exception ex)
	        {

                this.IconUri = SharePointContext.GetImagePath("error16by16.gif");
                this.Text = "(Error: Feature missing)";
                this.ToolTipText = ex.Message;
	        }

        }

        public void ActivateFeature()
        {
            if (this.Definition != null)
            {
                this.SPObject = FeatureCollection.Add(Definition.Id, true);
                this.Activated = true;
            }
        }


        public void DeactivateFeature()
        {
            if (this.Definition != null)
            {
                FeatureCollection.Remove(this.Definition.Id, true);
                this.SPObject = null;
                this.Activated = false;
            }
        }

        public void UpdateIconUri()
        {
            if (this.Activated)
            {
                this.IconUri = SharePointContext.GetImagePath("newrowheader.png");
            }
            else
            {
                this.IconUri = SharePointContext.GetImagePath("mblwpitembullet.gif");
            }
        }

	}
}

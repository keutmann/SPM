using System;
using System.Runtime.Serialization;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Collections.Specialized;

using System.Windows.Forms;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using Keutmann.SharePointManager.Library;
using System.Drawing;
using System.Diagnostics;
using SPM2.SharePoint.Model;
using System.Collections.Generic;
using SPM2.SharePoint;

namespace Keutmann.SharePointManager.Components
{



    public class ExplorerNodeBase : TreeNode
    {
        #region Members

        public bool HasChildrenLoaded = false;

        private string _BrowserUrl = string.Empty;
        private bool _DefaultExpand = false;

        #endregion

        #region Properties

        public bool InReadOnlyMode
        {
            get { return Properties.Settings.Default.ReadOnly; }
        }
         
        public bool DefaultExpand
        {
            get { return _DefaultExpand; }
            set { _DefaultExpand = value; }
        }

        public virtual bool NewFeatureIn2010
        {
            get
            {
                return false;
            }
        }

        public virtual string BrowserUrl
        {
            get
            {
                return _BrowserUrl;
            }
            set
            {
                _BrowserUrl = value;
            }
        }

        protected Func<object> _spObject;
        public object SPObject
        {
            get
            {
                return _spObject();
            }
        }


        #endregion 

        #region Methods

        public ExplorerNodeBase() : base()
        {
        }

        public  ExplorerNodeBase(string text) : base(text)
        {
        }

        public virtual void Setup()
        {
            
        }

        protected ExplorerNodeBase(SerializationInfo serializationInfo, StreamingContext context)
            :
            base(serializationInfo, context)
        { }

        public ExplorerNodeBase(string text, TreeNode[] children)
            : base(text, children)
        { }

        public ExplorerNodeBase(string text, int imageIndex, int selectedImageIndex)
            :
            base(text, imageIndex, selectedImageIndex)
        { }

        public ExplorerNodeBase(string text, int imageIndex, int selectedImageIndex, TreeNode[] children)
            : base(text, imageIndex, selectedImageIndex, children)
        { }




        //public void AddNode(NodeDisplayLevelType requiredlevel, ExplorerNodeBase node)
        //{
        //    if (node.NewFeatureIn2010)
        //    {
        //        node.BackColor = Color.LightGray;
        //    }
        //    else
        //    {
        //        node.BackColor = Color.Empty;
        //    }

        //    TreeViewExplorer exp = this.TreeView as TreeViewExplorer;

        //    int level = (int)exp.DisplayLevel;
        //    int result = level & (int)requiredlevel;
        //    if (result >= 1)
        //    {
        //        this.Nodes.Add(node);
        //    }
        //}

        public virtual void LoadNodes()
        {
            if (Nodes.Count == 1 && Nodes[0].Text == "Dummy")
            {
                Nodes.Clear();
            }
            HasChildrenLoaded = true;
        }

        public ExplorerNodeBase GetNodeByTag(object objTag)
        {
            ExplorerNodeBase result = null;
            foreach (ExplorerNodeBase node in this.Nodes)
            {
                if (node.SPObject == objTag)
                {
                    result = node;
                    break;
                }
            }
            return result;
        }






        public virtual void Update()
        {
            SPMReflection.CallMethod(this.SPObject, "Update", new object[] { });
        }

        public virtual string ImageUrl()
        {
            return SPMEnvironment.Paths.ImageDirectory + "BLANK16.GIF";
        }


        #region Context Menu functions


        public virtual void CopyToClipboard()
        {
        }

        public virtual void CutToClipboard()
        {
        }

        public virtual void PasteFromClipboard()
        {
        }

        public virtual void Delete()
        {
            if(!InReadOnlyMode)
                SPMReflection.CallMethod(this.SPObject, "Delete", new object[] { });
        }

        public virtual void Refresh()
        {
        }
        #endregion

        #endregion

    }
}

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

namespace Keutmann.SharePointManager.Components
{



    public class ExplorerNodeBase : TreeNode
    {
        #region Members

        public bool HasChildrenLoaded = false;

        public object SPParent;

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



        protected ContextMenuStrip MenuStripBase = SPMMenu.Strips.Standard;
        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                if (base.ContextMenuStrip == null)
                {
                    base.ContextMenuStrip = MenuStripBase;
                }
                if (base.ContextMenuStrip is ContextMenuStripBase)
                {
                    ContextMenuStripBase menu = base.ContextMenuStrip as ContextMenuStripBase;
                    Program.Window.Explorer.SelectedNode = this;
                }
                
                return base.ContextMenuStrip;
            }
            set
            {
                base.ContextMenuStrip = value;
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


        public virtual TabPage[] GetTabPages()
        {
            ArrayList alPages = new ArrayList();

            alPages.Add(TabPages.GetPropertyPage(TabPages.PROPERTIES, this.Tag));

            if (this.BrowserUrl.Length > 0)
            {
                alPages.Add(TabPages.GetBrowserPage("Browser", this.BrowserUrl));
            }


            if (this.Tag != null)
            {
                Type type = Tag.GetType();
                PropertyInfo propInfo = type.GetProperty("SchemaXml", typeof(string));
                if (propInfo != null)
                {
                    alPages.Add(TabPages.GetXmlPage("Schema Xml", propInfo.GetValue(Tag, null) as string));
                }
            }
            
            return (TabPage[])alPages.ToArray(typeof(TabPage));

        }


        public void AddNode(NodeDisplayLevelType requiredlevel, ExplorerNodeBase node)
        {
            if (node.NewFeatureIn2010)
            {
                node.BackColor = Color.LightGray;
            }
            else
            {
                node.BackColor = Color.Empty;
            }

            TreeViewExplorer exp = this.TreeView as TreeViewExplorer;

            int level = (int)exp.DisplayLevel;
            int result = level & (int)requiredlevel;
            if (result >= 1)
            {
                this.Nodes.Add(node);
            }
        }

        public virtual void LoadNodes()
        {
            HasChildrenLoaded = true;
            this.Nodes.Clear();
           
        }

        public ExplorerNodeBase GetNodeByTag(object objTag)
        {
            ExplorerNodeBase result = null;
            foreach (ExplorerNodeBase node in this.Nodes)
            {
                if (node.Tag == objTag)
                {
                    result = node;
                    break;
                }
            }
            return result;
        }


        private ExplorerNodeBase GetWebApp(ExplorerNodeBase start)
        {
            ExplorerNodeBase child = start;
            while (child != null)
            {
                if (child.Tag is SPWebApplication)
                {
                    return child;
                }
                child = child.Parent as ExplorerNodeBase;
            }
            return null;
        }


        private ArrayList SaveStucture(ExplorerNodeBase currentNode)
        {
            ArrayList list = new ArrayList();

            list.Add(currentNode.Name.Clone());
            ExplorerNodeBase child = currentNode.Parent as ExplorerNodeBase;
            while (child != null)
            {
                list.Insert(0, child.Name.Clone());
                if (child.Tag is SPSiteCollection)
                {
                    break;
                }
                child = child.Parent as ExplorerNodeBase;
            }

            return list;
        }

        private void Reload(ExplorerNodeBase parent, ArrayList list)
        {
            if (list.Count > 0)
            {
                parent.HasChildrenLoaded = false;
                Program.Window.Explorer.ExpandNode(parent);

                string name = list[0] as string;
                list.RemoveAt(0);
                foreach (ExplorerNodeBase node in parent.Nodes)
                {
                    if (node.Name.Equals(name))
                    {
                        Program.Window.Explorer.SelectedNode = node;
                        //Program.Window.propertyGrid.SelectedObject = node.Tag;
                        Reload(node, list);
                        break;
                    }
                }
            }

        }

        protected void RefreshSPPersistedObject()
        {
            ExplorerNodeBase parent = this.Parent as ExplorerNodeBase;
            Program.Window.Explorer.SelectedNode = null;
            Program.Window.Explorer.DisposeObjectModelNodes(parent);
            parent.HasChildrenLoaded = false;
            Program.Window.Explorer.ExpandNode(parent);

            foreach (ExplorerNodeBase node in parent.Nodes)
            {
                if (node.Name.Equals(this.Name))
                {
                    Program.Window.Explorer.SelectedNode = node;
                    //Program.Window.propertyGrid.SelectedObject = node.Tag;

                    if (this.IsExpanded)
                    {
                        node.HasChildrenLoaded = false;
                        //Program.Window.Explorer.ExpandNode(node);
                        this.Expand();
//                        this.Toggle();
                    }
                    break;
                }
            }
        }

        
        protected void RefreshSPPersistedObjectCollection()
        {
            Program.Window.Explorer.DisposeObjectModelNodes(this);
            this.Nodes.Clear();

            this.HasChildrenLoaded = false;
            Program.Window.Explorer.ExpandNode(this);
        }
  
        protected void RefreshWss2Objects()
        {
            ArrayList list = SaveStucture(this);

            if (list.Count > 0)
            {
                ExplorerNodeBase appNode = GetWebApp(this);
                Program.Window.Explorer.SelectedNode = null;
                if (appNode != null && appNode.Tag is SPWebApplication)
                {
                    Program.Window.Explorer.DisposeObjectModelNodes(appNode);
                    ((SPPersistedObject)appNode.Tag).Uncache();

                    Reload(appNode, list);

                    if (this.IsExpanded)
                    {
                        this.HasChildrenLoaded = false;
                        //Program.Window.Explorer.ExpandNode(CurrentNode);
                        this.Expand();
                    }
                }
            }
            else
            {
                throw new ApplicationException(SPMLocalization.GetString("ExplorerBase_Error"));
            }
        }

        protected void RefreshSPBaseCollection()
        {
        }



        public virtual void Update()
        {
            SPMReflection.CallMethod(this.Tag, "Update", new object[] { });
        }

        public virtual string ImageUrl()
        {
            return SPMPaths.ImageDirectory + "BLANK16.GIF";
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
                SPMReflection.CallMethod(this.Tag, "Delete", new object[] { });
        }

        public virtual void Refresh()
        {
            if (this.Parent != null)
            {
                if (this.Tag is SPPersistedObject)
                {
                    RefreshSPPersistedObject();
                }
                else if (this.Tag is SPBaseCollection)
                {
                    RefreshSPPersistedObject();
                }
                else
                {
                    Type tagType = this.Tag.GetType();
                    Type baseType = tagType.BaseType;
                    string baseName = baseType.Name;
                    if (baseName.IndexOf("SPPersistedObjectCollection") >= 0 ||
                        baseName.IndexOf("SPPersistedChildCollection") >= 0)
                    {
                        RefreshSPPersistedObjectCollection();
                    }
                    else
                    {
                        RefreshWss2Objects();
                    }
                }
            }
            else
            {
                // Reload the TreeView, because there is no parent to the node.
                // It is properly the root that haven been selected.
                Program.Window.Explorer.DisposeObjectModel();
                Program.Window.Explorer.Build();
            }
        }
        #endregion

        #endregion

    }
}

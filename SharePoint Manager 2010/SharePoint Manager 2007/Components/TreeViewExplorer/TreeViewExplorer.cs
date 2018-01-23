using System;
using System.IO;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;


namespace Keutmann.SharePointManager.Components
{
    public class TreeViewExplorer : TreeView
    {
        public NodeDisplayLevelType DisplayLevel = NodeDisplayLevelType.Advanced | NodeDisplayLevelType.Medium | NodeDisplayLevelType.Simple;
        public int oldNodeIndex = -1; 
        public SPFarm CurrentFarm =  SPFarm.Local;

        public TreeViewExplorer()
        {
            this.ShowNodeToolTips = true;
            this.HideSelection = false;
        }

        public int AddImage(string path)
        {
            int index = -1;
            if (path.Length > 0)
            {
                if (!this.ImageList.Images.ContainsKey(path))
                {
                    if (File.Exists(path))
                    {
                        Image icon = Image.FromFile(path);

                        this.ImageList.Images.Add(path, icon);

                        index = this.ImageList.Images.Count - 1;
                    }
                }
                else
                {
                    index = this.ImageList.Images.IndexOfKey(path);
                }
            }
            return index;
        }

        private void DefaultExpand(ExplorerNodeBase parent)
        {
            if (parent.DefaultExpand)
            {
                parent.Expand();
                foreach (ExplorerNodeBase child in parent.Nodes)
                {
                    DefaultExpand(child);
                }
            }
        }

        public void Build()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.ImageList = Program.Window.SPMimageList;
            Nodes.Clear();
            BeginUpdate();
            TreeViewNodeSorter = new NodeSorter();

            ExplorerNodeBase root = null;
            root = new FarmNode(CurrentFarm);
            this.Nodes.Add(root);

            Sort();
            DefaultExpand(root);
            
            
            this.SelectedNode = root;

            EndUpdate();
            Cursor.Current = Cursors.Default;
        }

        

        public void ExpandNode(ExplorerNodeBase node)
        {
            if (!node.HasChildrenLoaded)
            {
                Cursor.Current = Cursors.WaitCursor;

                node.HasChildrenLoaded = true;
                node.LoadNodes();

                Cursor.Current = Cursors.Default;
            }
        }

        protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            ExplorerNodeBase node = e.Node as ExplorerNodeBase;

            ExpandNode(node);

            base.OnBeforeExpand(e);
        }


        public void DisposeObjectModelNodes(TreeNode parent)
        {
            foreach (TreeNode child in parent.Nodes)
            {
                DisposeObjectModelNodes(child);
                if (child.Tag != null)
                {
                    if (child.Tag is IDisposable)
                    {
                        ((IDisposable)child.Tag).Dispose();
                    }
                    else if (child.Tag is SPPersistedObject)
                    {
                        ((SPPersistedObject)child.Tag).Uncache();
                    }
                }
            }
        }

        public void DisposeObjectModel()
        {
            foreach (TreeNode node in this.Nodes)
            {
                DisposeObjectModelNodes(node as ExplorerNodeBase);
            }
            this.Nodes.Clear();
            
        }

        protected override void  Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeObjectModel();
            }
            base.Dispose(disposing);
        }

    }
}

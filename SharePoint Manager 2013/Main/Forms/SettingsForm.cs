using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPM2.Framework.IoC;
using Keutmann.SharePointManager.Components;
using System.Collections;
using Keutmann.SharePointManager.Collections;
using System.Reflection;

namespace Keutmann.SharePointManager.Forms
{
    public partial class SettingsForm : Form
    {
        private SettingsPropertyGrid _propertyGrid;
        private SettingsTreeView _treeView;

        public IContainerAdapter IoCContainer { get; set; }

        public Dictionary<TreeNode, bool> ChangedNodes;
        public Dictionary<TreeNode, Hashtable> ChangedPropertyItems;

        public TreeNode SelectedNode
        {
            get
            {
                return _treeView.SelectedNode;
            }
        }


        public SettingsForm(IContainerAdapter container, SettingsTreeView treeView, SettingsPropertyGrid propertyGrid)
        {
            ChangedNodes =  new Dictionary<TreeNode, bool>();
            ChangedPropertyItems = new Dictionary<TreeNode, Hashtable>();

            _treeView = treeView;
            _propertyGrid = propertyGrid;
            IoCContainer = container;
            InitializeComponent();
            
            Load += new EventHandler(SettingsForm_Load);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            _propertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(_propertyGrid_PropertyValueChanged);
            splitContainer.Panel2.Controls.Add(_propertyGrid);

            _treeView.LoadModel();
            _treeView.SelectedNodeChanged += new SPM2.Framework.Forms.TreeViewSelectedNodeChangedEventHandler(treeView_SelectedNodeChanged);
            splitContainer.Panel1.Controls.Add(_treeView);
        }


        private void treeView_SelectedNodeChanged(object sender, SPM2.Framework.Forms.TreeViewSelectedNodeChangedArgs e)
        {
            _propertyGrid.SelectedObject = e.AfterNode.Tag;
        }

        private void _propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (SelectedNode == null)
                return;

            Hashtable propertyItems = null;
            if (!ChangedPropertyItems.ContainsKey(SelectedNode))
            {
                propertyItems = new Hashtable();
                ChangedPropertyItems[SelectedNode] = propertyItems;
            }
            else
            {
                propertyItems = ChangedPropertyItems[SelectedNode];
            }
            propertyItems[e.ChangedItem] = e;
        }


        public void UndoChanges()
        {
            foreach (TreeNode node in ChangedNodes.Keys)
            {
                Hashtable propertyItem = ChangedPropertyItems[node];

                foreach (PropertyValueChangedEventArgs pvEventArgs in propertyItem.Values)
                {
                    PropertyDescriptor pd = pvEventArgs.ChangedItem.PropertyDescriptor;

                    Type nodeType = node.Tag.GetType();
                    FieldInfo myField = nodeType.GetField(pd.Name, BindingFlags.Instance | BindingFlags.Public);
                    if (myField != null)
                    {
                        myField.SetValue(node.Tag, pvEventArgs.OldValue);
                    }
                    else
                    {
                        PropertyInfo myProperty = nodeType.GetProperty(pd.Name, BindingFlags.Instance | BindingFlags.Public);
                        if (myProperty != null)
                        {
                            myProperty.SetValue(node.Tag, pvEventArgs.OldValue, null);
                        }
                    }
                }

                ChangedPropertyItems.Remove(node);
            }

            ChangedNodes.Clear();
        }
        
    }
}

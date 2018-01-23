using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;


namespace Keutmann.SharePointManager.Components
{
    // Create a node sorter that implements the IComparer interface.
    public class NodeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;

            return string.Compare(tx.Text, ty.Text);
        }
    }

}

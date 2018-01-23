using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Keutmann.SharePointManager.Components.FileListView
{
    public partial class SPMListView : ListView
    {
        #region Interop-Defines
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wPar, IntPtr lPar);

        // ListView messages
        private const int LVM_FIRST = 0x1000;
        private const int LVM_GETCOLUMNORDERARRAY = (LVM_FIRST + 59);

        // Windows Messages
        private const int WM_PAINT = 0x000F;
        #endregion
        
        private int sortColumn = -1;



        public SPMListView()
        {
            InitializeComponent();
        }

        public SPMListView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void SPMListView_Resize(object sender, EventArgs e)
        {
            SizeLastColumn((ListView)sender);
        }

        private void SPMListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                this.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (this.Sorting == SortOrder.Ascending)
                    this.Sorting = SortOrder.Descending;
                else
                    this.Sorting = SortOrder.Ascending;
            }
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.ListViewItemSorter = new ListViewItemComparer(e.Column,
                                                              this.Sorting);

            // Call the sort method to manually sort.
            this.Sort();
        }




        private void SizeLastColumn(ListView lv)
        {
            lv.Columns[lv.Columns.Count - 1].Width = -2;
        }

        /// <summary>
        /// Retrieve the order in which columns appear
        /// </summary>
        /// <returns>Current display order of column indices</returns>
        public int[] GetColumnOrder()
        {
            IntPtr lPar = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)) * Columns.Count);

            IntPtr res = SendMessage(Handle, LVM_GETCOLUMNORDERARRAY, new IntPtr(Columns.Count), lPar);
            if (res.ToInt32() == 0)	// Something went wrong
            {
                Marshal.FreeHGlobal(lPar);
                return null;
            }

            int[] order = new int[Columns.Count];
            Marshal.Copy(lPar, order, 0, Columns.Count);

            Marshal.FreeHGlobal(lPar);

            return order;
        }




    }
}

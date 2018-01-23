using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Keutmann.SharePointManager.Components
{
    public class ReadOnlyPropertyGrid : PropertyGrid
    {
        private bool _readOnly;
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                this.SetObjectAsReadOnly(this.SelectedObject, _readOnly);
            }
        }

        protected override void OnSelectedObjectsChanged(EventArgs e)
        {
            this.SetObjectAsReadOnly(this.SelectedObject, this._readOnly);
            base.OnSelectedObjectsChanged(e);
        }

        private void SetObjectAsReadOnly(object selectedObject, bool isReadOnly)
        {
            if (this.SelectedObject != null)
            {
                TypeDescriptor.AddAttributes(this.SelectedObject, new Attribute[] { new ReadOnlyAttribute(_readOnly) });
                this.Refresh();
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SPM2.Framework.WPF.Commands;
using System.Collections;
using System.Diagnostics;

namespace SPM2.Framework.WPF.Components
{
    /// <summary>
    /// Interaction logic for PropertyGrid.xaml
    /// </summary>
    public partial class PropertyGridControl : UserControl
    {
        public Dictionary<object, Hashtable> ChangedPropertyItems = new Dictionary<object, Hashtable>();



        // Using a DependencyProperty as the backing store for ValueChanged.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueChangedProperty =
            DependencyProperty.Register("ValueChanged", typeof(bool), typeof(PropertyGridControl), new UIPropertyMetadata(false));

        public bool ValueChanged
        {
            get { return (bool)GetValue(ValueChangedProperty); }
            set { SetValue(ValueChangedProperty, value); }
        }

        public PropertyGridControl()
        {
            InitializeComponent();
        }

        public void Update()
        {
            if (this.ValueChanged)
            {
                // Save the changes from the property grid on the object, is the object supports a "Update" method.
                foreach (KeyValuePair<object, Hashtable> entry in this.ChangedPropertyItems)
                {
                    entry.Key.InvokeMethod("Update");
                }

                ChangedPropertyItems = new Dictionary<object, Hashtable>();

                //this.propertyGrid.SelectedObject.InvokeMethod("Update");
                this.ValueChanged = false;
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(propertyGrid_PropertyValueChanged);

        }

        void propertyGrid_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
        {
            Hashtable propertyItems = null;
            if (!ChangedPropertyItems.ContainsKey(this.propertyGrid.SelectedObject))
            {
                propertyItems = new Hashtable();
                ChangedPropertyItems[this.propertyGrid.SelectedObject] = propertyItems;
            }
            else
            {
                propertyItems = ChangedPropertyItems[this.propertyGrid.SelectedObject];
            }
            propertyItems[e.ChangedItem] = e;

            ValueChanged = true;
            CommandManager.InvalidateRequerySuggested();
        }


        public void SetObject(object obj)
        {
            if (obj != null && this.propertyGrid.SelectedObject != obj)
            {
#if DEBUG
                Stopwatch watch = new Stopwatch();
                watch.Start();
#endif

                Mouse.OverrideCursor = Cursors.Wait;

                this.propertyGrid.SelectedObject = obj;

                Mouse.OverrideCursor = Cursors.Arrow;

#if DEBUG
                watch.Stop();
                Trace.WriteLine(String.Format("PropertyGrid load: Type:{0} - Time {1} milliseconds.", obj.GetType().Name, watch.ElapsedMilliseconds));
#endif

            }
        }
        
    }
}

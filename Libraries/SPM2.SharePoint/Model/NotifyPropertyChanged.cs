using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SPM2.SharePoint.Model
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            //thread safe
            PropertyChangedEventHandler handler;
            lock (this)
            {
                handler = PropertyChanged;
            }

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

            /*var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }*/
        }
    }
}

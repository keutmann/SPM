using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Reflection;
using System.Windows.Input;

namespace SPM2.Framework.WPF.Commands
{
    public class CommandHistoryItem
    {
        public string CommandName { get; set; }
        public UIElement Source { get; set; }
        public UIElement OriginalSource { get; set; }
        public string PropertyName { get; set; }
        public object PreviousState { get; set; }

        public CommandHistoryItem(ExecutedRoutedEventArgs e)
            : this(((RoutedCommand)e.Command).Name, e.Source, "", e.Parameter)
        {
        }

        public CommandHistoryItem(string commandName)
            : this(commandName, null, "", null)
        { 
        }

        public CommandHistoryItem(string commandName, object source, string propertyName, object previousState)
        {
            CommandName = commandName;
            Source = (UIElement)source;
            PropertyName = propertyName;
            PreviousState = previousState;
        }

        public bool CanUndo
        {
            get { return (Source != null && PropertyName != ""); }
        }

        public void Undo()
        {
            Type elementType = Source.GetType();
            PropertyInfo property = elementType.GetProperty(PropertyName);
            property.SetValue(Source, PreviousState, null);
        }
    }
}


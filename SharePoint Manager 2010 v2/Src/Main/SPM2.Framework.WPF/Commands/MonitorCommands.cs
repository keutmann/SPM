using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace SPM2.Framework.WPF.Commands
{
    public class MonitorCommands
    {
        public List<CommandHistoryItem> History = new List<CommandHistoryItem>();

        private static RoutedUICommand _applicationUndo;
        public static RoutedUICommand ApplicationUndo
        {
            get { return MonitorCommands._applicationUndo; }
        }

        public UIElement Element = null;

        static MonitorCommands()
        {
            _applicationUndo = new RoutedUICommand("ApplicationUndo", "Application Undo", typeof(MonitorCommands));
        }

        public MonitorCommands(UIElement element)
        {
            this.Element = element;
            
            this.Element.AddHandler(CommandManager.PreviewExecutedEvent, new ExecutedRoutedEventHandler(CommandExecuted));

            CommandBinding ApplicationUndo_Binding = new CommandBinding(ApplicationUndo);
            ApplicationUndo_Binding.Executed += new ExecutedRoutedEventHandler(ApplicationUndo_Binding_Executed);
            this.Element.CommandBindings.Add(ApplicationUndo_Binding);
        }

        void ApplicationUndo_Binding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CommandHistoryItem item = this.History.Last();
            item.Undo();
            this.History.Remove(item);
        }


        ~MonitorCommands()
        {
            Close();
        }

        public void Close()
        {
            if (this.Element != null)
            {
                this.Element.RemoveHandler(CommandManager.PreviewExecutedEvent, new ExecutedRoutedEventHandler(CommandExecuted));
            }
        }

        private void CommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // Ignore menu button source.
            if (e.Source is ICommandSource) return;
            // Ignore the ApplicationUndo command.
            if (e.Command == MonitorCommands.ApplicationUndo) return;

            this.History.Add(new CommandHistoryItem(e));
        }
    }
}


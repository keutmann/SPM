using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace SPM2.Framework.WPF
{
    public static class CommandBindingCollectionExtensions
    {
        public static void AddCommandPreviewCanExecuteHandler(this CommandBindingCollection collection, RoutedCommand command, CanExecuteRoutedEventHandler handler)
        {
            CommandBinding binding = GetOrCreateBinding(collection, command);
            // Remove the handler if it already exist
            binding.PreviewCanExecute -= handler;
            binding.PreviewCanExecute += handler;
        }

        public static void AddCommandCanExecuteHandler(this CommandBindingCollection collection, RoutedCommand command, CanExecuteRoutedEventHandler handler)
        {
            CommandBinding binding = GetOrCreateBinding(collection, command);
            // Remove the handler if it already exist
            binding.CanExecute -= handler;
            binding.CanExecute += handler;
        }

        public static void AddCommandPreviewExecuteHandler(this CommandBindingCollection collection, RoutedCommand command, ExecutedRoutedEventHandler handler)
        {
            CommandBinding binding = GetOrCreateBinding(collection, command);
            // Remove the handler if it already exist
            binding.PreviewExecuted -= handler;
            binding.PreviewExecuted += handler;
        }


        public static void AddCommandExecutedHandler(this CommandBindingCollection collection, RoutedCommand command, ExecutedRoutedEventHandler handler)
        {
            CommandBinding binding = GetOrCreateBinding(collection, command);
            // Remove the handler if it already exist
            binding.Executed -= handler;
            binding.Executed += handler;
        }

        public static void RemoveCommandPreviewCanExecuteHandler(this CommandBindingCollection collection, RoutedCommand command, CanExecuteRoutedEventHandler handler)
        {
            CommandBinding binding = GetBinding(collection, command);
            if (binding != null)
            {
                binding.PreviewCanExecute -= handler;
            }
        }

        public static void RemoveCommandCanExecuteHandler(this CommandBindingCollection collection, RoutedCommand command, CanExecuteRoutedEventHandler handler)
        {
            CommandBinding binding = GetBinding(collection, command);
            if (binding != null)
            {
                binding.CanExecute -= handler;
            }
            
        }

        public static void RemoveCommandPreviewExecuteHandler(this CommandBindingCollection collection, RoutedCommand command, ExecutedRoutedEventHandler handler)
        {
            CommandBinding binding = GetBinding(collection, command);
            if (binding != null)
            {
                binding.PreviewExecuted -= handler;
            }
            
        }

        public static void RemoveCommandExecutedHandler(this CommandBindingCollection collection, RoutedCommand command, ExecutedRoutedEventHandler handler)
        {
            CommandBinding binding = GetBinding(collection, command);
            if (binding != null)
            {
                binding.Executed -= handler;
            }
            
        }

        public static CommandBinding GetBinding(this CommandBindingCollection collection, RoutedCommand command)
        {
            return collection.OfType<CommandBinding>().FirstOrDefault(p => p.Command == command);
        }

        public static CommandBinding GetOrCreateBinding(this CommandBindingCollection collection, RoutedCommand command)
        {
            CommandBinding binding = GetBinding(collection, command);
            if (binding == null)
            {
                binding = new CommandBinding(command);
                collection.Add(binding);
            }
            return binding;
        }
    }
}

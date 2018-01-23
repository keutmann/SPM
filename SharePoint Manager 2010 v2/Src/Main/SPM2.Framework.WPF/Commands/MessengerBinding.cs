using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using System.Diagnostics;
using System.Windows.Controls;
using SPM2.Framework.WPF.Commands;


namespace SPM2.Framework.WPF
{
    public class ExecuteMessageEvent
    {
        public ExecutedRoutedEventArgs Parameter { get; private set; }

        public ExecuteMessageEvent(ExecutedRoutedEventArgs parameter)
        {
            Parameter = parameter;
        }

        public static void Register(object recipient, object target, Action<ExecuteMessageEvent> action)
        {
            Register(recipient, target, action, null);
        }

        public static void Register(object recipient, object target, Action<ExecuteMessageEvent> action, Action<CanExecuteMessageEvent> canExecute)
        {
            Messenger.Default.Register<ExecuteMessageEvent>(
                recipient,
                target,
                action);

            if (canExecute != null)
            {
                CanExecuteMessageEvent.Register(recipient, target, canExecute);
            }
        }

    }

    public class PreviewExecuteMessageEvent
    {
        public ExecutedRoutedEventArgs Parameter { get; private set; }

        public PreviewExecuteMessageEvent(ExecutedRoutedEventArgs parameter)
        {
            Parameter = parameter;
        }

        public static void Register(object recipient, object target, Action<PreviewExecuteMessageEvent> action)
        {
            Register(recipient, target, action, null);
        }

        public static void Register(object recipient, object target, Action<PreviewExecuteMessageEvent> action, Action<PreviewCanExecuteMessageEvent> canExecute = null)
        {
            Messenger.Default.Register<PreviewExecuteMessageEvent>(
                recipient,
                target,
                action);

            if (canExecute != null)
            {
                PreviewCanExecuteMessageEvent.Register(recipient, target, canExecute);
            }
        }    
    }
    
    public class CanExecuteMessageEvent
    {
        Action<bool> _callback = null;

        public CanExecuteRoutedEventArgs Parameter { get; private set; }

        public CanExecuteMessageEvent(CanExecuteRoutedEventArgs parameter, Action<bool> callback)
        {
            Parameter = parameter;
            _callback = callback;
        }

        public void CanExecute(bool parameter)
        {
            if (_callback != null)
            {
                _callback.Invoke(parameter);
            }
        }

        public static void Register(object recipient, object target, Action<CanExecuteMessageEvent> action)
        {
            Messenger.Default.Register<CanExecuteMessageEvent>(
                recipient,
                target,
                action);
        }
    }

    public class PreviewCanExecuteMessageEvent 
    {
        Action<bool> _callback = null;

        public CanExecuteRoutedEventArgs Parameter { get; private set; }

        public PreviewCanExecuteMessageEvent(CanExecuteRoutedEventArgs parameter, Action<bool> callback)
        {
            Parameter = parameter;
            _callback = callback;
        }

        public void CanExecute(bool parameter)
        {
            if (_callback != null)
            {
                _callback.Invoke(parameter);
            }
        }

        public static void Register(object recipient, object target, Action<PreviewCanExecuteMessageEvent> action)
        {
            Messenger.Default.Register<PreviewCanExecuteMessageEvent>(
                recipient,
                target,
                action);
        }
    }

    public static class CommandToMessenger
    {

        public static void Relay(UIElement element)
        {
            element.AddHandler(CommandManager.ExecutedEvent, new RoutedEventHandler(HandleExecute), true);
            element.AddHandler(CommandManager.CanExecuteEvent, new RoutedEventHandler(HandleCanExecute), true);

            element.AddHandler(CommandManager.PreviewExecutedEvent, new RoutedEventHandler(HandlePreviewExecute), true);
            element.AddHandler(CommandManager.PreviewCanExecuteEvent, new RoutedEventHandler(HandlePreviewCanExecute), true);
        }

        private static void HandleExecute(object sender, RoutedEventArgs e)
        {
            ExecutedRoutedEventArgs args = (ExecutedRoutedEventArgs)e;

            CommandToMessenger.Execute(args.Source, args);
        }

        private static void HandlePreviewExecute(object sender, RoutedEventArgs e)
        {
            ExecutedRoutedEventArgs args = (ExecutedRoutedEventArgs)e;

            CommandToMessenger.PreviewExecute(args.Source, args);
        }
        

        private static void HandleCanExecute(object sender, RoutedEventArgs e)
        {
            CanExecuteRoutedEventArgs args = (CanExecuteRoutedEventArgs)e;
            CommandToMessenger.CanExecute(args.Source, args);
        }

        private static void HandlePreviewCanExecute(object sender, RoutedEventArgs e)
        {
            CanExecuteRoutedEventArgs args = (CanExecuteRoutedEventArgs)e;
            CommandToMessenger.PreviewCanExecute(args.Source, args);
        }



        public static RoutedCommand Bind(UIElement target, RoutedCommand command)
        {
            target.CommandBindings.AddCommandExecutedHandler(command,  Execute );
            target.CommandBindings.AddCommandCanExecuteHandler(command, CanExecute);

            return command;
        }

        public static void Execute(object sender, ExecutedRoutedEventArgs parameter)
        {
            Messenger.Default.Send<ExecuteMessageEvent>(new ExecuteMessageEvent(parameter), parameter.Command);
            //parameter.Handled = true;
        }

        public static void PreviewExecute(object sender, ExecutedRoutedEventArgs parameter)
        {
            Messenger.Default.Send<PreviewExecuteMessageEvent>(new PreviewExecuteMessageEvent(parameter), parameter.Command);
            //parameter.Handled = true;
        }

        //[DebuggerStepThrough]
        public static void CanExecute(object sender, CanExecuteRoutedEventArgs parameter)
        {
            var message = new CanExecuteMessageEvent(
                parameter,
                callbackMessage =>
                {
                    // This is the callback code
                    if (callbackMessage)
                    {
                        parameter.CanExecute = true;
                    }
                });

            Messenger.Default.Send<CanExecuteMessageEvent>(message, parameter.Command);
        }

        public static void PreviewCanExecute(object sender, CanExecuteRoutedEventArgs parameter)
        {
            var message = new PreviewCanExecuteMessageEvent(
                parameter,
                callbackMessage =>
                {
                    // This is the callback code
                    if (callbackMessage)
                    {
                        parameter.CanExecute = true;
                    }
                });

            Messenger.Default.Send<PreviewCanExecuteMessageEvent>(message, parameter.Command);
        }
    }
}

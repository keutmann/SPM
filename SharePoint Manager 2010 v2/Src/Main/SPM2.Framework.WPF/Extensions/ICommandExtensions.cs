using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace SPM2.Framework.WPF
{
    public static class ICommandExtensions
    {

        public static ICommand Bind(this ICommand command, System.Windows.Controls.Control ctrl)
        {
            CommandBinding binding = new CommandBinding();
            binding.Command = command;

            binding.Executed += new ExecutedRoutedEventHandler((sender, e) =>
            {
                var message = new NotificationMessage<ExecutedRoutedEventArgs>(sender, e, "Execute");
                Messenger.Default.Send(message, command);
            });

            binding.CanExecute += new CanExecuteRoutedEventHandler((sender, e) =>
            {
                var message = new NotificationMessageAction<bool>(sender, "CanExecute", b =>
                {
                    e.CanExecute = (b) ? b : e.CanExecute;
                });
                Messenger.Default.Send(message, command);
            });

            ctrl.CommandBindings.Add(binding);

            return command;
        }

        public static void Register(this ICommand command, object recipient, Action<NotificationMessage<ExecutedRoutedEventArgs>> execute, Action<NotificationMessageAction<bool>> canExecute) 
        {
            if(execute != null)
            {
                Messenger.Default.Register<NotificationMessage<ExecutedRoutedEventArgs>>(recipient, command, execute);
            }

            if(canExecute != null)
            {
                Messenger.Default.Register<NotificationMessageAction<bool>>(recipient, command, canExecute);
            }
        }
    }
}

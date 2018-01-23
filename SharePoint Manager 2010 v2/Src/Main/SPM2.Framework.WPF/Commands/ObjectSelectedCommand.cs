using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace SPM2.Framework.WPF.Commands
{
    public class ObjectSelectedCommand : RoutedCommand
    {

        //List<ExecutedRoutedEventHandler> executed

        public ObjectSelectedCommand() : 
            base()
        {
        }

        public ObjectSelectedCommand(string name, Type ownerType) :
            base(name, ownerType)
        {
        }

        public ObjectSelectedCommand(string name, Type ownerType, InputGestureCollection inputGestures)
            : base(name, ownerType, inputGestures)
        {
        }


        public new void Execute(object parameter, IInputElement target)
        {
            base.Execute(parameter, target);
        }



    }
}

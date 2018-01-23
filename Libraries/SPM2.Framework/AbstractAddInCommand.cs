using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework
{
    public abstract class  AbstractAddInCommand : IAddInCommand
    {
        //public virtual IAddInCommandCollection Commands { get; set; }

        //public virtual void Initialize()
        //{
        //}

        //public CommandAvailablility Availablility()
        //{
        //    return CommandAvailablility.Enabled;
        //}
        
        //public virtual void Execute()
        //{
        //}


        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public virtual void Execute(object parameter)
        {
        }
    }
}

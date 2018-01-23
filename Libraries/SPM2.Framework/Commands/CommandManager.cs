using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework.Commands
{
    public class CommandManager
    {
        public Stack<ICommand> Commands { get; set; }

        public CommandManager()
        {
            Commands = new Stack<ICommand>();
        }

        public void Push(ICommand command)
        {
            this.Commands.Push(command);
        }

        public ICommand Pop()
        {
            return this.Commands.Pop();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework.Commands
{
    public interface ICommandUndo : ICommand
    {
        void Undo();
    }
}

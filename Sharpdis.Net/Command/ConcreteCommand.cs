using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net.Command
{

    class ConcreteCommand : ICommand
    {
        public object execute(string cmd)
        {
            return new object();
        }
    }
}

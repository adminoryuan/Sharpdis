using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net.Command
{
    internal interface ICommand
    {


        public Object execute(string cmd);
        
    }

    
   
}

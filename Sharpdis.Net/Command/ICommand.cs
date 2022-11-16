using Sharpdis.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net.Command
{
    internal interface ICommand
    {
        public RespResEntity? execute(RespRequestEntity respReq);


        private static ConcreteCommand concrcmd;
        public static ICommand GetCommand()
        {
            if (concrcmd == null)
            {
                concrcmd =  new ConcreteCommand();
            }
            return concrcmd;
        }
    }

    
   
}

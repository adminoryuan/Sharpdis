using Sharpdis.Common.Entity;
using Sharpdis.Core.impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Core
{
    internal interface ICommand
    {
        public RespResEntity? execute(RespRequestEntity respReq);


        private static ConcreteCommand concrcmd;
        public static ICommand GetCommand()
        {
            if (concrcmd == null)
            {
                concrcmd = new ConcreteCommand();
            }
            return concrcmd;
        }
    }



}

using Sharpdis.Common.Entity;
using Sharpdis.DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net.Command
{

    class ConcreteCommand : ICommand
    {

        public RespResEntity? execute(RespRequestEntity respReq)
        {
            return CmdTable.GetCmdFunc(respReq.headers)?.Invoke(respReq.body);
        }
    }
}

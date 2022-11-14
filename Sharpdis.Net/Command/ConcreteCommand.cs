using Sharpdis.DataStructure;
using Sharpdis.Net.Entity;
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

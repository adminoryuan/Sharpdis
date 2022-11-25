using Sharpdis.Common.Entity;
using Sharpdis.DataStructure;
using Sharpdis.Log;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sharpdis.Net.Command
{

    class ConcreteCommand : ICommand
    {
       //持久化
        private absLogger absLog = AofLogger.getAofInstance();

        public RespResEntity? execute(RespRequestEntity respReq)
        {   
            var res= CmdTable.GetCmdFunc(respReq.headers)?.Invoke(respReq.body); 

            //如何是写命令 且执行成功了 则需要写入aof
            if (res.IsSucess && LoggerUntils.IsWriteCmd(respReq.headers))
            {
                Console.WriteLine("aof 写入" + respReq.respBody.Length);
                absLog.WriteLog(respReq.respBody);
            }
            return res;
        }
    }
}

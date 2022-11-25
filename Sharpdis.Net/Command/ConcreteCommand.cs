using Sharpdis.Common.Entity;
using Sharpdis.DataStructure;
using Sharpdis.Log;
using Sharpdis.Log.impl;
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
        public ConcreteCommand()
        {
            //加载日志
            absLog.LoadLog(new Action<RespRequestEntity>(respReq =>
            {
                CmdTable.GetCmdFunc(respReq.headers)?.Invoke(respReq.body);
            }));
        }
        public RespResEntity? execute(RespRequestEntity respReq)
        {   
            var res= CmdTable.GetCmdFunc(respReq.headers)?.Invoke(respReq.body); 

            //如何是写命令 且执行成功了 则需要写入aof
            if (res.IsSucess && 
                                LoggerUntils.IsWriteCmd(respReq.headers))
            {
                absLog.WriteLog(respReq.respBody);
            }
            return res;
        }
    }
}

using Sharpdis.Common.Entity;
using Sharpdis.Core;
using Sharpdis.DataStructure;
using Sharpdis.Log;
using Sharpdis.Log.impl;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sharpdis.Core.impl
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
            Console.WriteLine($"{respReq.headers}");
            var res = CmdTable.GetCmdFunc(respReq.headers)?.Invoke(respReq.body);
            
            //命令成功写入后追加日志
            if(res!=null && res.IsSucess)
                absLog.AppendLogAsync(respReq);
         
            return res;
        }
    }
}

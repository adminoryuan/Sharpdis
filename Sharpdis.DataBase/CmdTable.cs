using Sharpdis.Common.Entity;
using Sharpdis.DataStructure.cmd;
using Sharpdis.DataStructure.structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Sharpdis.DataStructure
{

    public static class CmdTable
    {
        /// <summary>
        /// 保存命令与func 的对应关系
        /// </summary>
        private static readonly Dictionary<string, Func<string[], RespResEntity>> cmdKv;

        public static int selectcmdKv = 0;
        static CmdTable()
        {
            cmdKv = new Dictionary<string, Func<string[], RespResEntity>>(); 
            //初始化所有命令
            SysCmd.RegistCmd();
            HashCmd.registCmd();
            ListCmd.RegistCmd();
            SetCmd.RegistCmd();
            StringCmd.registCmd();
        }

        

        /// <summary>
        /// 注册命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="cmdfunc"></param>
        public static void RegistCmd(string cmd, Func<string[], RespResEntity> cmdfunc){
                cmdKv.Add(cmd, cmdfunc);
        }

        private static Func<string[], RespResEntity> errFunc= new Func<string[], RespResEntity>(cmd =>
        {    
            return new RespResEntity(true, "The command is not sh temporarily!");
        });
        
        /// <summary>
        /// 获得具体命令执行函数
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static Func<string[], RespResEntity> GetCmdFunc(string cmd)
        {
            cmd = cmd.ToLower();
            if (!cmdKv.ContainsKey(cmd))
            {
                return errFunc;
            }
            return cmdKv[cmd];
        }


       
    }
}

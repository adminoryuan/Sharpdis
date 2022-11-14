using Sharpdis.DataStructure.structure;
using Sharpdis.Net.Entity;
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
        /// cmdKv 数量
        /// </summary>
        private static readonly int MAXcmdKv = 10;
        private static readonly Dictionary<string, Func<string[], RespResEntity>> cmdKv = Init();

        public static int selectcmdKv = 0;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string,Func<string[], RespResEntity>> Init()
        {
           var cmdKvs= new Dictionary<string,Func<string[], RespResEntity>>();

          
           
            return cmdKvs;
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
            return new RespResEntity(false, "The command is not sh temporarily\r\n\r\n!");
        });
        
        /// <summary>
        /// 获得具体命令执行函数
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static Func<string[], RespResEntity> GetCmdFunc(string cmd)
        {
            if (!cmdKv.ContainsKey(cmd))
            {
                return errFunc;
            }
            return cmdKv[cmd];
        }


        /// <summary>
        /// 保存所有数据
        /// </summary>
        private static Dictionary<string, Object> kvData = new Dictionary<string, Object>();

        public static T getStrucutr<T>(string key) where T : Structure
        {
            var val= kvData[key];
           
            if (val == null)
            {
                if (typeof(T) is List) 
                              val = new ListStucture();
            }
            return (T)val;
        }
    }
}

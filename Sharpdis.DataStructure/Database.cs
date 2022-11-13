using Sharpdis.Net.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Sharpdis.DataStructure
{

    public static class Database
    {
        /// <summary>
        /// db 数量
        /// </summary>
        private static readonly int MAXDB = 10;
        private static readonly Dictionary<string, Func<string[], RespResEntity>>[] db = Init();

        public static int selectDb = 0;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string,Func<string[], RespResEntity>>[] Init()
        {
           var dbs= new Dictionary<string,Func<string[], RespResEntity>>[MAXDB];

            for(int i = 0; i < dbs.Length; i++)
            {
                dbs[i] = new Dictionary<string,Func<string[], RespResEntity>>();
            }

           
            return dbs;
        }


        /// <summary>
        /// 注册命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="cmdfunc"></param>
        public static void RegistCmd(string cmd, Func<string[], RespResEntity> cmdfunc){
            for (int i = 0; i < db.Length; i++)
            {
                db[i].Add(cmd, cmdfunc);
            }
        }

        private static Func<string[], RespResEntity> errFunc= new Func<string[], RespResEntity>(cmd =>
        {

                return new RespResEntity(false, "The command is not sh temporarily\r\n\r\n!");
        });
        public static Func<string[], RespResEntity> GetCmdFunc(string cmd)
        {
            if (!db[selectDb].ContainsKey(cmd))
            {
                return errFunc;
            }
            return db[selectDb][cmd];
        }
    }
}

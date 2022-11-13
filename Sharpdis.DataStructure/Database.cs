using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure
{

    public static class Database
    {
        /// <summary>
        /// db 数量
        /// </summary>
        private static readonly int MAXDB = 10;

        public static readonly Dictionary<string, Func<string[]>>[] db =Init();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, Func<string[]>>[] Init()
        {
           var dbs= new Dictionary<string, Func<string>>[MAXDB];

            for(int i = 0; i < dbs.Length; i++)
            {
                dbs[i] = new Dictionary<string, Func<string>>();
            }
            return dbs;
        }


        /// <summary>
        /// 注册命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="cmdfunc"></param>
        public static void RegistCmd(string cmd, Func<string[]> cmdfunc){
            for (int i = 0; i < db.Length; i++)
            {
                db[i].Add(cmd, cmdfunc);
            }
        }
    }
}

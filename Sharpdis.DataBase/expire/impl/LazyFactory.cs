using Sharpdis.DataStructure;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataBase.expire.impl
{
    public class LazyFactory : IExpireFactory
    {
        /// <summary>
        /// 采用惰性删除
        /// </summary>
        /// <param name="key"></param>
        public  void CheckExpire(string key)
        {
            CmdTable.db.CheckExpire(key);
        }
    }
}

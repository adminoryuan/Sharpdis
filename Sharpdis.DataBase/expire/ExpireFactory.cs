using Sharpdis.Common.Entity;
using Sharpdis.DataBase.expire.impl;
using Sharpdis.DataStructure;
using Sharpdis.DataStructure.structure;
using Sharpdis.Untils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataBase.expire
{
    public interface  IExpireFactory
    {
        public  void CheckExpire(string key);

        public static IExpireFactory getExpire(string type)
        {
            if (type.Equals("Lazy"))
                return new LazyFactory();
            else if (type.Equals("LazyAndActive"))
                return new LazyAndActiveFactory();

            return null;
        }

        public static RespResEntity AddExpire(string key,int timeout)
        {
            Structure stuct;
            if ((stuct = CmdTable.db.getStrucutr(key)) == null)
            {
                return RespResUntils.GetArgsError();
            }

            stuct.start = TimeUntils.getTimeSpan();
            stuct.expire = timeout;

            return new RespResEntity(true, timeout);

        }
    }
}
    
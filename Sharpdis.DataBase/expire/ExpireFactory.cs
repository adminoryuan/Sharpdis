using Sharpdis.DataBase.expire.impl;
using System;
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
    }
}

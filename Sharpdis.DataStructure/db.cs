using Sharpdis.DataStructure.structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure
{
    static class Database
    {
        private static readonly int MAXdb = 10;

        /// <summary>
        /// 保存所有数据
        /// </summary>
        private static Dictionary<string, Structure>[] dbs = new Dictionary<string, Structure>[MAXdb];

        private static int selectIndex = 0;

        static Database()
        {
            for (int i = 0; i < MAXdb; i++)
                    dbs[i] = new Dictionary<string, Structure>();
            
        }

        /// <summary>
        /// 如何不存在则创建
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T CrateStrucutr<T>(string key) where T : Structure
        {
            var val = dbs[selectIndex].GetValueOrDefault(key,null);

            if (val == null)
            {
                if (typeof(T) == typeof(ListStucture))
                    val = new ListStucture();
                else if (typeof(T) == typeof(HashStucture))
                    val = new HashStucture();
                else if (typeof(T) == typeof(StringStructure))
                    val = new StringStructure();

                 dbs[selectIndex][key] = val;
            }
            return (T)val;
        }
        
        public static Structure getStrucutr(string key)
        {
            return dbs[selectIndex].GetValueOrDefault(key, null);
        }
    }
}

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
        public static T getStrucutr<T>(string key) where T : Structure
        {
            var val = dbs[selectIndex][key];

            if (val == null)
            {
                if (typeof(T) is List)
                    val = new ListStucture();
            }
            return (T)val;
        }
    }
}

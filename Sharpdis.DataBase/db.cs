using Sharpdis.DataStructure.structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure
{
    static class Database
    {
        /// <summary>
        /// db数量
        /// </summary>
        private static readonly int MAXdb = 10;

        /// <summary>
        /// 保存所有数据
        /// </summary>
        private static Dictionary<string, Structure>[] dbs = new Dictionary<string, Structure>[MAXdb];

        private static int selectIndex = 0;

        static Database()
        {
            //初始化
            for (int i = 0; i < MAXdb; i++)
                    dbs[i] = new Dictionary<string, Structure>();
            
        }

        /// <summary>
        /// 如何不存在则创建
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">建名称</param>
        /// <returns></returns>
        public static T CrateStrucutr<T>(string key) where T : Structure
        {
            var val = dbs[selectIndex].GetValueOrDefault(key,null);

            if (val == null)
            {
                //判断数据结构类型
                if (typeof(T) == typeof(ListStucture))
                    val = new ListStucture();
                else if (typeof(T) == typeof(HashStucture))
                    val = new HashStucture();
                else if (typeof(T) == typeof(StringStructure))
                    val = new StringStructure();
                else if (typeof(T)==typeof(SetStructure))
                    val = new SetStructure();
                else if(typeof(T)==typeof(ZSetStructure))
                    val=new ZSetStructure();

                dbs[selectIndex][key] = val;
            }
            return (T)val;
        }
        /// <summary>
        /// 不存在则返回null
        /// </summary>
        /// <param name="key">建</param>
        /// <returns></returns>
        
        public static Structure getStrucutr(string key)
        {
            return dbs[selectIndex].GetValueOrDefault(key, null);
        }
    }
}

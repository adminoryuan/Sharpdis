using Sharpdis.Common;
using Sharpdis.Common.Entity;
using Sharpdis.DataStructure.structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure
{
   public  class  Database
    {

        private static Database instan = null;

        public static  Database newInstance()
        {
            if (instan == null)
                instan = new  Database();
            return instan;
        }

        /// <summary>
        /// db数量
        /// </summary>
        private  readonly int MAXdb = 10;

        /// <summary>
        /// 保存所有数据
        /// </summary>
        private  Dictionary<string, Structure>[] dbs ;

        private  int selectIndex = 0;


        public void Init()
        {
            selectIndex = Global.config.DataBase;
            dbs = new Dictionary<string, Structure>[MAXdb];
            for (int i = 0; i < MAXdb; i++) 
                dbs[i] = new Dictionary<string, Structure>();
        }
        private  Database()
        {

           
        }

        /// <summary>
        /// 如何不存在则创建
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">建名称</param>
        /// <returns></returns>
        public T? CrateStrucutr<T>(string key) where T : Structure
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
            
            return val==null?null:(T)val;
        }

        public int GetSelectIndex()
        {
            return selectIndex;
        }

        /// <summary>
        /// 不存在则返回null
        /// </summary>
        /// <param name="key">建</param>
        /// <returns></returns>

        public  Structure? getStrucutr(string key, int selectIndex)
        {
            return dbs[selectIndex]?.GetValueOrDefault(key, null);
        }
    }
}

using Sharpdis.Common;
using Sharpdis.Common.Entity;
using Sharpdis.DataBase.expire;
using Sharpdis.DataBase.expire.impl;
using Sharpdis.DataStructure.structure;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure
{
   public  class  Database
    {

        private static Database instan;
        private static IExpireFactory factory;

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
        private  Dictionary<string, Structure?>[] dbs ;

        private  int selectIndex = 0;


        public void Init()
        {
            selectIndex = Global.config.DataBase;
            dbs = new Dictionary<string, Structure?>[MAXdb];

            factory = IExpireFactory.getExpire(Global.config.ExpireType);
            for (int i = 0; i < MAXdb; i++) 
                dbs[i] = new Dictionary<string, Structure?>();
        }
        private Database() { }

        /// <summary>
        /// 如何不存在则创建
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">建名称</param>
        /// <returns></returns>
        public T? CrateStrucutr<T>(string key) where T : Structure
        {

            Expire(key);

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

        public bool ContainsKey(string key)
        {
            return dbs[selectIndex].ContainsKey(key);
        }
        private void Expire(string key)
        {
            //判断是否包括惰性加载
            if (factory is LazyFactory)
                factory.CheckExpire(key);
        }

        public int GetSelectIndex()
        {
            return selectIndex;
        }

        public void Del(string key)
        {
             dbs[selectIndex].Remove(key);
        }

        /// <summary>
        /// 不存在则返回null
        /// </summary>
        /// <param name="key">建</param>
        /// <returns></returns>

        public  Structure? getStrucutr(string key, int selectIndex)
        {
            Expire(key);

            return dbs[selectIndex]?.GetValueOrDefault(key, null);
        
        }

        /// <summary>
        /// 检测是否过期
        /// </summary>
        /// <param name="key"></param>
        public void CheckExpire(string key)
        {
            var l = dbs[selectIndex]?.GetValueOrDefault(key);

            if (l != null && l.expire!=-1)
            {
                var currTimeSpan = TimeUntils.getTimeSpan();
                if (l.expire + l.start < currTimeSpan)
                {
                    //过期了需要删除
                    CmdTable.db.Del(key);
                }
            }
        }

        /// <summary>
        /// 不存在则返回null
        /// </summary>
        /// <param name="key">建名</param>
        /// <returns></returns>
        public Structure? getStrucutr(string key)
        {
            Expire(key);
            factory.CheckExpire(key);
            return dbs[selectIndex]?.GetValueOrDefault(key, null);
        }
    }
}

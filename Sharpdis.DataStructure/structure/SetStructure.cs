using Sharpdis.Untils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharpdis.DataStructure.structure
{
    public class SetStructure: Structure
    {
        private  object _val = new object();
        private int ItemCount = 0;
        private bool isSet = true;
        //使用inset 的两种情况
        // 所有的元素都是整数值时
        // set 对象保存的元素数量不超过512个

        public SetStructure()
        {
            _val = new List<int>();
        }

        public void SAdd(string[] val)
        {
            foreach (var item in val)
            {   
                if (isSet) { 
                    int res = 0;
                    if (!int.TryParse(item, out res)|| ItemCount>512)
                    {

                        ToHashSet();
                        ((HashSet<string>)_val).Add(item);
                        isSet = false;
                        continue;
                    }
                    ((List<int>)_val).Add(res);
                }
                else
                {
                    ((HashSet<string>)_val).Add(item);
                }
                ItemCount++;
            }
        }
       

        /// <summary>
        /// 获取所有值
        /// </summary>
        /// <returns></returns>
        public Array SMEMBERS()
        {
            Array res=null;
            if (isSet) res = ((List<int>)_val).ToArray();
            else res = ((HashSet<string>)_val).ToArray<string>();
            return res;
        }

        /// <summary>
        /// 将Set转换为hashSet
        /// </summary>
        public void ToHashSet()
        {
            var hashTable = new HashSet<string>();

            var list= (List<int>)_val;
            foreach (var item in list)
            {
                hashTable.Add(item.ToString());
            }
            _val =hashTable;

        }

    }
}

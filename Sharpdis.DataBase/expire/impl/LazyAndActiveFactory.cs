using Sharpdis.DataStructure;
using Sharpdis.DataStructure.structure;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sharpdis.DataBase.expire.impl
{
    /// <summary>
    /// 惰性和主动删除
    /// </summary>
    public class LazyAndActiveFactory : LazyFactory
    {
        public LazyAndActiveFactory()
        {
            Task.Run(new Action(() =>
            {
                ForkDel();
            }));
        }

        /// <summary>
        /// 主动删除
        /// </summary>
        public void ForkDel()
        {
            //
        }
    }
}

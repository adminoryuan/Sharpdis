using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Common.Entity
{   
    /// <summary>
    /// 描述一个返回结果
    /// </summary>
    public class RespResEntity
    {
        /// <summary>
        /// 是否执行成功
        /// </summary>
        private bool _IsSucess;

        /// <summary>
        /// 输出结果
        /// </summary>
        private object _Res;

        public bool IsSucess { get { return _IsSucess; } set { _IsSucess = value; } }

        public object Res { get { return _Res; } set { _Res = value; } }

        public RespResEntity(bool isSucess, object res)
        {
            IsSucess = isSucess;
            Res = res;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net.Entity
{
    public class RespResEntity
    {
        private bool _IsSucess;

        private object _Res;

        public bool IsSucess { get { return _IsSucess; }set { _IsSucess = value; } }

        public object Res { get { return _Res; } set { _Res = value; } }

        public  RespResEntity(bool isSucess, object res)
        {
            IsSucess = isSucess;
            Res = res;
        }
    }
}

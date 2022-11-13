using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net.Entity
{
    internal class RespResEntity
    {
        private bool _IsSucess { get; set; }

        private string _Res { get; set; }

         public bool IsSucess { get { return _IsSucess; }set { _IsSucess = value; } }

        public string Res { get { return _Res; } set { _Res = value; } }

        public RespResEntity(bool isSucess, string res)
        {
            IsSucess = isSucess;
            Res = res;
        }
    }
}

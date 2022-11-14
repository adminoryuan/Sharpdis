using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure.structure
{
    public abstract class DataStructure
    {
        private int _ex;

        private string _key;

        public int Ex { get { return _ex; } set { _ex = value; } }


        public string Key { get { return _key; } set { _key = value; } }


        public abstract void RegistCmd();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure.structure
{
    public abstract class Structure
    {
        private int _ex;

        public int expire { get { return _ex; } set { _ex = value; } }
         

    }
}

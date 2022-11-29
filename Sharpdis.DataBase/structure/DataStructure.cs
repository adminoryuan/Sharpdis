using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure.structure
{
    public abstract class Structure
    {
        private int _ex;

        public int expire { get { return _ex; } set { _ex = value; } }
         

        public long start { get; set; }

        public Structure(int ex)
        {
            start = TimeUntils.getTimeSpan();
            expire = ex;
        }
        public Structure()
        {
            start = TimeUntils.getTimeSpan(); 
            expire = -1;
        }
       
    }
}

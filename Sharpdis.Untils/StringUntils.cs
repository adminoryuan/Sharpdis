using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Untils
{
    public class StringUntils
    {
        public  static bool Isint(string val,out int res)
        {
            return int.TryParse(val, out res);
        }
            
    }
}

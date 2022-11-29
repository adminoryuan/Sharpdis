using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure.structure
{
    public class StringStructure: Structure
    {
        private string _val;
        public  string set(string[] val)
        {
            
            
            _val = val[2];
            
            return "ok";
        }
        
        public  bool incr(out int res)
        {
            
            if (!int.TryParse(_val, out res))
                return false;

            _val= (++res).ToString();

            return true;
        }
        public string get()
        {
            return _val;
        }
    }
}

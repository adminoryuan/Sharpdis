using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharpdis.DataStructure.structure
{
    public class HashStucture: Structure
    {
        private Dictionary<string, string> _val = new Dictionary<string, string>();

        public string Hset(string key,string val)
        {
            _val[key] = val;
            return "ok";
        }
        public string hget(string key)
        {
            return _val.GetValueOrDefault<string,string>(key,null);
        }
        public string[] hgetall()
        {
            return _val?.Values.ToArray<string>();
        }

        public int hexists(string key)
        {
            return _val.ContainsKey(key) ? 1 : 0;
        }

        public string[] hkeys()
        {
            return _val.Keys.ToArray();
        }

        public string[] hval()
        {
            return _val.Values.ToArray();
        }
    }   
}

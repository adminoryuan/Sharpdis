using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure.structure
{
    public class ZSetStructure: Structure
    {
        private SkipList skip = new SkipList();

        public bool zadd(SkipNode node)
        {
            skip.Insert(node);
            return true;
        }
        public int Rank(string val)   
        {
            return skip.ZRank(val);
        }
        public Array ZRange(int min,int max)
        {    
            return skip.ZRange(min, max);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure.structure
{
    public class ZSetStructure:Structure
    {
        private SkipList<int, string> skip = new SkipList<int, string>();

        public bool zadd(string[] cmd)
        {
            int score;
            if(!int.TryParse(cmd[0],out score))
            {

                return false;
            }
            string val = cmd[1];
            skip.Add(score, val);
            return true;
        }

        public Array zangebyscore(string[] cmd,out bool res)
        {   
            int min, max;
            if (!int.TryParse(cmd[0],out min) ||!int.TryParse(cmd[1], out max))
            {
                res = false;
                return new string[] { };
            }
            SkipList<int, string>.SkipListNode<int, string> head;
            
            if(skip.Search(min, out head))
            {
              
            }
            res = false;
            return new string[] { };
        }
    }
}

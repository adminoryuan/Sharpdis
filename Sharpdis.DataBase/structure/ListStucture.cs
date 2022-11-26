using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure.structure
{
    public class ListStucture: Structure
    {
        private LinkedList<string> link = new LinkedList<string>();

        public int Len()
        {
            return link.Count;
        }
        public string LPop()
        {
            string val= link.First?.Value;
            
            if(val!=null)
                link.RemoveFirst();

            return val;
        }

        public string RPop()
        {
            string val = link.Last?.Value;

            if(val!=null)
                link.RemoveLast();

            return val;
        }

        public bool LPush(string[] value)
        {
            foreach (string val in value)
                link.AddLast(val);
            return true;
        }

        public bool RPush(string[] value)
        {
            foreach(string val in value)
                 link.AddFirst(val);
            return true;
        }
        public string lindex(int index)
        {
            if (index >= 0)
            {
                var last= link.First;
                while (last != null && index>0)
                {
                    index--;
                    last = last.Next;
                }
                return last?.Value;
            }
            var first = link.Last;
            while (first != null && index > 0)
            {
                index--;
                first = first.Previous;
            }
            return first?.Value;
        }

        public string[] lrange(int start,int stop)
        {
           int range = stop - start;
           var last= link.First;
           while (last != null && start>0)
           {
                last = last.Next;
                start--;
           }
            string[] args = new string[range];

            while (start< range && last!=null)
            {
                args[start] = last?.Value;
                start++;
                last = last.Next;
            }
            return args;
        }
    }
}

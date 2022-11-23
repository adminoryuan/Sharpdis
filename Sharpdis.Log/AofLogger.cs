using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Sharpdis.Log
{
    public class AofLogger : absLogger
    {
        private static AofLogger instance;

        private AofLogger(): base("appendonly.aof")
        {

        }

        public static absLogger getAofInstance()
        {
            if (instance == null)
                instance = new AofLogger();
            return instance;
        }
        
        public override void LoadLog()
        {
            throw new NotImplementedException();
        }

        public override  void WriteLog(byte[] cmd)
        {
             swrite.WriteLine(Encoding.UTF8.GetString(cmd));
             swrite.FlushAsync();
        }       
    }
}

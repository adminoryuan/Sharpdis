using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Common.Entity
{
    public class Config
    {
        public string Bind { get; set; }
        public int Port { get; set; }

        public int DataBase { get;set; }

        public int MaxClients { get; set; }
        public string AppendOnly { get; set; }
        public string dbfilename { get; set; }
        public string AppendFilename { get; set; }
    }
}

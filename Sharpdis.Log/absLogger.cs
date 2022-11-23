using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sharpdis.Log
{
    public abstract class absLogger
    {
        protected string _fileName;
        protected FileStream _file;
        protected StreamWriter swrite;

        public absLogger(string fileName)
        {
            _fileName = fileName;
            _file = File.Create(fileName);
            swrite = new StreamWriter(_file);
        }
        public abstract void WriteLog(byte[] cmd);

        public abstract void LoadLog();
        
    }
}

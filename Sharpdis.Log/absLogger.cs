using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sharpdis.Log
{
    public abstract class absLogger
    {
        protected string _fileName;
       
        public absLogger(string fileName)
        {
            _fileName = fileName;
        }

        protected async Task WriteAsync(byte[] body)
        {
                var _file = File.Open(_fileName, FileMode.OpenOrCreate | FileMode.Append); 
                using (var stream = new StreamWriter(_file))
                {
                    stream.WriteLine(Encoding.UTF8.GetString(body));
                    await stream.FlushAsync();
                }
            _file.Close();

        }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="cmd"></param>
        public abstract void WriteLog(byte[] cmd);

        /// <summary>
        /// 加载日志
        /// </summary>
        public abstract void LoadLog(Action<Common.Entity.RespRequestEntity> func);




    }
}



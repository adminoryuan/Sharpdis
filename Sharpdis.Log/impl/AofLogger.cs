using DotNetty.Buffers;
using Sharpdis.Log.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Sharpdis.Log.impl
{
    public class AofLogger : absLogger
    {
        private static AofLogger instance;

        private AofLogger() : base("appendonly.aof")
        {

        }

        public static absLogger getAofInstance()
        {
            if (instance == null)
                instance = new AofLogger();
            return instance;
        }

        /// <summary>
        /// 加载aof 日志
        /// </summary>
        /// <param name="func">解析出命令后回调</param>
        public override void LoadLog(Action<Common.Entity.RespRequestEntity> func)
        {   

            var body= File.ReadAllBytes(_fileName);

            var buf = Unpooled.Buffer();
            
            buf.WriteBytes(body);
            
            //解析日志
            RespParser.Parser(buf, func);

        }

        public override async void WriteLog(byte[] cmd)
        {
           await WriteAsync(cmd);
        }
    }
}

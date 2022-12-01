using DotNetty.Buffers;
using Sharpdis.Common.Entity;
using Sharpdis.Log.parser;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Sharpdis.Log.impl
{
    public class AofLogger : absLogger
    {
        private static AofLogger? instance=null;

        private AofLogger() : base("appendonly.aof")
        {

        }

        public static absLogger getAofInstance()
        {
            if (instance == null)
                instance = new AofLogger();
            return instance;
        }

        public override async void AppendLogAsync(RespRequestEntity req)
        {
             if(LoggerUntils.IsWriteCmd(req.headers))
                await WriteAsync(req.respBody);
        }

        /// <summary>
        /// 加载aof 日志
        /// </summary>
        /// <param name="func">解析出命令后回调</param>
        public override void LoadLog(Action<Common.Entity.RespRequestEntity> func)
        {
            try { 
            if (!File.Exists(_fileName))
                return;
                var body= File.ReadAllBytes(_fileName);

                var buf = Unpooled.Buffer();
            
                buf.WriteBytes(body);
            
                //解析日志
                RespParser.Parser(buf, func);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
 
    }
}

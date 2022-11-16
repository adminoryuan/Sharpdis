using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Microsoft.Extensions.Logging;
using Sharpdis.Net.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Sharpdis.Net.codec
{

    internal class RedisRespDecoder : ByteToMessageDecoder
    {
       
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            input.ResetReaderIndex();
            if (input.ReadByte() != '*')
            {
                return;
            }
            int argsLen = (int)((char)input.ReadByte() - '0');
            string[] args= new string[argsLen];
            int index = 0;
            while (index < argsLen)
            {
                if (input.ReadByte() == '\r'){
                    input.ReadByte();
                }
                
                if (input.ReadByte()!= '$')
                {
                    return; 
                }
                int argCount = (int)((char)input.ReadByte()-'0');
                int tempIndex = 0;
                string nodeStr = "";                    
                while (tempIndex < argCount)
                {
                    char t =(char) input.ReadByte();
                    if (t == '\r')  
                           input.ReadByte();
                    else { 
                        nodeStr += (char)t;
                        tempIndex++;
                    }
                }
                args[index++] = nodeStr; 
            }
            Console.WriteLine($"[cmd]= {args[0]}, values={ToString(args)}");
            input.Clear();
            output.Add(new RespRequestEntity(args[0],args));
        }
        public static string ToString( string[] s)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in s)
            {
                builder.Append(item);
                builder.Append(" ");
            }
            return builder.ToString();
        }
    }
}

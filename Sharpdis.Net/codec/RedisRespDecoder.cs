using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Microsoft.Extensions.Logging;
using Sharpdis.Net.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Sharpdis.Net.codec
{

    internal class RedisRespDecoder : ByteToMessageDecoder
    {
       
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            string res = Encoding.UTF8.GetString(input.Array);
            
            if (input.ReadByte() != '*')
            {
                Console.WriteLine("协议错误");

                input.Clear();
                context.CloseAsync();
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
                    Console.WriteLine("resp 协议异常");
                    context.CloseAsync();
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

                index++;
                
            }
            foreach (var item in args)
            {
                Console.WriteLine(item);
            }
            output.Add(args);

        }
    }
}

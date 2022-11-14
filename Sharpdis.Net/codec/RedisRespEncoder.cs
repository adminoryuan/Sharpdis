using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Sharpdis.Net.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net.codec
{

    public class RedisRespEncoder : MessageToByteEncoder<RespResEntity>
    {
        protected override void Encode(IChannelHandlerContext context, 
                                        RespResEntity message, 
                                        IByteBuffer output){
            string prefix = "";

            if (message.Res is null || message.Res is string)
            {
                prefix += message.IsSucess ? "+" : "-";
                prefix += message.Res == null ? "nil" : message.Res;
                prefix += " \r\n";

            }
            else if (message.Res is string[])
            {
                string[] res = (string[])message.Res;
                prefix += $"*{res.Length}\r\n";
                foreach (var item in res)
                {
                    prefix += $"${item.Length}\r\n";
                    prefix += item;
                    prefix += "\r\n";
                }
            }
            output.WriteBytes(Encoding.UTF8.GetBytes(prefix));

        }
    }
}

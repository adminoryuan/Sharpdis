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
            String prefix = "";
            prefix += message.IsSucess ? "+" : "-";

            
            prefix += message.Res;
            prefix += " \r\n";
            output.WriteBytes(Encoding.UTF8.GetBytes(prefix));

        }
    }
}

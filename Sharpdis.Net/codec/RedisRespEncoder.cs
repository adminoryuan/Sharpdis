using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Sharpdis.Net.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net.codec
{

    internal class RedisRespEncoder : MessageToByteEncoder<RespResEntity>
    {
        protected override void Encode(IChannelHandlerContext context, RespResEntity message, IByteBuffer output)
        {

            output.WriteBytes(Encoding.UTF8.GetBytes("+OKOK \r\n"));
            context.Channel.WriteAndFlushAsync(Encoding.UTF8.GetBytes("+OKOK \r\n"));
        }
    }
}

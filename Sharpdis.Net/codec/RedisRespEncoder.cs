using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Sharpdis.Net.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net.codec
{

    internal class RedisRespEncoder : MessageToByteEncoder<RespEntity>
    {
        protected override void Encode(IChannelHandlerContext context, RespEntity message, IByteBuffer output)
        {
            throw new NotImplementedException();
        }
    }
}

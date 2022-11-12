using DotNetty.Transport.Channels;
using Sharpdis.Net.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net.handle
{

    public class SharpdisHandle : SimpleChannelInboundHandler<RespRequestEntity>
    {
        protected override void ChannelRead0(IChannelHandlerContext ctx, RespRequestEntity msg)
        {
            ctx.WriteAndFlushAsync(new RespResEntity(true,"ok"));
        }
    }
}

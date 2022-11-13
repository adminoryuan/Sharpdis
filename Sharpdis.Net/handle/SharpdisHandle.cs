using DotNetty.Transport.Channels;
using Sharpdis.Net.Command;
using Sharpdis.Net.Entity;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net.handle
{

    public class SharpdisHandle : SimpleChannelInboundHandler<RespRequestEntity>
    {
        private ICommand cmd = ICommand.GetCommand();
        protected override void ChannelRead0(IChannelHandlerContext ctx, RespRequestEntity req)
        {
         
            //对命令进行校验
            if (!RespCheckUntils.ChechCmd(req.body))
            {
                ctx.Channel.WriteAndFlushAsync(new RespResEntity(true, "ERR NOT FOUD CMD"));
            }

            ctx.Channel.WriteAndFlushAsync(cmd.execute(req));
        }
    }
}

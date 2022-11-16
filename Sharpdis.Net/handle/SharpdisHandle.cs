using DotNetty.Transport.Channels;
using Sharpdis.Common.Entity;
using Sharpdis.Net.Command;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net.handle
{


    public class SharpdisHandle : SimpleChannelInboundHandler<RespRequestEntity>  
    {
       // public override bool IsSharable => true;

        private ICommand cmd = ICommand.GetCommand();
        protected override void ChannelRead0(IChannelHandlerContext ctx, RespRequestEntity req)
        {
         
            //对命令进行校验
            if (!RespResUntils.ChechCmd(req.body))
            {
                ctx.Channel.WriteAndFlushAsync(new RespResEntity(true, "ERR NOT FOUD CMD"));
            }

            ctx.Channel.WriteAndFlushAsync(cmd.execute(req));
        }
        public override void ChannelInactive(IChannelHandlerContext context)
        {
            base.ChannelInactive(context);

        }
        public override void ChannelUnregistered(IChannelHandlerContext context)
        {
            base.ChannelUnregistered(context);
        }
    }
}

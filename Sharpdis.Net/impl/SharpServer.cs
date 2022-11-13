using DotNetty.Handlers.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Sharpdis.DataStructure;
using Sharpdis.Net.codec;
using Sharpdis.Net.Entity;
using Sharpdis.Net.handle;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Sharpdis.Net.impl
{
    public class SharpServer : ISharpdisServer
    {
        
        public async void Start(int port = 6379)
        {
            var boosgroup= new MultithreadEventLoopGroup(3);
            var workgroup = new MultithreadEventLoopGroup(3);
            ServerBootstrap bootstrap = new ServerBootstrap();
            bootstrap.
                Group(boosgroup, workgroup)
                .Channel<TcpServerSocketChannel>()
                .Option(ChannelOption.SoBacklog, 100)
                .Handler(new LoggingHandler())
                .ChildHandler(new ActionChannelInitializer<ISocketChannel>(chanle =>
                {

                    var pipelin= chanle.Pipeline;

                    pipelin.AddLast(new RedisRespDecoder());
                    pipelin.AddLast(new RedisRespEncoder());
                    pipelin.AddLast(new SharpdisHandle());
                }));
            Console.WriteLine("Sharpdis Server start：[6379]");

            init();
          
            var chanle=await bootstrap.BindAsync(6379);
            
        }
        public void init()
        {
            Database.RegistCmd("COMMAND", new Func<string[], RespResEntity>(cmd =>
            {
                return new RespResEntity(true, "ok");
            }));
            Database.RegistCmd("info", new Func<string[], RespResEntity>(cmd =>
            {

                
                return new RespResEntity(true, " ");
            }));
            Database.RegistCmd("Auth", new Func<string[], RespResEntity>(cmd =>
            {

                var res = cmd[1].Equals("admin") && cmd[2].Equals("pwd");
                return new RespResEntity(res, res ? "！" : "！");
            }));
        }
    }
}

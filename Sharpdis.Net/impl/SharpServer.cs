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
    
    
    public class SharpServer :  ISharpdisServer
    {


        public async void Start(int port = 6379)
        {
            var boosgroup= new MultithreadEventLoopGroup(4);
            var workgroup = new MultithreadEventLoopGroup(1);
            ServerBootstrap bootstrap = new ServerBootstrap();
            var handle=new SharpdisHandle();
            bootstrap.
                Group(boosgroup, workgroup)
                 .Channel<TcpServerSocketChannel>()
                 .Option(ChannelOption.SoReuseport,true)
                .Option(ChannelOption.SoBacklog, 1000)
                .Handler(new LoggingHandler())
                .ChildHandler(new ActionChannelInitializer<ISocketChannel>(chanle =>
                {
                  
                    var pipelin= chanle.Pipeline;
                    pipelin.AddLast(new RedisRespDecoder());
                    pipelin.AddLast(new RedisRespEncoder());
                    pipelin.AddLast(handle);
                   // chanle.WriteAndFlushAsync(new RespResEntity(true, ""));
                }));
            Console.WriteLine("Sharpdis Server start：[6379]");

            init();
          
            var chanle=await bootstrap.BindAsync(6379);
            
        }
        public void init()
        {
            CmdTable.RegistCmd("COMMAND", new Func<string[], RespResEntity>(cmd =>
            {
                return new RespResEntity(true, "ok");
            }));
            CmdTable.RegistCmd("info", new Func<string[], RespResEntity>(cmd =>
            {

                
                return new RespResEntity(true, " ");
            }));
            CmdTable.RegistCmd("Auth", new Func<string[], RespResEntity>(cmd =>
            {

                var res = cmd[1].Equals("admin") && cmd[2].Equals("pwd");
                return new RespResEntity(res, res ? "！" : "！");
            }));
            Hash.registCmd();
            List.RegistCmd();
            SetCmd.RegistCmd();
            StringCmd.registCmd();
        }
    }
}

using DotNetty.Handlers.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Sharpdis.Common.Entity;
using Sharpdis.DataStructure;
using Sharpdis.DataStructure.cmd;
using Sharpdis.Net.codec;
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
            var boosgroup= new MultithreadEventLoopGroup(3); //boss 线程
            var workgroup = new MultithreadEventLoopGroup(1); //work 线程
            ServerBootstrap bootstrap = new ServerBootstrap();
            var handle=new SharpdisHandle();
            bootstrap.
                Group(boosgroup, workgroup)
                 .Channel<TcpServerSocketChannel>()
                 .Option(ChannelOption.SoReuseport,true)
                 .Option(ChannelOption.TcpNodelay,true) 
                .Option(ChannelOption.SoBacklog, 1024) //阻塞队列
                .Option(ChannelOption.SoKeepalive,true) 
                .Handler(new LoggingHandler(LogLevel.INFO)) 
                .ChildHandler(new ActionChannelInitializer<ISocketChannel>(chanle =>
                {
                   
                    var pipelin= chanle.Pipeline;
                    pipelin.AddLast(new RedisRespDecoder());
                    pipelin.AddLast(new RedisRespEncoder());
                    pipelin.AddLast(new SharpdisHandle());
                }));

            
            Console.WriteLine("[Sharpdis] Server start [6379]");

            var chanle =await bootstrap.BindAsync(6379);
            
        }
        
    }
}

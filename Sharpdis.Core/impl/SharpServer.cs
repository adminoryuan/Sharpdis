using DotNetty.Handlers.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Sharpdis.Common;
using Sharpdis.Common.Entity;
using Sharpdis.DataStructure;
using Sharpdis.DataStructure.cmd;
using Sharpdis.Net.codec;
using Sharpdis.Net.handle;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Emit;
using System.Text;

namespace Sharpdis.Net.impl
{


    public class SharpServer :  ISharpdisServer
    {
        public SharpServer()
        {
            Database.newInstance().Init();
        }


        public async void Start()
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

            Console.WriteLine($"[Sharpdis] Server start [{Global.config.Bind}:{Global.config.Port}]");
           
            var chanle =await bootstrap.BindAsync(IPAddress.Parse(Global.config.Bind),Global.config.Port);
            
        }
        
    }
}

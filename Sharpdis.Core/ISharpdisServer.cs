using DotNetty.Transport.Channels;
using Sharpdis.Common;
using Sharpdis.Common.Entity;
using Sharpdis.Net.impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net
{
    public interface ISharpdisServer 
    {
        public static ISharpdisServer GetSharpdis(Config config)
        {

            Global.config = config;
            
            return new SharpServer();
        }
        public void Start();

    }
}

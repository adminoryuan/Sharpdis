using Sharpdis.Net.impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net
{
    public interface ISharpdisServer
    {

        public static ISharpdisServer GetSharpdis()
        {
            return new SharpServer();
        }
        public void Start(int port = 6379);

    }
}

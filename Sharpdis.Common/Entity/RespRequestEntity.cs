using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Common.Entity
{
    public class RespRequestEntity
    {
        private string _headers;
        private string[] cmd;
        private byte[] _respBody;
        public RespRequestEntity(string headers, string[] body, byte[] respBody)
        {
            this.headers = headers;
            this.body = body;
            this._respBody = respBody;   
        }
        public byte[] respBody { get { return _respBody; } }

        public string headers { get { return _headers; } set { _headers = value; } }

        public string[] body { get { return cmd; } set { cmd = value; } }
    }

}



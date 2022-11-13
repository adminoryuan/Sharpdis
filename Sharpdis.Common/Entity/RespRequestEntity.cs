using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net.Entity
{
    public class RespRequestEntity
    {
        private string _headers;
        private string[] cmd;

        public RespRequestEntity(string headers, string[] body)
        {
            this.headers = headers;
            this.body = body;
        }

        public string headers { get { return _headers; } set { _headers = value; } }

        public string[] body { get { return cmd; } set { cmd = value; } } }

    }



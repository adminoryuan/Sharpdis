using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Net.Entity
{
    public class RespRequestEntity
    {
        private string _headers;
        private string[] _body;

        public string headers { get { return _headers; } set { _headers = value; } }

        public string[] body { get { return _body; } set { _body = value; } } }

    }



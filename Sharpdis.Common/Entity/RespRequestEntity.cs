using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Common.Entity
{   
    /// <summary>
    /// 描述一个请求
    /// </summary>
    public class RespRequestEntity
    {
        /// <summary>
        /// 命令行头部命令
        /// </summary>
        private string _headers;
        
        /// <summary>
        /// 命令行命令与命令行参数
        /// </summary>
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



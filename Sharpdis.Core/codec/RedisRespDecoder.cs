using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Microsoft.Extensions.Logging;
using Sharpdis.Common.Entity;
using Sharpdis.Log.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Transactions;

namespace Sharpdis.Net.codec
{

    internal class RedisRespDecoder : ByteToMessageDecoder
    {
       
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            input.MarkReaderIndex();
            Console.WriteLine(input.ReadString(input.ReadableBytes,Encoding.UTF8));
            input.ResetReaderIndex();
            RespParser.Parser(input, new Action<RespRequestEntity>(res =>
            {
                output.Add(res);
            }));
             
        }
        public static string ToString( string[] s)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in s)
            {
                builder.Append(item);
                builder.Append(" ");
            }
            return builder.ToString();
        }
    }
}

using DotNetty.Buffers;
using Sharpdis.Common.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sharpdis.Log.parser
{
    public static class RespParser
    {

        public static void Parser(IByteBuffer buffer,Action<RespRequestEntity> func)
        { 
            while (buffer.ReaderIndex < buffer.WriterIndex) { 

                    buffer.MarkReaderIndex();
                    var prifix = buffer.ReadByte();
                    RespRequestEntity resp=null;

                    switch (prifix)
                    {
                        case (byte)'*':
                            int len=int.Parse(Encoding.UTF8.GetString(buffer.ReadLine()));
                             resp=Parser0(len,buffer);
                            break;
                        default:
                            buffer.ResetReaderIndex();
                            var line= Encoding.UTF8.GetString(buffer.ReadLine());
                            resp = new RespRequestEntity(line, new string[] { line }, null);
                            break;
                    }
                
                    resp.respBody = buffer.Array.Take(buffer.ReaderIndex).ToArray();

                    func(resp);
            }

        }

        public static RespRequestEntity Parser0(int len,IByteBuffer buffer)
        {
            int index = 0;
            string[] args = new string[len];
            while (index< len)
            {
                if (buffer.ReadByte() != '$')
                {
                    throw new Exception("parser resp Error..");
                    
                }
                buffer.ReadLine();

                args[index++] =Encoding.UTF8.GetString(buffer.ReadLine());

            }
            return new RespRequestEntity(args[0],args,new byte[0]);
       }
        public static byte[] ReadLine(this IByteBuffer buffer)
        {
                List<byte> res = new List<byte>();

                byte temp;
                while (buffer.ReaderIndex<buffer.WriterIndex-1 && (temp=buffer.ReadByte()) != '\r')
                {
                    res.Add(temp);
                }
                
                buffer.ReadByte();

                return res.ToArray();
        }
        public static RespRequestEntity AsteriskParser(int len,StreamReader reder)
        {
            string[] args = new string[len];

            int index = 0;
            List<byte> l = new List<byte>();
            while (index++ < args.Length)
            {
                string rline = reder.ReadLine();
                
                if (rline[0] != '$')
                {
                    //协议错误
                    throw new Exception("resp error");
                }
                args[index] = reder.ReadLine();
            }

            return new RespRequestEntity(args[0], args, new byte[0]);

             
        }
        
    }
}

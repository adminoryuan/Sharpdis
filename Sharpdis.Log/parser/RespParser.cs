using DotNetty.Buffers;
using Sharpdis.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Log.parser
{
    public static class RespParser
    {

        public static void Parser(IByteBuffer input,Action<RespRequestEntity> func) 
        {
            while (input.ReaderIndex<input.WriterIndex) {
                 
                     
                    if (input.ReadByte() != '*')
                    {
                            continue;
                    }
                    int argsLen = (int)((char)input.ReadByte() - '0');
                    string[] args = new string[argsLen];
                    int index = 0;
                    while (index < argsLen)
                    {
                        if (input.ReadByte() == '\r')
                        {
                            input.ReadByte();
                        }

                        if (input.ReadByte() != '$')
                        {
                            Console.WriteLine("Aof File Error");
                            break;
                        }
                        int argCount = (int)((char)input.ReadByte() - '0');
                        int tempIndex = 0;
                        string nodeStr = "";
                        while (tempIndex < argCount)
                        {
                            char t = (char)input.ReadByte();
                            if (t == '\r')
                                input.ReadByte();
                            else
                            {
                                nodeStr += (char)t;
                                tempIndex++;
                            }
                        }
                        args[index++] = nodeStr;
                    }
                    
                    func(new RespRequestEntity(args[0], args,new byte[0]));
            }
        }
    }
}

using Sharpdis.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure.cmd
{
     static class SysCmd
    {
        public static void RegistCmd()
        {
            CmdTable.RegistCmd("commad", new Func<string[], RespResEntity>(cmd =>
            {
                return new RespResEntity(true, "OK");
            }));
            CmdTable.RegistCmd("info", new Func<string[], RespResEntity>(cmd =>
            {
                 
                return new RespResEntity(true, "my sharpdis");
            }));

            CmdTable.RegistCmd("ping", new Func<string[], RespResEntity>(cmd =>
            {
                return new RespResEntity(true, "PONG");

            }));
            CmdTable.RegistCmd("auth", new Func<string[], RespResEntity>(cmd =>
            {

                var res = cmd[1].Equals("admin") && cmd[2].Equals("pwd");
                return new RespResEntity(res, res ? "！" : "！");
            }));
        
        }
    }
}

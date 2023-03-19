using Sharpdis.Common.Entity;
using Sharpdis.Common.Expand;
using Sharpdis.DataBase.expire;
using Sharpdis.DataStructure.structure;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Sharpdis.DataStructure.cmd
{
     static class StringCmd
    {
        
        [ArgsVerify(3)]
        public static RespResEntity Set(string[] cmd)
        {
            string key = cmd[1];
            bool isExpire=false;
            int timeOut=-1;
            for (int i=0;i<cmd.Length-1; i++)
            {
                if (cmd[i].Equals("px"))
                {
                    isExpire = true;
                    if (!int.TryParse(cmd[i + 1], out timeOut)) return RespResUntils.GetArgsError();
                    timeOut /= 1000;
                }
                else if (cmd[i].Equals("ex"))
                {
                    isExpire = true;
                    if (!int.TryParse(cmd[i + 1], out timeOut)) return RespResUntils.GetArgsError();
                    
                }
            }

            if (cmd[cmd.Length-1].Equals("nx"))
            {
                if(CmdTable.db.ContainsKey(key))
                    return new RespResEntity(true, "curr key isExits");
            }

            var res= new RespResEntity(true, CmdTable.db.CrateStrucutr<StringStructure>(key).set(cmd)); 
            if (isExpire)
            {
                IExpireFactory.AddExpire(cmd[1], timeOut);
            }
            return res;
        }
        
        [ArgsVerify(2)]
        public static RespResEntity Incr(string[] cmd)
        {
            string key = cmd[1];
            var l =  CmdTable.db.getStrucutr(key, CmdTable.db.GetSelectIndex());
            if (l == null) return new RespResEntity(false, "nil");
            int number = 0;
            if(!((StringStructure)l).incr(out number))
                return new RespResEntity(false,  "convent val error");
            return new RespResEntity(true, number);

        }
        [ArgsVerify(2)]
        public static RespResEntity Get(string[] cmd)
        {
            if (cmd.Length < 2) return RespResUntils.GetArgsError();
            string key = cmd[1];
            var l =  CmdTable.db.getStrucutr(key, CmdTable.db.GetSelectIndex());
            if (l == null) return new RespResEntity(false, "nil");

            return new RespResEntity(true,  CmdTable.db.CrateStrucutr<StringStructure>(key).get());

        }

        public static void registCmd()
        {
            CmdTable.RegistCmd("get", Get);

            CmdTable.RegistCmd("set", Set);

            CmdTable.RegistCmd("incr", Incr);
        }
    }
}

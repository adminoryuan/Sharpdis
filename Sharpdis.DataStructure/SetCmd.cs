using Sharpdis.Common.Entity;
using Sharpdis.DataStructure.structure;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharpdis.DataStructure
{
    public static class SetCmd
    {
        public static RespResEntity SAdd(string[] cmd)
        {
            if (cmd.Length < 3) return RespResUntils.getArgsError();
            
            string key = cmd[1];

            Database.CrateStrucutr<SetStructure>(key).SAdd(cmd.Skip(2).Take(cmd.Length - 1).ToArray());

            return new RespResEntity(true, "ok");
        }
        public static RespResEntity SMEMBERS(string[] cmd)
        {
            if (cmd.Length <2) return RespResUntils.getArgsError();
            string key = cmd[1];

             var l=Database.getStrucutr(key);

            if (l == null) return RespResUntils.getNilRes();

            return new RespResEntity(true, ((SetStructure)l).SMEMBERS());

        }
         public static void RegistCmd()
        {
            CmdTable.RegistCmd("sadd", SAdd);
            CmdTable.RegistCmd("smembers", SMEMBERS);
        }
    }
}

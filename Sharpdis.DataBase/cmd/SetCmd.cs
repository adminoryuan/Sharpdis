using Sharpdis.Common.Entity;
using Sharpdis.Common.Expand;
using Sharpdis.DataStructure.structure;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharpdis.DataStructure.cmd
{
     static class SetCmd
    {
        [ArgsVerify(3)]
        public static RespResEntity SAdd(string[] cmd)
        {
            if (cmd.Length < 3) return RespResUntils.GetArgsError();

            string key = cmd[1];

             CmdTable.db.CrateStrucutr<SetStructure>(key).SAdd(cmd.Skip(2).Take(cmd.Length - 1).ToArray());

            return new RespResEntity(true, "ok");
        }
        [ArgsVerify(2)]
        public static RespResEntity SMEMBERS(string[] cmd)
        {
            if (cmd.Length < 2) return RespResUntils.GetArgsError();
            string key = cmd[1];

            var l =  CmdTable.db.getStrucutr(key, CmdTable.db.GetSelectIndex());

            if (l == null) return RespResUntils.GetArgsError();

            return new RespResEntity(true, ((SetStructure)l).SMEMBERS());

        }
        public static void RegistCmd()
        {
            CmdTable.RegistCmd("sadd", SAdd);
            CmdTable.RegistCmd("smembers", SMEMBERS);
        }
    }
}

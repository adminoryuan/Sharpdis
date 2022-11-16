using Sharpdis.DataStructure.structure;
using Sharpdis.Net.Entity;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure
{
    public static class StringCmd
    {
        public static RespResEntity Set(string[] cmd)
        {
            if (cmd.Length < 3) return RespResUntils.getArgsError();
            string key = cmd[1];
            string val = cmd[2];
            return new RespResEntity(true, Database.CrateStrucutr<StringStructure>(key).set(val));
        }
        public static RespResEntity Incr(string[] cmd)
        {
            if (cmd.Length < 2) return RespResUntils.getArgsError();
            string key = cmd[1];
            var l= Database.getStrucutr(key);
            if (l == null) return new RespResEntity(false, "nil");
            bool res = ((StringStructure)l).incr();

            return new RespResEntity(res, res?"ok":"convent val error");

        }
        public static RespResEntity Get(string[] cmd)
        {
            if (cmd.Length < 2) return RespResUntils.getArgsError();
            string key = cmd[1];
            var l = Database.getStrucutr(key);
            if (l == null) return new RespResEntity(false, "nil");

            return new RespResEntity(true, Database.CrateStrucutr<StringStructure>(key).get());

        }

        public static void registCmd()
        {
            CmdTable.RegistCmd("get", Get);

            CmdTable.RegistCmd("set", Set);

            CmdTable.RegistCmd("incr",Incr);
        }
    }
}

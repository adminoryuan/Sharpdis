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
            if (cmd.Length < 3) return RespCheckUntils.getArgsError();
            string key = cmd[1];
            string val = cmd[2];
            return new RespResEntity(true, Database.CrateStrucutr<StringStructure>(key).set(val));
        }
        public static RespResEntity Incr(string[] cmd)
        {
            if (cmd.Length < 2) return RespCheckUntils.getArgsError();
            string key = cmd[1];
            var l= Database.getStrucutr(key);
            if (l == null) return new RespResEntity(false, null);

            return new RespResEntity(true, ((StringStructure)l).incr());

        }

        public static void registCmd()
        {

        }
    }
}

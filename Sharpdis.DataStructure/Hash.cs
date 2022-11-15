using Sharpdis.DataStructure.structure;
using Sharpdis.Net.Entity;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure
{
    public class Hash
    {
        public static RespResEntity hget(string[] cmd)
        {
            if (cmd.Length < 3)
            {
                return RespCheckUntils.getArgsError();
            }

            string key = cmd[1];
            string hkey = cmd[2];
            var l = Database.getStrucutr(key);

            if (l == null) return new RespResEntity(false, "nil");

            return new RespResEntity(true, ((HashStucture)l).hget(hkey));
        }

        public static RespResEntity hset(string[] cmd)
        {
            if (cmd.Length < 3)
            {
                return RespCheckUntils.getArgsError();
            }
            string key = cmd[1];
            string hkey = cmd[2];
            string hval = cmd[3];
            return new RespResEntity(true, ((HashStucture)Database.CrateStrucutr<HashStucture>(key)).Hset(hkey, hval));
        }
        public static RespResEntity hgetall(string[] cmd)
        {
            if (cmd.Length < 2)
            {
                return RespCheckUntils.getArgsError();
            }
            string key = cmd[1];
            var l = Database.getStrucutr(key);

            if (l == null) return new RespResEntity(false, "nil");

            return new RespResEntity(true, ((HashStucture)l).hgetall());
        }
        public static RespResEntity hexists(string[] cmd)
        {
            if (cmd.Length < 3)
            {
                return RespCheckUntils.getArgsError();
            }
            string key = cmd[1];
            string hkey = cmd[2];
            var l = Database.getStrucutr(key);

            if (l == null) return new RespResEntity(false, "nil");

            return new RespResEntity(true, ((HashStucture)l).hexists(hkey));
        }

        public static RespResEntity hkeys(string[] cmd)
        {

            if (cmd.Length < 2)
            {
                return RespCheckUntils.getArgsError();
            }
            string key = cmd[1];
            var l = Database.getStrucutr(key);

            if (l == null) return new RespResEntity(false, "nil");

            return new RespResEntity(true, ((HashStucture)l).hkeys());

        }
        public static RespResEntity hvals(string[] cmd)
        {
            if (cmd.Length < 2)
            {
                return RespCheckUntils.getArgsError();
            }
            string key = cmd[1];
            var l = Database.getStrucutr(key);

            if (l == null) return new RespResEntity(false, "nil");

            return new RespResEntity(true, ((HashStucture)l).hval());
        }
        public static void registCmd()
        {
            CmdTable.RegistCmd("hset", hset);

            CmdTable.RegistCmd("hget", hget);

            CmdTable.RegistCmd("hgetall", hgetall);


            CmdTable.RegistCmd("hkeys", hkeys);



            CmdTable.RegistCmd("hvals", hvals);
        }



    }
}

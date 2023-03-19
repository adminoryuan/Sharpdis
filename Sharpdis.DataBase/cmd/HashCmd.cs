using Sharpdis.Common.Entity;
using Sharpdis.Common.Expand;
using Sharpdis.DataStructure.structure;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure.cmd
{
     class HashCmd
    {
        [ArgsVerify(3)]
        public static RespResEntity hget(string[] cmd)
        {
            if (cmd.Length < 3)
            {
                return RespResUntils.GetArgsError();
            }

            string key = cmd[1];
            string hkey = cmd[2];
            var l =  CmdTable.db.getStrucutr(key, CmdTable.db.GetSelectIndex());

            if (l == null) return new RespResEntity(false, "nil");

            return new RespResEntity(true, ((HashStucture)l).hget(hkey));
        }
        [ArgsVerify(4)]
        public static RespResEntity hset(string[] cmd)
        {
            string key = cmd[1];
            string hkey = cmd[2];
            string hval = cmd[3];
            return new RespResEntity(true,  CmdTable.db.CrateStrucutr<HashStucture>(key).Hset(hkey, hval));
        }

        [ArgsVerify(2)]
        public static RespResEntity hgetall(string[] cmd)
        {
            string key = cmd[1];
            var l =  CmdTable.db.getStrucutr(key, CmdTable.db.GetSelectIndex());

            if (l == null) return new RespResEntity(false, "nil");

            return new RespResEntity(true, ((HashStucture)l).hgetall());
        }
        [ArgsVerify(3)]
        public static RespResEntity hexists(string[] cmd)
        {
            if (cmd.Length < 3)
            {
                return RespResUntils.GetArgsError();
            }
            string key = cmd[1];
            string hkey = cmd[2];
            var l =  CmdTable.db.getStrucutr(key, CmdTable.db.GetSelectIndex());

            if (l == null) return new RespResEntity(false, "nil");

            return new RespResEntity(true, ((HashStucture)l).hexists(hkey));
        }
        [ArgsVerify(2)]
        public static RespResEntity hkeys(string[] cmd)
        {
            string key = cmd[1];
            var l =  CmdTable.db.getStrucutr(key, CmdTable.db.GetSelectIndex());

            if (l == null) return new RespResEntity(false, "nil");

            return new RespResEntity(true, ((HashStucture)l).hkeys());

        }
        
        [ArgsVerify(2)]
        public static RespResEntity hvals(string[] cmd)
        {
            if (cmd.Length < 2)
            {
                return RespResUntils.GetArgsError();
            }
            string key = cmd[1];
            var l =  CmdTable.db.getStrucutr(key, CmdTable.db.GetSelectIndex());

            if (l == null) return new RespResEntity(false, "nil");

            return new RespResEntity(true, ((HashStucture)l).hval());
        }
        
        public static void RegistCmd()
        {
            CmdTable.RegistCmd("hset", hset);

            CmdTable.RegistCmd("hget", hget);

            CmdTable.RegistCmd("hgetall", hgetall);

            CmdTable.RegistCmd("hkeys", hkeys);
             
            CmdTable.RegistCmd("hvals", hvals);
        }


    }
}

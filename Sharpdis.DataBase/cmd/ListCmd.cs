using Sharpdis.Common.Entity;
using Sharpdis.DataStructure.structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharpdis.Common.Expand;
namespace Sharpdis.DataStructure.cmd
{

    /// <summary>
    /// list命令的具体实现
    /// </summary>
     static class ListCmd
     {
        [ArgsVerify(3)]
        public static RespResEntity lLen(string[] args)
        {
            string key = args[1];
            var l = CmdTable.db.getStrucutr(key, CmdTable.db.GetSelectIndex());
            if (l == null)
            {
                return new RespResEntity(false, "nil!");
            }
            string value = Convert.ToString(((ListStucture)l).Len());

            return new RespResEntity(true, value);
        }
        [ArgsVerify(1)]
        public static RespResEntity LPop(string[] args)
        {
            string key = args[1];

            var l =  CmdTable.db.getStrucutr(key, CmdTable.db.GetSelectIndex());
            if (l == null)
            {
                return new RespResEntity(false, "nil");
            }
            return new RespResEntity(true, ((ListStucture)l).LPop());
        }
        [ArgsVerify(1)]
        public static RespResEntity RPop(string[] args)
        {
            string key = args[1];
            var l =  CmdTable.db.getStrucutr(key, CmdTable.db.GetSelectIndex());
            if (l == null)
            {
                return new RespResEntity(false, "nil!");
            }
            return new RespResEntity(true, ((ListStucture)l).RPop());
        }
        [ArgsVerify(3)]
        public static RespResEntity lPush(string[] args)
        {
            string key = args[1];
            string val = args[2];

            return new RespResEntity(true,  CmdTable.db.CrateStrucutr<ListStucture>(key).LPush(args.Skip(2).Take(args.Length - 2).ToArray()) ? "ok" : "error");
        }
        [ArgsVerify(3)]
        public static RespResEntity RPush(string[] args)
        {
            
            string key = args[1];

            return new RespResEntity(true,  CmdTable.db.CrateStrucutr<ListStucture>(key).RPush(args.Skip(2).Take(args.Length - 2).ToArray()) ? "ok" : "err");
        }
        [ArgsVerify(3)]
        public static RespResEntity LIndex(string[] args)
        {
            string key = args[1];
            int val = -1;
            if (!int.TryParse(args[2], out val))
            {
                return new RespResEntity(false, "wrong number of arguments for 'LIndex' command");

            }

            return new RespResEntity(true,  CmdTable.db.CrateStrucutr<ListStucture>(key).lindex(val));


        }
        [ArgsVerify(4)]
        public static RespResEntity lRange(string[] args)
        {
            string key = args[1];

            int startindex, stopindex;
            if (!int.TryParse(args[2], out startindex) || !int.TryParse(args[3], out stopindex))
            {
                return new RespResEntity(false, "wrong number of arguments for 'lRange' command");
            }
            return new RespResEntity(true,  CmdTable.db.CrateStrucutr<ListStucture>(key).lrange(startindex, stopindex));

        }
        static ListCmd()
        {

        }

        public static void RegistCmd()
        {
            CmdTable.RegistCmd("llen", lLen);
            CmdTable.RegistCmd("lindex", LIndex);
            CmdTable.RegistCmd("lpos", lLen);
            CmdTable.RegistCmd("lpop", LPop);
            CmdTable.RegistCmd("rpop", RPop);
            CmdTable.RegistCmd("lpush", lPush);
            CmdTable.RegistCmd("lpushx", lLen);
            CmdTable.RegistCmd("rpush", RPush);
            CmdTable.RegistCmd("rpushx", lLen);
            CmdTable.RegistCmd("lset", lLen);
            CmdTable.RegistCmd("lrem", lLen);
            CmdTable.RegistCmd("ltrim", lLen);
            CmdTable.RegistCmd("lrange", lRange);
            CmdTable.RegistCmd("lmove", lLen);

        }


    }
}

using Sharpdis.DataStructure.structure;
using Sharpdis.Net.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharpdis.DataStructure
{   

    /// <summary>
    /// list命令的具体实现
    /// </summary>
    public static class List
    { 
        public static RespResEntity lLen(string[] args)
        {
            string key = args[1];

            var l = Database.getStrucutr(key);
            if (l == null)
            {
                return new RespResEntity(false,"nil!");
            }
            string value = Convert.ToString(((ListStucture)l).Len());
        
            return new RespResEntity(true, value);
        }
        public static RespResEntity LPop(string[] args)
        {
            if (args.Length < 1) return new RespResEntity(false, "wrong number of arguments for 'lPush' command ");
            string key = args[1];

            var l = Database.getStrucutr(key);
            if (l == null)
            {
                return new RespResEntity(false, "nil");
            }
            return new RespResEntity(true, ((ListStucture)l).LPop());
        }
        public static  RespResEntity RPop(string[] args)
        {
            if (args.Length < 1) return new RespResEntity(false, "wrong number of arguments for 'lPush' command ");

            string key = args[1];
            var l = Database.getStrucutr(key);
            if (l == null)
            {
                return new RespResEntity(false, "nil!");
            }
            return new RespResEntity(true, ((ListStucture)l).RPop());
        }
        public static RespResEntity lPush(string[] args)
        {
            if (args?.Length < 3)
            {
                return new RespResEntity(false, "wrong number of arguments for 'lPush' command");
            }
            string key = args[1];
            string val = args[2];
            
            return new RespResEntity(true, Database.CrateStrucutr<ListStucture>(key).LPush(args.Skip(2).Take(args.Length-2).ToArray())?"ok":"error");
        }

        public static RespResEntity RPush(string[] args)
        {
            if (args?.Length < 3)
            {
                return new RespResEntity(false, "wrong number of arguments for 'lPush' command");
            }
            string key = args[1];

            return new RespResEntity(true, Database.CrateStrucutr<ListStucture>(key).RPush(args.Skip(2).Take(args.Length - 2).ToArray())?"ok":"err");
        }
        public static RespResEntity LIndex(string[] args)
        {
            if (args?.Length < 3)
            {
                return new RespResEntity(false, "wrong number of arguments for 'LIndex' command");
            }
            string key = args[1];
            int val = -1; 
            if(!int.TryParse(args[2],out val))
            {
                return new RespResEntity(false, "wrong number of arguments for 'LIndex' command");

            }

            return new RespResEntity(true, Database.CrateStrucutr<ListStucture>(key).lindex(val));


        }
        public static RespResEntity lRange(string[] args)
        {
            if (args?.Length < 4)
            {
                return new RespResEntity(false, "wrong number of arguments for 'lrange' command");
            }
            string key = args[1];
            int startindex,stopindex;
            if (!int.TryParse(args[2],out startindex) || !int.TryParse(args[3],out stopindex))
            {
                return new RespResEntity(false, "wrong number of arguments for 'lRange' command");
            }
            return new RespResEntity(true, Database.CrateStrucutr<ListStucture>(key).lrange(startindex,stopindex));

        }
        static List()
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
            CmdTable.RegistCmd("rpush",RPush);
            CmdTable.RegistCmd("rpushx", lLen);
            CmdTable.RegistCmd("lset", lLen);
            CmdTable.RegistCmd("lrem", lLen);
            CmdTable.RegistCmd("ltrim", lLen);
            CmdTable.RegistCmd("lrange", lRange);
            CmdTable.RegistCmd("lmove", lLen);

        }

     
    }
}

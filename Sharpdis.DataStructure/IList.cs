using Sharpdis.DataStructure.structure;
using Sharpdis.Net.Entity;
using System;
using System.Collections.Generic;
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
            
            string value = Convert.ToString(CmdTable.getStrucutr<ListStucture>(key).Len());
        
            return new RespResEntity(true, value);
        }
        public static RespResEntity LPop(string[] args)
        {
            string key = args[1];
            return new RespResEntity(true, CmdTable.getStrucutr<ListStucture>(key).LPop());
        }
        public static  RespResEntity RPop(string[] args)
        {
            string key = args[1];
            return new RespResEntity(true, CmdTable.getStrucutr<ListStucture>(key).RPop());
        }
        public static RespResEntity lPush(string[] args)
        {
            if (args?.Length < 3)
            {
                return new RespResEntity(false, "wrong number of arguments for 'lPush' command");
            }
            string key = args[1];
            string val = args[2];
            
            return new RespResEntity(true, CmdTable.getStrucutr<ListStucture>(key).LPush(val));
        }
        
        static List()
        {
            RegistCmd();
        }

        public static void RegistCmd()
        {
            CmdTable.RegistCmd("llen", lLen);
            CmdTable.RegistCmd("lindex", lLen);
            CmdTable.RegistCmd("lpos", lLen);
            CmdTable.RegistCmd("lpop", lLen);
            CmdTable.RegistCmd("rpop", lLen);
            CmdTable.RegistCmd("lpush", lLen);
            CmdTable.RegistCmd("lpushx", lLen);
            CmdTable.RegistCmd("rpush", lLen);
            CmdTable.RegistCmd("rpushx", lLen);
            CmdTable.RegistCmd("lset", lLen);
            CmdTable.RegistCmd("lrem", lLen);
            CmdTable.RegistCmd("ltrim", lLen);
            CmdTable.RegistCmd("lrange", lLen);
            CmdTable.RegistCmd("lmove", lLen);

        }

     
    }
}

﻿using Sharpdis.Common.Entity;
using Sharpdis.DataStructure.structure;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sharpdis.DataStructure.cmd
{
     static class StringCmd
    {
        public static RespResEntity Set(string[] cmd)
        {
            if (cmd.Length < 3) return RespResUntils.getArgsError();
            string key = cmd[1];
            string val = cmd[2];
            return new RespResEntity(true,  CmdTable.db.CrateStrucutr<StringStructure>(key).set(val));
        }
        public static RespResEntity Incr(string[] cmd)
        {
            if (cmd.Length < 2) return RespResUntils.getArgsError();
            string key = cmd[1];
            var l =  CmdTable.db.getStrucutr(key, CmdTable.db.GetSelectIndex());
            if (l == null) return new RespResEntity(false, "nil");
            int number = 0;
            if(!((StringStructure)l).incr(out number))
                return new RespResEntity(false,  "convent val error");
            return new RespResEntity(true, number);

        }
        public static RespResEntity Get(string[] cmd)
        {
            if (cmd.Length < 2) return RespResUntils.getArgsError();
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
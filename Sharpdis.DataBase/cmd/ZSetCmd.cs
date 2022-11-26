using Sharpdis.Common.Entity;
using Sharpdis.DataStructure.structure;
using Sharpdis.Untils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.DataStructure.cmd
{
     static class ZSetCmd
    {
        public static RespResEntity Range(string[] cmd)
        {
            int min, max;
            if (cmd.Length < 4 || int.TryParse(cmd[2], out min) || !int.TryParse(cmd[3], out max))
            {
                return RespResUntils.getArgsError();
            }
            var l =  CmdTable.db.getStrucutr(cmd[1]);
            
            if (l == null) return new RespResEntity(false, "nil");

            return new RespResEntity(true, ((ZSetStructure)l).ZRange(min, max));
        }
        public static RespResEntity ZAdd(string[] cmd)
        {
            if (cmd.Length < 4 || cmd.Length % 2 != 0)
            {
                return RespResUntils.getArgsError();

            }
            var l =  CmdTable.db.getStrucutr(cmd[1]);
            
            if (l == null) return new RespResEntity(false, "nil");


            int index = 2;

            var zsetStr = (ZSetStructure)l;
            List<SkipNode> args = new List<SkipNode>();

            // 拆分命令 保证命令正确
            while (index < cmd.Length)
            {
                int score = 0;
                if (!int.TryParse(cmd[index++], out score))
                {
                    return RespResUntils.getArgsError();
                }
                args.Add(new SkipNode(score, cmd[index++]));
            }
            //保存数据
            args.ForEach(new Action<SkipNode>(a =>
            {
                zsetStr.zadd(a);
            }));

            return new RespResEntity(true, "ok");
        }

        public static RespResEntity Rank(string[] cmd)
        {
            if (cmd == null || cmd.Length < 3)
            {
                return RespResUntils.getArgsError();
            }
            string Structkey = cmd[1];

            object res;
            if ((res =  CmdTable.db.getStrucutr(Structkey)) == null)
            {
                return RespResUntils.getNilRes();
            }

            if (((ZSetStructure)res).Rank(cmd[2]) == -1) return RespResUntils.getNilRes();


            return RespResUntils.getOkRes();


        }
    }
}

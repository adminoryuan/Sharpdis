using Sharpdis.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Untils
{
    /// <summary>
    /// resp协议
    /// </summary>


    public class RespResUntils
    {
        public static RespResEntity getArgsError()
        {
            return new RespResEntity(false, "Args error");
        }
        public static RespResEntity getNilRes()
        {
            return new RespResEntity(true, "nil");
        }

        public static RespResEntity getOkRes()
        {
            return new RespResEntity(true, "ok");
        }
        public static bool ChechCmd(string[] cmd)
        {
            return true;
        }
    }
}

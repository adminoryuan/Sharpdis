using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Untils
{
    public class LoggerUntils
    {

        private static HashSet<String> cmdSet;
        static LoggerUntils()
        {
            cmdSet = new HashSet<string>();
            cmdSet.Add("set");
            cmdSet.Add("hset");

        }

        /// <summary>
        /// 是否是写命令
        /// </summary>
        /// <returns></returns>
        public static bool IsWriteCmd(string cmd)
        {
            return cmdSet.Contains(cmd);
        }
    }
}

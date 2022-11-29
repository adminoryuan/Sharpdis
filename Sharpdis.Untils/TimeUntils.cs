using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Untils
{
    public static class TimeUntils
    {

        public static long getTimeSpan()
        {
            TimeSpan mTimeSpan = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0);
            //得到精确到秒的时间戳（长度10位）
            long time = (long)mTimeSpan.TotalSeconds;
            return time;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Click_TV
{
    class UnixTime
    {
        public static int getUnixTimeStamp(DateTime time)
        {
            return (int)(time.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        }
    }
}

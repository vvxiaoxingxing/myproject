using System;

namespace NetCore.Infrastructure.Utils
{
    /// <summary>
    /// <see cref="DateTime"/>的工具类
    /// </summary>
    public static class TimeUtil
    {
        /// <summary>
        /// The unix UTC Ticks.
        /// 1970-01-01 00:00:00 的时间刻度
        /// </summary>
        public const long UnixUTCTicks = 621355968000000000;

        /// <summary>
        /// 获取本地当前时间的 Unix 时间戳
        /// 注：会将本地时间转换为 UTC 时间
        /// </summary>
        /// <returns>The UTCT imestamp.</returns>
        public static long UnixTimestamp()
        {
            return UnixTimestamp(DateTime.UtcNow);
        }

        /// <summary>
        /// 获取指定时间的 Unix 时间戳（使用的是 UTC 时间） ,精确到秒
        /// </summary>
        /// <param name="utcTime">UTC 时间, 注：此时间必须为 UTC 时间</param>
        /// <returns></returns>
        public static long UnixTimestamp(DateTime utcTime)
        {
            return (utcTime.Ticks - UnixUTCTicks) / 10000000;
        }

        

        public static long DateTimeToUtcMillisecond(this DateTime time)
        {
            return UnixTimestampMillisecond(time);
        }

        /// <summary>
        /// 获取指定时间的 Unix 时间戳，精确到毫秒
        /// </summary>
        /// <param name="utcTime">UTC 时间，注：此处是 UTC 时间</param>
        /// <returns></returns>
        public static long UnixTimestampMillisecond(DateTime utcTime)
        {
            return (utcTime.Ticks - UnixUTCTicks) / 10000;
        }

        /// <summary>
        /// 时间戳转换时间(秒)
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime SUnixTimestampToDateTime(this long unixTimeStamp)
        {
            DateTime startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.FindSystemTimeZoneById("China Standard Time"));
            startTime = startTime.AddSeconds(unixTimeStamp);
            startTime = startTime.AddHours(8);//转化为北京时间(北京时间=UTC时间+8小时 )
            return startTime;
        }

        /// <summary>
        /// 时间戳转换时间(毫秒)
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime MSUnixTimestampToDateTime(this long unixTimeStamp)
        {
            DateTime startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.FindSystemTimeZoneById("China Standard Time"));
            startTime = startTime.AddMilliseconds(unixTimeStamp);
            startTime = startTime.AddHours(8);//转化为北京时间(北京时间=UTC时间+8小时 )
            return startTime;
        }

        /// <summary>
        ///  时间转时间戳Unix-时间戳精确到毫秒
        /// </summary> 
        public static long ToUnixTimestampByMilliseconds(this DateTime dt)
        {
            DateTimeOffset dto = new DateTimeOffset(dt);
            return dto.ToUnixTimeMilliseconds();
        }


        /// <summary>  
        /// 得到本周第一天(以星期一为第一天)  
        /// </summary>  
        /// <param name="datetime"></param>  
        /// <returns></returns>  
        public static DateTime GetWeekFirstDayMon(DateTime datetime)
        {
            //星期一为第一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);

            //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。  
            weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
            int daydiff = (-1) * weeknow;

            //本周第一天  
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }
        /// <summary>  
        /// 得到本周最后一天(以星期天为最后一天)  
        /// </summary>  
        /// <param name="datetime"></param>  
        /// <returns></returns>  
        public static DateTime GetWeekLastDaySun(DateTime datetime)
        {
            //星期天为最后一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            weeknow = (weeknow == 0 ? 7 : weeknow);
            int daydiff = (7 - weeknow);

            //本周最后一天  
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }
    }
}

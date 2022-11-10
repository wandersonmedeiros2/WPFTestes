using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfClockControlApp.NativeApi
{
    public struct SystemTime
    {
        public ushort Year;
        public ushort Month;
        public ushort DayOfWeek;
        public ushort Day;
        public ushort Hour;
        public ushort Minute;
        public ushort Second;
        public ushort Millisecond;
    };

    public class Kernel32Wrapper
    {
        [DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
        private extern static bool Kernel32SetSystemTime(ref SystemTime st);

        [DllImport("kernel32.dll", EntryPoint = "GetSystemTime", SetLastError = true)]
        private extern static void Kernel32GetSystemTime(ref SystemTime st);

        [DllImport("kernel32.dll", EntryPoint = "SetLocalTime", SetLastError = true)]
        private extern static void Kernel32SetLocalTime(ref SystemTime st);

        [DllImport("kernel32.dll", EntryPoint = "GetLocalTime", SetLastError = true)]
        private extern static void Kernel32GetLocalTime(ref SystemTime st);


        private static SystemTime DateTimeToSystemTime(DateTime dateTime)
        {
            SystemTime systemTime = new SystemTime();
            systemTime.Year = (ushort)dateTime.Year;
            systemTime.Month = (ushort)dateTime.Month;
            systemTime.DayOfWeek = (ushort)dateTime.DayOfWeek;
            systemTime.Day = (ushort)dateTime.Day;
            systemTime.Hour = (ushort)dateTime.Hour;
            systemTime.Minute = (ushort)dateTime.Minute;
            systemTime.Second = (ushort)dateTime.Second;
            systemTime.Millisecond = (ushort)dateTime.Millisecond;

            return systemTime;
        }

        public static void SetSystemTime(DateTime dateTime)
        {

            DateTime datetimeUTC = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second,dateTime.Millisecond, DateTimeKind.Local);
            SystemTime systemTime = DateTimeToSystemTime(datetimeUTC);


            Kernel32SetLocalTime(ref systemTime);
        }

        public static void SetSystemTime(TimeSpan time)
        {
            DateTime currentDatetime = DateTime.Now;
            DateTime datetimeUTC = new DateTime(currentDatetime.Year, currentDatetime.Month, currentDatetime.Day, time.Hours, time.Minutes, time.Seconds, time.Milliseconds, DateTimeKind.Local);
            SetSystemTime(datetimeUTC);
        }

    }
}

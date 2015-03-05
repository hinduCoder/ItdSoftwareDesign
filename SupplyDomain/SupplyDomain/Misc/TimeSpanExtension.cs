using System;

namespace SupplyDomain.Misc
{
    public static class TimeSpanExtension
    {
        public static int Weeks(this TimeSpan timeSpan)
        {
            return timeSpan.Days / 7;
        }
    }
}
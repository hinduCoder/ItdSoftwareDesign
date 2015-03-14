using System;

namespace SupplyDomain
{
    public static class DateTimeExtenstion
    {
        public static int Week(this DateTime dateTime)
        {
            return dateTime.Day / 7;
        }

        public static int GetMonthCountOfBetween(this DateTime thisDateTime, DateTime otherDateTime)
        {
            return Math.Abs(thisDateTime.Month - otherDateTime.Month 
                + (thisDateTime.Year - otherDateTime.Year)*12);
        }
    }
}
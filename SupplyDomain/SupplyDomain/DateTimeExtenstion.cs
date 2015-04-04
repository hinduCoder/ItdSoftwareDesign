using System;

namespace SupplyDomain
{
    public static class DateTimeExtenstion
    {
        public static int GetMonthCountOfBetween(this DateTime thisDateTime, DateTime otherDateTime)
        {
            return Math.Abs(thisDateTime.Month - otherDateTime.Month 
                + (thisDateTime.Year - otherDateTime.Year)*12);
        }
    }
}
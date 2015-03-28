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

        public static bool CheckDateIntoPeriod(this DateTime thisDateTime, DateTime otherDateTime, int monthRepetition)
        {
            if (thisDateTime < otherDateTime)
            {
                var temp = thisDateTime;
                thisDateTime = otherDateTime;
                otherDateTime = temp;
            }
            if (thisDateTime.Day == otherDateTime.Day ||
                thisDateTime.Day > DateTime.DaysInMonth(otherDateTime.Year, otherDateTime.Month))
            {
                return thisDateTime.GetMonthCountOfBetween(otherDateTime) % monthRepetition == 0;
            }
            return false;
        }

    }
}
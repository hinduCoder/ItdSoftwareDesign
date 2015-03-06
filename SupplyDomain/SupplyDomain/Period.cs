using System;
using SupplyDomain.Misc;

namespace SupplyDomain {
    public class Period
    {
        private int _monthRepetition;
        private DateTime _startDate;

        public int MonthRepetition
        {
            get { return _monthRepetition; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Months repeatness may be bigger then 0");
                }
                _monthRepetition = value;
            }
        }

        public Period(DateTime startDate, int monthRepetition)
        {
            _startDate = startDate;
            _monthRepetition = monthRepetition;
        }

        public bool IsDueDateToday
        {
            get { return DateTime.Now.GetMonthCountOfBetween(_startDate) % MonthRepetition == 0; }
        }
    }
}


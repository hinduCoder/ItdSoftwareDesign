using System;
using SupplyDomain.Misc;

namespace SupplyDomain {
    public class Period
    {
        private int _monthRepeatnes;
        private DateTime _startDate;

        public int MonthRepeatnes
        {
            get { return _monthRepeatnes; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Months repeatness may be bigger then 0");
                }
                _monthRepeatnes = value;
            }
        }

        public Period(DateTime startDate, int monthRepeatnes)
        {
            _startDate = startDate;
            _monthRepeatnes = monthRepeatnes;
        }

        public bool IsDueDateToday
        {
            get { return DateTime.Now.GetMonthCountOfBetween(_startDate) % MonthRepeatnes == 0; }
        }
    }
}


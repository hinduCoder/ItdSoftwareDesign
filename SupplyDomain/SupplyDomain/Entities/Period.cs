using System;
using SupplyDomain;

namespace SupplyDomain.Entities 
{
    public class Period
    {
        private int _monthRepetition;
        private DateTime _startDate;
        private DateTime _closeDate;

        public int MonthRepetition
        {
            get { return _monthRepetition; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
        }

        public DateTime CloseDate
        {
            get { return _closeDate; }
        }

        public Period(DateTime startDate, int monthRepetition, DateTime closeDate)
        {
            _startDate = startDate;
            _monthRepetition = monthRepetition;
            _closeDate = closeDate;
        }

        public bool IsDueDate(DateTime date)
        {
            return date.CheckDateIntoPeriod< _closeDate;
        }
    }
}


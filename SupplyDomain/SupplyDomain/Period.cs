using System;
using System.Collections.Generic;
using System.Linq;
using SupplyDomain.Misc;

namespace SupplyDomain {
    public class Period {
        private int? _days;
        private int? _weeks;
        private int? _months;
        private int? _years;
        private DateTime _startDate;
        private readonly HashSet<DayOfWeek> _daysOfWeek = new HashSet<DayOfWeek>();

        public Period(DateTime startDate) 
        {
            _startDate = startDate;
        }
        public int? Days 
        {
            get { return _days; }
            set { _days = value; }
        }
        public int? Weeks 
        {
            get { return _weeks; }
            set { _weeks = value; }
        }
        public int? Months 
        {
            get { return _months; }
            set { _months = value; }
        }
        public int? Years 
        {
            get { return _years; }
            set { _years = value; }
        }
        public void SetDaysOfWeek(params DayOfWeek[] days)
        {
            foreach (var day in days)
	        {
		        _daysOfWeek.Add(day);
	        }
        }
        public bool IsDueDateToday 
        {
            get 
            {
                return CheckWhetherDueDateIsToday();
            }
        }
        private bool CheckWhetherDueDateIsToday() 
        {
            var dueDateIsToday = IsCurrentYear();
            dueDateIsToday = dueDateIsToday && IsCurrentMonth();
            dueDateIsToday = dueDateIsToday && IsCurrentWeek();
            if (IsCurrentDay()) return true; //TODO
            return dueDateIsToday;
        }

        private bool IsCurrentDay()
        {
            DateTime now = DateTime.Now;
            bool result;
            if (_daysOfWeek.Count != 0)
                result &= _daysOfWeek.Any(day => day == now.DayOfWeek);
            else if (_days == null)
                result &= now.Day == _startDate.Day;
            else
                return true;
            return false;
        }

        private bool IsCurrentWeek()
        {
            if (_weeks == null)
                return true;
            if (_months == null)
                return (DateTime.Now - _startDate).Weeks() % _weeks == 0;
            return DateTime.Now.Week() %_weeks == 0;
        }

        private bool IsCurrentMonth()
        {
            if (_months != null)
                return DateTime.Now.GetMonthCountOfBetween(_startDate) % _months == 0;
            return true;
        }

        private bool IsCurrentYear()
        {
            if (_years != null)
                return (DateTime.Now.Year - _startDate.Year) % _years == 0;
            return true;
        }
    }
}


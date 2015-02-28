using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDomain
{
    public class Period
    {
        protected int? _days;
        protected int? _weeks;
        protected int? _months;
        protected int? _years;
        private DateTime _startDate;

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
        public bool IsToday
        {
            get { return CheckWhetherDateIsToday(); }
        }
        private bool CheckWhetherDateIsToday()
        {
            var result = true;
            var now = DateTime.Now;
            if(_years != null)
                result &=  (now.Year - _startDate.Year) % _years == 0;
            if(_months != null)
                result &= (now.Month - _startDate.Month) % _months == 0;
            if(_weeks != null)
                result &= (now - _startDate).Days % _days == 0;
            if(_days == null)
                result &= now.Day == _startDate.Day;
            return result;
        }
    }
}


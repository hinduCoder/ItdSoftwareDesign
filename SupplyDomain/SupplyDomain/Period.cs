using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< Updated upstream
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
=======
namespace SupplyDomain {
    public class Period {
        private int? days;
        private int? weeks;
        private int? months;
        private int? years;
        private DateTime startDate;
        private HashSet<DayOfWeek> daysOfWeek = new HashSet<DayOfWeek>();

        public Period(DateTime startDate) 
        {
            this.startDate = startDate;
        }
        public int? Days 
        {
            get { return days; }
            set { days = value; }
        }
        public int? Weeks 
        {
            get { return weeks; }
            set { weeks = value; }
        }
        public int? Months 
        {
            get { return months; }
            set { months = value; }
        }
        public int? Years 
        {
            get { return years; }
            set { years = value; }
        }
        public void SetDaysOfWeek(params DayOfWeek[] days)
        {
            foreach (var day in days)
	        {
		        daysOfWeek.Add(day);
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
            DateTime now;
            bool result;
            if (daysOfWeek.Count != 0)
                result &= daysOfWeek.Any(day => day == now.DayOfWeek);
            else if (days == null)
                result &= now.Day == startDate.Day;
            else
                return true;
            return false;
        }

        private bool IsCurrentWeek()
        {
            bool result;
            if (weeks == null)
                return true;
            if (months == null)
                return (DateTime.Now - startDate).Days % (weeks * 7) == 0; //Why days?
            return 
        }

        private bool IsCurrentMonth()
        {
            bool result;
            if (months != null)
                return (DateTime.Now.Month - startDate.Month) % months == 0;
            return true;
        }

        private bool IsCurrentYear()
        {
            if (years != null)
                return (DateTime.Now.Year - startDate.Year) % years == 0;
            return true;
>>>>>>> Stashed changes
        }
    }
}


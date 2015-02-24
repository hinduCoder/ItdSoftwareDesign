using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDomain {
    public class Period {
        protected int? days;
        protected int? weeks;
        protected int? months;
        protected int? years;
        private DateTime startDate;

        public Period(DateTime startDate) {
            this.startDate = startDate;
        }
        public int? Days {
            get { return days; }
            set { days = value; }
        }
        public int? Weeks {
            get { return weeks; }
            set { weeks = value; }
        }
        public int? Months {
            get { return months; }
            set { months = value; }
        }
        public int? Years {
            get { return years; }
            set { years = value; }
        }
        public bool IsToday {
            get {
                return CheckWhetherDateIsToday();
            }
        }
        private bool CheckWhetherDateIsToday() {
            var result = true;
            var now = DateTime.Now;
            if(years != null)
                result &=  (now.Year - startDate.Year) % years == 0;
            if(months != null)
                result &= (now.Month - startDate.Month) % months == 0;
            if(weeks != null)
                result &= (now - startDate).Days % days == 0;
            if(days == null)
                result &= now.Day == startDate.Day;
            return result;
        }
    }
}


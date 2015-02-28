using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDomain
{
    public class Contract
    {
        private string _number;
        private DateTime _dueDate;
        private DateTime _startDate;
        private DateTime _endDate;
        private List<string> _participants;
        private Period _period;
    }
}

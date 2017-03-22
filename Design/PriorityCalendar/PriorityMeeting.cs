using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.PriorityCalendar
{
    public class PriorityMeeting
    {
        public PriorityLevel Priority { get; set; }

        public string User { get; set; }

        public string Subject { get; set; }

        public DateTime fromDateTime { get; set; }

        public DateTime toDateTime { get; set; }
    }
}

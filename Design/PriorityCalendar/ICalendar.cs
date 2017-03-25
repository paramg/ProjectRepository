using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.PriorityCalendar
{
    public interface ICalendar
    {
        bool BookMeeting(PriorityMeeting meetingRequest);

        void SliceIfPossible(PriorityMeeting requestMeeting, PriorityMeeting currentMeeting);
    }
}

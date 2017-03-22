using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.PriorityCalendar
{
    public class PriorityMeetingCollection : List<PriorityMeeting>
    {
        public bool IsHigherPriorityExists(PriorityMeeting meetingRequest)
        {
            return this.Where(priority =>
            {
                bool isHigher = false;
                int pLevel = (int)priority.Priority;
                if (pLevel > (int)meetingRequest.Priority)
                {
                    isHigher = true;
                }

                return isHigher;
            }).ToList().Any();
        }

        public PriorityMeetingCollection GetMeetingsByTimeRange(DateTime fromDateTime, DateTime toDateTime)
        {
            return (PriorityMeetingCollection)this.Where(meeting =>
            {
                return meeting.fromDateTime <= fromDateTime
                        && meeting.toDateTime >= toDateTime;
            }).ToList();
        }

        public PriorityMeeting GetMeetingByCurrentTime(DateTime currentDateTime)
        {
            return this.Where(meeting => {
                return meeting.fromDateTime <= currentDateTime
                        && meeting.toDateTime >= currentDateTime;
            }).ToList().Single();
        }
    }
}

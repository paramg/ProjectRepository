using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.PriorityCalendar
{
    public class PriorityCalendar : ICalendar
    {
        public PriorityMeetingCollection PriorityMeetings { get; set; }

        public PriorityCalendar()
        {
            this.PriorityMeetings = new PriorityMeetingCollection();
        }

        public bool BookMeeting(PriorityMeeting meetingRequest)
        {
            bool canBookMeeting = false;
            PriorityMeetingCollection currentPriorityMeetings = this.PriorityMeetings.GetMeetingsByTimeRange(meetingRequest.fromDateTime, meetingRequest.toDateTime);

            bool isHigherPriority = this.PriorityMeetings.IsHigherPriorityExists(meetingRequest);

            if (!isHigherPriority)
            {
                canBookMeeting = true;
                this.PriorityMeetings.Add(meetingRequest);
            }
            else
            {
                // Manage the conflict and slice the priorities.
                canBookMeeting = this.ManageConflict(meetingRequest, currentPriorityMeetings);
            }

            return canBookMeeting;
        }        

        public void SliceIfPossible(PriorityMeeting requestMeeting, PriorityMeeting currentMeeting)
        {            
            // Compare start time of the two meeting request.
            int fromDateTimeValue = this.Compare(requestMeeting.fromDateTime, currentMeeting.fromDateTime);

            // Compare end time of the two meeting request.
            int toDateTimeValue = this.Compare(requestMeeting.toDateTime, currentMeeting.toDateTime);

            if(fromDateTimeValue > 0 || toDateTimeValue < 0)
            {
                // Initialize to the requested meeting.
                PriorityMeeting priorityMeeting = currentMeeting;

                // slice the end time to the beginning of the requested meeting.
                if (fromDateTimeValue > 0)
                {
                    priorityMeeting.fromDateTime = currentMeeting.fromDateTime;
                    priorityMeeting.toDateTime = requestMeeting.fromDateTime;
                }

                // slice the start time to the end of requested meeting.
                if (toDateTimeValue < 0)
                {
                    priorityMeeting.fromDateTime = requestMeeting.toDateTime;
                    priorityMeeting.toDateTime = currentMeeting.toDateTime;
                }

                this.PriorityMeetings.Add(priorityMeeting);
            }
            // Happens if the current start datetime is less than requested meeting.
            // And current end datetime is greater than requested meeting.
            // In this case slice into two meeting request and add to the priority list.
            else if(fromDateTimeValue > 0 && toDateTimeValue < 0)
            {
                PriorityMeeting priorityMeeting1 = currentMeeting;
                PriorityMeeting priorityMeeting2 = currentMeeting;

                priorityMeeting1.fromDateTime = currentMeeting.fromDateTime;
                priorityMeeting1.toDateTime = requestMeeting.fromDateTime;

                this.PriorityMeetings.Add(priorityMeeting1);

                priorityMeeting2.fromDateTime = requestMeeting.toDateTime;
                priorityMeeting2.toDateTime = currentMeeting.toDateTime;

                this.PriorityMeetings.Add(priorityMeeting2);
            }
        }

        private bool ManageConflict(PriorityMeeting meetingRequest, PriorityMeetingCollection currentPriortyMeetings)
        {
            bool canSetupMeeting = false;

            foreach (PriorityMeeting meeting in currentPriortyMeetings)
            {
                if (meetingRequest.Priority > meeting.Priority)
                {
                    // Slice out the current meeting and replace with the new one.
                    this.PriorityMeetings.Remove(meeting);

                    this.SliceIfPossible(meetingRequest, meeting);
                    canSetupMeeting = true;
                }
            }

            return canSetupMeeting;
        }

        private int Compare(DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1.CompareTo(dateTime2);
        }
    }
}

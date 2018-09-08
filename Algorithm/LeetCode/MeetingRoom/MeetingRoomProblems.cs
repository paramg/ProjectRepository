using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.MeetingRoom
{
    [TestClass]
    public class MeetingRoomProblems
    {
        public bool CanPersonAttendAllMeetings(List<Meeting> meetings)
        {
            meetings.Sort();

            for (int i=0; i< meetings.Count -1; i++)
            {
                if (meetings[i].EndTime > meetings[i + 1].StartTime)
                {
                    return false;
                }
            }

            return true;
        }

        public List<Meeting> InsertMeeting(List<Meeting> meetings, Meeting newMeeting)
        {
            meetings.Sort();
            List<Meeting> resultMeeting = new List<Meeting>();

            // In this for-loop just loop through the meetings and add only the current meeting to the list.
            // the new meeting can either be inserted in the start, middle or end. 
            // if the new meeting has to be inserted in the middle instead of current meeting, change the current meeting to new meeting
            // if there is a conflict, merge the meeting and set to the new meeting.
            // at the end at least one meeting is left to add if there is conflict or new meeting is inserted in the middle.
            // add to the end.
            foreach(Meeting currentMeeting in meetings)
            {
                if (currentMeeting.EndTime < newMeeting.StartTime)
                {
                    resultMeeting.Add(currentMeeting);
                }
                else if (currentMeeting.StartTime > newMeeting.EndTime)
                {
                    resultMeeting.Add(newMeeting);

                    // newmeeting is set to currentmeeting so that in next iteration the currentmeeting can be added to the result.
                    newMeeting = currentMeeting;
                }
                else if (currentMeeting.EndTime > newMeeting.StartTime)
                {
                    int startTime = Math.Min(currentMeeting.StartTime, newMeeting.StartTime);
                    int endTime = Math.Max(currentMeeting.EndTime, newMeeting.EndTime);

                    Meeting meeting = new Meeting(startTime, endTime);

                    // merge the new meeting with current meeting, dont add yet because there could be more meetings to be merged.
                    // once this condition is not met, then you can add the new meeting to the end.
                    newMeeting = meeting;
                }
            }

            // after exit of the loop, the new meeting is still not added to the list. 
            resultMeeting.Add(newMeeting);

            return resultMeeting;
        }

        /// <summary>
        /// Return the merged meetings.
        /// </summary>
        /// <param name="meetings"></param>
        /// <returns></returns>
        public List<Meeting> MergeMeetings(List<Meeting> meetings)
        {
            meetings.Sort();

            List<Meeting> mergedMeetings = new List<Meeting>();
            mergedMeetings.Add(meetings[0]);

            for ( int i=1; i < meetings.Count; i++)
            {
                Meeting current = mergedMeetings.Last();
                Meeting next = meetings[i];

                if (current.EndTime >= next.StartTime)
                {
                    // merge meetings.
                    int startTime = Math.Min(current.StartTime, next.StartTime);
                    int endTime = Math.Max(current.EndTime, next.EndTime);

                    current.StartTime = startTime;
                    current.EndTime = endTime;
                }
                else
                {
                    mergedMeetings.Add(next);
                }
            }

            return mergedMeetings;
        }

        [TestMethod]
        public void TestCanPersonAttendMeeting()
        {
            Meeting[] meetings1 = new Meeting[] { new Meeting(0, 30), new Meeting(5, 10), new Meeting(15, 20) };
            Assert.IsFalse(this.CanPersonAttendAllMeetings(meetings1.ToList()));

            Meeting[] meetings2 = new Meeting[] { new Meeting(0, 3), new Meeting(5, 10), new Meeting(15, 20) };
            Assert.IsTrue(this.CanPersonAttendAllMeetings(meetings2.ToList()));

            Meeting[] meetings3 = new Meeting[] { new Meeting(0, 3), new Meeting(5, 10), new Meeting(15, 20), new Meeting(7, 15) };
            Assert.IsFalse(this.CanPersonAttendAllMeetings(meetings3.ToList()));
        }

        [TestMethod]
        public void TestMergedMeetings()
        {
            Meeting[] meetings1 = new Meeting[] { new Meeting(0, 30), new Meeting(15, 20), new Meeting(20, 40), new Meeting(45, 60), new Meeting(50, 70) };
            List<Meeting> mergedMeeting = this.MergeMeetings(meetings1.ToList());
        }
    }
}

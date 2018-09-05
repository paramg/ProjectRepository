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

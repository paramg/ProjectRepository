using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.InterviewCake
{
    [TestClass]
    public class Meeting
    {
        public Meeting() { }

        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public Meeting(int startTime, int endTime)
        {
            // Number of 30 min blocks past 9:00 am
            StartTime = startTime;
            EndTime = endTime;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            var meeting = (Meeting)obj;
            return StartTime == meeting.StartTime && EndTime == meeting.EndTime;
        }

        public override int GetHashCode()
        {
            var result = 17;
            result = result * 31 + StartTime;
            result = result * 31 + EndTime;
            return result;
        }

        public override string ToString()
        {
            return $"({StartTime}, {EndTime})";
        }

        public static List<Meeting> MergeRanges(List<Meeting> meetings)
        {
            // Meeting(1,3) overlaps with Meeting(2,4) Merge to Meeting(1,4)
            // SO, if the end time is greater than the start time of next then merge the two meetings.

            // Sort the original meeting requests by start time.
            var sortedMeetingList = meetings
                 .Select(m => new Meeting(m.StartTime, m.EndTime))
                .OrderBy(m => m.StartTime);

            // Initialize the new list to the first item in the sorted list.
            IList<Meeting> ouputMeetingList = new List<Meeting> { sortedMeetingList.First() };

            foreach (var meeting in sortedMeetingList)
            {
                // get the lastly added item to the output list.
                var lastAddedMeeting = ouputMeetingList.Last();

                // If the start time of the incoming list is less than the end time of the existing list.
                // As it is ordered by start time, we can merge to the existing list.
                if (meeting.StartTime <= lastAddedMeeting.EndTime)
                {
                    // Update the end time to the max end time of both the meeting request. 
                    // For instance Meeting(1,3), the new meeting could be Meeting(1,2) => result should be Meeting (1,3)
                    // Second case: Meeting(1,3), the new meeting coule be Meeting(2, 4) => result should be Meeting (1,4)
                    lastAddedMeeting.EndTime = Math.Max(meeting.EndTime, lastAddedMeeting.EndTime);
                }
                else
                {
                    ouputMeetingList.Add(meeting);
                }
            }

            return ouputMeetingList.ToList();
        }

        [TestMethod]
        public void MeetingsOverlapTest()
        {
            var meetings = new List<Meeting>()
            {
                new Meeting(1, 3), new Meeting(2, 4)
            };
            var actual = MergeRanges(meetings);
            var expected = new List<Meeting>()
            {
                new Meeting(1, 4)
            };
            Assert.AreEqual(expected.Count, actual.Count);
        }
    }
}

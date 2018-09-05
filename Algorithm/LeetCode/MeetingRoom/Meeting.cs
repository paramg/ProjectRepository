using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.MeetingRoom
{
    public class Meeting : IComparable<Meeting>
    {
        public DateTime StartDateTime;
        public DateTime EndDateTime;

        public int StartTime;
        public int EndTime;

        public Meeting(DateTime start, DateTime end)
        {
            this.StartDateTime = start;
            this.EndDateTime = end;
        }

        public Meeting(int start, int end)
        {
            this.StartTime = start;
            this.EndTime = end;
        }

        public int CompareTo(Meeting x)
        {
            return this.StartTime.CompareTo(x.StartTime);
        }
    }
}

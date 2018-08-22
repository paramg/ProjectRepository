using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.InterviewCake
{
    [TestClass]
    public class RepeatNumbers
    {
        public static int FindRepeat(int[] items)
        {
            int floor = 1;
            int ceiling = items.Length - 1;

            while (floor < ceiling)
            {
                // Divide our range 1..n into an upper range and lower range
                // (such that they don't overlap)
                // Lower range is floor..midpoint
                // Upper range is midpoint+1..ceiling
                int midpoint = floor + (ceiling - floor) / 2;
                int lowerRangeFloor = floor;
                int lowerRangeCeiling = midpoint;
                int upperRangeFloor = midpoint + 1;
                int upperRangeCeiling = ceiling;

                // Count number of items in lower range
                int itemsInLowerRange = items.Count(item => item >= lowerRangeFloor && item <= lowerRangeCeiling);

                int distinctPossibleIntegersInLowerRange = lowerRangeCeiling - lowerRangeFloor + 1;

                if (itemsInLowerRange > distinctPossibleIntegersInLowerRange)
                {
                    // There must be a duplicate in the lower range
                    // so use the same approach iteratively on that range
                    floor = lowerRangeFloor;
                    ceiling = lowerRangeCeiling;
                }
                else
                {
                    // There must be a duplicate in the upper range
                    // so use the same approach iteratively on that range
                    floor = upperRangeFloor;
                    ceiling = upperRangeCeiling;
                }
            }

            // Floor and ceiling have converged
            // We found a number that repeats!
            return floor;
        }

        [TestMethod]
        public void LongArrayTest()
        {
            // var numbers = new int[] { 4, 1, 4, 8, 3, 2, 7, 6, 5 };
            var numbers = new int[] { 5, 8, 4, 1, 3, 2, 7, 6, 8 };
            var expected = 8;
            var actual = FindRepeat(numbers);
            Assert.AreEqual(expected, actual);
        }
    }
}

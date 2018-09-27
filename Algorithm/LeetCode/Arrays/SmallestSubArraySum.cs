using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class SmallestSubArraySum
    {
        /// <summary>
        /// watch this video: https://www.youtube.com/watch?v=NKoHjWl2m8Y
        /// </summary>
        /// <param name="array">{1, 10, 3, 40 ,18}</param>
        /// <param name="sumX">50</param>
        /// <returns></returns>
        public int GetSmallestSubArraySumGreaterThanGivenValue(int[] array, int sumX)
        {
            // first loop through the array in linear
            // set the min length to n + 1
            // set start and end point to be 0

            int start = 0;
            int end = start + 1;
            int currentSum = array[start];
            int minLengthAnswer = array.Length + 1;

            while(end < array.Length)
            {
                // if the start value is greater than end then 
                if (currentSum > sumX)
                {
                    if (start < array.Length)
                    {
                        minLengthAnswer = end - start;
                        currentSum -= array[start];
                        start++;
                    }
                }
                else
                {
                    if (end < array.Length)
                    {
                        currentSum += array[end];
                        end++;
                    }
                }
            }

            return minLengthAnswer;
        }

        [TestMethod]
        public void TestGetSmallestSubArraySumGreaterThanGivenValue()
        {
            // INCOMPLETE!!!!!
             int minValue = this.GetSmallestSubArraySumGreaterThanGivenValue(new[] { 1, 10, 3, 40, 18 }, 50);

            Assert.AreEqual(minValue, 2);
        }
    }
}

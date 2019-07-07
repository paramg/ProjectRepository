using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class SlidingWindowArray
    {
        public List<int> RangeSum(int[] array, int k)
        {
            int sum = 0;
            // initialize sum from 0 through k
            for (int i = 0; i < k; i++)
            {
                sum += array[i];
            }

            List<int> result_Array = new List<int> { sum };
            for (int i = k; i < array.Length; i++)
            {
                int intermediateSum = array[i] + result_Array[i - k] - array[i - k];

                result_Array.Add(intermediateSum);
            }

            return result_Array;
        }

        /// <summary>
        /// Uses the double ended queue (deque) to push the elements.
        /// maintain the deque such that the max (of the range) is in the front - store only the index in deque
        /// and if the next element in array is less than element at back of deque then push the element to back
        /// (the reason is it could be max at some point in the range)
        /// if the range is done exit and set the result array to the front element of the deque.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="k"></param>
        public int[] SlidingWindowMaximum(int[] array, int k)
        {
            // deque is the double ended queue which can push node to the front and back.
            dynamic deque = null;

            List<int> resultArray = new List<int>();

            for (int i=0; i<= array.Length; i++)
            {
                // pop from front if the element is out of the range.
                if (!deque.isEmpty() && deque.front() == i -k)
                {
                    deque.pop_front();
                }

                // if the array element is greater than element in deque then pop the element until it's empty
                while(!deque.isEmpty() && array[i] > array[deque.back()])
                {
                    deque.pop_back();
                }

                deque.push_back(i);

                // push the max value from the front of the deque to the result array.
                if (i >= k -1)
                {
                    resultArray.Add(array[deque.front()]);
                }
            }

            return resultArray.ToArray();
        }

        [TestMethod]
        public void TestRangeSum()
        {
            List<int> rangeSum = this.RangeSum(new[] { 1, 2, 3, 4, 5 }, 3);
        }

        [TestMethod]
        public void TestSlidingWindowsMax()
        {
            this.SlidingWindowMaximum(new[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
        }
    }
}

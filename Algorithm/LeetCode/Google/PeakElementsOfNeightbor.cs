using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Google
{
    [TestClass]
    // Tag: Google
    public class PeakElementsOfNeightbor
    {
        // Find peak element of the neighbor array, eg: [1,2,3,1] should be 3, as it's greater than 2 and 1 
        // Hint: use binary search.
        public int FindPeakElement(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] < nums[mid + 1])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        [TestMethod]
        public void TestMethod()
        {
            int[] array = { 1, 2, 3, 1};

            this.FindPeakElement(array);
        }
    }
}

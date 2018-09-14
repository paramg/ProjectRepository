using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class MedianOfArray
    {
        public int MedianOfTwoSortedArray(int[] a1, int[] a2, int start, int end)
        {
            // Always make sure that the input1 is smaller than input2.
            if(a1.Length > a2.Length)
            {
                return MedianOfTwoSortedArray(a2, a1, 0, a2.Length);
            }

            int median = -1;

            while(start <= end)
            {
                // find the median such that length of left elements and right elements are same.
                // identify the median of a1 
                int partitionA1 = (end + start) / 2;
                int partitionA2 = ((a1.Length + a2.Length + 1) / 2) - partitionA1;

                int leftPartitionA1 = partitionA1 == 0 ? int.MinValue : a1[partitionA1 - 1];
                int leftPartitionA2 = partitionA2 == 0 ? int.MinValue : a2[partitionA2 - 1];

                int rightPartitionA1 = partitionA1 == 0 ? int.MaxValue : a1[partitionA1];
                int rightPartitionA2 = partitionA2 == 0 ? int.MaxValue : a2[partitionA2];

                if (leftPartitionA1 <= rightPartitionA2 &&
                    leftPartitionA2 <= rightPartitionA1)
                {
                    // the median is found
                    // if the elements are odd then it will be max(leftPartitionA1 , leftPartitionA2 )
                    // if the elements are even then it will be Avg(max(leftPartitionA1, leftPartitionA2) , min(rightPartitionA1, rightPartitionA2)
                    if ((a1.Length + a2.Length) % 2 == 0)
                    {
                        median = (Math.Max(leftPartitionA1, leftPartitionA2) 
                                    + Math.Min(rightPartitionA1, rightPartitionA2)) / 2;
                    }
                    else
                    {
                        median = Math.Max(leftPartitionA1, leftPartitionA2);
                    }

                    break;
                }
                else if (leftPartitionA1 >= rightPartitionA2)
                {
                    // move towards left.
                    end = partitionA1 - 1;
                }
                else
                {
                    start = partitionA1;
                }
            }
            
            return median;
        }

        [TestMethod]
        public void TestMethod()
        {
            int[] sortedArrayA1 = new[] { 1, 3, 8, 9, 15 };
            int[] sortedArrayA2 = new[] { 7, 11, 18, 19, 21, 25 };

            int median = this.MedianOfTwoSortedArray(sortedArrayA1, sortedArrayA2, 0, sortedArrayA1.Length);

            Assert.AreEqual(median, 11);

            sortedArrayA1 = new[] { 23, 26, 31, 35 };
            sortedArrayA2 = new[] { 3, 5, 7, 9, 11, 16 };

            median = this.MedianOfTwoSortedArray(sortedArrayA1, sortedArrayA2, 0, sortedArrayA1.Length);

            Assert.AreEqual(median, 13);
        }
    }
}

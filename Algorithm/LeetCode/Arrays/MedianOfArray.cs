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
            int median = -1;

            while(start < end)
            {
                // find the median such that length of left elements and right elements are same.
                // identify the median of a1 
                int partitionA1 = end + start / 2;
                int partitionA2 = ((a1.Length + a2.Length + 1) / 2) - partitionA1;

                int leftPartitionA1 = a1[partitionA1 - 1];
                int leftPartitionA2 = a2[partitionA2 - 1];
                int rightPartitionA1 = a1[partitionA1];
                int rightPartitionA2 = a2[partitionA2];

                if (a1[leftPartitionA1] <= a2[rightPartitionA2] &&
                    a2[leftPartitionA2] <= a1[rightPartitionA1])
                {
                    // the median is found
                    // if the elements are odd then it will be max(a1[leftPartitionA1] , a2[leftPartitionA2] )
                    // if the elements are even then it will be Avg(max(a1[leftPartitionA1], a2[leftPartitionA2]) , min(a1[rightPartitionA1], a2[rightPartitionA2])
                    if (a1.Length + a2.Length % 2 == 0)
                    {
                        median = (Math.Max(a1[leftPartitionA1], a2[leftPartitionA2]) 
                                    + Math.Min(a1[rightPartitionA1], a2[rightPartitionA2])) / 2;
                    }
                    else
                    {
                        median = Math.Max(a1[leftPartitionA1], a2[leftPartitionA2]);
                    }
                }
                else if (a1[leftPartitionA1] >= a2[rightPartitionA2])
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

            this.MedianOfTwoSortedArray(sortedArrayA1, sortedArrayA2, 0, sortedArrayA1.Length);
        }
    }
}

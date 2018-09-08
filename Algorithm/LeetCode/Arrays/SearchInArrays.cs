using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class SearchInArrays
    {
        /// <summary>
        /// Rotated sorted array.
        /// In Rotated sorted array, there is a point where a value is less than previous value.
        /// For intance: 1 2 3 4 5 6 7 8 is rotated at 4 means 4 5 6 7 8 1 2 3
        /// It is increasing order from 4 and stops at 8 and then starts at 1 and goes in increasing order.
        /// Now, finding the pivot where it stops increasing is the first step (i.e, the value is less than previous value)
        /// If the target is less than the arr[pivot] and greater than array[n-1] then search in first set. 
        /// Otherwise search in second set of array.
        /// If it's first set then the array range will be 0-pivot
        /// If it's second set then the array range will be pivot+1 - (n-1)
        /// Both the ranges are in increasing order, so we can apply the binary search.
        /// </summary>
        public int SearchInRotatedSortedArray(int[] array, int target)
        {
            // first step find the pivot value.
            int pivotValue = this.FindPivot(array);
            int index =0;

            if (target < array[pivotValue] && target > array[array.Length -1])
            {
                // Binary search from 0 to mid-1
                int[] newArray = new int[pivotValue + 1];
                Array.Copy(array, newArray, newArray.Length);
                index = this.BinarySearch(newArray, target);
            }
            else
            {
                // Binary search from pivot  to n
                int len = array.Length -1;
                int[] newArray = new int[len - pivotValue];

                Array.Copy(array, pivotValue + 1, newArray, 0, newArray.Length);
                index = this.BinarySearch(newArray, target);

                index += pivotValue + 1;
            }

            return index;
        }

        private int BinarySearch(int[] array, int target)
        {
            int low = 0;
            int high = array.Length - 1;

            while(low<= high)
            {
                int mid = (low + high) / 2;

                if (array[mid] < target)
                {
                    low = mid + 1;
                }
                else if(array[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        private int FindPivot(int[] array)
        {
            // we can find the pivot in o(log(n)).
            int low = 0;
            int high = array.Length - 1;

            while (low < high)
            {
                int mid = (low + high) / 2;
                if (array[mid] < array[mid-1])
                {
                    return mid -1;
                }
                else 
                {
                    low = mid + 1;
                }
            }

            return 0;
        }

        public void SearchForRangeInArray()
        { }

        /// <summary>
        /// Not good impl as it's o(n).
        /// </summary>
        /// <param name="array"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsertPositionInArray(int[] array, int target)
        {
            int counter = 0;
            while (counter < array.Length)
            {
                if (array[counter] < target)
                {
                    counter += 1;
                }
                else if (array[counter] == target || array[counter] > target)
                {
                    return counter;
                }
            }

            return counter;
        }

        /// <summary>
        /// Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order. You may assume no duplicates in the array.
        /// [1,3,5,6], 5 -> 2
        /// [1,3,5,6], 2 -> 1
        /// </summary>
        public int SearchInsertPositionInSortedArray_BinarySearch(int[] array, int target)
        {
            int low = 0;
            int high = array.Length - 1;
            int mid = 0;
            while (low <= high)
            {
                mid = (low + high) / 2;

                if (array[mid] < target)
                {
                    low = mid + 1;
                }
                else if (array[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            return low;
        }

        [TestMethod]
        public void TestSearchInRotatedSortedArray()
        {
            int index = this.SearchInRotatedSortedArray(new[] { 4, 5, 6, 7, 8, 1, 2, 3 }, 5);
            Assert.AreEqual(index, 1);

            index = this.SearchInRotatedSortedArray(new[] { 3, 4, 5, 6, 7, 8, 1, 2 }, 2);
            Assert.AreEqual(index, 7);

            index = this.SearchInRotatedSortedArray(new[] { 7, 8, 1, 2, 3, 4, 5, 6 }, 4);
            Assert.AreEqual(index, 5);
        }

        [TestMethod]
        public void TestSearchInsertPositionInArray()
        {
            int[] array = { 1, 3, 5, 6 };
            int resultIndex = this.SearchInsertPositionInSortedArray_BinarySearch(array, 5);

            Assert.AreEqual(resultIndex, 2);

            array = new [] { 1, 3, 5, 6 };
            resultIndex = this.SearchInsertPositionInSortedArray_BinarySearch(array, 2);

            Assert.AreEqual(resultIndex, 1);

            array = new[] { 1, 3, 5, 6 };
            resultIndex = this.SearchInsertPositionInSortedArray_BinarySearch(array, 7);

            Assert.AreEqual(resultIndex, 4);

            array = new[] { 1, 3, 5, 6 };
            resultIndex = this.SearchInsertPositionInSortedArray_BinarySearch(array, 0);

            Assert.AreEqual(resultIndex, 0);
        }
    }
}

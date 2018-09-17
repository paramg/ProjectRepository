using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class SubArray
    {
        public class Result
        {
            public int startIndex;
            public int endIndex;
            public int sum_so_far = int.MaxValue;
        }

        public Result MinimumSubArray(int[] array)
        {
            Result result = new Result();

            int start_index = -1;
            int end_index = -1;
            int min_sum_SubArray = int.MaxValue;

            for(int i=0;i < array.Length; i++)
            {
                if (min_sum_SubArray  < 0 )
                {
                    if (start_index < 0)
                    {
                        start_index = i;
                    }

                    min_sum_SubArray += array[i];

                    end_index = i;
                }
                else
                {                    
                    start_index = -1;
                    end_index = -1;
                    min_sum_SubArray = array[i];
                }

                // save the previous ones if it's already set.
                if (result.sum_so_far > min_sum_SubArray)
                {
                    result.startIndex = start_index;
                    result.endIndex = end_index;
                    result.sum_so_far = min_sum_SubArray;
                }
            }

            return result;
        }

        public List<List<int>> GetArraysInRange(int[] originalArray, int range)
        {
            List<List<int>> resultArrays = new List<List<int>>();

            for(int i=0; i<= originalArray.Length - range; i++)
            {
                int[] temp = new int[range]; 
                for(int start = 0; start < range; start++)
                {
                     temp[start] = originalArray[start + i];
                }

                resultArrays.Add(temp.ToList());
            }

            return resultArrays;
        }

        public int SumSubArrayMins(int[] A)
        {
            // answer should be {3}, {1}, {2}, {4}, {3,1}, {1,2}, {2,4}, {3,1,2} {1,2,4} {3,1,2,4}
            // min_answer should be {3}, {1}, {2}, {4}, {1}, {1}, {2}, {1}, {1}, {1}
            int k = 1;
            List<List<int>> resultArrays = new List<List<int>>();
            while (k <= A.Length)
            {
                List<List<int>> temp = this.GetArraysInRange(A, k);

                resultArrays.AddRange(temp);
                k = k + 1;
            }

            List<int> minResultArray = new List<int>();
            foreach (List<int> array in resultArrays)
            {
                Result result = this.MinimumSubArray(array.ToArray());
                minResultArray.Add(result.sum_so_far);
            }

            return minResultArray.Sum();
        }

        [TestMethod]
        public void TestMinimumSubArray()
        {
            int[] arr = { 3, 1, 2, 4 };
            int result = this.SumSubArrayMins(arr);
            Assert.AreEqual(result, 17);
        }
    }
}

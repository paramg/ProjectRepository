using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class TwoSumProblem
    {
        /// <summary>
        /// First sort the array.
        /// Start from first index and from last index.
        /// Move the first index to right (one step) if the array[first] + array[last] is less than target
        /// Move the last index to left (one step) if the array[first] + array[last]  is greater than target.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSumByOrderOneSpace(List<int> nums, int target)
        {
            int[] result = new int[2]; 
            nums.Sort();
            int first =0, last = nums.Count -1;

            while(first < last)
            {
                int total = nums[first] + nums[last];

                if (total == target)
                {
                    result[0] = nums[first];
                    result[1] = nums[last];

                    break;
                }

                first = total < target ? first + 1 : first;
                last = total > target ? last - 1 : last;
            }

            return result;
        }

        /// <summary>
        /// One pass hash.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<string, int> hashMap = new Dictionary<string, int>();

            for (int i = 0; i <= nums.Length; i++)
            {
                int result = target - nums[i];

                if (hashMap.ContainsKey(result.ToString()))
                {
                    int value;
                    hashMap.TryGetValue(result.ToString(), out value);
                    return new[] { value, i };
                }

                if (!hashMap.ContainsKey(nums[i].ToString()))
                {
                    hashMap.Add(nums[i].ToString(), i);
                }
            }

            return default(int[]);
        }

        [TestMethod]
        public void TestingMethodWithHashTable()
        {
            int[] resultSet2 = this.TwoSum(new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 }, 542);

            Assert.AreEqual(resultSet2[0], 0);
            Assert.AreEqual(resultSet2[1], 2);
        }

        [TestMethod]
        public void TestMethodOrderOneSpace()
        {
            // int[] array = { -8, 1, 4, 6, 10, 45 };

            int[] result = this.TwoSumByOrderOneSpace(new List<int>(new []{ 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 }), 542);

            Assert.AreEqual(6, result[0]);
            Assert.AreEqual(10, result[1]);
        }
    }
}

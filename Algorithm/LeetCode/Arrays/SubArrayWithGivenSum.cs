using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class SubArrayWithGivenSum
    {
        /// <summary>
        /// INCOMPLETE
        /// </summary>
        /// <param name="array"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public int[] GetSubArrayWithGivenSumWithNegatives(int[] array, int sum)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int currentSum = array[0];

            for(int i=0; i < array.Length; i++)
            {
                int value = currentSum - sum;
                if (!dict.ContainsKey(value))
                {
                    dict[currentSum] = i;
                }
                else
                {
                    currentSum += array[i];
                }
            }

            return null;
        }

        public int[] GetSubArrayWithGivenSum(int[] array, int sum)
        {
            int[] resultArray = new int[array.Length];
            int i = 0;
            int currentSum = array[i];
            int startIndex = i;

            for(i=1;  i < array.Length; i++)
            {
                while (currentSum > sum && startIndex < i)
                {
                    currentSum -= array[startIndex];
                    startIndex++;
                }

                if (currentSum == sum)
                {
                    Array.Copy(array, startIndex, resultArray, 0, i - startIndex);
                    return resultArray;
                }

                currentSum += array[i];
            }

            return resultArray;
        }

        [TestMethod]
        public void TestSubArrayWithGivenSum()
        {
            int[] resultArray = this.GetSubArrayWithGivenSum(new[] { 1, 4, 0, 0, 3, 10, 5 }, 7);
        }
    }
}

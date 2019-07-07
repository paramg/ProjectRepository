using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class LongestConsecutiveSequence
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array">{4,1,2,6,5}</param>
        public int LongestConsecutiveSequenceInArray(int[] array)
        {
            Dictionary<int, bool> elementsInSet = new Dictionary<int, bool>();

            for (int i=0; i < array.Length; i++)
            {
                elementsInSet[array[i]] = true;
            }

            int longest_so_far = 0;
            for (int i=0; i< array.Length; i++)
            {
                if (!elementsInSet.ContainsKey(array[i] -1))
                {
                    int counter = 1;
                    int value =  array[i];
                    while(elementsInSet.ContainsKey(value + 1))
                    {
                        counter++;
                        value = value + 1;
                    }

                    longest_so_far = Math.Max(longest_so_far, counter);
                }
            }

            return longest_so_far;
        }

        [TestMethod]
        public void TestLongestConsecutiveSequence()
        {
            int longestValue = this.LongestConsecutiveSequenceInArray(new[] { 4, 1, 6, 5, 2 });

            Assert.AreEqual(longestValue, 3);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Google.Hard
{
    [TestClass]
    public class RemoveDuplicateLetters
    {
        /// <summary>
        /// Remove the duplicate letters in string and print in lexicographical order.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveDuplicateLettersFunction(string s)
        {
            StringBuilder output = new StringBuilder();
            int[] countArray = new int[26];
            bool[] flagArray = new bool[26];

            foreach(char c in s)
            {
                int charIndex = c - 'a';
                countArray[charIndex] += 1;
            }

            foreach(char c in s)
            {
                int charIndex = c - 'a';
                countArray[charIndex]--;
                if (flagArray[charIndex]) continue;

                while(output.Length > 0 
                    && output[output.Length - 1] - 'a' > charIndex
                    && countArray[output[output.Length - 1] - 'a'] > 0)
                {
                    // remove the element from output.
                    flagArray[output[output.Length - 1] - 'a'] = false;
                    output.Remove(output.Length - 1, 1);
                }

                output.Append(c);
                flagArray[charIndex] = true;
            }

            return output.ToString();
        }

        [TestMethod]
        public void TestMethod1()
        {
            string output = this.RemoveDuplicateLettersFunction("c");

            Assert.AreEqual(output, "abc");

            output = this.RemoveDuplicateLettersFunction("cbacdcbc");

            Assert.AreEqual(output, "acdb");
        }
    }
}

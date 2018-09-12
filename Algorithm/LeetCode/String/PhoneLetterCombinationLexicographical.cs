using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.String
{
    [TestClass]
    public class PhoneLetterCombinationLexicographical
    {
        private List<string> letterList = new List<string> { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

        public IList<string> LetterCombinations(string digits)
        {
            IList<string> letterCombination = new List<string>();

            // if digits = 2
            // this.LetterCombinationHelper("23", 2, new char[2], 0, letterCombination);
            this.LetterCombinationHelper(digits, digits.Length, new char[digits.Length], 0, letterCombination);

            return letterCombination;
        }

        /// <summary>
        /// Letter combination helper for recursive calls.
        /// </summary>
        /// <param name="digits">The given digits like "23".</param>
        /// <param name="len">The length of the digits like "23" which is 2.</param>
        /// <param name="output">The output chars to be print for every iteration, like ad, ae, af.</param>
        /// <param name="count">The count that tracks the length of digits for every recursion call.</param>
        /// <param name="letterCombination">The letter combination result where intermediate results are added.</param>
        public void LetterCombinationHelper(string digits, int len, char[] output, int count, IList<string> letterCombination)
        {
            if (len == count)
            {
                // store the result, if len is equal to the count.
                letterCombination.Add(new string(output));
                System.Diagnostics.Debug.WriteLine(new string(output));
                return;
            }

            // gets the index to look up from letterList
            // if the digits = "23", then digits[0] = 2, lookup 2nd index from letterList (the phone keypad combination).
            int index = int.Parse(digits[count].ToString());

            // Loop through the letterList for the digit's index.
            // for instance: index:2 then letterList[2] = abc, in the recursion call it will fetch from letterList[3] def,
            // if count == 2 then it will print 'ad', 'ae', 'af' before going to next from the index 2 i.e. 'b'
            for (int i = 0; i < letterList[index].Length; i++)
            {
                output[count] = letterList[index][i];
                this.LetterCombinationHelper(digits, len, output, count + 1, letterCombination);
            }
        }

        [TestMethod]
        public void TestLetterCombination()
        {
            IList<string> expectedList = new List<string> { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };
            IList<string> letterCombinationList = this.LetterCombinations("23");

            Assert.AreEqual(expectedList.Count, letterCombinationList.Count);
            foreach (string expectedStr in expectedList)
            {
                Assert.IsTrue(letterCombinationList.Contains<string>(expectedStr));
            }
        }
    }
}

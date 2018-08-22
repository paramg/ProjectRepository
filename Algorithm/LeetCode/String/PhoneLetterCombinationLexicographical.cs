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
            this.LetterCombinationHelper(digits, digits.Length, new char[digits.Length], 0, letterCombination);

            return letterCombination;
        }

        public void LetterCombinationHelper(string digits, int len, char[] output, int count, IList<string> letterCombination)
        {
            if (len == count)
            {
                letterCombination.Add(new string(output));
                System.Diagnostics.Debug.WriteLine(new string(output));
                return;
            }

            int index = int.Parse(digits[count].ToString());

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

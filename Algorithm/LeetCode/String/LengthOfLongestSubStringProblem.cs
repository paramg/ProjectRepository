using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.String
{
    [TestClass]
    public class LengthOfLongestSubStringProblem
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            if (s.Length == 0) return 0;
            if (s.Length == 1) return 1;

            // store the char as key and last index of the char as value.
            Dictionary<char, int> visitedCharacters = new Dictionary<char, int>();
            int maxLength = 0;
            int currLength = 1;
            visitedCharacters[s[0]] = 0;
            int previouslyVisitedIndex = 0;

            for (int i = 1; i < s.Length; i++)
            {
                bool isVisited = visitedCharacters.ContainsKey(s[i]);
                if (isVisited)
                {
                    previouslyVisitedIndex = visitedCharacters[s[i]];
                }

                if (!isVisited ||
                    currLength < i - previouslyVisitedIndex)
                {
                    currLength += 1;
                }
                else
                {
                    currLength = i - visitedCharacters[s[i]];
                }

                visitedCharacters[s[i]] = i;

                if (maxLength < currLength)
                {
                    maxLength = currLength;
                }
            }

            return maxLength;
        }

        [TestMethod]
        public void TestingMethod_LengthOfLongestSubstring()
        {
            // Length of longest substring withour repeating.
            int length = this.LengthOfLongestSubstring("abcabcdd");

            Assert.AreEqual(4, length); // ans: abcd

            length = this.LengthOfLongestSubstring("ABDEFGABEF");

            Assert.AreEqual(6, length); // ans: BDEFGA
        }
    }
}

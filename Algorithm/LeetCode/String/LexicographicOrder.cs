using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.String
{
    [TestClass]
    public class LexicographicOrder
    {
        /// <summary>
        /// Watch this video for explanation: https://www.youtube.com/watch?v=nYFd7VHKyWQ
        /// </summary>
        /// <param name="characters"></param>
        public List<string> PrintLexicographicOrder(string characters)
        {
            Dictionary<char, int> characterMap = new Dictionary<char, int>();
            foreach(char c in characters)
            {
                if (characterMap.ContainsKey(c))
                {
                    characterMap[c] += 1;
                }
                else
                {
                    characterMap[c] = 1;
                }
            }

            var outputOrder = new List<string>();
            this.PrintLexicographicOrderHelper(characterMap.Keys.ToArray(), characterMap.Values.ToArray(),  new char[characters.Length], 0, outputOrder);

            return outputOrder;
        }

        public void PrintLexicographicOrderHelper(char[] currentCharOutput, int[] charCountArray, char[] resultArray, int level, List<string> result)
        {
            // if the count is equal to the leng of the character, then print them.
            if (level == resultArray.Length)
            {
                string resultChar = new string(resultArray);
                System.Diagnostics.Debug.WriteLine(resultChar);
                result.Add(resultChar);
                return;
            }

            for(int i=0; i < currentCharOutput.Length; i++)
            {
                if (charCountArray[i] == 0)
                {
                    continue;
                }

                resultArray[level] = currentCharOutput[i];
                charCountArray[i]--;

                this.PrintLexicographicOrderHelper(currentCharOutput, charCountArray, resultArray, level + 1, result);

                charCountArray[i]++;
            }
        }

        [TestMethod]
        public void TestMethod()
        {
            List<string> expectedOutput = new List<string> { "ABC", "ACB", "BAC", "BCA", "CAB", "CBA"};

            List <string>  actualOutput = this.PrintLexicographicOrder("ABC");

            actualOutput = this.PrintLexicographicOrder("AABC");
        }
    }
}

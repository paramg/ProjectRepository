using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.BackTrack
{
    [TestClass]
    public class BackTrackProblems
    {
        public void PrintAllCombinations(string str, int l, int r)
        {
            if (l == r)
            {
                Debug.WriteLine(str);
            }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    PrintAllCombinations(str, l + 1, r);
                    str = swap(str, l, i);
                }
            }
        }

        private string swap(string a, int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }

        [TestMethod]
        public void TestPrintAllCombinations()
        {
            this.PrintAllCombinations("ABC", 0, 2);
        }

        // eg: 123 = 123, 1+2+3, 12 + 3, 1+23 
        public void ComputeMathExpression(string input, string result, int counter)
        {
            if (input.Length == counter)
            {
                Debug.WriteLine(result);
                return;
            }
            else
            {
                this.ComputeMathExpression(input, result + input[counter], counter + 1);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    this.ComputeMathExpression(input, result + "+" + input[counter], counter + 1);
                }
            }
        }

        [TestMethod]
        public void TestComputeMathExpression()
        {
            this.ComputeMathExpression("123", string.Empty, 0);
        }
    }
}

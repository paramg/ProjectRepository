using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    [TestClass]
   public  class ZigZagDisplayCharacters
    {
        public string Convert(string s, int numRows)
        {
            if (numRows <= 1) return s;

            string result = string.Empty;
            int row = 0;
            string[] tempStr = new string[numRows];
            bool isDown = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (row == 0)
                {
                    isDown = true;
                }
                else if (row == numRows - 1)
                {
                    isDown = false;
                }

                tempStr[row] = string.Concat(tempStr[row], s[i].ToString());

                if (isDown)
                    ++row;
                else
                    --row;
            }

            for (int i = 0; i < numRows; i++)
            {
                result = string.Concat(result, tempStr[i]);
            }

            return result;
        }

        [TestMethod]
        public void TestMethod_ZigZag()
        {
            string result = this.Convert("AB", 1);

            Assert.AreEqual(result, "AB");
        }
    }
}

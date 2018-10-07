using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class Solution
    {
        public int singleNumber(List<int> A)
        {
            int result = A[0];
            int i = 1;
            while (i < A.Count)
            {
                result = result ^ A[i];
                i++;
            }

            return result;
        }

        [TestMethod]
        public void TestSinglNumber()
        {
            int result = this.singleNumber(new List<int> { 1, 2, 2, 3, 1});
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    [TestClass]
    public class ClimbingStairs
    {
        /// <summary>
        /// Returns the number of ways you can climb the stairs. 
        /// https://leetcode.com/problems/climbing-stairs/description/
        /// </summary>
        /// <param name="noOfStairs"></param>
        /// <returns></returns>
        public int ClimbingStairsMethod(int noOfStairs)
        {
            int[] dp = new int[noOfStairs + 1];

            dp[0] = 1;
            dp[1] = 1;

            for(int i=2; i<= noOfStairs; i++)
            {
                /// Each time you either climb 1 or 2 steps.
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[noOfStairs];
        }

        [TestMethod]
        public void TestMethod1()
        {
            int noOfWays = this.ClimbingStairsMethod(3);

            Assert.AreEqual(noOfWays, 3);
        }
    }
}

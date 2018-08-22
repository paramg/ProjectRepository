using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.InterviewCake
{
    [TestClass]
    public class AppStockProblem
    {
        public int FindBestStock(int[] stockPrices)
        {
            int max_Profit_sofar = int.MinValue;
            int j = 0;
            for (int i = 1; i < stockPrices.Length; i++)
            {
                if (max_Profit_sofar < stockPrices[i] - stockPrices[j])
                {
                    max_Profit_sofar = stockPrices[i] - stockPrices[j];
                }
                else
                {
                    j = i;
                }
            }

            return max_Profit_sofar;
        }

        [TestMethod]
        public void TestStockProblem()
        {
            int expectedProfit = -1;
            int bestProfit = this.FindBestStock(new[] { 9, 7, 4, 1, 6 });

            Assert.AreEqual(expectedProfit, bestProfit, "Expected and Actual are wrong!");
        }
    }
}

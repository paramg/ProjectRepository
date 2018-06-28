using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Arrays
{
    [TestClass]
    public class MinCoinChange
    { 
        public int GetCoinsForBalance(int balance, int[] coins)
        {
            int minValue = Int16.MaxValue;
            int coinCounter = 0;

            if (balance == 0) return 0;
            
            foreach(int coin in coins)
            {
                if (balance - coin >= 0)                                                                                                                                                                                                                                                                                                                                                                                                                   
                {
                    coinCounter = this.GetCoinsForBalance(balance - coin, coins);
                    if (minValue > coinCounter)
                    {
                        minValue = coinCounter; 
                    }
                }
            }
            return minValue + 1;
        }

        [TestMethod]
        public void TestMinCoinChange()
        {
            int result = this.GetCoinsForBalance(19, new []{ 10, 6, 1 });

            Assert.AreEqual(result, 4);
        }
    }
}
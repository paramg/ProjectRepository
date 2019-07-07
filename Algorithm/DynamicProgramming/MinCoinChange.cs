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
        public int GetMinCoinsForBalance(int amount, int[] coins)
        {
            // create the dp array that contains the coins for 0...amount.
            var dp = new int[amount + 1];
            
            // initialize bigger value.
            for(int i=0; i <= amount; i++)
            {
                dp[i] = amount + 1;
            }

            dp[0] = 0;
            for (int i=0;i<= amount; i++)
            {
                for (int j=0; j< coins.Length; j++)
                {
                    if (coins[j] <= i)
                    {
                        // In this case, take the min of dp[i] which is the current number of coins added so far 
                        // and dp[i - coin[j]] which is the amount added previously plus current coin (1)
                        // [For instance, if the amount is 9 and if there are coins {1,6} and j=1 then dp[9-6] = dp[3] which will be 3 + 1 (current coind which is 6) = 4].
                        // In above case, when j=0 which is coin=1 then in first attempt the dp[9] = dp[9-1] + 1 = 9. As described above, the dp[9] will be 4. 
                        dp[i] = Math.Min(dp[i], 1 + dp[i - coins[j]]);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }

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
            int result = this.GetMinCoinsForBalance(19, new []{ 1, 6, 10 });

            Assert.AreEqual(result, 4);
        }
    }
}
namespace Alogrithms.Problem.DynamicProgramming
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class KnapSackEntity
    {
        public int Weight;
        public int Value;

        public KnapSackEntity(int weight, int value)
        {
            this.Weight = weight;
            this.Value = value;
        }
    }

    [TestClass]
    public class KnapSackProblem
    {
        public int KnapSack(KnapSackEntity[] items, int i, int weight)
        {
            // Go through the end of the items.
            if (i == items.Length) return 0;

            // If the weight is not enough, exclude and move on to next item.
            if (weight -  items[i].Weight < 0)
            {
                return KnapSack(items, i + 1, weight);
            }

            // Include the item - Reduce the weight.
            int includedItemValue = KnapSack(items, i + 1, weight - items[i].Weight) + items[i].Value;

            // Exclude the item - Dont reduce the weight.
            int excludedItemValue = KnapSack(items, i + 1, weight);

            // Find the max value between included and excluded.
            int max_Value = Math.Max(includedItemValue, excludedItemValue);

            return max_Value;
        }
        [TestMethod]
        public void TestKnapSack_1()
        {
            var knapSackItems = new KnapSackEntity[] {
                new KnapSackEntity(2, 5),
                new KnapSackEntity(2, 3),
                new KnapSackEntity(3, 9)
            };

            int value = this.KnapSack(knapSackItems, 0, 5);

            Assert.AreEqual(value, 14);
        }
    }
}

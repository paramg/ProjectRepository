using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class MergeTwoSortedArray
    {
        public void MergeTwoSortedArrayHelper(int[] arrayA, int[] arrayB)
        {
            int m = arrayA.Length - 1;
            int n = arrayB.Length - 1;
            
            int counterMidA = arrayA.Length - arrayB.Length - 1;
            int counterEndA = m;
            int counterB = n;

            while (counterB >= 0 && counterMidA >= 0)
            {
                if (arrayA[counterMidA] > arrayB[counterB])
                {
                    arrayA[counterEndA] = arrayA[counterMidA];
                    counterMidA--;
                }
                else
                {
                    arrayA[counterEndA] = arrayB[counterB];
                    counterB--;
                }

                counterEndA--;
            }
        }

        [TestMethod]
        public void TestMergeTwoSortefArray()
        {
            int[] arrayA = new int[] { 1, 5, 9, 10, 15, 20, 0, 0, 0, 0 };
            int[] arrayB = new int[] { 2, 3, 8, 13};

            this.MergeTwoSortedArrayHelper(arrayA, arrayB);
        }
    }
}

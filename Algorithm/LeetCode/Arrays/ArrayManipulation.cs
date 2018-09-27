using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class ArrayManipulation
    {
        public int[] MoveZerosToRight2(int[] array)
        {
            int i = 0;
            int j = 0;

            while (i < array.Length)
            {
                if (array[i] != 0)
                {
                    if (i != j)
                        array[j] = array[i];

                    j++;
                }
                i++;
            }

            while (j < array.Length)
            {
                array[j] = 0;
                j++;
            }

            return array;
        }

        public int[] MoveZerosToRight(int[] array)
        {
            for(int i=0; i< array.Length; i++)
            {
                if (array[i] == 0)
                {
                    int j = i  + 1;
                    while (j < array.Length && array[j] == 0)
                    {
                        j++;
                    }

                    if (j >= array.Length) break;

                    // swap the current array
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            return array;
        }

        [TestMethod]
        public void TestMoveZerosToRight()
        {
            int[] resultArray = this.MoveZerosToRight(new[] { 0, 1, 2, 0, 3, 0 });
            resultArray = this.MoveZerosToRight2(new[] { 0, 1,2,0,3,0});
        }
    }
}

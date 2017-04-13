using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Arrays
{
    [TestClass]
    public class RotateArray
    {
        /// <summary>
        /// Rotate array for k times.
        /// </summary>
        /// <param name="array">Given array for rotation.</param>
        /// <param name="k">Number of times to rotate.</param>
        public void ArrayRotation(int[] array, int k)
        {
            /// For ex:
            /// array = 1,2,3,4,5,6
            /// k = 3
            /// result = 4,5,6,1,2,3

            /// space: o(1) and time: o(n) 
            /// step1: Divide into 2 - first part: 1,2,3 second part: 4,5,6
            /// step2: reverse 1st part 3,2,1 
            /// step3: reverse 2nd part: 6,5,4 {3,2,1,6,5,4}
            /// step2: reverse the whole array : {4,5,6,1,2,3}

            int length = array.Length;
            int firstPart = array.Length - k - 1;
            int secondPart = firstPart + 1;

            reverseArray(array, 0, firstPart);
            reverseArray(array, secondPart, array.Length - 1);
            reverseArray(array, 0, array.Length -1);
        }

        public void reverseArray(int[] array, int startIndex, int endIndex)
        {
            while(startIndex < endIndex)
            {
                int temp = array[startIndex];
                array[startIndex] = array[endIndex];
                array[endIndex] = temp;

                startIndex = startIndex + 1;
                endIndex = endIndex - 1;
            }
        }

        [TestMethod]
        public void TestRotateArray()
        {
            int[] array = { 1, 2, 3, 4, 5, 6 };
            int k = 3;

            this.ArrayRotation(array, k);

            int[] expectedArray = { 4,5,6,1,2,3 };

            for(int i = 0; i< expectedArray.Length - 1; i++)
            {
                Assert.AreEqual(array[i], expectedArray[i], "The expected value is invalid!");
            }
        }
    }
}

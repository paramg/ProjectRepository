using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Arrays
{
    [TestClass]
    public class ThreeSum
    {
        public ThreeSum()
        {
        }

        /// <summary>
        /// Make sure the input is sorted.
        /// Start from first index and have two pointers = start and end. 
        /// Sum = arr[i] + arr[start] + arr[end] == 0 if yes, add to the list otherwise
        /// Move the pointers - increment the start and decrement the end pointer.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<int[]> FindThreeSum(int[] input)
        {
            List<int[]> output = new List<int[]>();

            int nextIndex;
            int lastIndex;

            for(int i=0; i< input.Length -3; i++)
            {
                int value = input[i];

                nextIndex = i + 1;
                lastIndex = input.Length - 1;

                while(lastIndex > nextIndex)
                {
                    int inverseValue = input[nextIndex] + input[lastIndex] * (-1);

                    if (value < inverseValue)
                    {
                        while (input[nextIndex] != input[nextIndex + 1]);
                        {
                            nextIndex++;
                        }
                    }
                    else if (value > inverseValue)
                    {
                        lastIndex--;
                    }
                    else
                    {
                        int[] resultArray = new int[3];

                        resultArray[0] = input[i];
                        resultArray[1] = input[nextIndex];
                        resultArray[2] = input[lastIndex];

                        output.Add(resultArray);

                        break;
                    }
                }
            }

            return output;
        }

        [TestMethod]
        public void TestFindingThreeSum()
        {
            int[] input = { -1, 0, 1, 2, -1 ,-4};
            // result = {-1, -1, 2}
            //          {-1, 0, 1}


        }
    }
}

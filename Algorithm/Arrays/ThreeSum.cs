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
        /// Returns the three sum
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<int[]> FindThreeSumUsingHash(int[] input)
        {
            List<int[]> result = new List<int[]>();
            HashSet<int> hashSet = new HashSet<int>();

            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    int k = - (input[i] + input[j]);

                    if (hashSet.Contains(k))
                    {
                        int[] result1 = new int[3];

                        result1[0] = input[i];
                        result1[1] = input[j];
                        result1[2] = k;

                        result.Add(result1);
                    }
                    else
                    {
                        hashSet.Add(input[j]);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Make sure the input is sorted.
        /// Start from first index and have two pointers = start and end. 
        /// Sum = arr[i] + arr[start] + arr[end] == 0 if yes, add to the list otherwise
        /// Move the pointers - increment the start and decrement the end pointer.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public IList<IList<int>> FindThreeSum(int[] nums)
        {
            IList<IList<int>> finalResult = new List<IList<int>>();
            List<int> input = new List<int>(nums);
            input.Sort();

            for(int i=0; i< input.Count -2; i++)
            {
                int j = i + 1;
                int k = input.Count - 1;

                while( j< k)
                {
                    int intermediateResult = input[i] + input[j] + input[k];

                    // Found answer.
                    if (intermediateResult == 0)
                    {
                        List<int> answer = new List<int>();
                        answer.Add(input[i]);
                        answer.Add(input[j]);
                        answer.Add(input[k]);

                        finalResult.Add(answer.ToList());

                        j = j + 1;
                        k = k - 1;
                    }
                    else if (intermediateResult < 0)
                    {
                        j = j + 1;
                    }
                    else
                    {
                        k = k - 1;
                    }
                }
            }

            return finalResult;
        }

        [TestMethod]
        public void TestFindingThreeSum()
        {
            // int[] input = { -1, 0, 1, 2, -1 ,-4};
            // result = {-1, -1, 2}
            //          {-1, 0, 1}

            int[] expectedResult = { 0, -1, 1}; 
            int[] input = { -1, 0, 1, 2, -1, -4 };// { 0 , -1, 2, -3, 1};
            IList<IList<int>> result = this.FindThreeSum(input);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class CombinationSum
    {
        public List<int> RangeSum(int[] array, int k)
        {
            int sum = 0;
            // initialize sum from 0 through k
            for (int i=0; i< k; i++)
            {
                sum += array[i];
            }

            List<int> result_Array = new List<int>{ sum };
            for (int i=k; i< array.Length; i++)
            {
                int intermediateSum = array[i] + result_Array[i - k] - array[i - k];

                result_Array.Add(intermediateSum);
            }

            return result_Array;
        }

        public List<List<int>> combinationSum(int[] candidates, int target)
        {
            List<List<int>> result = new List<List<int>>();

            if (candidates == null || candidates.Length == 0) return result;

            List<int> current = new List<int>();
            Array.Sort(candidates);

            combinationSum(candidates, target, 0, current, result);

            return result;
        }

        public void combinationSum(int[] candidates, int target, int j, List<int> curr, List<List<int>> result)
        {
            if (target == 0)
            {
                List<int> temp = new List<int>(curr);
                result.Add(temp);
                return;
            }

            for (int i = j; i < candidates.Length; i++)
            {
                if (target < candidates[i])
                    return;

                curr.Add(candidates[i]);
                combinationSum(candidates, target - candidates[i], i, curr, result);
                curr.RemoveAt(curr.Count - 1);
            }
        }

        public void TargetSumHelper(int[] clockNumbers, int target, int targetSum, List<List<int>> result, List<int> interimResult, int baseCounter, int counter)
        {
           
        }

        public List<List<int>> TargetSum(int[] clockNumbers, int target)
        {
            List<List<int>> result = new List<List<int>>();
            int start = 0;
            while(start < clockNumbers.Length - 1)
            {
                List<int> intermediateResult = new List<int>();

                int targetSum = 0;
                for (int i=start; i< clockNumbers.Length; i++)
                {
                    intermediateResult.Add(clockNumbers[i]);
                    targetSum += clockNumbers[i];
                    if (targetSum == target)
                    {
                        List<int> foundOne = new List<int>(intermediateResult);
                        result.Add(foundOne);
                    }
                }
                start++;
            }
            return result;
        }

        [TestMethod]
        public void TestTargetClockSum()
        {
            int[] clockNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            // this.combinationSum(clockNumbers, 30);
            List<List<int>> result = this.TargetSum(clockNumbers, 31);
        }

        [TestMethod]
        public void TestRangeSum()
        {
            this.RangeSum(new[] { 1, 2, 3, 4, 5 }, 3);
        }
    }
}

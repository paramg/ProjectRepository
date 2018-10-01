using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class DuplicatesInArray
    {
        public int[] GetDuplicates(int[] array)
        {
            List<int> resultArray = new List<int>();
            for (int i=0; i< array.Length; i++)
            {
                int index = Math.Abs(array[i]) - 1;

                if (array[index] < 0)
                {
                    // already exists 
                    resultArray.Add(Math.Abs(array[index]));
                }
                else
                {
                    array[index] = -1 * array[index];
                }
            }
            return resultArray.ToArray();
        }

        [TestMethod]
        public void ValidateDuplicates()
        {
            int[] result = this.GetDuplicates(new[] { 2, 1, 2, 1});
        }
    }
}

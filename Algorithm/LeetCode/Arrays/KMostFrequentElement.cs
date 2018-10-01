using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class KMostFrequentElement
    {
        /// <summary>
        /// Store the repeated elements in dictionary with {element, frequency}
        /// Create a bucket list<list<int>> with index as frequency and add the repeated elements in array.
        /// The kth most repeated element can be scanned from the bucket from the end.
        /// </summary>
        /// <param name="array">The array elements.</param>
        /// <param name="k">The kth most repeated element.</param>
        /// <returns>Returns the repeated elements.</returns>
        public int[] GetFrequentElements(int[] array, int k)
        {
            int[] resultArray = default(int[]);
            Dictionary<int, int> frequentElements = new Dictionary<int, int>();
            List<List<int>> kthFrequentElements = new List<List<int>>(array.Length + 1);

            for(int i=0; i<= array.Length; i++)
            {
                kthFrequentElements.Add(null);
            }

            for (int i=0; i< array.Length; i++)
            {
                if (frequentElements.ContainsKey(array[i]))
                {
                    frequentElements[array[i]] += 1;
                }
                else
                {
                    frequentElements[array[i]] = 1;
                }
            }

            foreach(KeyValuePair<int, int> value in frequentElements)
            {
                List<int> list = kthFrequentElements[value.Value];
                if (list == null)
                {
                    List<int> createList = new List<int>();
                    createList.Add(value.Key);
                    kthFrequentElements[value.Value] = createList;
                }
                else
                {
                    list.Add(value.Key);
                }
            }

            int counter = kthFrequentElements.Count -1;
            int freqCounter = 1;
            while(counter>=0)
            {
                if (kthFrequentElements[counter] != null)
                {
                    if (k == freqCounter)
                    {
                        resultArray = kthFrequentElements[counter].ToArray();
                        break;
                    }

                    freqCounter ++;
                }

                counter--;
            }
            return resultArray;
        }

        [TestMethod]
        public void TestGetMostFrequentElement()
        {
            int[] result = this.GetFrequentElements(new[] { 1, 6, 2, 1, 6, 1, 6 }, 2);
        }
    }
}

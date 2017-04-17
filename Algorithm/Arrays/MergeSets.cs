using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Arrays
{
    public class Set
    {
        public int LowerBound { get; set; }

        public int UpperBound { get; set; }

        public Set(int lowerBound, int upperBound)
        {
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }
    }

    [TestClass]
    public class MergeSets
    {
        /// <summary>
        /// Assumption : The sets are in sorted list.
        /// If set1 = {{1,2},{2,3},{6,7},{7,8}}
        /// If set2 = {{3,4}, {8,9}, {11,12}}
        /// output: set1 = {{1,4}, {6,9}}
        /// output: set2 = {{11,12}}
        /// </summary>
        /// <param name="setList1"></param>
        /// <param name="setList2"></param>
        /// <returns>Returns the merged set for the given two lists of sets.</returns>
        public List<Set> PerformMergeSet(List<Set> setList1, List<Set> setList2)
        {
            List<Set> output = new List<Set>();

            int setList1Counter = 0;
            int setList2Counter = 0;

            while (setList1Counter <= setList1.Count -1 &&
                setList2Counter <= setList2.Count - 1)
            {
                while(setList1Counter <= setList1.Count - 1 &&
                        setList2Counter <= setList2.Count - 1 &&
                        setList1[setList1Counter].UpperBound <= setList2[setList2Counter].LowerBound)
                {
                    this.PerformMergeSetHelper(output, setList1[setList1Counter]);
                    setList1Counter++;
                }

                while (setList2Counter <= setList2.Count - 1 &&
                        setList1Counter <= setList1.Count - 1 &&
                        setList2[setList2Counter].UpperBound <= setList1[setList1Counter].LowerBound)
                {
                    this.PerformMergeSetHelper(output, setList2[setList2Counter]);
                    setList2Counter++;
                }
            }

            // remaining items of set1
            while (setList1Counter <= setList1.Count - 1)
            {
                this.PerformMergeSetHelper(output, setList1[setList1Counter]);
                setList1Counter++;
            }

            // remaining items of set2
            while (setList2Counter <= setList2.Count - 1)
            {
                this.PerformMergeSetHelper(output, setList2[setList2Counter]);
                setList2Counter++;
            }

            return output;
        }

        public void PerformMergeSetHelper(List<Set> output, Set set)
        {
            Set set1 = output.LastOrDefault();

            if(set1 != null && set1.UpperBound == set.LowerBound)
            {
                set1.UpperBound = set.UpperBound;
            }
            else
            {
                Set newSet = new Set(set.LowerBound, set.UpperBound);
                output.Add(newSet);
            }
        }

        [TestMethod]
        public void TestMergeSets()
        {
            List<Set> set1List = new List<Set>{ new Set(1, 2), new Set(2, 3), new Set(6, 7), new Set(7, 8), new Set(9,10) };
            List<Set> set2List = new List<Set> { new Set(3, 4), new Set(8, 9), new Set(11, 12) };

            List<Set> actualSetList = this.PerformMergeSet(set1List, set2List);

            List<Set> expectedSetList = new List<Set> { new Set(1, 4), new Set(6, 10), new Set(11, 12) };

            Assert.AreEqual(expectedSetList.Count, actualSetList.Count);

            foreach (Set expectedSet in expectedSetList)
            {
                Assert.IsTrue(actualSetList.Where((actual) => 
                    actual.LowerBound == expectedSet.LowerBound 
                    && actual.UpperBound == expectedSet.UpperBound).Any());
            }
        }
    }
}

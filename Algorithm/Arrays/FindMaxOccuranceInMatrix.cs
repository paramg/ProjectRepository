using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Arrays
{
    public class Output
    {
        public int rowNumber { get; set; }

        public int NumberOfOnes { get; set; }
    }

    [TestClass]
    public class FindMaxOccuranceInMatrix
    {
        public static Output FindMaxOccurancesOfOne(int[,] matrix)
        {
            Output output = new Output();

            int rowLen = matrix.GetLength(0);
            int colLen = matrix.GetLength(1);

            int colStart = colLen;
            int maxNumberOfOnes = 0;

            for(int row=0; row< rowLen; row++)
            {        
                for (int col = colStart -1; col >= 0; col--)
                {
                    if(matrix[row, col] == 1)
                    {
                        maxNumberOfOnes += 1;
                        colStart = col;
                    }
                    else
                    {
                        break;
                    }
                }

                if(output.NumberOfOnes < maxNumberOfOnes)
                {
                    output.NumberOfOnes = maxNumberOfOnes;
                    output.rowNumber = row;
                }
            }

            return output;
        }

        [TestMethod]
        public void TestFindMaximumOccuranceOfOne()
        {
            int[,] matrix = {
                                {0, 0, 1, 1, 1},
                                {0, 0, 0, 1, 1},
                                {1, 1, 1, 1, 1},
                                {1, 1, 1, 1, 1},
                                {0, 0, 1, 1, 1},
                            };

            Output output = FindMaxOccurancesOfOne(matrix);

            Assert.AreEqual(output.rowNumber, 2);
            Assert.AreEqual(output.NumberOfOnes, 5);
        }
    }
}

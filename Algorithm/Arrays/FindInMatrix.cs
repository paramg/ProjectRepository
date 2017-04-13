using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Arrays
{
    [TestClass]
    public class FindInSortedMatrix
    {
        /// <summary>
        /// The given matrix is sorted column from right 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        public bool FindValueInSortedMatrix(int[,] matrix, int target)
        {
            /// [
            ///     [1,   4,  7, 11, 15],
            ///     [2,   5,  8, 12, 19],
            ///     [3,   6,  9, 16, 22],
            ///     [10, 13, 14, 17, 24],
            ///     [18, 21, 23, 26, 30]
            /// ]
            
            bool isTargetFound = false;
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            // start from left bottom.
            int row = rowLength - 1;
            int col = 0;

            while(row > 0 && col < colLength)
            {
                if( matrix[row, col] > target)
                {
                    row--;
                }
                else if(matrix[row, col] < target)
                {
                    col++;
                }
                else
                {
                    isTargetFound = true;
                    break;
                }
            }

            return isTargetFound;
        }

        [TestMethod]
        public void TestFindValueInSortedMatrix()
        {
            int[,] matrix = {
                                {1,   4,  7, 11, 15},
                                {2,   5,  8, 12, 19},
                                {3,   6,  9, 16, 22},
                                {10, 13, 14, 17, 24},
                                {18, 21, 23, 26, 30}
                            };
            Assert.IsTrue(this.FindValueInSortedMatrix(matrix, 5));
            Assert.IsFalse(this.FindValueInSortedMatrix(matrix, 50));
        }
    }
}

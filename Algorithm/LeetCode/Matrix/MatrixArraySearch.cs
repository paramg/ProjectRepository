using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Matrix
{
    [TestClass]
    public class MatrixArraySearch
    {
        public bool SearchInSortedMatrix(int[,] matrix, int target)
        {
            int rowMax = matrix.GetLength(0);
            int colMax = matrix.GetLength(1);

            for (int i = 0, j = colMax - 1; j >= 0 && i < rowMax;)
            {
                if (target > matrix[i, j])
                {
                    i = i + 1;
                }
                else if (target < matrix[i, j])
                {
                    j = j - 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        [TestMethod]
        public void TestSortedMatrixSearch()
        {
            int[,] mat = {
                    { 10, 20, 30, 40},
                      { 15, 25, 35, 45},
                      { 27, 29, 37, 48},
                      { 32, 33, 39, 50}
            };

            bool result = this.SearchInSortedMatrix(mat, 10);

            Assert.IsTrue(result);
        }
    }
}

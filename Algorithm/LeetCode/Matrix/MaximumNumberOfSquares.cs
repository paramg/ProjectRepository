using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Matrix
{
    [TestClass]
    public class MaximumNumberOfSquares
    {
        public int GetMaxNumberOfSquaresInMatrix(int[,] matrix, int row, int col)
        {
            int[,] cache = new int[matrix.GetLength(0), matrix.GetLength(1)];

            // initialize the cache to -1
            for(int i=0;i<cache.GetLength(0); i++)
            {
                for (int j=0; j< cache.GetLength(1); j++)
                {
                    cache[i, j] = -1;
                }
            }

            int max_so_far = 0;

            for (int i=0; i< matrix.GetLength(0); i++)
            {
                for (int j=0; j< matrix.GetLength(1); j++)
                {
                    int value = this.GetMaxNumberOfSquaresInMatrixHelper(matrix, i, j, cache);

                    if (max_so_far < value)
                    {
                        max_so_far = value;
                    }
                }
            }

            return max_so_far;
        }

        public int GetMaxNumberOfSquaresInMatrixHelper(int[,] matrix, int row, int col, int[,] cache)
        {
            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1) || row < 0 || col < 0)
                return 0;

            if (cache[row, col] != -1)
            {
                return cache[row, col];
            }

            if (matrix[row, col] == 0) return 0;

            int value = Math.Min(
                   Math.Min(
                       this.GetMaxNumberOfSquaresInMatrixHelper(matrix, row + 1, col, cache),
                       this.GetMaxNumberOfSquaresInMatrixHelper(matrix, row, col + 1, cache)),
                   this.GetMaxNumberOfSquaresInMatrixHelper(matrix, row + 1, col + 1, cache));

            cache[row, col] = value + 1;

            return cache[row, col];
        }

        [TestMethod]
        public void TestGetMaxNumberOfSquaresInMatrix()
        {
            int[,] matrix = {  { 1, 1, 0, 1, 0 },
                                        { 0, 1, 1, 1, 0 },
                                        { 1, 1, 1, 1, 0 },
                                        { 0, 1, 1, 1, 1}
            };

            this.GetMaxNumberOfSquaresInMatrix(matrix, 0, 0);
        }
    }
}

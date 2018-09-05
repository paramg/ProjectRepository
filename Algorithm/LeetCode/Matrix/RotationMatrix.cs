using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Matrix
{
    [TestClass]
    public class RotationMatrix
    {
        /// <summary>
        /// First step: Perform the transpose of the matrix (Transpose is to convert rows to columns and columns to row).
        /// Second step: Reverse each row of the matrix.
        /// </summary>
        public void Rotate(int[,] matrix)
        {
            // Transpose
            this.Transpose(matrix);

            // Reverse rows.
            this.Reverse(matrix);
        }

        private void Transpose(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            for(int i=0; i< row; i++)
            {
                for (int j=i; j< col; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i,j] = matrix[j,i];
                    matrix[j,i] = temp;
                }
            }
        }

        private void Reverse(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            for (int i=0; i< row; i++)
            {
                for (int j=0, k = col -1; j< k; j++, k--)
                {
                    int temp = matrix[i,k];
                    matrix[i,k] = matrix[i, j];
                    matrix[i,j] = temp;
                }
            }
        }

        [TestMethod]
        public void Test90DegreeRotation()
        {
            int[,] matrix = new int[,] { { 5, 1, 9, 11 }, { 2, 4, 8, 10 }, { 13, 3, 6, 7 } , { 15, 14, 12, 16 } };

            this.Rotate(matrix);
        }
    }
}

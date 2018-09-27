using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.BackTrack
{
    [TestClass]
    public class NQueenProblem
    {
        public bool isSafe(int[] position, int target, int[,] matrix)
        {
            bool canPlace = false;
            // the same row should not be affected. 
            for (int i=0; i < position.Length; i++)
            {
                // first position
                int row = i;
                int col = position[i];

                int targetRow = target;
                canPlace = false;

                for( int j=0; j < matrix.GetLength(1); j++)
                {
                    int targetCol = j;

                    if (row == targetRow || col == targetCol   // check for same row and col
                        || row == targetRow + 1 && col == targetCol + 1 // check for diagonal
                        || (row == targetRow + 1 && col == targetCol -1) // check for upper diagonal
                        || (row == targetCol - 1 && col == targetRow + 1) // check for lower diagonal
                        || (row == targetRow - 1 && col == targetCol + 1)   // check for lower diagonal
                        || (row == targetCol + 1 && col == targetRow - 1)   // check for lower diagonal
                        )
                    {
                        canPlace = false;
                    }
                    else
                    {
                        canPlace = true;
                        break;
                    }
                }

                if (!canPlace) { break; }
            }

            return canPlace;
        }

        [TestMethod]
        public void TestMethodIsSafe()
        {
            int[] position = { 0, 2, 0, 0 };

            int[,] matrix = { { 1, 0, 0, 0 }, 
                                        { 0, 0, 1, 0 },
                                        { 0, 0, 0, 0 },
                                        { 0, 0, 0, 0 }
                                    };

            bool canPlace = this.isSafe(position, 2, matrix);
        }
    }
}

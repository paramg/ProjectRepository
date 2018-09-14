using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Matrix
{
    [TestClass]
    public class MatrixProblemsBFS
    {
        public class Point
        {
            public int x;
            public int y;
        }

        public class Result
        {
            public string color;
            public int count;

            public Result(string color)
            {
                this.color = color;
                count = 1;
            }
        }

        // define direction to go up, down, left and right
        private int[] xDir = { -1, 1, 0, 0};
        private int[] yDir = { 0, 0, -1, 1};

        public bool IsBoundary(string[,] matrix, Point index)
        {
            if (index.x < 0 || index.y < 0 || index.x >= matrix.GetLength(0) || index.y >= matrix.GetLength(1))
                return false;

            return true;
        }

        public Result MatrixFindMaxColorHelper(string[,] matrix, Point index)
        {
            Result result = new Result(matrix[index.x, index.y]);

            // walk through the matrix for the given co-ordinate starting from that char.
            // Initialize the queue with the index point and set the visited flag to true.

            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(index);

            bool[,] IsVisited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            IsVisited[index.x, index.y] = true;

            while (queue.Any())
            {
                string ch = matrix[index.x, index.y];

                Point point = queue.Dequeue();

                for (int i=0; i< 4; i++)
                {
                    int row = point.x + xDir[i];
                    int col = point.y + yDir[i];

                    if (this.IsBoundary(matrix, new Point { x = row, y = col}) 
                        && matrix[row, col] == ch 
                        && !IsVisited[row, col])
                    {
                        queue.Enqueue(new Point { x = row, y = col} );
                        result.count += 1;

                        IsVisited[row, col] = true;
                    }
                }
            }

            return result;
        }

        public Result MatrixFindMaxColor(string[,] matrix)
        {
            Result maxResult = null;
            for(int i=0; i< matrix.GetLength(0); i++)
            {
                for (int j=0; j < matrix.GetLength(1); j++)
                {
                    Result result = this.MatrixFindMaxColorHelper(matrix, new Point { x = i, y = j });

                    if (maxResult == null)
                    {
                        maxResult = result;
                    }
                    else if (maxResult.count < result.count)
                    {
                        maxResult.color = result.color;
                        maxResult.count = result.count;
                    }
                }
            }

            return maxResult;
        }

        [TestMethod]
        public void TestMatrixProblemByBFS()
        {
            string[,] matrix = {    { "r", "r", "r", "g" }, 
                                                { "g", "r", "r", "g" },
                                                { "g", "g", "r", "g"}
                                            };
                    
            Result result = this.MatrixFindMaxColor(matrix);
        }
    }
}

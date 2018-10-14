using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Problem.Library
{
    [TestClass]
    public class MazeResolver
    {
        int[,] MazeMatrix { get; }

        public MazeResolver()
        {
        }

        public MazeResolver(int[,] maze)
        {
            this.MazeMatrix = maze;
        }

        public void FileMazePath()
        {
            int[,] mazeSolution = new int[this.MazeMatrix.GetLength(0), this.MazeMatrix.GetLength(1)];

            if (SolveMaze(this.MazeMatrix, 0, 0, mazeSolution))
            {
                // print maze solution. 
                Console.WriteLine("Solution found...");

                this.PrintMaze(mazeSolution);
            }
            else
            {
                Console.WriteLine("No solution found...");
            }
        }

        private bool SolveMaze(int[,] mazeMatrix, int row, int col, int[,] mazeSolution)
        {
            if (this.IsFinished(mazeMatrix, row, col))
            {
                mazeSolution[row, col] = 1;

                return true;
            }

            if (this.IsValidMove(mazeMatrix, row, col))
            {
                mazeSolution[row, col] = 1;

                // go down
                this.SolveMaze(mazeMatrix, row + 1, col, mazeSolution);

                // go right
                this.SolveMaze(mazeMatrix, row, col + 1, mazeSolution);

                return true;
            }

            return false;
        }

        private bool IsValidMove(int[,] mazeMatrix, int row, int col)
        {
            if (row < 0 || row >= mazeMatrix.GetLength(0))
                return false;
            else if (col < 0 || col >= mazeMatrix.GetLength(1))
                return false;
            else if (mazeMatrix[row,col] != 1)
                return false;
                    
            return true;
        }

        private bool IsFinished(int[,] mazeMatrix, int row, int col)
        {
            if(row == mazeMatrix.GetLength(0) -1 && col == mazeMatrix.GetLength(1) -1)
            {
                return true;
            }

            return false;
        }

        private void PrintMaze(int[,] solutionMatrix)
        {
            for(int i=0; i< solutionMatrix.GetLength(0); i++)
            {
                for(int j=0; j < solutionMatrix.GetLength(1); j++)
                {
                    Console.Write(solutionMatrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        [TestMethod]
        public void TestFindPathInMaze()
        {
            int[,] mazeMatrix = {   
                                    { 1, 0, 0 }, 
                                    { 1, 0, 0 }, 
                                    { 1, 1, 1 },
                                    { 0, 0, 1 },
                                    { 1, 1, 1 }
                                };

            MazeResolver mazeResolver = new MazeResolver(mazeMatrix);
            mazeResolver.FileMazePath();
        }
    }
}

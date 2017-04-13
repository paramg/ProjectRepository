using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Arrays
{
    [TestClass]
    public class SpiralOrderArray
    {
        public ArrayList PrintSpiralOrderArray(int[,] inputArray)
        {
            /// Input:
            /// [   
            ///     {1,2,3},
            ///     {4,5,6},
            ///     {7,8,9} 
            /// ]
            /// Output: 1,2,3,6,9,8,7,4,5

            int row = 0; int col = 0;
            ArrayList output = new ArrayList();

            int rowLength = inputArray.GetLength(0);
            int colLength = inputArray.GetLength(1);

            while( rowLength > 0 && colLength > 0)
            {
                // row length = 1
                if (rowLength == 1)
                {
                    for(int i=0; i < colLength -1; i++)
                    {
                        output.Add(inputArray[row, col++]);
                    }

                    break;
                }
                // col length = 1
                else if (colLength == 1)
                {
                    for (int i = 0; i < rowLength - 1; i++)
                    {
                        output.Add(inputArray[row++, col]);
                    }

                    break;
                }

                // move left to right
                for (int i=0; i< colLength-1; i++)
                {
                    output.Add(inputArray[row, col]);
                    col = col + 1;
                }

                // move right to down
                for(int i=0;i < rowLength -1; i++)
                {
                    output.Add(inputArray[row, col]);
                    row = row + 1;
                }

                // move right to left
                for(int i=0; i< colLength - 1; i++)
                {
                    output.Add(inputArray[row, col]);
                    col = col - 1;
                }

                // move from down to top
                for(int i = 0; i < rowLength -1; i++)
                {
                    output.Add(inputArray[row, col]);
                    row = row - 1;
                }

                rowLength = rowLength - 2;
                colLength = colLength - 2;

                row = row + 1;
                col = col + 1;
            }

            return output;
        }

        [TestMethod]
        public void TestPrintSpiralArray()
        {
            int[,] inputArray = {   { 1, 2, 3 }, 
                                    { 4, 5, 6 }, 
                                    { 7, 8, 9 },
                                    { 10,11,12}
                                };
            ArrayList expectedArray = new ArrayList{ 1,2,3,6,9,12,11,10,7,4,5,8 };
            ArrayList output = this.PrintSpiralOrderArray(inputArray);

            for (int i = 0; i < expectedArray.Count; i++)
            {
                Assert.AreEqual(expectedArray[i], output[i]);
            }
        }
    }
}

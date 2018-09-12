using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Matrix
{
    [TestClass]
    public class WordSearchProblem
    {
        private int[] rowDir = { -1, -1, -1, 0, 0, 1, 1, 1};
        private int[] colDir =   { -1, 0, 1, -1, 1, -1, 0, 1 };

        public bool WordSearchHelper(char[,] matrix, string word, int row, int col)
        {
            if (matrix[row, col] != word[0])
                return false;

            for(int i=0; i < 8; i++)
            {
                int rowd = row + rowDir[i];
                int cold = col + colDir[i];
                int k = 1;

                for (; k < word.Length; k++)
                {
                    // checking for boundaries.
                    if (rowd < 0 || cold < 0 || rowd >= matrix.GetLength(0) || cold >= matrix.GetLength(1))
                    {
                        break;
                    }

                    if (matrix[rowd,cold] != word[k])
                    {
                        break;
                    }

                    // This is important, to make it go in specific direction (top or bottom or left or right or diagonal)
                    rowd += rowDir[i];
                    cold += colDir[i];
                }

                if ( k == word.Length)
                {
                    return true;
                }
            }

            return false;
        }

        public void WordSearchSpecifcDirection(char[,] matrix, string word)
        {
            for( int i=0; i < matrix.GetLength(0); i++)
            {
                for (int j=0; j < matrix.GetLength(1); j++)
                {
                    if (this.WordSearchHelper(matrix, word, i, j))
                    {
                        Debug.WriteLine(string.Format("The word {0}: appeared at the index row: {1} col:{2}", word, i, j));
                    }
                }
            }
        }

        public bool WordSearchZigZagHelper(char[,] matrix, string word, int row, int col, bool[,] visitedArray, int wordCount, string wordStr)
        {
            if (wordStr == word)
            {
                Debug.WriteLine(word);
                return true;
            }

            visitedArray[row, col] = true;

            for (int i = 0; i < 8; i++)
            {
                int rowd = row + rowDir[i];
                int cold = col + colDir[i];

                if (!(rowd < 0 || cold < 0 || rowd >= matrix.GetLength(0) || cold >= matrix.GetLength(1)) // check for boundaries. 
                    && matrix[rowd, cold] == word[wordCount] // check for char that matches 
                    && !visitedArray[rowd, cold])  // check if it's already visited previously. 
                {
                    return this.WordSearchZigZagHelper(matrix, word, rowd, cold, visitedArray,  wordCount + 1, wordStr + matrix[rowd, cold]);
                }
            }

            visitedArray[row, col] = false;

            return false;
        }

        public bool Exist(char[,] board, string word)
        {
            bool[,] visitedArray = new bool[board.GetLength(0), board.GetLength(1)]; 
            for(int i=0; i< board.GetLength(0); i++)
            {
                for (int j=0; j< board.GetLength(1); j++)
                {
                    if (board[i,j] == word[0])
                    {
                        bool result = this.WordSearchZigZagHelper(board, word, i, j, visitedArray, 1, word[0].ToString());

                        if (result) return true;
                    }
                }
            }

            return false;
        }

        [TestMethod]
        public void TestWordSearch()
        {
            char[,] matrix = {  { 'c', 'a', 't', 'c', 'a', 't'}, 
                                            { 'a', 'a', 'a', 'o', 'o', 's'}, 
                                            { 'p', 'a', 't', 'w', 'a', 's'}
                                        };

            // We can find words like cat, cap, tap, pat, was, tow, cow
            // We should also find the repetition, but dont go in zig-zag only 8 direction 
            // (left, right, top, bottom, diagonal (rightdown), (rightup), (leftup), (leftdown)

            this.WordSearchSpecifcDirection(matrix, "tac");
        }

        [TestMethod]
        public void TestWordSearchZigZag()
        {
            char[,] matrix = { { 'A', 'B', 'C', 'S'}, { 'S', 'F', 'C', 'S' }, { 'A', 'D', 'E', 'F' } };

            Assert.IsTrue(this.Exist(matrix, "ABCCED"));
            Assert.IsTrue(this.Exist(matrix, "SFE"));
            Assert.IsFalse(this.Exist(matrix, "ABCB"));
        }
    }
}

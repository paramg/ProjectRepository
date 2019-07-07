using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.BackTrack
{
    [TestClass]
    public class Solution
    {
        public IList<string> FindWords(char[][] board, string[] words)
        {
            var list = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                if (IsWordExists(words[i], board))
                {
                    list.Add(words[i]);
                }
            }

            return list;
        }

        private bool IsWordExists(string word, char[][] board)
        {
            int index = 0;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.GetLength(i); j++)
                {
                    return IsWordExistsHelper(word, board, i, j, index);
                }
            }

            return false;
        }

        private bool IsWordExistsHelper(string word, char[][] board, int i, int j, int index)
        {
            if (index == word.Length)
            {
                return true;
            }

            if (i < 0 || i >= board.Length -1 || j < 0 || j >= board[i].Length - 1 || board[i][j] != word[index])
            {
                return false;
            }

            char temp = board[i][j];
            board[i][j] = ' ';
            index = index + 1;
            bool found = IsWordExistsHelper(word, board, i + 1, j, index) ||
                IsWordExistsHelper(word, board, i - 1, j, index) ||
                IsWordExistsHelper(word, board, i, j + 1, index) ||
                IsWordExistsHelper(word, board, i, j - 1, index);

            board[i][j] = temp;
            return found;
        }

        [TestMethod]
        public void TestMethod()
        {
            char[][] board   = {  new char[]{ 'o', 'a', 'a', 'n' },
                                           new char[] { 'e', 't', 'a', 'e' },
                                           new char[]{ 'i', 'h', 'k', 'r' },
                                           new char[]{ 'i', 'f', 'l', 'v' }
                                        };

            string[] words = { "oath", "pea", "eat", "rain" };
            var listWords = this.FindWords(board, words);
        }
    }
}

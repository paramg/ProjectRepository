using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Tries
{
    public static class Arrays
    {
        public static List<T> AsList<T>(params T[] source)
        {
            return source.ToList();
        }
    }

    public class PalTrieNode
    {
        public PalTrieNode[] next;
        public int index;
        public List<int> list;

        public PalTrieNode()
        {
            next = new PalTrieNode[26];
            index = -1;
            list = new List<int>();
        }
    }

    [TestClass]
    public class PalindromePairsUsingTries
    {
        public List<List<int>> palindromePairs(String[] words)
        {
            List<List<int>> res = new List<List<int>>();

            PalTrieNode root = new PalTrieNode();

            for (int i = 0; i < words.Length; i++)
            {
                addWord(root, words[i], i);
            }

            for (int i = 0; i < words.Length; i++)
            {
                search(words, i, root, res);
            }

            return res;
        }

        private void addWord(PalTrieNode root, String word, int index)
        {
            for (int i = word.Length - 1; i >= 0; i--)
            {
                int j = word[i] - 'a';

                if (root.next[j] == null)
                {
                    root.next[j] = new PalTrieNode();
                }

                if (isPalindrome(word, 0, i))
                {
                    root.list.Add(index);
                }

                root = root.next[j];
            }

            root.list.Add(index);
            root.index = index;
        }

        private void search(String[] words, int i, PalTrieNode root, List<List<int>> res)
        {
            for (int j = 0; j < words[i].Length; j++)
            {
                if (root.index >= 0 && root.index != i && isPalindrome(words[i], j, words[i].Length - 1))
                {
                    res.Add(Arrays.AsList(i, root.index));
                }

                root = root.next[words[i][j] - 'a'];
                if (root == null) return;
            }

            foreach (int j in root.list)
            {
                if (i == j) continue;
                res.Add(Arrays.AsList(i, j));
            }
        }

        private bool isPalindrome(String word, int i, int j)
        {
            while (i < j)
            {
                if (word[i++] != word[j--]) return false;
            }

            return true;
        }
        
        [TestMethod]
        public void TestMethod()
        {
            PalindromePairsUsingTries pp = new PalindromePairsUsingTries();
            var list =  pp.palindromePairs(new[] { "geekf", "keeg", "abc", "xyxcba" });
            //var list = pp.palindromePairs(new[] { "geekf", "keeg" });
        }
    }
}

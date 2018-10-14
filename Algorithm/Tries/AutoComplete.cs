using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Tries
{
    [TestClass]
    public class AutoComplete
    {
        TrieOperation trieOperation = new TrieOperation();

        public List<string> AutoCompleteUsingTries(TrieNode root, string prefix)
        {
            if (root == null) return null;

            TrieNode node = root;

            for(int i=0; i< prefix.Length; i++)
            {
                int index = prefix[i] - 'a';

                if (node != null && node.Children[index] != null)
                {
                    node = node.Children[index];
                }
            }

            // node is current at the end of the prefix
            // fetch all the strings starting from the current node.

            List<string> list = new List<string>();
            this.AutoCompleteHelper(node, prefix, list);

            return list;
        }

        public void AutoCompleteHelper(TrieNode node, string actualString, List<string> list)
        {
            // end of the word
            if (node != null && node.isWordEnd)
            {
                list.Add(actualString);
            }

            if (!trieOperation.HasChildNodes(node)) return;

            for(int i= 0; i< node.Children.Length; i++)
            {
                if (node != null && node.Children[i] != null)
                {
                    int charEq = i + 'a';
                    actualString += (char)charEq;
                    this.AutoCompleteHelper(node.Children[i], actualString, list);
                }
            }
        }

        [TestMethod]
        public void TestAutoCompleteFeature()
        {
            TrieNode root = new TrieNode();
            trieOperation.Insert(root, "abc");
            trieOperation.Insert(root, "abcd");
            trieOperation.Insert(root, "abbbaba");

            List<string> listOfString = this.AutoCompleteUsingTries(root, "ab");

            Assert.IsTrue(listOfString.Contains("abbbaba"));
            // output coming as abbc, abbcd
            // Assert.IsTrue(listOfString.Contains("abc"));
            // Assert.IsTrue(listOfString.Contains("abcd"));
        }
    }
}

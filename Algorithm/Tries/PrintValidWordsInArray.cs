using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Tries
{
    [TestClass]
    public class PrintValidWordsInArray
    {
        TrieOperation trieOperation = new TrieOperation();

        public List<string> PrintValidWords(TrieNode root, string[] array)
        {
            return null;
        }

        [TestMethod]
        public void TestPrintValidWords()
        {
            TrieNode root = new TrieNode();
            string[] array = { "e", "o", "b", "a", "m", "g", "l"};

            // populate dictionary
            trieOperation.Insert(root, "go");
            trieOperation.Insert(root, "goal");
            trieOperation.Insert(root, "me");
            trieOperation.Insert(root, "eat");
            trieOperation.Insert(root, "boy");
            trieOperation.Insert(root, "run");

            List<string> listStr = this.PrintValidWords(root, array);

            Assert.IsTrue(listStr.Contains("go"));
            Assert.IsTrue(listStr.Contains("goal"));
            Assert.IsTrue(listStr.Contains("me"));

            // can it be printed ???
            Assert.IsTrue(listStr.Contains("bo"));
            Assert.IsTrue(listStr.Contains("boal"));
        }
    }
}

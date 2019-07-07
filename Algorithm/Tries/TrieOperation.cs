using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Tries
{
    public class TrieNode
    {
        private int SIZE = 26;

        public TrieNode[] Children;
        public bool isWordEnd;

        public TrieNode()
        {
            this.Children = new TrieNode[SIZE];
            this.isWordEnd = false;
        }
    }

    [TestClass]
    public class TrieOperation
    {
        public void Insert(TrieNode root, string value)
        {
            TrieNode node = root;
            for(int i=0;i < value.Length; i++)
            {
                int index = value[i] - 'a';

                if (node != null && node.Children[index] == null)
                {
                    node.Children[index] = new TrieNode();
                }
                node = node.Children[index];
            }
            node.isWordEnd = true;
        }

        public void Delete(TrieNode root, string value)
        {
            this.DeleteHelper(root, value, 0);
        }

        public void DeleteHelper(TrieNode root, string value, int position)
        {
            if (root == null) return;

            if (root.isWordEnd && position == value.Length)
            {
                return;
            }

            int index = value[position] - 'a';

            if (root.Children[index] != null)
            {
                this.DeleteHelper(root.Children[index], value, position + 1);

                if (root != null)
                {
                    int index1 = value[position] - 'a';

                    TrieNode child = root.Children[index1];
                    if (!this.HasChildNodes(child))
                    {
                        // dont delete if it's the end of some other word.
                        // but delete if it's the end of the current string.
                        // the position will be equal to the value.Length - 1 if it's the end of current string (when using recursion the postion will be value of the last char in the string)
                        if (child.isWordEnd && position == value.Length - 1)
                        {
                            root.Children[index1] = null;
                        }
                    }
                }
            }
        }

        public bool HasChildNodes(TrieNode node)
        {
            for(int i=0; i< node.Children.Length;i++)
            {
                if (node.Children[i] != null)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Search(TrieNode root, string value)
        {
            TrieNode node = root;
            for(int i=0; i< value.Length; i++)
            {
                int index = value[i] - 'a';

                if (node.Children[index] == null)
                {
                    return false;
                }

                node = node.Children[index];
            }

            return node != null && node.isWordEnd;
        }

        [TestMethod]
        public void TestTrieInsert()
        {
            // create root node.
            TrieNode root = new TrieNode();

            // insert the strings as dictionary
            TrieOperation operation = new TrieOperation();
            operation.Insert(root, "abc");
            operation.Insert(root, "abcd");
            operation.Insert(root, "aa");
            operation.Insert(root, "abbbaba");

            // assert for search operation
            Assert.IsTrue(operation.Search(root, "abc"));
            Assert.IsTrue(operation.Search(root, "abcd"));
            Assert.IsTrue(operation.Search(root, "abbbaba"));
            Assert.IsFalse(operation.Search(root, "abb"));

            // delete abc from Trie node
            operation.Delete(root, "abcd");

            // assert for search operation.
            Assert.IsFalse(operation.Search(root, "abcd"));
            Assert.IsTrue(operation.Search(root, "abc"));
            Assert.IsTrue(operation.Search(root, "abbbaba"));
        }
    }
}

using DataStructures.Libraries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.BinaryTree.BinaryTreeView
{
    public class BinaryTreeNodeEx
    {
        public BinaryTreeNode treeNode;
        public int position;
    }

    [TestClass]
    public class BinaryTreeRightView
    {
        public void PrintRightViewOfTree(BinaryTreeNode treeNode)
        {
            var queueBinaryTree = new Queue<BinaryTreeNode>();

            queueBinaryTree.Enqueue(treeNode);
            queueBinaryTree.Enqueue(null);

            while (queueBinaryTree.Any())
            {
                BinaryTreeNode node = queueBinaryTree.Dequeue();

                if (node == null && queueBinaryTree.Peek() != null)
                {
                    Console.WriteLine(queueBinaryTree.Peek());
                    queueBinaryTree.Enqueue(null);
                }
                else
                {
                    if (node.Right != null)
                        queueBinaryTree.Enqueue(node.Right);

                    if (node.Left != null)
                        queueBinaryTree.Enqueue(node.Left);
                }
            }
        }

        public void PrintTopViewOfTree(BinaryTreeNodeEx treeNode)
        {
            Dictionary<int, BinaryTreeNodeEx> dictionary = new Dictionary<int, BinaryTreeNodeEx>();
            var queueBinaryTree = new Queue<BinaryTreeNodeEx>();

            queueBinaryTree.Enqueue(treeNode);
            dictionary.Add(0, treeNode);

            while (queueBinaryTree.Any())
            {
                BinaryTreeNodeEx node = queueBinaryTree.Dequeue();
                int leftPosition = node.position - 1;
                int rightPosition = node.position + 1;

                dictionary.Add(leftPosition, node);
            }
        }

        [TestMethod]
        public void ValidateTreeSpiralOrder()
        {
            var binarySearchTree = new BinarySearchTree();
            binarySearchTree.PopulateDefaultBalanceTree();

            int[] rightView = { 20, 30, 10, 5, 12, 25, 35 };

            var spiralOrder = new BinaryTreeRightView();

            spiralOrder.PrintRightViewOfTree(binarySearchTree.Root);
        }
    }
}
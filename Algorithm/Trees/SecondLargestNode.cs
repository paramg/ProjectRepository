using DataStructures.Libraries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Trees
{
    [TestClass]
    public class SecondLargestNode
    {
        public BinaryTreeNode FindSecondLargestNode(BinaryTreeNode root)
        {
            return null;
        }

        public double FindRightMostNode(BinaryTreeNode currentNode)
        {
            if (currentNode.Right != null)
            {
                return this.FindRightMostNode(currentNode.Right);
            }

            return currentNode.Value;
        }

        [TestMethod]
        public void TestSecondLargetsNode()
        {
            BinaryTreeNode root = new BinaryTreeNode(5);
            root.Left = new BinaryTreeNode(3);
            root.Right = new BinaryTreeNode(8);

            root.Left.Left = new BinaryTreeNode(1);
            root.Left.Right = new BinaryTreeNode(4);

            root.Right.Left = new BinaryTreeNode(7);
            root.Right.Right = new BinaryTreeNode(9);
            root.Right.Right.Right = new BinaryTreeNode(12);

            double largest = this.FindRightMostNode(root);
        }
    }
}

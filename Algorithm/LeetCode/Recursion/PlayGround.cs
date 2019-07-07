using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Libraries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Recursion
{
    [TestClass]
    public class PlayGround
    {
        public double FindSumOfParentOfXValueInTree(BinaryTreeNode binaryTree, int x)
        {
            List<double> list = new List<double>();
            this.SumParentOfXRecursive(binaryTree, null, x, list);

            return list.Sum();
        }

        private void SumParentOfXRecursive(BinaryTreeNode binaryTree, BinaryTreeNode parent, int x, List<double> parentList)
        {
            if (binaryTree == null) return;

            if (binaryTree.Value == x)
            {
                parentList.Add(parent.Value);
            }

            SumParentOfXRecursive(binaryTree.Left, binaryTree, x, parentList);
            SumParentOfXRecursive(binaryTree.Right, binaryTree, x, parentList);
        }

        [TestMethod]
        public void TestSumParentOfXRecursive()
        {
            BinaryTreeNode node = new BinaryTreeNode(4);
            node.Left = new BinaryTreeNode(2);
            node.Left.Left = new BinaryTreeNode(7);
            node.Left.Right = new BinaryTreeNode(2);

            node.Right = new BinaryTreeNode(5);
            node.Right.Left = new BinaryTreeNode(2);
            node.Right.Right = new BinaryTreeNode(3);

            double answer = this.FindSumOfParentOfXValueInTree(node, 2);

            Assert.AreEqual(answer, 11);
        }

        // find cheeze in the maze
        public bool Recurse(int[,] maze)
        {
            return true;
        }

        public void TestRecurse()
        {

        }
    }
}

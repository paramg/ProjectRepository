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
    public class BinaryTreeIsABST
    {
        public class BinaryTreeChecker
        {
            public BinaryTreeNode BinaryTree { get; set; }
            public int lowerBound { get; set; }
            public int upperBound { get; set; }

            public BinaryTreeChecker(BinaryTreeNode binaryTreeNode, int lowerBound, int upperBound)
            {
                this.lowerBound = lowerBound;
                this.upperBound = upperBound;
                this.BinaryTree = binaryTreeNode;
            }
        }

        public bool IsBinaryTreeABST(BinaryTreeNode root)
        {
            Stack<BinaryTreeChecker> bstChecker = new Stack<BinaryTreeChecker>();

            bstChecker.Push(new BinaryTreeChecker(root, int.MinValue, int.MaxValue));

            while(bstChecker.Any())
            {
                BinaryTreeChecker rangeChecker = bstChecker.Pop();

                if (rangeChecker.BinaryTree != null 
                    && (rangeChecker.BinaryTree.Value < rangeChecker.lowerBound || rangeChecker.BinaryTree.Value > rangeChecker.upperBound))
                {
                    return false;
                }

                if (rangeChecker.BinaryTree != null && rangeChecker.BinaryTree.Right != null)
                {
                    BinaryTreeChecker rightRangeNode = new BinaryTreeChecker(rangeChecker.BinaryTree.Right, rangeChecker.BinaryTree.Value, rangeChecker.upperBound);
                    bstChecker.Push(rightRangeNode);
                }

                if (rangeChecker.BinaryTree != null && rangeChecker.BinaryTree.Left != null)
                {
                    BinaryTreeChecker leftRangeNode = new BinaryTreeChecker(rangeChecker.BinaryTree.Left, rangeChecker.lowerBound, rangeChecker.BinaryTree.Value);
                    bstChecker.Push(leftRangeNode);
                }
            }

            return true;
        }

        [TestMethod]
        public void TestIsBinaryTreeABST()
        {
            BinaryTreeNode root = new BinaryTreeNode(10);
            root.Left = new BinaryTreeNode(0);
            root.Right = new BinaryTreeNode(25);

            root.Left.Left = new BinaryTreeNode(-1);
            root.Left.Right = new BinaryTreeNode(9);

            root.Right.Left = new BinaryTreeNode(16);
            root.Right.Right = new BinaryTreeNode(32);

            bool result = this.IsBinaryTreeABST(root);
        }
    }
}

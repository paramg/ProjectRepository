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
            public double lowerBound { get; set; }
            public double upperBound { get; set; }

            public BinaryTreeChecker(BinaryTreeNode binaryTreeNode, double lowerBound, double upperBound)
            {
                this.lowerBound = lowerBound;
                this.upperBound = upperBound;
                this.BinaryTree = binaryTreeNode;
            }
        }

        public bool IsBinaryTreeABSTRecursion(BinaryTreeNode root)
        {
            return this.IsBinaryTreeABSTRecursionHelper(new BinaryTreeChecker(root, int.MinValue, int.MaxValue));
        }

        public bool IsBinaryTreeABSTRecursionHelper(BinaryTreeChecker root)
        {
            if (root == null || root.BinaryTree == null) return true;

            if (root != null 
                && root.BinaryTree != null 
                && (root.BinaryTree.Value < root.lowerBound || root.BinaryTree.Value > root.upperBound))
            {
                return false;
            }

            bool isLeftTree = this.IsBinaryTreeABSTRecursionHelper(new BinaryTreeChecker(root.BinaryTree.Left, root.lowerBound, root.BinaryTree.Value));
            bool isRightTree = this.IsBinaryTreeABSTRecursionHelper(new BinaryTreeChecker(root.BinaryTree.Right, root.BinaryTree.Value, root.lowerBound));

            return isLeftTree && isRightTree;
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

        [TestMethod]
        public void TestIsBinaryTreeABSTUsingRecursion()
        {
            BinaryTreeNode root = new BinaryTreeNode(10);
            root.Left = new BinaryTreeNode(0);
            root.Right = new BinaryTreeNode(25);

            root.Left.Left = new BinaryTreeNode(-1);
            root.Left.Right = new BinaryTreeNode(9);

            root.Right.Left = new BinaryTreeNode(16);
            root.Right.Right = new BinaryTreeNode(32);

            bool result = this.IsBinaryTreeABSTRecursion(root);
        }
    }
}

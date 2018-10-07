using DataStructures.Libraries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.BinaryTree
{
    /// <summary>
    /// INCOMPLETE!!!!!!!!!!!!!!!   
    /// </summary>
    [TestClass]
    public class MaxDifferenceForNodeAndAncestor
    {
        public void MaxDiffBetweenNodeAndAncestor(BinaryTreeNode root)
        {

        }

        public double GetMinFromSubTree(BinaryTreeNode node, double minValue)
        {
            if (node == null) return minValue;

            minValue = Math.Min(node.Value, minValue);

            minValue = this.GetMinFromSubTree(node.Left, minValue);
            minValue = this.GetMinFromSubTree(node.Right, minValue);

            return minValue;
        }

        [TestMethod]
        public void TestIsBinaryTreeABST()
        {
            BinaryTreeNode root = new BinaryTreeNode(8);
            root.Left = new BinaryTreeNode(3);
            root.Right = new BinaryTreeNode(10);

            root.Left.Left = new BinaryTreeNode(1);
            root.Left.Right = new BinaryTreeNode(6);

            root.Right.Right = new BinaryTreeNode(14);

            root.Left.Right.Left = new BinaryTreeNode(4);
            root.Left.Right.Right = new BinaryTreeNode(7);

            root.Right.Right.Left = new BinaryTreeNode(13);

            double result = this.GetMinFromSubTree(root.Left, double.MaxValue);
        }
    }
}

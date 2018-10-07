using DataStructures.Libraries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.BinaryTree
{
    [TestClass]
    public class PrintCommonPath
    {
        public void PrintCommonNodes()
        {
            // Find LCA of two nodes.

            // Get all the ancestors till the given node
        }

        public void PrintAllAncestors(BinaryTreeNode root, BinaryTreeNode node, List<double> tempValues, List<double> result)
        {
            if (root == null) return;

            tempValues.Add(root.Value);
            if (root.Value == node.Value)
            {
                // print the nodes
                for(int i=0;i<tempValues.Count -1; i++)
                {
                    result.Add(tempValues[i]);
                    System.Diagnostics.Debug.WriteLine(tempValues[i]);
                }
                result.Reverse();
            }

            this.PrintAllAncestors(root.Left, node, tempValues, result);
            this.PrintAllAncestors(root.Right, node, tempValues, result);
        }

        [TestMethod]
        public void TestPrintAllAncestors()
        {
            BinaryTreeNode root = new BinaryTreeNode(1);
            root.Left = new BinaryTreeNode(2);
            root.Right = new BinaryTreeNode(3);

            root.Left.Left = new BinaryTreeNode(4);
            root.Left.Right = new BinaryTreeNode(5);

            root.Left.Left.Left = new BinaryTreeNode(7);

            BinaryTreeNode node = root.Left.Left.Left;
            var values = new List<double>();
            List<double> result = new List<double>();
             this.PrintAllAncestors(root, node, values, result);
        }
    }
}

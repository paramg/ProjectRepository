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
    public class PathRootToLeaf
    {
        public PathRootToLeaf()
        {
        }

        public bool PathToSpecificNode(BinaryTreeNode root, BinaryTreeNode node, List<double> array)
        {
            if (root == null) return false;

            if (root == node)
            {
                array.Add(root.Value);
                return true;
            }

            if (this.PathToSpecificNode(root.Left, node, array) || 
                this.PathToSpecificNode(root.Right, node, array))
            {
                array.Add(root.Value);
                return true;
            }

            return false;
        }

        public void PathRootToLeafImpl(BinaryTreeNode root)
        {
            double[] path = new double[100];

            this.PathRootToLeafImpl(root, 0, path);
        }

        public void PathRootToLeafImpl(BinaryTreeNode root, int counter, double[] path)
        {
            if (root == null) return;

            path[counter++] = root.Value;

            // Leaf node
            if (root.Left == null && root.Right == null)
            {
                for (int i = 0; i < counter; i++)
                {
                    Console.Write(path[i] + " ");
                }

                Console.WriteLine();
            }
            else
            {
                PathRootToLeafImpl(root.Left, counter, path);
                PathRootToLeafImpl(root.Right, counter, path);
            }
        }

        [TestMethod]
        public void ValidateTreePathToLeaf()
        {
            var binarySearchTree = new BinarySearchTree();
            binarySearchTree.PopulateDefaultBalanceTree();

            var pathRootToLeaf = new PathRootToLeaf();

            pathRootToLeaf.PathRootToLeafImpl(binarySearchTree.Root);
        }

        [TestMethod]
        public void TestPathToSpecificNode()
        {
            BinaryTreeNode root = new BinaryTreeNode(5);
            root.Left = new BinaryTreeNode(10);
            root.Right = new BinaryTreeNode(15);

            root.Left.Left = new BinaryTreeNode(20);
            root.Left.Right = new BinaryTreeNode(25);

            root.Right.Left = new BinaryTreeNode(30);
            root.Right.Right = new BinaryTreeNode(35);

            root.Left.Right.Right = new BinaryTreeNode(45);

            BinaryTreeNode node = root.Left.Right.Right;

            List<double> array = new List<double>();

            this.PathToSpecificNode(root, node, array);
        }
    }
}

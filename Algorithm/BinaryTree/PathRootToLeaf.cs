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
        BinaryTreeNode Root { get; }

        public PathRootToLeaf()
        {
        }

        public PathRootToLeaf(BinaryTreeNode root)
        {
            this.Root = root;
        }

        public void PathRootToLeafImpl()
        {
            int[] path = new int[100];

            this.PathRootToLeafImpl(this.Root, 0, path);
        }

        public void PathRootToLeafImpl(BinaryTreeNode root, int counter, int[] path)
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

            var pathRootToLeaf = new PathRootToLeaf(binarySearchTree.Root);

            pathRootToLeaf.PathRootToLeafImpl();
        }
    }
}

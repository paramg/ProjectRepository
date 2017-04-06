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
    public class LowestCommonAncestor
    {
        BinaryTreeNode Root { get; }

        public LowestCommonAncestor()
        {
        }

        public LowestCommonAncestor(BinaryTreeNode root)
        {
            this.Root = root;
        }

        public BinaryTreeNode FindLowestCommonAncestor(BinaryTreeNode node1, BinaryTreeNode node2)
        {
            return this.FindLowestCommonAncestor(this.Root, node1, node2);
        }

        public BinaryTreeNode FindLowestCommonAncestor(BinaryTreeNode root, BinaryTreeNode node1, BinaryTreeNode node2)
        {
            if(node1 == null) throw new ArgumentNullException("node1");
            if(node2 == null) throw new ArgumentNullException("node2");

            if (root == null)
            {
                return null;
            }

            if (root.Value == node1.Value || root.Value == node2.Value)
            {
                return root;
            }

            BinaryTreeNode leftNode = FindLowestCommonAncestor(root.Left, node1, node2);
            BinaryTreeNode rightNode = FindLowestCommonAncestor(root.Right, node1, node2);

            if (leftNode != null && rightNode != null)
            {
                return root;
            }

            return leftNode != null ? leftNode : rightNode;
        }

        [TestMethod]
        public void ValidateTreeSpiralOrder()
        {
            var binarySearchTree = new BinarySearchTree();
            binarySearchTree.PopulateDefaultBalanceTree();

            LowestCommonAncestor lowestCommonAncestor = new LowestCommonAncestor(binarySearchTree.Root);

            // Lowest common ancestor for 10 & 30 is 20
            BinaryTreeNode lcaNode1 = lowestCommonAncestor.FindLowestCommonAncestor(new BinaryTreeNode(10), new BinaryTreeNode(30));
            Assert.AreEqual(20, lcaNode1.Value, "The LCA value is incorrect!");

            // Lowest common ancestor for 5 & 12 is 10
            BinaryTreeNode lcaNode2 = lowestCommonAncestor.FindLowestCommonAncestor(new BinaryTreeNode(5), new BinaryTreeNode(12));
            Assert.AreEqual(10, lcaNode2.Value, "The LCA value is incorrect!");

            // Lowest common anscestor for 12 & 35 is 20
            BinaryTreeNode lcaNode3 = lowestCommonAncestor.FindLowestCommonAncestor(new BinaryTreeNode(12), new BinaryTreeNode(35));
            Assert.AreEqual(20, lcaNode3.Value, "The LCA value is incorrect!");
        }
    }
}

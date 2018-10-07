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

            // Return the root if there is one match.
            if (root.Value == node1.Value || root.Value == node2.Value)
            {
                return root;
            }

            BinaryTreeNode leftNode = this.FindLowestCommonAncestor(root.Left, node1, node2);
            BinaryTreeNode rightNode = this.FindLowestCommonAncestor(root.Right, node1, node2);

            // LCA found...if both nodes left and right sends not null.
            if (leftNode != null && rightNode != null)
            {
                return root;
            }

            return leftNode != null ? leftNode : rightNode;
        }

        public BinaryTreeNode FindLcaUsingParentPointer(BinaryTreeNode root, BinaryTreeNode node1, BinaryTreeNode node2)
        {
            BinaryTreeNode lca = null;

            // build hashtable using parent node.
            Dictionary<double, double> childParent = new Dictionary<double, double>();

            // take node1 to build the has map.
            while(node1 != null && node1.Parent != null)
            {
                childParent.Add(node1.Value, node1.Parent.Value);
                node1 = node1.Parent;
            }

            // add the root and it's parent to null
            childParent.Add(node1.Value, -1);

            while(node2 != null)
            {
                if (childParent.ContainsKey(node2.Value))
                {
                    lca = node2;

                    // break and this is the lowest ancestor.
                    break;
                }

                node2 = node2.Parent;
            }

            return lca;
        }

        [TestMethod]
        public void ValidateLCAUsingParentPointer()
        {
            BinaryTreeNode root = new BinaryTreeNode(20);
            root.Left = new BinaryTreeNode(8);
            root.Right = new BinaryTreeNode(22);

            root.Left.Parent = root;
            root.Right.Parent = root;

            root.Left.Left = new BinaryTreeNode(4);
            root.Left.Right = new BinaryTreeNode(12);

            root.Left.Left.Parent = root.Left;
            root.Left.Right.Parent = root.Left;

            root.Left.Right.Left = new BinaryTreeNode(10);
            root.Left.Right.Right = new BinaryTreeNode(14);

            root.Left.Right.Left.Parent = root.Left.Right;
            root.Left.Right.Right.Parent = root.Left.Right;

            BinaryTreeNode node1 = root.Left.Right.Left;
            BinaryTreeNode node2 = root.Left.Right.Right;

            BinaryTreeNode lca = this.FindLcaUsingParentPointer(root, node1, node2);
            Assert.AreEqual(lca.Value, 12);

            node1 = root.Left;
            node2 = root.Left.Right.Right;
            lca = this.FindLcaUsingParentPointer(root, node1, node2);
            Assert.AreEqual(lca.Value, 8);
        }

        [TestMethod]
        public void ValidateLCA()
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

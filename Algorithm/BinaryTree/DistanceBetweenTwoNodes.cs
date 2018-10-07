using DataStructures.Libraries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.BinaryTree
{
    public class BinaryTreeDistance
    {
        public BinaryTreeNode binaryTreeNode;
        public int distance;

        public BinaryTreeDistance(BinaryTreeNode binaryTreeNode, int distance)
        {
            this.binaryTreeNode = binaryTreeNode;
            this.distance = distance;
        }
    }

    [TestClass]
    public class DistanceBetweenTwoNodes
    {
        public BinaryTreeNode FindLca(BinaryTreeNode root, BinaryTreeNode node1, BinaryTreeNode node2)
        {
            if (root == null) return null;

            if (root == node1 || root == node2) return root;

            BinaryTreeNode left = this.FindLca(root.Left, node1, node2);
            BinaryTreeNode right = this.FindLca(root.Right, node1, node2);

            if (left != null && right != null)
            {
                return root;
            }

            if (left != null) return left;
            else return right;
        }

        public int GetDistanceFromRootUsingRecursion(BinaryTreeNode root, BinaryTreeNode node)
        {
            int distance = -1;
            if (root == null) return -1;

            if (root.Value == node.Value) return distance + 1;

            distance = this.GetDistanceFromRootUsingRecursion(root.Left, node);
            if (distance >= 0) return distance + 1;

            distance = this.GetDistanceFromRootUsingRecursion(root.Right, node);
            if (distance >= 0) return distance + 1;

            return distance;
        }

        public int GetDistanceFromRoot(BinaryTreeNode root, BinaryTreeNode node)
        {
            Stack<BinaryTreeDistance> stack = new Stack<BinaryTreeDistance>();
            int distance = 0;
            stack.Push(new BinaryTreeDistance(root, distance));
            
            while(stack.Count > 0)
            {
                BinaryTreeDistance distanceNode = stack.Pop();

                if (distanceNode.binaryTreeNode.Value == node.Value)
                {
                    return distanceNode.distance;
                }

                distance = distanceNode.distance + 1;
                if (distanceNode.binaryTreeNode.Left != null)
                {
                    stack.Push(new BinaryTreeDistance( distanceNode.binaryTreeNode.Left, distance));
                }

                if (distanceNode.binaryTreeNode.Right != null)
                {
                    stack.Push(new BinaryTreeDistance(distanceNode.binaryTreeNode.Right, distance));
                }
            }

            return -1;
        }

        [TestMethod]
        public void TestGetDistanceFromRootUsingRecursion()
        {
            var root = new BinaryTreeNode(1);

            root.Left = new BinaryTreeNode(2);
            root.Right = new BinaryTreeNode(3);

            root.Left.Left = new BinaryTreeNode(4);
            root.Left.Right = new BinaryTreeNode(5);

            root.Right.Left = new BinaryTreeNode(6);
            root.Right.Right = new BinaryTreeNode(7);

            BinaryTreeNode node1 = root.Right.Left;
            BinaryTreeNode node2 = root.Left.Right;

            int distanceNode1 = this.GetDistanceFromRootUsingRecursion(root, node1);
            int distanceNode2 = this.GetDistanceFromRootUsingRecursion(root, node2);
        }

        [TestMethod]
        public void TestGetDistanceFromRoot()
        {
            ///           1
            ///        /      \
            ///      2          3
            ///     / \        /  \
            ///   4    5    6    7

            var root = new BinaryTreeNode(1);

            root.Left = new BinaryTreeNode(2);
            root.Right = new BinaryTreeNode(3);

            root.Left.Left = new BinaryTreeNode(4);
            root.Left.Right = new BinaryTreeNode(5);

            root.Right.Left = new BinaryTreeNode(6);
            root.Right.Right = new BinaryTreeNode(7);

            BinaryTreeNode node1 = root.Left.Left;
            BinaryTreeNode node2 = root.Left.Right;

            int distance1 = this.GetDistanceFromRoot(root, node1);
            int distance2 = this.GetDistanceFromRoot(root, node2);

            BinaryTreeNode lca = this.FindLca(root, node1, node2);

            int lcaDistance = this.GetDistanceFromRoot(root, lca);

            int actualDistance = distance1 + distance2 - (2 * lcaDistance);

            Assert.AreEqual(2, actualDistance);
        }
    }
}

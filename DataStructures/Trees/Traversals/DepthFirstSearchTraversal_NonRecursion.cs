using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Libraries.Trees
{
    [TestClass]
    public class DepthFirstSearchTraversalNonRecursion
    {
        public List<double> InOrderTraversal(BinaryTreeNode root)
        {
            List<double> array = new List<double>();
            Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                BinaryTreeNode node = stack.Peek();

                if (node.Left == null && node.Right == null)
                {
                    array.Add( stack.Pop().Value);
                }

                if (!node.IsLeftInStack && node.Left != null)
                {
                    node.IsLeftInStack = true;
                    stack.Push(node.Left);
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        BinaryTreeNode parentNode = stack.Pop();
                        array.Add(parentNode.Value);

                        if (parentNode.Right != null)
                        {
                            stack.Push(parentNode.Right);
                        }
                    }
                }
            }

            return array;
        }

        public static void PreOrderTraversal(BinaryTreeNode root)
        {
            // pop the node
            // print the node
            // push the right and left (in this order)
        }

        public static void PostOrderTraversal(BinaryTreeNode root)
        {
        }

        [TestMethod]
        public void TestInOrderTraversal()
        {
            BinaryTreeNode root = new BinaryTreeNode(10);
            root.Left = new BinaryTreeNode(8);
            root.Right = new BinaryTreeNode(12);

            root.Left.Left = new BinaryTreeNode(6);
            root.Left.Right = new BinaryTreeNode(9);

            root.Right.Left = new BinaryTreeNode(11);
            root.Right.Right = new BinaryTreeNode(13);

            root.Right.Right.Left = new BinaryTreeNode(12.5);
            root.Right.Right.Right = new BinaryTreeNode(14);

            root.Right.Right.Left.Left = new BinaryTreeNode(12.25);

            List<double> array = this.InOrderTraversal(root);
        }
    }
}

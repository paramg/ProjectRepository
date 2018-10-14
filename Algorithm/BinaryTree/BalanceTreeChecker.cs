using DataStructures.Libraries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.BinaryTree
{
    public class TreeNodeCheck
    {
        public BinaryTreeNode TreeNode;
        public int Depth;

        public TreeNodeCheck(BinaryTreeNode node, int depth)
        {
            this.TreeNode = node;
            this.Depth = depth;
        }
    }

    [TestClass]
    public class BalanceTreeChecker
    {
        public bool IsBinaryTreeBalance(BinaryTreeNode root)
        {
            List<int> depths = new List<int>(3);
            Stack<TreeNodeCheck> stack = new Stack<TreeNodeCheck>();
            stack.Push(new TreeNodeCheck(root, 0));

            while(stack.Any())
            {
                TreeNodeCheck node = stack.Pop();
                int depth = node.Depth;

                // if it's leaf node add the depth to the list.
                if (node.TreeNode != null && 
                    node.TreeNode.Left == null && node.TreeNode.Right == null)
                {
                    if (!depths.Contains(depth))
                    {
                        depths.Add(depth);

                        // when adding the items to the list if the number of depth is more than 2 then the tree is not balanced.
                        // otherwise if there are two items, then the difference should not be greater than 1.
                        if (depths.Count > 2 || 
                            (depths.Count == 2 && Math.Abs(depths[0] - depths[1]) > 1))
                        {
                            return false;
                        }
                    }
                }
                
                if (node.TreeNode != null && node.TreeNode.Left != null)
                {
                    stack.Push(new TreeNodeCheck( node.TreeNode.Left, depth + 1));
                }

                if (node.TreeNode != null && node.TreeNode.Right != null)
                {
                    stack.Push(new TreeNodeCheck(node.TreeNode.Right, depth + 1));
                }
            }

            return true;
        }

        [TestMethod]
        public void TestBinaryTreeChecker()
        {

        }
    }
}

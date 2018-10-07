using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Libraries.Trees
{
    [TestClass]
    public class BinarySearchTree
    {
        public BinarySearchTree()
        {
            this.PopulateDefaultBalanceTree();
        }

        public BinaryTreeNode Root { get; set; }

        public void PopulateDefaultBalanceTree()
        {
            this.Insert(20);
            this.Insert(10);
            this.Insert(30);
            this.Insert(5);
            this.Insert(12);
            this.Insert(25);
            this.Insert(35);
        }
        
        public void Insert(int data)
        {
            BinaryTreeNode treeNode = new BinaryTreeNode(data);

            if(this.Root == null)
            {
                this.Root = treeNode;
            }
            else
            {
                BinaryTreeNode currentNode = this.Root;
                BinaryTreeNode parent = null;

                while (currentNode != null)
                {
                    parent = currentNode;

                    if (data < currentNode.Value)
                    {
                        currentNode = currentNode.Left;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                    }
                }

                if(data < parent.Value)
                {
                    parent.Left = treeNode;
                }
                else
                {
                    parent.Right = treeNode;
                }
            }
        }

        public BinaryTreeNode Delete(BinaryTreeNode root, double data)
        {
            if (root == null) return null;

            if(root.Value > data)
            {
                root.Left = this.Delete(root.Left, data);
            }
            else if(root.Value < data)
            {
                root.Right = this.Delete(root.Right, data);
            }
            else
            {
                // case 1: Both left and right child of the node is null (leaf node) 
                if (root.Left == null && root.Right == null)
                {
                    root = null;
                }

                // case 2: One child - Left or right child could be present
                else if (root.Left != null && root.Right == null)
                {
                    root = root.Left;
                }
                else if(root.Right != null && root.Left == null)
                {
                    root = root.Right;
                }
                // case 3: Two child - In order successor, the next successor of the current node to be deleted.
                // The next successor could be present on the extreme left of the right subtree 
                // Or the next successor could be present on the extreme right of the left subtree
                else if(root.Left != null && root.Right != null)
                {
                    // Find the min in the right sub tree and replace with the current node.
                    BinaryTreeNode minNode = FindMinimum(root.Right);
                    root.Value = minNode.Value;

                    // Delete the minNode from the tree.
                    root.Right = this.Delete(root.Right, minNode.Value);
                }
            }

            return root;
        }

        private BinaryTreeNode FindMinimum(BinaryTreeNode rightSubTree)
        {
            // The min value will lie in the extreme left of the right sub tree.
            while(rightSubTree.Left != null)
            {
                rightSubTree = rightSubTree.Left;
            }

            return rightSubTree;
        }

        [TestMethod]
        public void TestBinaryNodeDelete()
        {
            this.Root = this.Delete(this.Root, 10);
        }
    }
}

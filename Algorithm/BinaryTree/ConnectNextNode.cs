using DataStructures.Libraries.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.BinaryTree
{
    public class ConnectNextNode
    {
        BinaryTreeNode Root { get; }

        public ConnectNextNode(BinaryTreeNode root)
        {
            this.Root = root;
        }

        public void ConnectNode()
        {
            BinaryTreeNode node = this.Root;

            // 1. Start loop 1 to traverse depth wise.
            // 2. Start loop 2 to traverse breadth wise.
            // 3. Connect the next node while traversing depth and breadth wise.
            // Somtimes the next node will not be present in immediate next, 
            // in such cases keep going next until we find the next node.
            // For eg1: consider the following tree:
            ///         20
            ///         /  \
            ///      10    30
            ///     /        /  \
            ///    5      25   35
            ///    
            // For eg2: consider the following tree:
            ///         20
            ///         /  \
            ///      10    30
            ///     /   \       \
            ///    5    12    35

            // depth wise traversal
            while (node != null)
            {
                BinaryTreeNode node2 = node;

                // breadth wise traversal
                while (node2 != null)
                {
                    if (node2.Left != null)
                    {
                        if(node2.Right != null)
                        {
                            node2.Left.Next = node2.Right;
                        }
                        else
                        {
                            // Traverse breadth until we find the next node.
                            node.Left.Next = this.SearchForNextNode(node2.Next);
                        }
                    }

                    if (node2.Right != null && node2.Next != null)
                    {
                        if(node2.Next.Left != null)
                        {
                            node2.Right.Next = node2.Next.Left;
                        }
                        else
                        {
                            // Traverse breadth until we find the next node.
                            node2.Right.Next = this.SearchForNextNode(node2.Next);
                        }
                    }

                    node2 = node2.Next;
                }

                node = node.Left;
            }
        }

        private BinaryTreeNode SearchForNextNode(BinaryTreeNode node2)
        {
            BinaryTreeNode node = node2;

            while(node != null)
            {
                if(node.Left != null)
                {
                    return node.Left;
                }

                else if(node.Right != null)
                {
                    return node.Right;
                }

                node = node.Next;
            }

            // Return null if nothing is found.
            return null;
        }
    }
}

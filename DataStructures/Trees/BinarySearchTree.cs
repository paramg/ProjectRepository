using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Libraries.Trees
{
    public class BinarySearchTree
    {
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

        public void Delete(int data)
        {
            // case 1: Both left and right child of the node is null (leaf node) 

            // case 2: One child - Left or right child could be present

            // case 3: Two child - In order successor, the next successor of the current node to be deleted.
            // The next successor could be present on the extreme left of the right subtree 
            // Or the next successor could be present on the extreme right of the left subtree
        }
    }
}

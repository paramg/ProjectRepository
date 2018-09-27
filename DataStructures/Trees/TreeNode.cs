using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Libraries.Trees
{
    /// <summary>
    /// Tree node is the node that contains as many children from the root.
    /// </summary>
    public class TreeNode
    {
        public TreeNode root;

        private const int ChildrenNodeSize = 100;
        public TreeNode[] ChildNodes;
        public int value = int.MinValue;
        public bool isLeafNode;

        public TreeNode(int value)
        {
            this.value = value;
            this.ChildNodes = new TreeNode[ChildrenNodeSize];
        }

        public void InsertNewNode(TreeNode root, int parent, int value)
        {
            if (root == null)
            {
                var node = new TreeNode(value);
                root = node;

                this.root = root;
            }
            else
            {
                TreeNode node = this.GetTreeNode(root, value);
                // choose the child to add the value 
                int count = 0;
                while(count < node.ChildNodes.Length)
                {
                    if (node.ChildNodes[count] != null)
                    {
                        count++;
                    }
                }
                node.ChildNodes[count] = new TreeNode(value);
            }
        }

        public TreeNode GetTreeNode(TreeNode current, int value)
        {
            if (current == null) return null;

            // do in-order traversal of the tree node using the recursive approach.
            while(current != null)
            {
                // do dfs and compare the values
                if (current.value != value)
                {
                    for (int i=0; i <= ChildrenNodeSize; i++)
                    {
                        if (current.ChildNodes[i].value > int.MinValue)
                        {
                            current = this.GetTreeNode(current.ChildNodes[i], value);
                        }
                    }
                }
                else
                {
                    return current;
                }
            }

            return current;
        }
    }
}

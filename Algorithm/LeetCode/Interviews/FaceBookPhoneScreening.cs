using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Interviews
{
    public class TreeNode
    {
        public int value = int.MinValue;
        public TreeNode parent;
        public TreeNode[] ChildNodes;

        public TreeNode(int value)
        {
            this.value = value;
        }
    }

    [TestClass]
    public class FaceBookPhoneScreening
    {
        public TreeNode FindTreeNode(TreeNode clone, TreeNode nodePosition)
        {
            if (clone == null ||
                nodePosition == null) return nodePosition;

            TreeNode nodeParent = nodePosition.parent;

            int position = -1;
            if (nodeParent != null)
            {
                // find all the children.
                TreeNode[] childNodes = nodeParent.ChildNodes;

                // find the position of the node for that parent.
                position = position + 1;
                while (childNodes[position] != nodePosition)
                {
                    position++;
                }
            }

            TreeNode actualNode = this.FindTreeNode(clone, nodeParent);

            if (actualNode == null) actualNode = clone;

            // Pop section, traverse through the clone tree to find the nodePosition.
            // hop to the child node to find the right position.
            if (position >= 0)
            {
                actualNode = actualNode.ChildNodes[position];
            }

            // found actual node.
            return actualNode;
        }

        [TestMethod]
        public void TestFindTreeNode()
        {
            TreeNode root;
            TreeNode node = new TreeNode(10);
            root = node;
            node.parent = null;
            node.ChildNodes = new TreeNode[2];
            node.ChildNodes[0] = new TreeNode(20);
            node.ChildNodes[1] = new TreeNode(30);

            node.ChildNodes[0].parent = node;
            node.ChildNodes[1].parent = node;

            TreeNode childNode1 = node.ChildNodes[1];
            childNode1.ChildNodes = new TreeNode[3];
            childNode1.ChildNodes[0] = new TreeNode(40);
            childNode1.ChildNodes[1] = new TreeNode(50);
            childNode1.ChildNodes[2] = new TreeNode(60);

            childNode1.ChildNodes[0].parent = childNode1;
            childNode1.ChildNodes[1].parent = childNode1;
            childNode1.ChildNodes[2].parent = childNode1;

            TreeNode childNode12 = childNode1.ChildNodes[2];

            TreeNode clone = new TreeNode(root.value);
            this.Clone(root, clone);

            TreeNode resultNode = this.FindTreeNode(clone, childNode12);

            Assert.AreEqual(resultNode.value, childNode12.value);
        }

        private TreeNode Clone(TreeNode root, TreeNode clone)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode tempClone = clone;

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node.ChildNodes != null)
                {
                    int index = 0;

                    if (tempClone.ChildNodes != null)
                    {
                        TreeNode childClone = tempClone.ChildNodes.First(child => child.value == node.value);

                        if (childClone != null)
                        {
                            tempClone = childClone;
                        }
                    }

                    tempClone.ChildNodes = new TreeNode[node.ChildNodes.Length];

                    foreach(TreeNode child in node.ChildNodes)
                    {
                        tempClone.ChildNodes[index] = new TreeNode(child.value);
                        tempClone.ChildNodes[index].parent = tempClone;
                        queue.Enqueue(child);
                        index++;
                    }
                }
            }

            return clone;
        }        
    }
}

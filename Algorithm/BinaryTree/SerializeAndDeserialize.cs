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
    public class SerializeAndDeserialize
    {
        public BinaryTreeNode DeSerialize(int[] serializedString, int count)
        {
            // this is leaf node
            if (serializedString[count] == -1)
            {
                return null;
            }

            int value = serializedString[count];
            BinaryTreeNode treeNode = new BinaryTreeNode(value);


            treeNode.Left = this.DeSerialize(serializedString, count + 1);
            treeNode.Right = this.DeSerialize(serializedString, count + 1);

            return treeNode;
        }

        public string Serialize(BinaryTreeNode root, string str)
        {
            if (root != null)
            {
                str += root.Value + ",";

                if (root.Left == null && root.Right == null)
                {
                    str = str + "-1,";
                    System.Diagnostics.Debug.WriteLine(str);

                    return str;
                }
            }

            if (root != null) str = Serialize(root.Left, str);
            if (root!= null) str = Serialize(root.Right, str);

            return str;
        }

        [TestMethod]
        public void TestSerialize()
        {
            var binarySearchTree = new BinarySearchTree();
            binarySearchTree.PopulateDefaultBalanceTree();

            //BinaryTreeNode node1 = new BinaryTreeNode(10);
            //node1.Left = new BinaryTreeNode(5);
            //node1.Right = new BinaryTreeNode(12);

            string str = this.Serialize(binarySearchTree.Root, "");
            string serializedString = str.TrimEnd(',');

            string[] serializedStringArray = serializedString.Split(',');
            List<int> serializedIntArray = new List<int>();

            foreach(string ser in serializedStringArray)
            {
                serializedIntArray.Add(int.Parse(ser));
            }

            BinaryTreeNode node = this.DeSerialize(serializedIntArray.ToArray(), 0);
        }
    }
}

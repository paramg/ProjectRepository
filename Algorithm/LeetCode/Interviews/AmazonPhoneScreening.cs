using DataStructures.Libraries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interviews
{
    [TestClass]
    // Date: 9/18/2018
    public class AmazonPhoneScreening
    {
        /*
            At amazon products are organized in a hierarchy called browse nodes. 
            Each browse node may be a part of another browse node, until you 
            reach a top level BN which doesn't belong to any other 
            BN. e.g - prodcut id:1 which is a Mobile Phone may have the following hirarchy:
            PID-1 (iPhone) ->N3 (Mobile Phones) -> N2 (Phones) -> N1 (Electronics)
 
            You are given two files, which contains the following mappings
            File-1 (product to parent node mapping)
            PID-1 : N3
 
            File-2 (parent->child node mapping)
            N1 : N2
            N2 : N3
 
            Given these two files, for every product in File 1, we want to 
            find the BN hierarchy starting with the top level node leading upto the 
            immediate parent node. So for the above example
            PID-1 : N1,N2,N3
        */

        private TreeNode Clone(TreeNode root, TreeNode clone, int value, int position)
        {
            // if node is null then return new node
            if (root.ChildNodes == null)
                return new TreeNode(value);

            while (root != null)
            {
                TreeNode node = root.ChildNodes != null ? root.ChildNodes[position] : null;

                value = node != null ? node.value : 0;
                if (clone.ChildNodes == null && root.ChildNodes != null)
                {
                    clone.ChildNodes = new TreeNode[root.ChildNodes.Length];
                }

                TreeNode newNode = this.Clone(node, clone.ChildNodes[position], value, position);

                if (clone != null)
                {
                    // set the child and parent for that position.
                    clone.ChildNodes[position] = newNode;
                    clone.ChildNodes[position].parent = clone;

                    position = position == clone.ChildNodes.Length - 1 ? 0 : position + 1;
                    // clone = clone.ChildNodes[position];
                }
            }

            return clone;
        }
        public void GetProductHierarchy(BinaryTreeNode root)
        {
        }

        /// <summary>
        /// The dependency tree will look like:
        /// N1:N2, N2:N3, N2:N4, N1:N5, N5:N6, N5:N7
        ///            N1
        ///        /         \
        ///      N2         N5
        ///     /   \        /  \
        ///   N3   N4   N6   N7
        /// </summary>
        /// <param name="dependencyTree"></param>
        /// <returns></returns>
        public void CreateBinaryTreeNode(string[] dependencyTree)
        {
        }

        public void InsertNode(string node, BinaryTreeNode root = null)
        {
            // first find the node from the tree and if it does not exists then insert as root
            if (root == null)
            {
            }
        }

        public void GetProductHierarchy(string[] file1, string[] file2)
        {
            Dictionary<string, string> nodeHierarchy = this.GetDictionary(file2);
            int file1Counter = 0;
            while (file1Counter < file1.Length )
            {
                string line = file1[file1Counter];
                string[] array = line.Split(':');

                // parent
                string product = array[0].Trim();
                string node = array[1].Trim();

                List<string> nodes = new List<string>();
                nodes.Add(node);

                while (nodeHierarchy.ContainsKey(node))
                {
                    node = nodeHierarchy[node];
                    nodes.Add(node);
                }

                // print the list in reverse order.
                nodes.Reverse();

                nodes.ForEach(i => System.Diagnostics.Debug.Write(i));

                file1Counter++;
            }
        }


        public Dictionary<string, string> GetDictionary(string[]  nodeHierarchyFile )
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            int fileCounter = 0;
            while (fileCounter < nodeHierarchyFile.Length)
            {
                string line = nodeHierarchyFile[fileCounter];
                string[] array = line.Split(':');

                // parent
                string parent = array[0].Trim();
                string child = array[1].Trim();

                dict[child] = parent;

                fileCounter++;
            }

            return dict;
        }

        [TestMethod]
        public void TestHierarchy()
        {
             this.GetProductHierarchy(new[] { "PID-1 : N3" }, new[] { "N1 : N2", "N2 : N3" });
        }
    }
}

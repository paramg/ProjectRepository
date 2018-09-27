using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Libraries.Trees
{
    [TestClass]
    public class RootToLeafSum
    {
        public bool FindRootToLeafSumPath(BinaryTreeNode root, int sum, List<int> result)
        {
            // check if it's leaf node
            if (root.Left == null && root.Right == null)
            {
                bool isTarget = false;
                if (sum == root.Value)
                {
                    isTarget = true;
                    result.Add(root.Value);
                }

                return isTarget;
            }

            bool isTargetSumLeft = this.FindRootToLeafSumPath(root.Left, sum - root.Value, result);
            bool isTargetSumRight = this.FindRootToLeafSumPath(root.Right, sum - root.Value, result);

            if (isTargetSumLeft) result.Add(root.Value);
            if (isTargetSumRight) result.Add(root.Value);
            
            return isTargetSumLeft || isTargetSumRight;
        }

        [TestMethod]
        public void TestFindRootToLeaftSumPath()
        {
            ///          20
            ///        /      \
            ///      10       30
            ///     / \        /  \
            ///    5   12   25   35
            
           var root = new BinaryTreeNode(20);

           root.Left = new BinaryTreeNode(10);
           root.Right = new BinaryTreeNode(30);

           root.Left.Left = new BinaryTreeNode(5);
           root.Left.Right = new BinaryTreeNode(12);

           root.Right.Left = new BinaryTreeNode(25);
           root.Right.Right = new BinaryTreeNode(35);

            List<int> listArray = new List<int>();

            bool isTargetExist = this.FindRootToLeafSumPath(root, 80, listArray);
        }
    }
}

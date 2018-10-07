using DataStructures.Libraries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Trees
{
    [TestClass]
    public class LevelSpiralOrder
    {
        BinaryTreeNode Root { get; }

        public LevelSpiralOrder()
        {
        }

        public LevelSpiralOrder(BinaryTreeNode root)
        {
            this.Root = root;
        }

        public double[] PrintSpiralOrder()
        {
            List<double> spiralOrderArray = new List<double>();

            // 1. Use two stacks S1 and S2
            // 2. Push first item to Stack S1
            // 3. Pop Items from S1 and move left and right nodes to S2 until S1 is empty.
            // 4. Pop Items from S2 and move right and left nodes (in order) to S1 until S2 is empty.
            // 5. Repeat 3 and 4 until both the stacks S1 and S2 are empty.

            var s1 = new Stack<BinaryTreeNode>();
            var s2 = new Stack<BinaryTreeNode>();

            if(this.Root == null)
            {
                return spiralOrderArray.ToArray();
            }

            s1.Push(this.Root);

            while(s1.Count > 0 || s2.Count > 0)
            {
                while(s1.Count > 0)
                {
                    BinaryTreeNode node = s1.Pop();

                    spiralOrderArray.Add(node.Value);

                    if(node.Right != null)
                    {
                        s2.Push(node.Left);
                    }

                    if(node.Left != null)
                    {
                        s2.Push(node.Right);
                    }
                }

                while(s2.Count > 0)
                {
                    BinaryTreeNode node = s2.Pop();

                    spiralOrderArray.Add(node.Value);

                    if (node.Left != null)
                    {
                        s1.Push(node.Right);
                    }

                    if (node.Right != null)
                    {
                        s1.Push(node.Left);
                    }
                }
            }

            return spiralOrderArray.ToArray();
        }

        [TestMethod]
        public void ValidateTreeSpiralOrder()
        {
            var binarySearchTree = new BinarySearchTree();
            binarySearchTree.PopulateDefaultBalanceTree();

            int[] spiralOrderExpected = { 20, 30, 10, 5, 12, 25, 35}; 

            var spiralOrder = new LevelSpiralOrder(binarySearchTree.Root);

            double[] spiralOrderActual = spiralOrder.PrintSpiralOrder();

            for(int i=0; i < spiralOrderExpected.Length; i++)
            {
                Assert.AreEqual(spiralOrderExpected[i], spiralOrderActual[i], "The data does not match!");
            }
        }
    }
}

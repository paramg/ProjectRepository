using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Libraries.Trees
{
    [TestClass]
    public class BinaryTreeUnitTests
    {
        [TestMethod]
        public void ValidateLevelByLevelTraversal()
        {
            BinarySearchTree binarySearchTree = new BinarySearchTree();
            binarySearchTree.PopulateDefaultBalanceTree();

            // Verify breadth first search.
            BreadthFirstSearchTraversal.LevelByLevelTraversal(binarySearchTree.Root);
        }
    }
}

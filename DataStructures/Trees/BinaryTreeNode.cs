using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Libraries.Trees
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode Left { get; set; }

        public BinaryTreeNode Right { get; set; }

        public int Value { get; set; }

        public BinaryTreeNode(int data)
        {
            this.Value = data;
        }
    }
}

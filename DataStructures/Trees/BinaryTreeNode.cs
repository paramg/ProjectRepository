using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Libraries.Trees
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode Parent { get; set; }

        public BinaryTreeNode Left { get; set; }

        public BinaryTreeNode Right { get; set; }

        public BinaryTreeNode Next { get; set; }

        public bool IsLeftInStack { get; set; }

        public double Value { get; set; }

        public BinaryTreeNode(double data)
        {
            this.Value = data;
        }
    }
}

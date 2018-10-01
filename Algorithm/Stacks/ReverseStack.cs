using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Stacks
{
    [TestClass]
    public class ReverseStack
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=dQsZP8UvHVk
        /// </summary>
        /// <param name="stack"></param>
        public void ReverseStackUsingRecursion(Stack<int> stack)
        {
            if (stack != null  && stack.Count == 0) return;
            int stackValue = stack.Pop();
            
            this.ReverseStackUsingRecursion(stack);
            this.insertBottomOfStack(stack, stackValue);
        }

        public void insertBottomOfStack(Stack<int> stack, int element)
        {
            if (stack.Count == 0)
            {
                stack.Push(element);
                return;
            }

            int stackValue = stack.Pop();
            this.insertBottomOfStack(stack, element);
            stack.Push(stackValue);
        }

        [TestMethod]
        public void TestReverseStackUsingRecursion()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            this.ReverseStackUsingRecursion(stack);
        }
    }
}

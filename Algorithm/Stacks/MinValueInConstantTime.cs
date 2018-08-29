using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    /// <summary>
    /// Get minimum value from stack in constant time.
    /// </summary>
    [TestClass]
    public class MinValueInConstantTime
    {
        private Stack<int> stack = new Stack<int>();
        private Stack<int> auxillaryStack = new Stack<int>();

        public int GetMinimumValue()
        {
            return this.auxillaryStack.Peek();
        }

        public void Push(int value)
        {
            this.stack.Push(value);

            // Use the aux stack (2nd) to push the value if the top of the aux stack is less than the value.
            // Also push to aux stack if the stack is empty.
            if (this.auxillaryStack.Count == 0 || this.auxillaryStack.Peek() > value)
            {
                this.auxillaryStack.Push(value);
            }
            else
            {
                int auxValue = this.auxillaryStack.Peek();
                this.auxillaryStack.Push(auxValue);
            }
        }

        public int Pop()
        {
            int value = this.stack.Pop();

            // remove from the aux stack if the value is equal to the top of the stack.
            if (this.auxillaryStack.Peek() == value)
            {
                this.auxillaryStack.Pop();
            }

            return value;
        }

        [TestMethod]
        public void TestGetMinimumInConstantTime()
        {
            this.Push(10);
            this.Push(8);
            this.Push(11);
            this.Push(5);
            this.Push(2);
            this.Push(20);
            this.Push(17);
            this.Push(1);

            int value = this.GetMinimumValue();

            Assert.AreEqual(value, 1);
        }
    }
}

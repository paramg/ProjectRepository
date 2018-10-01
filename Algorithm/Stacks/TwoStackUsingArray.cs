using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Stacks
{
    public enum StackOption
    {
        One = 1,
        Two = 2
    }

    [TestClass]
    public class TwoStackUsingArray
    {
        public TwoStackUsingArray()
        {
            this.stackOneTop = -1;
            this.stackTwoTop = this.stackArray.Length;
        }

        private int[] stackArray = new int[10];
        private int stackOneTop;
        private int stackTwoTop;

        public bool Push(int value, StackOption stackOption)
        {
            // deduct one from stack 2 top, as you cannot have both pointing to same index as it may overwrite the value.
            if (stackOneTop  == stackTwoTop -1)
            {
                // stack is full
                return false;
            }
            if ( stackOption == StackOption.One)
            {
                this.stackOneTop += 1;
                this.stackArray[this.stackOneTop] = value;
            }

            if (stackOption == StackOption.Two)
            {
                this.stackTwoTop -= 1;
                this.stackArray[this.stackTwoTop] = value;
            }

            return true;
        }

        public int Pop(StackOption stackOption)
        {
            if (stackOption == StackOption.One && this.stackOneTop == -1)
            {
                return -1;
            }

            if (stackOption == StackOption.Two && this.stackTwoTop == this.stackArray.Length)
            {
                return -1;
            }

            int result = -1;
            if (stackOption == StackOption.One)
            {
                result = this.stackArray[this.stackOneTop];
                this.stackArray[this.stackOneTop] = 0;
                this.stackOneTop--;
            }

            if (stackOption == StackOption.Two)
            {
                result = this.stackArray[this.stackTwoTop];
                this.stackArray[this.stackTwoTop] = 0;
                this.stackTwoTop++;
            }

            return result;
        }

        [TestMethod]
        public void TestTwoStackImpl()
        {
            // Stack1
            this.Push(10, StackOption.One);
            this.Push(11, StackOption.One);
            this.Push(12, StackOption.One);
            this.Push(13, StackOption.One);
            this.Push(14, StackOption.One);
            this.Push(15, StackOption.One);
            this.Push(16, StackOption.One);

            // Stack2
            this.Push(20, StackOption.Two);
            this.Push(21, StackOption.Two);
            this.Push(22, StackOption.Two);

            // Stack is full - no space.
            Assert.IsFalse(this.Push(23, StackOption.Two));

            // Pop Stack1
            Assert.AreEqual(16, this.Pop(StackOption.One));
            Assert.AreEqual(15, this.Pop(StackOption.One));
            Assert.AreEqual(14, this.Pop(StackOption.One));
            Assert.AreEqual(13, this.Pop(StackOption.One));
            Assert.AreEqual(12, this.Pop(StackOption.One));
            Assert.AreEqual(11, this.Pop(StackOption.One));
            Assert.AreEqual(10, this.Pop(StackOption.One));
            Assert.AreEqual(-1, this.Pop(StackOption.One));

            // Pop Stack2
            Assert.AreEqual(22, this.Pop(StackOption.Two));
            Assert.AreEqual(21, this.Pop(StackOption.Two));
            Assert.AreEqual(20, this.Pop(StackOption.Two));
            Assert.AreEqual(-1, this.Pop(StackOption.Two));
        }
    }
}

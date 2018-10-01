using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Queues
{
    [TestClass]
    public class QueueUsingStacks
    {
        private Stack<int> auxillaryStack = new Stack<int>();
        private Stack<int> realStack = new Stack<int>();

        public void DequeueMoreCost()
        {
        }

        public void EnqueueMoreCost(int value)
        {
            if (!realStack.Any())
            {
                realStack.Push(value);
                return;
            }

            while(realStack.Any())
            {
                int getValue = realStack.Pop();

                auxillaryStack.Push(getValue);
            }

            realStack.Push(value);

            while(auxillaryStack.Any())
            {
                int getValue = auxillaryStack.Pop();
                realStack.Push(getValue);
            }
        }

        public int Dequeue()
        {
            if (!realStack.Any())
            {
                return -1;
            }

            return realStack.Pop();
        }

        [TestMethod]
        public void TestQueueUsingStack()
        {
            this.EnqueueMoreCost(1);
            this.EnqueueMoreCost(2);
            this.EnqueueMoreCost(3);

            Assert.AreEqual(1, this.Dequeue());
            Assert.AreEqual(2, this.Dequeue());
            Assert.AreEqual(3, this.Dequeue());
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Stacks
{
    public class Node
    {
        public int value;
        public Node previous;
        public Node next;

        public Node(int value)
        {
            this.value = value;
        }
    }

    [TestClass]
    public class GetMiddleElementConstantTimeProblem
    {
        private Node doubleLinkedList;
        private Node middleElement;
        public int Counter = 0;

        public void Push(int value)
        {
            Node node = new Node(value);

            if (doubleLinkedList == null)
            {
                doubleLinkedList = node;
                middleElement = doubleLinkedList;
            }
            else
            {
                doubleLinkedList.next = node;
                doubleLinkedList.next.previous = doubleLinkedList;

                doubleLinkedList = doubleLinkedList.next;
            }

            this.Counter += 1;

            if (this.Counter > 1 && !(this.Counter % 2 == 0))
            {
                middleElement = middleElement.next;
            }
        }

        public int Pop()
        {
            int value = doubleLinkedList.value;
            doubleLinkedList = doubleLinkedList.previous;
            doubleLinkedList.next = null;

            this.Counter -= 1;

            if (!(this.Counter % 2 == 0))
            {
                middleElement = middleElement.previous;
            }

            return value;
        }

        public int GetMiddleElement()
        {
            return middleElement.value;
        }

        [TestMethod]
        public void TestMiddleElementConstantTime()
        {
            this.Push(1);
            this.Push(2);
            this.Push(3);

            Assert.AreEqual(2, GetMiddleElement());
        }

        [TestMethod]
        public void TestMiddleElementConstantTime2()
        {
            this.Push(1);
            this.Push(2);
            this.Push(3);
            this.Push(4);

            Assert.AreEqual(2, GetMiddleElement());
        }

        [TestMethod]
        public void TestMiddleElementConstantTime3()
        {
            this.Push(1);
            this.Push(2);
            this.Push(3);
            this.Push(4);
            this.Push(5);

            Assert.AreEqual(3, GetMiddleElement());
        }

        [TestMethod]
        public void TestMiddleElementConstantTime4()
        {
            this.Push(1);
            this.Push(2);
            this.Push(3);
            this.Push(4);
            this.Push(5);
            this.Pop();

            Assert.AreEqual(3, GetMiddleElement());
        }

        [TestMethod]
        public void TestMiddleElementConstantTime5()
        {
            this.Push(1);
            this.Push(2);
            this.Push(3);
            this.Push(4);
            this.Push(5);

            this.Pop();
            this.Pop();

            Assert.AreEqual(2, GetMiddleElement());
        }
    }
}

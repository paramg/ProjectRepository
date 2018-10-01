using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Queues
{
    public class Node
    {
        public int _value;
        public Node next;

        public Node(int val)
        {
            this._value = val;
        }
    }

    [TestClass]
    public class QueueUsingLinkedList
    {
        private Node head;
        private Node tail;

        public void push(int value)
        {
            Node newNode = new Node(value);
            if (this.tail == null)
            {
                this.tail = newNode;
                this.head = this.tail;

                return;
            }

            this.tail.next = newNode;
            this.tail = this.tail.next;
        }

        public int pop()
        {
            if (this.head == null)
                return -1;

            Node node = this.head;
            this.head = this.head.next;

            if (this.head == null)
            {
                this.tail = null;
            }

            return node._value;
        }

        public void Display()
        {
            Node temp = this.head;

            while (temp != null)
            {
                System.Diagnostics.Debug.WriteLine(temp._value);
                temp = temp.next;
            }
        }

        [TestMethod]
        public void TestQueueUsingLinkedList()
        {
            QueueUsingLinkedList queue = new QueueUsingLinkedList();
            queue.push(1);
            queue.push(2);
            queue.push(3);
            queue.push(4);
            queue.push(5);

            queue.Display();
        }
    }
}

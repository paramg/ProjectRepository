using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    [TestClass]
    public class AddTwoNumbersProblem
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x) { val = x; }
        }

        private ListNode InsertNode(ListNode root, int value)
        {
            ListNode parent = root;
            while (root != null)
            {
                parent = root;
                root = root.next;
            }
            ListNode newNode = new ListNode(value);

            if (parent == null) parent = newNode;
            else parent.next = newNode;

            return parent;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode resultNode = null;
            int carryOnValue = 0;

            while (l1 != null || l2 != null)
            {
                int value1 = 0, value2 = 0;
                if (l1 != null)
                {
                    value1 = l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    value2 = l2.val;
                    l2 = l2.next;
                }

                // Add 2 numbers and carryOn if exists.
                int result = value1 + value2 + carryOnValue;

                // compute the reminder and carry on value.
                int reminder = result % 10;
                carryOnValue = result / 10;

                // create the new node and insert the node to the next.
                ListNode newNode = new ListNode(reminder);
                if (resultNode != null)
                {
                    this.InsertNode(resultNode, reminder);
                }
                else
                {
                    resultNode = this.InsertNode(resultNode, reminder);
                }
            }

            if (carryOnValue > 0)
            {
                this.InsertNode(resultNode, carryOnValue);
            }

            return resultNode;
        }

        [TestMethod]
        public void TestMethod()
        {
            ListNode list1 = null;
            list1 = this.InsertNode(list1, 5);
            // this.InsertNode(list1, 4);
            // this.InsertNode(list1, 3);
            // this.InsertNode(list1, 5);

            ListNode list2 = null;
            list2 = this.InsertNode(list2, 5);
            // this.InsertNode(list2, 6);
            // this.InsertNode(list2, 7);

            ListNode list3 = this.AddTwoNumbers(list1, list2);

            Assert.AreEqual(list3.val, 0);
            list3 = list3.next;

            Assert.AreEqual(list3.val, 1);
        }
    }
}

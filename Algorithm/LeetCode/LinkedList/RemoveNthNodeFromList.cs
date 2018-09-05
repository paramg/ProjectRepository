using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
    [TestClass]
    public class RemoveNthNodeFromList
    {
        
        public bool Compare(ListNode head, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (head.value == array[i])
                {
                    head = head.next;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Remove the node from list from last (n)
        /// 1->2->3->4->5, and n = 2.
        /// After removing the second node from the end, the linked list becomes 1->2->3->5.
        /// Approach: Have 2 pointers, move the first one for n times and then move the 2nd pointer until the 1st one reaches the end.
        /// </summary>
        /// <param name="n"></param>
        public ListNode RemoveNodefromList(ListNode head, int n)
        {
            if (n == 0) return head;

            ListNode pointer1 = head;
            ListNode pointer2 = head;

            int counter = 0;
            while(pointer1 != null && counter < n)
            {
                pointer1 = pointer1.next;
                counter++;
            }

            if (pointer1 == null)
            {
                head = head.next;
                return head;
            }

            while (pointer2 != null 
                && pointer1 != null && pointer1.next != null)
            {
                pointer1 = pointer1.next;
                pointer2 = pointer2.next;
            }

            if (pointer2 != null && pointer2.next != null)
            {
                pointer2.next = pointer2.next.next;
            }

             return head;
        }

        [TestMethod]
        public void TestRemoveNodeFromList()
        {
            ListNode list = ListNode.PopulateLinkedList(new[] { 1, 2, 3, 4, 5});
            this.RemoveNodefromList(list, 2);
            Boolean removedSuccessfully = this.Compare(list, new[] { 1, 2, 3, 5 });

            Assert.IsTrue(removedSuccessfully);
        }

        [TestMethod]
        public void TestRemoveNodeFromList1()
        {
            ListNode list = ListNode.PopulateLinkedList(new[] { 1 });
            this.RemoveNodefromList(list, 1);
            Boolean removedSuccessfully = this.Compare(list, null);

            Assert.IsTrue(removedSuccessfully);
        }
    }
}
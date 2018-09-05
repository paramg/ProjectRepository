using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
    public class ListNode
    {
        public int value;
        public ListNode next;

        public ListNode(int value)
        {
            this.value = value;
        }

        public static ListNode PopulateLinkedList(int[] arrayOfValues)
        {
            ListNode head = new ListNode(arrayOfValues[0]);
            ListNode temp = head;

            for (int i = 1; i < arrayOfValues.Length; i++)
            {
                ListNode node = new ListNode(arrayOfValues[i]);
                temp.next = node;

                temp = temp.next;
            }

            return head;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.LRUCache
{
    public class DoubleLinkedListNode
    {
        public int PageNumber;
        public DoubleLinkedListNode Previous { get; set; }
        public DoubleLinkedListNode Next { get; set; }

        public DoubleLinkedListNode(int pageNumber)
        {
            this.PageNumber = pageNumber;
            this.Previous = null;
            this.Next = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.LRUCache
{
    public class LRUCacheQueue
    {
        public Dictionary<int, DoubleLinkedListNode> lruCacheHashSet = new Dictionary<int, DoubleLinkedListNode>();
        public const int CacheSize = 5;

        public int Counter = 0;
        public DoubleLinkedListNode head;
        public DoubleLinkedListNode rear;

        public bool IsEmpty()
        {
            return this.head == null 
                && this.rear == null
                && this.Counter == 0;
        }

        public bool CheckIfElementExists(int pageNumber, out DoubleLinkedListNode node)
        {
            return this.lruCacheHashSet.TryGetValue(pageNumber, out node);
        }

        public DoubleLinkedListNode CreateCacheElement(int pageNumber)
        {
            var newElement = new DoubleLinkedListNode(pageNumber);

            return newElement;
        }

        public void AddOrRemovePageNumber(int pageNumber)
        {
            DoubleLinkedListNode existingElement;

            if (this.CheckIfElementExists(pageNumber, out existingElement))
            {
                // Detach the element from the queue.
                if (existingElement != null && existingElement.Previous != null)
                {
                    existingElement.Previous.Next = existingElement.Next;
                    this.Counter -= 1;
                }
            }

            if (this.Counter == LRUCacheQueue.CacheSize)
            {
                // Remove the rear element.
                this.Dequeue();
            }

            // Insert to the head of the queue.
            this.Enqueue(pageNumber);
        }

        public void Enqueue(int pageNumber)
        {
            // Create the new cache element to be enqueued.
            DoubleLinkedListNode newElement = this.CreateCacheElement(pageNumber);

            // If the cache is empty both head and rear point to the new element.
            if (this.IsEmpty())
            {
                this.head = newElement;
                this.rear = newElement;
            }
            else
            {
                // Insert the new element to the head.
                newElement.Next = this.head;
                newElement.Previous = null;
                this.head = newElement;
            }
            
            this.Counter += 1;

            // Add to the cache.
            lruCacheHashSet.Add(pageNumber, newElement);
        }

        public void Dequeue()
        {
            if (this.IsEmpty())
            {
                return;
            }

            // Remove the element from the queue.
            DoubleLinkedListNode elementToRemove = this.rear;

            this.rear = elementToRemove.Previous;

            // Reove the element from dictionary.
            this.lruCacheHashSet.Remove(elementToRemove.PageNumber);
        }
    }
}

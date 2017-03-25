using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Libraries.Heap
{
    public abstract class Heap<TKey, TObject>
    {
        public int counter = 0;
        public HeapType HeapType;

        public int HeapSize;
        public const int DefaultHeapSize = 10;

        // Use the heap object to heapify the collection.
        public TKey[] HeapObject;

        public Dictionary<TKey, TObject> dict;

        public Heap(int size = DefaultHeapSize, HeapType heapType = HeapType.MinHeap)  
        {
            this.HeapSize = size;
            this.HeapType = heapType;

            this.dict = new Dictionary<TKey, TObject>();
        }

        public abstract void SiftUpOperation();

        public abstract void SiftDownOperation();

        public void Insert(TKey key, TObject value)
        {
            this.dict.Add(key, value);

            this.HeapObject[this.counter] = key;

            // Heapify using Sift up operation.
            this.SiftUpOperation();
            this.counter += 1;
        }

        public TObject GetAndDelete()
        {
            TKey keyValue = this.HeapObject[0];

            // Delete the root node from the heap.
            this.HeapObject[0] = this.HeapObject[this.counter];
            this.counter -= 1;

            // Heapify using Sift down operation.
            this.SiftDownOperation();

            // Remove the value from the dictionary.
            TObject valueObject = this.dict[keyValue];
            this.dict.Remove(keyValue);

            return valueObject;
        }
        
        protected int FindParent(int position)
        {
            return (position - 1) / 2;
        }

        protected int FindRightChild(int position)
        {
            int rightChildPosition = (2 * position + 2);

            // If the right child is greater than the end of the array
            // Return -1 value.
            if (rightChildPosition > this.counter)
            {
                return -1;
            }

            return rightChildPosition;
        }

        protected int FindLeftChild(int position)
        {
            int leftChildPosition = (2 * position + 1);

            // If the left child is greater than the end of the array
            // Return -1 value.
            if (leftChildPosition > this.counter)
            {
                return -1;
            }

            return leftChildPosition;
        }

        protected int Compare(int position1, int position2)
        {
            if(this.HeapObject[position1] is int)
            {
                int heapValue1 = int.Parse(this.HeapObject[position1].ToString());
                int heapValue2 = int.Parse(this.HeapObject[position2].ToString());

                return heapValue1 > heapValue2 ? 1 : 0;
            }
            else if(this.HeapObject[position1] is DateTime)
            {
                DateTime heapValue1 = DateTime.Parse(this.HeapObject[position1].ToString());
                DateTime heapValue2 = DateTime.Parse(this.HeapObject[position2].ToString());

                return heapValue1.CompareTo(heapValue2);
            }
            else
            {
                throw new NotSupportedException(string.Format("Unsupported data type: {0}", typeof(TKey)));
            }
        }
    }
}

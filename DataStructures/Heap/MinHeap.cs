using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Libraries.Heap
{
    public class MinHeap<TKey, TObject> : Heap<TKey, TObject>
    {
        public MinHeap(int size = DefaultHeapSize, HeapType heapType = HeapType.MinHeap)
            : base(size, heapType)
        {
        }

        public override void SiftDownOperation()
        {
            // Always start at the root node of the heap.
            int rootPosition = 0;
            int leftChildPosition = 0;
            int rightChildPosition = 0;

            while(leftChildPosition < this.counter || rightChildPosition < this.counter)
            {
                leftChildPosition = this.FindLeftChild(rootPosition);
                rightChildPosition = this.FindRightChild(rootPosition);

                // If there is no left or right child for the given parent then quit.
                if(leftChildPosition < 0 && rightChildPosition < 0)
                {
                    break;
                }

                // If left child is smaller than right child
                if (this.Compare(leftChildPosition, rightChildPosition) < 0)
                {
                    // Swap the parent with the left child
                    if (this.Compare(rootPosition, leftChildPosition) > 0)
                    {
                        TKey temp = this.HeapObject[rootPosition];
                        this.HeapObject[rootPosition] = this.HeapObject[leftChildPosition];
                        this.HeapObject[leftChildPosition] = temp;

                        rootPosition = leftChildPosition;
                    }
                    // Swap the parent with the right child
                    else if (this.Compare(rootPosition, rightChildPosition) > 0)
                    {
                        TKey temp = this.HeapObject[rootPosition];
                        this.HeapObject[rootPosition] = this.HeapObject[leftChildPosition];
                        this.HeapObject[leftChildPosition] = temp;

                        rootPosition = rightChildPosition;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public override void SiftUpOperation()
        {
            if(this.counter > 0)
            {
                int parentPosition = this.FindParent(this.counter);

                while(parentPosition >= 0)
                {
                    // Swap if the parent is higher than the child.
                    // For min heap the parent should be always less than the child (either left or right).
                    if (parentPosition > 0 && this.Compare(parentPosition, this.counter) > 0)
                    {
                        TKey temp = this.HeapObject[this.counter];
                        this.HeapObject[this.counter] = this.HeapObject[parentPosition];
                        this.HeapObject[parentPosition] = temp;
                    }
                    else
                    {
                        // If the parent is smaller, then the quit the loop.
                        break;
                    }
                }
            }
        }
    }
}

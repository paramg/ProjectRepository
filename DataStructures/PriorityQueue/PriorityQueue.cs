using Algorithm.Libraries.Heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Libraries.PriorityQueue
{
    public class PriorityQueue<TKey, TObject>
    {
        Dictionary<TKey, TObject> dict;
        MinHeap<TKey, TObject> minHeap = new MinHeap<TKey, TObject>();

        public PriorityQueue(int size)
        {
            this.dict = new Dictionary<TKey, TObject>();
            this.minHeap = new MinHeap<TKey, TObject>(size, HeapType.MinHeap);
        }

        public void Insert(TKey key, TObject value)
        {
            this.minHeap.Insert(key, value);

            this.dict.Add(key, value);
        }

        public TObject Delete()
        {
            TKey keyValue = this.minHeap.Get();

            // Remove the value from the dictionary.
            TObject valueObject = this.dict[keyValue];
            this.dict.Remove(keyValue);

            return valueObject;
        }

        public TObject Get()
        {
            TKey keyValue = this.minHeap.Get();

            // Remove the value from the dictionary.
            TObject valueObject = this.dict[keyValue];

            return valueObject;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.LRUCache
{
    public interface ILRUCache
    {
        void AddOrRemovePageNumber(int pageNumber);

        void Enqueue(int pageNumber);

        void Dequeue();
    }
}

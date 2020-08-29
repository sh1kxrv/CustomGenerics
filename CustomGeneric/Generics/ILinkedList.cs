using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGeneric.Generics
{
    public abstract class ILinkedList<T> : IEnumerable<T>
    {
        public int count;
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public abstract void Add(T data);
        public abstract void Remove(T data);
        public abstract void Clear();
        public abstract bool HasItem(T item);
        public abstract IEnumerator<T> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGeneric.Generics
{
    public class DList<T> : ILinkedList<T>
    {
        public DNode<T> Main;
        public DNode<T> Last;
        public override void Add(T data)
        {
            DNode<T> node = new DNode<T>(data);

            if (Main == null)
                Main = node;
            else
            {
                Last.Next = node;
                node.Previous = Last;
            }
            Last = node;
        }

        public override void Clear()
        {
            Main = null;
            Last = null;
            count = 0;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            DNode<T> current = Main;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public override void Remove(T data)
        {
            DNode<T> current = Main;

            while (current != null)
            {
                if (current.Data.Equals(data))
                    break;
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    Last = current.Previous;

                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    Main = current.Next;
                count--;
            }
        }
        public override bool HasItem(T item)
        {
            DNode<T> next = Main;
            if (next != null)
            {
                if (item != null)
                {
                    while (EqualityComparer<T>.Default.Equals(next.Data, item))
                    {
                        next = next.Next;
                        if (next == Main)
                            return false;
                    }
                    return true;
                }
                while (next.Data != null)
                {
                    next = next.Next;
                    if (next == Main)
                        return false;
                }
                return true;
            }
            return false;
        }
    }
}

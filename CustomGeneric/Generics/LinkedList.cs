using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGeneric.Generics
{
    public class LinkedList<T> : ILinkedList<T>
    {
        SNode<T> Main;
        SNode<T> Last;
        public override void Add(T data)
        {
            SNode<T> node = new SNode<T>(data);
            if (Main == null)
                Main = node;
            else
                Last.Next = node;
            Last = node;
            count++;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            SNode<T> current = Main;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public override void Remove(T data)
        {
            SNode<T> current = Main;
            SNode<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            Last = previous;
                    }
                    else
                    {
                        Main = Main.Next;
                        if (Main == null)
                            Last = null;
                    }
                    count--;
                }

                previous = current;
                current = current.Next;
            }
        }
        public override void Clear()
        {
            Main = null;
            Last = null;
            count = 0;
        }
        public override bool HasItem(T item)
        {
            SNode<T> next = Main;
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

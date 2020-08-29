using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGeneric.Generics
{
    public class RDLinkedList<T> : ILinkedList<T>
    {
        public DNode<T> Main;
        public override void Add(T data)
        {
            DNode<T> node = new DNode<T>(data);

            if (Main == null)
            {
                Main = node;
                Main.Next = node;
                Main.Previous = node;
            }
            else
            {
                node.Previous = Main.Previous;
                node.Next = Main;
                Main.Previous.Next = node;
                Main.Previous = node;
            }
            count++;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            DNode<T> current = Main;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != Main);
        }
        public override void Clear()
        {
            Main = null;
            count = 0;
        }
        public override void Remove(T data)
        {
            DNode<T> current = Main;

            DNode<T> removedItem = null;
            if (count == 0) return;
            do
            {
                if (current.Data.Equals(data))
                {
                    removedItem = current;
                    break;
                }
                current = current.Next;
            }
            while (current != Main);

            if (removedItem != null)
            {
                if (count == 1)
                    Main = null;
                else
                {
                    if (removedItem == Main)
                        Main = Main.Next;
                    removedItem.Previous.Next = removedItem.Next;
                    removedItem.Next.Previous = removedItem.Previous;
                }
                count--;
            }
        }

        public override bool HasItem(T item)
        {
            DNode<T> next = Main;
            if(next != null)
            {
                if(item != null)
                {
                    while(!EqualityComparer<T>.Default.Equals(next.Data, item))
                    {
                        next = next.Next;
                        if (next == Main)
                            return false;
                    }
                    return true;
                }
                while(next.Data != null)
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

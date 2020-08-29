using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGeneric.Generics
{
    //Doubly node
    public class DNode<T>
    {
        public DNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DNode<T> Next { get; set; }
        public DNode<T> Previous { get; set; }
    }
}

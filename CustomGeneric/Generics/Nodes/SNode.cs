using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGeneric.Generics
{
    //Single node
    public class SNode<T>
    {
        public SNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public SNode<T> Next { get; set; }
    }
}

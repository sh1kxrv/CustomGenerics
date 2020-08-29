using CustomGeneric.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGeneric.CTest
{
    class Program
    {
        static DList<int> DList;
        static RDLinkedList<int> RDList;
        static void Main(string[] args)
        {
            DList = new DList<int>();
            DList.Add(123);
            DList.Add(321);
            DList.Add(1337);

            Console.WriteLine(string.Join(" ", DList));

            DList = null;

            Console.WriteLine("\nRDLIST\n");
            RDList = new RDLinkedList<int>();
            RDList.Add(123);
            RDList.Add(321);
            RDList.Add(1337);

            Console.WriteLine(string.Join(" ", RDList));

            Task.Delay(-1).Wait();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture
{
    public class Stack<T>
    {
        int sp = 0;
        T[] items = new T[100];
        public void Push(T item) { items[sp++] = item; }
        public T Pop() { return items[--sp]; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            OpenClosedType.Demo();

            int max = UtilsWithcontraints.max(123,23,2,3,4,5,6);
            Console.WriteLine(max);
        }
    }
}

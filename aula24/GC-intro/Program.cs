using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime;

namespace GC_intro
{
    class X
    {
        String x = "some string";
        long y = 10;
    }

    // Administrative tools -> Performance monitor -> Add .NET CLR Memory / #Bytes in all heaps
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                X x = new X();
            }
        }
    }
}

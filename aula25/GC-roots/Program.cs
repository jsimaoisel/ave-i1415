using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace GCDemo_1
{
    class Program
    {
        private static void TimerCallback(Object o)
        {
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            
            // Force a GC collector
            GC.Collect();
        }

        static void Main(string[] args)
        {
            // Create a Timer object that knows to call our TimerCallback 
            // method once every 1000 milliseconds.
            Timer t = new Timer(TimerCallback, null, 0, 1000);

            Console.ReadLine();

            //Console.WriteLine(t.GetType());
        }
    }
}

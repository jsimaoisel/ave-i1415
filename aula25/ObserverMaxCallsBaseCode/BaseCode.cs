using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;

namespace ObserversMaxCalls
{

    public class Program
    {
        public static void Main()
        {
            Counter c = new Counter();
            c.CounterEvent += B.ConsoleHandler;
            c.CounterEvent += C.MboxHandler;
            c.DoIt(5, 10);
        }
    }


    public delegate void Observer(int value);

    public class ObserverHandlerAttribute : Attribute
    {
        private int maxCalls = Int32.MaxValue;

        public int MaxCalls
        {
            get { return maxCalls; }
            set { maxCalls = value; }
        }
    }

    class Counter
    {
        public event Observer CounterEvent;
        /* <=>
         * public event Observer CounterEvent {
         *   add {
         *      observers += value;
         *   }
         *   remove {
         *      observers -= value;
         *   }
         * }
         * private Observer observers;
         */

        private void NotifyObservers(int n)
        {
            foreach (Observer h in CounterEvent.GetInvocationList())
                if (h != null)
                {
                    ObserverHandlerAttribute attr =
                        (ObserverHandlerAttribute)h.Method.GetCustomAttribute(typeof(ObserverHandlerAttribute), false);
                    if (attr != null && attr.MaxCalls > 0)
                    {
                        attr.MaxCalls--;
                        h(n); // <=> h.Invoke(n);
                    }
                }
        }

        // Notifica o método de callback,
        // por cada iteração de <from> até <to>.
        public void DoIt(int from, int to)
        {
            for (int i = from; i <= to; i++)
            {
                NotifyObservers(i);
            }
        }
    }

}
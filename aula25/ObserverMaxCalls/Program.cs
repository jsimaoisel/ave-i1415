using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;

namespace ObserversMaxCalls
{

    class Program
    {
        static void Main()
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
        class Pair<T, W>
        {
            public T Item1 { get; set; }
            public W Item2 { get; set; }
        }

        private List<Pair<Observer, int>> observers;

        public Counter()
        {
            observers = new List<Pair<Observer, int>>();
        }

        public event Observer CounterEvent
        {
            add
            {
                 ObserverHandlerAttribute attr =
                    (ObserverHandlerAttribute)
                    value.Method.GetCustomAttribute(typeof(ObserverHandlerAttribute), false);
                 observers.Add(new Pair<Observer, int> {
                     Item1 =value, 
                     Item2 = attr == null ? -1 : attr.MaxCalls
                 });
            }
            remove
            {
                for (int i=0; i < observers.Count; ++i)
                {
                    if (observers[i].Item1.Equals(value))
                    {
                        observers.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public void NotifyObservers(int n)
        {
            for(int i=0; i<observers.Count; ++i) {
                Pair<Observer, int> h = observers[i];
                if (h.Item2 != -1)
                {
                    h.Item2--;
                    if (h.Item2 == 0)
                    {
                        observers.RemoveAt(i);
                    }
                }
                h.Item1.Invoke(n); // <=> h(n);
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
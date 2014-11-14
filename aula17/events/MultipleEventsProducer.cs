using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events
{
    delegate void Notify(int code);

    class MultipleEventsProducer
    {
        const int EvA = 0, EvB = 1, EvC = 2;

        private Dictionary<int, Notify> eventListeners;

        public event Notify EventA {
            add 
            {
                Notify n = eventListeners[EvA];
                n = (Notify) Delegate.Combine(n, value);
            }
            remove
            {
                Notify n = eventListeners[EvA];
                n = (Notify)Delegate.Combine(n, value);
            }
        }

        public event Notify EventB
        {
            add
            {
                Notify n = eventListeners[EvB];
                n = (Notify)Delegate.Combine(n, value);
            }
            remove
            {
                Notify n = eventListeners[EvB];
                n = (Notify)Delegate.Combine(n, value);
            }
        }

        public event Notify EventC
        {
            add
            {
                Notify n = eventListeners[EvB];
                n = (Notify)Delegate.Combine(n, value);
            }
            remove
            {
                Notify n = eventListeners[EvB];
                n = (Notify)Delegate.Combine(n, value);
            }
        }

        public MultipleEventsProducer()
        {
            eventListeners = new Dictionary<int, Notify>();
        }

        protected void OnNewEvent(int eventType, int arg)
        {
            Notify n = eventListeners[eventType];
            if (n != null)
            {
                n(arg);
            }
        }

        public void simulateNewEventA(int someCode)
        {
            OnNewEvent(EvA, someCode);
        }
        public void simulateNewEventB(int someCode)
        {
            OnNewEvent(EvB, someCode);
        }
        public void simulateNewEventC(int someCode)
        {
            OnNewEvent(EvC, someCode);
        }

        public static void Main(String[] args)
        {
            MultipleEventsProducer aProducer = new MultipleEventsProducer();
            aProducer.EventA += (c) => Console.WriteLine("eventA {0}", c);
            aProducer.EventB += (c) => Console.WriteLine("eventB {0}", c);
            aProducer.EventB += (c) => Console.WriteLine("eventC {0}", c);
            aProducer.simulateNewEventA(1);
            aProducer.simulateNewEventA(2);
            aProducer.simulateNewEventA(3);
        }
    }
}

using System;
using System.Collections.Generic;

namespace tpc_14
{

    interface IEvent
    {
        event EventHandler MyEvent;
        void SimulateEvent(object sender, EventArgs args);
    }

    class A : IEvent {
        public event EventHandler MyEvent;

        public void SimulateEvent(object sender, EventArgs args)
        {
            if (MyEvent != null)
                MyEvent(sender, args);
        }
    }

    class B : IEvent
    {
        public virtual event EventHandler MyEvent;
        public void SimulateEvent(object sender, EventArgs args)
        {
            if (MyEvent != null)
                MyEvent(sender, args);
        }
    }

    class C : B
    {
        public override event EventHandler MyEvent
        {
            add
            {
                Console.WriteLine("I'm on C.MyEvent.add");
            }
            remove
            {
                Console.WriteLine("I'm on C.MyEvent.add");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();

            Console.WriteLine("{0}\n{1}\n{2}\n", a.GetHashCode(), b.GetHashCode(), c.GetHashCode());

            a.MyEvent += GenericObserver;
            b.MyEvent += GenericObserver;
            c.MyEvent += GenericObserver;

            //a.MyEvent();
            a.SimulateEvent(a, new EventArgs());
            b.SimulateEvent(b, new EventArgs());
            c.SimulateEvent(c, new EventArgs());
        }

        static void GenericObserver(object sender, EventArgs e)
        {
            Console.WriteLine("Event produced by object {0} whose type is {1}", 
                sender.GetHashCode(),
                sender.GetType());
        }
    }
}

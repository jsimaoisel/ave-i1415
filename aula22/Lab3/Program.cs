using System;
using System.Reflection;

namespace dynamic_events
{
   public class Observer 
    {
        public void MyObserver(Object sender, EventArgs args)
        {
            Console.WriteLine("MyObserver called by {0}", sender);
        }
    }

    public class MyClass
    {
        public event EventHandler MyEvent;

        public void CallObservers()
        {
            if (MyEvent != null)
                MyEvent(this, null);
        }
    }

    public class Program
    {
        public static void RegisterObserver(Object target, EventInfo ev, Object delObj, MethodInfo mi)
        {
            ev.AddEventHandler(
                target, 
                Delegate.CreateDelegate(ev.EventHandlerType, delObj, mi)
            );
        }

        static void Main(string[] args)
        {
            MyClass p = new MyClass();
            Observer delObj = new Observer();
            RegisterObserver(
                p, 
                typeof(MyClass).GetEvent("MyEvent"), 
                delObj,
                typeof(Observer).GetMethod("MyObserver"));
            p.CallObservers();
        }
    }
}







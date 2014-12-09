using System;
using System.Reflection;

namespace tpc18
{

    [AttributeUsage(AttributeTargets.Event, AllowMultiple=true)]
    class ForbidenType: Attribute {
        public ForbidenType(Type t) { TheForbidenType = t; }
        public Type TheForbidenType { get; set; }
    }

    class EventUtils {
        public static bool IsTypeAllowedByEvent(EventInfo ei, Type type) {
            ForbidenType[] fattrs = 
                (ForbidenType[])ei.GetCustomAttributes(typeof(ForbidenType));
            for (int i=0; i<fattrs.Length; ++i)
                if (fattrs[i].TheForbidenType.Equals(type))
                    return false;
            return true;
        }

        public static bool IsDelegateAllowedByEvent(Type t, String ev, Delegate d) {
            EventInfo ei = t.GetEvent(ev);
            if (ei == null)
                return false;
            // obter o descritor do tipo onde o método do delegate foi declarado
            Type delType = d.Method.DeclaringType;
            return IsTypeAllowedByEvent(ei, delType);
        }
    }

    class Tx {
        [ForbidenType(typeof(Cx))] [ForbidenType(typeof(Cy))]  // proibe que os delegates refiram      
        public event Action<int> Ev1 {                         // métodos dos tipos Cx e Cy
            add {
                if (
                    EventUtils.
                        IsDelegateAllowedByEvent(typeof(Tx), "Ev1", value)) 
                    ev1 += value;
            }
            remove { ev1 -= value; }
        }
        private Action<int> ev1;
        public void OnEv1()
        {
            if (ev1 != null)
                ev1(12);
        }
    }

    class Cx {
        public void M(int a) {
            Console.WriteLine("Cx.M");
        }
    }

    class Cy {
        public void M(int a) {
            Console.WriteLine("Cy.M");
        }
    }

    class Cw
    {
        public void M(int a)
        {
            Console.WriteLine("Cy.W");
        }
    }

    class Program {
        static void Main(string[] args)
        {
            Cx cx = new Cx();
            Cy cy = new Cy();
            Cw cw = new Cw();
            Tx tx = new Tx();
            tx.Ev1 += new Action<int>(cx.M);
            tx.Ev1 += new Action<int>(cy.M);
            tx.Ev1 += new Action<int>(cw.M);
            tx.OnEv1();
        }

    }
}

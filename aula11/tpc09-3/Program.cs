using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tpc09_03
{
    interface I { void M();}
    class A : I { public virtual void M() { Console.WriteLine("A"); } }
    class B : A { public override void M() { Console.WriteLine("B"); } }
    class C : B, I { void I.M() { Console.WriteLine("C"); } }

    class Program
    {
        static void Main(string[] args)
        {
            C c = new C(); 
            A a = c; 
            B b = c; 
            I i = c; 
            
            a.M(); 
            b.M(); 
            c.M(); 
            i.M();
        }
    }
}

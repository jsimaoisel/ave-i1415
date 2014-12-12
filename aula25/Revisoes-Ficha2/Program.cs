using System;
using System.Collections.Generic;
using System.Reflection;

namespace Revisoes_Ficha2
{
    public static class Extensions
    {
        /*
         * Returns a new object of type T with the properties incialized as describeb in the input sequence
         */
        public static T BindTo<T>(this IEnumerable<Pair<String,Object>> values) {
            Type tObj = typeof(T);
            T obj = (T)Activator.CreateInstance(tObj);
            foreach (Pair<String, Object> p in values)
            {
                PropertyInfo pi = tObj.GetProperty(p.Item1);
                if (pi != null)
                {
                    pi.SetValue(obj, p.Item2);
                }
            }
            return obj;
        }
    }

    class Program
    {
        /*
         * Returns a set of pairs with the public fields of the obj's type
         */
        static IEnumerable<Pair<String, Object>> GetValues(Object obj)
        {
            Type t = obj.GetType();
            foreach (FieldInfo fi in t.GetFields( ))
            {
                yield return new Pair<String,Object>(fi.Name, fi.GetValue(obj));;
            }
            foreach (PropertyInfo pi in t.GetProperties( ))
            {
                yield return new Pair<String, Object>(pi.Name, pi.GetValue(obj));;
            }
        }

        class TestClass
        {
            public int a = 10;
            public String s = "abc";
            public String p
            {
                get { return "ola mundo"; }
                set { s = value;}
            }
            public void M(int a)
            {
                Console.WriteLine(a);
            }
        }

        static void Main(string[] args)
        {
            List<Pair<String, Object>> values = new List<Pair<string, object>>();
            values.Add(new Pair<String, Object>("p", "AVE"));
            TestClass a = (TestClass)values.BindTo<TestClass>();
            foreach (Pair<String, Object> p in GetValues(a))
            {
                Console.WriteLine(p.Item1 + " " + p.Item2);
            }

            Type t = typeof(TestClass);
            MethodInfo mi = t.GetMethod("M");
            Action<int> d1 = CreateActionWithMethodInfo_Lambda(a, mi);
            Action<int> d2 = CreateActionWithMethodInfo_Reflection(a, mi);
            d1(10);
            d2(20);
        }


        /* 
         * delegates, lambdas, eventos, reflection 
         */
        public static Action<int> CreateActionWithMethodInfo_Lambda(Object target, MethodInfo mi)
        {
            return (x) => mi.Invoke(target, new Object[] { x });
        }
        public static Action<int> CreateActionWithMethodInfo_Reflection(Object target, MethodInfo mi)
        {
            return (Action<int>) Delegate.CreateDelegate(typeof(Action<int>), target, mi);
        }

        class A
        {
            public delegate void MyHandler();
            public event MyHandler MyEvent
            {
                // entra em loop infinito
                add
                {
                    MyEvent += value;
                }
                remove
                {
                    MyEvent -= value;
                }
            }
        }

        static class App
        {
            static void Foo() { Console.WriteLine("Foo"); }
            static void Test()
            {
                A a = new A();
                a.MyEvent += Foo;
            }
        } 


    }
}

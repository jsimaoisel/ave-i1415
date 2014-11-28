using System;
using System.Collections.Generic;


namespace Iterators
{
    static class Extensions
    {
        public static E First<E>(this IEnumerable<E> elements)
        {
            IEnumerator<E> iter = elements.GetEnumerator();
            iter.MoveNext();
            return iter.Current;
        }

        public static IEnumerable<E> Filter<E>(this IEnumerable<E> elements, Func<E, bool> pred)
        {
            return new FilterEnumerable<E>(elements, pred);
        }
    }

    static class ExtensionsLazyWithYield
    {
        public static E FirstYield<E>(this IEnumerable<E> elements)
        {
            IEnumerator<E> iter = elements.GetEnumerator();
            iter.MoveNext();
            return iter.Current;
        }

        public static IEnumerable<E> FilterYield<E>(this IEnumerable<E> elements, Func<E, bool> pred)
        {
            foreach (E e in elements)
                if (pred(e))
                    yield return e;
        }
    }


    struct Student
    {
        public int Number { get; set; }
        public String Name { get; set; }
        public double CurrAverage { get; set; }
        public override string ToString()
        {
            return String.Format("[ Number={0} Name={1} CurrAverage={2}]", Number, Name, CurrAverage);
        }
    }  


    class Program
    {
        public static void Main(String[] args) 
        {
            List<Student> list = new List<Student>();
            list.Add(new Student { Name = "j", Number = 1234, CurrAverage = 12.5 });
            list.Add(new Student { Name = "maria", Number = 1023, CurrAverage = 18.1 });
            list.Add(new Student { Name = "ana", Number = 1223, CurrAverage = 17.3 });
            list.Add(new Student { Name = "rui", Number = 1123, CurrAverage = 15.1 });
            list.Add(new Student { Name = "maria2", Number = 10232, CurrAverage = 18.1 });
            list.Add(new Student { Name = "ana2", Number = 12232, CurrAverage = 17.3 });
            list.Add(new Student { Name = "rui2", Number = 1123222, CurrAverage = 15.1 });

            IEnumerable<Student> students =
            list.Filter(x => { Console.WriteLine("1.Analyzing {0}", x); return x.Name.Length > 1; })
                .Filter(x => { Console.WriteLine("2.Analyzing {0}", x); return x.Number % 2 == 0; });
            foreach (Student s in students)
                Console.WriteLine(s);

            IEnumerable<Student> byNames = list.Filter(x => x.Name.Length > 3);

            Console.WriteLine(s);
        }        
    }
}

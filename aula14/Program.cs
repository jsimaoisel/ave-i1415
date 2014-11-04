using System;
using System.Collections.Generic;

namespace generic_delegates
{
    delegate bool Selector<T>(T value);

    /**
     * < 0 o1 < o2
     * = 0 o1 = o2
     * > 0 o1 > o2
     */
    delegate int Comparator<W>(W o1, W o2);

    class Program
    {
        static int FindFirst<T>(T[] values, Selector<T> criterion) {
            for (int i = 0; i < values.Length; ++i)
                if (criterion(values[i]))
                    return i;
            return -1;
        }

        static int Greatest<T>(T[] values, Comparator<T> criterion)
        {
            int idxOfGreatest = 0;
            for (int i = 1; i < values.Length; ++i)
                if (criterion(values[i], values[idxOfGreatest]) > 0)
                    idxOfGreatest = i;
            return idxOfGreatest;
        }

        static void Main(string[] args)
        {
            
            int[] ints = { 10, 1, 2, 3, 40, 5, 6, 7 };
            String[] strs = { "ana", "rui", "manuel", "andrade" };

            Console.WriteLine(Greatest(ints, (x, y) => x - y));

            Console.WriteLine(FindFirst(strs, (s) => s.Contains("d")));

            String name = "rui";
            Console.WriteLine(FindFirst(strs, (s) => s.Equals(name)));

        }
    }
}

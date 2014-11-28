using System;
using System.Collections.Generic;

namespace GenericAlgorithms_Iterators
{
    static class CollectionsExtensions
    {
        public static List<E> Filter<E>(this List<E> elements, Func<E, bool> filter)
        {
            List<E> tmp = new List<E>();
            foreach (E elem in elements)
                if (filter(elem))
                    tmp.Add(elem);
            return tmp;
        }

        public static void ForEach<E>(this List<E> elements, Action<E> action)
        {
            foreach (E elem in elements)
                action(elem);
        }

        public static E First<E>(this List<E> elements)
        {
            return elements[0];
        }
    }

}

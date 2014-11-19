using System;
using System.Collections.Generic;

namespace GenericAlgorithms_Iterators
{
    static class Collections
    {
        public static void ForEach<E>(List<E> elements, Action<E> action)
        {
            foreach (E elem in elements)
                action(elem);
        }

        public static List<E> Filter<E>(List<E> elements, Func<E, bool> filter)
        {
            List<E> tmp = new List<E>();
            foreach (E elem in elements)
                if (filter(elem))
                    tmp.Add(elem);
            return tmp;
        }

        // insertion sort
        public static List<E> Sort<E>(List<E> elements, Func<E, E, int> criterion)
        {
		    for (int i=1; i<elements.Count; ++i) {
			    E key = elements[i];
			    int j=i-1;
			    for (; j>=0 && criterion(elements[j], key) > 0; --j)
				    elements[j+1] = elements[j];
			    elements[j+1] = key;
		    }
            return elements;
        }

        public static List<R> Select<E, R>(List<E> elements, Func<E, R> criterion)
        {
            List<R> tmp = new List<R>();
            foreach (E elem in elements)
                tmp.Add(criterion(elem));
            return tmp;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Iterators
{
    class FilterEnumerable<T> : IEnumerable<T>
    {
        private IEnumerable<T> elems;
        private Func<T, bool> func;

        public FilterEnumerable(IEnumerable<T> elems, Func<T, bool> func)
        {
            this.elems = elems;
            this.func = func;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new FilterEnumerator<T>(elems, func);
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new FilterEnumerator<T>(elems, func);
        }
    }

    class FilterEnumerator<T> : IEnumerator<T>
    {
        private IEnumerator<T> elems;
        private Func<T, bool> func;


        public FilterEnumerator(IEnumerable<T> elems, Func<T, bool> func)
        {
            this.elems = elems.GetEnumerator();
            this.func = func;
        }

        public T Current
        {
            get
            {
                return elems.Current;
            }
        }

        public bool MoveNext()
        {
            while (elems.MoveNext())
            {
                if (func(elems.Current))
                    return true;
            }
            return false;
        }

        public void Reset()
        {
            elems.Reset();
        }

        public void Dispose()
        {
            elems.Dispose();
        }

        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }
    }

    class ForEachEnumerable<T> : IEnumerable<T>
    {

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}

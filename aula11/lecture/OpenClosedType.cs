using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture
{
    class SimpleGenericClass2Param<T, W> {
        public void MyMethod<Z>() { }
    }

    public static class OpenClosedType
    {

        public static void Demo()
        {
            // List is an open type having 1 type parameters
            Type t = typeof(List<>);
            Console.WriteLine(t);

            // SimpleGenericClass2Param is an open type having 2 type parameters
            t = typeof(SimpleGenericClass2Param<,>);
            Console.WriteLine(t);

            // List<int32> is a closed type
            t = typeof(List<Int32>);
            Console.WriteLine(t);

            // List<int32> is a closed type
            t = typeof(List<String>);
            Console.WriteLine(t);

            // List<int32> is a closed type
            t = typeof(List<List<Int32>>);
            Console.WriteLine(t);
        }
    }
}

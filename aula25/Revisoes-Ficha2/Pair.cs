using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Revisoes_Ficha2
{
    public class Pair<T1, T2>
    {

        public Pair(T1 p1, T2 p2)
        {
            Item1 = p1;
            Item2 = p2;
        }
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
    }
}

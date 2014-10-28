using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture
{
    class UtilsWithcontraints
    {
        public static T max<T>(params T[] vals) where T : IComparable<T>
        {
            if (vals.Length == 0)
                throw new System.Exception("Invalid Argument List");
            T r = vals[0];
            for (int i = 1; i < vals.Length; ++i)
            {
                if (r.CompareTo(vals[i]) < 0) r = vals[i];
            }
            return r;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csalgs.math;
namespace csalgs_tests
{
    class Helpers
    {

        public static Double[] GenerateDoubleSelection(int count) {
            if (count <= 0) throw new ArgumentException("Count must be greater than 0");
            Double[] result = new Double[count];
            IRDL rdl = new UniformRDL();

            while (count--!=0) result[count] = rdl.Get();


            return result;
        }

        public static Boolean TestSorting<T>(IEnumerable<T> selection, Comparison<T> comparison){
            


            return false;
        }

    }
}

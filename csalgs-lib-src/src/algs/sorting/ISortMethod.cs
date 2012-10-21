using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.sorting
{
    public interface ISortMethod<T>{
        void Setup(T[] selection);
        void SetupComparable(Comparison<T> comparison);
        
        void Sort();

        void NextStep();

        Boolean Finished
        {
            get;
        }

        int StepIndex
        {
            get;
        }

        int PrimaryItemIndex
        {
            get;
        }

        int SecondaryItemIndex
        {
            get;
        }
    }

    public sealed class Comparisons {
        public static Comparison<Double> DOUBLE_ASC = (double o1, double o2) =>
        {
            if (o1 > o2) return 1;
            if (o1 < o2) return -1;
            return 0;
        };

        public static Comparison<Double> DOUBLE_DESC = (double o1, double o2) =>
        {
            if (o1 > o2) return -1;
            if (o1 < o2) return 1;
            return 0;
        };
    }
}

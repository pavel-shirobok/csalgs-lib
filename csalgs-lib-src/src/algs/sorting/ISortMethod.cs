using System;

// ReSharper disable CheckNamespace
namespace csalgs.sorting
// ReSharper restore CheckNamespace
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
		// ReSharper disable InconsistentNaming
        public static Comparison<Double> DOUBLE_ASC = (o1, o2) =>
		// ReSharper restore InconsistentNaming
	        {
		        if (o1 > o2) return 1;
		        return o1 < o2 ? -1 : 0;
	        };

		// ReSharper disable InconsistentNaming
        public static Comparison<Double> DOUBLE_DESC = (o1, o2) =>
		// ReSharper restore InconsistentNaming
        {
            if (o1 > o2) return -1;
            return o1 < o2 ? 1 : 0;
        };
    }
}

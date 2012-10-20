using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.sorting
{
    abstract public class AbstractSortMethod<T>:ISortMethod<T>
    {
        protected IEnumerable<T> selection;
        protected Comparison<T> comparison;

        public void Setup(IEnumerable<T> selection)
        {
            if (null == selection) throw new ArgumentNullException("selection must be non-null");
            this.selection = selection;
        }

        public void SetupComparable(Comparison<T> comparison)
        {
            if (null == comparison) throw new ArgumentNullException("comparison functions must be non-null");
            this.comparison = comparison;
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public int StepIndex
        {
            get { throw new NotImplementedException(); }
        }

        public int Index
        {
            get { throw new NotImplementedException(); }
        }
        
        abstract public void  NextStep();

        abstract public bool Finished
        {
            get;
        }
    }
}

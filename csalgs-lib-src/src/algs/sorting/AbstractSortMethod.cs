using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.sorting
{
    abstract public class AbstractSortMethod<T>:ISortMethod<T>
    {
        protected T[] selection;
        protected Comparison<T> comparison;
        protected int currentStepIndex;
        protected int currentItemIndex = 0;

        public void Setup(T[] selection)
        {
            if (null == selection) throw new ArgumentNullException("selection must be non-null");
            this.selection = selection;
            reset();
        }

        public void SetupComparable(Comparison<T> comparison)
        {
            if (null == comparison) throw new ArgumentNullException("comparison functions must be non-null");
            this.comparison = comparison;
            reset();
        }

        protected void reset() {
            currentStepIndex = 0;
            currentItemIndex = 0;
        }

        protected void increaseItemIndex() {
            currentItemIndex++;
        }

        public virtual void Sort()
        {
            throw new NotImplementedException();
        }

        public int StepIndex
        {
            get { return currentStepIndex; }
        }

        public int ItemIndex
        {
            get { return currentItemIndex; }
        }
        
        abstract public void  NextStep();

        abstract public bool Finished
        {
            get;
        }
    }
}

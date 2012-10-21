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
        protected int currentPrimaryItemIndex = 0;
        protected int currentSecondaryItemIndex = 0;

        public virtual void Setup(T[] selection)
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

        protected virtual void reset() {
            currentStepIndex = 0;
            currentPrimaryItemIndex = -1;
            currentSecondaryItemIndex = -1;
        }

        protected void increaseItemIndex() {
            currentPrimaryItemIndex++;
        }

        public virtual void Sort()
        {
            while (!Finished) NextStep();
        }

        public int StepIndex
        {
            get { return currentStepIndex; }
        }

        public int PrimaryItemIndex
        {
            get { return currentPrimaryItemIndex; }
        }
        
        abstract public void  NextStep();

        abstract public bool Finished
        {
            get;
        }


        public int SecondaryItemIndex
        {
            get { return currentSecondaryItemIndex; }
        }
    }
}

using System;

// ReSharper disable CheckNamespace
namespace csalgs.sorting
// ReSharper restore CheckNamespace
{
    abstract public class AbstractSortMethod<T>:ISortMethod<T>
    {
        protected T[] Selection;
        protected Comparison<T> Comparison;
        protected int CurrentStepIndex;
        protected int CurrentPrimaryItemIndex = 0;
        protected int CurrentSecondaryItemIndex = 0;

        public virtual void Setup(T[] selection)
        {
            if (null == selection) throw new ArgumentNullException("selection");
            Selection = selection;
            Reset();
        }

        public void SetupComparable(Comparison<T> comparison)
        {
            if (null == comparison) throw new ArgumentNullException("comparison");
            Comparison = comparison;
            Reset();
        }

        protected virtual void Reset() {
            CurrentStepIndex = 0;
            CurrentPrimaryItemIndex = -1;
            CurrentSecondaryItemIndex = -1;
        }

        protected void IncreaseItemIndex() {
            CurrentPrimaryItemIndex++;
        }

        public virtual void Sort()
        {
            while (!Finished) NextStep();
        }

        public int StepIndex
        {
            get { return CurrentStepIndex; }
        }

        public int PrimaryItemIndex
        {
            get { return CurrentPrimaryItemIndex; }
        }
        
        abstract public void  NextStep();

        abstract public bool Finished
        {
            get;
        }


        public int SecondaryItemIndex
        {
            get { return CurrentSecondaryItemIndex; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.sorting
{
    public class BubbleSort<T>:AbstractSortMethod<T>
    {
        private Boolean whasChanged = true;
        private T current;
        public override void Sort()
        {
            current = selection[0];

            while (!Finished) NextStep();
        }

        public override void NextStep()
        {
            current = selection[currentItemIndex];
            increaseItemIndex();

            if(currentItemIndex == selection.Length){
                currentItemIndex = 0;
                current = selection[currentItemIndex];
                increaseItemIndex();
            }
            
            T next = selection[currentItemIndex];

            if (comparison(current, next) == 1) {
                selection[currentItemIndex] = current;
                selection[currentItemIndex-1] = next;
            }
            currentStepIndex++;
        }

        public override bool Finished
        {
            get { return SortHelper.TestSorting<T>(selection, comparison); }
        }
    }
}

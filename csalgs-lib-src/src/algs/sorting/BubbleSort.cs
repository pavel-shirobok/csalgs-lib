using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.sorting
{
    public class BubbleSort<T>:AbstractSortMethod<T>
    {
        private T current;
        private int lightIndex;

        protected override void reset()
        {
            base.reset();
            lightIndex = -1;
        }

        public override void NextStep()
        {
            if (lightIndex == -1) {
                lightIndex = selection.Length;
                currentPrimaryItemIndex = 0;
                current = selection[0];
            }

            current = selection[currentPrimaryItemIndex];
            increaseItemIndex();

            if(currentPrimaryItemIndex == lightIndex){
                currentPrimaryItemIndex = 0;
                current = selection[currentPrimaryItemIndex];
                increaseItemIndex();
                lightIndex--;
            }
            
            T next = selection[currentPrimaryItemIndex];

            if (comparison(current, next) == 1) {
                currentSecondaryItemIndex = currentPrimaryItemIndex - 1;
                selection[currentPrimaryItemIndex] = current;
                selection[currentSecondaryItemIndex] = next;
            }

            currentStepIndex++;
        }

        public override bool Finished
        {
            get { return lightIndex==1; }
        }
    }
}

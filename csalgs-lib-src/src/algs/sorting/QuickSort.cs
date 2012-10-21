using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.sorting
{
    public class QuickSort<T>:AbstractSortMethod<T>
    {
        public override void Setup(T[] selection)
        {
            base.Setup(selection);
            DivideSelection(selection);
        }

        private void DivideSelection(T[] selection)
        {
            //разделить на центры и их диапозоны
            // для этого надо сначала посчитать, сколько там всего таких областей
            int N = selection.Length;
            int countOfFields = 0;
            
            int center = N >> 1;

        }

        public override void NextStep()
        {
            throw new NotImplementedException();
        }

        public override bool Finished
        {
            get { throw new NotImplementedException(); }
        }
    }
}

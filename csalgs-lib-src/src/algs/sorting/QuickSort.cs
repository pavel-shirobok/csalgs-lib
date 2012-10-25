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

using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.sorting
{
    public class QuickSort<T>:AbstractSortMethod<T>
    {
        private static readonly int MAXSTACK = 2048;
        private int i;
        private int j;   			// указатели, участвующие в разделении
  
        private int lb;
        private int ub;  		// границы сортируемого в цикле фрагмента

        private int[] lbstack;
        private int[] ubstack; // стек запросов
 /*                       // каждый запрос задается парой значений,
                        // а именно: левой(lbstack) и правой(ubstack) 
                        // границами промежутка

  long stackpos = 1;   	// текущая позиция стека
  long ppos;            // середина массива
  T pivot;              // опорный элемент
  T temp; 

  lbstack[1] = 0;
  ubstack[1] = size-1;
*/

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

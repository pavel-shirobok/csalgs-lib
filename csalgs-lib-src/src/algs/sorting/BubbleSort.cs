// ReSharper disable CheckNamespace
namespace csalgs.sorting
// ReSharper restore CheckNamespace
{
    public class BubbleSort<T>:AbstractSortMethod<T>
    {
        private T _current;
        private int _lightIndex;

        protected override void Reset()
        {
            base.Reset();
            _lightIndex = -1;
        }

        public override void NextStep()
        {
            if (_lightIndex == -1) {
                _lightIndex = Selection.Length;
                CurrentPrimaryItemIndex = 0;
                _current = Selection[0];
            }

            _current = Selection[CurrentPrimaryItemIndex];
            IncreaseItemIndex();

            if(CurrentPrimaryItemIndex == _lightIndex){
                CurrentPrimaryItemIndex = 0;
                _current = Selection[CurrentPrimaryItemIndex];
                IncreaseItemIndex();
                _lightIndex--;
            }
            
            T next = Selection[CurrentPrimaryItemIndex];

            if (Comparison(_current, next) == 1) {
                CurrentSecondaryItemIndex = CurrentPrimaryItemIndex - 1;
                Selection[CurrentPrimaryItemIndex] = _current;
                Selection[CurrentSecondaryItemIndex] = next;
            }

            CurrentStepIndex++;
        }

        public override bool Finished
        {
            get { return _lightIndex==1; }
        }
    }
}

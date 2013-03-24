using System.Collections.Generic;

// ReSharper disable CheckNamespace
namespace csalgs.math
// ReSharper restore CheckNamespace
{
	public interface ISelection:IEnumerable<IVector> {
		IVector this[int index]
		{
			get;
			set;
		}

		IVector Add(IVector vector);
		IVector Remove(int index);

		void Swap(int indexFirst, int indexSecond);

		ISelection Copy();
		ISelection Copy(int[] indexes);

		void SortBy(int index);

		int Size
		{
			get;
		}
	}

	public class Selection:ISelection
	{
		private readonly SelectionComparator _comparator;

		private readonly List<IVector> _selection;
		public Selection() {
			_selection = new List<IVector>();
			_comparator = new SelectionComparator();
		}

		public Selection(IVector[] vectors) {
			_selection = new List<IVector>();
			for (int i = 0, len = vectors.Length; i < len; i++) {
				Add(vectors[i]);
			}
		}


		public IVector this[int index]
		{
			get { return _selection[index]; }
			set {
				_selection[index] = value;
			}
		}

		public IVector Add(IVector vector)
		{
			_selection.Add(vector);
			return vector;
		}

		public IVector Remove(int index)
		{
			IVector vector = _selection[index];
			_selection.RemoveAt(index);
			return vector;
		}

		public void Swap(int indexFirst, int indexSecond)
		{
			IVector first = _selection[indexFirst];
			IVector second = _selection[indexSecond];

			_selection[indexFirst] = second;
			_selection[indexSecond] = first;
		}

		public ISelection Copy()
		{
			var result = new Vector[_selection.Count];

			for (int i = 0, len = _selection.Count; i < len; i++) {
				result[i] = (Vector) _selection[i].Copy();
			}

			return new Selection(result);
		}

		public ISelection Copy(int[] indexes)
		{
			var result = new Selection();
			for (int i = 0, len = Size; i < len; i++) {
				result.Add(this[i].Copy(indexes));
			}
			return result;
		}

		public void SortBy(int index)
		{
			_comparator.Index = index;
			_selection.Sort(_comparator);
		}

		public int Size
		{
			get { return _selection.Count; }
		}

		public IEnumerator<IVector> GetEnumerator()
		{
			return _selection.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return _selection.GetEnumerator();
		}
	}

	class SelectionComparator : IComparer<IVector> {
		public int Index = 0;
		public int Compare(IVector x, IVector y)
		{
			if (x[Index] > y[Index]) return -1;
			return x[Index] < y[Index] ? 1 : 0;
		}
	}
}

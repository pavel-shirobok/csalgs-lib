using System;

// ReSharper disable CheckNamespace
namespace csalgs.math
// ReSharper restore CheckNamespace
{
	public interface IVector {
		double this[int index]{
			get;
			set;
		}

		double[] Values{
			get;
		}

		int Size
		{
			get;
		}

		IVector Copy(int[] indexes);
		IVector Copy();
	}


	public class Vector:IVector
	{
		private double[] _values;
		private int _size;
		public Vector(double[] values) {
			Init(values);
		}

		public Vector(int size) {
			var vv = new double[size];
			Init(vv);
		}

		private void Init(double[] values) {
			_values = values;
			_size = values.Length;
		}

		public double this[int index]
		{
			get
			{
				return _values[index];
			}
			set
			{
				_values[index] = value;
			}
		}

		public int Size
		{
			get { return _size; }
		}

		public IVector Copy(int[] indexes)
		{
			int i;
			var copy = new double[indexes.Length];
			for (i = 0; i < indexes.Length; i++) {
				copy[i] = _values[indexes[i]];
			}
			return new Vector(copy);
		}

		public IVector Copy()
		{
			var copy = new double[_size];
			Array.Copy(_values, copy, _size);
			return new Vector(copy);
		}
	

		public double[]  Values
		{
			get {
				var copy = new double[_size];
				Array.Copy(_values, copy, _size);
				return copy;
			}
		}
	}
}

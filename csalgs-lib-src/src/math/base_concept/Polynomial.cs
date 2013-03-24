using System;

// ReSharper disable CheckNamespace
namespace csalgs.math
// ReSharper restore CheckNamespace
{
	public class Polynomial
	{

		private double[] _data;

		public int Size {
			get
			{
				return _data.Length;
			}
		}

		public double[] Values {
			get {
				return _data;
			}
		}

		public double this[int index] {
			set {
				_data[index] = value;
			}
			get {
				return _data[index];
			}
		}

		public Polynomial(int size) {
			var ndata = new double[size];
			Init(ndata);
		}

		public Polynomial(double[] data) {
			Init(data);
		}
		
		public Polynomial(IVector data) {
			Init(data.Values);
		}

		private void Init(double[] data)
		{
			_data = data;
		}
		
		public double GetValueForX(double x) {
			double result = 0;
			for (int i = 0, len = Size; i < len; i++) {
				result += this[i] * Math.Pow(x, i);
			}
			return result;
		}

		public ISelection GetSelectionFromRange(double min, double max, int count) {
			var range = new Range(min, max);
			ISelection result = new Selection();

			for (double i = range.Min; i < range.Max; i += (range.Length / (double)count)) 
			{
				IVector v = new Vector(2);
				v[0] = i;
				v[1] = GetValueForX(i);
				result.Add(v);
			}

			return result;
		}

	}
}

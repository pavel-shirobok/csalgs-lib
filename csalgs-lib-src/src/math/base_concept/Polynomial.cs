using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.math
{
	public class Polynomial
	{

		private double[] data;

		public int Size {
			get
			{
				return data.Length;
			}
		}

		public double[] Values {
			get {
				return data;
			}
		}

		public double this[int index] {
			set {
				data[index] = value;
			}
			get {
				return data[index];
			}
		}

		public Polynomial(int size) {
			double[] ndata = new double[size];
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
			this.data = data;
		}
		
		public double GetValueForX(double x) {
			double result = 0;
			for (int i = 0, len = this.Size; i < len; i++) {
				result += this[i] * Math.Pow(x, i);
			}
			return result;
		}

		public ISelection GetSelectionFromRange(double min, double max, int count) {
			Range range = new Range(min, max);
			ISelection result = new Selection();

			for (double i = range.Min; i < range.Max; i += ((double)range.Length / (double)count)) {
				IVector v = new Vector(2);
				v[0] = i;
				v[1] = GetValueForX(i);
				result.Add(v);
			}

			return result;
		}

	}
}

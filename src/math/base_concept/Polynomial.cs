using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.math
{
	public class Polynomial
	{
		private double[] data;
		
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
			for (int i = 0, len = data.Length; i < len; i++) {
				result += x * Math.Pow(data[i], i);
			}
			return result;
		}

	}
}

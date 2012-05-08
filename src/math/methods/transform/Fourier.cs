using System;
using System.Collections.Generic;
using csalgs.math;

namespace csalgs.math
{
	public class FourierUtils {
		public static IWave GetWaveFromComplex(Complex complex, double freq, int numberOfComponents)
		{
			double phase = Math.Atan(complex.Im / complex.R);
			double amplitude = (1.0 / (double)numberOfComponents) * Math.Sqrt(Math.Pow(complex.R, 2) + Math.Pow(complex.Im, 2));

			return new CosWave(freq, amplitude, phase);
		}

		public static Complex[] GetComplexArrayFrom1DSelection(ISelection selection) {
			int size = selection.Size;

			Complex[] result = new Complex[size];
			int i = 0;
			foreach(IVector v in selection){
				result[i] = new Complex(v[0], 0);
				i++;
			}

			return result;
		}

		public static Complex[] GetComplexArrayFrom2DSelection(ISelection selection)
		{
			int size = selection.Size;

			Complex[] result = new Complex[size];
			int i = 0;
			foreach (IVector v in selection)
			{
				result[i] = new Complex(v[0], v[1]);
				i++;
			}

			return result;
		}

		public static ISelection GetSelectionFromComplexArray(Complex[] complexArray){
			ISelection selection = new Selection();

			foreach (Complex c in complexArray) {
				double[] v = {c.R};
				selection.Add(new Vector(v));
			}

			return selection;
		}
	}

	public interface IFourierTransform {
		Complex[] Direct(Complex[] selection);
		Complex[] Reverse(Complex[] selection);
	}

	public class RecursiveFastFourierTransform:IFourierTransform{

		public Complex[] Direct(Complex[] selection)
		{
			return Transform(selection, false);
		}

		public Complex[] Reverse(Complex[] selection)
		{
			return Transform(selection, true);
		}


		private Complex[] Transform(Complex[] selection, bool reverse) {
			int n = selection.Length;
			if (!MathUtils.isPowerOfTwo(n)) throw new ArgumentException("Length of incoming selection must be power of two");

			if (n == 1)
			{
				return selection;
			}

			Complex w = new Complex(1, 0);
			Complex wn = Complex.FromExp(((2 * Math.PI) / (double)n) * (reverse ? -1 : 1));

			int half_length = n / 2;

			Complex[] a0 = new Complex[half_length];
			Complex[] a1 = new Complex[half_length];

			int last0_index = 0;
			int last1_index = 0;

			for (int i = 0; i < n; i++)
			{
				if ((i & 1) == 1)
				{
					a1[last1_index] = selection[i].Clone();
					last1_index++;
				}
				else
				{
					a0[last0_index] = selection[i].Clone();
					last0_index++;
				}
			}

			Complex[] y0 = Transform(a0, reverse);
			Complex[] y1 = Transform(a1, reverse);

			Complex[] y = new Complex[n];

			for (int i = 0; i < n; i++)
			{
				y[i] = new Complex(1, 0);
			}

			Complex y0k;
			Complex y1k;
			Complex w0k;
			for (int k = 0; k < half_length; k++)
			{
				y0k = y0[k];
				y1k = y1[k];

				w0k = w * y1k;
				y[k] = y0k + w0k;
				y[k + n / 2] = y0k - w0k;
				if (reverse) {
					y[k] /= 2;
					y[k + n / 2] /= 2;
				}
				w = w * wn;
			}

			return y;
		}
	}
}

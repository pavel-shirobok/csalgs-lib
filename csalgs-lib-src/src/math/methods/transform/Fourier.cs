using System;

// ReSharper disable CheckNamespace
namespace csalgs.math
// ReSharper restore CheckNamespace
{
	public class FourierUtils {
		public static IWave GetWaveFromComplex(Complex complex, double freq, int numberOfComponents)
		{
			var phase = Math.Atan(complex.Im / complex.R);
			var amplitude = (1.0 / numberOfComponents) * Math.Sqrt(Math.Pow(complex.R, 2) + Math.Pow(complex.Im, 2));

			return new CosWave(freq, amplitude, phase);
		}

		public static Complex[] GetComplexArrayFrom1DSelection(ISelection selection) {
			int size = selection.Size;

			var result = new Complex[size];
			var i = 0;
			foreach(var v in selection){
				result[i] = new Complex(v[0], 0);
				i++;
			}

			return result;
		}

		public static Complex[] GetComplexArrayFrom2DSelection(ISelection selection)
		{
			int size = selection.Size;

			var result = new Complex[size];
			int i = 0;
			foreach (var v in selection)
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

			var w = new Complex(1, 0);
			var wn = Complex.FromExp(((2 * Math.PI) / n) * (reverse ? -1 : 1));

			int halfLength = n / 2;

			var a0 = new Complex[halfLength];
			var a1 = new Complex[halfLength];

			var last0Index = 0;
			var last1Index = 0;

			for (int i = 0; i < n; i++)
			{
				if ((i & 1) == 1)
				{
					a1[last1Index] = selection[i].Clone();
					last1Index++;
				}
				else
				{
					a0[last0Index] = selection[i].Clone();
					last0Index++;
				}
			}

			var y0 = Transform(a0, reverse);
			var y1 = Transform(a1, reverse);

			var y = new Complex[n];

			for (int i = 0; i < n; i++)
			{
				y[i] = new Complex(1, 0);
			}

			for (int k = 0; k < halfLength; k++)
			{
				// ReSharper disable InconsistentNaming
				var y0k = y0[k];
				var y1k = y1[k];
				var w0k = w * y1k;
				// ReSharper restore InconsistentNaming
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

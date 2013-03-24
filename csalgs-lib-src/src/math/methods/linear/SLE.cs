// ReSharper disable CheckNamespace
namespace csalgs.math
// ReSharper restore CheckNamespace
{
	/// <summary>
	/// System of linear equation
	/// </summary>
	public interface ISLE {
		IVector Solve(Matrix a, Matrix b);
	}

	public class SLEGausse : ISLE {

		public IVector Solve(Matrix a, Matrix b)
		{
			int i, j;
			var n = a.RowsCount;

			var A = a.Clone();
			var B = b.Clone();

			n--;
			for (i = 0; i < n - 1; i++)
			{
				for (j = i + 1; j < n; j++)
				{
					A[j, i] = -A[j, i] / A[i, i];
					for (var k = i + 1; k < n; k++)
					{
						A[j, k] = A[j, k] + A[j, i] * A[i, k];
						B[j, 0] = B[j, 0] + A[j, i] * B[i, 0];
					}


				}
			}

			var x = new double[n];

			x[n] = B[n, 0] / A[n, n];
			for (i = n - 1; i >= 0; i--)
			{
				var h = B[i, 0];
				for (j = i + 1; j < n; j++)
				{
					h = h - x[j] * A[i, j];
				}

				x[i] = h / A[i, i];
			}

			return new Vector(x);
		}
	}

	public class SLEMatrix : ISLE {

		public IVector Solve(Matrix a, Matrix b)
		{
			return new Vector((!a * b).GetColumnArray(0));
		}
	}

}

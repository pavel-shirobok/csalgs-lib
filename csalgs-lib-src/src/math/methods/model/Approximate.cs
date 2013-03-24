using System;

// ReSharper disable CheckNamespace
namespace csalgs.math
// ReSharper restore CheckNamespace
{
	public interface IApproximator {
		Polynomial Approximate(ISelection xy, int order);	
	}

	public class LeastSquareMethod:IApproximator{

		public Polynomial Approximate(ISelection xy, int order){
			var a = new Matrix(order, order);
			var b = new Matrix(order, 1);

			for (var i = 0; i < order; i++)
			{
				for (var j = 0; j < order; j++)
				{
					for (var k = 0; k < xy.Size; k++)
					{
						a[i, j] += Math.Pow(xy[k][0], i) * Math.Pow(xy[k][0], j);
					}
				}
			}

			for (var i = 0; i < order; i++) {
				for(var k=0; k < xy.Size; k++){
					b[i, 0] += Math.Pow(xy[k][0], i) * xy[k][1];
				}
			}

			ISLE sle = new SLEGausse();
			return new Polynomial(sle.Solve(a, b));
		}

	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.math
{
	public interface IApproximator {
		Polynomial Approximate(ISelection XY, int order);	
	}

	public class LeastSquareMethod:IApproximator{

		public Polynomial Approximate(ISelection XY, int order){
			Matrix A = new Matrix(order, order);
			Matrix B = new Matrix(order, 1);

			for (int i = 0; i < order; i++)
			{
				for (int j = 0; j < order; j++)
				{
					for (int k = 0; k < XY.Size; k++)
					{
						
						A[i, j] += Math.Pow(XY[k][0], i) * Math.Pow(XY[k][0], j);
					}
				}
			}

			for (int i = 0; i < order; i++) {
				for(int k=0; k < XY.Size; k++){
					B[i, 0] += Math.Pow(XY[k][0], i) * XY[k][1];
				}
			}

			ISLE sle = new SLEGausse();
			return new Polynomial(sle.Solve(A, B));
			//RealMatrix resM = A.GetInverse().Multiply(B);// !A * B;
			//return new Polynomial(resM.GetColumnArray(0));
		}

	}
}

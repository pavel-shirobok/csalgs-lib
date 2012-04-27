using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.math.model
{
	public interface IApproximator {
		Polynomial Approximate(ISelection XY, int order);	
	}

	public class LeastSquareMethod:IApproximator{

		public Polynomial Approximate(ISelection XY, int order){
			RealMatrix A = new RealMatrix(order, order);
			RealMatrix B = new RealMatrix(order, 1);

			for (int i = 0; i < order; i++) {
				for (int j = 0; j < order; j++) {
					for(int k=0; k < XY.Size; k++){
						A[i, j] += Math.Pow(XY[k][0], i) * Math.Pow(XY[k][0], j);
					}
				}
			}

			for (int i = 0; i < order; i++) {
				for(int k=0; k < XY.Size; k++){
					B[i, 0] += Math.Pow(XY[k][0], i) * XY[k][0];
				}
			}

			RealMatrix resM = !A * B;

			//This is old type of result List<double> result = resM.Columns[0].GetRawData();
			
			return null;
		}

	}
}

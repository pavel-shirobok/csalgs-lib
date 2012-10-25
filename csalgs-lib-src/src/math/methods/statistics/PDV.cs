using System;

namespace csalgs.math.stat
{
	/// <summary>
	/// Probability density value - оценка плотности вероятности
	/// </summary>
	public interface IPDV {
		double Calculate(double[] vector);
		double Calculate(IVector vector);
	}

	public class RosenblattParzenAssessment : IPDV
	{
		private Matrix data;
		private IKernel kernel;
		private double[] blurs;

		public RosenblattParzenAssessment(Matrix data, IKernel kernel, double[] blurs) {
			init(data, kernel, blurs);
		}

		public RosenblattParzenAssessment(Matrix data, IKernel kernel, IVector blurs) {
			init(data, kernel, blurs.Values);
		}

		private void init(Matrix data, IKernel kernel, double[] h) {
			//TODO проверки на совместимость данных!
			this.data = data;
			this.kernel = kernel;
			blurs = h;
		}

		public double Calculate(double[] vector) {
			int i, j;
			double resultSumm = 0;
			double resultMult = 0;
			double temp;
			for (i = 0; i < data.RowsCount; i++)
			{
				resultMult = 1;
				for (j = 0; j < data.ColumnsCount; j++)
				{
					temp = (1.0 / blurs[j]) * kernel.Calculate((vector[j] - data[i,j]) / blurs[j]);
					resultMult *= (temp == 0 ? 1 : temp);
				}
				resultSumm += resultMult;
			}

			return resultSumm / data.RowsCount;
		}

		public double Calculate(IVector vector) {
			return Calculate(vector.Values);
		}
	}


}

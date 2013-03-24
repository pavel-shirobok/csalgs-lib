// ReSharper disable CheckNamespace
namespace csalgs.math.stat
// ReSharper restore CheckNamespace
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
		private Matrix _data;
		private IKernel _kernel;
		private double[] _blurs;

		public RosenblattParzenAssessment(Matrix data, IKernel kernel, double[] blurs) {
			Init(data, kernel, blurs);
		}

		public RosenblattParzenAssessment(Matrix data, IKernel kernel, IVector blurs) {
			Init(data, kernel, blurs.Values);
		}

		private void Init(Matrix data, IKernel kernel, double[] h) {
			//TODO проверки на совместимость данных!
			_data = data;
			_kernel = kernel;
			_blurs = h;
		}

		public double Calculate(double[] vector) {
			double resultSumm = 0;
			for (var i = 0; i < _data.RowsCount; i++)
			{
				double resultMult = 1;
				for (var j = 0; j < _data.ColumnsCount; j++)
				{
					var temp = (1.0 / _blurs[j]) * _kernel.Calculate((vector[j] - _data[i,j]) / _blurs[j]);
					resultMult *= (temp == 0 ? 1 : temp);
				}
				resultSumm += resultMult;
			}

			return resultSumm / _data.RowsCount;
		}

		public double Calculate(IVector vector) {
			return Calculate(vector.Values);
		}
	}


}

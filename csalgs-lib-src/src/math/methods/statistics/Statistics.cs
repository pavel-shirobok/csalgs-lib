using System;
// ReSharper disable CheckNamespace
namespace csalgs.math.stat
// ReSharper restore CheckNamespace
{
	public class Statistics
	{

		/// <summary>
		/// Get mean value
		/// </summary>
		/// <param name="data">selection</param>
		/// <returns></returns>
		public static double GetMeanValue(double[] data)
		{
			var s = data.Length;
			double summ = 0;

			for (int i = 0; i < s; i++)
			{
				summ += data[i];
			}
			summ /= s;
			return summ;
		}

		public static double GetMeanValue(IVector data) {
			return GetMeanValue(data.Values);
		}

		/// <summary>
		/// Get dispersion value
		/// </summary>
		/// <param name="data">selection</param>
		/// <param name="meanValue">mean value</param>
		/// <returns></returns>
		public static double GetDispersionValue(double[] data, double meanValue)
		{
			var s = data.Length;
			var summ = 0.0;
			var mw = meanValue;

			for (var i = 0; i < s; i++)
			{
				summ += (Math.Pow(data[i] - mw, 2));
			}
			return Math.Sqrt(summ / s);
		}

		public static double GetDispersionValue(IVector data, double meanValue) {
			return GetDispersionValue(data.Values, meanValue);
		}

		/// <summary>
		/// Get dispersion value
		/// </summary>
		/// <param name="data">selection</param>
		/// <returns></returns>
		public static double GetDispersionValue(double[] data)
		{
			double mw = GetMeanValue(data);
			return GetDispersionValue(data, mw);
		}

		public static double GetDispersionValue(IVector data) {
			return GetDispersionValue(data.Values);
		}

		/// <summary>
		/// Get value of covatiance
		/// </summary>
		/// <param name="dataX">first selection</param>
		/// <param name="dataY">second selection</param>
		/// <returns></returns>
		public static double GetCovarianceValue(double[] dataX, double[] dataY)
		{
			var mwX = GetMeanValue(dataX);
			var mwY = GetMeanValue(dataY);

			var tempData = new double[dataX.Length];
			for (var i = 0; i < dataX.Length; i++)
			{
				tempData[i] = (dataX[i] - mwX) * (dataY[i] - mwY);
			}

			return GetMeanValue(tempData);
		}

		public static double GetCovarianceValue(IVector dataX, IVector dataY) {
			return GetCovarianceValue(dataX.Values, dataY.Values);
		}

		/// <summary>
		/// Get value of correlation
		/// </summary>
		/// <param name="dataOne">first selection</param>
		/// <param name="dataTwo">second selection</param>
		/// <returns></returns>
		public static double GetCorrelationValue(double[] dataOne, double[] dataTwo)
		{
			return GetCovarianceValue(dataOne, dataTwo) / (Math.Sqrt(GetDispersionValue(dataOne, GetMeanValue(dataOne))) * Math.Sqrt(GetDispersionValue(dataTwo, GetMeanValue(dataTwo))));
		}

		public static double GetCorrelationValue(IVector dataOne, IVector dataTwo) {
			return GetCorrelationValue(dataOne.Values, dataTwo.Values);
		}

		/// <summary>
		/// Get matrix with pair correlation values
		/// </summary>
		/// <param name="matrix">matrix with selections</param>
		/// <returns></returns>
		public static Matrix GetPairCorrelationsMatrix(Matrix matrix)
		{
			var n = matrix.ColumnsCount;

			var result = new Matrix(n, n);

			for (var i = 0; i < n; i++)
			{
				for (var j = 0; j < n; j++)
				{
					result[i,j] = GetCorrelationValue(matrix.GetColumnArray(i), matrix.GetColumnArray(j));
				}
			}
			return result;
		}

	}
}

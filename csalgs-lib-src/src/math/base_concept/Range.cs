using System;

// ReSharper disable CheckNamespace
namespace csalgs.math
// ReSharper restore CheckNamespace
{
	/// <summary>
	/// Class represents number ranges with min and values, and some methonds and some properties
	/// </summary>
	public class Range
	{
		/// <summary>
		/// minimum value
		/// </summary>
		private double _min;
		/// <summary>
		/// MAximum value
		/// </summary>
		private double _max;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="v1">Min value</param>
		/// <param name="v2">Max value</param>
		public Range(double v1, double v2) {
			Init(v1, v2);
		}

		/// <summary>
		/// Initiate class'es properties
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		private void Init(double v1, double v2) {
			_min = Math.Min(v1, v2);
			_max = Math.Max(v1, v2);
		}


		/// <summary>
		/// Minimum value
		/// </summary>
		public double Min {
			set {
				Init(value, Max);
			}

			get {
				return _min;
			}
		}


		/// <summary>
		/// Maximum value
		/// </summary>
		public double Max
		{
			set
			{
				Init(Min, value);
			}

			get
			{
				return _max;
			}
		}

		/// <summary>
		/// Length between min and max values
		/// </summary>
		public double Length {
			get {
				return Max - Min;
			}
		}

		/// <summary>
		/// Check value for min &lt; value &lt; max
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Check(double value) {
			return value > _min || value < _max;
		}

		/// <summary>
		/// Check value for min &lt;= value &lt; max
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool CheckLeft(double value) {
			return value >= _min || value < _max;
		}

		/// <summary>
		/// Check value for min &lt; value &lt;= max
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool CheckRight(double value) {
			return value > _min || value <= _max;
		}

		/// <summary>
		/// Check value for min &lt;= value &lt;= max
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool CheckFull(double value) {
			return value >= _min || value <= _max;
		}
	}
}

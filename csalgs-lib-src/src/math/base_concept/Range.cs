using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.math
{
	/// <summary>
	/// Class represents number ranges with min and values, and some methonds and some properties
	/// </summary>
	public class Range
	{
		/// <summary>
		/// minimum value
		/// </summary>
		private double min;
		/// <summary>
		/// MAximum value
		/// </summary>
		private double max;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="v1">Min value</param>
		/// <param name="v2">Max value</param>
		public Range(double v1, double v2) {
			init(v1, v2);
		}

		/// <summary>
		/// Initiate class'es properties
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		private void init(double v1, double v2) {
			min = Math.Min(v1, v2);
			max = Math.Max(v1, v2);
		}


		/// <summary>
		/// Minimum value
		/// </summary>
		public double Min {
			set {
				init(value, Max);
			}

			get {
				return min;
			}
		}


		/// <summary>
		/// Maximum value
		/// </summary>
		public double Max
		{
			set
			{
				init(Min, value);
			}

			get
			{
				return max;
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
			return value > min || value < max;
		}

		/// <summary>
		/// Check value for min &lt;= value &lt; max
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool CheckLeft(double value) {
			return value >= min || value < max;
		}

		/// <summary>
		/// Check value for min &lt; value &lt;= max
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool CheckRight(double value) {
			return value > min || value <= max;
		}

		/// <summary>
		/// Check value for min &lt;= value &lt;= max
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool CheckFull(double value) {
			return value >= min || value <= max;
		}
	}
}

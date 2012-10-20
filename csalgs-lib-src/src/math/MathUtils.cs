using System;

namespace csalgs.math
{
	
	class MathUtils
	{
		public static int SignOfNumber(double value)
		{
			return value == 0 ? 0 : (value < 0 ? -1 : 1);
		}

		public static int SignOfNumber(int value)
		{
			return SignOfNumber((double)value);
		}

		public static int SignOfNumber(float value)
		{
			return SignOfNumber((double)value);
		}

		public static double DistanceBetweenTwoPoints(double x1, double y1, double x2, double y2) {
			return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
		}

		public static bool isPowerOfTwo(int testInt) {
			return (testInt & (testInt - 1)) == 0;
		}
	}
}

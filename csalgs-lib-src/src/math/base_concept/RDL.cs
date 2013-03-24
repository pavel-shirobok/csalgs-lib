using System;
// ReSharper disable CheckNamespace
namespace csalgs.math
// ReSharper restore CheckNamespace
{
	/// <summary>
	/// Interface represents of Random Distribution Law
	/// </summary>
	public interface IRDL
	{
		/// <summary>
		/// Install seed as current time
		/// </summary>
		void Seed();

		/// <summary>
		/// Istall seed for current RDL
		/// </summary>
		/// <param name="seed">seed, as example current time</param>
		void Seed(int seed);

		/// <summary>
		/// Return random number according to current RDL
		/// </summary>
		/// <returns>random number in range from 0.0 to 1.0</returns>
		double Get();

		/// <summary>
		/// Return random number from specified range
		/// </summary>
		/// <param name="min">min</param>
		/// <param name="max">max</param>
		/// <returns></returns>
		double Get(double min, double max);

		/// <summary>
		/// Return random number from specified  as instance of Range class
		/// </summary>
		/// <param name="range">instance of <see cref="csalgs.math.Range"/></param>
		/// <returns>random number in range from Range.min to Range.max</returns>
		double Get(Range range);

		/// <summary>
		/// Return random number with specified meenvalue and dispersion
		/// </summary>
		/// <param name="meanValue">meanvalue</param>
		/// <param name="dispersion">dispersion</param>
		/// <returns>random number</returns>
		double Get2(double meanValue, double dispersion);

		/// <summary>
		/// Property for <see cref="System.Random"/> using for generate RDL
		/// </summary>
		Random Source
		{
			get;
		}

	}

	/// <summary>
	/// Abstract implementation of <see cref="csalgs.math.IRDL"/>
	/// </summary>
	abstract public class AbstractRDL : IRDL {
		/// <summary>
		/// <see cref="System.Random"/> core of IRDL
		/// </summary>
		protected Random RandSource;
		
		/// <summary>
		/// Constructor
		/// </summary>
		protected AbstractRDL() {
			Seed();
		}

		/// <summary>
		/// Install seed as current time
		/// </summary>
		public void Seed()
		{
			var seed = DateTime.Now.Millisecond;
			Seed(seed);
		}

		/// <summary>
		/// Istall seed for current RDL
		/// </summary>
		/// <param name="seed">seed, as example current time</param>
		public void Seed(int seed)
		{
			RandSource = new Random(seed);
		}

		/// <summary>
		/// Property for <see cref="System.Random"/> using for generate RDL
		/// </summary>
		public Random Source {
			get {
				return RandSource;
			}
		}

		/// <summary>
		/// Return random number according to current RDL
		/// </summary>
		/// <returns>random number in range from 0.0 to 1.0</returns>
		public double Get() {
			return Get(0, 1);
		}

		/// <summary>
		/// Return random number from specified range
		/// </summary>
		/// <param name="min">min</param>
		/// <param name="max">max</param>
		/// <returns></returns>
		public double Get(double min, double max) {
			return Get(new Range(min, max));
		}

		/// <summary>
		/// Return random number from specified  as instance of Range class
		/// </summary>
		/// <param name="range">instance of <see cref="csalgs.math.Range"/></param>
		/// <returns>random number in range from Range.min to Range.max</returns>
		abstract public double Get(Range range);

		/// <summary>
		/// Return random number with specified meenvalue and dispersion
		/// </summary>
		/// <param name="meanValue">meanvalue</param>
		/// <param name="dispersion">dispersion</param>
		/// <returns>random number</returns>
		public double Get2(double meanValue, double dispersion) {
			return Get(new Range(meanValue - dispersion / 2, meanValue + dispersion / 2));
		}
	}

	/// <summary>
	/// Implementation of uniform <see cref="csalgs.math.IRDL"/>
	/// </summary>
	public class UniformRDL:AbstractRDL {

		/// <summary>
		/// Constructor
		/// </summary>
		public UniformRDL() {
			Seed();
		}

		/// <summary>
		/// Return random number from specified  as instance of Range class
		/// </summary>
		/// <param name="range">instance of <see cref="csalgs.math.Range"/></param>
		/// <returns>random number in range from Range.min to Range.max</returns>
		public override double Get(Range range)
		{
			return RandSource.NextDouble() * range.Length + range.Min;
		}
	}
	
	/// <summary>
	/// Implementation of normal <see cref="csalgs.math.IRDL"/>
	/// </summary>
	public class NormalRDL : AbstractRDL {

		/// <summary>
		/// Constructor
		/// </summary>
		public NormalRDL() {
			Seed();
		}

		/// <summary>
		/// Return random number from specified  as instance of Range class
		/// </summary>
		/// <param name="range">instance of <see cref="csalgs.math.Range"/></param>
		/// <returns>random number in range from Range.min to Range.max</returns>
		public override double Get(Range range)
		{
			double s = -1, x = 0;

			while (s <= 0 || s > 1)
			{
				x = -1 + RandSource.NextDouble() * 2;
				var y = -1 + RandSource.NextDouble() * 2;

				s = x * x + y * y;
			}

			var z1 = x * Math.Sqrt((-2 * Math.Log(s)) / s);

			var normZ = 1/2 + z1 / 2;
			return range.Length * normZ + range.Min;
		}
	}
}

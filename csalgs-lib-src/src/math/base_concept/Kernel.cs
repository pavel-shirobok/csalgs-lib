using System;

// ReSharper disable CheckNamespace
namespace csalgs.math
// ReSharper restore CheckNamespace
{
	/// <summary>
	/// Delegate specified core-function
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public delegate double KernelCore(double value);

	/// <summary>
	/// Interface specified kernel
	/// </summary>
	public interface IKernel {
		/// <summary>
		/// Calculate core value
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		double Calculate(double value);
	}

	/// <summary>
	/// Class impement <see cref="csalgs.math.IKernel"/>
	/// </summary>
	public class Kernel : IKernel {
		/// <summary>
		/// Gausse kernel
		/// </summary>
		public static IKernel Gausse = new Kernel(value => 
		                                          Math.Pow(2 * Math.PI, -0.5) * Math.Exp((-0.5) * Math.Pow(value, 2)));

		/// <summary>
		/// Epanichnikov's kernel
		/// </summary>
		public static IKernel Epanichnikov = new Kernel(
			value =>
				{
					if (Math.Abs(value) <= 1) 
					{
						return (0.75) * (1 - Math.Pow(value, 2));
					}
					return 0;
				});

		/// <summary>
		/// Quarlical kernel
		/// </summary>
		public static IKernel Quartical = new Kernel(value =>
			{
				if (Math.Abs(value) <= 1)
				{
					return (15 / 16) * Math.Pow(1 - Math.Pow(value, 2), 2);
				}
				return 0;
			});


		/// <summary>
		/// Treangle kernel
		/// </summary>
		public static IKernel Treangle = new Kernel(value =>
			{
				if (Math.Abs(value) <= 1)
				{
					return (1 - Math.Abs(value));
				}
				return 0;
			});

		/// <summary>
		/// Rectangle kernel
		/// </summary>
		public static IKernel Rectangle = new Kernel(r=> Math.Abs(r) <= 1 ? 0.5 : 0);

		/// <summary>
		/// Delegate for core-function
		/// </summary>
		private readonly KernelCore _core;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="core">delegate for core-function</param>
		public Kernel(KernelCore core)
		{
			_core = core;
		}

		/// <summary>
		/// Calculate core-function
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public double Calculate(double value)
		{
			return _core(value);
		}
	}
}
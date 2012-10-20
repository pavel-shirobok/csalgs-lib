using System;

namespace csalgs.math
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
		public static IKernel GAUSSE = new Kernel((KernelCore)((double value) => {
			return Math.Pow(2 * Math.PI, -0.5) * Math.Exp((-0.5) * Math.Pow(value, 2)); 
		}));

		/// <summary>
		/// Epanichnikov's kernel
		/// </summary>
		public static IKernel EPANICHNIKOV = new Kernel((KernelCore)((double value) => {
			if (Math.Abs(value) <= 1) 
			{
				return (0.75) * (1 - Math.Pow(value, 2));
			}
			else 
			{ 
				return 0; 
			} 
		}));

		/// <summary>
		/// Quarlical kernel
		/// </summary>
		public static IKernel QUARTICAL = new Kernel((KernelCore)((double value) =>
		{
			if (Math.Abs(value) <= 1)
			{
				return (15 / 16) * Math.Pow(1 - Math.Pow(value, 2), 2);
			}
			else
			{
				return 0;
			}
		}));


		/// <summary>
		/// Treangle kernel
		/// </summary>
		public static IKernel TREANGLE = new Kernel((KernelCore)((double value) =>
		{
			if (Math.Abs(value) <= 1)
			{
				return (1 - Math.Abs(value));
			}
			else
			{
				return 0;
			}
		}));

		/// <summary>
		/// Rectangle kernel
		/// </summary>
		public static IKernel RECTANGLE = new Kernel((KernelCore)((double r)=>{
			if (Math.Abs(r) <= 1)
			{
				return 0.5;
			}
			else
			{
				return 0;
			}
		}));

		/// <summary>
		/// Delegate for core-function
		/// </summary>
		private KernelCore core;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="core">delegate for core-function</param>
		public Kernel(KernelCore core)
		{
			this.core = core;
			
		}

		/// <summary>
		/// Calculate core-function
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public double Calculate(double value)
		{
			return core(value);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.math
{
	public interface IWave
	{
		double Phase
		{
			get;
			set;
		}

		double Amplitude
		{
			get;
			set;
		}

		double Frequency
		{
			get;
			set;
		}

		double GetValue(double time);
	}

	public abstract class AbstractWave:IWave {
		protected const double DOUBLE_PI = Math.PI * 2; 
		private double frequency;
		private double amplitude;
		private double phase;

		protected void init(double freq, double ampl, double phase) {
			frequency = freq;
			amplitude = ampl;
			this.phase = phase;
		}

		public double Phase
		{
			get
			{
				return phase;
			}
			set
			{
				phase = value;
			}
		}

		public double Amplitude
		{
			get
			{
				return amplitude;
			}
			set
			{
				amplitude = value;
			}
		}

		public double Frequency
		{
			get
			{
				return frequency;
			}
			set
			{
				frequency = value;
			}
		}

		public abstract double GetValue(double time);
	}

	public class SinWave : AbstractWave {

		public SinWave(double freq, double ampl, double phase){
			init(freq, ampl, phase);
		}

		public override double GetValue(double time)
		{
			return Amplitude * Math.Sin(time * DOUBLE_PI * Frequency + Phase);
		}
	}

	public class CosWave : AbstractWave {
		public CosWave(double freq, double ampl, double phase)
		{
			init(freq, ampl, phase);
		}

		public override double GetValue(double time)
		{
			return Amplitude * Math.Cos(time * DOUBLE_PI * Frequency + Phase);
		}
	}
}

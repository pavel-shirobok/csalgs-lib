using System;

// ReSharper disable CheckNamespace
namespace csalgs.math
// ReSharper restore CheckNamespace
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
		protected const double DoublePi = Math.PI * 2; 
		private double _frequency;
		private double _amplitude;
		private double _phase;

		protected void Init(double freq, double ampl, double phase) {
			_frequency = freq;
			_amplitude = ampl;
			_phase = phase;
		}

		public double Phase
		{
			get
			{
				return _phase;
			}
			set
			{
				_phase = value;
			}
		}

		public double Amplitude
		{
			get
			{
				return _amplitude;
			}
			set
			{
				_amplitude = value;
			}
		}

		public double Frequency
		{
			get
			{
				return _frequency;
			}
			set
			{
				_frequency = value;
			}
		}

		public abstract double GetValue(double time);
	}

	public class SinWave : AbstractWave {

		public SinWave(double freq, double ampl, double phase){
			Init(freq, ampl, phase);
		}

		public override double GetValue(double time)
		{
			return Amplitude * Math.Sin(time * DoublePi * Frequency + Phase);
		}
	}

	public class CosWave : AbstractWave {
		public CosWave(double freq, double ampl, double phase)
		{
			Init(freq, ampl, phase);
		}

		public override double GetValue(double time)
		{
			return Amplitude * Math.Cos(time * DoublePi * Frequency + Phase);
		}
	}
}

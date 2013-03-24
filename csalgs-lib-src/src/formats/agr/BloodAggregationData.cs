using System;
using csalgs.math;
// ReSharper disable CheckNamespace
namespace csalgs.formats
// ReSharper restore CheckNamespace
{
	public class BloodAggregationData:Selection
	{
		public BloodAggregationData()
		{
			DateOfTest = DateTime.Now;
			PatientName = "Unknown";
			ReagentName = "No";
		}

		public IVector AddExpirementData(double averageRadius, double averageTransmittance)
		{
			return Add(CreateVector(averageRadius, averageTransmittance));
		}

		private IVector CreateVector(double averageRadius, double averageTransmittance)
		{
			return new Vector(new[] {averageRadius, averageTransmittance});
		}

		public DateTime DateOfTest { get; set; }

		public string PatientName { get; set; }

		public string ReagentName { get; set; }
	}
}

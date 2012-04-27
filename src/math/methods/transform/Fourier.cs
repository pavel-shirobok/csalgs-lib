using System;
using System.Collections.Generic;
using csalgs.math;

namespace csalgs.math.transform
{
	public interface IFourierTransform {
		Complex[] Direct(Complex[] selection);
		Complex[] Reverse(Complex[] selection);
	}
}

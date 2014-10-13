// Milan Darjanin, 1mAIN, milan.darjanin@gmail.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CG1.Ex01.Mathematics
{
	public static class MathEx
	{
		public static double DegToRad(double angleDeg)
		{
			return (Math.PI * angleDeg) / 180;
		}

		public static double RadToDeg(double angleRad)
		{
			return (angleRad * 180) / Math.PI;
		}
	}
}

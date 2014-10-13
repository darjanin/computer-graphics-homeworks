using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CG1.Ex03.Mathematics
{
	public static class MathEx
	{
        /// <summary>
        /// Convert numbers to radians.
        /// </summary>
        /// <param name="a"></param>
		public static double DegToRad(double angleDeg)
		{
            return angleDeg*Math.PI/180;
		}

        /// <summary>
        /// Convert radians to numbers.
        /// </summary>
        /// <param name="a"></param>
		public static double RadToDeg(double angleRad)
		{
            return angleRad*180/Math.PI;
		}
	}
}

// Milan Darjanin, 1mAIN, milan.darjanin@gmail.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CG1.Ex01.Mathematics
{
    // Info: We will use 'structs' instead of 'classes' here. Maybe this will explain why: http://goo.gl/8w6bo
    // Now we assigne vector to another variable, the value is copied not just the reference to the value.
    // Vector is defined in homogeneous coordinates to resolve affine transformatin problem
	public struct Vector4
	{
		#region Properties

		public static readonly Vector4 Zero = new Vector4(0, 0, 0, 0);
 
        public static readonly Vector4 UnitX = new Vector4(1, 0, 0, 0);
        public static readonly Vector4 UnitY = new Vector4(0, 1, 0, 0);
        public static readonly Vector4 UnitZ = new Vector4(0, 0, 1, 0);
        public static readonly Vector4 UnitW = new Vector4(0, 0, 0, 1);
		
        public Double X, Y, Z, W;

		public Double Length
		{
            get
            {
                return Math.Sqrt(Math.Pow(X,2) + Math.Pow(Y,2) + Math.Pow(Z,2));
            }
		}

		#endregion

		#region Init

		public Vector4(Double x, Double y, Double z, Double w = 0)
		{
            X = x;
            Y = y;
            Z = z;
            W = w;
            
		}

		#endregion

		#region Arithmetic Operations

		public static Vector4 operator +(Vector4 a, Vector4 b)
		{
            // Returns addition of two vectors.
            return new Vector4(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
		}

		public static Vector4 operator -(Vector4 a, Vector4 b)
		{
            // Returns subtraction of two vectors.
            return new Vector4(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
		}

		public static Vector4 operator *(Vector4 a, Double b)
		{
            // Returns vector multiplied by number.
            return new Vector4(a.X * b, a.Y * b, a.Z * b, a.W * b);
		}

		public static Vector4 operator *(Double a, Vector4 b)
		{
            // Returns vector multiplied by number.
            return new Vector4(b.X * a, b.Y * a, b.Z * a, b.W * a);
		}

		/// <summary>
		/// Dot Product
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Double operator *(Vector4 a, Vector4 b)
		{
            //Returns dot product of two vectors.
            return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z) + (a.W * b.W) ;
		}

		/// <summary>
		/// 3D Cross Product
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Vector4 operator %(Vector4 a, Vector4 b)
		{
            //Returns 3D cross product of two vectors.
            return new Vector4(
            	a.Y*b.Z - a.Z*b.Y,
            	a.Z*b.X - a.X*b.Z,
            	a.X*b.Y - a.Y*b.X
            );
		}

        /// <summary>
        /// Projection of vector along another vector
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector4 operator /(Vector4 a, Vector4 b)
        {
            // Returns projection of vector 'a' along vector 'b'
            Vector4 aUnit = a * (1/a.Length);
            Vector4 bUnit = b * (1/b.Length);
            Double cosTheta = aUnit * bUnit;
            return a.Length * cosTheta * bUnit;
        }

        /// <summary>
        /// Modulation Product
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector4 operator ^(Vector4 a, Vector4 b)
        {
            // Returns a modulation product of two vectors
            return new Vector4(a.X*b.X, a.Y*b.Y, a.Z*b.Z);
        }

		#endregion

	}
}

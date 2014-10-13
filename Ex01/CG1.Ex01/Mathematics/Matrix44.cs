﻿// Milan Darjanin, 1mAIN, milan.darjanin@gmail.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CG1.Ex01.Mathematics
{
	public struct Matrix44
	{
		#region Properties

		public const Int32 Dim = 4;

        public static readonly Matrix44 Zero = new Matrix44(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        public Double M00, M01, M02, M03, M10, M11, M12, M13, M20, M21, M22, M23, M30, M31, M32, M33;

		public static Matrix44 Identity
		{
            get
            {
            	return new Matrix44(1,0,0,0, 0,1,0,0, 0,0,1,0, 0,0,0,1);
            }
		}

        public Matrix44 Transposed
        {
            get
            {
            	return
            		new Matrix44(M00,M10,M20,M30, M01,M11,M21,M31, M02,M12,M22,M32, M03,M13,M23,M33);
            }
        }

        public Double Determinant
        {
            get
            {
                return M00*M11*M22 + M01*M12*M20 + M02*M10*M21 - M00*M12*M21 - M01*M10*M22 - M02*M11*M20;
            }
        }

        public Matrix44 Inversed
        {
            get
            {
				// Calculate determinant for this matrix            	
            	Double det = this.Determinant;
            	
            	// If determinant [det] is equal to zero, than matrix has not inversed matrix.
            	// Return Zero matrix in that case.
            	if (det == 0) {
            		return Matrix44.Zero;
            	}
            	
            	// Calculate inverse matrix as determinants of 2x2matrices divided by determinant[det].
                return new Matrix44(
            		 (M11*M22 - M12*M21)/det, -(M01*M22 - M02*M21)/det,  (M01*M12 - M02*M11)/det, M03,
            		-(M10*M22 - M12*M20)/det,  (M00*M22 - M02*M20)/det, -(M00*M12 - M02*M10)/det, M13,
            		 (M10*M21 - M11*M20)/det, -(M00*M21 - M01*M20)/det,  (M00*M11 - M01*M10)/det, M23,
            		 M30, M31, M32, M33
            	);
            }
        }

		#endregion

		#region Init

		public Matrix44(
			Double m00, Double m01, Double m02, Double m03,
			Double m10, Double m11, Double m12, Double m13,
			Double m20, Double m21, Double m22, Double m23,
			Double m30, Double m31, Double m32, Double m33)
		{
            M00 = m00; M01 = m01; M02 = m02; M03 = m03;
            M10 = m10; M11 = m11; M12 = m12; M13 = m13;
            M20 = m20; M21 = m21; M22 = m22; M23 = m23;
            M30 = m30; M31 = m31; M32 = m32; M33 = m33;
		}

		#endregion

		#region Arithmetic Operations

		public static Matrix44 operator -(Matrix44 a)
		{
            // Returns matrix with opposite values.
            return new Matrix44(
            	-a.M00, -a.M01, -a.M02, -a.M03,
				-a.M10, -a.M11, -a.M12, -a.M13,
				-a.M20, -a.M21, -a.M22, -a.M23,
				-a.M30, -a.M31, -a.M32, -a.M33
			);
		}

		public static Matrix44 operator +(Matrix44 a, Matrix44 b)
		{
            // Returns addition of two matrices.
            return new Matrix44(
            	a.M00+b.M00, a.M01+b.M01, a.M02+b.M02, a.M03+b.M03,
				a.M10+b.M10, a.M11+b.M11, a.M12+b.M12, a.M13+b.M13,
				a.M20+b.M20, a.M21+b.M21, a.M22+b.M22, a.M23+b.M23,
				a.M30+b.M30, a.M31+b.M31, a.M32+b.M32, a.M33+b.M33
			);
		}

		public static Matrix44 operator -(Matrix44 a, Matrix44 b)
		{
            // Returns subtraction of two matrices as addition of matrix a and matrix b with opposite values
            return a + (-b);
		}

		public static Matrix44 operator *(Matrix44 a, Matrix44 b)
		{
            // Returns multiplication of two matrices.
            return new Matrix44(
            	a.M00*b.M00 + a.M01*b.M10 + a.M02*b.M20 + a.M03*b.M30,
            	a.M00*b.M01 + a.M01*b.M11 + a.M02*b.M21 + a.M03*b.M31,
            	a.M00*b.M02 + a.M01*b.M12 + a.M02*b.M22 + a.M03*b.M32,
            	a.M00*b.M03 + a.M01*b.M13 + a.M02*b.M23 + a.M03*b.M33,
            	
            	a.M10*b.M00 + a.M11*b.M10 + a.M12*b.M20 + a.M13*b.M30,
            	a.M10*b.M01 + a.M11*b.M11 + a.M12*b.M21 + a.M13*b.M31,
            	a.M10*b.M02 + a.M11*b.M12 + a.M12*b.M22 + a.M13*b.M32,
            	a.M10*b.M03 + a.M11*b.M13 + a.M12*b.M23 + a.M13*b.M33,
            	
            	a.M20*b.M00 + a.M21*b.M10 + a.M22*b.M20 + a.M23*b.M30,
            	a.M20*b.M01 + a.M21*b.M11 + a.M22*b.M21 + a.M23*b.M31,
            	a.M20*b.M02 + a.M21*b.M12 + a.M22*b.M22 + a.M23*b.M32,
            	a.M20*b.M03 + a.M21*b.M13 + a.M22*b.M23 + a.M23*b.M33,
            	
            	a.M30*b.M00 + a.M31*b.M10 + a.M32*b.M20 + a.M33*b.M30,
            	a.M30*b.M01 + a.M31*b.M11 + a.M32*b.M21 + a.M33*b.M31,
            	a.M30*b.M02 + a.M31*b.M12 + a.M32*b.M22 + a.M33*b.M32,
            	a.M30*b.M03 + a.M31*b.M13 + a.M32*b.M23 + a.M33*b.M33
            );
		}

		public static Vector4 operator *(Vector4 a, Matrix44 b)
		{
            // Returns multiplication of vector and matrix.
            // Calculated using matrix multiplication where from vector a is created matrix
            Matrix44 tmp = new Matrix44(a.X,a.Y,a.Z,a.W, 0,0,0,0, 0,0,0,0, 0,0,0,0) * b;
            return new Vector4(tmp.M00, tmp.M01, tmp.M02, tmp.M03);
		}

		public static Vector4 operator *(Matrix44 a, Vector4 b)
		{
            // Returns multiplication of matrix and vector.
            // Calculated using matrix multiplication where from vector b is created matrix
            Matrix44 tmp = a * new Matrix44(b.X,0,0,0, b.Y,0,0,0, b.Z,0,0,0, b.W,0,0,0);
            return new Vector4(tmp.M00, tmp.M10, tmp.M20, tmp.M30);
		}

		#endregion

        #region Transformations

        public static Matrix44 Scale(Vector4 scaleVector)
        {
            // Returns scale matrix.
            return new Matrix44(scaleVector.X,0,0,0, 0,scaleVector.Y,0,0 , 0,0,scaleVector.Z,0, 0,0,0,1);
        }

        public static Matrix44 Translate(Vector4 translateVector)
        {
            // Returns translate matrix.
            return new Matrix44(1,0,0,translateVector.X, 0,1,0,translateVector.Y, 0,0,1,translateVector.Z, 0,0,0,1);
        }

        public static Matrix44 RotateX(double angleDeg)
        {
            // Returns rotation matrix around X axis.
            Double angle = MathEx.DegToRad(angleDeg);
            return new Matrix44(
            	1, 0, 0, 0,
            	0, Math.Cos(angle), -Math.Sin(angle), 0,
            	0, Math.Sin(angle),  Math.Cos(angle), 0,
            	0, 0, 0, 1
            );
        }

        public static Matrix44 RotateY(double angleDeg)
        {
            // Returns rotation matrix around Y axis.
            Double angle = MathEx.DegToRad(angleDeg);
            return new Matrix44(
            	 Math.Cos(angle), 0, Math.Sin(angle), 0,
            	 0, 1, 0, 0,
            	 -Math.Sin(angle), 0, Math.Cos(angle), 0,
            	 0, 0, 0, 1
            );
        }

        public static Matrix44 RotateZ(double angleDeg)
        {
            // Returns rotation matrix around Z axis.
            Double angle = MathEx.DegToRad(angleDeg);
            return new Matrix44(
            	Math.Cos(angle), -Math.Sin(angle), 0, 0,
            	Math.Sin(angle),  Math.Cos(angle), 0, 0,
            	0, 0, 1, 0,
            	0, 0, 0, 1
            );
        }

        #endregion
	}
}

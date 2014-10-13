// Milan Darjanin, 1mAIN, milan.darjanin@gmail.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CG1.Ex01.Mathematics;
using System.Globalization;
namespace CG1.Ex01
{
    public partial class Form1 : Form
    {

        Vector4 U, V, W;

		Matrix44 A, B, C;
        
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Will try to parse String value to Double value.
        /// </summary>
        double Parse(String text)
        {
            Double res = 0;
            // The ToDouble() method rises exception if string is not number, in that case res stays with 0
            // Because I don't need to do special action if Exception is raised, the catch block is empty.
            try {
            	res = Convert.ToDouble(text);
            } catch {}
            return res;
        }

        /// <summary>
        /// Read values from GUI and assign them to Matrices and Vectors from GUI.
        /// </summary>
        void ReadValues()
        {

            A.M00 = Parse(tbA00.Text);
            A.M01 = Parse(tbA01.Text);
            A.M02 = Parse(tbA02.Text);
            A.M03 = Parse(tbA03.Text);
            A.M10 = Parse(tbA10.Text);
            A.M11 = Parse(tbA11.Text);
            A.M12 = Parse(tbA12.Text);
            A.M13 = Parse(tbA13.Text);
            A.M20 = Parse(tbA20.Text);
            A.M21 = Parse(tbA21.Text);
            A.M22 = Parse(tbA22.Text);
            A.M23 = Parse(tbA23.Text);
            A.M30 = Parse(tbA30.Text);
            A.M31 = Parse(tbA31.Text);
            A.M32 = Parse(tbA32.Text);
            A.M33 = Parse(tbA33.Text);

            B.M00 = Parse(tbB00.Text);
            B.M01 = Parse(tbB01.Text);
            B.M02 = Parse(tbB02.Text);
            B.M03 = Parse(tbB03.Text);
            B.M10 = Parse(tbB10.Text);
            B.M11 = Parse(tbB11.Text);
            B.M12 = Parse(tbB12.Text);
            B.M13 = Parse(tbB13.Text);
            B.M20 = Parse(tbB20.Text);
            B.M21 = Parse(tbB21.Text);
            B.M22 = Parse(tbB22.Text);
            B.M23 = Parse(tbB23.Text);
            B.M30 = Parse(tbB30.Text);
            B.M31 = Parse(tbB31.Text);
            B.M32 = Parse(tbB32.Text);
            B.M33 = Parse(tbB33.Text);
			
            U.X = Parse(tbUX.Text);
            U.Y = Parse(tbUY.Text);
            U.Z = Parse(tbUZ.Text);
            U.W = Parse(tbUW.Text);

            V.X = Parse(tbVX.Text);
            V.Y = Parse(tbVY.Text);
            V.Z = Parse(tbVZ.Text);
            V.W = Parse(tbVW.Text);
        }

        /// <summary>
        /// Write values from Matrices and Vectors and assign them back to GUI.
        /// </summary>
        void WriteValues()
        {
            // "F2" parameter specify number of decimal digits in output. In this case 2.
            
            tbWX.Text = W.X.ToString("F2");
            tbWY.Text = W.Y.ToString("F2");
            tbWZ.Text = W.Z.ToString("F2");

            tbC00.Text = C.M00.ToString("F2");
            tbC01.Text = C.M01.ToString("F2");
            tbC02.Text = C.M02.ToString("F2");
            tbC03.Text = C.M03.ToString("F2");
            tbC10.Text = C.M10.ToString("F2");
            tbC11.Text = C.M11.ToString("F2");
            tbC12.Text = C.M12.ToString("F2");
            tbC13.Text = C.M13.ToString("F2");
            tbC20.Text = C.M20.ToString("F2");
            tbC21.Text = C.M21.ToString("F2");
            tbC22.Text = C.M22.ToString("F2");
            tbC23.Text = C.M23.ToString("F2");
             
        }

        /// <summary>
        /// Main function of today's seminar. Will run after we click on button 'Calculate'. 
        /// </summary>
        private void bCalc_Click(object sender, EventArgs e)
        {
            ReadValues();
            
            switch (cbOp.Text) {
            	case "W = U + V": W = U + V; break;
            	case "W = U - V": W = U - V; break;
            	case "W = U % V": W = U % V; break;
            	case "W = U / V": W = U / V; break;
            	case "W = U ^ V": W = U ^ V; break;
            	case "W.X = U * V": W = new Vector4(U * V, 0,0); break;
            	case "W.X = Length(U)": W = new Vector4(U.Length, 0, 0); break;
            	
            	case "C = A + B": C = A + B; break;
            	case "C = A - B": C = A - B; break;
            	case "C = A * B": C = A * B; break;
            	case "C = A.Transposed": C = A.Transposed; break;
            	case "C = A.Inversed": C = A.Inversed; break;
            	case "W.X = A.Determinant": W.X = A.Determinant; break;
            	case "W = A * V": W = A * V; break;
            	case "W = U * B": W = U * B; break;
            	
            	case "C = Matrix44.Translate(U)": C = Matrix44.Translate(U); break;
            	case "C = Matrix44.Scale(U)": C = Matrix44.Scale(U); break;
            	case "C = Matrix44.RotateX(U.X)": C = Matrix44.RotateX(U.X); break;
            	case "C = Matrix44.RotateY(U.X)": C = Matrix44.RotateY(U.X); break;
            	case "C = Matrix44.RotateZ(U.X)": C = Matrix44.RotateZ(U.X); break;
            	
            	default: break;
            }

            WriteValues();
        }
    }
}

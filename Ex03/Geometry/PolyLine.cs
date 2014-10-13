using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CG1.Ex03.Mathematics;
using System.Drawing;

namespace CG1.Ex03.Geometry
{
	public class Vertex
	{
        //Position of vertex
        public Vector4 Position;
	}

	public class PolyLine
	{
        #region Properties

        //Pivot vector of polyline
        public Vector4 Pivot = new Vector4(0, 0, 0, 0);
        
        //Default scale vector
        public Vector4 Scale = new Vector4(1, 1, 1, 1);
        
        //Polyline's vertices
        public List<Vertex> Vertices = new List<Vertex>();

        public double OrientationZDeg = 0;
        public Boolean IsSelected = false;
        
        #endregion

        #region Draw Polyline

        /// <summary>
        /// Draw polyline
        /// </summary>
        /// <param name="a"></param>
        public void Draw(Graphics g)
        {
            Vertex p0 = null;
            double vectorLenght = 40;

            // Transform matrix applied to all points
            Matrix44 transformMatrix = Matrix44.Translate(new Vector4(Pivot.X, Pivot.Y, 0, 1)) * Matrix44.RotateZ(OrientationZDeg) * Matrix44.Scale(Scale);
            
            //ToDo: Apply this new transform matrix to pivot axises
            Vector4 xAxis = transformMatrix * (new Vector4(vectorLenght, 0, 0, 1));
            Vector4 yAxis = transformMatrix * (new Vector4(0, vectorLenght, 0, 1));
			
            //Draw a polyline pivot and two axises in X and Y direction.
            g.DrawLine(Pens.Red, (float)Pivot.X, (float)Pivot.Y, (float)xAxis.X, (float)xAxis.Y);
            g.DrawLine(Pens.Green, (float)Pivot.X, (float)Pivot.Y, (float)yAxis.X, (float)yAxis.Y);
            g.FillEllipse((IsSelected ? Brushes.Yellow : Brushes.Blue), (float)Pivot.X - 6, (float)Pivot.Y - 6, 12, 12);

            //Draw lines of polyline. Be aware because there is one ToDo inside!
            foreach (Vertex v in Vertices)
            {	
            	
            	Vertex p1 = new Vertex();
            	p1.Position = transformMatrix * v.Position;

                if (p0 != null)
                    g.DrawLine(Pens.Black, (float)p0.Position.X, (float)p0.Position.Y, (float)p1.Position.X, (float)p1.Position.Y);
                g.FillEllipse(Brushes.Black, (float)p1.Position.X - 4, (float)p1.Position.Y - 4, 8, 8);

                p0 = p1;
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Add new vertex.
        /// </summary>
        /// <param name="a"></param>
        public void AddVertex(Vector4 point)
        {
            Vertex v = new Vertex();
            //ToDo: Change a position of vertex v to a position of local polyline vertex.
            //      Vertex v is a local vertex of polyline. And polyline is global object of Form1.
            //      So what will be a position of such vertex?
            
			Matrix44 transformMatrix = Matrix44.Scale(new Vector4(1/Scale.X, 1/Scale.Y, 0, 0)) * Matrix44.RotateZ(-OrientationZDeg) * Matrix44.Translate(new Vector4(-Pivot.X, -Pivot.Y, 0, 1));
			v.Position = transformMatrix * point;

            Vertices.Add(v);
        }

        public void TrySelect(Vector4 point)
        {
            // Test if clicked point is near by polyline pivot
            // Try to do this with vectors.
            // If true then set IsSelected.
            int pointRadius = 6;
            if (Pivot.X > point.X - pointRadius && Pivot.X < point.X + pointRadius &&
                Pivot.Y > point.Y - pointRadius && Pivot.Y < point.Y + pointRadius) 
            {
            	IsSelected = true;
            }
        }

        #endregion
	}
}

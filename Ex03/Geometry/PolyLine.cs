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

            //ToDo: Create a transform matrix. This matrix should include all transformations you applied on this polyline. 
            //      Use Pivot, OrientationZDeg and Scale
            Matrix44 transformMatrix = Matrix44.Translate(new Vector4(Pivot.X, Pivot.Y, 0, 1)) * Matrix44.RotateZ(OrientationZDeg) * Matrix44.Scale(Scale);
            
            //ToDo: Apply this new transform matrix to pivot axises
            Vector4 xAxis = new Vector4(40, 0, 0, 1);
            Vector4 yAxis = new Vector4(0, 40, 0, 1);
            
            xAxis = transformMatrix * xAxis;
            yAxis = transformMatrix * yAxis;
			
            //Draw a polyline pivot and two axises in X and Y direction.
            g.DrawLine(Pens.Red, (float)Pivot.X, (float)Pivot.Y, (float)xAxis.X, (float)xAxis.Y);
            g.DrawLine(Pens.Green, (float)Pivot.X, (float)Pivot.Y, (float)yAxis.X, (float)yAxis.Y);
            g.FillEllipse((IsSelected ? Brushes.Yellow : Brushes.Blue), (float)Pivot.X - 6, (float)Pivot.Y - 6, 12, 12);

            //Draw lines of polyline. Be aware because there is one ToDo inside!
            foreach (Vertex v in Vertices)
            {	
            	
            	Vertex p1 = new Vertex();
            	p1.Position.X = v.Position.X;
            	p1.Position.Y = v.Position.Y;

                //ToDo: Use transform matrix to transform position of each polyline's vertex

                Vector4 tmp = transformMatrix * p1.Position;
                
                p1.Position.X = tmp.X;
                p1.Position.Y = tmp.Y;
                
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
			v.Position.X = point.X - Pivot.X;
			v.Position.Y = point.Y - Pivot.Y;			
			
            Vertices.Add(v);
        }

        public void TrySelect(Vector4 point)
        {
            // Ttest if clicked point is near by polyline pivot
            // Try to do this with vectors.
            // If true then set IsSelected.
            int threshold = 6;
            if (Pivot.X > point.X - threshold && Pivot.X < point.X + threshold &&
                Pivot.Y > point.Y - threshold && Pivot.Y < point.Y + threshold) {
            	IsSelected = true;
            }
        }

        #endregion
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CG1.Ex04.Mathematics;
using CG1.Ex04.Geometry;

namespace CG1.Ex04.Clipping
{
    public class CyrusBeck
    {
        #region Properties

        //Info: Copy lines from GUI to clipping algorithm
        public List<Line> Lines { get; set; }

        #endregion

        #region Clipping Methods

        //ToDo: Implement C-B clipping algorithm. Create you own methods etc. Use Line.cs, Polygon.cs and Vector4.cs. Comment you solution
        //      You should copy lines to local Lines - clip them and then return already clipped lines.
        //      As materials you can use your lectures > http://goo.gl/SuqxS
        //                               or additional materials > http://goo.gl/3kVUD

        public List<Line> StartClipping(Polygon Poly, List<Line> lines)
        {
            //Info: Copy lines from GUI to clipping algorithm
            Lines = new List<Line>(lines);
            List<Line> outputLines = new List<Line>();
            //ToDo: Here the algorithm could start
            foreach (Line line in Lines)
            {
            	outputLines.Add(CyrusBeckAlg(line.v0.X, line.v0.Y, line.v1.X, line.v1.Y, Poly));
            }

            return outputLines;
        }
        
        private Line CyrusBeckAlg(Double x0, double y0, double x1, double y1, Polygon Poly)
        {
        	double t0 = 0, t1 = 1;
			double t, dq, d1;
			Vector4 directionSegment = new Vector4(x1-x0,y1-y0,0,0);
			Vector4 edge;
			
			bool clockwise = isClockwise(Poly);

        	foreach(Line line in Poly.Lines){

				if(clockwise) // base on orientation set the vector for edge
					edge = new Vector4(line.v0.X - line.v1.X, line.v0.Y - line.v1.Y,0,0);
				else
					edge = new Vector4(line.v1.X - line.v0.X, line.v1.Y - line.v0.Y,0,0);
				
				dq = dotProduct(edge, new Vector4(x0-line.v0.X,y0-line.v0.Y,0,0));
				d1 = -dotProduct(edge, directionSegment);

        		t = dq / d1;

        		if (d1 < 0) // in-to-out case
        		{
					t0 = Math.Max(t, t0);
        		}
        		else // out-to-in case
        		{
        			t1 = Math.Min(t, t1);
        		}
        	}

			// if t1 > t0 return line from start calculated with t0 and end calculated with t1
			if(t0 < t1)
       			return new Line(
					new Vector4(x0 + t0*directionSegment.X, y0 + t0*directionSegment.Y,0,0),
					new Vector4(x0 + t1*directionSegment.X, y0 + t1*directionSegment.Y,0,0)
				);
       		else
       			return new Line(new Vector4(0,0,0,0),new Vector4(0,0,0,0));
        }
        
        
        private double dotProduct(Vector4 u, Vector4 v)
        {
        	return ((u.X * v.Y) - (u.Y * v.X));
        }
        
        private bool isClockwise(Polygon Poly)
        {
        	double sum = 0;
        	
        	foreach (Line line in Poly.Lines)
        	{
        		sum += ((line.v1.X - line.v0.X) * (line.v1.Y + line.v0.Y));
        	}
        	
        	return sum > 0 ? true : false;
        }


        #endregion
    }
}


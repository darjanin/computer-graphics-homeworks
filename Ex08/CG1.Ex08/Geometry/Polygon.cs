using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CG1.Ex08.Mathematics;
using CG1.Ex08.Rasterization;
using CG1.Ex08.Geometry;
using System.Drawing;

namespace CG1.Ex08.Geometry
{
	public class Polygon {

        //Info: Properties from last exercises - clipping
        public bool Closed = false;
        private List<Edge> Edges = new List<Edge>();
        private Vector4 Prev = new Vector4(-1, -1, -1);
        private Vector4 First;

		// SLEdge (ScanLineEdge) contains informations important for Scan Line algorithm        
        public class SLEdge {
            public double xMin;
            public double yMax;
            public double yMin;
            public double slope;

            public SLEdge(double xMin, double yMax, double yMin, double slope)
            {
                this.xMin = xMin;
                this.yMax = yMax;
                this.yMin = yMin;
                this.slope = slope;
            }
        }

		public void TryAddVertex(Vector4 point)
		{
            if(Prev.X == -1)
            {
                First = point;
                Prev = point;
            }
            else
            {
                Vector4 d = point - First;
                if (d.Length < 5)
                {
                    Edge e = new Edge(Prev, First);
                    Edges.Add(e);
                    Closed = true;
                    Prev = new Vector4(-1, -1, -1);
                }
                else
                {
                    Edge e = new Edge(Prev, point);
                    Edges.Add(e);
                    Prev = point;
                }
            }
		}
		
        public void Scan(Bitmap Image)
        {
            //ToDo: Implement scanline algorithm
            //Info: Here you can start to scan the polygon
            
            List<SLEdge> TE = new List<SLEdge>(); // Table of edges
            List<SLEdge> TAE = new List<SLEdge>(); // Table of active edges
            int yMin = 999;

            foreach (Edge e in Edges)
            {
                if (!e.horizontal)
                {
                    TE.Add(new SLEdge(e.xMin, e.yMax, e.yMin, e.slope));
                    if (e.yMin < yMin)
                        yMin = e.yMin;
                }
            }
            
            int y = yMin; // starting scanline is set to minimal y coordinate
            
            while (TE.Count > 0 || TAE.Count > 0) {
            	
                foreach (SLEdge e in TE.ToList()) {
                    if (e.yMin == y) {
                        TAE.Add(e);
                        TE.Remove(e);
                    }
                }
            	
                TAE.Sort(sortByX); // sort TAS by x
                
                bool isInside = false; // if true than this part will be drawn
                int begin = 0; // from which x start to fill line
                
                foreach (SLEdge e in TAE) {
                	if (!isInside) {
                		begin = (int) Math.Round(e.xMin);
                		isInside = true;
                	}
                	else {
                		// fill line from begin to pixel (both contains x coordinates) on y line
                		for (var pixel = begin; pixel < e.xMin; pixel++) {
                			SetPixel(Image, pixel, y);
                		}
                		isInside = false;
                	}
                }
                
                // delete not required lines from the TAS
                foreach (SLEdge e in TAE.ToList())
                {
                    if (e.yMax <= y+1)
                        TAE.Remove(e);
                    else
                        e.xMin += e.slope;
                }
                
                // move to the next scanline
                y++;
            }
        }

        private int sortByX(SLEdge a, SLEdge b)
        {
        	if (a.xMin == b.xMin) return 0;
        	return a.xMin > b.xMin ? 1 : -1;
        }
        
		public void Draw(Bitmap Image)
		{
            foreach (Edge e in Edges)
                e.Draw(Image);
		}
		
		protected void SetPixel(Bitmap g, int x, int y)
        {
            g.SetPixel(x, y, Color.Salmon);
        }
	}
}
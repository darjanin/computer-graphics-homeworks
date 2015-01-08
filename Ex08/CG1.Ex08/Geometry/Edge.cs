using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CG1.Ex08.Mathematics;
using CG1.Ex08.Rasterization;
using System.Drawing;

namespace CG1.Ex08.Geometry
{
    public class Edge 
    {
        public Vector4 v1;
        public Vector4 v2;
        //ToDo: Define also other edge properties - due to scanline algorithm
		public int yMax;
		public int yMin;
		public int xMin;
		public int xMax;
		public Double slope;
		public bool horizontal; // is edge horizontal?
        
        Line line = new Line();

        public Edge(Vector4 p1, Vector4 p2) 
        {
            v1 = p1;
            v2 = p2;
            //ToDo: Initialize an edge properties - due to algorithm
            yMax = p1.Y > p2.Y ? (int)p1.Y : (int)p2.Y;
            yMin = p1.Y < p2.Y ? (int)p1.Y : (int)p2.Y;
            xMin = p1.Y < p2.Y ? (int)p1.X : (int)p2.X;
            xMax = p1.Y > p2.Y ? (int)p1.X : (int)p2.X;
            slope = (p1.X - p2.X) / (p1.Y - p2.Y);
            horizontal = p1.Y == p2.Y ? true : false;
        }

        public void Draw(Bitmap Image)
        {
            //Info: You should rasterize each edge - due to flood algorithms
            line.RasterizeLineBresenham(Image, (int)v1.X, (int)v1.Y, (int)v2.X, (int)v2.Y);
        }
        
    }
}
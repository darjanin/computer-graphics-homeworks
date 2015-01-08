using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CG1.Ex07.Rasterization
{
    public class Ellipse
    {
        //Info: Internal representation for center of ellipse.
        public Int32 X0;
        public Int32 Y0;
        
        private Int32 CellSize;
        private Graphics g;

        //Info: As always - you can generate your own functions or change the template if necessary.
        public void BresenEllipse(Graphics g, Int32 CellSize, Int32 x0, Int32 y0, Int32 dx, Int32 dy)
        {
            //ToDo: Implement Bresenham algorithm for rasterization of ellipse.
            //Ellipse is not symmetric in all 4 axises!
            this.CellSize = CellSize;
            this.g = g;
            
            int cx = x0;
            int cy = y0;
            int RadiusX = dx;
            int RadiusY = dy;
            int DoubleSquareX = 2 * RadiusX * RadiusX;
           	int DoubleSquareY = 2 * RadiusY * RadiusY;
           	
           	int x = RadiusX;
            int y = 0;
           	int ChangeX = RadiusY * RadiusY * (1 - 2 * RadiusX);
           	int ChangeY = RadiusX * RadiusX;
            int StoppingX = DoubleSquareY * RadiusX;
          	int StoppingY = 0;
            int EllipseError = 0;
            
            while (StoppingX > StoppingY)
            {
            	Fill4Parts(x, y, cx, cy);
            	
            	y++;
            	StoppingY += DoubleSquareX;
            	EllipseError += ChangeY;
            	ChangeY += DoubleSquareX;
            	
            	if ((2 * EllipseError + ChangeX) > 0)
            	{
            		x--;
            		StoppingX -= DoubleSquareY;
            		EllipseError += ChangeX;
            		ChangeX += DoubleSquareY;
            	}
            }
            
            x = 0;
            y = RadiusY;
            ChangeX = RadiusY * RadiusY;
            ChangeY = RadiusX * RadiusX * (1 - 2 * RadiusY);
            StoppingX = 0;
            StoppingY = DoubleSquareX * RadiusY;
			
            while (StoppingX < StoppingY)
            {
            	Fill4Parts(x, y, cx, cy);
            	
            	x++;
            	StoppingX += DoubleSquareY;
            	EllipseError += ChangeX;
            	ChangeX += DoubleSquareY;
            	
            	if ((2 * EllipseError + ChangeY) > 0)
            	{
            		y--;
            		StoppingY -= DoubleSquareX;
            		EllipseError += ChangeY;
            		ChangeY += DoubleSquareX;
            	}
            }
            
            
        }
        
        private void Fill4Parts(Int32 x, Int32 y, Int32 cx, Int32 cy)
	    {
        	SolidBrush brush = new SolidBrush(Color.Black);
        	g.FillRectangle(brush, (cx + x) * CellSize, (cy + y) * CellSize, CellSize, CellSize);
        	g.FillRectangle(brush, (cx - x) * CellSize, (cy + y) * CellSize, CellSize, CellSize);
        	g.FillRectangle(brush, (cx - x) * CellSize, (cy - y) * CellSize, CellSize, CellSize);
        	g.FillRectangle(brush, (cx + x) * CellSize, (cy - y) * CellSize, CellSize, CellSize);
	    }
    }
}

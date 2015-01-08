using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CG1.Ex07.Rasterization
{
    public class Circle
    {
        //Info: Internal representation for center of circle.
        public Int32 X0;
        public Int32 Y0;
        
        private Int32 CellSize;
        private Graphics g;

        //Info: As always - you can generate your own functions or change the template if necessary.
        public void MidpointCircle(Graphics g, Int32 CellSize, Int32 r, Int32 x0, Int32 y0)
        {
            //ToDo: Implement Midpoint algorithm for rasterization of circle.
            //      You can change the implementation to Bresenham algorithm if you want.
            this.CellSize = CellSize;
            this.g = g;
            
            int x = r;
            int y = 0;
            int RadiusError = 1 - x;
            
            while (x >= y)
            {
            	Fill( x + x0,  y + y0);
            	Fill( y + x0,  x + y0);
            	Fill( x + x0, -y + y0);
            	Fill( y + x0, -x + y0);
            	Fill(-x + x0,  y + y0);
            	Fill(-y + x0,  x + y0);
            	Fill(-x + x0, -y + y0);
            	Fill(-y + x0, -x + y0);
            	
            	y++;
            	
            	if (RadiusError < 0)
            		RadiusError += 2 * y + 1;
            	else
            	{
            		x--;
            		RadiusError += 2 * (y - x + 1);
            	}
            }
        }
        
        private void Fill(Int32 x, Int32 y)
	    {
        	g.FillRectangle(new SolidBrush(Color.Black), x * CellSize, y * CellSize, CellSize, CellSize);
	    }
    }
}

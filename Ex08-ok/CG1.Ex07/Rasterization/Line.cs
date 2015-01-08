using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CG1.Ex07.Rasterization
{
    class Line
    {
        //Info: Internal representation for cell size.
        public Int32 CS;

        //Info: As always - you can generate your own functions or change the template if necessary.
        public void RasterizeLineBresenham(Graphics g, int x0, int y0, int x1, int y1, Int32 CellSize)
        {
        	int dx = Math.Abs(x1 - x0);
        	int dy = -Math.Abs(y1 - y0);
        	int sx = x0 < x1 ? 1 : -1;
        	int sy = y0 < y1 ? 1 : -1;
        	
        	int error = dx + dy;
        	int error2;
        	
        	while (true)
        	{
        		g.FillRectangle(
        			new SolidBrush(Color.Black),
        			x0 * CellSize,
        			y0 * CellSize,
        			CellSize, CellSize
        		);
        		
        		if (x0 == x1 && y0 == y1)
        			break;
        		
        		error2 = 2 * error;
        		
        		if (error2 > dy)
        		{
        			error += dy;
        			x0 += sx;
        		}
        		
        		if (error2 < dx)
        		{
        			error += dx;
        			y0 += sy;
        		}
        	}
        }
        
    }
}

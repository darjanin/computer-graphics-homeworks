using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CG1.Ex04.Mathematics;
using CG1.Ex04.Geometry;

namespace CG1.Ex04.Clipping
{
    class CohenSutherland
    {
        #region Properties

        //Info: Binary constants
        byte TOP = 1, BOTTOM = 2, RIGHT = 4, LEFT = 8;

        //Info: Clipping polygon min and max
        double xmin = 0, ymin = 0, xmax = 0, ymax = 0;

        //Info: Copy lines from GUI to clipping algorithm
        public List<Line> Lines { get; set; }

        #endregion

        #region Clipping Methods

        //ToDo: Implement C-S clipping algorithm. Create you own methods etc. Use Line.cs and Vector4.cs. Comment you solution
        //      You should copy lines to local Lines - clip them and then return already clipped lines.
        //      As materials you can use your lectures > http://goo.gl/SuqxS
        //                               or additional materials > http://goo.gl/3kVUD

        public List<Line> StartClipping(Point StartPoint, Point EndPoint, List<Line> lines)
        {
            //Info: Set min and max values
            xmax = (StartPoint.X > EndPoint.X) ? StartPoint.X : EndPoint.X;
            xmin = (StartPoint.X < EndPoint.X) ? StartPoint.X : EndPoint.X;
            ymax = (StartPoint.Y > EndPoint.Y) ? StartPoint.Y : EndPoint.Y;
            ymin = (StartPoint.Y < EndPoint.Y) ? StartPoint.Y : EndPoint.Y;

            //Info: Copy lines from GUI to clipping algorithm
            Lines = new List<Line>(lines);

            List<Line> outputLines = new List<Line>();

            foreach (Line line in Lines) {
            	outputLines.Add(CohanSutherlandAlg(line.v0.X, line.v0.Y, line.v1.X, line.v1.Y));
            }

            return outputLines;
        }
        
        private Line CohanSutherlandAlg(double x0, double y0, double x1, double y1)
        {
        	byte code0 = code(x0, y0);
        	byte code1 = code(x1, y1);
        	
        	double x = 0, y = 0;
        	
        	while (code0 != 0 || code1 != 0) 
        	{
        		if ((code0 & code1) != 0) 
        		{
        			x0=0;y0=0;
        			x1=0;y1=0;
        			break;
        		}
        		
    			byte codeOut = code0 != 0 ? code0 : code1;
    			
    			if ((codeOut & TOP) != 0) // test if intersect with top edge
    			{
    				x = x0 + (x1 - x0) * (ymin - y0) / (y1 - y0);
    				y = ymin;
    			}
    			else if ((codeOut & BOTTOM) != 0) // test if intersect with bottom edge
    			{
    				x = x0 + (x1 - x0) * (ymax - y0) / (y1 - y0);
    				y = ymax;
    			}
    			else if ((codeOut & RIGHT) != 0) // test if intersect with right edge
    			{
    				y = y0 + (y1 - y0) * (xmax - x0) / (x1 - x0);
    				x = xmax;
    			}
    			else if ((codeOut & LEFT) != 0) // test if intersect with left edge
    			{
    				y = y0 + (y1 - y0) * (xmin - x0) / (x1 - x0);
    				x = xmin;
    			}
    			
    			if (codeOut == code0) 
    			{
    				x0 = x;
    				y0 = y;
    				code0 = code(x0, y0);
    			} 
    			else 
    			{
    				x1 = x;
    				y1 = y;
    				code1 = code(x1, y1);
    			}
        	}

        	return new Line(new Vector4(x0, y0, 0, 0), new Vector4(x1, y1, 0, 0));
        	
        }
        
        
        private byte code(double x, double y) {
        	// calculate code for segment in which is point[x,y]
        	byte result = 0;
        	
        	if (x < xmin)
        		result |= LEFT;
        	else if (x > xmax)
        		result |= RIGHT;
        	if (y < ymin)
        		result |= TOP;
        	else if (y > ymax)
        		result |= BOTTOM;
        	
        	return result;
        }
       	

        #endregion
    }
}

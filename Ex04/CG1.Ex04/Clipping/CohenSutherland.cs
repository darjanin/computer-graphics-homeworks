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
            //ToDo: Here the algorithm could start
            Line tmpLine;
            foreach (Line line in Lines) {
            	tmpLine = magic(line);
            	if (tmpLine != null) {
            		tmpLine.allClipped = true;
            		outputLines.Add(tmpLine);
            	}
            }

            return outputLines;
        }
        
        private Line magic(Line inputLine) {
        	byte c1 = 0, c2 = 0, tmpByte;
        	double tmpInt;
        	
        	Line outputLine = inputLine;
        	
        	c2 = code(outputLine.v1.X, outputLine.v1.Y);
        	while (true) {
        		c1 = code(outputLine.v0.X, outputLine.v0.Y);
        	
        		if ((c1 & c2) != 0) return null;
        		else if ((c1 | c2) == 0) return outputLine;
        		else {
        			if (c1 == 0) {
        				// here comes swap of values
        				tmpInt = outputLine.v0.X; outputLine.v0.X = outputLine.v1.X; outputLine.v1.X = tmpInt;
        				tmpInt = outputLine.v0.Y; outputLine.v0.Y = outputLine.v1.Y; outputLine.v1.Y = tmpInt;
        				tmpByte = c1; c1 = c2; c2 = tmpByte;
        			} else if (c1 == 1 || c1 == 5 || c1 == 9) {
			           	outputLine.v0.X = outputLine.v0.X + (outputLine.v1.X-outputLine.v0.X) * (ymax - outputLine.v0.Y) / (outputLine.v1.Y - outputLine.v0.Y);
			           	outputLine.v0.Y = ymax;
        			} else if (c1 == 2 || c1 == 6 || c1 == 10) {
			           	outputLine.v0.X = outputLine.v0.X + (outputLine.v1.X-outputLine.v0.X) * (ymin - outputLine.v0.Y) / (outputLine.v1.Y - outputLine.v0.Y);
			           	outputLine.v0.Y = ymin;
        			} else if (c1 == 4 || c1 == 5 || c1 == 6) {
			           	outputLine.v0.Y = outputLine.v0.Y + (outputLine.v1.Y-outputLine.v0.Y) * (xmax - outputLine.v0.X) / (outputLine.v1.X - outputLine.v0.X);
			           	outputLine.v0.X = xmax;
        			} else if (c1 == 8 || c1 == 9 || c1 == 10) {
			           	outputLine.v0.Y = outputLine.v0.Y + (outputLine.v1.Y-outputLine.v0.Y) * (xmin - outputLine.v0.X) / (outputLine.v1.X - outputLine.v0.X);
			           	outputLine.v0.X = xmin;
        			}
        		}
        	}
        	
        }
        
        
        private byte code(double x, double y) {
        	byte result = 0;
        	if (x < xmin) result |= LEFT;
        	else if (x > xmax) result |= RIGHT;
        	if (y < ymin) result |= TOP;
        	else if (y > ymax) result |= BOTTOM;
        	return result;
        }
       	

        #endregion
    }
}

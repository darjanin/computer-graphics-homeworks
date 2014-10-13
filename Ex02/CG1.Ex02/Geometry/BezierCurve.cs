using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CG1.Ex02.Mathematics;
using System.Drawing;

namespace CG1.Ex02.Geometry
{
    //ToDo: Implement all 'ToDo' statements. 
    //      Example resource for Bezier Curve is f.e. http://goo.gl/5HQFX
    //      Example resource for DeCasteljau algorithm is f.e. http://goo.gl/3oFla
    public class BezierCurve
    {
        public class Point
        {
            public Vector4 Position;
            public bool Selected;

            /// <summary>
            /// Creates a new Point with position. Point can be a ControlPoint or a CurvePoint. Also it can be selected / active.
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <param name="c"></param>
            /// <returns></returns>
            public Point(Vector4 pos, bool sel, bool con)
            {
                Position = pos;
                Selected = sel;
            }
        }

        #region Properties
        
        //For simpler maintenance of points you can use these two Lists.
        public List<Point> ControlPoints = new List<Point>();
        public List<Point> CurvePoints = new List<Point>();

        #endregion

        #region Draw Methods

        /// <summary>
        /// Will draw all control points and all curve lines.
        /// </summary>
        /// <param name="a"></param>
        public void Draw(Graphics g)
        {
            //ToDo: Implement drawing of curve's control points. You can use foreach
            //      And at a same time, you can draw lines of control polygon.
            //      For drawing a polygon you can maintain a Point p0 and test each pair of points. 
            //      Also, try to use different color of point for selected and not selected Points. (Should be similar to the sample application)
            Point p0 = null;
            
            Pen ControlPointPen = new Pen(Color.Navy);
            Pen ControlPointSelectedPen = new Pen(Color.Red);
            Pen ControlLinePen = new Pen(Color.Blue);
            Pen ActivePointPen = ControlPointPen;
            
            float radius = 5;
            
            foreach (Point ControlPoint in ControlPoints) {
            	if (p0 == null) {
            		p0 = ControlPoint;
            	} else {
            		g.DrawLine(ControlLinePen, (float) p0.Position.X, (float) p0.Position.Y, (float) ControlPoint.Position.X, (float) ControlPoint.Position.Y);
            		p0 = ControlPoint;
            	}
            	
            	ActivePointPen = ControlPoint.Selected ? ControlPointSelectedPen : ControlPointPen;
            	g.DrawEllipse(ActivePointPen,(float) ControlPoint.Position.X-radius,(float) ControlPoint.Position.Y-radius,radius*2,radius*2);
            }
            
            ControlLinePen = new Pen(Color.Black);
            Point p0Curve = null;
            if (CurvePoints.Count > 1) {
            	foreach (Point ControlPoint in CurvePoints) {
	            	if (p0Curve == null) {
	            		p0Curve = ControlPoint;
	            	} else {
	            		g.DrawLine(ControlLinePen, (float) p0Curve.Position.X, (float) p0Curve.Position.Y, (float) ControlPoint.Position.X, (float) ControlPoint.Position.Y);
	            		p0Curve = ControlPoint;
	            	}
            	}
            }
           

            //ToDo: Implement drawing of curve itself. 
        }
        
        #endregion

        #region Computation

        /// <summary>
        /// Will compute curve's points. Number of points is due to quality of sampling
        /// </summary>
        /// <param name="a"></param>
        public void Casteljau(Double quality)
        {
            //ToDo: Implement De Casteljau algorithm in your own way.
            //      You can use few foreach runs or you can use recursion.
            //      There are quite a few different implementations - use a wiki or another resource if you must.
            //      Maybe you will need more than one function. Create it.
            CurvePoints.Clear();
            	Double qualityPart = 1/quality;
        		for (Double t = 0; t <= 1; t += qualityPart) {
           	 		//CurvePoints.Add(B(t));
           	 		List<Point> tmp = new List<Point>();
           	 		
		    		foreach (Point ControlPoint in ControlPoints) {	
           	 			tmp.Add(new Point(new Vector4(ControlPoint.Position.X,ControlPoint.Position.Y,0,0), ControlPoint.Selected, false));
			        }
			        for (int j = 1; j < tmp.Count; j++) {
		    			for (int i = 0; i < tmp.Count - j; i++) {
           	 				tmp[i].Position.X = (tmp[i].Position.X + t*(tmp[i+1].Position.X - tmp[i].Position.X));
           	 				tmp[i].Position.Y = (tmp[i].Position.Y + t*(tmp[i+1].Position.Y - tmp[i].Position.Y));
			            }
			        }
           	 		CurvePoints.Add(tmp[0]);
			        //return tmp.get(0);
        		
        		//points.add(controlPoints.get(controlPoints.size()-1));
        		//return true;
        	}
            	CurvePoints.Add(ControlPoints.Last());
    	}
        #endregion

        #region Helper Methods

        /// <summary>
        /// Will add another control point.
        /// </summary>
        /// <param name="a"></param>
        public void AddControlPoint(Vector4 point)
        {
            //ToDo: Implement this method.
            foreach (Point ControlPoint in ControlPoints) {
            	ControlPoint.Selected = false;
            }
            ControlPoints.Add(new Point(point, false, true));
        }

        /// <summary>
        /// Will deleted selected / active control point.
        /// </summary>
        /// <param name="a"></param>
        public void DeletePoint()
        {
            //ToDo: Implement deletion of a control point. 
            //      In c# you should ad first find a point, which should be deleted. And then delete it.
            //      Remember, you can do these operations only on control points of Bezier curve.
            Point PointToRemove = new Point(Vector4.Zero, false, true);
            foreach (Point ControlPoint in ControlPoints) {
            	if (ControlPoint.Selected) {
            		PointToRemove = ControlPoint;
            	}
            }
            ControlPoints.Remove(PointToRemove);

        }

        /// <summary>
        /// Will update a position of selected / active control point to new 'point'.
        /// </summary>
        /// <param name="a"></param>
        public void UpdatePoint(Vector4 point)
        {
            //ToDo: Implement this method
            foreach (Point ControlPoint in ControlPoints) {
            	if (ControlPoint.Selected) {
            		ControlPoint.Position.X = point.X;
            		ControlPoint.Position.Y = point.Y;
            	}
            }
            
        }

        /// <summary>
        /// Will return true if some point can be selected. At a same time this point should become selected.
        /// </summary>
        /// <param name="a"></param>
        public bool SetActive(Vector4 point)
        {
        	int threshold = 10;
            //ToDo: Implement this method
            foreach (Point ControlPoint in ControlPoints) {
            	ControlPoint.Selected = false;
            }
            
            foreach (Point ControlPoint in ControlPoints) {
            	bool IsTheOne = 
            		ControlPoint.Position.X < point.X+threshold &&
            		ControlPoint.Position.X > point.X-threshold &&
            		ControlPoint.Position.Y < point.Y+threshold &&
            		ControlPoint.Position.Y > point.Y-threshold;
            	if (IsTheOne) {
            		ControlPoint.Selected = true;
            		return true;
            	}
            }
            return false;
        }

        public void AllClear()
        {
            ControlPoints.Clear();
            CurvePoints.Clear();
        }

        #endregion
    }
}


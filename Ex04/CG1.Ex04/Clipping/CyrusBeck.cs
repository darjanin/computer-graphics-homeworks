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

            //ToDo: Here the algorithm could start


            return Lines;
        }


        #endregion
    }
}


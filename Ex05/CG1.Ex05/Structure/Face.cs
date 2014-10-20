using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Drawing;
using CG1.Ex05.Mathematics;

namespace CG1.Ex05.Structure
{
    public class MeshFace
    {
        #region Properties

        /// <summary>
        /// One of the Bounding half edges.
        /// </summary>
        public HalfEdge Edge { get; set; }

        /// <summary>
        /// Center point of face. Maintained just for picking.
        /// </summary>
        private Vector4 center;

        /// <summary>
        /// Maintained just for picking.
        /// </summary>
        public Boolean IsSelected;

        #endregion

        #region Get and Set Methods

        public Vector4 Center
        {
            get { return center; }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Geometric center of standard convex polygon without holes.
        /// </summary>
        public void SetCenter()
        {
            center = new Vector4(0, 0, 0);
            //ToDo: Compute geometric center of polygon.
            //      You can go through all vertices of polygon and compute. 
            //      Remember that vertices of polygon are at a same time vectors - you can use operations for vectors.
            //Hint: Add all polygon vertices and then divide them by number of polygon vertices
            //      You can use method Vertices
            int count = 0;
        }

        /// <summary>
        /// Return all vertices of polygon as Points. You can use it during drawing and during computation of polygon's center.
        /// </summary>
        public IEnumerable<Point> Vertices()
        {
            //ToDo: Return all vertices of current face. Use navigation theory of half-edge data structure.
            //      You should return them as Points - used in drawing of polygon in method Draw(Graphics g).
            yield return new Point();
        }

        #endregion
    }
}

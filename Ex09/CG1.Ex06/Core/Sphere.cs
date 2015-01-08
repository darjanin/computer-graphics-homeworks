using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CG1.Ex06.Core 
{
    public class Sphere
    {
        public double x, y, z, r;
        public Color color;

        public Sphere(double x, double y, double z, double r, Color color) 
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.r = r;
            this.color = color;
        }

        /// <summary>
        /// This is used in two ways. 
        /// First it returns if clicked point is in the sphere projection / sphere is selected. 
        /// Second it returns if pixel in zBuffer[i, j] is in the sphere.
        /// </summary>
        public bool Selected(double x, double y) 
        {
            // ToDo: Return distance from center of the sphere and if it is less than sphere's radius
            if (Math.Sqrt((x-this.x) * (x-this.x) + (y-this.y) * (y-this.y)) > r) return false;
            return true;
        }

        /// <summary>
        /// Compute Z coordinate for XY coordinates
        /// </summary>
        public double FrontZforXY(double x, double y) 
        {
            // ToDo: Return z coor for known x and y
            // Hint: You can use steps and equations from the seminar
            return this.z - Math.Sqrt(r*r - (x-this.x)*(x-this.x) - (y-this.y)*(y-this.y));

        }

        /// <summary>
        /// Compute color of the pixel with coordinates x, y
        /// </summary>
        public Color ColorAt(double x, double y, bool shading) 
        {
            // ToDo: Return color at curtain x and y due to shading
            // ToDo: Colors are: BG black, flat sphere color, and shaded sphere color
            return Color.Black;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CG1.Ex06.Core 
{
    public class BufferRecord 
    {
        public double depth;
        public Color color;

        public BufferRecord() 
        {
            Clear();            
        }

        /// <summary>
        /// Clear buffer
        /// </summary>
        public void Clear() 
        {
            this.depth = double.PositiveInfinity;
            this.color = Color.Black;
        }

        /// <summary>
        /// Update buffer in case when there is an object closer to a camera
        /// </summary>
        public void Update(double newDepth, Color newColor) 
        {
            // ToDo: Compare depth and newDepth and update color acordingly
            if (newDepth < depth)
            {
            	depth = newDepth;
            	color = newColor;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CG1.Ex06.Core
{
    class World
    {
        #region Properties

        private BufferRecord[,] zBuffer = new BufferRecord[50, 50];
        private Bitmap Image = new Bitmap(50, 50);

        public List<Sphere> spheres = new List<Sphere>() {
        new Sphere(30, 30, 5, 12, Color.Red), 
        new Sphere(20, 20, 10, 20, Color.LimeGreen)
        };

        private Double PixelSize = 10;

        #endregion

        #region Init

        public World(Double pixelSize) 
        {
            PixelSize = pixelSize;
            InitBufferes();
        }

        /// <summary>
        /// Initialize the buffer
        /// </summary>
        public void InitBufferes()
        {
            for (int i = 0; i < 50; i++)
                for (int j = 0; j < 50; j++)
                    zBuffer[i, j] = new BufferRecord();
        }

        /// <summary>
        /// Clear the buffer
        /// </summary>
        public void ClearBuffers(Graphics g)
        {
            g.FillRectangle(Brushes.Black, 0, 0, Image.Width, Image.Height);

            for (int i = 0; i < 50; i++)
                for (int j = 0; j < 50; j++)
                    zBuffer[i, j].Clear();
        }

        #endregion

        #region Rendering

        /// <summary>
        /// Render the scene. Render all objects to buffer.
        /// Set buffer pixels to image.
        /// Draw object's centers.
        /// </summary>
        public void RenderScene(Graphics g, bool shading)
        {
            // ToDo: Render each sphere in the scene
            // Hint: You can use a bounding object to render only sphere's pixels.
            //       Go through all pixels and if the pixel[i,j] is in the sphere range, compute z-coor. and update
            // ToDo: Set buffer pixels to image
            foreach (Sphere sphere in spheres)
            	for (int x = 0; x < 50; x++)
                	for (int y = 0; y < 50; y++)
            			zBuffer[x, y].Update(sphere.FrontZforXY(x, y),sphere.color);
            
            for (int i = 0; i < 50; i++)
                for (int j = 0; j < 50; j++)
                    Image.SetPixel(i, j, zBuffer[i, j].color);

            // Info: Draw sphere's centers
            g.DrawImage(Image, 0, 0, (int)PixelSize * Image.Width, (int)PixelSize * Image.Height);

            foreach (Sphere sphere in spheres)
            {
                g.FillEllipse(new SolidBrush(sphere.color), (int)(PixelSize * sphere.x - 5), (int)(PixelSize * sphere.y - 5), 10, 10);
                g.DrawEllipse(Pens.Black, (int)(PixelSize * sphere.x - 5), (int)(PixelSize * sphere.y - 5), 10, 10);
            }
        }

        #endregion
    }
}

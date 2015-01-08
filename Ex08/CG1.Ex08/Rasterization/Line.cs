using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CG1.Ex08.Rasterization
{
    class Line
    {
        public void RasterizeLineBresenham(Bitmap Image, int x0, int y0, int x1, int y1)
        {
            int dx = x1 - x0;
            int dy = y1 - y0;
            SetPixel(Image, x0, y0);
            if (Math.Abs(dx) >= Math.Abs(dy))
            {
                int x = x0, xinc = dx > 0 ? 1 : -1;
                float y = y0, yinc = (float)dy / dx * xinc;
                while (x != x1)
                {
                    x += xinc;
                    y += yinc;
                    SetPixel(Image, x, (int)Math.Round(y));
                }
            }
            else
            {
                int y = y0, yinc = dy > 0 ? 1 : -1;
                double x = x0, xinc = (double)dx / dy * yinc;
                while (y != y1)
                {
                    x += xinc;
                    y += yinc;
                    SetPixel(Image, (int)Math.Round(x), y);
                }
            }
        }

        protected void SetPixel(Bitmap g, int x, int y)
        {
            g.SetPixel(x, y, Color.Black);
        }
    }
}

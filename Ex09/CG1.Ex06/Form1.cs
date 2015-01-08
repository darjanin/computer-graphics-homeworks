using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CG1.Ex06.Core;

namespace CG1.Ex06
{
    public partial class Form1 : Form
    {
        public Double PixelSize = 10;
       
        protected Double x0, y0, z0;

        World world;
        Sphere selected = null;

        public Form1()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            world = new World(PixelSize);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            // Info: Clear buffers before each painting
            world.ClearBuffers(g);
            world.RenderScene(g, checkBox1.Checked);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Double x = e.X / PixelSize;
            Double y = e.Y / PixelSize;
            Double z = e.Y / PixelSize;
            x0 = x;
            y0 = y;
            z0 = z;

            // Info: Select the sphere
            foreach (Sphere sphere in world.spheres)
            {
                if (sphere.Selected((float)x, (float)y))
                {
                    selected = sphere;
                    break;
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            selected = null;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Info: Move the sphere
            if (selected == null)
                return;

            Double x = e.X / PixelSize;
            Double y = e.Y / PixelSize;
            Double z = e.Y / PixelSize;
            Double dx = x - x0;
            Double dy = y - y0;
            Double dz = z - z0;

            if (e.Button.HasFlag(MouseButtons.Left))
            {
                selected.x += dx;
                selected.y += dy;
            }
            else if (e.Button.HasFlag(MouseButtons.Right))
            {
                selected.z += dz;
            }

            x0 = x;
            y0 = y;
            z0 = z;
            Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}

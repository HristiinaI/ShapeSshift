using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesWindowsForms
{
    abstract class Shape
    {
        public Shape(float dim1, float dim2, Point location)
        {
            Location = location;
            Dim1 = dim1;
            Dim2 = dim2;

        }

        public Shape() { }

        public Point Location { get; set; }

        public float Dim1 { get; set; }

        public float Dim2 { get; set; }

        public abstract float CalculateSurface();

        public abstract void Paint(Graphics g);

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesWindowsForms
{
    class Parallelogram : Shape
    {
        public Parallelogram(float a, float b, Point paraLocation)
        {
            A = a;
            B = b;
            ParaLocation = paraLocation;
        }

        public Point ParaLocation { get; set; }
        public float A { get; set; }
        public float B { get; set; }

        public override float CalculateSurface()
        {
            return A * B;
        }

        public override void Paint(Graphics g)
        {
            using (var pen = new Pen(Color.Blue, 3))
                g.DrawRectangle(pen, Location.X, Location.Y, A, B);
        }
    }
}

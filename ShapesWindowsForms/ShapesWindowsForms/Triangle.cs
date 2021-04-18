using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesWindowsForms
{
    class Triangle : Shape
    {
        public Triangle(float h, float a, Point pt1, Point pt2, Point pt3)
        {
            H = h;
            A = a;
            Pt1 = pt1;
            Pt2 = pt2;
            Pt3 = pt3;
        }

        public Point Pt1 { get; set; }
        public Point Pt2 { get; set; }
        public Point Pt3 { get; set; }


        public float H { get; set; }
        public float A { get; set; }


        public override float CalculateSurface()
        {
            return (H * A) / 2;
        }

        public override void Paint(Graphics g)
        {
            Point[] points = { Pt1, Pt2, Pt3 };
            g.DrawPolygon(new Pen(Color.Blue), points);
        }
    }
}

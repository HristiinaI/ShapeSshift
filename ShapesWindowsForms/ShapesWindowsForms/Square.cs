using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesWindowsForms
{
    class Square : Shape
    {

        public Square(float a, Point squareLocation)
        {
            A = a;
            SquareLocation = squareLocation;
        }

        public Point SquareLocation { get; set; }
        public float A { get; set; }

        public override float CalculateSurface()
        {
            return A * A;
        }

        public override void Paint(Graphics g)
        {
            using (var pen = new Pen(Color.Blue, 3))
                g.DrawRectangle(pen, Location.X, Location.Y, A, A);
        }
    }
}

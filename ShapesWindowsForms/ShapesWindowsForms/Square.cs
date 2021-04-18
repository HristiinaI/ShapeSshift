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

        public Square(float a, float b, Point squareLocation)
        {
            A = a;
            B = b;
            SquareLocation = squareLocation;
        }

        public Point SquareLocation { get; set; }
        public float A { get; set; }
        public float B { get; set; }

        public override float CalculateSurface()
        {
            return A * B;
        }

        public override void Paint(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}

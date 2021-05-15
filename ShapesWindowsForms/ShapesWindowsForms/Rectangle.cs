using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesWindowsForms
{
    class Rectangle : Shape
    {
        public Point RecLocation { get; set; }
        public float A { get; set; }
        public float B { get; set; }
        public Color RectangleColor { get; set; }

        protected override float CalculateSurface()
        {
            return (2 * A) + (2 * B);
        }

        protected override float CalculateArea()
        {
            return A * B;
        }

        public override void Paint(Graphics g)
        {
            using (var brush = new SolidBrush(Color.LightBlue))
                g.FillRectangle(brush, RecLocation.X, RecLocation.Y, A, B);
            using (var pen = new Pen(Color.Blue, 3))
                g.DrawRectangle(pen, RecLocation.X, RecLocation.Y, A, B);         
        }


    }
}

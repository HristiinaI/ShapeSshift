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
        public float A { get; set; }

        protected override float CalculateSurface()
        {
            return 4 * A;

        }

        protected override float CalculateArea()
        {
            return A * A;
        }

        public override void Paint(Graphics g)
        {
            if (Fill)
            {
                var fillColor = Color.FromArgb(
                    100,
                    Color);
                using (var brush = new SolidBrush(fillColor))
                g.FillRectangle(brush, Location.X, Location.Y, A, A);
            }

            using (var pen = new Pen(Color, 3))
                g.DrawRectangle(pen, Location.X, Location.Y, A, A);
        }

        public override bool Contains(Point p)
        {
            return
                Location.X < p.X && p.X < Location.X + A &&
                Location.Y < p.Y && p.Y < Location.Y + A;
        }

        public bool Intersets(Square square)
        {
            return
                    this.Location.X < square.Location.X + square.A &&
                    square.Location.X < this.Location.X + this.A &&
                    this.Location.Y < square.Location.Y + square.A &&
                    square.Location.Y < this.Location.Y + this.A        ;
        }
    }
}

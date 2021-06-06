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
        protected override float CalculateSurface()
        {
            return 4 * Height;

        }

        public override float CalculateArea()
        {
            return Height * Height;
        }

        public override void Paint(Graphics g)
        {
            var borderColor = Selected
                ? Color.Red
                : Color;
            if (Fill)
            {
                using (var brush = new SolidBrush(Color))
                g.FillRectangle(brush, Location.X, Location.Y, Height, Height);
            }

            using (var pen = new Pen(borderColor, 3))
                g.DrawRectangle(pen, Location.X, Location.Y, Height, Height);
        }

        public override bool Contains(Point p)
        {
            return
                Location.X < p.X && p.X < Location.X + Height &&
                Location.Y < p.Y && p.Y < Location.Y + Height;
        }

        public override bool Intersets(Shape square)
        {
            return
                    this.Location.X < square.Location.X + square.Height &&
                    square.Location.X < this.Location.X + this.Height &&
                    this.Location.Y < square.Location.Y + square.Height &&
                    square.Location.Y < this.Location.Y + this.Height        ;
        }
    }
}

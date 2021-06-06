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

        protected override float CalculateSurface()
        {
            return (2 * Width) + (2 * Height);
        }

        public override float CalculateArea()
        {
            return Width * Height;
        }

        public override void Paint(Graphics g)
        {
            if (Fill)
            {
                var fillColor = Color.FromArgb(
                    100,
                    Color);

                using (var brush = new SolidBrush(fillColor))
                    g.FillRectangle(brush, Location.X, Location.Y, Width, Height);
            }

            using (var pen = new Pen(Color, 3))
                g.DrawRectangle(pen, Location.X, Location.Y, Width, Height);         
        }

        public override bool Contains(Point p)
        {
            return
                ((Location.X < p.X) && (p.X < Location.X + Width)) &&
                ((Location.Y < p.Y) && (p.Y < Location.Y + Height));
        }

        public override bool Intersets(Shape rectengle)
        {
            return
                    this.Location.X < rectengle.Location.X + rectengle.Width &&
                    rectengle.Location.X < this.Location.X + this.Width &&
                    this.Location.Y < rectengle.Location.Y + rectengle.Height &&
                    rectengle.Location.Y < this.Location.Y + this.Height;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesWindowsForms
{
    class Circle : Shape
    {
        public float Radius { get; set; }

        protected override float CalculateSurface()
        {
            return (float)(2 * Math.PI * Radius);
        }

        protected override float CalculateArea()
        {
            return (float)Math.PI * Radius * Radius;
        }

        public override void Paint(Graphics g)
        {
            if (Fill)
            {
                var fillColor = Color.FromArgb(
                    100,
                    Color);
                using (var brush = new SolidBrush(fillColor))
                    g.FillEllipse(brush, Location.X, Location.Y,
                         Radius + Radius, Radius + Radius);
            }

            using (var pen = new Pen(Color, 3))
            {
                g.DrawEllipse(pen, Location.X, Location.Y,
                     Radius + Radius, Radius + Radius);
            }
        }

        public override bool Contains(Point p)
        {
            return true;
        }


        //public override string ToString()
        //{
        //    return string.Format("This is circle class \n Radius:{0}", Radius);
        //}

    }
}

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
        public Point CircleLocation { get; set; }

        public float Radius { get; set; }

        public Color CircleColor { get; set; }

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
            using (var brush = new SolidBrush(Color.LightBlue))
                g.FillEllipse(brush, CircleLocation.X, CircleLocation.Y,
                     Radius + Radius, Radius + Radius);

            using (var pen = new Pen(Color.Blue, 3))
            {
                g.DrawEllipse(pen, CircleLocation.X, CircleLocation.Y,
                     Radius + Radius, Radius + Radius);
            }
        }

        //public override string ToString()
        //{
        //    return string.Format("This is circle class \n Radius:{0}", Radius);
        //}

    }
}

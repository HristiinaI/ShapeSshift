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
        public Circle(float radius, Point circleLocation)
        {
            Radius = radius;
            CircleLocation = circleLocation;
        }

        public Point CircleLocation { get; set; }

        public float Radius { get; set; }

        public override float CalculateSurface()
        {
            return Radius;
        }

        public override void Paint(Graphics g)
        {
            using (var pen = new Pen(Color.Blue, 3))
            {
                g.DrawEllipse(pen, Location.X, Location.Y,
                     Radius + Radius, Radius + Radius);
            }
        }

        //public override string ToString()
        //{
        //    return string.Format("This is circle class \n Radius:{0}", Radius);
        //}

    }
}

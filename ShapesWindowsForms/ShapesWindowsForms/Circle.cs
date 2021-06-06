using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesWindowsForms
{
    class Circle : Shape
    {

        protected override float CalculateSurface()
        {
            return (float)(2 * Math.PI * Radius);
        }

        public override float CalculateArea()
        {
            return (float)Math.PI * Radius * Radius;
        }

        public override void Paint(Graphics g)
        {
            var borderColor = Selected
                ? Color.Red
                : Color;
            if (Fill)
            {
                using (var brush = new SolidBrush(Color))
                    g.FillEllipse(brush, Location.X, Location.Y,
                         Radius + Radius, Radius + Radius);
            }

            using (var pen = new Pen(borderColor, 3))
            {
                g.DrawEllipse(pen, Location.X, Location.Y,
                     Radius + Radius, Radius + Radius);
            }
        }

        public override bool Contains(Point p)
        {
            return
                ((Location.X < p.X) && (p.X < Location.X + Radius)) &&
                ((Location.Y < p.Y) && (p.Y < Location.Y + Radius)); ;
        }

        public bool HitTest(Circle circle, Point p)
        {
            var result = false;
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(circle.Location.X, circle.Location.Y, this.Radius * 2, this.Radius * 2);
                result = path.IsVisible(p);
            }
            return result;
        }

        public override bool Intersets(Shape circle)
        {
           return 
                        Math.Abs(circle.Location.X - Location.X) < circle.Radius &&
                        Math.Abs(circle.Location.Y - Location.Y) < circle.Radius;
        }


        //public override string ToString()
        //{
        //    return string.Format("This is circle class \n Radius:{0}", Radius);
        //}

    }
}

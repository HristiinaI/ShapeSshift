using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tu.shapes.ClassLibraryShapes
{
    [Serializable]

    public class Circle : Shape
    {

        protected override float CalculateSurface()
        {
            return (float)(2 * Math.PI * Radius);
        }

        public override float CalculateArea()
        {
            return (float)Math.PI * Radius * Radius;
        }

        public override void Paint(IGraphics g)
        {
            var color = Selected
                ? Color.Red
                : Color;
            g.DrawCircle(
                color,
                Fill
                    ? Color
                    : (Color?)null,
                Location.X,
                Location.Y,
                Radius);
        }

        public override bool Contains(Point p)
        {
            return
                ((Location.X < p.X) && (p.X < Location.X + Radius * 2)) &&
                ((Location.Y < p.Y) && (p.Y < Location.Y + Radius * 2)); ;
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

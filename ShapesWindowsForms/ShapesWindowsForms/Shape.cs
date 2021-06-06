using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesWindowsForms
{
    abstract class Shape
    {
        public Point Location { get; set; }

        public float Width { get; set; }
        public float Height { get; set; }

        public float Radius { get; set; }

        public Color Color { get; set; }

        public bool Fill { get; set; } = true;

        protected abstract float CalculateSurface();

        public abstract float CalculateArea();

        public abstract void Paint(Graphics g);

        public abstract bool Intersets(Shape shape);

        public abstract bool Contains(Point p);

        public static implicit operator float(Shape shape)
        {
            return shape.CalculateArea();
        }


    }
}

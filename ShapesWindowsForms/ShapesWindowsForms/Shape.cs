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

        public Color Color { get; set; }

        public bool Fill { get; set; } = true;

        protected abstract float CalculateSurface();

        protected abstract float CalculateArea();

        public abstract void Paint(Graphics g);

        public abstract bool Contains(Point p);


    }
}

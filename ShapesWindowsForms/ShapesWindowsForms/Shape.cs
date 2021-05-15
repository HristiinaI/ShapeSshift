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
        protected Point Location { get; set; }

        protected abstract float CalculateSurface();

        protected abstract float CalculateArea();

        public abstract void Paint(Graphics g);

    }
}

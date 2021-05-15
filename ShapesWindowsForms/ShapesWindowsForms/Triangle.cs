using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesWindowsForms
{
    class Triangle : Shape
    {
        public Point TriLocation { get; set; }
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }
        public Color TriColor { get; set; }

        protected override float CalculateSurface()
        {
            return A + B + C;
        }

        protected override float CalculateArea()
        {
            float halfArea = CalculateSurface() / 2;
            return (float)Math.Sqrt(halfArea * (halfArea - A) * (halfArea - B) 
                            * (halfArea - C));
 
        }

        public override void Paint(Graphics g)
        {
            
        }
    }
}

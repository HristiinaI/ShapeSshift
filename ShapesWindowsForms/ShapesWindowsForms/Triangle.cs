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
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }

        protected override float CalculateSurface()
        {
            return A + B + C;
        }

        public override float CalculateArea()
        {
            float halfArea = CalculateSurface() / 2;
            return (float)Math.Sqrt(halfArea * (halfArea - A) * (halfArea - B) 
                            * (halfArea - C));
 
        }

        public override void Paint(Graphics g)
        {
            
        }

        public override bool Contains(Point p)
        {
            return true;
        }

        public override bool Intersets(Shape shape)
        {
            throw new NotImplementedException();
        }
    }
}

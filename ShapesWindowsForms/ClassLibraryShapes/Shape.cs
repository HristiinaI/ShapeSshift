using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tu.shapes.ClassLibraryShapes
{
    [Serializable]

    public abstract class Shape
    {
        private float _width;

        public Point Location { get; set; }

        public float Width
        {
            get => _width;

            set
            {
                if(value < 0)
                {
                    throw new InvalidValueExeption("Negative value not allowed!!");
                }

                _width = value;
            }
        }
        public float Height { get; set; }

        public float Radius { get; set; }

        public Color Color { get; set; }

        public bool Fill { get; set; } = true;

        public bool Selected { get; set; }

        protected abstract float CalculateSurface();

        public abstract float CalculateArea();

        public abstract void Paint(IGraphics g);

        public abstract bool Intersets(Shape shape);

        public abstract bool Contains(Point p);

        public static implicit operator float(Shape shape)
        {
            return shape.CalculateArea();
        }


    }
}

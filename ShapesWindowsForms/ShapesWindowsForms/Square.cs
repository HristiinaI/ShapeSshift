﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesWindowsForms
{
    class Square : Shape
    {
        public Point SquareLocation { get; set; }
        public float A { get; set; }
        public Color SquareColor { get; set; }

        protected override float CalculateSurface()
        {
            return 4 * A;

        }

        protected override float CalculateArea()
        {
            return A * A;
        }

        public override void Paint(Graphics g)
        {
            using (var brush = new SolidBrush(Color.LightBlue))
                g.FillRectangle(brush, SquareLocation.X, SquareLocation.Y, A, A);

            using (var pen = new Pen(Color.Blue, 3))
                g.DrawRectangle(pen, SquareLocation.X, SquareLocation.Y, A, A);
        }
    }
}

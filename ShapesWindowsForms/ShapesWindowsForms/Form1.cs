using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapesWindowsForms
{
    public partial class Form1 : Form
    {
        private List<Shape> _shapes = new List<Shape>();

        public Form1()
        {
            InitializeComponent();
        }

        //public void AddShape(Shape shape)
        //{
        //    _shapes.Add(shape);
        //}

        public double CalculateSurface()
        {
            double surface = 0.0;

            foreach(var shape in _shapes)
            {
                surface += shape.CalculateSurface();
            }

            return surface;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = _shapes.Count(); i >= 0; i--)
            {
                _shapes[i].Paint(e.Graphics);
            }

            //var c = new Circle(100, new Point(50, 50));
            //var shape = new Shape(c.Radius, c.Location);

            //c.Paint(e.Graphics);
            
            //var t = new Triangle(6, 10, new Point(10, 10), new Point(100, 10), 
            //    new Point(50, 100));
            //t.Paint(e.Graphics);
        }


    }
}

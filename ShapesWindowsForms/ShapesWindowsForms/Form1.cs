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

        private Boolean isItTriangle = false;
        private Boolean isItCircle = false;
        private Boolean isItRectangle = false;
        private Boolean isItSquare = false;


        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (var shape in _shapes)
                shape.Paint(e.Graphics);
        }

        //Figure menu button
        private void button1_Click(object sender, EventArgs e)
        {
            if(panel1.Height == 175)
            {
                panel1.Height = 37;
            }
            else
            {
                panel1.Height = 175;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Height = 37;     
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            isItTriangle = true;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            isItCircle = true;
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            isItRectangle = true;
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            isItSquare = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (isItTriangle)
                {
                    isItTriangle = false;
                    var tri = new Triangle
                    {
                        TriLocation = e.Location,
                        A = 100,
                        B = 100,
                        C = 100
                    };
                    _shapes.Add(tri);
                }
                else if (isItCircle)
                {
                    isItCircle = false;

                    var c = new Circle
                    {
                        CircleLocation = e.Location,
                        Radius = 50
                    };

                    _shapes.Add(c);
                }
                else if (isItRectangle)
                {

                    isItRectangle = false;

                    var r = new Rectangle
                    {
                        RecLocation = e.Location,
                        A = 100,
                        B = 200,
                    };

                    _shapes.Add(r);
                }
                else if (isItSquare)
                {
                    isItSquare = false;

                    var s = new Square
                    {
                        SquareLocation = e.Location,
                        A = 100,
                    };

                    _shapes.Add(s);

                }

            }else if(e.Button == MouseButtons.Left)
            {

            }

            Invalidate();

        }
    }
}

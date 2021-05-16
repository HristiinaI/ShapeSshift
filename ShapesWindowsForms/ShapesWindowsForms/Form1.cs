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
        private bool _captureMouse;
        private Point _captureLocation;
        private Shape _frame;

        private Boolean isItTriangle = false;
        private Boolean isItCircle = false;
        private Boolean isItRectangle = false;
        private Boolean isItSquare = false;

        public Form1()
        {
            InitializeComponent();

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (var shape in _shapes)
                shape.Paint(e.Graphics);

            if (_captureMouse && _frame != null)
                _frame.Paint(e.Graphics);
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
            isItCircle = false;
            isItSquare = false;
            isItRectangle = false;
            isItTriangle = true;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            isItRectangle = false;
            isItSquare = false;
            isItTriangle = false;
            isItCircle = true;
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            isItCircle = false;
            isItSquare = false;
            isItTriangle = false;
            isItRectangle = true;
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            isItCircle = false;
            isItRectangle = false;
            isItTriangle = false;
            isItSquare = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _captureMouse = true;
            _captureLocation = e.Location;

            foreach (var shape in _shapes)
                shape.Color = Color.Blue; 

            Invalidate();

        }

        private Rectangle CreateFrameRectangle(Point location)
        {
            var frame = new Rectangle
            {
                Location = new Point(
                    Math.Min(_captureLocation.X, location.X),
                    Math.Min(_captureLocation.Y, location.Y)),
                Width =
                    Math.Abs(_captureLocation.X - location.X),
                Height =
                    Math.Abs(_captureLocation.Y - location.Y),
            };

            return frame;
        }

        private Square CreateFrameSquare(Point location)
        {
            var frame = new Square
            {
                Location = new Point(
                    Math.Min(_captureLocation.X, location.X),
                    Math.Min(_captureLocation.Y, location.Y)),
                A =
                    Math.Abs(_captureLocation.X - location.X),
                
            };

            return frame;
        }

        private Triangle CreateFrameTriangle(Point location)
        {
            var frame = new Triangle
            {
                
            };

            return frame;
        }

        private Circle CreateFrameCircle(Point location)
        {
            var frame = new Circle
            {
                Location = new Point(
                     Math.Min(_captureLocation.X, location.X),
                     Math.Min(_captureLocation.Y, location.Y)),
                Radius =
                     Math.Abs(_captureLocation.X - location.X),

            };

            return frame;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_captureMouse)
                return;

            if (isItRectangle)
            {
                
                _frame = CreateFrameRectangle(e.Location);
                _frame.Fill = false;
                _frame.Color = Color.LightGray;
                foreach (Rectangle rectangle in _shapes)
                    rectangle.Color = rectangle.Intersets(CreateFrameRectangle(e.Location))
                        ? Color.Red
                        : Color.Blue;

            }
            else if (isItSquare)
            {
                
                _frame = CreateFrameSquare(e.Location);
                _frame.Fill = false;
                _frame.Color = Color.LightGray;
            }
            else if (isItTriangle)
            {
               
                _frame = CreateFrameTriangle(e.Location);
                _frame.Fill = false;
                _frame.Color = Color.LightGray;
            }
            else if (isItCircle)
            {
               
                _frame = CreateFrameCircle(e.Location);
                _frame.Fill = false;
                _frame.Color = Color.LightGray;
            }

             
            Invalidate();

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_captureMouse)
                return;
            if (e.Button == MouseButtons.Right)
            {
                _frame.Fill = true;
                _frame.Color = Color.Red;

                _shapes.Add(_frame);
            }

            _frame = null;
            _captureMouse = false;

            Invalidate();        
        }
    }
}

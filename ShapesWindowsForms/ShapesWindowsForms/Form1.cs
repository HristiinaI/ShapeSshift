using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tu.shapes.ClassLibraryShapes;
using Rectangle = tu.shapes.ClassLibraryShapes.Rectangle;

namespace tu.shapes
{
    public partial class Form1 : Form, IGraphics
    {
        private List<Shape> _shapes = new List<Shape>();
        private bool _captureMouse;
        private Point _captureLocation;
        private Shape _frame;
        private FormChange formProperties;

        private float areaRectangle = 0;
        private float areaSquare = 0;
        private float areaCircle = 0;

        private Boolean isItCircle = false;
        private Boolean isItRectangle = false;
        private Boolean isItSquare = false;

        private Graphics _graphics;

        //private Form formProperties;

        public Form1()
        {
            InitializeComponent();

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
        }

        public void DrawRectangle(Color colorBorder, Color? colorFill, float x, float y, float width, float hieght)
        {
            if( _graphics != null)
            {
                if (colorFill.HasValue)
                {
                    using (var brush = new SolidBrush(colorFill.Value))
                        _graphics.FillRectangle(brush, x, y, width, hieght);
                }

                using (var pen = new Pen(colorBorder, 3))
                    _graphics.DrawRectangle(pen, x, y, width, hieght);
            }
        }

        public void DrawCircle(Color colorBorder, Color? colorFill, float x, float y, float radius)
        {
            if( _graphics != null)
            {
                if (colorFill.HasValue)
                {
                    using (var brush = new SolidBrush(colorFill.Value))
                        _graphics.FillEllipse(brush, x, y,
                             radius + radius, radius + radius);
                }

                using (var pen = new Pen(colorBorder, 3))
                {
                    _graphics.DrawEllipse(pen, x, y,
                             radius + radius, radius + radius);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            _graphics = e.Graphics;

            for(int i = _shapes.Count - 1; i >= 0; i--)
                _shapes[i].Paint(this);

            if (_captureMouse && _frame != null)
                _frame.Paint(this);

            _graphics = null;
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
            if (!File.Exists("data"))
                return;

            var formatter = new BinaryFormatter();

            using (var stream = new FileStream("data", FileMode.Open))
            {
                _shapes = (List<Shape>)formatter.Deserialize(stream);
            }
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            isItRectangle = false;
            isItSquare = false;
            isItCircle = true;
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            isItCircle = false;
            isItSquare = false;
            isItRectangle = true;
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            isItCircle = false;
            isItRectangle = false;
            isItSquare = true;
        }

        

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _captureMouse = true;
            _captureLocation = e.Location;
            //_frame = null;

            foreach (var shape in _shapes)
                shape.Selected = false;

            var selectedShape = _shapes
                .FirstOrDefault(r => r.Contains(e.Location));
              
            if(selectedShape != null)
                selectedShape.Selected = true;

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
                Height =
                    Math.Abs(_captureLocation.X - location.X),
                
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
                _frame = CreateFrameRectangle(e.Location);
            else if (isItSquare)
                _frame = CreateFrameSquare(e.Location);
            else if (isItCircle)
                _frame = CreateFrameCircle(e.Location); 


            _frame.Fill = false;
            _frame.Color = Color.LightGray;
            foreach (Shape shape in _shapes
                    .Where(r => r.Intersets(_frame)))
                shape.Selected = true;

            Invalidate();

        }

        private void RefreshArea()
        {
            if (isItRectangle)
                areaRectangle = _shapes
                    .Select(s => s.CalculateArea())
                    .Sum();
            else if (isItSquare)
                areaSquare = _shapes
                    .Select(s => s.CalculateArea())
                    .Sum();
            else if (isItCircle)
                areaCircle = _shapes
                    .Select(s => s.CalculateArea())
                    .Sum();

            toolStripStatusLabelRec.Text = "RectangleArea: " + areaRectangle.ToString();
            toolStripStatusLabelSquare.Text = "SquareArea: " + areaSquare.ToString();
            toolStripStatusLabelCircle.Text = "CircleArea: " + areaCircle.ToString();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_captureMouse)
                return;
            if (e.Button == MouseButtons.Right)
            {
                _frame.Fill = true;
                _frame.Selected = true;
                _frame.Color = Color.Blue;

                _shapes.Insert(0, _frame);
            }

            _captureMouse = false;

            RefreshArea();
            Invalidate();        
        }

        private void DeleteSelected()
        {
            for (int i = _shapes.Count - 1; i >= 0; i--)
                if (_shapes[i].Selected)
                    _shapes.RemoveAt(i);

            RefreshArea();
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            DeleteSelected();
        }

        

        private void toolStripStatusLabelRec_Click(object sender, EventArgs e)
        {

        }

        private void Properties()
        {
            var shape = _shapes
                .FirstOrDefault(r => r.Selected);

            if (isItRectangle)
                formProperties = new FormChange(FormChange.Style.Properties, FormChange.Type.Rectangle);
            else if (isItSquare)
                formProperties = new FormChange(FormChange.Style.Properties, FormChange.Type.Square);
            else if (isItCircle)
                formProperties = new FormChange(FormChange.Style.Properties, FormChange.Type.Circle);

            if (shape != null)
            {
                formProperties.Height = shape.Height;
                formProperties.Width = shape.Width;
                formProperties.Radius = shape.Radius;
                formProperties.Color = shape.Color;
                if (formProperties.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        shape.Height = formProperties.Height.Value;
                        shape.Width = formProperties.Width.Value;
                        shape.Radius = formProperties.Radius.Value;
                        shape.Color = formProperties.Color.Value;

                    }
                    catch (InvalidValueExeption e)
                    {
                        MessageBox.Show(
                            e.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            Properties();
        }

        private void selectToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
             
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            var selectedCount = _shapes
                .Count(r => r.Selected);

            deleteToolStripMenuItem.Enabled = selectedCount > 0;

            propertiesToolStripMenuItem.Enabled = selectedCount == 1;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties();
        } 

        private void selectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isItRectangle)
                formProperties = new FormChange(FormChange.Style.Properties, FormChange.Type.Rectangle);
            else if (isItSquare)
                formProperties = new FormChange(FormChange.Style.Properties, FormChange.Type.Square);
            else if (isItCircle)
                formProperties = new FormChange(FormChange.Style.Properties, FormChange.Type.Circle);

            if (formProperties.ShowDialog() == DialogResult.OK)
            {
                var selectedShapes = _shapes
                    .AsEnumerable();
                if (formProperties.Width.HasValue)
                    selectedShapes = selectedShapes
                        .Where(r => r.Width == formProperties.Width.Value);
                if (formProperties.Height.HasValue)
                    selectedShapes = selectedShapes
                        .Where(r => r.Height == formProperties.Height.Value);
                if (formProperties.Color.HasValue)
                    selectedShapes = selectedShapes
                        .Where(r => r.Color == formProperties.Color.Value);
                if (formProperties.Height.HasValue || formProperties.Width.HasValue
                    || formProperties.Color.HasValue)
                    foreach (var shape in selectedShapes)
                        shape.Selected = true;
                Invalidate();

            }
            RefreshArea();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var formatter = new BinaryFormatter();

            using (var stream = new FileStream("data", FileMode.Create))
            {
                formatter.Serialize(stream, _shapes);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

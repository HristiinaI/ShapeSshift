using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tu.shapes.ClassLibraryShapes;


namespace tu.shapes
{
    public partial class FormChange : Form
    {

        private float? _Height;
        private float? _Width;
        private float? _Radius;
        private Color? _Color;

        public enum Style
        {
            Properties,
            Select
        }

        public enum Type
        {
            Rectangle,
            Square,
            Circle
        }

        public FormChange(Style style, Type type)
        {
            InitializeComponent();

            switch (style)
            {
                case Style.Properties:
                    Text = "Properties";
                    buttonOK.Text = "OK";
                    break;

                case Style.Select:
                    Text = "Select";
                    buttonOK.Text = "Select";
                    break;
            }
            switch (type)
            {
                case Type.Rectangle:
                    labelHeight.Visible = true;
                    labelWeight.Visible = true;
                    textBoxHeight.Visible = true;
                    textBoxWidth.Visible = true;
                    textBoxRadius.Visible = false;
                    labelRadius.Visible = false;
                    break;
                case Type.Square:
                    labelHeight.Visible = true;
                    labelWeight.Visible = false;
                    textBoxHeight.Visible = true;
                    textBoxWidth.Visible = false;
                    textBoxRadius.Visible = false;
                    labelRadius.Visible = false;
                    break;
                case Type.Circle:
                    labelHeight.Visible = false;
                    labelWeight.Visible = false;
                    textBoxHeight.Visible = false;
                    textBoxWidth.Visible = false;
                    textBoxRadius.Visible = true;
                    labelRadius.Visible = true;
                    break;

            }
        }

        private void labelRadius_Click(object sender, EventArgs e)
        {

        }

        public new float? Height {
            get
            {
                return _Height;
            }
            set 
            {
                _Height = value;
                textBoxHeight.Text = _Height.ToString();
            } 
        }
        public new float? Width {
            get
            {
                return _Width;
            }
            set
            {
                _Width = value;
                textBoxWidth.Text = _Width.ToString();
            }
        }


        public float? Radius
        {
            get
            {
                return _Radius;
            }
            set
            {
                _Radius = value;
                textBoxRadius.Text = _Radius.ToString();
            }
        }

        public Color? Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
                buttonColor.BackColor = _Color ?? BackColor;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _Width = int.TryParse(textBoxWidth.Text, out int width)
                   ? width
    :              (int?)null;
            _Height = int.TryParse(textBoxHeight.Text, out int height)
                ? height
                : (int?)null;
            _Radius = int.TryParse(textBoxRadius.Text, out int radius)
                   ? radius
                   : (int?)null;


            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();
            Color = cd.ShowDialog() == DialogResult.OK
                ? cd.Color
                : (Color?)null;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class FormSquareChange : Form
    {
        private float _Height;
        private float _Width;

        public FormSquareChange()
        {
            InitializeComponent();
        }

        public float Height
        {
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
        public float Width
        {
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

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _Height = int.Parse(textBoxHeight.Text);
            _Width = int.Parse(textBoxWidth.Text);
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

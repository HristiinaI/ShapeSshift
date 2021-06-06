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
    public partial class FormCircleChange : Form
    {
        private float _Radius; 
        public FormCircleChange()
        {
            InitializeComponent();
        }

        public float Radius {
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

        private void textBoxRadius_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _Radius = int.Parse(textBoxRadius.Text);

            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

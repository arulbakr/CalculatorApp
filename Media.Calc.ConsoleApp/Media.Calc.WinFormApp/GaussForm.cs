using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Media.Calc.WinFormApp
{
    public partial class GaussForm : Form
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string X { get; set; }

        public GaussForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            A = textBox1.Text;
            B = textBox2.Text;
            C = textBox3.Text;
            X = textBox4.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
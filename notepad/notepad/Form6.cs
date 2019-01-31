using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace notepad
{
    public partial class Form6 : Form
    {
        Form1 B;
        EnglishToHindi.Class1 obj = new EnglishToHindi.Class1();
        public Form6(Form1 B)
        {

            InitializeComponent();
            this.B = B;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.Text = obj.ConvertData(richTextBox1.Text);
            }
            catch (Exception ee)
            {
            }

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            richTextBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            B.richTextBox1.Text = richTextBox2.Text;
            Dispose();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            richTextBox2.Enabled = false;
        }
    }
}

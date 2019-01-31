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
    public partial class Form4 : Form
    {
        Form1 A;
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(Form1 A)
        {
            InitializeComponent();
            this.A = A;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String str = A.richTextBox1.Text;
            str = str.Replace(textBox1.Text, textBox2.Text);
            A.richTextBox1.Text = str;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (A.richTextBox1.SelectedText == "")
            {
                MessageBox.Show("Please First U Find The Text Using Find Button");

            }
            else
            {
                String str = A.richTextBox1.Text.Substring(0, pos);

                str = str + textBox2.Text;

                str = str + A.richTextBox1.Text.Substring(pos + 1);
                A.richTextBox1.Text = str;

            }


            


        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        int pos = -1;
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0)
                return;
            
            if (button1.Text == "Find")
            {

                pos = A.richTextBox1.Text.IndexOf(textBox1.Text);
                if (pos == -1)
                {
                    MessageBox.Show("Text Not Found");
                    return;
                }
                else
                {
                    A.richTextBox1.Select(pos, textBox1.Text.Length);
                    button1.Text = "Find Next";


                }

            }
            else
            {
                pos = A.richTextBox1.Text.IndexOf(textBox1.Text, pos + 1);

                if (pos == -1)
                {
                    MessageBox.Show("Search Complete");
                    button1.Text = "Find";
                }
                else
                {
                    A.richTextBox1.Select(pos, textBox1.Text.Length);
                }

            }

        }
    }
}

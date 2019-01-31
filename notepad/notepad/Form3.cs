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
    public partial class Form3 : Form
    {
        Form1 B;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Form1 B)
        {
            InitializeComponent();
            this.B = B;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        int pos = 0;
        private void button1_Click(object sender, EventArgs e)
        {
           
            //MessageBox.Show(B.richTextBox1.Text);
            if (radioButton1.Checked == true)
            {
                if (button1.Text == "Find")
                {
                    if(checkBox1.Checked==true)

                    pos = B.richTextBox1.Text.IndexOf(textBox1.Text,StringComparison.OrdinalIgnoreCase);
                    else
                        pos = B.richTextBox1.Text.IndexOf(textBox1.Text);
                    if (pos == -1)
                    {
                        MessageBox.Show("Search Complete");
                    }
                    else
                    {
                        B.richTextBox1.Select(pos, textBox1.Text.Length);
                        button1.Text = "Find Next";

                    }
                }
                else
                {

                    if (checkBox1.Checked == true)

                        pos = B.richTextBox1.Text.IndexOf(textBox1.Text,pos+1, StringComparison.OrdinalIgnoreCase);
                    else
                        pos = B.richTextBox1.Text.IndexOf(textBox1.Text,pos+1);

                    if (pos == -1)
                    {
                        MessageBox.Show("Search Complete");
                        button1.Text = "Find";
                        pos = 0;
                    }
                    else
                    {
                        B.richTextBox1.Select(pos, textBox1.Text.Length);


                    }
                }

            }
            else 
            {
                if (button1.Text == "Find")
                {
                    if (checkBox1.Checked == true)

                        pos = B.richTextBox1.Text.LastIndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase);
                    else
                        
                    pos = B.richTextBox1.Text.LastIndexOf(textBox1.Text);
                   
                    if (pos == -1)
                    {
                        MessageBox.Show("Search Complete");
                    }
                    else
                    {
                        B.richTextBox1.Select(pos, textBox1.Text.Length);
                        button1.Text = "Find Next";

                    }
                }
                else
                {
                    if (checkBox1.Checked == true)

                        pos = B.richTextBox1.Text.LastIndexOf(textBox1.Text,pos-1, StringComparison.OrdinalIgnoreCase);
                    else
                        

                    pos = B.richTextBox1.Text.LastIndexOf(textBox1.Text, pos - 1);
                    if (pos == -1)
                    {
                        MessageBox.Show("Search Complete");
                        button1.Text = "Find";
                        pos = 0;
                    }
                    else
                    {
                        B.richTextBox1.Select(pos, textBox1.Text.Length);


                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}

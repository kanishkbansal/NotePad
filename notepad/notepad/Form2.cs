using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace notepad
{
    public partial class Form2 : Form
    {
        Form1 A;
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public Form2(Form1 A)
        {
            InitializeComponent();
            this.A = A;
            
        }

       System.Collections.Hashtable hfont = new System.Collections.Hashtable();
        private void Form2_Load(object sender, EventArgs e)
        {
            InstalledFontCollection fc = new InstalledFontCollection();

            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            foreach (FontFamily ff in fc.Families)
            {
                listBox1.Items.Add(ff.Name);
                hfont.Add(ff.Name, ff);
                collection.Add(ff.Name);


            }
            //textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteCustomSource = collection;
            


           listBox1.SelectedIndex = 0;
           textBox1.Text = listBox1.Items[0].ToString();

            for (int i = 10; i <= 100; i++)
            {
                listBox2.Items.Add(i);
            }

            listBox2.SelectedIndex = 0;
            textBox2.Text = listBox2.Items[0].ToString();
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
           A.richTextBox1.Font = new Font(textBox1.Text, Convert.ToInt32(textBox2.Text));
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 && listBox2.SelectedIndex != -1)
            {
                FontFamily ff = (FontFamily)hfont[listBox1.Items[listBox1.SelectedIndex]];

                int fontsize = Convert.ToInt32(listBox2.Items[listBox2.SelectedIndex]);

                label1.Font = new Font(ff, fontsize);
                textBox1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();

            }
           
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1 && listBox1.SelectedIndex != -1)
            {
                int fontsize = Convert.ToInt32(listBox2.Items[listBox2.SelectedIndex]);


                FontFamily ff = (FontFamily)hfont[listBox1.Items[listBox1.SelectedIndex]];
                label1.Font = new Font(ff, fontsize);
                textBox2.Text = listBox2.Items[listBox2.SelectedIndex].ToString();



            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                if (listBox1.Items.Contains(textBox1.Text))
                {
                    int pos = listBox1.Items.IndexOf(textBox1.Text);

                    listBox1.SelectedIndex = pos;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            
            
        }

       
    }
}

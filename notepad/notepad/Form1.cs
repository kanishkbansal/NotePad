using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Controls;
using System.Drawing.Imaging;
namespace notepad
{
    public partial class Form1 : Form
    {

        String filepath = "";
        public Font font;
        public Form1()
        {
            InitializeComponent();
        }


        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();



        }

        public void readData(String path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    String txt = reader.ReadToEnd();
                    richTextBox1.Text = txt;
                }
            }
            catch (Exception ee)
            { 
            }
        }


        public void writeData(String path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    String txt = richTextBox1.Text;
                    writer.Write(txt);
                }
            }
            catch (Exception ee)
            { 
            }
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (filepath == "")
            {
                try
                {
                    SaveFileDialog s = new SaveFileDialog();
                    s.Filter = "Text Files (.txt)|*.txt|All Files(*.*)|*.*";
                    s.ShowDialog();

                    filepath = s.FileName;

                    this.Text = new FileInfo(s.FileName).Name;
                }
                catch (Exception ee)
                { 
                }
            }
            
            writeData(filepath);

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Text Files (.txt)|*.txt|All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                readData(op.FileName);
                filepath = op.FileName;
                this.Text = new FileInfo(op.FileName).Name;

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Text Files (.txt)|*.txt|All Files(*.*)|*.*";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(sv.FileName, RichTextBoxStreamType.PlainText);
                this.Text = new FileInfo(sv.FileName).Name;
            }
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contact Developer", "HELP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
          if (richTextBox1.Text != "")
            {
               DialogResult dio= MessageBox.Show("Do you want to save this file?", "Alert", MessageBoxButtons.YesNo);
               if (dio == DialogResult.Yes)
               {
                   SaveFileDialog sv = new SaveFileDialog();
                   sv.Filter = "Text Files (.txt)|*.txt|All Files(*.*)|*.*";
                   if (sv.ShowDialog() == DialogResult.OK)
                   {
                       richTextBox1.SaveFile(sv.FileName, RichTextBoxStreamType.PlainText);
                       
                   }
               }
                richTextBox1.Clear();
                this.Text = "Untitled Document";
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
            redoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Enabled = true;
            
           
        }

       

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Underline);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
         //   statusStrip1.Items[0].Text = "Ln : " + richTextBox1.Lines.Length +"\t Col : "+Cursor.Position.ToString();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
          /*  if (e.KeyData == Keys.Enter || e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {

                 int col =richTextBox1.GetCharIndexFromPosition(Cursor.Position);

                int line=  richTextBox1.GetFirstCharIndexFromLine(col);

                statusStrip1.Items[0].Text = "Ln : " + line + "\t Col : "+col;
            }
           */
         
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 s = new Form2(this);
            s.Show();
           
           
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form3 a = new Form3(this);
            a.Show();
        }
        int pos = 0;
        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pos = richTextBox1.SelectedText.Length;
            if (pos == 0)
            {
                Form3 a = new Form3(this);
                a.Show();
            }
            else
            {
                pos = pos + richTextBox1.SelectionLength;
                pos = richTextBox1.Text.IndexOf(richTextBox1.SelectedText, pos);
                if (pos == -1)
                {
                    MessageBox.Show("Search Complete");
                    pos = 0;
                    richTextBox1.Select(0, 0);
                }
                else
                {
                    richTextBox1.Select(pos, richTextBox1.SelectedText.Length);
                }


            }
           

        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //replaceToolStripMenuItem.Enabled = false;
            Form4 a = new Form4(this);
            a.Show();
        }

        private void dateAndTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text + " " + DateTime.Now;
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Untitled Document";
            

           
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Underline);
        }

        

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            richTextBox1.Multiline = true;
            richTextBox1.AcceptsTab = true;


            if (richTextBox1.Text.Length > 0)
            {
                
                undoToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                findToolStripMenuItem.Enabled = true;
                findNextToolStripMenuItem.Enabled = true;
                replaceToolStripMenuItem.Enabled = true;

            }
            else
            {
                undoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
                findToolStripMenuItem.Enabled = false;
                findNextToolStripMenuItem.Enabled = false;
                replaceToolStripMenuItem.Enabled = false;
                
                //statusStrip1.Items[0].Text = "Ln : " + richTextBox1.Lines.Length + "\t Col : " + Cursor.Position.ToString();
            }
            
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            


        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
           
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                toolStripButton11.BackColor = colorDialog1.Color;
            }
            richTextBox1.ForeColor = colorDialog1.Color;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Text Files (.txt)|*.txt|All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                readData(op.FileName);
                filepath = op.FileName;
                this.Text = new FileInfo(op.FileName).Name;

            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            if (filepath == "")
            {
                try
                {
                    SaveFileDialog s = new SaveFileDialog();
                    s.Filter = "Text Files (.txt)|*.txt|All Files(*.*)|*.*";
                    s.ShowDialog();

                    filepath = s.FileName;

                    this.Text = new FileInfo(s.FileName).Name;
                }
                catch (Exception ee)
                {
                }
            }

            writeData(filepath);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Text Files (.txt)|*.txt|All Files(*.*)|*.*";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(sv.FileName, RichTextBoxStreamType.PlainText);
                this.Text = new FileInfo(sv.FileName).Name;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
               DialogResult dio= MessageBox.Show("Do you want to save this file?", "Alert", MessageBoxButtons.YesNo);
               if (dio == DialogResult.Yes)
               {
                   SaveFileDialog sv = new SaveFileDialog();
                   sv.Filter = "Text Files (.txt)|*.txt|All Files(*.*)|*.*";
                   if (sv.ShowDialog() == DialogResult.OK)
                   {
                       richTextBox1.SaveFile(sv.FileName, RichTextBoxStreamType.PlainText);
                       
                   }
               }
                richTextBox1.Clear();
                this.Text = "Untitled Document";
            }
            

        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contact Developer", "HELP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                if (this.Text == "Untitled Document")
                {
                    Dispose();
                }
    
            }
                else 
                {
                    DialogResult dia = MessageBox.Show("Do you really want to exit without saving ?", "Exit", MessageBoxButtons.YesNo);
                    if (dia == DialogResult.No)
                    {
                        e.Cancel = true;

                    }
                
            }
        }
        private void CaptureMyScreen()
        {

            try
            {
                Bitmap captureBitmap = new Bitmap(1024, 768, PixelFormat.Format32bppArgb);
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                captureBitmap.Save(@"E:\Capture.jpg", ImageFormat.Jpeg);
                MessageBox.Show("Screen Captured");

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        private void gotoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            CaptureMyScreen();
        }

        private void screenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptureMyScreen();
        }

        private void richTextBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            
        }

        private void hiEnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 B = new Form6(this);
            B.Show();
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 9)
            {
                e.Handled = false;
            }
        }

        

        
    }
}

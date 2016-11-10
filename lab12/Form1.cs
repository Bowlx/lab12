using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12
{
    public partial class Form1 : Form
    {
        bool Drow;
        Bitmap _bmp;
        private Point _startPoint;
        private Pen Painter = new Pen(Color.Black, 2);
        public Form1()

        {
            InitializeComponent();
            Bitmap newbmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = newbmp;
            string[] mas2 = {"1","2","3","4","5","6","7","8","9" };
            comboBox1.Items.AddRange(mas2);
        }
       

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
                Drow = true;
                _startPoint = e.Location;
            
                
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && pictureBox1.Image != null)
            {
                using (Graphics graf = Graphics.FromImage(pictureBox1.Image))
                {
                    graf.DrawLine(Painter, _startPoint, e.Location);
                    
                    _startPoint = e.Location;
                    pictureBox1.Invalidate();
                    graf.Dispose();
                }
            }
            

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Drow = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap newbmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = newbmp;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.Text = "Рисователь-2000";
                    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            OpenFileDialog open_dialog = new OpenFileDialog(); 
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; 
            if (open_dialog.ShowDialog() == DialogResult.OK) 
            {
                Image image = Image.FromFile(open_dialog.FileName);
                              
                _bmp = new Bitmap(Image.FromFile(open_dialog.FileName), pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = _bmp;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) 
            {
               
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;        
                savedialog.CheckPathExists = true;          
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";               
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) 
                {                  
                        _bmp.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);                                      
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Painter.Color = colorDialog1.Color;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Painter.Width = Convert.ToInt16(comboBox1.Text);
        }

       
    }
}

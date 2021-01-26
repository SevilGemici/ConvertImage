using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertImage
{
    public partial class Form1 : Form
    {
        public string imagePath;
        public Form1()
        {
            InitializeComponent();
            createFolder();
        }

        public void createFolder()
        {
            Directory.CreateDirectory(@"C:\imagefolder");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd=new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = ofd.FileName;
                    imagePath = ofd.FileName;
                }
            }
        }

        public void messages()
        {
            MessageBox.Show("Image is converted to: " + comboBox1.Text, " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        public void Convert(string selectFormat)
        {
            try
            {
                Image img = Image.FromFile(imagePath);
                if (selectFormat == "JPEG")
                {
                    img.Save(@"C:\imagefolder\photo.Jpeg", ImageFormat.Jpeg);
                }
                else if (selectFormat == "PNG")
                {
                    img.Save(@"C:\imagefolder\photo.Png", ImageFormat.Png);
                }
                else if (selectFormat == "TIFF")
                {
                    img.Save(@"C:\imagefolder\photo.Tiff", ImageFormat.Tiff);
                }
                else if (selectFormat == "BMP")
                {
                    img.Save(@"C:\imagefolder\photo.Bmp", ImageFormat.Bmp);
                }
                else if (selectFormat == "ICON")
                {
                    img.Save(@"C:\imagefolder\photo.Icon", ImageFormat.Icon);
                }
                else if (selectFormat == "GIF")
                {
                    img.Save(@"C:\imagefolder\photo.Gif", ImageFormat.Gif);
                }
                else if (selectFormat == "EMF")
                {
                    img.Save(@"C:\imagefolder\photo.Emf", ImageFormat.Emf);
                }
                else if (selectFormat == "WMF")
                {
                    img.Save(@"C:\imagefolder\photo.Wmf", ImageFormat.Wmf);
                }
                else
                {
                    MessageBox.Show("Can not convert", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Select Image First");
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (imagePath != null)
            {
                Convert(comboBox1.Text);
                messages();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}

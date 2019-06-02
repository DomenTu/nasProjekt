using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace PrimerjavaSlik
{
    public partial class Form1 : Form
    {
        Image<Rgb, byte> image1 = null;
        Image<Rgb, byte> image2 = null;

        public Form1()
        {
            InitializeComponent();
            image1 = new Image<Rgb, byte>(523, 328, new Rgb(0, 0, 0));
            image2 = new Image<Rgb, byte>(523, 328, new Rgb(0, 0, 0));
        }

        void primerjava()
        {
            Bitmap slika1 = image1.Bitmap;
            Bitmap slika2 = image2.Bitmap;
            int stevilo = 0;
            for(int i =0; i< 523; i++)
            {
                for (int j = 0; j < 328; j++)
                {
                    if(slika1.GetPixel(i,j).R == slika2.GetPixel(i, j).R && slika1.GetPixel(i, j).G == slika2.GetPixel(i, j).G && slika1.GetPixel(i, j).B == slika2.GetPixel(i, j).B)
                    {
                        stevilo++;
                    }

                }
            }
            float procent = stevilo / (523 * 328);
            procent = procent * 100;
            label1.Text = procent.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (DialogResult.OK == ofd.ShowDialog())
            {
                Image<Rgb, byte> imgInput = new Image<Rgb, byte>(ofd.FileName);
                image1 = imgInput.Resize(523, 328, new Emgu.CV.CvEnum.Inter());
                imageBox1.Image = image1;

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (DialogResult.OK == ofd.ShowDialog())
            {
                Image<Rgb, byte> imgInput = new Image<Rgb, byte>(ofd.FileName);
                image2 = imgInput.Resize(523, 328, new Emgu.CV.CvEnum.Inter());
                imageBox2.Image = image2;

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            primerjava();
        }
    }
}

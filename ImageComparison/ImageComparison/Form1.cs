using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImageComparison
{
    public partial class Form1 : Form
    {
        string fname1, fname2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            pictureBox1.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Images";
            openFileDialog1.Filter = "All Images|*.jpg; *.bmp; *.png";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.ToString() != "")
            {
                fname1 = openFileDialog1.FileName.ToString();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog2.FileName = "";
            openFileDialog2.Title = "Images";
            openFileDialog2.Filter = "All Images|*.jpg; *.bmp; *.png";
            openFileDialog2.ShowDialog();
            if (openFileDialog2.FileName.ToString() != "")
            {
                fname2 = openFileDialog2.FileName.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            int count1 = 0,count2 = 0;
            bool flag = true;
            string img1_ref, img2_ref;
            Bitmap img1 = new Bitmap(fname1);
            Bitmap img2 = new Bitmap(fname2);
            progressBar1.Maximum = img1.Width;
            if (img1.Width == img2.Width && img1.Height == img2.Height)
            {
                for (int i = 0; i < img1.Width; i++)
                {
                    for (int j = 0; j < img1.Height; j++)
                    {
                        img1_ref = img1.GetPixel(i, j).ToString();
                        img2_ref = img2.GetPixel(i, j).ToString();
                        if (img1_ref != img2_ref)
                        {
                            count2++;
                            flag = false;
                            break;
                        }
                        count1++;
                    }
                    progressBar1.Value++;
                }
                if (flag == false)
                    MessageBox.Show("Sorry, Images are not same , " + count2 + " wrong pixels found");
                else
                    MessageBox.Show(" Images are same , " + count1 + " same pixels found and " + count2 + " wrong pixels found");
            }
            else
                MessageBox.Show("can not compare this images");
            this.Dispose();
        }
    }
}

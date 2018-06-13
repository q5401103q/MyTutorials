using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessor
{
    public partial class Form1 : Form
    {
        private readonly string path = "D:/images/";
        private readonly string watermark = "www.github.com";

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = dialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = txtImagePath.Text;
            
            Bitmap bitmap = new Bitmap(filename);
            Graphics graphic = Graphics.FromImage(bitmap);
            int width = bitmap.Width - 1;
            int height = bitmap.Height - 1;

            Color color;
            Bitmap bitmap2 = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), PixelFormat.DontCare);
            Bitmap bitmap3 = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), PixelFormat.DontCare);

            //第一张图片，加文字
            graphic.DrawImage(bitmap, new Rectangle(0, 0, width, height));
            graphic.SmoothingMode = SmoothingMode.AntiAlias;
            graphic.DrawString(watermark, new Font("黑体", 32.0f), Brushes.Red, 20.0f, 100.0f);
            bitmap.Save(string.Format("{0}_01.jpg", path), ImageFormat.Jpeg);

            //第二张图片，灰度处理
            for (int i = width; i >= 0; i--)
            {
                for (int j = height; j >= 0; j--)
                {
                    //使用平均值法进行灰度处理   
                    color = bitmap2.GetPixel(i, j);
                    int middle = (color.R + color.G + color.B) / 3;
                    Color colorResult = Color.FromArgb(255, middle, middle, middle);
                    bitmap2.SetPixel(i, j, colorResult);

                    //使用最大值法进行灰度处理
                    //color = bitmap2.GetPixel(i, j);
                    //int tmp = Math.Max(color.R, color.G);
                    //int maxcolor = Math.Max(tmp, color.B);
                    //Color colorResult = Color.FromArgb(255, maxcolor, maxcolor, maxcolor);
                    //bitmap2.SetPixel(i, j, colorResult);
                }
            }
            graphic.DrawImage(bitmap2, new Rectangle(0, 0, width, height));
            bitmap2.Save(string.Format("{0}_02.jpg", path), ImageFormat.Jpeg);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using AForge.Math;
using AForge;
using System.Drawing.Imaging;


namespace AutomatedVisionInspection
{
    class Processing
    {

        bool done1 = false;
        bool done2 = false;
        Bitmap bitmap_im1, bitmap_im2;
        public void startProcessing(Bitmap im, Bitmap im2)
        {
            bitmap_im1 = new Bitmap(im.Width, im.Height);
            bitmap_im2 = new Bitmap(im2.Width, im2.Height);
            Thread thread = new Thread(() => convert(im, 1));
            Thread thread2 = new Thread(() => convert(im2, 2));
            thread.Start();
            thread2.Start();
            thread.Join();
            thread2.Join();


        }
        public void convert(Bitmap im3, int id)
        {

            // double threeshold, th = 0, g1 = 0, g2 = 0, sum1 = 0, sum2 = 0, m1, m2, value;
            int row, col, sumvalue = 0;
            Color C;
            row = im3.Height;
            col = im3.Width;
            double[,] temp_Array = new double[col, row];
            int red, green, blue, y;
            Bitmap temp = new Bitmap(col, row);
            temp = AForge.Imaging.Image.Clone(im3);
            Bitmap matim = new Bitmap(col, row);
            for (int j = 0; j < row; j++)
            {
                for (int i = 0; i < col; i++)
                {

                    red = temp.GetPixel(i, j).R;
                    green = temp.GetPixel(i, j).G;
                    blue = temp.GetPixel(i, j).B;
                    y = (int)(red * 0.299 + green * 0.587 + blue * 0.114);
                    C = Color.FromArgb(y, y, y);
                    temp_Array.SetValue(y, i, j);
                    sumvalue += y;

                }

            }

            object yyy = null;
            if (id == 1)
            {
                MLApp.MLApp matlab;
                matlab = new MLApp.MLApp();
                matlab.Execute(@"cd C:\Users\BayanHendawi\Documents\MATLAB");
                matlab.Feval("threshold_function", 1, out yyy, temp_Array);
                matlab.Quit();
            }
            if (id == 2)
            {
                MLApp.MLApp matlab;
                matlab = new MLApp.MLApp();
                matlab.Execute(@"cd C:\Users\BayanHendawi\Documents\MATLAB");
                matlab.Feval("threshold_function", 1, out yyy, temp_Array);
            }

            object[] pp = yyy as object[];
            int b = 0, w = 255;
            for (int j = 0; j < row; j++)
            {
                for (int i = 0; i < col; i++)
                {
                    bool c = (pp[0] as Boolean[,])[i, j];
                    if (c)
                        C = Color.FromArgb(w, w, w);
                    else
                        C = Color.FromArgb(b, b, b);

                    matim.SetPixel(i, j, C);

                }
            }

            if (id == 1)
            {
                bitmap_im1 = AForge.Imaging.Image.Clone(matim);
                done1 = true;
            }
            if (id == 2)
            {
                bitmap_im2 = AForge.Imaging.Image.Clone(matim);
                done2 = true;
            }
        }

        public bool Done()
        {
            while (!(done1 && done2))
            {

            }
            return true;

        }

        public Bitmap getIm1()
        {
            return bitmap_im1;
        }
        public Bitmap getIm2()
        {
            return bitmap_im2;
        }

    }
}
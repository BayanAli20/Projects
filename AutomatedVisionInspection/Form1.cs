using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using AForge.Math;
using AForge;
using System.Drawing.Imaging;
using MLApp;


namespace AutomatedVisionInspection
{
    public partial class Form1 : Form
    {
        [DllImport("inpout32.dll")]
        private static extern UInt32 IsInpOutDriverOpen();
        [DllImport("inpout32.dll")]
        private static extern void Out32(short PortAddress, short Data);
        [DllImport("inpout32.dll")]
        private static extern byte Inp32(short PortAddress);

        [DllImport("inpoutx64.dll", EntryPoint = "IsInpOutDriverOpen")]
        private static extern UInt32 IsInpOutDriverOpen_x64();
        [DllImport("inpoutx64.dll", EntryPoint = "Out32")]
        private static extern void Out32_x64(short PortAddress, short Data);
        [DllImport("inpoutx64.dll", EntryPoint = "Inp32")]
        private static extern char Inp32_x64(short PortAddress);


        public Form1()
        {
            InitializeComponent();
        }
        private FilterInfoCollection filter, filter2;
        private VideoCaptureDevice imag, imag2;
        Bitmap im1, im2;

        byte dataout, output, datain;

        private void Form1_Load(object sender, EventArgs e)
        {
            dataout = 0;
            output = 0;
            Out32(0x37A, 0x0B);

            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo capturar in filter)
            {
                comboBox1.Items.Add(capturar.Name);
            }
            comboBox1.SelectedIndex = 0;

            imag = new VideoCaptureDevice();
            imag = new VideoCaptureDevice(filter[0].MonikerString);
            imag.NewFrame += new NewFrameEventHandler(camera);
            imag.Start();
            //When use second camera
            //imag2 = new VideoCaptureDevice();
            //imag2 = new VideoCaptureDevice(filter[2].MonikerString);
            //imag2.NewFrame += new NewFrameEventHandler(camera2);
            //imag2.Start();
        }

        void camera(object sender, NewFrameEventArgs EventArgs)
        {

            Bitmap bit1 = (Bitmap)EventArgs.Frame.Clone();
              pictureBox1.Image = bit1;
        }

        //When use second camera
        //void camera2(object sender, NewFrameEventArgs EventArgs)
        //{
        //    Bitmap bit2 = (Bitmap)EventArgs.Frame.Clone();
        //    pictureBox2.Image = bit2;
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            datain = Inp32(0x379);

            if ((datain & 0x40) == 0x40)//sensor for camera pin 10==I6
            {
                im1 = (Bitmap)pictureBox1.Image;
                im2 = (Bitmap)pictureBox2.Image;
                //fire thread for proccessing
                //Processing pr = new Processing();
                //pr.startProcessing(im1, im2);

            }

            if ((datain & 0x80) == 0x00) //sensor for paston 1 pin 11 ==  I7' is on
            {

                dataout |= 0x02;// push paston 1
               Out32(0x0378, dataout);
            }

            if ((datain & 0x20) == 0x20) //sensor for paston 2 pin 12 == I5 is on
            {

                dataout |= 0x04;// push paston 1
                Out32(0x0378, dataout);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataout |= 0x02; //run motor
            Out32(0x0378, dataout);
        }


    }
}

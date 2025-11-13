using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using TGMT;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;

namespace VietANPR_UI
{
    public partial class FormWebcam : Form
    {
        static FormWebcam m_instance;
        VideoCaptureDevice m_videoSource;
        Bitmap g_bmp;

        private static Random random = new Random();
        Stopwatch m_watch;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormWebcam()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormWebcam GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormWebcam();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("input");
            InitCamera();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void InitCamera()
        {
            cbCamera.Items.Clear();

            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videosources.Count == 0)
            {
                FormMain.GetInstance().PrintError("Can not find camera");
                return;
            }


            for (int i = 0; i < videosources.Count; i++)
            {
                cbCamera.Items.Add(videosources[i].Name);
            }
            cbCamera.Enabled = true;
            if(cbCamera.Items.Count == 1)
            {
                cbCamera.SelectedIndex = 0;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectLocalCamera();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ConnectLocalCamera()
        {
            if (cbCamera.Items.Count == 0 || cbCamera.SelectedIndex == -1)
                return;
            if (m_videoSource != null)
            {
                m_videoSource.Stop();
            }
            else
            {
                FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                m_videoSource = new VideoCaptureDevice(videosources[cbCamera.SelectedIndex].MonikerString);
            }

            m_videoSource.NewFrame += new NewFrameEventHandler(OnCameraFrame);
            m_videoSource.Start();
            btnRead.Enabled = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnCameraFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (g_bmp != null)
                g_bmp.Dispose();


            g_bmp = (Bitmap)eventArgs.Frame.Clone();
            picCamera.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (g_bmp == null)
            {
                return;
            }

            string filePath = "input\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_" + RandomString(10) + ".jpg";
            g_bmp.Save(filePath, ImageFormat.Jpeg);

            btnRead.Enabled = false;
            FormMain.GetInstance().PrintMessage("");
            FormMain.GetInstance().StartProgressbar();

            
            Thread t = new Thread(() => Read((Bitmap)g_bmp.Clone()));
            t.Start();            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Read(Bitmap bmp)
        {
            m_watch = Stopwatch.StartNew();
            VehiclePlate[] plates = Program.reader.Reads(bmp);
            m_watch.Stop();

            if (plates.Length == 0)
                return;

            VehiclePlate plate = plates[0];

            this.Invoke(new Action(() =>
            {
                FormMain.GetInstance().StopProgressbar();
                lbl_result.Text = plate.text;

                lbl_result.ForeColor = plate.isValid ? Color.White : Color.Red;

                if (plate.bitmap == null)
                {
                    FormMain.GetInstance().PrintError(plate.error);
                }
                else
                {
                    picResult.Image = plate.bitmap;
                    FormMain.GetInstance().PrintMessage("Elapsed: " + m_watch.ElapsedMilliseconds.ToString() + "ms");
                }
                

                btnRead.Enabled = true;
                
            }));
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormWebcam_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if(cbCamera.Items.Count == 1)
                {
                    cbCamera.SelectedIndex = 0;
                }
            }
            else
            {
                StopAllCamera();
                cbCamera.SelectedIndex = -1;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StopAllCamera()
        {

            if (m_videoSource != null)
                m_videoSource.Stop();

            picCamera.Image = null;
            btnRead.Enabled = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormWebcam_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerProgressbar.Stop();
            StopAllCamera();
        }
    }
}

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
        Bitmap _bmp;

        private static Random random = new Random();
        Stopwatch m_watch;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormWebcam()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
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
            LoadWebcam();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormWebcam_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerProgressbar.Stop();
            StopWebcam();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void OnFormSelected(bool selected)
        {
            if (selected)
            {

            }
            else
            {

            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormWebcam_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (cb_webcam.Items.Count == 1)
                {
                    cb_webcam.SelectedIndex = 0;
                }
            }
            else
            {
                StopWebcam();
                cb_webcam.SelectedIndex = -1;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadResolution();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (btnRead.Text == "Start")
            {
                StartWebcam();
                btnRead.Text = "Read";
            }
            else
            {
                btnRead.Text = "Start";
                StopWebcam();
                ReadPlateAsync();
            }           
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void LoadWebcam()
        {
            cb_webcam.Items.Clear();

            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videosources.Count == 0)
            {
                FormMain.GetInstance().PrintError("Can not find camera");
                return;
            }


            for (int i = 0; i < videosources.Count; i++)
            {
                cb_webcam.Items.Add(videosources[i].Name);
            }
            cb_webcam.Enabled = true;
            if (cb_webcam.Items.Count == 1)
            {
                cb_webcam.SelectedIndex = 0;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void StartWebcam()
        {
            if (cb_webcam.Items.Count == 0 || cb_webcam.SelectedIndex == -1)
                return;
            if (m_videoSource != null)
            {
                m_videoSource.Stop();
            }
            else
            {
                FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                m_videoSource = new VideoCaptureDevice(videosources[cb_webcam.SelectedIndex].MonikerString);
            }

            m_videoSource.NewFrame += new NewFrameEventHandler(OnWebcamFrame);
            m_videoSource.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnWebcamFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (_bmp != null)
                _bmp.Dispose();


            _bmp = (Bitmap)eventArgs.Frame.Clone();
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

        public void StopWebcam()
        {
            if (m_videoSource != null)
                m_videoSource.Stop();
        }
        
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void LoadResolution()
        {
            if (cb_webcam.Items.Count == 0)
                return;

            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videosources[cb_webcam.SelectedIndex].MonikerString);

            cb_resolution.Items.Clear();
            foreach (var cap in videoSource.VideoCapabilities)
            {
                cb_resolution.Items.Add(cap.FrameSize.Width + "x" + cap.FrameSize.Height + " (" + cap.MaximumFrameRate + " FPS)");
            }
            if (cb_resolution.Items.Count > 0)
            {
                cb_resolution.SelectedIndex = 0;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ReadPlateAsync()
        {
            if(chk_save.Checked)
            {
                string filePath = "input\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".jpg";
                _bmp.Save(filePath, ImageFormat.Jpeg);
            }            

            FormMain.GetInstance().PrintMessage("");
            circle1.Visible = true;


            Thread t = new Thread(() => ReadPlate((Bitmap)_bmp.Clone()));
            t.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ReadPlate(Bitmap bmp)
        {
            m_watch = Stopwatch.StartNew();
            VehiclePlate[] plates = Program.reader.Reads(bmp, false);
            m_watch.Stop();

            circle1.Visible = false;

            if (plates.Length == 0)
            {
                lbl_result.Text = "Không tìm thấy biển số";
                return;
            }
                

            VehiclePlate plate = plates[0];

            this.Invoke(new Action(() =>
            {
                FormMain.GetInstance().PrintMessage("Elapsed: " + m_watch.ElapsedMilliseconds.ToString() + "ms");

                lbl_result.Text = plate.text;

                lbl_result.ForeColor = plate.isValid ? Color.FromArgb(21, 66, 139) : Color.Red;

                if (plate.bitmap == null)
                {
                    lbl_result.Text = plate.error;
                }
                else
                {
                    picResult.Image = plate.bitmap;                    
                }
            }));
        }
    }
}

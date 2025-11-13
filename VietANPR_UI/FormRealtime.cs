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
using TGMTcs;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;

namespace VietANPR_UI
{
    public partial class FormRealtime : Form
    {
        static FormRealtime m_instance;
        VideoCaptureDevice m_videoSource;
        Bitmap g_bmp;

        private static Random random = new Random();
        Stopwatch watch;
        bool m_showValidOnly = true;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormRealtime()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormRealtime GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormRealtime();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = TGMTregistry.GetInstance().ReadInt("interval", 500);

            Directory.CreateDirectory("input");
            InitCamera();

            timerDetect.Interval = (int)numericUpDown1.Value;
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

            btn_start.PerformClick();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnCameraFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (g_bmp != null)
                g_bmp.Dispose();

            if (eventArgs.Frame == null)
                return;

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
        

        private void btn_start_Click(object sender, EventArgs e)
        {
            if(btn_start.Text == "Start")
            {
                btn_start.Text = "Stop";
                timerDetect.Start();
                numericUpDown1.Enabled = false;
            }
            else
            {
                btn_start.Text = "Start";
                timerDetect.Stop();
                numericUpDown1.Enabled = true;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Read(Bitmap bmp)
        {
            try
            {
                if (bmp == null)
                    return;

                lbl_result.Text = "";
                watch = Stopwatch.StartNew();

                VehiclePlate[] plates = Program.reader.Reads(bmp);
                watch.Stop();

                if (plates.Length == 0)
                    return;

                VehiclePlate plate = plates[0];

                if (plate.text == "")
                {
                    lbl_result.Text = plate.error;
                }
                else
                {
                    if (m_showValidOnly && !plate.isValid)
                    {
                        timerDetect.Start();
                        return;
                    }


                    lbl_result.Text = plate.text;
                    lbl_result.ForeColor = plate.isValid ? Color.White : Color.Red;
                    if (plate.bitmap == null)
                    {
                        FormMain.GetInstance().PrintError(plate.error);
                    }
                    else
                    {
                        UC.UCplate ucPlate = new UC.UCplate();
                        ucPlate.picResult.Image = (Bitmap)plate.bitmap.Clone();
                        ucPlate.lblPlate.Text = plate.text;
                        ucPlate.lblPlate.ForeColor = plate.isValid ? Color.Green : Color.Red;
                        panelResult.Controls.Add(ucPlate);
                        FormMain.GetInstance().PrintMessage("Elapsed: " + watch.ElapsedMilliseconds.ToString() + "ms");
                    }
                }

                
            }
            catch(Exception ex)
            {

            }            
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
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormRealtime_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerDetect.Stop();
            StopAllCamera();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerDetect_Tick(object sender, EventArgs e)
        {
            

            if (progressBar1.Value >= progressBar1.Maximum)
                progressBar1.Value = progressBar1.Minimum;
            progressBar1.Value += 1;
            
            try
            {
                Bitmap bmp = (Bitmap)g_bmp.Clone();
                if (bmp == null)
                {
                    return;
                }

                timerDetect.Stop();
                Read(bmp);
                timerDetect.Start();
            }
            catch(Exception ex)
            {
                timerDetect.Start();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timerDetect.Interval = (int)numericUpDown1.Value;
            TGMTregistry.GetInstance().SaveValue("interval", numericUpDown1.Value);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_clear_Click(object sender, EventArgs e)
        {
            panelResult.Controls.Clear();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rd_validOnly_CheckedChanged(object sender, EventArgs e)
        {
            m_showValidOnly = rd_validOnly.Checked;
        }
    }
}

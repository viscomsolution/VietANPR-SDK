using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TGMT;
using TGMTcs;


namespace MiniServer
{
    public partial class FormMain : Form
    {
        PerformanceCounter _cpuCounter;

        [StructLayout(LayoutKind.Sequential)]
        public struct nvmlUtilization_t
        {
            public uint gpu;
            public uint memory;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct nvmlMemory_t
        {
            public ulong total;
            public ulong free;
            public ulong used;
        }

        [DllImport("nvml.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nvmlDeviceGetHandleByIndex_v2(
            uint index,
            out IntPtr device);

        [DllImport("nvml.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nvmlDeviceGetUtilizationRates(
            IntPtr device,
            out nvmlUtilization_t utilization);

        

        [DllImport("nvml.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int nvmlDeviceGetMemoryInfo(
            IntPtr device,
            out nvmlMemory_t memory);


        DateTime _startupTime = DateTime.Now;
        int _port = 9999;

        int COL_FRAME = 1;

        
        List<SessionRow> _rows = new List<SessionRow>();
        List<Session> _sessions = new List<Session>();
        List<Bitmap> _imageFrames = new List<Bitmap>();

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormMain()
        {
            InitializeComponent();

            dataGridView1.VirtualMode = true;
            TGMTform.SetDoubleBuffer(dataGridView1);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(() => { StartServer(); });
            Task.Run(() => { ShowHardwareUsage(); });

            timerServer.Start();
            workerLoading.RunWorkerAsync();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_SizeChanged(object sender, EventArgs e)
        {


            //label_tong.Location = new Point((int)(panelUsage.Width / 2 - label_tong.Width), label_tong.Location.Y);
            //lbl_sum.Location = new Point(label_tong.Location.X + label_tong.Width, lbl_sum.Location.Y);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                dataGridView1.Invalidate();
            }
            else if(e.KeyCode == Keys.O)
            {                
                if(e.Control)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                    if(openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string input = openFileDialog.FileName;
                        Bitmap bmp = TGMTimage.LoadBitmapWithoutLock(input);
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_startServer_Click(object sender, EventArgs e)
        {
            if(btn_startServer.Text == "START")
            {
                Task.Run(() => { StartServer(); });
            }
            else
            {
                StopServer();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_stopServer_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerLoading_DoWork(object sender, DoWorkEventArgs e)
        {
            PlateReaderMgr.GetInstance().MaxReaders = (int)numericUpDown1.Value;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerLoading_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            PlateReaderMgr.GetInstance().MaxReaders = (int)numericUpDown1.Value;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void StartServer()
        {
            if(TGMTserver.GetInstance().onPostRequest == null)
            {
                TGMTserver.GetInstance().onPostRequest += OnPostRequest;
            }
            
            TGMTserver.GetInstance().Start(_port);

            TGMTthread.BeginInvokeSafe(this, () => {
                lbl_serverStatus.Text = "RUNNING";
                btn_startServer.Text = "STOP";
                lbl_address.Text = $"http://{TGMThardware.GetIPAddress()}:{_port}";
            });

            Console.WriteLine(TGMThardware.GetMacAddress());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void StopServer()
        {            
            TGMTserver.GetInstance().Stop();
            lbl_serverStatus.Text = "STOPPED";
            btn_startServer.Text = "START";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void ShowHardwareUsage()
        {            
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");


            string GPUname = TGMThardware.GetGPUname();
            if(GPUname != "")
            {
                TGMTthread.BeginInvokeSafe(this, () =>
                {
                    lbl_GPU.Text = GPUname.ToString();
                });
            }           


            TGMTthread.BeginInvokeSafe(this, () => {
                lbl_CPUname.Text = TGMThardware.GetCpuName();
                timerHardware.Start();
            });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerHardware_Tick(object sender, EventArgs e)
        {
            try
            {
                lbl_CPU.Text = _cpuCounter.NextValue().ToString("F1") + "%";

                double usedMB, totalMB, percent;
                TGMThardware.GetMemory(out usedMB, out totalMB, out percent);

                lbl_RAM.Text = $"{usedMB:N0}/ {totalMB:N0} MB ({percent:N0}%)";

                string nvmlPath = @"C:\Windows\System32\nvml.dll";
                if(File.Exists(nvmlPath))
                {

                    IntPtr GPUpointer;
                    nvmlDeviceGetHandleByIndex_v2(0, out GPUpointer);

                    nvmlUtilization_t util;
                    nvmlDeviceGetUtilizationRates(GPUpointer, out util);

                    lbl_CUDA.Text = util.gpu + "%";


                    nvmlMemory_t mem;
                    nvmlDeviceGetMemoryInfo(GPUpointer, out mem);

                    double VRAMusage = mem.used / 1024 / 1024;
                    double VRAMtotal = mem.total / 1024 / 1024;
                    lbl_VRAM.Text = $"{VRAMusage:N0}/{VRAMtotal:N0} MB ({util.memory}%)";
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerServer_Tick(object sender, EventArgs e)
        {
            lbl_upTime.Text = (DateTime.Now - _startupTime).ToString(@"dd\.hh\:mm\:ss");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if(e.RowIndex < 0 || e.RowIndex >= _rows.Count)
                return;


            Session session = _sessions[e.RowIndex];
            var row = _rows[e.RowIndex];


            if(e.ColumnIndex == COL_FRAME)
            {
                e.Value = LoadThumb(_imageFrames, e.RowIndex);
            }
            else
            {
                e.Value = row.Values[e.ColumnIndex];
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Bitmap LoadThumb(List<Bitmap> imageList, int rowIndex)
        {
            if(rowIndex > -1 && rowIndex < imageList.Count)
            {
                return imageList[rowIndex];
            }

            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void OnPostRequest(HttpListenerRequest req, HttpListenerResponse res)
        {
            if(req.Url.AbsolutePath.EndsWith("/recognize"))
            {
                HandleRecognize(req, res);
            }
            else
            {
                JObject obj = new JObject();
                obj["status"] = "ERROR";
                obj["message"] = "Unknown endpoint.";
                TGMTserver.WriteText(res, obj.ToString());
                res.Close();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void HandleRecognize(HttpListenerRequest req, HttpListenerResponse res)
        {
            Dictionary<string, string> param = TGMTserver.GetParam(req);
            JObject obj = new JObject();

            if(!param.ContainsKey("imageBase64"))
            {
                obj["status"] = "ERROR";
                obj["message"] = "Missing card parameter.";
            }
            else
            {
                string imageBase64 = param["imageBase64"];
                bool cropped = param.ContainsKey("cropped") && param["cropped"] == "true";

                Bitmap bmp = (Bitmap)TGMTimage.Base64ToImage(imageBase64);

                Stopwatch sw = new Stopwatch();
                sw.Start();
                VehiclePlate[] plates = PlateReaderMgr.GetInstance().Reads(bmp, cropped);
                sw.Stop();

                JArray objects = new JArray();
                for(int i=0; i < plates.Length; i++)
                {
                    VehiclePlate plate = plates[i];
                    JObject plateObj = new JObject();
                    if(plate != null)
                    {
                        plateObj["text"] = plate.text;
                        plateObj["scoreQuad"] = plate.scoreQuad;
                        plateObj["scoreText"] = plate.scoreText;
                        plateObj["rect"] = new JObject
                        {
                            ["x"] = plate.rect.X,
                            ["y"] = plate.rect.Y,
                            ["width"] = plate.rect.Width,
                            ["height"] = plate.rect.Height
                        };
                    }
                    else
                    {
                        plateObj["text"] = "";
                        plateObj["scoreQuad"] = 0;
                        plateObj["scoreText"] = 0;
                        plateObj["rect"] = new JObject
                        {
                            ["x"] = 0,
                            ["y"] = 0,
                            ["width"] = 0,
                            ["height"] = 0
                        };
                    }
                    objects.Add(plateObj);
                }
                

                obj["objects"] = objects.ToString(Newtonsoft.Json.Formatting.None);
                obj["status"] = "OK";

                Task.Run(() =>
                {
                    DisplayToGrid(bmp, plates, sw.ElapsedMilliseconds);
                });
            }

            

            TGMTserver.WriteText(res, obj.ToString());
            res.Close();

            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void DisplayToGrid(Bitmap bmp, VehiclePlate[] plates, long elapsed)
        {
            if(plates == null || plates.Length == 0)
                return;
            for(int i = 0; i < plates.Length; i++)
            {
                VehiclePlate plate = plates[i];

                Session s = new Session
                {
                    Text = plate.text,
                    Alphanumeric = plate.alphanumeric,
                    CheckinTime = DateTime.Now,
                };
                _sessions.Insert(0, s);

                _rows.Insert(0, new SessionRow
                {
                    Values = new object[]
                    {
                        _rows.Count + 1,
                        "",
                        plate.text,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        elapsed,
                        "192.168.1.27",
                        "POST"
                    },
                });

                Bitmap thumb = TGMTimage.ResizeBitmapByHeight(bmp, 150);
                _imageFrames.Insert(0, thumb);
            }                       
            

            TGMTthread.BeginInvokeSafe(this, () => {
                dataGridView1.RowCount = _rows.Count;
                dataGridView1.Refresh();
            });

        }


    }
}

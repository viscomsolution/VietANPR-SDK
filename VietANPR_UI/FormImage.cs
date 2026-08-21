using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TGMT;
using TGMTcs;
using System.IO;
using OpenCV;
using System.Threading.Tasks;
using VietANPR_UI.UC;

namespace VietANPR_UI
{
    public partial class FormImage : Form
    {
        static FormImage m_instance;
        Stopwatch watch;

        Pen pen_blue_thick = new Pen(Color.FromArgb(40, 134, 255), 2);
        Brush blue_brush_soft = new SolidBrush(Color.FromArgb(100, Color.FromArgb(40, 134, 255)));

        Color colorBlue = Color.FromArgb(40, 134, 255);
        Color colorRed = Color.FromArgb(255, 1, 228);
        Pen pen_red = new Pen(Color.FromArgb(255, 2, 228));

        VehiclePlate[] m_results;
        Bitmap m_bmp;

        double m_scaleX = 0;
        double m_scaleY = 0;
        double m_aspect = 0;

        int m_selectedIndex = -1;
        bool _inited = false;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormImage()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormImage GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormImage();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormImage_Load(object sender, EventArgs e)
        {
            txt_fileName.Text = TGMTregistry.GetInstance().ReadString("txt_fileName");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormImage_Shown(object sender, EventArgs e)
        {
            _inited = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormImage_SizeChanged(object sender, EventArgs e)
        {
            AdjustSize();
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

        private void txt_fileName_TextChanged(object sender, EventArgs e)
        {
            m_bmp = TGMTimage.LoadBitmapWithoutLock(txt_fileName.Text);
            pictureBox1.Image = m_bmp;

            if(_inited)
            {
                TGMTregistry.GetInstance().SaveValue("txt_fileName", txt_fileName.Text);
                Read();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_detect_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Read();
            });
        }        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (m_results == null || m_results.Length == 0)
                return;

            for (int i = 0; i < m_results.Length; i++)
            {
                VehiclePlate plate = m_results[i];
                List<Point> drawPoints = new List<Point>();
                drawPoints.Add(new Point(plate.top_left.X, plate.top_left.Y));
                drawPoints.Add(new Point(plate.top_right.X, plate.top_right.Y));
                drawPoints.Add(new Point(plate.bottom_right.X, plate.bottom_right.Y));
                drawPoints.Add(new Point(plate.bottom_left.X, plate.bottom_left.Y));

                drawPoints = ConvertToDrawPoint(drawPoints);

                if(i == m_selectedIndex)
                {
                    e.Graphics.DrawPolygon(pen_red, drawPoints.ToArray());
                }
                else
                {
                    e.Graphics.DrawPolygon(pen_blue_thick, drawPoints.ToArray());
                    e.Graphics.FillPolygon(blue_brush_soft, drawPoints.ToArray());
                }
                
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        List<Point> ConvertToDrawPoint(List<Point> pointFs)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < pointFs.Count; i++)
            {
                Point pointF = pointFs[i];
                Point point = new Point();
                point.X = (int)(pointF.X / m_scaleX);
                point.Y = (int)(pointF.Y / m_scaleY);

                points.Add(point);
            }

            return points;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Read()
        {
            TGMTthread.InvokeSafe(this, () =>
            {
                if(txt_fileName.Text == "")
                    return;

                string fileName = txt_fileName.Text.Replace("\"", "");
                if(!File.Exists(fileName))
                {
                    FormMain.GetInstance().PrintError("File not exist");
                    return;
                }

                panelResult.Controls.Clear();


                string ext = Path.GetExtension(fileName).ToLower();
                if(ext == ".webp")
                {
                    m_bmp = ImgCodec.imread(fileName);
                }
                else
                {
                    m_bmp = TGMTimage.LoadBitmapWithoutLock(fileName);
                }

                if(m_bmp != null)
                {
                    pictureBox1.Image = m_bmp;

                    AdjustSize();

                    FormMain.GetInstance().PrintMessage("");
                    FormMain.GetInstance().StartProgressbar();

                    watch = Stopwatch.StartNew();
                    Read(fileName);
                }
            });
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Read(string imagePath)
        {
            string text = "";

            FormMain.GetInstance().PrintMessage("");

            Bitmap frame = TGMTimage.LoadBitmapWithoutLock(imagePath);
            m_results = Program.reader.Reads(imagePath);

            if (m_results.Length > 0)
            {
                VehiclePlate plate = m_results[0];
                if(plate.bitmap != null)
                {
                    pictureBox1.Image = plate.bitmap;
                    pictureBox1.Refresh();
                }                   


                for (int i=0; i< m_results.Length; i++)
                {
                    plate = m_results[i];

                    Bitmap bmlPlate = TGMTimage.CropBitmap(frame, plate.rect);

                    UCplate uc = new UCplate();
                    uc.picResult.Image = bmlPlate;
                    uc.lbl_plate.Text = plate.text;
                    uc.lbl_num.Text = (i + 1).ToString();
                    uc.lbl_scoreQuad.Text = "Score: " + plate.scoreText.ToString("N2");

                    panelResult.Controls.Add(uc);
                }

                string ext = Path.GetExtension(imagePath).ToLower();
                Bitmap bmp;
                if(ext == ".webp")
                    bmp = ImgCodec.imread(imagePath);
                else
                    bmp = new Bitmap(imagePath);
 
            }
            else
            {
                FormMain.GetInstance().PrintMessage("Không tìm thấy biển số");
            }
            


            FormMain.GetInstance().StopProgressbar();
            watch.Stop();
            FormMain.GetInstance().PrintMessage(watch.ElapsedMilliseconds + " ms");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void AdjustSize()
        {
            if (m_bmp == null)
            {
                pictureBox1.Width = panelPicture.Width;
                pictureBox1.Height = panelPicture.Height;
                return;
            }

            int thickness = (int)Math.Round((float)m_bmp.Width / 1000);
            pen_red = new Pen(colorRed, thickness);
            pen_blue_thick = new Pen(colorBlue, thickness);

            m_aspect = (double)m_bmp.Width / (double)m_bmp.Height;
            double panelAspect = (double)panelPicture.Width / (double)panelPicture.Height;
            if (m_aspect > panelAspect)
            {
                pictureBox1.Width = panelPicture.Width;
                pictureBox1.Height = (int)(pictureBox1.Width / m_aspect);
            }
            else if (m_aspect < panelAspect)
            {
                pictureBox1.Height = panelPicture.Height;
                pictureBox1.Width = (int)(pictureBox1.Height * m_aspect);
            }
            m_scaleX = (double)m_bmp.Width / pictureBox1.Width;
            m_scaleY = (double)m_bmp.Height / pictureBox1.Height;
        }
    }
}

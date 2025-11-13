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

namespace VietANPR_UI
{
    public partial class FormImage : Form
    {
        static FormImage m_instance;
        Stopwatch watch;

        public FormImage()
        {
            InitializeComponent();
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
            chk_draw.Checked = Program.reader.DrawRectangle;
            chk_crop.Checked = Program.reader.CropPlate;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_select_Click(object sender, EventArgs e)
        {
            txt_fileName.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image file |*.jpg;*.png*.bmp;*.PNG;";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                txt_fileName.Text = ofd.FileName;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_crop_CheckedChanged(object sender, EventArgs e)
        {
            Program.reader.CropPlate = chk_crop.Checked;
            TGMTregistry.GetInstance().SaveValue("CropPlate", chk_crop.Checked);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_draw_CheckedChanged(object sender, EventArgs e)
        {
            Program.reader.DrawRectangle = chk_draw.Checked;
            TGMTregistry.GetInstance().SaveValue("DrawRectangle", chk_draw.Checked);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_fileName_TextChanged(object sender, EventArgs e)
        {
            Read();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Read()
        {
            if (txt_fileName.Text == "")
                return;

            string fileName = txt_fileName.Text.Replace("\"", "");
            if(!File.Exists(fileName))
            {
                FormMain.GetInstance().PrintError("File not exist");
                return;
            }
            lbl_result.Text = "";
            Bitmap bmp = TGMTimage.LoadBitmapWithoutLock(fileName);
            if (bmp != null)
            {
                picResult.Image = bmp;
                FormMain.GetInstance().PrintMessage("");
                FormMain.GetInstance().StartProgressbar();

                watch = Stopwatch.StartNew();
                Read(fileName);
            }
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Read(string imagePath)
        {
            string text = "";

            FormMain.GetInstance().PrintMessage("");

            VehiclePlate plate = null;
            if (Program.readingMode == ReadingMode.Best)
            {
                plate = Program.reader.Read(imagePath);
                if(plate != null)
                {
                    text = plate.text;
                }                
            }
            else
            {                
                VehiclePlate[] results = Program.reader.Reads(imagePath);

                if(results.Length > 0)
                {
                    Bitmap bmp = new Bitmap(imagePath);
                    int thickness = (int)Math.Round((float)bmp.Width / 200);

                    if (Program.readingMode == ReadingMode.All)
                    {                        
                        if (results.Length == 1)
                        {
                            text = results[0].text;
                            if(results[0].bitmap == null)
                            {
                                bmp = TGMTdraw.DrawRectangle(bmp, results[0].rect, Color.Green, false, thickness);
                            }
                            else
                            {
                                bmp = results[0].bitmap;
                            }                            
                        }
                        else
                        {
                            for (int i = 0; i < results.Length; i++)
                            {
                                text += results[i].text + Program.delimiter;
                                bmp = TGMTdraw.DrawRectangle(bmp, results[i].rect, Color.Green, false, thickness);
                            }
                        }
                    }
                    else if (Program.readingMode == ReadingMode.Biggest)
                    {
                        plate = ParkingUtil.GetBiggest(results);
                        text = plate.text;
                        bmp = TGMTdraw.DrawRectangle(bmp, plate.rect, Color.Green, false, thickness);
                    }
                    else if (Program.readingMode == ReadingMode.Center)
                    {                        
                        plate = ParkingUtil.GetNearestCenter(bmp, results);
                        text = plate.text;
                        bmp = TGMTdraw.DrawRectangle(bmp, plate.rect, Color.Green, false, thickness);
                    }

                    picResult.Image = bmp;
                }
                else
                {
                    text = "Không tìm thấy biển số";
                }
            }

            lbl_result.Text = text;

            FormMain.GetInstance().StopProgressbar();

            watch.Stop();

            FormMain.GetInstance().PrintMessage(watch.ElapsedMilliseconds + " ms");

            if (plate == null)
                return;

            
            

            if (plate.bitmap == null)
            {
                FormMain.GetInstance().PrintMessage(plate.error);
            }
            else
            {                    
                picResult.Image = plate.bitmap;
                FormMain.GetInstance().PrintMessage("Elapsed: " + watch.ElapsedMilliseconds.ToString() + "ms");

                string outputName = "output\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".jpg";
                plate.bitmap.Save(outputName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }           

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_detect_Click(object sender, EventArgs e)
        {
            Read();
        }
    }
}

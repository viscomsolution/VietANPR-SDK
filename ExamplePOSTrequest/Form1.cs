using ExamplePOSTrequest.UC;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TGMTcs;

namespace ExamplePOSTrequest
{
    public partial class Form1 : Form
    {
        Bitmap m_bmp;
        bool _inited = false;

        public Form1()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_serverIP.Text = TGMTini.GetInstance().ReadString("txt_serverIP");
            txt_serverPort.Text = TGMTini.GetInstance().ReadString("txt_serverPort");
            txt_filePath.Text = TGMTini.GetInstance().ReadString("txt_filePath");

            _inited = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_serverIP_TextChanged(object sender, EventArgs e)
        {
            if(!_inited)
                return;

            TGMTini.GetInstance().SaveValue("txt_serverIP", txt_serverIP.Text);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_serverPort_TextChanged(object sender, EventArgs e)
        {
            if(!_inited)
                return;

            TGMTini.GetInstance().SaveValue("txt_serverPort", txt_serverPort.Text);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_filePath_TextChanged(object sender, EventArgs e)
        {            
            m_bmp = TGMTimage.LoadBitmapWithoutLock(txt_filePath.Text);
            pictureBox1.Image = m_bmp;

            if(_inited)
            {
                TGMTini.GetInstance().SaveValue("txt_filePath", txt_filePath.Text);                
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_send_Click(object sender, EventArgs e)
        {
            if(m_bmp == null)
            {
                MessageBox.Show("Please select an image first.");
                return;
            }

            panelResult.Controls.Clear();
            SendImageToServer(m_bmp, false);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void SendImageToServer(Bitmap bmp, bool cropped)
        {
            string url = $"http://{txt_serverIP.Text}:{txt_serverPort.Text}/recognize";

            string imageBase64 = TGMTimage.ImageToBase64(bmp);
            var param = new Dictionary<string, string>() 
            { 
                { "imageBase64", imageBase64 },
                { "cropped", cropped ? "true" : "false" }
            };


            TGMTonline.SendPOSTrequest(url, param, OnResponse);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnResponse(int code, string respond)
        {
            if(code != 200)
            {
                MessageBox.Show("Error: " + code + "\n" + respond);
                return;
            }

            JObject root = JObject.Parse(respond);

            string status = (string)root["status"];
            string message = (string)root["message"];
            string objectsJson = (string)root["objects"]; // this is a string containing JSON array text

            if(string.IsNullOrWhiteSpace(objectsJson))
            {
                MessageBox.Show("No objects found.\nStatus: " + status + "\nMessage: " + message);
                return;
            }

            JArray objects = JArray.Parse(objectsJson);

            for(int i = 0; i < objects.Count; i++)
            {
                JObject obj = objects[i] as JObject;
                if(obj == null)
                    continue;

                string text = (string)obj["text"];
                float scoreQuad = obj["scoreQuad"] != null ? (float)obj["scoreQuad"] : 0f;
                float scoreText = obj["scoreText"] != null ? (float)obj["scoreText"] : 0f;

                JObject rectObj = obj["rect"] as JObject;
                int x = rectObj != null && rectObj["x"] != null ? (int)rectObj["x"] : 0;
                int y = rectObj != null && rectObj["y"] != null ? (int)rectObj["y"] : 0;
                int width = rectObj != null && rectObj["width"] != null ? (int)rectObj["width"] : 0;
                int height = rectObj != null && rectObj["height"] != null ? (int)rectObj["height"] : 0;

                Rectangle rect = new Rectangle(x, y, width, height);
                Console.WriteLine($"Plate: {text}, scoreQuad: {scoreQuad}, scoreText: {scoreText}, rect: ({x},{y},{width},{height})");

                UCplate uc = new UCplate();
                uc.picResult.Image = TGMTimage.CropBitmap(m_bmp, rect);
                uc.lbl_plate.Text = text;
                uc.lbl_num.Text = (i + 1).ToString();
                uc.lbl_scoreQuad.Text = "Score: " + scoreText.ToString("N2");

                TGMTthread.BeginInvokeSafe(this, () =>
                {
                    panelResult.Controls.Add(uc);
                });
            }
        }
    }
}

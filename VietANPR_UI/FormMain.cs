using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMT;
using TGMTcs;

namespace VietANPR_UI
{
    public partial class FormMain : Form
    {
        
        static FormMain m_instance;
        Button currentButton;
        Form activeForm;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormMain()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormMain GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormMain();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormMain_Load(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().Init("IPSS");

            Program.readingMode = (ReadingMode) TGMTregistry.GetInstance().ReadInt("ReadingMode", (int)ReadingMode.Best);


            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();

            StartProgressbar();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Program.reader = new PlateReader();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Program.reader.CropPlate = TGMTregistry.GetInstance().ReadBool("CropPlate");


            StopProgressbar();

            if(!Program.reader.IsLicenseActivated)
                this.Text += " | Vui lòng liên hệ 0939.825.125";

            lbl_version.Text = Program.reader.Version;

            string childform = TGMTregistry.GetInstance().ReadString("childform");
            if (childform == "" || childform == "FormImage")
                btnImage.PerformClick();
            else if (childform == "FormWebcam")
                btnWebcam.PerformClick();
            else if (childform == "FormFolder")
                btnFolder.PerformClick();
            else if (childform == "FormRealtime")
                btn_realtime.PerformClick();
            else
                btnImage.PerformClick();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnWebcam_Click(object sender, EventArgs e)
        {
            OpenChildForm(FormWebcam.GetInstance(), sender);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenChildForm(FormImage.GetInstance(), sender);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnFolder_Click(object sender, EventArgs e)
        {
            OpenChildForm(FormFolder.GetInstance(), sender);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_ipCamera_Click(object sender, EventArgs e)
        {
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_realtime_Click(object sender, EventArgs e)
        {
            OpenChildForm(FormRealtime.GetInstance(), sender);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(FormSettings.GetInstance(), sender);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintError(string message)
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = DateTime.Now.ToString("(hh:mm:ss)") + message;

            timerClear.Stop();
            timerClear.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintSuccess(string message)
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = DateTime.Now.ToString("(hh:mm:ss)") + message;
            timerClear.Stop();
            timerClear.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintMessage(string message)
        {
            lblMessage.ForeColor = Color.Black;
            lblMessage.Text = DateTime.Now.ToString("(hh:mm:ss)") + message;
            timerClear.Stop();
            timerClear.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Hide();
            }

            ActiveButton(btnSender);

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            TGMTregistry.GetInstance().SaveValue("childform", childForm.Name);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;

                    Color color = SelectThemeColor(currentButton);
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Microsoft Sans Serif", 12.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Color SelectThemeColor(Button btn)
        {
            int index = FindIndexOfBtn(btn);
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        int FindIndexOfBtn(Button btn)
        {
            int index = -1;
            foreach (Control ctrl in panelMenu.Controls)
            {
                if (ctrl.GetType() == typeof(Button))
                {
                    index++;
                    if ((Button)ctrl == btn)
                    {
                        return index;
                    }
                }
            }

            return index;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StartProgressbar()
        {
            timerProgressbar.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StopProgressbar()
        {
            timerProgressbar.Stop();
            progressBar1.Value = progressBar1.Minimum;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerProgressbar_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= progressBar1.Maximum)
                progressBar1.Value = progressBar1.Minimum;
            progressBar1.Value += 1;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(activeForm != null)
                activeForm.Close();
        }

        
    }
}
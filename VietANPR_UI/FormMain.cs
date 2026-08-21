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
using TGMTcontrols;
using TGMTcs;

namespace VietANPR_UI
{
    public partial class FormMain : Form
    {        
        static FormMain m_instance;
        Button currentButton;
        Form activeForm;
        List<string> _formOpeneds = new List<string>();

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
            TGMTregistry.GetInstance().Init("VietANPR");

            this.Text += " " + TGMTutil.GetVersion();
#if DEBUG
            this.Text += " *";
#endif

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();

            StartProgressbar();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormMain_Shown(object sender, EventArgs e)
        {
            gradientTab1.SelectedIndex = TGMTregistry.GetInstance().ReadInt("selected_tab_index", 0);
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_option_Click(object sender, EventArgs e)
        {
            new FormSettings().ShowDialog();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Program.reader = new PlateReader();
            Program.reader.MinScoreText = 0.7f;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Program.reader.CropPlate = TGMTregistry.GetInstance().ReadBool("CropPlate");

            AddFormToTab();
            StopProgressbar();


            if(!Program.reader.IsLicenseActivated)
                this.Text += " | Vui lòng liên hệ: 0939.825.125";
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void AddFormToTab()
        {
            if(gradientTab1.SelectedIndex == 0)
            {
                if(_formOpeneds.Contains("FormImage") == false)
                {
                    _formOpeneds.Add("FormImage");
                    tabPage1.Controls.Add(FormImage.GetInstance());
                    FormImage.GetInstance().Show();
                }
            }
            else if(gradientTab1.SelectedIndex == 1)
            {
                if(_formOpeneds.Contains("FormFolder") == false)
                {
                    _formOpeneds.Add("FormFolder");
                    tabPage2.Controls.Add(FormFolder.GetInstance());
                    FormFolder.GetInstance().Show();
                }
            }
            else if(gradientTab1.SelectedIndex == 2)
            {
                if(_formOpeneds.Contains("FormWebcam") == false)
                {
                    _formOpeneds.Add("FormWebcam");
                    tabPage3.Controls.Add(FormWebcam.GetInstance());
                    FormWebcam.GetInstance().Show();
                }
            }

            gradientTab1.SelectedIndex = TGMTregistry.GetInstance().ReadInt("selected_tab_index", 0);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("selected_tab_index", gradientTab1.SelectedIndex);

            AddFormToTab();

            FormImage.GetInstance().OnFormSelected(gradientTab1.SelectedIndex == 0);
            FormFolder.GetInstance().OnFormSelected(gradientTab1.SelectedIndex == 1);
            FormWebcam.GetInstance().OnFormSelected(gradientTab1.SelectedIndex == 2);
        }
    }
}
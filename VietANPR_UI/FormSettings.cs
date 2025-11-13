using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using TGMT;
using System.Windows.Forms;
using TGMTcs;

namespace VietANPR_UI
{
    public partial class FormSettings : Form
    {
        static FormSettings m_instance;

        public FormSettings()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormSettings GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormSettings();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormSettings_Load(object sender, EventArgs e)
        {
            if (Program.readingMode == ReadingMode.All)
                rd_all.Checked = true;
            else if (Program.readingMode == ReadingMode.Best)
                rd_topLeft.Checked = true;
            else if (Program.readingMode == ReadingMode.Biggest)
                rd_biggest.Checked = true;
            else if (Program.readingMode == ReadingMode.Center)
                rd_center.Checked = true;
            else
                rd_topLeft.Checked = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(rd_all.Checked)
                Program.readingMode = ReadingMode.All;
            else if (rd_topLeft.Checked)
                Program.readingMode = ReadingMode.Best;
            else if (rd_biggest.Checked)
                Program.readingMode = ReadingMode.Biggest;
            else if (rd_center.Checked)
                Program.readingMode = ReadingMode.Center;


            TGMTregistry.GetInstance().SaveValue("ReadingMode", (int)Program.readingMode);

            FormMain.GetInstance().PrintSuccess("Save thành công");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniServer
{
    public partial class FormOption : Form
    {
        public FormOption()
        {
            InitializeComponent();
        }

        private void FormOption_Load(object sender, EventArgs e)
        {
            txt_serverPort.Text = Program.port.ToString();
            txt_secretKey.Text = Program.secretKey;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Program.port = int.Parse(txt_serverPort.Text);
            Program.secretKey = txt_secretKey.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

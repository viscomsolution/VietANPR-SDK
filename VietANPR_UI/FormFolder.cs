using Microsoft.VisualBasic.FileIO;
using NAudio;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMT;
using TGMTcs;

namespace VietANPR_UI
{
    public partial class FormFolder : Form
    {
        string m_folderOutput = "";
        //List<Plate> m_plates = new List<Plate>();

        static FormFolder m_instance;
        bool m_multithread = false;

        List<PlateReader> m_readers = new List<PlateReader>();
        List<bool> m_readerAvailables = new List<bool>();
        object m_lock = new object();

        int MAX_READER = 1;

        int m_exactlyCount = 0;
        string m_content = "";

        bool m_loaded = false;
        ManualResetEvent readerAvailableEvent = new ManualResetEvent(true);

        List<VehiclePlate[]> _listResults = new List<VehiclePlate[]>();

        Pen pen_blue_thick = new Pen(Color.FromArgb(40, 134, 255), 2);
        Brush blue_brush_soft = new SolidBrush(Color.FromArgb(100, Color.FromArgb(40, 134, 255)));

        double m_scaleX = 0;
        double m_scaleY = 0;
        double m_aspect = 0;

        Bitmap m_bmp = null;
        int m_selectedPlateIndex = -1;

        Pen pen_red = new Pen(Color.FromArgb(255, 2, 228));

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormFolder()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            this.AutoScaleMode = AutoScaleMode.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormFolder_Load(object sender, EventArgs e)
        {
            txtFolderInput.Text = TGMTregistry.GetInstance().ReadString("folderInput");
            txtFailedDir.Text = TGMTregistry.GetInstance().ReadString("txtFailedDir");
            txtValidDir.Text = TGMTregistry.GetInstance().ReadString("txtValidDir");
            txtInvalidDir.Text = TGMTregistry.GetInstance().ReadString("txtInvalidDir");

            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                int width = TGMTregistry.GetInstance().ReadInt("column_" + i.ToString() + "_width", -1);
                if (width > -1)
                {
                    listView1.Columns[i].Width = width;
                }
            }
            m_loaded = true;
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

        private void FormFolder_SizeChanged(object sender, EventArgs e)
        {
            int padding = 30;
            listView1.Width = this.Width / 2 + padding;

            AdjustSize();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormFolder GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormFolder();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;

            DisplayResultImage();

            int selectedIndex = listView1.SelectedIndices[0];
            if (selectedIndex >= 0 && selectedIndex < _listResults.Count)
            {
                listView2.Items.Clear();
                VehiclePlate[] plates = _listResults[selectedIndex];
                for (int i = 0; i < plates.Length; i++)
                {
                    VehiclePlate plate = plates[i];
                    ListViewItem item = new ListViewItem((i + 1).ToString());
                    item.SubItems.Add(plate.text);
                    item.SubItems.Add(plate.alphanumeric);
                    item.SubItems.Add(plate.scoreQuad.ToString("N2"));

                    listView2.Items.Add(item);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_selectedPlateIndex = listView2.SelectedIndices.Count > 0 ? listView2.SelectedIndices[0] : -1;
            pictureBox1.Refresh();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> files = new List<string>();
            listView1.Items.Clear();

            string[] fileList = Directory.GetFiles(txtFolderInput.Text, "*.jpg");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            fileList = Directory.GetFiles(txtFolderInput.Text, "*.png");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            fileList = Directory.GetFiles(txtFolderInput.Text, "*.bmp");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            e.Result = files;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<string> files = (List<string>)e.Result;
            for (int i = 0; i < files.Count; i++)
            {
                listView1.Items.Add(files[i]);
            }
            FormMain.GetInstance().PrintMessage("Loaded " + listView1.Items.Count + " images");

            circle1.Visible = false;
            btnDetect.Enabled = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_KeyDown(object sender, KeyEventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
                return;
            
            string filePath = TGMTutil.CorrectPath(txtFolderInput.Text);
            filePath += listView1.SelectedItems[0].Text;
            if (e.KeyCode == Keys.Enter)
            {
                System.Diagnostics.Process.Start(filePath);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if(File.Exists(filePath))
                {
                    int currentIndex = listView1.SelectedIndices[0];

                    FileSystem.DeleteFile(filePath, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
                    listView1.Items.Remove(listView1.SelectedItems[0]);

                    
                    if (currentIndex < listView1.Items.Count)
                    {
                        listView1.Items[currentIndex].Selected = true;
                        listView1.EnsureVisible(currentIndex);
                    }                        
                    else
                    {
                        int lastIndex = currentIndex - 1;
                        if (lastIndex >= 0)
                        {
                            listView1.Items[lastIndex].Selected = true;
                            listView1.EnsureVisible(lastIndex);
                        }                            
                    }
                }
                else
                {
                    FormMain.GetInstance().PrintError("File not found: " + filePath);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void picResult_Paint(object sender, PaintEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            int selectedIndex = listView1.SelectedIndices[0];
            if (selectedIndex == -1)
                return;

            if (selectedIndex >= _listResults.Count)
                return;

            VehiclePlate[] plates = _listResults[selectedIndex];

            for (int i = 0; i < plates.Length; i++)
            {
                VehiclePlate plate = plates[i];
                List<Point> drawPoints = new List<Point>();
                drawPoints.Add(new Point(plate.top_left.X, plate.top_left.Y));
                drawPoints.Add(new Point(plate.top_right.X, plate.top_right.Y));
                drawPoints.Add(new Point(plate.bottom_right.X, plate.bottom_right.Y));
                drawPoints.Add(new Point(plate.bottom_left.X, plate.bottom_left.Y));

                drawPoints = ConvertToDrawPoint(drawPoints);

                if (i == m_selectedPlateIndex)
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

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void DisplayResultImage()
        {
            if (listView1.Items.Count == 0 || listView1.SelectedItems.Count == 0)            
                return;
            

            string fileName = listView1.SelectedItems[0].Text;


            string inputPath = TGMTutil.CorrectPath(txtFolderInput.Text);
            string failedDir = txtFailedDir.Text != "" ? TGMTutil.CorrectPath(txtFailedDir.Text) : "";


            if (m_folderOutput != "" && File.Exists(m_folderOutput + fileName))
            {
                m_bmp = TGMTimage.LoadBitmapWithoutLock(m_folderOutput + fileName);
                FormMain.GetInstance().PrintMessage(m_folderOutput + fileName);
            }
            else if (File.Exists(inputPath + fileName))
            {
                m_bmp = TGMTimage.LoadBitmapWithoutLock(inputPath + fileName);
                FormMain.GetInstance().PrintMessage(inputPath + fileName);
            }
            else if (txtFailedDir.Text != "" && File.Exists(failedDir + fileName))
            {
                m_bmp = TGMTimage.LoadBitmapWithoutLock(failedDir + fileName);
                FormMain.GetInstance().PrintMessage(failedDir + fileName);
            }
            else
            {
                FormMain.GetInstance().PrintError("File " + inputPath + fileName + " does not exist");
                return;
            }

            pictureBox1.Image = m_bmp;
            m_scaleX = (double)m_bmp.Width / pictureBox1.Width;
            m_scaleY = (double)m_bmp.Height / pictureBox1.Height;

            AdjustSize();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtFolderInput_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolderInput.Text))
            {
                btnDetect.Enabled = false;
                return;
            }
                

            TGMTregistry.GetInstance().SaveValue("folderInput", txtFolderInput.Text);
            FormMain.GetInstance().PrintMessage("Loading files...");
            listView1.Items.Clear();
            bgLoadFile.RunWorkerAsync();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            string filePath = TGMTutil.CorrectPath(txtFolderInput.Text);
            filePath += listView1.SelectedItems[0].Text;
            if (!File.Exists(filePath))
            {
                FormMain.GetInstance().PrintMessage("File does not exist");
                return;
            }


            if (e.ClickedItem.Name == "btnCopyPath")
            {
                Clipboard.SetText(filePath);
                FormMain.GetInstance().PrintMessage("Copied path to clipboard");
            }
            else if (e.ClickedItem.Name == "btnCopyImage")
            {
                StringCollection paths = new StringCollection();
                paths.Add(filePath);
                Clipboard.SetFileDropList(paths);
                FormMain.GetInstance().PrintMessage("Copied image to clipboard");
            }
            else if (e.ClickedItem.Name == "btnOpenImage")
            {
                System.Diagnostics.Process.Start(filePath);
            }
            else if (e.ClickedItem.Name == "btnDelete")
            {
                if(File.Exists(filePath))
                {
                    FileSystem.DeleteFile(filePath, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
                }                
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string inputDir = "";
            if (txtFolderInput.Text != "")
                inputDir = TGMTutil.CorrectPath(txtFolderInput.Text);
            string failedDir = "";
            if (txtFailedDir.Text != "")
                failedDir = TGMTutil.CorrectPath(txtFailedDir.Text);

            string validDir = "";
            if (txtValidDir.Text != "")
                validDir = TGMTutil.CorrectPath(txtValidDir.Text);

            string invalidDir = "";
            if (txtInvalidDir.Text != "")
                invalidDir = TGMTutil.CorrectPath(txtInvalidDir.Text);

            m_exactlyCount = 0;
            m_content = "";
            

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (worker1.CancellationPending)
                    return;


                string filePath = listView1.Items[i].Text;
                string ext = Path.GetExtension(filePath).ToLower();
                

                if (ext != ".jpg" && ext != ".png" && ext != ".bmp")
                    continue;
                FormMain.GetInstance().PrintMessage((i + 1).ToString() + " / " + listView1.Items.Count + " " + filePath);


                int availableReader = AvailableReader();
                while (availableReader == -1)
                {
                    readerAvailableEvent.WaitOne();
                    availableReader = AvailableReader();
                }

                Read(availableReader, i, inputDir, filePath, validDir, invalidDir, failedDir);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FormMain.GetInstance().PrintMessage(e.ProgressPercentage + "/" + listView1.Items.Count + "(" + (100 * e.ProgressPercentage / listView1.Items.Count) + " %)");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btn_export.Enabled = true;
            FormMain.GetInstance().StopProgressbar();

            string fileCsv = TGMTutil.CorrectPath(txtFolderInput.Text) + "_report.csv";
            File.WriteAllText(fileCsv, m_content);

            btnDetect.Text = "Start";
            if (m_folderOutput != "")
                FormMain.GetInstance().PrintMessage("Save report to " + fileCsv);

            circle1.Visible = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Read(int availableReader, int itemIndex, string inputDir, string fileName, string validDir, string invalidDir, string failedDir)
        {
            string filePathAbs = inputDir + fileName;

            string text = "";
            string alphanumeric = "";
            bool isValid = true;
            string error = "";

            m_content += fileName + ",";
            VehiclePlate[] plates = m_readers[availableReader].Reads(filePathAbs);
            _listResults.Add(plates);

            if (plates.Length > 0)
            {                
                //int thickness = (int)Math.Round((float)bmp.Width / 200);
                for (int j = 0; j < plates.Length; j++)
                {

                    VehiclePlate p = plates[j];
                    //bmp = TGMTdraw.DrawRectangle(bmp, p.rect, Color.Green, false, thickness);
                    isValid &= p.isValid;
                    error = p.error;
                    alphanumeric += p.alphanumeric + Program.delimiter;
                    text += p.text + Program.delimiter;
                    
                }
                m_content += text + "," + alphanumeric;                
            }
            else
            {
                error = "Not found";
            }
           
   

            int i = itemIndex;
            if (text != "")
            {
                if (listView1.Items[i].SubItems.Count == 1)
                {
                    listView1.Items[i].SubItems.Add(text);
                    listView1.Items[i].SubItems.Add(alphanumeric);
                }
                else
                {
                    listView1.Items[i].SubItems[1].Text = text;
                    listView1.Items[i].SubItems[2].Text = alphanumeric;
                }
                listView1.Items[i].ForeColor = isValid ? Color.Blue : Color.Black;

                if (isValid)
                {
                    m_exactlyCount++;
                    if (chkMoveValid.Checked)
                    {
                        Task.Run(() => File.Move(inputDir + listView1.Items[i].Text, validDir + listView1.Items[i].Text));
                    }
                }
                else
                {
                    if (chkMoveInvalid.Checked)
                    {
                        Task.Run(() => File.Move(inputDir + listView1.Items[i].Text, invalidDir + listView1.Items[i].Text));
                    }
                }
            }
            else
            {
                if (listView1.Items[i].SubItems.Count == 1)
                {
                    listView1.Items[i].SubItems.Add(error);
                }
                else
                {
                    listView1.Items[i].SubItems[1].Text = error;
                }
                if (chkMoveFail.Checked)
                {
                    Task.Run(() => File.Move(inputDir + listView1.Items[i].Text, failedDir + listView1.Items[i].Text));
                }

                listView1.Items[i].ForeColor = Color.Red;

            }

            m_content += "\r\n";

            listView1.EnsureVisible(i);

            lock (m_lock)
            {
                m_readerAvailables[availableReader] = true;
                readerAvailableEvent.Set();
            }
        }        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSelectFolderInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Select folder";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtFolderInput.Text = Path.GetDirectoryName(folderBrowser.FileName);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveFail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveFail.Checked)
            {
                errorProvider1.Clear();

                if (txtFailedDir.Text == "")
                {
                    chkMoveFail.Checked = false;
                    FormMain.GetInstance().PrintError("Target directory is empty");
                }
                else if (!Directory.Exists(txtFailedDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txtFailedDir, "Dir does not exist");

                    chkMoveFail.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txtFailedDir", txtFailedDir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveValid_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveValid.Checked)
            {
                errorProvider1.Clear();

                if (txtValidDir.Text == "")
                {
                    FormMain.GetInstance().PrintError("Valid directory is empty");
                    chkMoveValid.Checked = false;
                }
                else if (!Directory.Exists(txtValidDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txtValidDir, "Dir does not exist");
                    chkMoveValid.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txtValidDir", txtValidDir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveInvalid_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveInvalid.Checked)
            {
                errorProvider1.Clear();

                if (txtInvalidDir.Text == "")
                {
                    FormMain.GetInstance().PrintError("Invalid directory is empty");
                    chkMoveInvalid.Checked = false;
                }
                else if (!Directory.Exists(txtInvalidDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txtInvalidDir, "Dir does not exist");
                    chkMoveInvalid.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txtInvalidDir", txtInvalidDir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnDetect_Click(object sender, EventArgs e)
        {
            if (btnDetect.Text.Contains("Start"))
            {
                circle1.Visible = true;
                _listResults.Clear();
                btn_export.Enabled = false;
                worker1.RunWorkerAsync();
                btnDetect.Text = "Stop";
            }
            else
            {
                circle1.Visible = false;
                worker1.CancelAsync();
                btnDetect.Text = "Start";                
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_export_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = "danh_sach_bien_so.xlsx";

                if (File.Exists(fileName))
                    File.Delete(fileName);
                
                TGMTexcel excel = new TGMTexcel(fileName);
                excel.AddSheet("Danh sach");


                string[] headers = new string[] { "STT", "Ảnh", "Biển số", "Alphanumeric"};
                excel.AddRow(0, 1, headers);


                for (int i = 0; i < _listResults.Count; i++)
                {
                    VehiclePlate[] plates = _listResults[i];
                    string text = "";
                    string alphanumeric = "";

                    for (int j=0;j<plates.Length;j++)
                    {
                        text += plates[j].text + Program.delimiter;
                        alphanumeric += plates[j].alphanumeric + Program.delimiter;
                    }

                    string[] values = new string[] { (i + 1).ToString(), listView1.Items[i].Text, text, alphanumeric };
                    excel.AddRow(0, i + 2, values);
                }



                for (int i = 1; i <= headers.Length; i++)
                {
                    excel.SetAutoFitContent(0, i);
                    excel.SetStyle(0, 1, i, Color.White, Color.Black, true);
                }

                excel.DrawTable(0, 1, 1, _listResults.Count + 1, headers.Length);


                excel.Save();
                if (MessageBox.Show("Bạn có muốn mở file excel?", "Save thành công", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có thể file excel đang mở, vui lòng kiểm tra lại", "Save file thất bại", MessageBoxButtons.OK);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        int AvailableReader()
        {
            for (int j = 0; j < m_readerAvailables.Count; j++)
            {
                lock (m_lock)
                {
                    if (m_readerAvailables[j])
                    {
                        m_readerAvailables[j] = false;
                        return j;
                    }
                        
                }
            }

            if (m_readers.Count < MAX_READER)
            {
                m_readers.Add(new PlateReader());
                m_readerAvailables.Add(false);

                return m_readerAvailables.Count - 1;

            }
            return -1;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (!m_loaded)
                return;

            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                TGMTregistry.GetInstance().SaveValue("column_" + i.ToString() + "_width", listView1.Columns[i].Width);
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void AdjustSize()
        {
            if (m_bmp == null)
                return;

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

            pictureBox1.Refresh();
        }


    }
}

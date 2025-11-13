using Microsoft.VisualBasic.FileIO;
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
        List<Plate> m_plates = new List<Plate>();

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

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormFolder()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormFolder_Load(object sender, EventArgs e)
        {
            txtFolderInput.Text = TGMTregistry.GetInstance().ReadString("folderInput");
            txtFailedDir.Text = TGMTregistry.GetInstance().ReadString("txtFailedDir");
            txtValidDir.Text = TGMTregistry.GetInstance().ReadString("txtValidDir");
            txtInvalidDir.Text = TGMTregistry.GetInstance().ReadString("txtInvalidDir");

            for (int i = 0; i < lstImage.Columns.Count; i++)
            {
                int width = TGMTregistry.GetInstance().ReadInt("column_" + i.ToString() + "_width", -1);
                if (width > -1)
                {
                    lstImage.Columns[i].Width = width;
                }
            }
            m_loaded = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormFolder_SizeChanged(object sender, EventArgs e)
        {
            int padding = 30;
            lstImage.Width = this.Width / 2 + padding;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormFolder GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormFolder();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> files = new List<string>();
            lstImage.Items.Clear();

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
                lstImage.Items.Add(files[i]);
            }
            FormMain.GetInstance().PrintMessage("Loaded " + lstImage.Items.Count + " images");

            btnDetect.Enabled = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lstImage.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                DisplayResultImage();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_KeyDown(object sender, KeyEventArgs e)
        {
            string filePath = TGMTutil.CorrectPath(txtFolderInput.Text);
            filePath += lstImage.SelectedItems[0].Text;
            if (e.KeyCode == Keys.Enter)
            {
                System.Diagnostics.Process.Start(filePath);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if(File.Exists(filePath))
                {
                    FileSystem.DeleteFile(filePath, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
                }
                else
                {
                    FormMain.GetInstance().PrintError("File not found: " + filePath);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void DisplayResultImage()
        {
            if (lstImage.Items.Count == 0 || lstImage.SelectedItems.Count == 0)
            {
                return;
            }

            string fileName = lstImage.SelectedItems[0].Text;


            string inputPath = TGMTutil.CorrectPath(txtFolderInput.Text);
            string failedDir = txtFailedDir.Text != "" ? TGMTutil.CorrectPath(txtFailedDir.Text) : "";
            

            if (m_folderOutput != "" && File.Exists(m_folderOutput + fileName))
            {
                picResult.ImageLocation = m_folderOutput + fileName;
                FormMain.GetInstance().PrintMessage(m_folderOutput + fileName);
            }
            else if (File.Exists(inputPath + fileName))
            {
                picResult.ImageLocation = inputPath + fileName;
                FormMain.GetInstance().PrintMessage(inputPath + fileName);
            }
            else if (txtFailedDir.Text != "" && File.Exists(failedDir + fileName))
            {
                picResult.ImageLocation = failedDir + fileName;
                FormMain.GetInstance().PrintMessage(failedDir + fileName);
            }
            else
            {
                FormMain.GetInstance().PrintError("File " + inputPath + fileName + " does not exist");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayResultImage();
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
            lstImage.Items.Clear();
            bgLoadFile.RunWorkerAsync();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string filePath = TGMTutil.CorrectPath(txtFolderInput.Text);
            filePath += lstImage.SelectedItems[0].Text;
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
            

            for (int i = 0; i < lstImage.Items.Count; i++)
            {
                if (bgWorker1.CancellationPending)
                    return;
                //bgWorker1.ReportProgress(i + 1);

                //Program.reader.OutputFileName = lstImage.Items[i].Text;

                string filePath = lstImage.Items[i].Text;
                string ext = filePath.Substring(filePath.Length - 4).ToLower();
                

                if (ext != ".jpg" && ext != ".png" && ext != ".bmp")
                    continue;
                FormMain.GetInstance().PrintMessage((i + 1).ToString() + " / " + lstImage.Items.Count + " " + filePath);


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
            FormMain.GetInstance().PrintMessage(e.ProgressPercentage + "/" + lstImage.Items.Count + "(" + (100 * e.ProgressPercentage / lstImage.Items.Count) + " %)");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btn_export.Enabled = true;
            FormMain.GetInstance().StopProgressbar();

            string fileCsv = TGMTutil.CorrectPath(txtFolderInput.Text) + "_report.csv";
            File.WriteAllText(fileCsv, m_content);

            btnDetect.Text = "Detect (F5)";
            if (m_folderOutput != "")
                FormMain.GetInstance().PrintMessage("Save report to " + fileCsv);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ReadAsync(int availableReader, int itemIndex, string inputDir, string filePath, string validDir, string invalidDir, string failedDir)
        {
            Thread t = new Thread(() => Read(availableReader, itemIndex, inputDir, filePath, validDir, invalidDir, failedDir));
            t.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Read(int availableReader, int itemIndex, string inputDir, string fileName, string validDir, string invalidDir, string failedDir)
        {
            string filePathAbs = inputDir + fileName;

            VehiclePlate plate;

            string text = "";
            string alphanumeric = "";
            bool isValid = true;
            string error = "";

            m_content += fileName + ",";

            if (Program.readingMode == ReadingMode.Best)
            {
                VehiclePlate[] plates = m_readers[availableReader].Reads(filePathAbs);
                if(plates.Length > 0)
                {
                    plate = plates[0];
                    m_plates.Add(new Plate(filePathAbs, plate.text, plate.alphanumeric));

                    isValid &= plate.isValid;
                    alphanumeric = plate.alphanumeric;
                    text = plate.text;
                    error = plate.error;

                    m_content += text;
                }    
                else
                {
                    error = "Not found";
                }
            }
            else
            {
                VehiclePlate[] plates = Program.reader.Reads(filePathAbs);

                if (plates.Length > 0)
                {
                    Bitmap bmp = new Bitmap(filePathAbs);
                    int thickness = (int)Math.Round((float)bmp.Width / 200);

                    if (Program.readingMode == ReadingMode.All)
                    {
                        if (plates.Length == 1)
                        {
                            VehiclePlate p = plates[0];
                            bmp = TGMTdraw.DrawRectangle(bmp, p.rect, Color.Green, false, thickness);
                            isValid &= p.isValid;
                            error = p.error;
                            text = p.text;
                            alphanumeric = p.alphanumeric;

                            m_content += text;
                        }
                        else if(plates.Length > 1)
                        {
                            
                            for (int j = 0; j < plates.Length; j++)
                            {
                                
                                VehiclePlate p = plates[j];
                                bmp = TGMTdraw.DrawRectangle(bmp, p.rect, Color.Green, false, thickness);
                                isValid &= p.isValid;
                                error = p.error;
                                alphanumeric += p.alphanumeric + Program.delimiter;
                                m_content += p.text + Program.delimiter + ",";
                            }

                            m_content = m_content.Substring(0, m_content.Length - 1);
                        }
                    }
                    else if (Program.readingMode == ReadingMode.Biggest)
                    {
                        plate = ParkingUtil.GetBiggest(plates);
                        bmp = TGMTdraw.DrawRectangle(bmp, plate.rect, Color.Green, false, thickness);
                        isValid &= plate.isValid;
                        text = plate.text;
                        alphanumeric = plate.alphanumeric;

                        m_content += text;
                    }
                    else if (Program.readingMode == ReadingMode.Center)
                    {
                        plate = ParkingUtil.GetNearestCenter(bmp, plates);
                        bmp = TGMTdraw.DrawRectangle(bmp, plate.rect, Color.Green, false, thickness);
                        isValid &= plate.isValid;
                        text = plate.text;
                        alphanumeric = plate.alphanumeric;

                        m_content += text;
                    }

                    picResult.Image = bmp;

                    m_plates.Add(new Plate(filePathAbs, text, alphanumeric));
                }
                else
                {
                    error = "Not found";
                }
            }            

            int i = itemIndex;
            if (text != "")
            {
                if (lstImage.Items[i].SubItems.Count == 1)
                {
                    lstImage.Items[i].SubItems.Add(text);
                    lstImage.Items[i].SubItems.Add(alphanumeric);
                }
                else
                {
                    lstImage.Items[i].SubItems[1].Text = text;
                    lstImage.Items[i].SubItems[2].Text = alphanumeric;
                }
                lstImage.Items[i].ForeColor = isValid ? Color.Blue : Color.Black;

                if (isValid)
                {
                    m_exactlyCount++;
                    if (chkMoveValid.Checked)
                    {
                        Task.Run(() => File.Move(inputDir + lstImage.Items[i].Text, validDir + lstImage.Items[i].Text));
                    }
                }
                else
                {
                    if (chkMoveInvalid.Checked)
                    {
                        Task.Run(() => File.Move(inputDir + lstImage.Items[i].Text, invalidDir + lstImage.Items[i].Text));
                    }
                }
            }
            else
            {
                if (lstImage.Items[i].SubItems.Count == 1)
                {
                    lstImage.Items[i].SubItems.Add(error);
                }
                else
                {
                    lstImage.Items[i].SubItems[1].Text = error;
                }
                if (chkMoveFail.Checked)
                {
                    Task.Run(() => File.Move(inputDir + lstImage.Items[i].Text, failedDir + lstImage.Items[i].Text));
                }

                lstImage.Items[i].ForeColor = Color.Red;

            }

            m_content += "\r\n";

            lstImage.EnsureVisible(i);

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
            if (btnDetect.Text.Contains("Detect"))
            {
                m_plates.Clear();
                btn_export.Enabled = false;
                bgWorker1.RunWorkerAsync();
                btnDetect.Text = "Stop";
            }
            else
            {
                bgWorker1.CancelAsync();
                btnDetect.Text = "Detect";                
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


                for (int i = 0; i < m_plates.Count; i++)
                {
                    Plate a = m_plates[i];
                    a.index = i + 1;
                    excel.AddRow(0, i + 2, a.ToArray(rd_fullPath.Checked));
                }            



                for (int i = 1; i <= headers.Length; i++)
                {
                    excel.SetAutoFitContent(0, i);
                    excel.SetFormat(0, 1, i, Color.White, Color.Black, true);
                }

                excel.DrawTable(0, 1, 1, m_plates.Count + 1, headers.Length);

            
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

            for (int i = 0; i < lstImage.Columns.Count; i++)
            {
                TGMTregistry.GetInstance().SaveValue("column_" + i.ToString() + "_width", lstImage.Columns[i].Width);
            }
        }
    }
}

namespace VietANPR_UI
{
    partial class FormFolder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bgLoadFile = new System.ComponentModel.BackgroundWorker();
            this.worker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopyImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.grFolder = new System.Windows.Forms.GroupBox();
            this.btnDetect = new TGMTcontrols.DefaultButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolderInput = new TGMTcontrols.BrowseDir();
            this.txtInvalidDir = new System.Windows.Forms.TextBox();
            this.chkMoveInvalid = new System.Windows.Forms.CheckBox();
            this.txtValidDir = new System.Windows.Forms.TextBox();
            this.chkMoveValid = new System.Windows.Forms.CheckBox();
            this.txtFailedDir = new System.Windows.Forms.TextBox();
            this.chkMoveFail = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_export = new TGMTcontrols.DefaultButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rd_fullPath = new System.Windows.Forms.RadioButton();
            this.panelPicture = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView1 = new TGMTcontrols.ColorListview();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new TGMTcontrols.ColorListview();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.circle1 = new TGMTcontrols.ProcessingControl();
            this.contextMenuStrip1.SuspendLayout();
            this.grFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgLoadFile
            // 
            this.bgLoadFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoadFile_DoWork);
            this.bgLoadFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoadFile_RunWorkerCompleted);
            // 
            // worker1
            // 
            this.worker1.WorkerSupportsCancellation = true;
            this.worker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker1_DoWork);
            this.worker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker1_ProgressChanged);
            this.worker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker1_RunWorkerCompleted);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopyPath,
            this.btnCopyImage,
            this.btnOpenImage,
            this.btnDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 92);
            this.contextMenuStrip1.Text = "Copy path";
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // btnCopyPath
            // 
            this.btnCopyPath.Name = "btnCopyPath";
            this.btnCopyPath.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.btnCopyPath.Size = new System.Drawing.Size(171, 22);
            this.btnCopyPath.Text = "Copy path";
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(171, 22);
            this.btnCopyImage.Text = "Copy image";
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(171, 22);
            this.btnOpenImage.Text = "Open image";
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(171, 22);
            this.btnDelete.Text = "Delete image";
            // 
            // grFolder
            // 
            this.grFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.grFolder.Controls.Add(this.circle1);
            this.grFolder.Controls.Add(this.btnDetect);
            this.grFolder.Controls.Add(this.label1);
            this.grFolder.Controls.Add(this.txtFolderInput);
            this.grFolder.Controls.Add(this.txtInvalidDir);
            this.grFolder.Controls.Add(this.chkMoveInvalid);
            this.grFolder.Controls.Add(this.txtValidDir);
            this.grFolder.Controls.Add(this.chkMoveValid);
            this.grFolder.Controls.Add(this.txtFailedDir);
            this.grFolder.Controls.Add(this.chkMoveFail);
            this.grFolder.Controls.Add(this.label4);
            this.grFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grFolder.Location = new System.Drawing.Point(0, 0);
            this.grFolder.Name = "grFolder";
            this.grFolder.Size = new System.Drawing.Size(995, 138);
            this.grFolder.TabIndex = 33;
            this.grFolder.TabStop = false;
            // 
            // btnDetect
            // 
            this.btnDetect.Active1 = System.Drawing.Color.DodgerBlue;
            this.btnDetect.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btnDetect.BackColor = System.Drawing.Color.Transparent;
            this.btnDetect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDetect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDetect.ForeColor = System.Drawing.Color.White;
            this.btnDetect.Icon = null;
            this.btnDetect.ImageLocation = new System.Drawing.Point(0, 0);
            this.btnDetect.ImageSize = new System.Drawing.Size(0, 0);
            this.btnDetect.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.btnDetect.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.btnDetect.Location = new System.Drawing.Point(151, 86);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Radius = 10;
            this.btnDetect.Size = new System.Drawing.Size(110, 43);
            this.btnDetect.Stroke = 0;
            this.btnDetect.StrokeColor = System.Drawing.Color.Gray;
            this.btnDetect.TabIndex = 27;
            this.btnDetect.Text = "Start";
            this.btnDetect.Transparency = false;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "Input folder";
            // 
            // txtFolderInput
            // 
            this.txtFolderInput.BackColor = System.Drawing.Color.Transparent;
            this.txtFolderInput.BackgroundColor = System.Drawing.Color.White;
            this.txtFolderInput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.txtFolderInput.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtFolderInput.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFolderInput.Location = new System.Drawing.Point(15, 47);
            this.txtFolderInput.Name = "txtFolderInput";
            this.txtFolderInput.Padding = new System.Windows.Forms.Padding(5);
            this.txtFolderInput.Size = new System.Drawing.Size(384, 30);
            this.txtFolderInput.TabIndex = 25;
            this.txtFolderInput.TextChanged += new System.EventHandler(this.txtFolderInput_TextChanged);
            // 
            // txtInvalidDir
            // 
            this.txtInvalidDir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvalidDir.Location = new System.Drawing.Point(600, 77);
            this.txtInvalidDir.Name = "txtInvalidDir";
            this.txtInvalidDir.Size = new System.Drawing.Size(273, 25);
            this.txtInvalidDir.TabIndex = 17;
            // 
            // chkMoveInvalid
            // 
            this.chkMoveInvalid.AutoSize = true;
            this.chkMoveInvalid.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoveInvalid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.chkMoveInvalid.Location = new System.Drawing.Point(423, 78);
            this.chkMoveInvalid.Name = "chkMoveInvalid";
            this.chkMoveInvalid.Size = new System.Drawing.Size(144, 23);
            this.chkMoveInvalid.TabIndex = 16;
            this.chkMoveInvalid.Text = "Move invalid file to";
            this.chkMoveInvalid.UseVisualStyleBackColor = true;
            this.chkMoveInvalid.CheckedChanged += new System.EventHandler(this.chkMoveInvalid_CheckedChanged);
            // 
            // txtValidDir
            // 
            this.txtValidDir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValidDir.Location = new System.Drawing.Point(600, 46);
            this.txtValidDir.Name = "txtValidDir";
            this.txtValidDir.Size = new System.Drawing.Size(273, 25);
            this.txtValidDir.TabIndex = 15;
            // 
            // chkMoveValid
            // 
            this.chkMoveValid.AutoSize = true;
            this.chkMoveValid.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoveValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.chkMoveValid.Location = new System.Drawing.Point(423, 47);
            this.chkMoveValid.Name = "chkMoveValid";
            this.chkMoveValid.Size = new System.Drawing.Size(133, 23);
            this.chkMoveValid.TabIndex = 14;
            this.chkMoveValid.Text = "Move valid file to";
            this.chkMoveValid.UseVisualStyleBackColor = true;
            this.chkMoveValid.CheckedChanged += new System.EventHandler(this.chkMoveValid_CheckedChanged);
            // 
            // txtFailedDir
            // 
            this.txtFailedDir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFailedDir.Location = new System.Drawing.Point(600, 15);
            this.txtFailedDir.Name = "txtFailedDir";
            this.txtFailedDir.Size = new System.Drawing.Size(273, 25);
            this.txtFailedDir.TabIndex = 13;
            // 
            // chkMoveFail
            // 
            this.chkMoveFail.AutoSize = true;
            this.chkMoveFail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoveFail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.chkMoveFail.Location = new System.Drawing.Point(423, 15);
            this.chkMoveFail.Name = "chkMoveFail";
            this.chkMoveFail.Size = new System.Drawing.Size(176, 23);
            this.chkMoveFail.TabIndex = 12;
            this.chkMoveFail.Text = "Move file can\'t detect to";
            this.chkMoveFail.UseVisualStyleBackColor = true;
            this.chkMoveFail.CheckedChanged += new System.EventHandler(this.chkMoveFail_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.groupBox1.Controls.Add(this.btn_export);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.rd_fullPath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(995, 48);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // btn_export
            // 
            this.btn_export.Active1 = System.Drawing.Color.DodgerBlue;
            this.btn_export.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_export.BackColor = System.Drawing.Color.Transparent;
            this.btn_export.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_export.Enabled = false;
            this.btn_export.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_export.ForeColor = System.Drawing.Color.White;
            this.btn_export.Icon = null;
            this.btn_export.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_export.ImageSize = new System.Drawing.Size(0, 0);
            this.btn_export.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.btn_export.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.btn_export.Location = new System.Drawing.Point(204, 12);
            this.btn_export.Name = "btn_export";
            this.btn_export.Radius = 4;
            this.btn_export.Size = new System.Drawing.Size(119, 30);
            this.btn_export.Stroke = 0;
            this.btn_export.StrokeColor = System.Drawing.Color.Gray;
            this.btn_export.TabIndex = 23;
            this.btn_export.Text = "Export excel";
            this.btn_export.Transparency = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.radioButton2.Location = new System.Drawing.Point(110, 18);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 23);
            this.radioButton2.TabIndex = 22;
            this.radioButton2.Text = "File name";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // rd_fullPath
            // 
            this.rd_fullPath.AutoSize = true;
            this.rd_fullPath.Checked = true;
            this.rd_fullPath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rd_fullPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.rd_fullPath.Location = new System.Drawing.Point(15, 18);
            this.rd_fullPath.Name = "rd_fullPath";
            this.rd_fullPath.Size = new System.Drawing.Size(80, 23);
            this.rd_fullPath.TabIndex = 21;
            this.rd_fullPath.TabStop = true;
            this.rd_fullPath.Text = "Full path";
            this.rd_fullPath.UseVisualStyleBackColor = true;
            // 
            // panelPicture
            // 
            this.panelPicture.Controls.Add(this.pictureBox1);
            this.panelPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPicture.Location = new System.Drawing.Point(539, 186);
            this.panelPicture.Name = "panelPicture";
            this.panelPicture.Size = new System.Drawing.Size(456, 465);
            this.panelPicture.TabIndex = 36;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(407, 359);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.picResult_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.listView2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 186);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 465);
            this.panel1.TabIndex = 37;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(539, 315);
            this.listView1.TabIndex = 35;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstImage_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Image name";
            this.columnHeader1.Width = 231;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Plate";
            this.columnHeader2.Width = 103;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Alphanumeric";
            this.columnHeader3.Width = 137;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 315);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.OwnerDraw = true;
            this.listView2.Size = new System.Drawing.Size(539, 150);
            this.listView2.TabIndex = 36;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "STT";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Biển số";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Alphanumeric";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Score";
            this.columnHeader7.Width = 100;
            // 
            // circle1
            // 
            this.circle1.BackColor = System.Drawing.Color.Transparent;
            this.circle1.IndexColor = System.Drawing.Color.DeepSkyBlue;
            this.circle1.Interval = 50;
            this.circle1.Location = new System.Drawing.Point(267, 86);
            this.circle1.Name = "circle1";
            this.circle1.NCircle = 8;
            this.circle1.Others = System.Drawing.Color.LightGray;
            this.circle1.Radius = 4;
            this.circle1.Size = new System.Drawing.Size(40, 40);
            this.circle1.TabIndex = 28;
            this.circle1.Text = "processingControl1";
            this.circle1.Visible = false;
            // 
            // FormFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 651);
            this.Controls.Add(this.panelPicture);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grFolder);
            this.Name = "FormFolder";
            this.Text = "FormFolder";
            this.Load += new System.EventHandler(this.FormFolder_Load);
            this.SizeChanged += new System.EventHandler(this.FormFolder_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.grFolder.ResumeLayout(false);
            this.grFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgLoadFile;
        private System.ComponentModel.BackgroundWorker worker1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnCopyPath;
        private System.Windows.Forms.ToolStripMenuItem btnCopyImage;
        private System.Windows.Forms.ToolStripMenuItem btnOpenImage;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.GroupBox grFolder;
        private System.Windows.Forms.TextBox txtInvalidDir;
        private System.Windows.Forms.CheckBox chkMoveInvalid;
        private System.Windows.Forms.TextBox txtValidDir;
        private System.Windows.Forms.CheckBox chkMoveValid;
        private System.Windows.Forms.TextBox txtFailedDir;
        private System.Windows.Forms.CheckBox chkMoveFail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rd_fullPath;
        private System.Windows.Forms.RadioButton radioButton2;
        private TGMTcontrols.BrowseDir txtFolderInput;
        private TGMTcontrols.DefaultButton btn_export;
        private System.Windows.Forms.Label label1;
        private TGMTcontrols.DefaultButton btnDetect;
        private System.Windows.Forms.Panel panelPicture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private TGMTcontrols.ColorListview listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private TGMTcontrols.ColorListview listView2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private TGMTcontrols.ProcessingControl circle1;
    }
}
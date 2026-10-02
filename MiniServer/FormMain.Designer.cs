namespace MiniServer
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.gradientPanel3 = new TGMTcontrols.GradientPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.defaultButton5 = new TGMTcontrols.DefaultButton();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.defaultButton8 = new TGMTcontrols.DefaultButton();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.colorGroupBox3 = new TGMTcontrols.ColorGroupBox();
            this.numericUpDown1 = new TGMTcontrols.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.colorGroupBox2 = new TGMTcontrols.ColorGroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbl_CPUname = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_GPU = new System.Windows.Forms.Label();
            this.lbl_VRAM = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbl_CUDA = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_RAM = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_CPU = new System.Windows.Forms.Label();
            this.colorGroupBox1 = new TGMTcontrols.ColorGroupBox();
            this.lbl_address = new System.Windows.Forms.Label();
            this.lbl_upTime = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.processingControl1 = new TGMTcontrols.ProcessingControl();
            this.lbl_serverStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_stopServer = new TGMTcontrols.DangerButton();
            this.btn_startServer = new TGMTcontrols.DefaultButton();
            this.timerHardware = new System.Windows.Forms.Timer(this.components);
            this.timerServer = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.workerLoading = new System.ComponentModel.BackgroundWorker();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradientPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.colorGroupBox3.SuspendLayout();
            this.colorGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.colorGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel3
            // 
            this.gradientPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.gradientPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.gradientPanel3.BorderThickness = 1;
            this.gradientPanel3.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.gradientPanel3.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.gradientPanel3.Controls.Add(this.label8);
            this.gradientPanel3.Controls.Add(this.defaultButton5);
            this.gradientPanel3.Controls.Add(this.label2);
            this.gradientPanel3.Controls.Add(this.pictureBox1);
            this.gradientPanel3.Controls.Add(this.defaultButton8);
            this.gradientPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel3.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.gradientPanel3.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel3.Name = "gradientPanel3";
            this.gradientPanel3.Size = new System.Drawing.Size(1386, 92);
            this.gradientPanel3.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.label8.Location = new System.Drawing.Point(114, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(390, 25);
            this.label8.TabIndex = 32;
            this.label8.Text = "Mini Server cung cấp API nhận dạng biển số";
            // 
            // defaultButton5
            // 
            this.defaultButton5.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(119)))));
            this.defaultButton5.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(119)))));
            this.defaultButton5.BackColor = System.Drawing.Color.Transparent;
            this.defaultButton5.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.defaultButton5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.defaultButton5.ForeColor = System.Drawing.Color.White;
            this.defaultButton5.Icon = null;
            this.defaultButton5.ImageLocation = new System.Drawing.Point(0, 0);
            this.defaultButton5.ImageSize = new System.Drawing.Size(24, 24);
            this.defaultButton5.Inactive1 = System.Drawing.Color.Empty;
            this.defaultButton5.Inactive2 = System.Drawing.Color.Empty;
            this.defaultButton5.Location = new System.Drawing.Point(537, 10);
            this.defaultButton5.Name = "defaultButton5";
            this.defaultButton5.Radius = 8;
            this.defaultButton5.Size = new System.Drawing.Size(30, 30);
            this.defaultButton5.Stroke = 0;
            this.defaultButton5.StrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(83)))), ((int)(((byte)(107)))));
            this.defaultButton5.TabIndex = 29;
            this.defaultButton5.Transparency = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(109)))));
            this.label2.Location = new System.Drawing.Point(111, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 54);
            this.label2.TabIndex = 31;
            this.label2.Text = "Viet ANPR";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.pictureBox1.Image = global::MiniServer.Properties.Resources.camera_right;
            this.pictureBox1.Location = new System.Drawing.Point(21, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // defaultButton8
            // 
            this.defaultButton8.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.defaultButton8.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(184)))));
            this.defaultButton8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultButton8.BackColor = System.Drawing.Color.Transparent;
            this.defaultButton8.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.defaultButton8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.defaultButton8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(71)))), ((int)(((byte)(104)))));
            this.defaultButton8.Icon = global::MiniServer.Properties.Resources.cog_24;
            this.defaultButton8.ImageLocation = new System.Drawing.Point(0, 0);
            this.defaultButton8.ImageSize = new System.Drawing.Size(20, 20);
            this.defaultButton8.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.defaultButton8.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.defaultButton8.Location = new System.Drawing.Point(1281, 6);
            this.defaultButton8.Name = "defaultButton8";
            this.defaultButton8.Radius = 6;
            this.defaultButton8.Size = new System.Drawing.Size(99, 34);
            this.defaultButton8.Stroke = 1;
            this.defaultButton8.StrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(183)))), ((int)(((byte)(194)))));
            this.defaultButton8.TabIndex = 29;
            this.defaultButton8.Text = "Cài đặt";
            this.defaultButton8.Transparency = false;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.panelLeft.Controls.Add(this.colorGroupBox3);
            this.panelLeft.Controls.Add(this.colorGroupBox2);
            this.panelLeft.Controls.Add(this.colorGroupBox1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 92);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(320, 625);
            this.panelLeft.TabIndex = 32;
            // 
            // colorGroupBox3
            // 
            this.colorGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.colorGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.colorGroupBox3.BorderThickness = 3;
            this.colorGroupBox3.Checked = false;
            this.colorGroupBox3.Controls.Add(this.numericUpDown1);
            this.colorGroupBox3.Controls.Add(this.label27);
            this.colorGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorGroupBox3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.colorGroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.colorGroupBox3.InsideColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.colorGroupBox3.Location = new System.Drawing.Point(0, 414);
            this.colorGroupBox3.Margin = new System.Windows.Forms.Padding(8, 10, 8, 8);
            this.colorGroupBox3.Name = "colorGroupBox3";
            this.colorGroupBox3.Radius = 8;
            this.colorGroupBox3.ShowCheckbox = false;
            this.colorGroupBox3.Size = new System.Drawing.Size(320, 111);
            this.colorGroupBox3.TabIndex = 2;
            this.colorGroupBox3.TabStop = false;
            this.colorGroupBox3.Text = "ENGINE";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.numericUpDown1.Location = new System.Drawing.Point(105, 41);
            this.numericUpDown1.MaxValue = 10D;
            this.numericUpDown1.MinValue = 0D;
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.SignColor = System.Drawing.Color.White;
            this.numericUpDown1.Size = new System.Drawing.Size(100, 30);
            this.numericUpDown1.TabIndex = 38;
            this.numericUpDown1.Text = "numericUpDown1";
            this.numericUpDown1.Value = 1D;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.label27.Location = new System.Drawing.Point(18, 45);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(49, 20);
            this.label27.TabIndex = 33;
            this.label27.Text = "ANPR";
            // 
            // colorGroupBox2
            // 
            this.colorGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.colorGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.colorGroupBox2.BorderThickness = 3;
            this.colorGroupBox2.Checked = false;
            this.colorGroupBox2.Controls.Add(this.pictureBox3);
            this.colorGroupBox2.Controls.Add(this.pictureBox2);
            this.colorGroupBox2.Controls.Add(this.lbl_CPUname);
            this.colorGroupBox2.Controls.Add(this.label6);
            this.colorGroupBox2.Controls.Add(this.lbl_GPU);
            this.colorGroupBox2.Controls.Add(this.lbl_VRAM);
            this.colorGroupBox2.Controls.Add(this.label16);
            this.colorGroupBox2.Controls.Add(this.lbl_CUDA);
            this.colorGroupBox2.Controls.Add(this.label14);
            this.colorGroupBox2.Controls.Add(this.lbl_RAM);
            this.colorGroupBox2.Controls.Add(this.label12);
            this.colorGroupBox2.Controls.Add(this.lbl_CPU);
            this.colorGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorGroupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.colorGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.colorGroupBox2.InsideColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.colorGroupBox2.Location = new System.Drawing.Point(0, 202);
            this.colorGroupBox2.Margin = new System.Windows.Forms.Padding(8, 10, 8, 8);
            this.colorGroupBox2.Name = "colorGroupBox2";
            this.colorGroupBox2.Radius = 8;
            this.colorGroupBox2.ShowCheckbox = false;
            this.colorGroupBox2.Size = new System.Drawing.Size(320, 212);
            this.colorGroupBox2.TabIndex = 1;
            this.colorGroupBox2.TabStop = false;
            this.colorGroupBox2.Text = "HARDWARE USAGE";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.pictureBox3.Image = global::MiniServer.Properties.Resources.Cuda_logo;
            this.pictureBox3.Location = new System.Drawing.Point(21, 120);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 27);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 46;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.pictureBox2.Image = global::MiniServer.Properties.Resources.cpu_32;
            this.pictureBox2.Location = new System.Drawing.Point(21, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            // 
            // lbl_CPUname
            // 
            this.lbl_CPUname.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CPUname.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_CPUname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.lbl_CPUname.Location = new System.Drawing.Point(78, 26);
            this.lbl_CPUname.Name = "lbl_CPUname";
            this.lbl_CPUname.Size = new System.Drawing.Size(222, 49);
            this.lbl_CPUname.TabIndex = 44;
            this.lbl_CPUname.Text = "UNKNOWN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.label6.Location = new System.Drawing.Point(19, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "CPU";
            // 
            // lbl_GPU
            // 
            this.lbl_GPU.AutoSize = true;
            this.lbl_GPU.BackColor = System.Drawing.Color.Transparent;
            this.lbl_GPU.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_GPU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.lbl_GPU.Location = new System.Drawing.Point(78, 124);
            this.lbl_GPU.Name = "lbl_GPU";
            this.lbl_GPU.Size = new System.Drawing.Size(32, 20);
            this.lbl_GPU.TabIndex = 42;
            this.lbl_GPU.Text = "NO";
            // 
            // lbl_VRAM
            // 
            this.lbl_VRAM.AutoSize = true;
            this.lbl_VRAM.BackColor = System.Drawing.Color.Transparent;
            this.lbl_VRAM.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_VRAM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.lbl_VRAM.Location = new System.Drawing.Point(78, 174);
            this.lbl_VRAM.Name = "lbl_VRAM";
            this.lbl_VRAM.Size = new System.Drawing.Size(30, 20);
            this.lbl_VRAM.TabIndex = 40;
            this.lbl_VRAM.Text = "0%";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.label16.Location = new System.Drawing.Point(18, 174);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 20);
            this.label16.TabIndex = 39;
            this.label16.Text = "VRAM";
            // 
            // lbl_CUDA
            // 
            this.lbl_CUDA.AutoSize = true;
            this.lbl_CUDA.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CUDA.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_CUDA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.lbl_CUDA.Location = new System.Drawing.Point(78, 149);
            this.lbl_CUDA.Name = "lbl_CUDA";
            this.lbl_CUDA.Size = new System.Drawing.Size(30, 20);
            this.lbl_CUDA.TabIndex = 38;
            this.lbl_CUDA.Text = "0%";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.label14.Location = new System.Drawing.Point(18, 149);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 20);
            this.label14.TabIndex = 37;
            this.label14.Text = "CUDA";
            // 
            // lbl_RAM
            // 
            this.lbl_RAM.AutoSize = true;
            this.lbl_RAM.BackColor = System.Drawing.Color.Transparent;
            this.lbl_RAM.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_RAM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.lbl_RAM.Location = new System.Drawing.Point(78, 99);
            this.lbl_RAM.Name = "lbl_RAM";
            this.lbl_RAM.Size = new System.Drawing.Size(30, 20);
            this.lbl_RAM.TabIndex = 36;
            this.lbl_RAM.Text = "0%";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.label12.Location = new System.Drawing.Point(18, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 20);
            this.label12.TabIndex = 35;
            this.label12.Text = "RAM";
            // 
            // lbl_CPU
            // 
            this.lbl_CPU.AutoSize = true;
            this.lbl_CPU.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CPU.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_CPU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.lbl_CPU.Location = new System.Drawing.Point(78, 75);
            this.lbl_CPU.Name = "lbl_CPU";
            this.lbl_CPU.Size = new System.Drawing.Size(30, 20);
            this.lbl_CPU.TabIndex = 34;
            this.lbl_CPU.Text = "0%";
            // 
            // colorGroupBox1
            // 
            this.colorGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.colorGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.colorGroupBox1.BorderThickness = 3;
            this.colorGroupBox1.Checked = false;
            this.colorGroupBox1.Controls.Add(this.lbl_address);
            this.colorGroupBox1.Controls.Add(this.lbl_upTime);
            this.colorGroupBox1.Controls.Add(this.label17);
            this.colorGroupBox1.Controls.Add(this.processingControl1);
            this.colorGroupBox1.Controls.Add(this.lbl_serverStatus);
            this.colorGroupBox1.Controls.Add(this.label1);
            this.colorGroupBox1.Controls.Add(this.btn_stopServer);
            this.colorGroupBox1.Controls.Add(this.btn_startServer);
            this.colorGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorGroupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.colorGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.colorGroupBox1.InsideColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.colorGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.colorGroupBox1.Margin = new System.Windows.Forms.Padding(8, 10, 8, 8);
            this.colorGroupBox1.Name = "colorGroupBox1";
            this.colorGroupBox1.Radius = 8;
            this.colorGroupBox1.ShowCheckbox = false;
            this.colorGroupBox1.Size = new System.Drawing.Size(320, 202);
            this.colorGroupBox1.TabIndex = 0;
            this.colorGroupBox1.TabStop = false;
            this.colorGroupBox1.Text = "SERVER STATUS";
            // 
            // lbl_address
            // 
            this.lbl_address.AutoSize = true;
            this.lbl_address.BackColor = System.Drawing.Color.Transparent;
            this.lbl_address.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_address.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.lbl_address.Location = new System.Drawing.Point(100, 83);
            this.lbl_address.Name = "lbl_address";
            this.lbl_address.Size = new System.Drawing.Size(125, 20);
            this.lbl_address.TabIndex = 38;
            this.lbl_address.Text = "192.168.1.111:8080";
            // 
            // lbl_upTime
            // 
            this.lbl_upTime.AutoSize = true;
            this.lbl_upTime.BackColor = System.Drawing.Color.Transparent;
            this.lbl_upTime.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_upTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.lbl_upTime.Location = new System.Drawing.Point(101, 109);
            this.lbl_upTime.Name = "lbl_upTime";
            this.lbl_upTime.Size = new System.Drawing.Size(69, 20);
            this.lbl_upTime.TabIndex = 37;
            this.lbl_upTime.Text = "0 minute";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.label17.Location = new System.Drawing.Point(28, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 20);
            this.label17.TabIndex = 36;
            this.label17.Text = "Up time:";
            // 
            // processingControl1
            // 
            this.processingControl1.BackColor = System.Drawing.Color.Transparent;
            this.processingControl1.IndexColor = System.Drawing.Color.DeepSkyBlue;
            this.processingControl1.Interval = 50;
            this.processingControl1.Location = new System.Drawing.Point(260, 21);
            this.processingControl1.Name = "processingControl1";
            this.processingControl1.NCircle = 8;
            this.processingControl1.Others = System.Drawing.Color.LightGray;
            this.processingControl1.Radius = 4;
            this.processingControl1.Size = new System.Drawing.Size(40, 40);
            this.processingControl1.TabIndex = 35;
            this.processingControl1.Text = "processingControl1";
            // 
            // lbl_serverStatus
            // 
            this.lbl_serverStatus.AutoSize = true;
            this.lbl_serverStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbl_serverStatus.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.lbl_serverStatus.ForeColor = System.Drawing.Color.Green;
            this.lbl_serverStatus.Location = new System.Drawing.Point(22, 21);
            this.lbl_serverStatus.Name = "lbl_serverStatus";
            this.lbl_serverStatus.Size = new System.Drawing.Size(199, 46);
            this.lbl_serverStatus.TabIndex = 34;
            this.lbl_serverStatus.Text = "LOADING...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.label1.Location = new System.Drawing.Point(28, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Address:";
            // 
            // btn_stopServer
            // 
            this.btn_stopServer.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_stopServer.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_stopServer.BackColor = System.Drawing.Color.Transparent;
            this.btn_stopServer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_stopServer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_stopServer.ForeColor = System.Drawing.Color.White;
            this.btn_stopServer.Icon = null;
            this.btn_stopServer.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_stopServer.ImageSize = new System.Drawing.Size(0, 0);
            this.btn_stopServer.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_stopServer.Inactive2 = System.Drawing.Color.Red;
            this.btn_stopServer.Location = new System.Drawing.Point(168, 143);
            this.btn_stopServer.Name = "btn_stopServer";
            this.btn_stopServer.Radius = 6;
            this.btn_stopServer.Size = new System.Drawing.Size(100, 32);
            this.btn_stopServer.Stroke = 0;
            this.btn_stopServer.StrokeColor = System.Drawing.Color.Gray;
            this.btn_stopServer.TabIndex = 1;
            this.btn_stopServer.Text = "Restart";
            this.btn_stopServer.Transparency = false;
            this.btn_stopServer.Click += new System.EventHandler(this.btn_stopServer_Click);
            // 
            // btn_startServer
            // 
            this.btn_startServer.Active1 = System.Drawing.Color.DodgerBlue;
            this.btn_startServer.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_startServer.BackColor = System.Drawing.Color.Transparent;
            this.btn_startServer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_startServer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_startServer.ForeColor = System.Drawing.Color.White;
            this.btn_startServer.Icon = null;
            this.btn_startServer.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_startServer.ImageSize = new System.Drawing.Size(0, 0);
            this.btn_startServer.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.btn_startServer.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.btn_startServer.Location = new System.Drawing.Point(53, 143);
            this.btn_startServer.Name = "btn_startServer";
            this.btn_startServer.Radius = 6;
            this.btn_startServer.Size = new System.Drawing.Size(100, 32);
            this.btn_startServer.Stroke = 0;
            this.btn_startServer.StrokeColor = System.Drawing.Color.Gray;
            this.btn_startServer.TabIndex = 0;
            this.btn_startServer.Text = "Start";
            this.btn_startServer.Transparency = false;
            this.btn_startServer.Click += new System.EventHandler(this.btn_startServer_Click);
            // 
            // timerHardware
            // 
            this.timerHardware.Interval = 1000;
            this.timerHardware.Tick += new System.EventHandler(this.timerHardware_Tick);
            // 
            // timerServer
            // 
            this.timerServer.Interval = 1000;
            this.timerServer.Tick += new System.EventHandler(this.timerServer_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(217)))), ((int)(((byte)(244)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column1,
            this.Column7,
            this.Column6,
            this.Column5,
            this.Column4});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(200)))), ((int)(((byte)(235)))));
            this.dataGridView1.Location = new System.Drawing.Point(320, 92);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(233)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.dataGridView1.RowTemplate.Height = 150;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1066, 625);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGridView1_CellValueNeeded);
            // 
            // workerLoading
            // 
            this.workerLoading.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerLoading_DoWork);
            this.workerLoading.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerLoading_RunWorkerCompleted);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "#";
            this.Column2.Name = "Column2";
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Image";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Biển số";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Vào lúc";
            this.Column7.Name = "Column7";
            this.Column7.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Elapsed";
            this.Column6.Name = "Column6";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "IP Address";
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Method";
            this.Column4.Name = "Column4";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 717);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.gradientPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Text = "VietANPR Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.gradientPanel3.ResumeLayout(false);
            this.gradientPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.colorGroupBox3.ResumeLayout(false);
            this.colorGroupBox3.PerformLayout();
            this.colorGroupBox2.ResumeLayout(false);
            this.colorGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.colorGroupBox1.ResumeLayout(false);
            this.colorGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TGMTcontrols.GradientPanel gradientPanel3;
        private System.Windows.Forms.Label label8;
        private TGMTcontrols.DefaultButton defaultButton5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private TGMTcontrols.DefaultButton defaultButton8;
        private System.Windows.Forms.Panel panelLeft;
        private TGMTcontrols.ColorGroupBox colorGroupBox1;
        private TGMTcontrols.DefaultButton btn_startServer;
        private TGMTcontrols.DangerButton btn_stopServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_serverStatus;
        private TGMTcontrols.ProcessingControl processingControl1;
        private TGMTcontrols.ColorGroupBox colorGroupBox2;
        private System.Windows.Forms.Label lbl_CPU;
        private System.Windows.Forms.Label lbl_VRAM;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbl_CUDA;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_RAM;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.Label lbl_upTime;
        private TGMTcontrols.ColorGroupBox colorGroupBox3;
        private System.Windows.Forms.Label label27;
        private TGMTcontrols.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Timer timerHardware;
        private System.Windows.Forms.Label lbl_GPU;
        private System.Windows.Forms.Label lbl_CPUname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timerServer;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker workerLoading;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}


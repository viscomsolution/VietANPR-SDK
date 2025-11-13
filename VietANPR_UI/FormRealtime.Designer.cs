namespace VietANPR_UI
{
    partial class FormRealtime
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.panelLogo = new System.Windows.Forms.Panel();
            this.rd_showAll = new System.Windows.Forms.RadioButton();
            this.rd_validOnly = new System.Windows.Forms.RadioButton();
            this.btn_start = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.lbl_result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_clear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panelResult = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picWebcam = new System.Windows.Forms.PictureBox();
            this.timerDetect = new System.Windows.Forms.Timer(this.components);
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(100, 100);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timerClear
            // 
            this.timerClear.Interval = 2000;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(183)))), ((int)(((byte)(110)))));
            this.panelLogo.Controls.Add(this.rd_showAll);
            this.panelLogo.Controls.Add(this.rd_validOnly);
            this.panelLogo.Controls.Add(this.btn_start);
            this.panelLogo.Controls.Add(this.progressBar1);
            this.panelLogo.Controls.Add(this.label5);
            this.panelLogo.Controls.Add(this.label4);
            this.panelLogo.Controls.Add(this.numericUpDown1);
            this.panelLogo.Controls.Add(this.cbCamera);
            this.panelLogo.Controls.Add(this.lbl_result);
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(982, 120);
            this.panelLogo.TabIndex = 21;
            // 
            // rd_showAll
            // 
            this.rd_showAll.AutoSize = true;
            this.rd_showAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_showAll.ForeColor = System.Drawing.Color.White;
            this.rd_showAll.Location = new System.Drawing.Point(175, 84);
            this.rd_showAll.Name = "rd_showAll";
            this.rd_showAll.Size = new System.Drawing.Size(130, 25);
            this.rd_showAll.TabIndex = 17;
            this.rd_showAll.Text = "Show all result";
            this.rd_showAll.UseVisualStyleBackColor = true;
            // 
            // rd_validOnly
            // 
            this.rd_validOnly.AutoSize = true;
            this.rd_validOnly.Checked = true;
            this.rd_validOnly.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_validOnly.ForeColor = System.Drawing.Color.White;
            this.rd_validOnly.Location = new System.Drawing.Point(21, 84);
            this.rd_validOnly.Name = "rd_validOnly";
            this.rd_validOnly.Size = new System.Drawing.Size(138, 25);
            this.rd_validOnly.TabIndex = 16;
            this.rd_validOnly.TabStop = true;
            this.rd_validOnly.Text = "Show valid only";
            this.rd_validOnly.UseVisualStyleBackColor = true;
            this.rd_validOnly.CheckedChanged += new System.EventHandler(this.rd_validOnly_CheckedChanged);
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(188)))));
            this.btn_start.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_start.ForeColor = System.Drawing.Color.White;
            this.btn_start.Location = new System.Drawing.Point(372, 13);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(129, 35);
            this.btn_start.TabIndex = 9;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(319, 50);
            this.progressBar1.Maximum = 20;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(182, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(228, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "milisecond";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Interval";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(102, 50);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // cbCamera
            // 
            this.cbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamera.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(102, 19);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(264, 25);
            this.cbCamera.TabIndex = 3;
            this.cbCamera.SelectedIndexChanged += new System.EventHandler(this.cbCamera_SelectedIndexChanged);
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_result.ForeColor = System.Drawing.Color.White;
            this.lbl_result.Location = new System.Drawing.Point(507, 14);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(76, 30);
            this.lbl_result.TabIndex = 2;
            this.lbl_result.Text = "Result";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Webcam";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(188)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.picWebcam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 532);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(188)))));
            this.panel2.Controls.Add(this.btn_clear);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.panelResult);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.picCamera);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 532);
            this.panel2.TabIndex = 26;
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_clear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_clear.ForeColor = System.Drawing.Color.White;
            this.btn_clear.Location = new System.Drawing.Point(788, 3);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(129, 35);
            this.btn_clear.TabIndex = 10;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(689, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 25);
            this.label6.TabIndex = 27;
            this.label6.Text = "Results";
            // 
            // panelResult
            // 
            this.panelResult.AutoScroll = true;
            this.panelResult.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelResult.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.panelResult.Location = new System.Drawing.Point(489, 39);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(490, 508);
            this.panelResult.TabIndex = 26;
            this.panelResult.WrapContents = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(188, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 25);
            this.label3.TabIndex = 25;
            this.label3.Text = "Webcam";
            // 
            // picCamera
            // 
            this.picCamera.BackColor = System.Drawing.Color.White;
            this.picCamera.Location = new System.Drawing.Point(3, 39);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(480, 294);
            this.picCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamera.TabIndex = 24;
            this.picCamera.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(188, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Ảnh input";
            // 
            // picWebcam
            // 
            this.picWebcam.BackColor = System.Drawing.Color.White;
            this.picWebcam.Location = new System.Drawing.Point(21, 63);
            this.picWebcam.Name = "picWebcam";
            this.picWebcam.Size = new System.Drawing.Size(480, 320);
            this.picWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWebcam.TabIndex = 24;
            this.picWebcam.TabStop = false;
            // 
            // timerDetect
            // 
            this.timerDetect.Interval = 500;
            this.timerDetect.Tick += new System.EventHandler(this.timerDetect_Tick);
            // 
            // FormRealtime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 652);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelLogo);
            this.Name = "FormRealtime";
            this.Text = "Đọc biển số xe realtime";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRealtime_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.FormWebcam_VisibleChanged);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timerClear;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lbl_result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picWebcam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Timer timerDetect;
        private System.Windows.Forms.FlowLayoutPanel panelResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.RadioButton rd_validOnly;
        private System.Windows.Forms.RadioButton rd_showAll;
    }
}


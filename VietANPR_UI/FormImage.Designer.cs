namespace VietANPR_UI
{
    partial class FormImage
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
            this.timerProgressbar = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.panelLogo = new System.Windows.Forms.Panel();
            this.txt_fileName = new AltoControls.BrowseFile();
            this.btn_detect = new AltoControls.AltoButton();
            this.chk_crop = new System.Windows.Forms.CheckBox();
            this.chk_draw = new System.Windows.Forms.CheckBox();
            this.lbl_result = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picWebcam = new System.Windows.Forms.PictureBox();
            this.panelLogo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).BeginInit();
            this.SuspendLayout();
            // 
            // timerProgressbar
            // 
            this.timerProgressbar.Interval = 10;
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
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.panelLogo.Controls.Add(this.txt_fileName);
            this.panelLogo.Controls.Add(this.btn_detect);
            this.panelLogo.Controls.Add(this.chk_crop);
            this.panelLogo.Controls.Add(this.chk_draw);
            this.panelLogo.Controls.Add(this.lbl_result);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(1023, 86);
            this.panelLogo.TabIndex = 21;
            // 
            // txt_fileName
            // 
            this.txt_fileName.BackColor = System.Drawing.Color.Transparent;
            this.txt_fileName.BackgroundColor = System.Drawing.Color.White;
            this.txt_fileName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.txt_fileName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_fileName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_fileName.Location = new System.Drawing.Point(21, 12);
            this.txt_fileName.Name = "txt_fileName";
            this.txt_fileName.Padding = new System.Windows.Forms.Padding(5);
            this.txt_fileName.Pattern = "";
            this.txt_fileName.Size = new System.Drawing.Size(457, 30);
            this.txt_fileName.TabIndex = 11;
            this.txt_fileName.TextChanged += new System.EventHandler(this.txt_fileName_TextChanged);
            // 
            // btn_detect
            // 
            this.btn_detect.Active1 = System.Drawing.Color.DodgerBlue;
            this.btn_detect.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_detect.BackColor = System.Drawing.Color.Transparent;
            this.btn_detect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_detect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_detect.ForeColor = System.Drawing.Color.White;
            this.btn_detect.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.btn_detect.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.btn_detect.Location = new System.Drawing.Point(489, 9);
            this.btn_detect.Name = "btn_detect";
            this.btn_detect.Radius = 10;
            this.btn_detect.Size = new System.Drawing.Size(110, 40);
            this.btn_detect.Stroke = false;
            this.btn_detect.StrokeColor = System.Drawing.Color.Gray;
            this.btn_detect.TabIndex = 9;
            this.btn_detect.Text = "Detect";
            this.btn_detect.Transparency = false;
            this.btn_detect.Click += new System.EventHandler(this.btn_detect_Click);
            // 
            // chk_crop
            // 
            this.chk_crop.AutoSize = true;
            this.chk_crop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chk_crop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chk_crop.Location = new System.Drawing.Point(626, 12);
            this.chk_crop.Name = "chk_crop";
            this.chk_crop.Size = new System.Drawing.Size(92, 23);
            this.chk_crop.TabIndex = 8;
            this.chk_crop.Text = "Crop plate";
            this.chk_crop.UseVisualStyleBackColor = true;
            this.chk_crop.CheckedChanged += new System.EventHandler(this.chk_crop_CheckedChanged);
            // 
            // chk_draw
            // 
            this.chk_draw.AutoSize = true;
            this.chk_draw.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chk_draw.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chk_draw.Location = new System.Drawing.Point(726, 12);
            this.chk_draw.Name = "chk_draw";
            this.chk_draw.Size = new System.Drawing.Size(157, 23);
            this.chk_draw.TabIndex = 6;
            this.chk_draw.Text = "Draw text - rectangle";
            this.chk_draw.UseVisualStyleBackColor = true;
            this.chk_draw.CheckedChanged += new System.EventHandler(this.chk_draw_CheckedChanged);
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_result.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_result.Location = new System.Drawing.Point(16, 53);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(76, 30);
            this.lbl_result.TabIndex = 2;
            this.lbl_result.Text = "Result";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(188)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.picWebcam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1023, 419);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(188)))));
            this.panel2.Controls.Add(this.picResult);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1023, 419);
            this.panel2.TabIndex = 26;
            // 
            // picResult
            // 
            this.picResult.BackColor = System.Drawing.Color.White;
            this.picResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picResult.Location = new System.Drawing.Point(0, 0);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(1023, 419);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picResult.TabIndex = 26;
            this.picResult.TabStop = false;
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
            // FormImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 505);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelLogo);
            this.Name = "FormImage";
            this.Text = "Đọc từng ảnh";
            this.Load += new System.EventHandler(this.FormImage_Load);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerProgressbar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timerClear;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lbl_result;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picWebcam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.CheckBox chk_draw;
        private System.Windows.Forms.CheckBox chk_crop;
        private AltoControls.AltoButton btn_detect;
        private AltoControls.BrowseFile txt_fileName;
    }
}


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
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.panelLogo = new System.Windows.Forms.Panel();
            this.txt_fileName = new TGMTcontrols.BrowseFile();
            this.btn_detect = new TGMTcontrols.DefaultButton();
            this.panelPicture = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelResult = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLogo.SuspendLayout();
            this.panelPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerProgressbar
            // 
            this.timerProgressbar.Interval = 10;
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
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(1023, 66);
            this.panelLogo.TabIndex = 21;
            // 
            // txt_fileName
            // 
            this.txt_fileName.BackColor = System.Drawing.Color.Transparent;
            this.txt_fileName.BackgroundColor = System.Drawing.Color.White;
            this.txt_fileName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.txt_fileName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_fileName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_fileName.Location = new System.Drawing.Point(21, 15);
            this.txt_fileName.Name = "txt_fileName";
            this.txt_fileName.Padding = new System.Windows.Forms.Padding(5);
            this.txt_fileName.Pattern = "";
            this.txt_fileName.Size = new System.Drawing.Size(748, 30);
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
            this.btn_detect.Icon = null;
            this.btn_detect.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_detect.ImageSize = new System.Drawing.Size(0, 0);
            this.btn_detect.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.btn_detect.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.btn_detect.Location = new System.Drawing.Point(775, 12);
            this.btn_detect.Name = "btn_detect";
            this.btn_detect.Radius = 6;
            this.btn_detect.Size = new System.Drawing.Size(110, 33);
            this.btn_detect.Stroke = 0;
            this.btn_detect.StrokeColor = System.Drawing.Color.Gray;
            this.btn_detect.TabIndex = 9;
            this.btn_detect.Text = "Detect";
            this.btn_detect.Transparency = false;
            this.btn_detect.Click += new System.EventHandler(this.btn_detect_Click);
            // 
            // panelPicture
            // 
            this.panelPicture.Controls.Add(this.pictureBox1);
            this.panelPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPicture.Location = new System.Drawing.Point(0, 66);
            this.panelPicture.Name = "panelPicture";
            this.panelPicture.Size = new System.Drawing.Size(595, 439);
            this.panelPicture.TabIndex = 29;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(564, 416);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // panelResult
            // 
            this.panelResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResult.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelResult.Location = new System.Drawing.Point(595, 66);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(428, 439);
            this.panelResult.TabIndex = 30;
            // 
            // FormImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 505);
            this.Controls.Add(this.panelPicture);
            this.Controls.Add(this.panelResult);
            this.Controls.Add(this.panelLogo);
            this.Name = "FormImage";
            this.Text = "Đọc từng ảnh";
            this.Load += new System.EventHandler(this.FormImage_Load);
            this.Shown += new System.EventHandler(this.FormImage_Shown);
            this.SizeChanged += new System.EventHandler(this.FormImage_SizeChanged);
            this.panelLogo.ResumeLayout(false);
            this.panelPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerProgressbar;
        private System.Windows.Forms.Timer timerClear;
        private System.Windows.Forms.Panel panelLogo;
        private TGMTcontrols.DefaultButton btn_detect;
        private TGMTcontrols.BrowseFile txt_fileName;
        private System.Windows.Forms.Panel panelPicture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel panelResult;
    }
}


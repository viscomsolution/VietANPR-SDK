namespace ExamplePOSTrequest
{
    partial class Form1
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
            if(disposing && (components != null))
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
            this.txt_filePath = new TGMTcontrols.BrowseFile();
            this.label2 = new System.Windows.Forms.Label();
            this.colorGroupBox1 = new TGMTcontrols.ColorGroupBox();
            this.circle1 = new TGMTcontrols.ProcessingControl();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_serverIP = new TGMTcontrols.RoundedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_serverPort = new TGMTcontrols.RoundedTextBox();
            this.colorGroupBox2 = new TGMTcontrols.ColorGroupBox();
            this.btn_send = new TGMTcontrols.DefaultButton();
            this.panelResult = new System.Windows.Forms.FlowLayoutPanel();
            this.panelPicture = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorGroupBox1.SuspendLayout();
            this.colorGroupBox2.SuspendLayout();
            this.panelPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_filePath
            // 
            this.txt_filePath.BackColor = System.Drawing.Color.Transparent;
            this.txt_filePath.BackgroundColor = System.Drawing.Color.White;
            this.txt_filePath.BorderColor = System.Drawing.Color.Red;
            this.txt_filePath.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_filePath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_filePath.Location = new System.Drawing.Point(106, 36);
            this.txt_filePath.Name = "txt_filePath";
            this.txt_filePath.Padding = new System.Windows.Forms.Padding(5);
            this.txt_filePath.Pattern = "";
            this.txt_filePath.Size = new System.Drawing.Size(479, 30);
            this.txt_filePath.TabIndex = 0;
            this.txt_filePath.TextChanged += new System.EventHandler(this.txt_filePath_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label2.Location = new System.Drawing.Point(28, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 193;
            this.label2.Text = "Chọn file";
            // 
            // colorGroupBox1
            // 
            this.colorGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.colorGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.colorGroupBox1.BorderThickness = 3;
            this.colorGroupBox1.Checked = false;
            this.colorGroupBox1.Controls.Add(this.circle1);
            this.colorGroupBox1.Controls.Add(this.label11);
            this.colorGroupBox1.Controls.Add(this.txt_serverIP);
            this.colorGroupBox1.Controls.Add(this.label10);
            this.colorGroupBox1.Controls.Add(this.txt_serverPort);
            this.colorGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorGroupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.colorGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.colorGroupBox1.InsideColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.colorGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.colorGroupBox1.Margin = new System.Windows.Forms.Padding(8, 10, 8, 8);
            this.colorGroupBox1.Name = "colorGroupBox1";
            this.colorGroupBox1.Radius = 8;
            this.colorGroupBox1.ShowCheckbox = false;
            this.colorGroupBox1.Size = new System.Drawing.Size(960, 100);
            this.colorGroupBox1.TabIndex = 194;
            this.colorGroupBox1.TabStop = false;
            this.colorGroupBox1.Text = "Server";
            // 
            // circle1
            // 
            this.circle1.BackColor = System.Drawing.Color.Transparent;
            this.circle1.IndexColor = System.Drawing.Color.DeepSkyBlue;
            this.circle1.Interval = 50;
            this.circle1.Location = new System.Drawing.Point(391, 32);
            this.circle1.Name = "circle1";
            this.circle1.NCircle = 8;
            this.circle1.Others = System.Drawing.Color.LightGray;
            this.circle1.Radius = 4;
            this.circle1.Size = new System.Drawing.Size(40, 40);
            this.circle1.TabIndex = 123;
            this.circle1.Text = "processingControl1";
            this.circle1.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(36, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 122;
            this.label11.Text = "IP Server";
            // 
            // txt_serverIP
            // 
            this.txt_serverIP.BackColor = System.Drawing.Color.Transparent;
            this.txt_serverIP.BackgroundColor = System.Drawing.Color.White;
            this.txt_serverIP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.txt_serverIP.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_serverIP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_serverIP.Location = new System.Drawing.Point(106, 38);
            this.txt_serverIP.Multiline = false;
            this.txt_serverIP.Name = "txt_serverIP";
            this.txt_serverIP.NumberOnly = false;
            this.txt_serverIP.Padding = new System.Windows.Forms.Padding(5);
            this.txt_serverIP.Radius = 4;
            this.txt_serverIP.Size = new System.Drawing.Size(140, 30);
            this.txt_serverIP.TabIndex = 121;
            this.txt_serverIP.TabStop = false;
            this.txt_serverIP.Text = "192.168.1.200";
            this.txt_serverIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_serverIP.TextChanged += new System.EventHandler(this.txt_serverIP_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(272, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 16);
            this.label10.TabIndex = 120;
            this.label10.Text = "Port";
            // 
            // txt_serverPort
            // 
            this.txt_serverPort.BackColor = System.Drawing.Color.Transparent;
            this.txt_serverPort.BackgroundColor = System.Drawing.Color.White;
            this.txt_serverPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.txt_serverPort.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_serverPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_serverPort.Location = new System.Drawing.Point(310, 37);
            this.txt_serverPort.Multiline = false;
            this.txt_serverPort.Name = "txt_serverPort";
            this.txt_serverPort.NumberOnly = true;
            this.txt_serverPort.Padding = new System.Windows.Forms.Padding(5);
            this.txt_serverPort.Radius = 4;
            this.txt_serverPort.Size = new System.Drawing.Size(61, 30);
            this.txt_serverPort.TabIndex = 119;
            this.txt_serverPort.TabStop = false;
            this.txt_serverPort.Text = "9999";
            this.txt_serverPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_serverPort.TextChanged += new System.EventHandler(this.txt_serverPort_TextChanged);
            // 
            // colorGroupBox2
            // 
            this.colorGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.colorGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.colorGroupBox2.BorderThickness = 3;
            this.colorGroupBox2.Checked = false;
            this.colorGroupBox2.Controls.Add(this.btn_send);
            this.colorGroupBox2.Controls.Add(this.txt_filePath);
            this.colorGroupBox2.Controls.Add(this.label2);
            this.colorGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorGroupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.colorGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.colorGroupBox2.InsideColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.colorGroupBox2.Location = new System.Drawing.Point(0, 100);
            this.colorGroupBox2.Margin = new System.Windows.Forms.Padding(8, 10, 8, 8);
            this.colorGroupBox2.Name = "colorGroupBox2";
            this.colorGroupBox2.Radius = 8;
            this.colorGroupBox2.ShowCheckbox = false;
            this.colorGroupBox2.Size = new System.Drawing.Size(960, 100);
            this.colorGroupBox2.TabIndex = 195;
            this.colorGroupBox2.TabStop = false;
            this.colorGroupBox2.Text = "Hình ảnh";
            // 
            // btn_send
            // 
            this.btn_send.Active1 = System.Drawing.Color.DodgerBlue;
            this.btn_send.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_send.BackColor = System.Drawing.Color.Transparent;
            this.btn_send.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_send.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_send.ForeColor = System.Drawing.Color.White;
            this.btn_send.Icon = null;
            this.btn_send.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_send.ImageSize = new System.Drawing.Size(0, 0);
            this.btn_send.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.btn_send.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.btn_send.Location = new System.Drawing.Point(602, 36);
            this.btn_send.Name = "btn_send";
            this.btn_send.Radius = 6;
            this.btn_send.Size = new System.Drawing.Size(110, 30);
            this.btn_send.Stroke = 0;
            this.btn_send.StrokeColor = System.Drawing.Color.Gray;
            this.btn_send.TabIndex = 194;
            this.btn_send.Text = "Send";
            this.btn_send.Transparency = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // panelResult
            // 
            this.panelResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResult.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelResult.Location = new System.Drawing.Point(532, 200);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(428, 396);
            this.panelResult.TabIndex = 196;
            // 
            // panelPicture
            // 
            this.panelPicture.Controls.Add(this.pictureBox1);
            this.panelPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPicture.Location = new System.Drawing.Point(0, 200);
            this.panelPicture.Name = "panelPicture";
            this.panelPicture.Size = new System.Drawing.Size(532, 396);
            this.panelPicture.TabIndex = 197;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(353, 312);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(960, 596);
            this.Controls.Add(this.panelPicture);
            this.Controls.Add(this.panelResult);
            this.Controls.Add(this.colorGroupBox2);
            this.Controls.Add(this.colorGroupBox1);
            this.Name = "Form1";
            this.Text = "Example POST request";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.colorGroupBox1.ResumeLayout(false);
            this.colorGroupBox1.PerformLayout();
            this.colorGroupBox2.ResumeLayout(false);
            this.colorGroupBox2.PerformLayout();
            this.panelPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TGMTcontrols.BrowseFile txt_filePath;
        private System.Windows.Forms.Label label2;
        private TGMTcontrols.ColorGroupBox colorGroupBox1;
        private TGMTcontrols.ProcessingControl circle1;
        private System.Windows.Forms.Label label11;
        private TGMTcontrols.RoundedTextBox txt_serverIP;
        private System.Windows.Forms.Label label10;
        private TGMTcontrols.RoundedTextBox txt_serverPort;
        private TGMTcontrols.ColorGroupBox colorGroupBox2;
        private System.Windows.Forms.FlowLayoutPanel panelResult;
        private System.Windows.Forms.Panel panelPicture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private TGMTcontrols.DefaultButton btn_send;
    }
}


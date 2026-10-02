namespace MiniServer
{
    partial class FormOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOption));
            this.colorGroupBox1 = new TGMTcontrols.ColorGroupBox();
            this.txt_secretKey = new TGMTcontrols.PasswordBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_serverIP = new TGMTcontrols.RoundedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_serverPort = new TGMTcontrols.RoundedTextBox();
            this.btn_save = new TGMTcontrols.DefaultButton();
            this.colorGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorGroupBox1
            // 
            this.colorGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.colorGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.colorGroupBox1.BorderThickness = 3;
            this.colorGroupBox1.Checked = false;
            this.colorGroupBox1.Controls.Add(this.txt_secretKey);
            this.colorGroupBox1.Controls.Add(this.label1);
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
            this.colorGroupBox1.Size = new System.Drawing.Size(722, 100);
            this.colorGroupBox1.TabIndex = 195;
            this.colorGroupBox1.TabStop = false;
            this.colorGroupBox1.Text = "Server";
            // 
            // txt_secretKey
            // 
            this.txt_secretKey.BackColor = System.Drawing.Color.Transparent;
            this.txt_secretKey.BackgroundColor = System.Drawing.Color.White;
            this.txt_secretKey.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.txt_secretKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_secretKey.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_secretKey.Location = new System.Drawing.Point(484, 35);
            this.txt_secretKey.Name = "txt_secretKey";
            this.txt_secretKey.Padding = new System.Windows.Forms.Padding(5);
            this.txt_secretKey.Radius = 6;
            this.txt_secretKey.Size = new System.Drawing.Size(206, 33);
            this.txt_secretKey.TabIndex = 124;
            this.txt_secretKey.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(402, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 123;
            this.label1.Text = "Secret key";
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
            this.txt_serverIP.Enabled = false;
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
            // 
            // btn_save
            // 
            this.btn_save.Active1 = System.Drawing.Color.DodgerBlue;
            this.btn_save.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Icon = global::MiniServer.Properties.Resources.save_32;
            this.btn_save.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_save.ImageSize = new System.Drawing.Size(24, 24);
            this.btn_save.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.btn_save.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.btn_save.Location = new System.Drawing.Point(311, 137);
            this.btn_save.Name = "btn_save";
            this.btn_save.Radius = 6;
            this.btn_save.Size = new System.Drawing.Size(113, 42);
            this.btn_save.Stroke = 0;
            this.btn_save.StrokeColor = System.Drawing.Color.Gray;
            this.btn_save.TabIndex = 196;
            this.btn_save.TabStop = false;
            this.btn_save.Text = "Save";
            this.btn_save.Transparency = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // FormOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(722, 219);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.colorGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOption";
            this.Text = "Option";
            this.Load += new System.EventHandler(this.FormOption_Load);
            this.colorGroupBox1.ResumeLayout(false);
            this.colorGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TGMTcontrols.ColorGroupBox colorGroupBox1;
        private TGMTcontrols.PasswordBox txt_secretKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private TGMTcontrols.RoundedTextBox txt_serverIP;
        private System.Windows.Forms.Label label10;
        private TGMTcontrols.RoundedTextBox txt_serverPort;
        private TGMTcontrols.DefaultButton btn_save;
    }
}
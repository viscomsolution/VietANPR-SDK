namespace VietANPR_UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btn_realtime = new System.Windows.Forms.Button();
            this.btn_ipCamera = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnFolder = new System.Windows.Forms.Button();
            this.btnWebcam = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lbl_version = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.timerProgressbar = new System.Windows.Forms.Timer(this.components);
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnSettings);
            this.panelMenu.Controls.Add(this.btn_realtime);
            this.panelMenu.Controls.Add(this.btn_ipCamera);
            this.panelMenu.Controls.Add(this.progressBar1);
            this.panelMenu.Controls.Add(this.btnFolder);
            this.panelMenu.Controls.Add(this.btnWebcam);
            this.panelMenu.Controls.Add(this.btnImage);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 679);
            this.panelMenu.TabIndex = 16;
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSettings.Image = global::VietANPR_UI.Properties.Resources.cog;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 370);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(200, 60);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = " Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btn_realtime
            // 
            this.btn_realtime.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_realtime.FlatAppearance.BorderSize = 0;
            this.btn_realtime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_realtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_realtime.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_realtime.Image = global::VietANPR_UI.Properties.Resources.car_running_32;
            this.btn_realtime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_realtime.Location = new System.Drawing.Point(0, 310);
            this.btn_realtime.Name = "btn_realtime";
            this.btn_realtime.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btn_realtime.Size = new System.Drawing.Size(200, 60);
            this.btn_realtime.TabIndex = 10;
            this.btn_realtime.Text = "  Realtime";
            this.btn_realtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_realtime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_realtime.UseVisualStyleBackColor = true;
            this.btn_realtime.Click += new System.EventHandler(this.btn_realtime_Click);
            // 
            // btn_ipCamera
            // 
            this.btn_ipCamera.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_ipCamera.FlatAppearance.BorderSize = 0;
            this.btn_ipCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ipCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ipCamera.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_ipCamera.Image = global::VietANPR_UI.Properties.Resources.cctv_32px;
            this.btn_ipCamera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ipCamera.Location = new System.Drawing.Point(0, 250);
            this.btn_ipCamera.Name = "btn_ipCamera";
            this.btn_ipCamera.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btn_ipCamera.Size = new System.Drawing.Size(200, 60);
            this.btn_ipCamera.TabIndex = 9;
            this.btn_ipCamera.Text = " IP camera";
            this.btn_ipCamera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ipCamera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ipCamera.UseVisualStyleBackColor = true;
            this.btn_ipCamera.Visible = false;
            this.btn_ipCamera.Click += new System.EventHandler(this.btn_ipCamera_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 656);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(200, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // btnFolder
            // 
            this.btnFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFolder.FlatAppearance.BorderSize = 0;
            this.btnFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolder.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFolder.Image = global::VietANPR_UI.Properties.Resources.folder_32px;
            this.btnFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFolder.Location = new System.Drawing.Point(0, 190);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnFolder.Size = new System.Drawing.Size(200, 60);
            this.btnFolder.TabIndex = 6;
            this.btnFolder.Text = "   Folder";
            this.btnFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // btnWebcam
            // 
            this.btnWebcam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWebcam.FlatAppearance.BorderSize = 0;
            this.btnWebcam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWebcam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebcam.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnWebcam.Image = global::VietANPR_UI.Properties.Resources.webcam_32;
            this.btnWebcam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWebcam.Location = new System.Drawing.Point(0, 130);
            this.btnWebcam.Name = "btnWebcam";
            this.btnWebcam.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnWebcam.Size = new System.Drawing.Size(200, 60);
            this.btnWebcam.TabIndex = 2;
            this.btnWebcam.Text = " Webcam";
            this.btnWebcam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWebcam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWebcam.UseVisualStyleBackColor = true;
            this.btnWebcam.Click += new System.EventHandler(this.btnWebcam_Click);
            // 
            // btnImage
            // 
            this.btnImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnImage.FlatAppearance.BorderSize = 0;
            this.btnImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImage.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnImage.Image = global::VietANPR_UI.Properties.Resources.picture_32;
            this.btnImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImage.Location = new System.Drawing.Point(0, 70);
            this.btnImage.Name = "btnImage";
            this.btnImage.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnImage.Size = new System.Drawing.Size(200, 60);
            this.btnImage.TabIndex = 1;
            this.btnImage.Text = "  Image";
            this.btnImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(72)))), ((int)(((byte)(51)))));
            this.panelLogo.Controls.Add(this.lbl_version);
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 70);
            this.panelLogo.TabIndex = 0;
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_version.ForeColor = System.Drawing.Color.White;
            this.lbl_version.Location = new System.Drawing.Point(86, 41);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(56, 17);
            this.lbl_version.TabIndex = 2;
            this.lbl_version.Text = "Version";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VietANPR_UI.Properties.Resources.icon_number_plate_white;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(76, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "VietANPR";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 679);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1187, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // panelDesktop
            // 
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(200, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(987, 679);
            this.panelDesktop.TabIndex = 17;
            // 
            // timerProgressbar
            // 
            this.timerProgressbar.Enabled = true;
            this.timerProgressbar.Interval = 10;
            this.timerProgressbar.Tick += new System.EventHandler(this.timerProgressbar_Tick);
            // 
            // timerClear
            // 
            this.timerClear.Interval = 2000;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 300000;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 701);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Việt ANPR | Phần mềm đọc biển số xe máy - xe hơi ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Button btnWebcam;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Timer timerProgressbar;
        private System.Windows.Forms.Timer timerClear;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btn_realtime;
        private System.Windows.Forms.Button btn_ipCamera;
        private System.Windows.Forms.Label lbl_version;
    }
}
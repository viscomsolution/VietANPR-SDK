namespace VietANPR_UI.UC
{
    partial class UCplate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picResult = new System.Windows.Forms.PictureBox();
            this.lbl_num = new System.Windows.Forms.Label();
            this.lbl_plate = new System.Windows.Forms.Label();
            this.lbl_scoreQuad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.SuspendLayout();
            // 
            // picResult
            // 
            this.picResult.BackColor = System.Drawing.Color.White;
            this.picResult.Dock = System.Windows.Forms.DockStyle.Left;
            this.picResult.Location = new System.Drawing.Point(0, 0);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(174, 120);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picResult.TabIndex = 0;
            this.picResult.TabStop = false;
            // 
            // lbl_num
            // 
            this.lbl_num.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_num.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.lbl_num.Location = new System.Drawing.Point(174, 0);
            this.lbl_num.Name = "lbl_num";
            this.lbl_num.Size = new System.Drawing.Size(226, 25);
            this.lbl_num.TabIndex = 1;
            this.lbl_num.Text = "1";
            this.lbl_num.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_plate
            // 
            this.lbl_plate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_plate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lbl_plate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_plate.Location = new System.Drawing.Point(174, 25);
            this.lbl_plate.Name = "lbl_plate";
            this.lbl_plate.Size = new System.Drawing.Size(226, 35);
            this.lbl_plate.TabIndex = 2;
            this.lbl_plate.Text = "Biển số";
            this.lbl_plate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_scoreQuad
            // 
            this.lbl_scoreQuad.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_scoreQuad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_scoreQuad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(82)))), ((int)(((byte)(125)))));
            this.lbl_scoreQuad.Location = new System.Drawing.Point(174, 60);
            this.lbl_scoreQuad.Name = "lbl_scoreQuad";
            this.lbl_scoreQuad.Size = new System.Drawing.Size(226, 25);
            this.lbl_scoreQuad.TabIndex = 4;
            this.lbl_scoreQuad.Text = "Score polygon";
            this.lbl_scoreQuad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UCplate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl_scoreQuad);
            this.Controls.Add(this.lbl_plate);
            this.Controls.Add(this.lbl_num);
            this.Controls.Add(this.picResult);
            this.Name = "UCplate";
            this.Size = new System.Drawing.Size(400, 120);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label lbl_num;
        public System.Windows.Forms.PictureBox picResult;
        public System.Windows.Forms.Label lbl_plate;
        public System.Windows.Forms.Label lbl_scoreQuad;
    }
}

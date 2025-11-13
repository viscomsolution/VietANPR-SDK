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
            this.lblPlate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.SuspendLayout();
            // 
            // picResult
            // 
            this.picResult.BackColor = System.Drawing.Color.White;
            this.picResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.picResult.Location = new System.Drawing.Point(0, 0);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(291, 164);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picResult.TabIndex = 0;
            this.picResult.TabStop = false;
            // 
            // lblPlate
            // 
            this.lblPlate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlate.Location = new System.Drawing.Point(0, 167);
            this.lblPlate.Name = "lblPlate";
            this.lblPlate.Size = new System.Drawing.Size(291, 25);
            this.lblPlate.TabIndex = 1;
            this.lblPlate.Text = "69M1 035.69";
            this.lblPlate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblPlate);
            this.Controls.Add(this.picResult);
            this.Name = "UCplate";
            this.Size = new System.Drawing.Size(291, 192);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label lblPlate;
        public System.Windows.Forms.PictureBox picResult;
    }
}

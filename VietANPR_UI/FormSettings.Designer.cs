namespace VietANPR_UI
{
    partial class FormSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_center = new System.Windows.Forms.RadioButton();
            this.rd_biggest = new System.Windows.Forms.RadioButton();
            this.rd_topLeft = new System.Windows.Forms.RadioButton();
            this.rd_all = new System.Windows.Forms.RadioButton();
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.btn_save = new TGMTcontrols.DefaultButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.rd_center);
            this.groupBox1.Controls.Add(this.rd_biggest);
            this.groupBox1.Controls.Add(this.rd_topLeft);
            this.groupBox1.Controls.Add(this.rd_all);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 194);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ảnh có nhiều biển số";
            // 
            // rd_center
            // 
            this.rd_center.AutoSize = true;
            this.rd_center.Location = new System.Drawing.Point(18, 128);
            this.rd_center.Name = "rd_center";
            this.rd_center.Size = new System.Drawing.Size(244, 23);
            this.rd_center.TabIndex = 3;
            this.rd_center.TabStop = true;
            this.rd_center.Text = "Đọc 01 biển số gần trung tâm nhất";
            this.rd_center.UseVisualStyleBackColor = true;
            // 
            // rd_biggest
            // 
            this.rd_biggest.AutoSize = true;
            this.rd_biggest.Location = new System.Drawing.Point(18, 99);
            this.rd_biggest.Name = "rd_biggest";
            this.rd_biggest.Size = new System.Drawing.Size(241, 23);
            this.rd_biggest.TabIndex = 2;
            this.rd_biggest.TabStop = true;
            this.rd_biggest.Text = "Đọc 01 biển số kích thước lớn nhất";
            this.rd_biggest.UseVisualStyleBackColor = true;
            // 
            // rd_topLeft
            // 
            this.rd_topLeft.AutoSize = true;
            this.rd_topLeft.Checked = true;
            this.rd_topLeft.Location = new System.Drawing.Point(17, 70);
            this.rd_topLeft.Name = "rd_topLeft";
            this.rd_topLeft.Size = new System.Drawing.Size(241, 23);
            this.rd_topLeft.TabIndex = 1;
            this.rd_topLeft.TabStop = true;
            this.rd_topLeft.Text = "Đọc 01 biển số đúng nhất (default)";
            this.rd_topLeft.UseVisualStyleBackColor = true;
            // 
            // rd_all
            // 
            this.rd_all.AutoSize = true;
            this.rd_all.Location = new System.Drawing.Point(17, 41);
            this.rd_all.Name = "rd_all";
            this.rd_all.Size = new System.Drawing.Size(339, 23);
            this.rd_all.TabIndex = 0;
            this.rd_all.TabStop = true;
            this.rd_all.Text = "Đọc tất cả biển số, cách nhau bằng dấu chấm phẩy";
            this.rd_all.UseVisualStyleBackColor = true;
            // 
            // timerClear
            // 
            this.timerClear.Interval = 1000;
            // 
            // btn_save
            // 
            this.btn_save.Active1 = System.Drawing.Color.DodgerBlue;
            this.btn_save.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.btn_save.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.btn_save.Location = new System.Drawing.Point(317, 223);
            this.btn_save.Name = "btn_save";
            this.btn_save.Radius = 10;
            this.btn_save.Size = new System.Drawing.Size(110, 40);
            this.btn_save.StrokeColor = System.Drawing.Color.Gray;
            this.btn_save.TabIndex = 27;
            this.btn_save.Text = "Save";
            this.btn_save.Transparency = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timerClear;
        private System.Windows.Forms.RadioButton rd_center;
        private System.Windows.Forms.RadioButton rd_biggest;
        private System.Windows.Forms.RadioButton rd_topLeft;
        private System.Windows.Forms.RadioButton rd_all;
        private TGMTcontrols.DefaultButton btn_save;
    }
}
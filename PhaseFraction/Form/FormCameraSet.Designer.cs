namespace PhaseFraction
{
    partial class FormCameraSet
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
            this.BtnPhoto = new System.Windows.Forms.Button();
            this.Btnvideo = new System.Windows.Forms.Button();
            this.BtnCalib = new System.Windows.Forms.Button();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnDrawRoi = new System.Windows.Forms.Button();
            this.BtnGenRoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnPhoto
            // 
            this.BtnPhoto.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnPhoto.Location = new System.Drawing.Point(416, 43);
            this.BtnPhoto.Name = "BtnPhoto";
            this.BtnPhoto.Size = new System.Drawing.Size(133, 30);
            this.BtnPhoto.TabIndex = 39;
            this.BtnPhoto.Text = "拍照";
            this.BtnPhoto.UseVisualStyleBackColor = true;
            this.BtnPhoto.Click += new System.EventHandler(this.BtnPhoto_Click);
            // 
            // Btnvideo
            // 
            this.Btnvideo.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btnvideo.Location = new System.Drawing.Point(416, 98);
            this.Btnvideo.Name = "Btnvideo";
            this.Btnvideo.Size = new System.Drawing.Size(133, 30);
            this.Btnvideo.TabIndex = 38;
            this.Btnvideo.Text = "录像";
            this.Btnvideo.UseVisualStyleBackColor = true;
            this.Btnvideo.Click += new System.EventHandler(this.Btnvideo_Click);
            // 
            // BtnCalib
            // 
            this.BtnCalib.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCalib.Location = new System.Drawing.Point(416, 313);
            this.BtnCalib.Name = "BtnCalib";
            this.BtnCalib.Size = new System.Drawing.Size(133, 30);
            this.BtnCalib.TabIndex = 40;
            this.BtnCalib.Text = "标定";
            this.BtnCalib.UseVisualStyleBackColor = true;
            // 
            // BtnOpen
            // 
            this.BtnOpen.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOpen.Location = new System.Drawing.Point(416, 152);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(133, 30);
            this.BtnOpen.TabIndex = 41;
            this.BtnOpen.Text = "打开图像";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnDrawRoi
            // 
            this.BtnDrawRoi.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnDrawRoi.Location = new System.Drawing.Point(416, 205);
            this.BtnDrawRoi.Name = "BtnDrawRoi";
            this.BtnDrawRoi.Size = new System.Drawing.Size(133, 30);
            this.BtnDrawRoi.TabIndex = 42;
            this.BtnDrawRoi.Text = "画ROI";
            this.BtnDrawRoi.UseVisualStyleBackColor = true;
            this.BtnDrawRoi.Click += new System.EventHandler(this.BtnDrawRoi_Click);
            // 
            // BtnGenRoi
            // 
            this.BtnGenRoi.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnGenRoi.Location = new System.Drawing.Point(416, 259);
            this.BtnGenRoi.Name = "BtnGenRoi";
            this.BtnGenRoi.Size = new System.Drawing.Size(133, 30);
            this.BtnGenRoi.TabIndex = 43;
            this.BtnGenRoi.Text = "生成ROI";
            this.BtnGenRoi.UseVisualStyleBackColor = true;
            this.BtnGenRoi.Click += new System.EventHandler(this.BtnGenRoi_Click);
            // 
            // FormCameraSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 406);
            this.Controls.Add(this.BtnGenRoi);
            this.Controls.Add(this.BtnDrawRoi);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.BtnCalib);
            this.Controls.Add(this.BtnPhoto);
            this.Controls.Add(this.Btnvideo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormCameraSet";
            this.Text = "FormCameraSet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCameraSet_FormClosing);
            this.Load += new System.EventHandler(this.FormCameraSet_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button BtnPhoto;
        public System.Windows.Forms.Button Btnvideo;
        public System.Windows.Forms.Button BtnCalib;
        public System.Windows.Forms.Button BtnOpen;
        public System.Windows.Forms.Button BtnDrawRoi;
        public System.Windows.Forms.Button BtnGenRoi;
    }
}
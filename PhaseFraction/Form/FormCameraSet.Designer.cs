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
            this.SuspendLayout();
            // 
            // BtnPhoto
            // 
            this.BtnPhoto.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnPhoto.Location = new System.Drawing.Point(555, 54);
            this.BtnPhoto.Margin = new System.Windows.Forms.Padding(4);
            this.BtnPhoto.Name = "BtnPhoto";
            this.BtnPhoto.Size = new System.Drawing.Size(177, 38);
            this.BtnPhoto.TabIndex = 39;
            this.BtnPhoto.Text = "拍照";
            this.BtnPhoto.UseVisualStyleBackColor = true;
            this.BtnPhoto.Click += new System.EventHandler(this.BtnPhoto_Click);
            // 
            // Btnvideo
            // 
            this.Btnvideo.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btnvideo.Location = new System.Drawing.Point(555, 122);
            this.Btnvideo.Margin = new System.Windows.Forms.Padding(4);
            this.Btnvideo.Name = "Btnvideo";
            this.Btnvideo.Size = new System.Drawing.Size(177, 38);
            this.Btnvideo.TabIndex = 38;
            this.Btnvideo.Text = "录像";
            this.Btnvideo.UseVisualStyleBackColor = true;
            this.Btnvideo.Click += new System.EventHandler(this.Btnvideo_Click);
            // 
            // BtnCalib
            // 
            this.BtnCalib.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCalib.Location = new System.Drawing.Point(555, 211);
            this.BtnCalib.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCalib.Name = "BtnCalib";
            this.BtnCalib.Size = new System.Drawing.Size(177, 38);
            this.BtnCalib.TabIndex = 40;
            this.BtnCalib.Text = "标定";
            this.BtnCalib.UseVisualStyleBackColor = true;
            // 
            // FormCameraSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 507);
            this.Controls.Add(this.BtnCalib);
            this.Controls.Add(this.BtnPhoto);
            this.Controls.Add(this.Btnvideo);
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
    }
}
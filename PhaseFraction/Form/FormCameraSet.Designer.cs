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
            this.BtnSaveImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CBTransition = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CBSelect = new System.Windows.Forms.ComboBox();
            this.BtnSaveParam = new System.Windows.Forms.Button();
            this.ChkBSelect = new System.Windows.Forms.CheckBox();
            this.BtnProcessImage = new System.Windows.Forms.Button();
            this.NUDThreshold = new System.Windows.Forms.NumericUpDown();
            this.NUDSigma = new System.Windows.Forms.NumericUpDown();
            this.BtnBorder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NUDThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSigma)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnPhoto
            // 
            this.BtnPhoto.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnPhoto.Location = new System.Drawing.Point(24, 27);
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
            this.Btnvideo.Location = new System.Drawing.Point(207, 27);
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
            this.BtnCalib.Location = new System.Drawing.Point(24, 159);
            this.BtnCalib.Name = "BtnCalib";
            this.BtnCalib.Size = new System.Drawing.Size(133, 30);
            this.BtnCalib.TabIndex = 40;
            this.BtnCalib.Text = "标定";
            this.BtnCalib.UseVisualStyleBackColor = true;
            // 
            // BtnOpen
            // 
            this.BtnOpen.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOpen.Location = new System.Drawing.Point(377, 27);
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
            this.BtnDrawRoi.Location = new System.Drawing.Point(207, 71);
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
            this.BtnGenRoi.Location = new System.Drawing.Point(377, 72);
            this.BtnGenRoi.Name = "BtnGenRoi";
            this.BtnGenRoi.Size = new System.Drawing.Size(133, 30);
            this.BtnGenRoi.TabIndex = 43;
            this.BtnGenRoi.Text = "生成ROI";
            this.BtnGenRoi.UseVisualStyleBackColor = true;
            this.BtnGenRoi.Click += new System.EventHandler(this.BtnGenRoi_Click);
            // 
            // BtnSaveImage
            // 
            this.BtnSaveImage.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSaveImage.Location = new System.Drawing.Point(207, 115);
            this.BtnSaveImage.Name = "BtnSaveImage";
            this.BtnSaveImage.Size = new System.Drawing.Size(133, 30);
            this.BtnSaveImage.TabIndex = 44;
            this.BtnSaveImage.Text = "保存图像";
            this.BtnSaveImage.UseVisualStyleBackColor = true;
            this.BtnSaveImage.Click += new System.EventHandler(this.BtnSaveImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 272);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 47;
            this.label1.Text = "幅度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(309, 274);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 48;
            this.label2.Text = "平滑";
            // 
            // CBTransition
            // 
            this.CBTransition.FormattingEnabled = true;
            this.CBTransition.Items.AddRange(new object[] {
            "all",
            "positive",
            "negative"});
            this.CBTransition.Location = new System.Drawing.Point(371, 315);
            this.CBTransition.Margin = new System.Windows.Forms.Padding(2);
            this.CBTransition.Name = "CBTransition";
            this.CBTransition.Size = new System.Drawing.Size(92, 20);
            this.CBTransition.TabIndex = 49;
            this.CBTransition.SelectedIndexChanged += new System.EventHandler(this.CBTransition_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(318, 316);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 50;
            this.label3.Text = "变换";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(20, 315);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 19);
            this.label4.TabIndex = 52;
            this.label4.Text = "位置";
            // 
            // CBSelect
            // 
            this.CBSelect.FormattingEnabled = true;
            this.CBSelect.Items.AddRange(new object[] {
            "all",
            "first",
            "last"});
            this.CBSelect.Location = new System.Drawing.Point(73, 315);
            this.CBSelect.Margin = new System.Windows.Forms.Padding(2);
            this.CBSelect.Name = "CBSelect";
            this.CBSelect.Size = new System.Drawing.Size(92, 20);
            this.CBSelect.TabIndex = 51;
            this.CBSelect.SelectedIndexChanged += new System.EventHandler(this.CBSelect_SelectedIndexChanged);
            this.CBSelect.TextChanged += new System.EventHandler(this.CBSelect_TextChanged);
            // 
            // BtnSaveParam
            // 
            this.BtnSaveParam.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSaveParam.Location = new System.Drawing.Point(377, 115);
            this.BtnSaveParam.Name = "BtnSaveParam";
            this.BtnSaveParam.Size = new System.Drawing.Size(133, 30);
            this.BtnSaveParam.TabIndex = 53;
            this.BtnSaveParam.Text = "保存参数";
            this.BtnSaveParam.UseVisualStyleBackColor = true;
            this.BtnSaveParam.Click += new System.EventHandler(this.BtnSaveParam_Click);
            // 
            // ChkBSelect
            // 
            this.ChkBSelect.AutoSize = true;
            this.ChkBSelect.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChkBSelect.Location = new System.Drawing.Point(24, 374);
            this.ChkBSelect.Name = "ChkBSelect";
            this.ChkBSelect.Size = new System.Drawing.Size(68, 23);
            this.ChkBSelect.TabIndex = 54;
            this.ChkBSelect.Text = "边缘";
            this.ChkBSelect.UseVisualStyleBackColor = true;
            this.ChkBSelect.CheckedChanged += new System.EventHandler(this.ChkBSelect_CheckedChanged);
            // 
            // BtnProcessImage
            // 
            this.BtnProcessImage.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnProcessImage.Location = new System.Drawing.Point(24, 115);
            this.BtnProcessImage.Name = "BtnProcessImage";
            this.BtnProcessImage.Size = new System.Drawing.Size(133, 30);
            this.BtnProcessImage.TabIndex = 55;
            this.BtnProcessImage.Text = "处理图像";
            this.BtnProcessImage.UseVisualStyleBackColor = true;
            this.BtnProcessImage.Click += new System.EventHandler(this.BtnProcessImage_Click);
            // 
            // NUDThreshold
            // 
            this.NUDThreshold.Location = new System.Drawing.Point(93, 272);
            this.NUDThreshold.Name = "NUDThreshold";
            this.NUDThreshold.Size = new System.Drawing.Size(120, 21);
            this.NUDThreshold.TabIndex = 57;
            this.NUDThreshold.ValueChanged += new System.EventHandler(this.NUDThreshold_ValueChanged);
            // 
            // NUDSigma
            // 
            this.NUDSigma.Location = new System.Drawing.Point(382, 272);
            this.NUDSigma.Name = "NUDSigma";
            this.NUDSigma.Size = new System.Drawing.Size(120, 21);
            this.NUDSigma.TabIndex = 58;
            this.NUDSigma.ValueChanged += new System.EventHandler(this.NUDSigma_ValueChanged);
            // 
            // BtnBorder
            // 
            this.BtnBorder.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnBorder.Location = new System.Drawing.Point(24, 71);
            this.BtnBorder.Name = "BtnBorder";
            this.BtnBorder.Size = new System.Drawing.Size(133, 30);
            this.BtnBorder.TabIndex = 59;
            this.BtnBorder.Text = "设置检测框";
            this.BtnBorder.UseVisualStyleBackColor = true;
            this.BtnBorder.Click += new System.EventHandler(this.BtnBorder_Click);
            // 
            // FormCameraSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 428);
            this.Controls.Add(this.BtnBorder);
            this.Controls.Add(this.NUDSigma);
            this.Controls.Add(this.NUDThreshold);
            this.Controls.Add(this.BtnProcessImage);
            this.Controls.Add(this.ChkBSelect);
            this.Controls.Add(this.BtnSaveParam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CBSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CBTransition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSaveImage);
            this.Controls.Add(this.BtnGenRoi);
            this.Controls.Add(this.BtnDrawRoi);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.BtnCalib);
            this.Controls.Add(this.BtnPhoto);
            this.Controls.Add(this.Btnvideo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCameraSet";
            this.Text = "FormCameraSet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCameraSet_FormClosing);
            this.Load += new System.EventHandler(this.FormCameraSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUDThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSigma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button BtnPhoto;
        public System.Windows.Forms.Button Btnvideo;
        public System.Windows.Forms.Button BtnCalib;
        public System.Windows.Forms.Button BtnOpen;
        public System.Windows.Forms.Button BtnDrawRoi;
        public System.Windows.Forms.Button BtnGenRoi;
        public System.Windows.Forms.Button BtnSaveImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBSelect;
        public System.Windows.Forms.ComboBox CBTransition;
        public System.Windows.Forms.Button BtnSaveParam;
        private System.Windows.Forms.CheckBox ChkBSelect;
        public System.Windows.Forms.Button BtnProcessImage;
        private System.Windows.Forms.NumericUpDown NUDThreshold;
        private System.Windows.Forms.NumericUpDown NUDSigma;
        public System.Windows.Forms.Button BtnBorder;
    }
}
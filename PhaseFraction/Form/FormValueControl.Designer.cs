namespace PhaseFraction
{
    partial class FormValueControl
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
            this.BtnInLiquidValue = new System.Windows.Forms.Button();
            this.BtnByPassValue = new System.Windows.Forms.Button();
            this.BtnOutGasValue = new System.Windows.Forms.Button();
            this.BtnOutLiquidValue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnInLiquidValue
            // 
            this.BtnInLiquidValue.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnInLiquidValue.Location = new System.Drawing.Point(57, 182);
            this.BtnInLiquidValue.Name = "BtnInLiquidValue";
            this.BtnInLiquidValue.Size = new System.Drawing.Size(186, 30);
            this.BtnInLiquidValue.TabIndex = 43;
            this.BtnInLiquidValue.Text = "进液电磁阀";
            this.BtnInLiquidValue.UseVisualStyleBackColor = true;
            // 
            // BtnByPassValue
            // 
            this.BtnByPassValue.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnByPassValue.Location = new System.Drawing.Point(57, 56);
            this.BtnByPassValue.Name = "BtnByPassValue";
            this.BtnByPassValue.Size = new System.Drawing.Size(186, 30);
            this.BtnByPassValue.TabIndex = 42;
            this.BtnByPassValue.Text = "打开旁路电磁阀";
            this.BtnByPassValue.UseVisualStyleBackColor = true;
            this.BtnByPassValue.Click += new System.EventHandler(this.BtnByPassValue_Click);
            // 
            // BtnOutGasValue
            // 
            this.BtnOutGasValue.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutGasValue.Location = new System.Drawing.Point(291, 56);
            this.BtnOutGasValue.Name = "BtnOutGasValue";
            this.BtnOutGasValue.Size = new System.Drawing.Size(186, 30);
            this.BtnOutGasValue.TabIndex = 41;
            this.BtnOutGasValue.Text = "排气电磁阀";
            this.BtnOutGasValue.UseVisualStyleBackColor = true;
            // 
            // BtnOutLiquidValue
            // 
            this.BtnOutLiquidValue.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOutLiquidValue.Location = new System.Drawing.Point(291, 182);
            this.BtnOutLiquidValue.Name = "BtnOutLiquidValue";
            this.BtnOutLiquidValue.Size = new System.Drawing.Size(186, 30);
            this.BtnOutLiquidValue.TabIndex = 44;
            this.BtnOutLiquidValue.Text = "出液电磁阀";
            this.BtnOutLiquidValue.UseVisualStyleBackColor = true;
            // 
            // FormValueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 319);
            this.Controls.Add(this.BtnOutLiquidValue);
            this.Controls.Add(this.BtnInLiquidValue);
            this.Controls.Add(this.BtnByPassValue);
            this.Controls.Add(this.BtnOutGasValue);
            this.Name = "FormValueControl";
            this.Text = "FormValueControl";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button BtnInLiquidValue;
        public System.Windows.Forms.Button BtnByPassValue;
        public System.Windows.Forms.Button BtnOutGasValue;
        public System.Windows.Forms.Button BtnOutLiquidValue;
    }
}
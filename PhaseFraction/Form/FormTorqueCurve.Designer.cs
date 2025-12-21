namespace PhaseFraction
{
    partial class FormTorqueCurve
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TmrAcquireTorque = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(11, 13);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(908, 690);
            this.groupBox3.TabIndex = 2115;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "力矩曲线";
            // 
            // TmrAcquireTorque
            // 
            this.TmrAcquireTorque.Interval = 500;
            this.TmrAcquireTorque.Tick += new System.EventHandler(this.TmrAcquireTorque_Tick);
            // 
            // FormTorqueCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 723);
            this.Controls.Add(this.groupBox3);
            this.Name = "FormTorqueCurve";
            this.Text = "力矩曲线";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTorqueCurve_FormClosing);
            this.Load += new System.EventHandler(this.FormTorqueCurve_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Timer TmrAcquireTorque;
    }
}
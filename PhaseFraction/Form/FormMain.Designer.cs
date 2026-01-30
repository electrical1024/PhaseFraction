namespace PhaseFraction
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lstMessage = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serialPortScaner = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.CmsChangeState = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddBarcode = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteBarcode = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeState = new System.Windows.Forms.ToolStripMenuItem();
            this.ToEmergency = new System.Windows.Forms.ToolStripMenuItem();
            this.ToComon = new System.Windows.Forms.ToolStripMenuItem();
            this.ToNonEmergency = new System.Windows.Forms.ToolStripMenuItem();
            this.WhLocking = new System.Windows.Forms.ToolStripMenuItem();
            this.WhUnlock = new System.Windows.Forms.ToolStripMenuItem();
            this.MnsMain = new System.Windows.Forms.MenuStrip();
            this.CameraSetTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ValueSetTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.TempCurveTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.PressureCurveTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.TorqueCurveTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnCreatConnect = new System.Windows.Forms.Button();
            this.BtnAlarmReset = new System.Windows.Forms.Button();
            this.BtnPause = new System.Windows.Forms.Button();
            this.TmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.ByPassValue = new HZH_Controls.Controls.UCValve();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.OutGasConduit2 = new HZH_Controls.Controls.UCConduit();
            this.OutLiquidValue = new HZH_Controls.Controls.UCValve();
            this.OutLiquidConduit1 = new HZH_Controls.Controls.UCConduit();
            this.OutGasConduit3 = new HZH_Controls.Controls.UCConduit();
            this.OutLiquidConduit2 = new HZH_Controls.Controls.UCConduit();
            this.OutGasValue = new HZH_Controls.Controls.UCValve();
            this.OutLiquidConduit3 = new HZH_Controls.Controls.UCConduit();
            this.OutGasConduit1 = new HZH_Controls.Controls.UCConduit();
            this.InLiquidConduit3 = new HZH_Controls.Controls.UCConduit();
            this.InLiquidValue = new HZH_Controls.Controls.UCValve();
            this.InLiquidConduit2 = new HZH_Controls.Controls.UCConduit();
            this.ByPassConduit1 = new HZH_Controls.Controls.UCConduit();
            this.InLiquidConduit1 = new HZH_Controls.Controls.UCConduit();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LblSensorState = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.LblCameraState = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.LblPLCState = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.hSmartWindowControl1 = new HalconDotNet.HSmartWindowControl();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LblLevel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.LblPressure = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.LblTemp = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.CmsChangeState.SuspendLayout();
            this.MnsMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMessage
            // 
            this.lstMessage.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lstMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lstMessage.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMessage.GridLines = true;
            this.lstMessage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstMessage.HideSelection = false;
            this.lstMessage.Location = new System.Drawing.Point(14, 25);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(430, 311);
            this.lstMessage.TabIndex = 1653;
            this.lstMessage.UseCompatibleStateImageBehavior = false;
            this.lstMessage.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "时间";
            this.ColumnHeader1.Width = 119;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "信息";
            this.ColumnHeader2.Width = 15000;
            // 
            // serialPortScaner
            // 
            this.serialPortScaner.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortScaner_DataReceived);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstMessage);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(727, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 346);
            this.groupBox1.TabIndex = 2110;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运行记录";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label25.Location = new System.Drawing.Point(1860, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(36, 20);
            this.label25.TabIndex = 2124;
            this.label25.Text = "test";
            this.label25.Visible = false;
            // 
            // CmsChangeState
            // 
            this.CmsChangeState.Font = new System.Drawing.Font("新細明體-ExtB", 9F);
            this.CmsChangeState.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CmsChangeState.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBarcode,
            this.DeleteBarcode,
            this.ChangeState,
            this.WhLocking,
            this.WhUnlock});
            this.CmsChangeState.Name = "contextMenuStrip1";
            this.CmsChangeState.Size = new System.Drawing.Size(143, 114);
            // 
            // AddBarcode
            // 
            this.AddBarcode.Name = "AddBarcode";
            this.AddBarcode.Size = new System.Drawing.Size(142, 22);
            this.AddBarcode.Text = "添加";
            this.AddBarcode.Click += new System.EventHandler(this.AddBarcode_Click);
            // 
            // DeleteBarcode
            // 
            this.DeleteBarcode.Name = "DeleteBarcode";
            this.DeleteBarcode.Size = new System.Drawing.Size(142, 22);
            this.DeleteBarcode.Text = "刪除";
            this.DeleteBarcode.Click += new System.EventHandler(this.DeleteBarcode_Click);
            // 
            // ChangeState
            // 
            this.ChangeState.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToEmergency,
            this.ToComon,
            this.ToNonEmergency});
            this.ChangeState.Name = "ChangeState";
            this.ChangeState.Size = new System.Drawing.Size(142, 22);
            this.ChangeState.Text = "改變倉庫狀態";
            this.ChangeState.Visible = false;
            // 
            // ToEmergency
            // 
            this.ToEmergency.Name = "ToEmergency";
            this.ToEmergency.Size = new System.Drawing.Size(130, 22);
            this.ToEmergency.Text = "轉為緊急";
            // 
            // ToComon
            // 
            this.ToComon.Name = "ToComon";
            this.ToComon.Size = new System.Drawing.Size(130, 22);
            this.ToComon.Text = "轉為一般";
            // 
            // ToNonEmergency
            // 
            this.ToNonEmergency.Name = "ToNonEmergency";
            this.ToNonEmergency.Size = new System.Drawing.Size(130, 22);
            this.ToNonEmergency.Text = "轉為非緊急";
            this.ToNonEmergency.Visible = false;
            // 
            // WhLocking
            // 
            this.WhLocking.Name = "WhLocking";
            this.WhLocking.Size = new System.Drawing.Size(142, 22);
            this.WhLocking.Text = "鎖定";
            this.WhLocking.Visible = false;
            // 
            // WhUnlock
            // 
            this.WhUnlock.Name = "WhUnlock";
            this.WhUnlock.Size = new System.Drawing.Size(142, 22);
            this.WhUnlock.Text = "解鎖";
            this.WhUnlock.Visible = false;
            // 
            // MnsMain
            // 
            this.MnsMain.AutoSize = false;
            this.MnsMain.BackColor = System.Drawing.Color.Silver;
            this.MnsMain.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MnsMain.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.MnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CameraSetTSMI,
            this.ValueSetTSMI,
            this.TempCurveTSMI,
            this.PressureCurveTSMI,
            this.TorqueCurveTSMI,
            this.LoginTSMI});
            this.MnsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MnsMain.Location = new System.Drawing.Point(0, 0);
            this.MnsMain.Name = "MnsMain";
            this.MnsMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MnsMain.Size = new System.Drawing.Size(1186, 43);
            this.MnsMain.TabIndex = 2111;
            this.MnsMain.Text = "MenuStrip1";
            // 
            // CameraSetTSMI
            // 
            this.CameraSetTSMI.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CameraSetTSMI.Name = "CameraSetTSMI";
            this.CameraSetTSMI.Size = new System.Drawing.Size(101, 39);
            this.CameraSetTSMI.Text = "相机设定";
            this.CameraSetTSMI.Click += new System.EventHandler(this.CameraSetTSMI_Click);
            // 
            // ValueSetTSMI
            // 
            this.ValueSetTSMI.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ValueSetTSMI.Name = "ValueSetTSMI";
            this.ValueSetTSMI.Size = new System.Drawing.Size(121, 39);
            this.ValueSetTSMI.Text = "电磁阀控制";
            this.ValueSetTSMI.Visible = false;
            this.ValueSetTSMI.Click += new System.EventHandler(this.ValueSetTSMI_Click);
            // 
            // TempCurveTSMI
            // 
            this.TempCurveTSMI.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TempCurveTSMI.Name = "TempCurveTSMI";
            this.TempCurveTSMI.Size = new System.Drawing.Size(101, 39);
            this.TempCurveTSMI.Text = "温度曲线";
            this.TempCurveTSMI.Visible = false;
            this.TempCurveTSMI.Click += new System.EventHandler(this.TempCurveTSMI_Click);
            // 
            // PressureCurveTSMI
            // 
            this.PressureCurveTSMI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PressureCurveTSMI.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PressureCurveTSMI.Image = ((System.Drawing.Image)(resources.GetObject("PressureCurveTSMI.Image")));
            this.PressureCurveTSMI.Name = "PressureCurveTSMI";
            this.PressureCurveTSMI.Size = new System.Drawing.Size(101, 39);
            this.PressureCurveTSMI.Text = "压力曲线";
            this.PressureCurveTSMI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PressureCurveTSMI.Visible = false;
            this.PressureCurveTSMI.Click += new System.EventHandler(this.PressureCurveTSMI_Click);
            // 
            // TorqueCurveTSMI
            // 
            this.TorqueCurveTSMI.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TorqueCurveTSMI.Name = "TorqueCurveTSMI";
            this.TorqueCurveTSMI.Size = new System.Drawing.Size(101, 39);
            this.TorqueCurveTSMI.Text = "液位曲线";
            this.TorqueCurveTSMI.Visible = false;
            this.TorqueCurveTSMI.Click += new System.EventHandler(this.TorqueCurveTSMI_Click);
            // 
            // LoginTSMI
            // 
            this.LoginTSMI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoginTSMI.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LoginTSMI.Image = ((System.Drawing.Image)(resources.GetObject("LoginTSMI.Image")));
            this.LoginTSMI.Name = "LoginTSMI";
            this.LoginTSMI.Size = new System.Drawing.Size(102, 39);
            this.LoginTSMI.Text = "登陆权限";
            this.LoginTSMI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.LoginTSMI.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnStart);
            this.groupBox2.Controls.Add(this.BtnCreatConnect);
            this.groupBox2.Controls.Add(this.BtnAlarmReset);
            this.groupBox2.Controls.Add(this.BtnPause);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(727, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 108);
            this.groupBox2.TabIndex = 2112;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本操作";
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStart.Location = new System.Drawing.Point(8, 66);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(133, 30);
            this.BtnStart.TabIndex = 38;
            this.BtnStart.Text = "开始测量";
            this.BtnStart.UseVisualStyleBackColor = true;
            // 
            // BtnCreatConnect
            // 
            this.BtnCreatConnect.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCreatConnect.Location = new System.Drawing.Point(8, 29);
            this.BtnCreatConnect.Name = "BtnCreatConnect";
            this.BtnCreatConnect.Size = new System.Drawing.Size(133, 30);
            this.BtnCreatConnect.TabIndex = 37;
            this.BtnCreatConnect.Text = "建立通讯";
            this.BtnCreatConnect.UseVisualStyleBackColor = true;
            this.BtnCreatConnect.Click += new System.EventHandler(this.BtnCreatConnect_Click);
            // 
            // BtnAlarmReset
            // 
            this.BtnAlarmReset.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAlarmReset.Location = new System.Drawing.Point(299, 29);
            this.BtnAlarmReset.Name = "BtnAlarmReset";
            this.BtnAlarmReset.Size = new System.Drawing.Size(133, 30);
            this.BtnAlarmReset.TabIndex = 31;
            this.BtnAlarmReset.Text = "报警复位";
            this.BtnAlarmReset.UseVisualStyleBackColor = true;
            this.BtnAlarmReset.Click += new System.EventHandler(this.BtnAlarmReset_Click);
            // 
            // BtnPause
            // 
            this.BtnPause.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnPause.Location = new System.Drawing.Point(299, 66);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(133, 30);
            this.BtnPause.TabIndex = 34;
            this.BtnPause.Text = "停止测量";
            this.BtnPause.UseVisualStyleBackColor = true;
            // 
            // TmrRefresh
            // 
            this.TmrRefresh.Interval = 200;
            this.TmrRefresh.Tick += new System.EventHandler(this.m);
            // 
            // ByPassValue
            // 
            this.ByPassValue.AsisBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ByPassValue.AxisColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ByPassValue.BackColor = System.Drawing.Color.Pink;
            this.ByPassValue.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ByPassValue.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ByPassValue.LiquidSpeed = 100;
            this.ByPassValue.Location = new System.Drawing.Point(316, 607);
            this.ByPassValue.Margin = new System.Windows.Forms.Padding(2);
            this.ByPassValue.Name = "ByPassValue";
            this.ByPassValue.Opened = true;
            this.ByPassValue.Size = new System.Drawing.Size(86, 64);
            this.ByPassValue.SwitchColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ByPassValue.TabIndex = 2159;
            this.ByPassValue.ValveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ByPassValue.ValveStyle = HZH_Controls.Controls.ValveStyle.Horizontal_Top;
            this.ByPassValue.Click += new System.EventHandler(this.ByPassValue_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F);
            this.label13.Location = new System.Drawing.Point(334, 591);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 16);
            this.label13.TabIndex = 2175;
            this.label13.Text = "直通阀";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.Location = new System.Drawing.Point(65, 569);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 2174;
            this.label9.Text = "进液阀";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(522, 138);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 16);
            this.label8.TabIndex = 2173;
            this.label8.Text = "排气阀";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(531, 548);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 2158;
            this.label7.Text = "出液阀";
            // 
            // OutGasConduit2
            // 
            this.OutGasConduit2.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.OutGasConduit2.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Horizontal_None_None;
            this.OutGasConduit2.ConduitWidth = 60;
            this.OutGasConduit2.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.OutGasConduit2.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.OutGasConduit2.LiquidSpeed = 100;
            this.OutGasConduit2.Location = new System.Drawing.Point(463, 105);
            this.OutGasConduit2.Margin = new System.Windows.Forms.Padding(2);
            this.OutGasConduit2.Name = "OutGasConduit2";
            this.OutGasConduit2.Size = new System.Drawing.Size(169, 15);
            this.OutGasConduit2.TabIndex = 2172;
            // 
            // OutLiquidValue
            // 
            this.OutLiquidValue.AsisBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.OutLiquidValue.AxisColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.OutLiquidValue.BackColor = System.Drawing.Color.Pink;
            this.OutLiquidValue.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.OutLiquidValue.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.OutLiquidValue.LiquidSpeed = 100;
            this.OutLiquidValue.Location = new System.Drawing.Point(509, 579);
            this.OutLiquidValue.Margin = new System.Windows.Forms.Padding(2);
            this.OutLiquidValue.Name = "OutLiquidValue";
            this.OutLiquidValue.Opened = true;
            this.OutLiquidValue.Size = new System.Drawing.Size(90, 54);
            this.OutLiquidValue.SwitchColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.OutLiquidValue.TabIndex = 2171;
            this.OutLiquidValue.ValveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.OutLiquidValue.ValveStyle = HZH_Controls.Controls.ValveStyle.Horizontal_Top;
            this.OutLiquidValue.Click += new System.EventHandler(this.OutLiquidValue_Click);
            // 
            // OutLiquidConduit1
            // 
            this.OutLiquidConduit1.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.OutLiquidConduit1.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_None_Right;
            this.OutLiquidConduit1.ConduitWidth = 50;
            this.OutLiquidConduit1.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.OutLiquidConduit1.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.OutLiquidConduit1.LiquidSpeed = 100;
            this.OutLiquidConduit1.Location = new System.Drawing.Point(442, 562);
            this.OutLiquidConduit1.Margin = new System.Windows.Forms.Padding(2);
            this.OutLiquidConduit1.Name = "OutLiquidConduit1";
            this.OutLiquidConduit1.Size = new System.Drawing.Size(22, 63);
            this.OutLiquidConduit1.TabIndex = 2170;
            // 
            // OutGasConduit3
            // 
            this.OutGasConduit3.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.OutGasConduit3.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_Left_None;
            this.OutGasConduit3.ConduitWidth = 60;
            this.OutGasConduit3.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.OutGasConduit3.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.OutGasConduit3.LiquidSpeed = 100;
            this.OutGasConduit3.Location = new System.Drawing.Point(629, 104);
            this.OutGasConduit3.Margin = new System.Windows.Forms.Padding(2);
            this.OutGasConduit3.Name = "OutGasConduit3";
            this.OutGasConduit3.Size = new System.Drawing.Size(15, 503);
            this.OutGasConduit3.TabIndex = 2167;
            this.OutGasConduit3.Load += new System.EventHandler(this.ucConduit7_Load);
            // 
            // OutLiquidConduit2
            // 
            this.OutLiquidConduit2.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.OutLiquidConduit2.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Horizontal_None_Down;
            this.OutLiquidConduit2.ConduitWidth = 50;
            this.OutLiquidConduit2.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.OutLiquidConduit2.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.OutLiquidConduit2.LiquidSpeed = 100;
            this.OutLiquidConduit2.Location = new System.Drawing.Point(463, 607);
            this.OutLiquidConduit2.Margin = new System.Windows.Forms.Padding(2);
            this.OutLiquidConduit2.Name = "OutLiquidConduit2";
            this.OutLiquidConduit2.Size = new System.Drawing.Size(223, 18);
            this.OutLiquidConduit2.TabIndex = 2169;
            // 
            // OutGasValue
            // 
            this.OutGasValue.AsisBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.OutGasValue.AxisColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.OutGasValue.BackColor = System.Drawing.Color.Pink;
            this.OutGasValue.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.OutGasValue.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.OutGasValue.LiquidSpeed = 100;
            this.OutGasValue.Location = new System.Drawing.Point(501, 77);
            this.OutGasValue.Margin = new System.Windows.Forms.Padding(2);
            this.OutGasValue.Name = "OutGasValue";
            this.OutGasValue.Opened = true;
            this.OutGasValue.Size = new System.Drawing.Size(98, 53);
            this.OutGasValue.SwitchColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.OutGasValue.TabIndex = 2166;
            this.OutGasValue.ValveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.OutGasValue.ValveStyle = HZH_Controls.Controls.ValveStyle.Horizontal_Top;
            this.OutGasValue.Load += new System.EventHandler(this.OutGasValue_Load);
            this.OutGasValue.Click += new System.EventHandler(this.OutGasValue_Click);
            // 
            // OutLiquidConduit3
            // 
            this.OutLiquidConduit3.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.OutLiquidConduit3.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_None_None;
            this.OutLiquidConduit3.ConduitWidth = 50;
            this.OutLiquidConduit3.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.OutLiquidConduit3.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.OutLiquidConduit3.LiquidSpeed = 100;
            this.OutLiquidConduit3.Location = new System.Drawing.Point(664, 614);
            this.OutLiquidConduit3.Margin = new System.Windows.Forms.Padding(2);
            this.OutLiquidConduit3.Name = "OutLiquidConduit3";
            this.OutLiquidConduit3.Size = new System.Drawing.Size(22, 37);
            this.OutLiquidConduit3.TabIndex = 2168;
            // 
            // OutGasConduit1
            // 
            this.OutGasConduit1.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.OutGasConduit1.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_Right_None;
            this.OutGasConduit1.ConduitWidth = 50;
            this.OutGasConduit1.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.OutGasConduit1.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Backward;
            this.OutGasConduit1.LiquidSpeed = 100;
            this.OutGasConduit1.Location = new System.Drawing.Point(448, 104);
            this.OutGasConduit1.Margin = new System.Windows.Forms.Padding(2);
            this.OutGasConduit1.Name = "OutGasConduit1";
            this.OutGasConduit1.Size = new System.Drawing.Size(15, 49);
            this.OutGasConduit1.TabIndex = 2165;
            // 
            // InLiquidConduit3
            // 
            this.InLiquidConduit3.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.InLiquidConduit3.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_None_None;
            this.InLiquidConduit3.ConduitWidth = 50;
            this.InLiquidConduit3.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.InLiquidConduit3.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Backward;
            this.InLiquidConduit3.LiquidSpeed = 100;
            this.InLiquidConduit3.Location = new System.Drawing.Point(289, 562);
            this.InLiquidConduit3.Margin = new System.Windows.Forms.Padding(2);
            this.InLiquidConduit3.Name = "InLiquidConduit3";
            this.InLiquidConduit3.Size = new System.Drawing.Size(22, 35);
            this.InLiquidConduit3.TabIndex = 2164;
            // 
            // InLiquidValue
            // 
            this.InLiquidValue.AsisBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.InLiquidValue.AxisColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.InLiquidValue.BackColor = System.Drawing.Color.Pink;
            this.InLiquidValue.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.InLiquidValue.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.InLiquidValue.LiquidSpeed = 100;
            this.InLiquidValue.Location = new System.Drawing.Point(132, 567);
            this.InLiquidValue.Margin = new System.Windows.Forms.Padding(2);
            this.InLiquidValue.Name = "InLiquidValue";
            this.InLiquidValue.Opened = true;
            this.InLiquidValue.Size = new System.Drawing.Size(90, 53);
            this.InLiquidValue.SwitchColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.InLiquidValue.TabIndex = 2163;
            this.InLiquidValue.ValveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.InLiquidValue.ValveStyle = HZH_Controls.Controls.ValveStyle.Horizontal_Top;
            this.InLiquidValue.Load += new System.EventHandler(this.InLiquidValue_Load);
            this.InLiquidValue.Click += new System.EventHandler(this.InLiquidValue_Click);
            // 
            // InLiquidConduit2
            // 
            this.InLiquidConduit2.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.InLiquidConduit2.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Horizontal_None_Up;
            this.InLiquidConduit2.ConduitWidth = 50;
            this.InLiquidConduit2.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.InLiquidConduit2.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.InLiquidConduit2.LiquidSpeed = 100;
            this.InLiquidConduit2.Location = new System.Drawing.Point(59, 594);
            this.InLiquidConduit2.Margin = new System.Windows.Forms.Padding(2);
            this.InLiquidConduit2.Name = "InLiquidConduit2";
            this.InLiquidConduit2.Size = new System.Drawing.Size(252, 18);
            this.InLiquidConduit2.TabIndex = 2162;
            // 
            // ByPassConduit1
            // 
            this.ByPassConduit1.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ByPassConduit1.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Horizontal_None_None;
            this.ByPassConduit1.ConduitWidth = 100;
            this.ByPassConduit1.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ByPassConduit1.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ByPassConduit1.LiquidSpeed = 100;
            this.ByPassConduit1.Location = new System.Drawing.Point(14, 639);
            this.ByPassConduit1.Margin = new System.Windows.Forms.Padding(2);
            this.ByPassConduit1.Name = "ByPassConduit1";
            this.ByPassConduit1.Size = new System.Drawing.Size(691, 24);
            this.ByPassConduit1.TabIndex = 2161;
            // 
            // InLiquidConduit1
            // 
            this.InLiquidConduit1.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.InLiquidConduit1.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_Right_None;
            this.InLiquidConduit1.ConduitWidth = 50;
            this.InLiquidConduit1.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.InLiquidConduit1.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Backward;
            this.InLiquidConduit1.LiquidSpeed = 100;
            this.InLiquidConduit1.Location = new System.Drawing.Point(39, 593);
            this.InLiquidConduit1.Margin = new System.Windows.Forms.Padding(2);
            this.InLiquidConduit1.Name = "InLiquidConduit1";
            this.InLiquidConduit1.Size = new System.Drawing.Size(20, 58);
            this.InLiquidConduit1.TabIndex = 2160;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LblSensorState);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.LblCameraState);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.LblPLCState);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(727, 53);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(450, 143);
            this.groupBox4.TabIndex = 2127;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "设备状态显示";
            // 
            // LblSensorState
            // 
            this.LblSensorState.AutoSize = true;
            this.LblSensorState.BackColor = System.Drawing.Color.Pink;
            this.LblSensorState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblSensorState.Location = new System.Drawing.Point(327, 85);
            this.LblSensorState.Name = "LblSensorState";
            this.LblSensorState.Size = new System.Drawing.Size(55, 16);
            this.LblSensorState.TabIndex = 43;
            this.LblSensorState.Text = "未连接";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(10, 85);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(135, 16);
            this.label16.TabIndex = 42;
            this.label16.Text = "传感器连接状态：";
            // 
            // LblCameraState
            // 
            this.LblCameraState.AutoSize = true;
            this.LblCameraState.BackColor = System.Drawing.Color.Pink;
            this.LblCameraState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblCameraState.Location = new System.Drawing.Point(328, 58);
            this.LblCameraState.Name = "LblCameraState";
            this.LblCameraState.Size = new System.Drawing.Size(55, 16);
            this.LblCameraState.TabIndex = 41;
            this.LblCameraState.Text = "未连接";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(25, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 16);
            this.label14.TabIndex = 40;
            this.label14.Text = "相机连接状态：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(55, 112);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 16);
            this.label19.TabIndex = 39;
            this.label19.Text = "报警状态：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.LightGreen;
            this.label20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(327, 112);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(87, 16);
            this.label20.TabIndex = 38;
            this.label20.Text = "未发生报警";
            // 
            // LblPLCState
            // 
            this.LblPLCState.AutoSize = true;
            this.LblPLCState.BackColor = System.Drawing.Color.Pink;
            this.LblPLCState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblPLCState.Location = new System.Drawing.Point(327, 30);
            this.LblPLCState.Name = "LblPLCState";
            this.LblPLCState.Size = new System.Drawing.Size(55, 16);
            this.LblPLCState.TabIndex = 3;
            this.LblPLCState.Text = "未连接";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(32, 30);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(111, 16);
            this.label24.TabIndex = 0;
            this.label24.Text = "PLC连接状态：";
            // 
            // hSmartWindowControl1
            // 
            this.hSmartWindowControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hSmartWindowControl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.hSmartWindowControl1.HDoubleClickToFitContent = true;
            this.hSmartWindowControl1.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.hSmartWindowControl1.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hSmartWindowControl1.HKeepAspectRatio = true;
            this.hSmartWindowControl1.HMoveContent = true;
            this.hSmartWindowControl1.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.hSmartWindowControl1.Location = new System.Drawing.Point(257, 132);
            this.hSmartWindowControl1.Margin = new System.Windows.Forms.Padding(0);
            this.hSmartWindowControl1.Name = "hSmartWindowControl1";
            this.hSmartWindowControl1.Size = new System.Drawing.Size(221, 432);
            this.hSmartWindowControl1.TabIndex = 0;
            this.hSmartWindowControl1.WindowSize = new System.Drawing.Size(221, 432);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 20F);
            this.label11.Location = new System.Drawing.Point(127, 53);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(363, 27);
            this.label11.TabIndex = 2179;
            this.label11.Text = "多相流分相含率在线测量系统";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F);
            this.label12.Location = new System.Drawing.Point(347, 111);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 16);
            this.label12.TabIndex = 2180;
            this.label12.Text = "分离器";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LblLevel);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.LblPressure);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.LblTemp);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(59, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(115, 377);
            this.groupBox3.TabIndex = 2128;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "分离器参数";
            // 
            // LblLevel
            // 
            this.LblLevel.AutoSize = true;
            this.LblLevel.BackColor = System.Drawing.Color.Yellow;
            this.LblLevel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblLevel.Location = new System.Drawing.Point(13, 242);
            this.LblLevel.Name = "LblLevel";
            this.LblLevel.Size = new System.Drawing.Size(39, 16);
            this.LblLevel.TabIndex = 43;
            this.LblLevel.Text = "####";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(10, 191);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 16);
            this.label17.TabIndex = 42;
            this.label17.Text = "液位：";
            // 
            // LblPressure
            // 
            this.LblPressure.AutoSize = true;
            this.LblPressure.BackColor = System.Drawing.Color.Yellow;
            this.LblPressure.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblPressure.Location = new System.Drawing.Point(13, 158);
            this.LblPressure.Name = "LblPressure";
            this.LblPressure.Size = new System.Drawing.Size(39, 16);
            this.LblPressure.TabIndex = 41;
            this.LblPressure.Text = "####";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(10, 111);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 16);
            this.label21.TabIndex = 40;
            this.label21.Text = "压力：";
            // 
            // LblTemp
            // 
            this.LblTemp.AutoSize = true;
            this.LblTemp.BackColor = System.Drawing.Color.Yellow;
            this.LblTemp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTemp.Location = new System.Drawing.Point(13, 74);
            this.LblTemp.Name = "LblTemp";
            this.LblTemp.Size = new System.Drawing.Size(39, 16);
            this.LblTemp.TabIndex = 3;
            this.LblTemp.Text = "####";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.SystemColors.Control;
            this.label33.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(10, 37);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(55, 16);
            this.label33.TabIndex = 0;
            this.label33.Text = "温度：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 306);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 33);
            this.button1.TabIndex = 2181;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(509, 374);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 33);
            this.button2.TabIndex = 2182;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 682);
            this.Controls.Add(this.hSmartWindowControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.ByPassValue);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.OutGasConduit2);
            this.Controls.Add(this.OutLiquidValue);
            this.Controls.Add(this.OutLiquidConduit1);
            this.Controls.Add(this.OutGasConduit3);
            this.Controls.Add(this.OutLiquidConduit2);
            this.Controls.Add(this.OutGasValue);
            this.Controls.Add(this.OutGasConduit1);
            this.Controls.Add(this.InLiquidConduit3);
            this.Controls.Add(this.InLiquidValue);
            this.Controls.Add(this.InLiquidConduit2);
            this.Controls.Add(this.ByPassConduit1);
            this.Controls.Add(this.InLiquidConduit1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MnsMain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OutLiquidConduit3);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "多相流分相含率在线测量系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.CmsChangeState.ResumeLayout(false);
            this.MnsMain.ResumeLayout(false);
            this.MnsMain.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListView lstMessage;
        public System.Windows.Forms.ColumnHeader ColumnHeader1;
        public System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.IO.Ports.SerialPort serialPortScaner;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ContextMenuStrip CmsChangeState;
        public System.Windows.Forms.ToolStripMenuItem AddBarcode;
        public System.Windows.Forms.ToolStripMenuItem DeleteBarcode;
        public System.Windows.Forms.ToolStripMenuItem ChangeState;
        public System.Windows.Forms.ToolStripMenuItem ToEmergency;
        public System.Windows.Forms.ToolStripMenuItem ToComon;
        public System.Windows.Forms.ToolStripMenuItem ToNonEmergency;
        private System.Windows.Forms.ToolStripMenuItem WhLocking;
        private System.Windows.Forms.ToolStripMenuItem WhUnlock;
        public System.Windows.Forms.MenuStrip MnsMain;
        public System.Windows.Forms.ToolStripMenuItem PressureCurveTSMI;
        public System.Windows.Forms.ToolStripMenuItem LoginTSMI;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button BtnCreatConnect;
        public System.Windows.Forms.Button BtnAlarmReset;
        public System.Windows.Forms.Button BtnPause;
        public System.Windows.Forms.Label label25;
        private System.Windows.Forms.Timer TmrRefresh;
        private System.Windows.Forms.ToolStripMenuItem TorqueCurveTSMI;
        private HZH_Controls.Controls.UCValve ByPassValue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private HZH_Controls.Controls.UCConduit OutGasConduit2;
        private HZH_Controls.Controls.UCValve OutLiquidValue;
        private HZH_Controls.Controls.UCConduit OutLiquidConduit1;
        private HZH_Controls.Controls.UCConduit OutGasConduit3;
        private HZH_Controls.Controls.UCConduit OutLiquidConduit2;
        private HZH_Controls.Controls.UCValve OutGasValue;
        private HZH_Controls.Controls.UCConduit OutLiquidConduit3;
        private HZH_Controls.Controls.UCConduit OutGasConduit1;
        private HZH_Controls.Controls.UCConduit InLiquidConduit3;
        private HZH_Controls.Controls.UCValve InLiquidValue;
        private HZH_Controls.Controls.UCConduit InLiquidConduit2;
        private HZH_Controls.Controls.UCConduit ByPassConduit1;
        private HZH_Controls.Controls.UCConduit InLiquidConduit1;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label LblPLCState;
        public System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label LblCameraState;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label LblSensorState;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem TempCurveTSMI;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label LblLevel;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label LblPressure;
        public System.Windows.Forms.Label label21;
        public System.Windows.Forms.Label LblTemp;
        public System.Windows.Forms.Label label33;
        private System.Windows.Forms.ToolStripMenuItem CameraSetTSMI;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public HalconDotNet.HSmartWindowControl hSmartWindowControl1;
        private System.Windows.Forms.ToolStripMenuItem ValueSetTSMI;
    }
}


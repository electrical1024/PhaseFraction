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
            this.ucValve1 = new HZH_Controls.Controls.UCValve();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ucConduit10 = new HZH_Controls.Controls.UCConduit();
            this.ucValve4 = new HZH_Controls.Controls.UCValve();
            this.ucConduit4 = new HZH_Controls.Controls.UCConduit();
            this.ucConduit7 = new HZH_Controls.Controls.UCConduit();
            this.ucConduit8 = new HZH_Controls.Controls.UCConduit();
            this.ucValve3 = new HZH_Controls.Controls.UCValve();
            this.ucConduit9 = new HZH_Controls.Controls.UCConduit();
            this.ucConduit6 = new HZH_Controls.Controls.UCConduit();
            this.ucConduit5 = new HZH_Controls.Controls.UCConduit();
            this.ucValve2 = new HZH_Controls.Controls.UCValve();
            this.ucConduit3 = new HZH_Controls.Controls.UCConduit();
            this.ucConduit2 = new HZH_Controls.Controls.UCConduit();
            this.ucConduit1 = new HZH_Controls.Controls.UCConduit();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LblSensorState = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.LblCameraState = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.LblPLCState = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hSmartWindowControl1 = new HalconDotNet.HSmartWindowControl();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.CmsChangeState.SuspendLayout();
            this.MnsMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMessage
            // 
            this.lstMessage.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lstMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lstMessage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMessage.GridLines = true;
            this.lstMessage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstMessage.HideSelection = false;
            this.lstMessage.Location = new System.Drawing.Point(18, 31);
            this.lstMessage.Margin = new System.Windows.Forms.Padding(4);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(387, 388);
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
            this.groupBox1.Location = new System.Drawing.Point(1140, 400);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(429, 432);
            this.groupBox1.TabIndex = 2110;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运行记录";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label25.Location = new System.Drawing.Point(2480, 0);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(43, 25);
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
            this.CmsChangeState.Size = new System.Drawing.Size(165, 114);
            // 
            // AddBarcode
            // 
            this.AddBarcode.Name = "AddBarcode";
            this.AddBarcode.Size = new System.Drawing.Size(164, 22);
            this.AddBarcode.Text = "添加";
            this.AddBarcode.Click += new System.EventHandler(this.AddBarcode_Click);
            // 
            // DeleteBarcode
            // 
            this.DeleteBarcode.Name = "DeleteBarcode";
            this.DeleteBarcode.Size = new System.Drawing.Size(164, 22);
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
            this.ChangeState.Size = new System.Drawing.Size(164, 22);
            this.ChangeState.Text = "改變倉庫狀態";
            this.ChangeState.Visible = false;
            // 
            // ToEmergency
            // 
            this.ToEmergency.Name = "ToEmergency";
            this.ToEmergency.Size = new System.Drawing.Size(163, 26);
            this.ToEmergency.Text = "轉為緊急";
            // 
            // ToComon
            // 
            this.ToComon.Name = "ToComon";
            this.ToComon.Size = new System.Drawing.Size(163, 26);
            this.ToComon.Text = "轉為一般";
            // 
            // ToNonEmergency
            // 
            this.ToNonEmergency.Name = "ToNonEmergency";
            this.ToNonEmergency.Size = new System.Drawing.Size(163, 26);
            this.ToNonEmergency.Text = "轉為非緊急";
            this.ToNonEmergency.Visible = false;
            // 
            // WhLocking
            // 
            this.WhLocking.Name = "WhLocking";
            this.WhLocking.Size = new System.Drawing.Size(164, 22);
            this.WhLocking.Text = "鎖定";
            this.WhLocking.Visible = false;
            // 
            // WhUnlock
            // 
            this.WhUnlock.Name = "WhUnlock";
            this.WhUnlock.Size = new System.Drawing.Size(164, 22);
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
            this.TempCurveTSMI,
            this.PressureCurveTSMI,
            this.TorqueCurveTSMI,
            this.LoginTSMI});
            this.MnsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MnsMain.Location = new System.Drawing.Point(0, 0);
            this.MnsMain.Name = "MnsMain";
            this.MnsMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MnsMain.Size = new System.Drawing.Size(1582, 54);
            this.MnsMain.TabIndex = 2111;
            this.MnsMain.Text = "MenuStrip1";
            // 
            // CameraSetTSMI
            // 
            this.CameraSetTSMI.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CameraSetTSMI.Name = "CameraSetTSMI";
            this.CameraSetTSMI.Size = new System.Drawing.Size(120, 50);
            this.CameraSetTSMI.Text = "相机设定";
            this.CameraSetTSMI.Click += new System.EventHandler(this.CameraSetTSMI_Click);
            // 
            // TempCurveTSMI
            // 
            this.TempCurveTSMI.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TempCurveTSMI.Name = "TempCurveTSMI";
            this.TempCurveTSMI.Size = new System.Drawing.Size(120, 50);
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
            this.PressureCurveTSMI.Size = new System.Drawing.Size(120, 50);
            this.PressureCurveTSMI.Text = "压力曲线";
            this.PressureCurveTSMI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PressureCurveTSMI.Visible = false;
            this.PressureCurveTSMI.Click += new System.EventHandler(this.PressureCurveTSMI_Click);
            // 
            // TorqueCurveTSMI
            // 
            this.TorqueCurveTSMI.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TorqueCurveTSMI.Name = "TorqueCurveTSMI";
            this.TorqueCurveTSMI.Size = new System.Drawing.Size(120, 50);
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
            this.LoginTSMI.Size = new System.Drawing.Size(127, 50);
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
            this.groupBox2.Location = new System.Drawing.Point(1140, 253);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(429, 135);
            this.groupBox2.TabIndex = 2112;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本操作";
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStart.Location = new System.Drawing.Point(11, 82);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(4);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(177, 38);
            this.BtnStart.TabIndex = 38;
            this.BtnStart.Text = "开始测量";
            this.BtnStart.UseVisualStyleBackColor = true;
            // 
            // BtnCreatConnect
            // 
            this.BtnCreatConnect.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCreatConnect.Location = new System.Drawing.Point(11, 36);
            this.BtnCreatConnect.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCreatConnect.Name = "BtnCreatConnect";
            this.BtnCreatConnect.Size = new System.Drawing.Size(177, 38);
            this.BtnCreatConnect.TabIndex = 37;
            this.BtnCreatConnect.Text = "建立通讯";
            this.BtnCreatConnect.UseVisualStyleBackColor = true;
            this.BtnCreatConnect.Click += new System.EventHandler(this.BtnCreatConnect_Click);
            // 
            // BtnAlarmReset
            // 
            this.BtnAlarmReset.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAlarmReset.Location = new System.Drawing.Point(228, 36);
            this.BtnAlarmReset.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAlarmReset.Name = "BtnAlarmReset";
            this.BtnAlarmReset.Size = new System.Drawing.Size(177, 38);
            this.BtnAlarmReset.TabIndex = 31;
            this.BtnAlarmReset.Text = "报警复位";
            this.BtnAlarmReset.UseVisualStyleBackColor = true;
            this.BtnAlarmReset.Click += new System.EventHandler(this.BtnAlarmReset_Click);
            // 
            // BtnPause
            // 
            this.BtnPause.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnPause.Location = new System.Drawing.Point(228, 82);
            this.BtnPause.Margin = new System.Windows.Forms.Padding(4);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(177, 38);
            this.BtnPause.TabIndex = 34;
            this.BtnPause.Text = "停止测量";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // TmrRefresh
            // 
            this.TmrRefresh.Interval = 200;
            this.TmrRefresh.Tick += new System.EventHandler(this.m);
            // 
            // ucValve1
            // 
            this.ucValve1.AsisBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve1.AxisColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve1.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve1.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucValve1.LiquidSpeed = 100;
            this.ucValve1.Location = new System.Drawing.Point(502, 759);
            this.ucValve1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucValve1.Name = "ucValve1";
            this.ucValve1.Opened = true;
            this.ucValve1.Size = new System.Drawing.Size(115, 80);
            this.ucValve1.SwitchColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucValve1.TabIndex = 2159;
            this.ucValve1.ValveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucValve1.ValveStyle = HZH_Controls.Controls.ValveStyle.Horizontal_Top;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F);
            this.label13.Location = new System.Drawing.Point(526, 739);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 20);
            this.label13.TabIndex = 2175;
            this.label13.Text = "电动阀4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.Location = new System.Drawing.Point(110, 715);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 2174;
            this.label9.Text = "电动阀2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(808, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 2173;
            this.label8.Text = "电动阀1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(827, 685);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 2158;
            this.label7.Text = "电动阀3";
            // 
            // ucConduit10
            // 
            this.ucConduit10.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit10.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Horizontal_None_None;
            this.ucConduit10.ConduitWidth = 50;
            this.ucConduit10.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit10.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit10.LiquidSpeed = 100;
            this.ucConduit10.Location = new System.Drawing.Point(736, 87);
            this.ucConduit10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucConduit10.Name = "ucConduit10";
            this.ucConduit10.Size = new System.Drawing.Size(225, 29);
            this.ucConduit10.TabIndex = 2172;
            // 
            // ucValve4
            // 
            this.ucValve4.AsisBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve4.AxisColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve4.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve4.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucValve4.LiquidSpeed = 100;
            this.ucValve4.Location = new System.Drawing.Point(798, 711);
            this.ucValve4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucValve4.Name = "ucValve4";
            this.ucValve4.Opened = true;
            this.ucValve4.Size = new System.Drawing.Size(120, 80);
            this.ucValve4.SwitchColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucValve4.TabIndex = 2171;
            this.ucValve4.ValveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucValve4.ValveStyle = HZH_Controls.Controls.ValveStyle.Horizontal_Top;
            // 
            // ucConduit4
            // 
            this.ucConduit4.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit4.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_None_Right;
            this.ucConduit4.ConduitWidth = 50;
            this.ucConduit4.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit4.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit4.LiquidSpeed = 100;
            this.ucConduit4.Location = new System.Drawing.Point(672, 702);
            this.ucConduit4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucConduit4.Name = "ucConduit4";
            this.ucConduit4.Size = new System.Drawing.Size(29, 79);
            this.ucConduit4.TabIndex = 2170;
            // 
            // ucConduit7
            // 
            this.ucConduit7.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit7.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_Left_None;
            this.ucConduit7.ConduitWidth = 50;
            this.ucConduit7.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit7.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit7.LiquidSpeed = 100;
            this.ucConduit7.Location = new System.Drawing.Point(960, 84);
            this.ucConduit7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucConduit7.Name = "ucConduit7";
            this.ucConduit7.Size = new System.Drawing.Size(21, 672);
            this.ucConduit7.TabIndex = 2167;
            // 
            // ucConduit8
            // 
            this.ucConduit8.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit8.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Horizontal_None_Down;
            this.ucConduit8.ConduitWidth = 50;
            this.ucConduit8.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit8.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit8.LiquidSpeed = 100;
            this.ucConduit8.Location = new System.Drawing.Point(696, 751);
            this.ucConduit8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucConduit8.Name = "ucConduit8";
            this.ucConduit8.Size = new System.Drawing.Size(337, 30);
            this.ucConduit8.TabIndex = 2169;
            // 
            // ucValve3
            // 
            this.ucValve3.AsisBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve3.AxisColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve3.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve3.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucValve3.LiquidSpeed = 100;
            this.ucValve3.Location = new System.Drawing.Point(808, 60);
            this.ucValve3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucValve3.Name = "ucValve3";
            this.ucValve3.Opened = true;
            this.ucValve3.Size = new System.Drawing.Size(79, 58);
            this.ucValve3.SwitchColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucValve3.TabIndex = 2166;
            this.ucValve3.ValveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucValve3.ValveStyle = HZH_Controls.Controls.ValveStyle.Horizontal_Top;
            // 
            // ucConduit9
            // 
            this.ucConduit9.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit9.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_None_None;
            this.ucConduit9.ConduitWidth = 50;
            this.ucConduit9.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit9.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit9.LiquidSpeed = 100;
            this.ucConduit9.Location = new System.Drawing.Point(1004, 776);
            this.ucConduit9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucConduit9.Name = "ucConduit9";
            this.ucConduit9.Size = new System.Drawing.Size(29, 37);
            this.ucConduit9.TabIndex = 2168;
            // 
            // ucConduit6
            // 
            this.ucConduit6.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit6.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_Right_None;
            this.ucConduit6.ConduitWidth = 50;
            this.ucConduit6.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit6.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit6.LiquidSpeed = 100;
            this.ucConduit6.Location = new System.Drawing.Point(716, 85);
            this.ucConduit6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucConduit6.Name = "ucConduit6";
            this.ucConduit6.Size = new System.Drawing.Size(25, 80);
            this.ucConduit6.TabIndex = 2165;
            // 
            // ucConduit5
            // 
            this.ucConduit5.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit5.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_None_None;
            this.ucConduit5.ConduitWidth = 50;
            this.ucConduit5.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit5.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit5.LiquidSpeed = 100;
            this.ucConduit5.Location = new System.Drawing.Point(404, 702);
            this.ucConduit5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucConduit5.Name = "ucConduit5";
            this.ucConduit5.Size = new System.Drawing.Size(29, 44);
            this.ucConduit5.TabIndex = 2164;
            // 
            // ucValve2
            // 
            this.ucValve2.AsisBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve2.AxisColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve2.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucValve2.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucValve2.LiquidSpeed = 100;
            this.ucValve2.Location = new System.Drawing.Point(183, 702);
            this.ucValve2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucValve2.Name = "ucValve2";
            this.ucValve2.Opened = true;
            this.ucValve2.Size = new System.Drawing.Size(120, 80);
            this.ucValve2.SwitchColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucValve2.TabIndex = 2163;
            this.ucValve2.ValveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucValve2.ValveStyle = HZH_Controls.Controls.ValveStyle.Horizontal_Top;
            // 
            // ucConduit3
            // 
            this.ucConduit3.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit3.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Horizontal_None_Up;
            this.ucConduit3.ConduitWidth = 50;
            this.ucConduit3.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit3.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit3.LiquidSpeed = 100;
            this.ucConduit3.Location = new System.Drawing.Point(96, 742);
            this.ucConduit3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucConduit3.Name = "ucConduit3";
            this.ucConduit3.Size = new System.Drawing.Size(337, 30);
            this.ucConduit3.TabIndex = 2162;
            // 
            // ucConduit2
            // 
            this.ucConduit2.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit2.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Horizontal_None_None;
            this.ucConduit2.ConduitWidth = 100;
            this.ucConduit2.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit2.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit2.LiquidSpeed = 100;
            this.ucConduit2.Location = new System.Drawing.Point(24, 799);
            this.ucConduit2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucConduit2.Name = "ucConduit2";
            this.ucConduit2.Size = new System.Drawing.Size(1068, 30);
            this.ucConduit2.TabIndex = 2161;
            // 
            // ucConduit1
            // 
            this.ucConduit1.ConduitColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucConduit1.ConduitStyle = HZH_Controls.Controls.ConduitStyle.Vertical_Right_None;
            this.ucConduit1.ConduitWidth = 50;
            this.ucConduit1.LiquidColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(243)))));
            this.ucConduit1.LiquidDirection = HZH_Controls.Controls.LiquidDirection.Forward;
            this.ucConduit1.LiquidSpeed = 100;
            this.ucConduit1.Location = new System.Drawing.Point(70, 741);
            this.ucConduit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucConduit1.Name = "ucConduit1";
            this.ucConduit1.Size = new System.Drawing.Size(29, 72);
            this.ucConduit1.TabIndex = 2160;
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
            this.groupBox4.Location = new System.Drawing.Point(1140, 66);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(429, 179);
            this.groupBox4.TabIndex = 2127;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "设备状态显示";
            // 
            // LblSensorState
            // 
            this.LblSensorState.AutoSize = true;
            this.LblSensorState.BackColor = System.Drawing.Color.Pink;
            this.LblSensorState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblSensorState.Location = new System.Drawing.Point(224, 106);
            this.LblSensorState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblSensorState.Name = "LblSensorState";
            this.LblSensorState.Size = new System.Drawing.Size(69, 20);
            this.LblSensorState.TabIndex = 43;
            this.LblSensorState.Text = "未连接";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(13, 106);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(169, 20);
            this.label16.TabIndex = 42;
            this.label16.Text = "传感器连接状态：";
            // 
            // LblCameraState
            // 
            this.LblCameraState.AutoSize = true;
            this.LblCameraState.BackColor = System.Drawing.Color.Pink;
            this.LblCameraState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblCameraState.Location = new System.Drawing.Point(225, 72);
            this.LblCameraState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCameraState.Name = "LblCameraState";
            this.LblCameraState.Size = new System.Drawing.Size(69, 20);
            this.LblCameraState.TabIndex = 41;
            this.LblCameraState.Text = "未连接";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(33, 72);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(149, 20);
            this.label14.TabIndex = 40;
            this.label14.Text = "相机连接状态：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(73, 140);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 20);
            this.label19.TabIndex = 39;
            this.label19.Text = "报警状态：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.LightGreen;
            this.label20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(224, 140);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(109, 20);
            this.label20.TabIndex = 38;
            this.label20.Text = "未发生报警";
            // 
            // LblPLCState
            // 
            this.LblPLCState.AutoSize = true;
            this.LblPLCState.BackColor = System.Drawing.Color.Pink;
            this.LblPLCState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblPLCState.Location = new System.Drawing.Point(224, 38);
            this.LblPLCState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPLCState.Name = "LblPLCState";
            this.LblPLCState.Size = new System.Drawing.Size(69, 20);
            this.LblPLCState.TabIndex = 3;
            this.LblPLCState.Text = "未连接";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(43, 38);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(139, 20);
            this.label24.TabIndex = 0;
            this.label24.Text = "PLC连接状态：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hSmartWindowControl1);
            this.panel1.Location = new System.Drawing.Point(70, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 540);
            this.panel1.TabIndex = 2178;
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
            this.hSmartWindowControl1.Location = new System.Drawing.Point(0, 0);
            this.hSmartWindowControl1.Margin = new System.Windows.Forms.Padding(0);
            this.hSmartWindowControl1.Name = "hSmartWindowControl1";
            this.hSmartWindowControl1.Size = new System.Drawing.Size(689, 540);
            this.hSmartWindowControl1.TabIndex = 0;
            this.hSmartWindowControl1.WindowSize = new System.Drawing.Size(689, 540);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 20F);
            this.label11.Location = new System.Drawing.Point(90, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(457, 34);
            this.label11.TabIndex = 2179;
            this.label11.Text = "多相流分相含率在线测量系统";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F);
            this.label12.Location = new System.Drawing.Point(76, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 2180;
            this.label12.Text = "分离器";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(786, 238);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(132, 362);
            this.groupBox3.TabIndex = 2128;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "分离器参数";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Yellow;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(17, 302);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 20);
            this.label15.TabIndex = 43;
            this.label15.Text = "####";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(13, 239);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 20);
            this.label17.TabIndex = 42;
            this.label17.Text = "液位：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Yellow;
            this.label18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(17, 198);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 20);
            this.label18.TabIndex = 41;
            this.label18.Text = "####";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(13, 139);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 20);
            this.label21.TabIndex = 40;
            this.label21.Text = "压力：";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Yellow;
            this.label31.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(17, 92);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(49, 20);
            this.label31.TabIndex = 3;
            this.label31.Text = "####";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.SystemColors.Control;
            this.label33.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(13, 46);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(69, 20);
            this.label33.TabIndex = 0;
            this.label33.Text = "温度：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1004, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 41);
            this.button1.TabIndex = 2181;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1004, 477);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 41);
            this.button2.TabIndex = 2182;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.ucValve1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ucConduit10);
            this.Controls.Add(this.ucValve4);
            this.Controls.Add(this.ucConduit4);
            this.Controls.Add(this.ucConduit7);
            this.Controls.Add(this.ucConduit8);
            this.Controls.Add(this.ucValve3);
            this.Controls.Add(this.ucConduit9);
            this.Controls.Add(this.ucConduit6);
            this.Controls.Add(this.ucConduit5);
            this.Controls.Add(this.ucValve2);
            this.Controls.Add(this.ucConduit3);
            this.Controls.Add(this.ucConduit2);
            this.Controls.Add(this.ucConduit1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MnsMain);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
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
            this.panel1.ResumeLayout(false);
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
        private HZH_Controls.Controls.UCValve ucValve1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private HZH_Controls.Controls.UCConduit ucConduit10;
        private HZH_Controls.Controls.UCValve ucValve4;
        private HZH_Controls.Controls.UCConduit ucConduit4;
        private HZH_Controls.Controls.UCConduit ucConduit7;
        private HZH_Controls.Controls.UCConduit ucConduit8;
        private HZH_Controls.Controls.UCValve ucValve3;
        private HZH_Controls.Controls.UCConduit ucConduit9;
        private HZH_Controls.Controls.UCConduit ucConduit6;
        private HZH_Controls.Controls.UCConduit ucConduit5;
        private HZH_Controls.Controls.UCValve ucValve2;
        private HZH_Controls.Controls.UCConduit ucConduit3;
        private HZH_Controls.Controls.UCConduit ucConduit2;
        private HZH_Controls.Controls.UCConduit ucConduit1;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label LblPLCState;
        public System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label LblCameraState;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label LblSensorState;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem TempCurveTSMI;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label label18;
        public System.Windows.Forms.Label label21;
        public System.Windows.Forms.Label label31;
        public System.Windows.Forms.Label label33;
        private System.Windows.Forms.ToolStripMenuItem CameraSetTSMI;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public HalconDotNet.HSmartWindowControl hSmartWindowControl1;
    }
}


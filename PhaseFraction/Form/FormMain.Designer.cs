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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.PressureCurveTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.TorqueCurveTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnCreatConnect = new System.Windows.Forms.Button();
            this.BtnHome = new System.Windows.Forms.Button();
            this.BtnAlarmReset = new System.Windows.Forms.Button();
            this.BtnPause = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.TxtManualSpeed = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.TxtCurCoord = new System.Windows.Forms.TextBox();
            this.BtnForewardRun = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnReverseRun = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtLocationInitSpeed = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtLocationCoord = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtLocationSpeed = new System.Windows.Forms.TextBox();
            this.BtnLocationRun = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.TxtBackInitSpeed = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtBackCoord = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtBackSpeed = new System.Windows.Forms.TextBox();
            this.BtnBackRun = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label46 = new System.Windows.Forms.Label();
            this.TxtAccPressCycle = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.TxtAccPressLimit = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.TxtAccDestSpeed = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TxtAccValue = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TxtAccCurSpeed = new System.Windows.Forms.TextBox();
            this.BtnAccRun = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.TxtDecPressCycle = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.TxtDecPressLimit = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TxtDecDestSpeed = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TxtDecValue = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TxtDecCurSpeed = new System.Windows.Forms.TextBox();
            this.BtnDecRun = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LblCheckPressure = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.LblDecRun = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.LblAccRun = new System.Windows.Forms.Label();
            this.LblNlimit = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblPlimit = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.LblEmergAlarm = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.LblServoAlarm = new System.Windows.Forms.Label();
            this.LblDAMConnState = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblBackRun = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblLocationRun = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblPLCAlarm = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LblOriginState = new System.Windows.Forms.Label();
            this.LblPLCConnState = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.TmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.CmsChangeState.SuspendLayout();
            this.MnsMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
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
            this.lstMessage.Location = new System.Drawing.Point(8, 36);
            this.lstMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(2556, 388);
            this.lstMessage.TabIndex = 1653;
            this.lstMessage.UseCompatibleStateImageBehavior = false;
            this.lstMessage.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "时间";
            this.ColumnHeader1.Width = 200;
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
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lstMessage);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(16, 730);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(2573, 432);
            this.groupBox1.TabIndex = 2110;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运行记录";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(516, 95);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(289, 68);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(516, 184);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(289, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
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
            this.PressureCurveTSMI,
            this.LoginTSMI,
            this.TorqueCurveTSMI});
            this.MnsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MnsMain.Location = new System.Drawing.Point(0, 0);
            this.MnsMain.Name = "MnsMain";
            this.MnsMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MnsMain.Size = new System.Drawing.Size(1582, 54);
            this.MnsMain.TabIndex = 2111;
            this.MnsMain.Text = "MenuStrip1";
            // 
            // PressureCurveTSMI
            // 
            this.PressureCurveTSMI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PressureCurveTSMI.Enabled = false;
            this.PressureCurveTSMI.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PressureCurveTSMI.Image = ((System.Drawing.Image)(resources.GetObject("PressureCurveTSMI.Image")));
            this.PressureCurveTSMI.Name = "PressureCurveTSMI";
            this.PressureCurveTSMI.Size = new System.Drawing.Size(120, 50);
            this.PressureCurveTSMI.Text = "压力曲线";
            this.PressureCurveTSMI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PressureCurveTSMI.Click += new System.EventHandler(this.PressureCurveTSMI_Click);
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
            // TorqueCurveTSMI
            // 
            this.TorqueCurveTSMI.Enabled = false;
            this.TorqueCurveTSMI.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TorqueCurveTSMI.Name = "TorqueCurveTSMI";
            this.TorqueCurveTSMI.Size = new System.Drawing.Size(120, 50);
            this.TorqueCurveTSMI.Text = "扭矩曲线";
            this.TorqueCurveTSMI.Click += new System.EventHandler(this.TorqueCurveTSMI_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnCreatConnect);
            this.groupBox2.Controls.Add(this.BtnHome);
            this.groupBox2.Controls.Add(this.BtnAlarmReset);
            this.groupBox2.Controls.Add(this.BtnPause);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(16, 58);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1084, 186);
            this.groupBox2.TabIndex = 2112;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本操作";
            // 
            // BtnCreatConnect
            // 
            this.BtnCreatConnect.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCreatConnect.Location = new System.Drawing.Point(11, 36);
            this.BtnCreatConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnCreatConnect.Name = "BtnCreatConnect";
            this.BtnCreatConnect.Size = new System.Drawing.Size(177, 38);
            this.BtnCreatConnect.TabIndex = 37;
            this.BtnCreatConnect.Text = "建立通讯";
            this.BtnCreatConnect.UseVisualStyleBackColor = true;
            this.BtnCreatConnect.Click += new System.EventHandler(this.BtnCreatConnect_Click);
            this.BtnCreatConnect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnCreatConnect_MouseDown);
            this.BtnCreatConnect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnCreatConnect_MouseUp);
            // 
            // BtnHome
            // 
            this.BtnHome.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnHome.Location = new System.Drawing.Point(8, 116);
            this.BtnHome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Size = new System.Drawing.Size(177, 38);
            this.BtnHome.TabIndex = 28;
            this.BtnHome.Text = "原点复归";
            this.BtnHome.UseVisualStyleBackColor = true;
            this.BtnHome.Click += new System.EventHandler(this.BtnHome_Click);
            this.BtnHome.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnHome_MouseDown);
            this.BtnHome.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnHome_MouseUp);
            // 
            // BtnAlarmReset
            // 
            this.BtnAlarmReset.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAlarmReset.Location = new System.Drawing.Point(827, 115);
            this.BtnAlarmReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAlarmReset.Name = "BtnAlarmReset";
            this.BtnAlarmReset.Size = new System.Drawing.Size(177, 38);
            this.BtnAlarmReset.TabIndex = 31;
            this.BtnAlarmReset.Text = "报警复位";
            this.BtnAlarmReset.UseVisualStyleBackColor = true;
            this.BtnAlarmReset.Click += new System.EventHandler(this.BtnAlarmReset_Click);
            this.BtnAlarmReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnAlarmReset_MouseDown);
            this.BtnAlarmReset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnAlarmReset_MouseUp);
            // 
            // BtnPause
            // 
            this.BtnPause.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnPause.Location = new System.Drawing.Point(827, 34);
            this.BtnPause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(177, 38);
            this.BtnPause.TabIndex = 34;
            this.BtnPause.Text = "停止";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            this.BtnPause.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnPause_MouseDown);
            this.BtnPause.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnPause_MouseUp);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label50);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.TxtManualSpeed);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.TxtCurCoord);
            this.groupBox4.Controls.Add(this.BtnForewardRun);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.BtnReverseRun);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(1129, 62);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(1067, 186);
            this.groupBox4.TabIndex = 2113;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "正反转运行";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.SystemColors.Control;
            this.label50.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label50.Location = new System.Drawing.Point(427, 61);
            this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(29, 20);
            this.label50.TabIndex = 2126;
            this.label50.Text = "mm";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.SystemColors.Control;
            this.label35.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(427, 130);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(49, 20);
            this.label35.TabIndex = 2125;
            this.label35.Text = "mm/s";
            // 
            // TxtManualSpeed
            // 
            this.TxtManualSpeed.Location = new System.Drawing.Point(204, 126);
            this.TxtManualSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtManualSpeed.Name = "TxtManualSpeed";
            this.TxtManualSpeed.Size = new System.Drawing.Size(197, 30);
            this.TxtManualSpeed.TabIndex = 2116;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(23, 129);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(109, 20);
            this.label24.TabIndex = 2115;
            this.label24.Text = "手动速度：";
            // 
            // TxtCurCoord
            // 
            this.TxtCurCoord.Enabled = false;
            this.TxtCurCoord.Location = new System.Drawing.Point(204, 59);
            this.TxtCurCoord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtCurCoord.Name = "TxtCurCoord";
            this.TxtCurCoord.Size = new System.Drawing.Size(197, 30);
            this.TxtCurCoord.TabIndex = 2114;
            // 
            // BtnForewardRun
            // 
            this.BtnForewardRun.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnForewardRun.Location = new System.Drawing.Point(819, 54);
            this.BtnForewardRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnForewardRun.Name = "BtnForewardRun";
            this.BtnForewardRun.Size = new System.Drawing.Size(171, 38);
            this.BtnForewardRun.TabIndex = 29;
            this.BtnForewardRun.Text = "正转运行";
            this.BtnForewardRun.UseVisualStyleBackColor = true;
            this.BtnForewardRun.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnForewardRun_MouseDown);
            this.BtnForewardRun.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnForewardRun_MouseUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(23, 61);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 20);
            this.label8.TabIndex = 2113;
            this.label8.Text = "当前坐标：";
            // 
            // BtnReverseRun
            // 
            this.BtnReverseRun.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnReverseRun.Location = new System.Drawing.Point(819, 121);
            this.BtnReverseRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnReverseRun.Name = "BtnReverseRun";
            this.BtnReverseRun.Size = new System.Drawing.Size(171, 38);
            this.BtnReverseRun.TabIndex = 30;
            this.BtnReverseRun.Text = "反转运行";
            this.BtnReverseRun.UseVisualStyleBackColor = true;
            this.BtnReverseRun.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnReverseRun_MouseDown);
            this.BtnReverseRun.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnReverseRun_MouseUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.TxtLocationInitSpeed);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.TxtLocationCoord);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.TxtLocationSpeed);
            this.groupBox3.Controls.Add(this.BtnLocationRun);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(16, 265);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(1084, 185);
            this.groupBox3.TabIndex = 2118;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "定位运行";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.SystemColors.Control;
            this.label33.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(1024, 42);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(49, 20);
            this.label33.TabIndex = 2123;
            this.label33.Text = "mm/s";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.SystemColors.Control;
            this.label31.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(437, 105);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(29, 20);
            this.label31.TabIndex = 2122;
            this.label31.Text = "mm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(437, 41);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 2121;
            this.label7.Text = "mm/s";
            // 
            // TxtLocationInitSpeed
            // 
            this.TxtLocationInitSpeed.Location = new System.Drawing.Point(827, 36);
            this.TxtLocationInitSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtLocationInitSpeed.Name = "TxtLocationInitSpeed";
            this.TxtLocationInitSpeed.Size = new System.Drawing.Size(176, 30);
            this.TxtLocationInitSpeed.TabIndex = 2120;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(600, 42);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 20);
            this.label9.TabIndex = 2119;
            this.label9.Text = "定位初始速度：";
            // 
            // TxtLocationCoord
            // 
            this.TxtLocationCoord.Location = new System.Drawing.Point(235, 100);
            this.TxtLocationCoord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtLocationCoord.Name = "TxtLocationCoord";
            this.TxtLocationCoord.Size = new System.Drawing.Size(181, 30);
            this.TxtLocationCoord.TabIndex = 2118;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(21, 101);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 20);
            this.label12.TabIndex = 2117;
            this.label12.Text = "定位坐标：";
            // 
            // TxtLocationSpeed
            // 
            this.TxtLocationSpeed.Location = new System.Drawing.Point(236, 39);
            this.TxtLocationSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtLocationSpeed.Name = "TxtLocationSpeed";
            this.TxtLocationSpeed.Size = new System.Drawing.Size(180, 30);
            this.TxtLocationSpeed.TabIndex = 2114;
            // 
            // BtnLocationRun
            // 
            this.BtnLocationRun.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnLocationRun.Location = new System.Drawing.Point(827, 108);
            this.BtnLocationRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnLocationRun.Name = "BtnLocationRun";
            this.BtnLocationRun.Size = new System.Drawing.Size(177, 38);
            this.BtnLocationRun.TabIndex = 29;
            this.BtnLocationRun.Text = "定位运行";
            this.BtnLocationRun.UseVisualStyleBackColor = true;
            this.BtnLocationRun.Click += new System.EventHandler(this.BtnLocationRun_Click);
            this.BtnLocationRun.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnLocationRun_MouseDown);
            this.BtnLocationRun.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnLocationRun_MouseUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(23, 40);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 20);
            this.label11.TabIndex = 2113;
            this.label11.Text = "定位速度：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label41);
            this.groupBox5.Controls.Add(this.label40);
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Controls.Add(this.TxtBackInitSpeed);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.TxtBackCoord);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.TxtBackSpeed);
            this.groupBox5.Controls.Add(this.BtnBackRun);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(1129, 265);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(1067, 190);
            this.groupBox5.TabIndex = 2122;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "折返运动";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.SystemColors.Control;
            this.label41.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.Location = new System.Drawing.Point(427, 105);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(29, 20);
            this.label41.TabIndex = 2124;
            this.label41.Text = "mm";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.SystemColors.Control;
            this.label40.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(1007, 42);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(49, 20);
            this.label40.TabIndex = 2125;
            this.label40.Text = "mm/s";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.SystemColors.Control;
            this.label34.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(427, 41);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(49, 20);
            this.label34.TabIndex = 2124;
            this.label34.Text = "mm/s";
            // 
            // TxtBackInitSpeed
            // 
            this.TxtBackInitSpeed.Location = new System.Drawing.Point(819, 38);
            this.TxtBackInitSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtBackInitSpeed.Name = "TxtBackInitSpeed";
            this.TxtBackInitSpeed.Size = new System.Drawing.Size(169, 30);
            this.TxtBackInitSpeed.TabIndex = 2120;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(587, 39);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(149, 20);
            this.label13.TabIndex = 2119;
            this.label13.Text = "折返初始速度：";
            // 
            // TxtBackCoord
            // 
            this.TxtBackCoord.Location = new System.Drawing.Point(204, 102);
            this.TxtBackCoord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtBackCoord.Name = "TxtBackCoord";
            this.TxtBackCoord.Size = new System.Drawing.Size(197, 30);
            this.TxtBackCoord.TabIndex = 2118;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(23, 105);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 20);
            this.label14.TabIndex = 2117;
            this.label14.Text = "折返坐标：";
            // 
            // TxtBackSpeed
            // 
            this.TxtBackSpeed.Location = new System.Drawing.Point(204, 36);
            this.TxtBackSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtBackSpeed.Name = "TxtBackSpeed";
            this.TxtBackSpeed.Size = new System.Drawing.Size(197, 30);
            this.TxtBackSpeed.TabIndex = 2114;
            // 
            // BtnBackRun
            // 
            this.BtnBackRun.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnBackRun.Location = new System.Drawing.Point(819, 98);
            this.BtnBackRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnBackRun.Name = "BtnBackRun";
            this.BtnBackRun.Size = new System.Drawing.Size(171, 38);
            this.BtnBackRun.TabIndex = 29;
            this.BtnBackRun.Text = "折返运行";
            this.BtnBackRun.UseVisualStyleBackColor = true;
            this.BtnBackRun.Click += new System.EventHandler(this.BtnBackRun_Click);
            this.BtnBackRun.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnBackRun_MouseDown);
            this.BtnBackRun.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnBackRun_MouseUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(23, 41);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 20);
            this.label15.TabIndex = 2113;
            this.label15.Text = "折返速度：";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label46);
            this.groupBox7.Controls.Add(this.TxtAccPressCycle);
            this.groupBox7.Controls.Add(this.label47);
            this.groupBox7.Controls.Add(this.label43);
            this.groupBox7.Controls.Add(this.label42);
            this.groupBox7.Controls.Add(this.label44);
            this.groupBox7.Controls.Add(this.TxtAccPressLimit);
            this.groupBox7.Controls.Add(this.label45);
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.TxtAccDestSpeed);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.TxtAccValue);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.TxtAccCurSpeed);
            this.groupBox7.Controls.Add(this.BtnAccRun);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox7.Location = new System.Drawing.Point(16, 476);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox7.Size = new System.Drawing.Size(1084, 246);
            this.groupBox7.TabIndex = 2123;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "恒加速运行";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.SystemColors.Control;
            this.label46.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label46.Location = new System.Drawing.Point(1036, 100);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(29, 20);
            this.label46.TabIndex = 2134;
            this.label46.Text = "ms";
            // 
            // TxtAccPressCycle
            // 
            this.TxtAccPressCycle.Location = new System.Drawing.Point(827, 96);
            this.TxtAccPressCycle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtAccPressCycle.Name = "TxtAccPressCycle";
            this.TxtAccPressCycle.Size = new System.Drawing.Size(176, 30);
            this.TxtAccPressCycle.TabIndex = 2133;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.BackColor = System.Drawing.SystemColors.Control;
            this.label47.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label47.Location = new System.Drawing.Point(600, 104);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(209, 20);
            this.label47.TabIndex = 2132;
            this.label47.Text = "恒加速压力采集周期：";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.SystemColors.Control;
            this.label43.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.Location = new System.Drawing.Point(437, 174);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(59, 20);
            this.label43.TabIndex = 2131;
            this.label43.Text = "mm/s2";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.SystemColors.Control;
            this.label42.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.Location = new System.Drawing.Point(1036, 40);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(19, 20);
            this.label42.TabIndex = 2129;
            this.label42.Text = "N";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.BackColor = System.Drawing.SystemColors.Control;
            this.label44.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.Location = new System.Drawing.Point(437, 108);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(49, 20);
            this.label44.TabIndex = 2130;
            this.label44.Text = "mm/s";
            // 
            // TxtAccPressLimit
            // 
            this.TxtAccPressLimit.Location = new System.Drawing.Point(827, 36);
            this.TxtAccPressLimit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtAccPressLimit.Name = "TxtAccPressLimit";
            this.TxtAccPressLimit.Size = new System.Drawing.Size(176, 30);
            this.TxtAccPressLimit.TabIndex = 2122;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.SystemColors.Control;
            this.label45.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label45.Location = new System.Drawing.Point(437, 42);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(49, 20);
            this.label45.TabIndex = 2129;
            this.label45.Text = "mm/s";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(600, 44);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(169, 20);
            this.label22.TabIndex = 2121;
            this.label22.Text = "恒加速压力限制：";
            // 
            // TxtAccDestSpeed
            // 
            this.TxtAccDestSpeed.Location = new System.Drawing.Point(233, 100);
            this.TxtAccDestSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtAccDestSpeed.Name = "TxtAccDestSpeed";
            this.TxtAccDestSpeed.Size = new System.Drawing.Size(183, 30);
            this.TxtAccDestSpeed.TabIndex = 2120;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(21, 106);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(169, 20);
            this.label19.TabIndex = 2119;
            this.label19.Text = "恒加速目标速度：";
            // 
            // TxtAccValue
            // 
            this.TxtAccValue.Location = new System.Drawing.Point(235, 170);
            this.TxtAccValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtAccValue.Name = "TxtAccValue";
            this.TxtAccValue.Size = new System.Drawing.Size(181, 30);
            this.TxtAccValue.TabIndex = 2118;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(23, 176);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(149, 20);
            this.label20.TabIndex = 2117;
            this.label20.Text = "恒加速加速度：";
            // 
            // TxtAccCurSpeed
            // 
            this.TxtAccCurSpeed.Enabled = false;
            this.TxtAccCurSpeed.Location = new System.Drawing.Point(235, 36);
            this.TxtAccCurSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtAccCurSpeed.Name = "TxtAccCurSpeed";
            this.TxtAccCurSpeed.Size = new System.Drawing.Size(181, 30);
            this.TxtAccCurSpeed.TabIndex = 2114;
            // 
            // BtnAccRun
            // 
            this.BtnAccRun.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAccRun.Location = new System.Drawing.Point(827, 159);
            this.BtnAccRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAccRun.Name = "BtnAccRun";
            this.BtnAccRun.Size = new System.Drawing.Size(177, 38);
            this.BtnAccRun.TabIndex = 29;
            this.BtnAccRun.Text = "加速运行";
            this.BtnAccRun.UseVisualStyleBackColor = true;
            this.BtnAccRun.Click += new System.EventHandler(this.BtnAccRun_Click);
            this.BtnAccRun.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnAccRun_MouseDown);
            this.BtnAccRun.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnAccRun_MouseUp);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(23, 42);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(169, 20);
            this.label21.TabIndex = 2113;
            this.label21.Text = "恒加速实时速度：";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label48);
            this.groupBox6.Controls.Add(this.label39);
            this.groupBox6.Controls.Add(this.TxtDecPressCycle);
            this.groupBox6.Controls.Add(this.label38);
            this.groupBox6.Controls.Add(this.label49);
            this.groupBox6.Controls.Add(this.label37);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.TxtDecPressLimit);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.TxtDecDestSpeed);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.TxtDecValue);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.TxtDecCurSpeed);
            this.groupBox6.Controls.Add(this.BtnDecRun);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox6.Location = new System.Drawing.Point(1129, 476);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Size = new System.Drawing.Size(1067, 246);
            this.groupBox6.TabIndex = 2124;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "恒减速运行";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.BackColor = System.Drawing.SystemColors.Control;
            this.label48.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label48.Location = new System.Drawing.Point(1007, 96);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(29, 20);
            this.label48.TabIndex = 2137;
            this.label48.Text = "ms";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.SystemColors.Control;
            this.label39.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.Location = new System.Drawing.Point(1007, 40);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(19, 20);
            this.label39.TabIndex = 2128;
            this.label39.Text = "N";
            // 
            // TxtDecPressCycle
            // 
            this.TxtDecPressCycle.Location = new System.Drawing.Point(817, 92);
            this.TxtDecPressCycle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtDecPressCycle.Name = "TxtDecPressCycle";
            this.TxtDecPressCycle.Size = new System.Drawing.Size(171, 30);
            this.TxtDecPressCycle.TabIndex = 2136;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.SystemColors.Control;
            this.label38.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.Location = new System.Drawing.Point(427, 174);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(59, 20);
            this.label38.TabIndex = 2127;
            this.label38.Text = "mm/s2";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.SystemColors.Control;
            this.label49.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label49.Location = new System.Drawing.Point(587, 101);
            this.label49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(209, 20);
            this.label49.TabIndex = 2135;
            this.label49.Text = "恒减速压力采集周期：";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.SystemColors.Control;
            this.label37.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.Location = new System.Drawing.Point(427, 108);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(49, 20);
            this.label37.TabIndex = 2126;
            this.label37.Text = "mm/s";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.SystemColors.Control;
            this.label36.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.Location = new System.Drawing.Point(427, 42);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(49, 20);
            this.label36.TabIndex = 2125;
            this.label36.Text = "mm/s";
            // 
            // TxtDecPressLimit
            // 
            this.TxtDecPressLimit.Location = new System.Drawing.Point(819, 35);
            this.TxtDecPressLimit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtDecPressLimit.Name = "TxtDecPressLimit";
            this.TxtDecPressLimit.Size = new System.Drawing.Size(169, 30);
            this.TxtDecPressLimit.TabIndex = 2122;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(587, 44);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(169, 20);
            this.label16.TabIndex = 2121;
            this.label16.Text = "恒减速压力限制：";
            // 
            // TxtDecDestSpeed
            // 
            this.TxtDecDestSpeed.Location = new System.Drawing.Point(203, 104);
            this.TxtDecDestSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtDecDestSpeed.Name = "TxtDecDestSpeed";
            this.TxtDecDestSpeed.Size = new System.Drawing.Size(199, 30);
            this.TxtDecDestSpeed.TabIndex = 2120;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(21, 106);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(169, 20);
            this.label17.TabIndex = 2119;
            this.label17.Text = "恒减速初始速度：";
            // 
            // TxtDecValue
            // 
            this.TxtDecValue.Location = new System.Drawing.Point(204, 174);
            this.TxtDecValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtDecValue.Name = "TxtDecValue";
            this.TxtDecValue.Size = new System.Drawing.Size(197, 30);
            this.TxtDecValue.TabIndex = 2118;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(23, 176);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 20);
            this.label18.TabIndex = 2117;
            this.label18.Text = "恒减速减速度：";
            // 
            // TxtDecCurSpeed
            // 
            this.TxtDecCurSpeed.Enabled = false;
            this.TxtDecCurSpeed.Location = new System.Drawing.Point(204, 40);
            this.TxtDecCurSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtDecCurSpeed.Name = "TxtDecCurSpeed";
            this.TxtDecCurSpeed.Size = new System.Drawing.Size(197, 30);
            this.TxtDecCurSpeed.TabIndex = 2114;
            // 
            // BtnDecRun
            // 
            this.BtnDecRun.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnDecRun.Location = new System.Drawing.Point(819, 159);
            this.BtnDecRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnDecRun.Name = "BtnDecRun";
            this.BtnDecRun.Size = new System.Drawing.Size(171, 38);
            this.BtnDecRun.TabIndex = 29;
            this.BtnDecRun.Text = "减速运行";
            this.BtnDecRun.UseVisualStyleBackColor = true;
            this.BtnDecRun.Click += new System.EventHandler(this.BtnDecRun_Click);
            this.BtnDecRun.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnDecRun_MouseDown);
            this.BtnDecRun.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnDecRun_MouseUp);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.SystemColors.Control;
            this.label23.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(23, 42);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(169, 20);
            this.label23.TabIndex = 2113;
            this.label23.Text = "恒减速实时速度：";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.LblCheckPressure);
            this.groupBox8.Controls.Add(this.label28);
            this.groupBox8.Controls.Add(this.LblDecRun);
            this.groupBox8.Controls.Add(this.label32);
            this.groupBox8.Controls.Add(this.LblAccRun);
            this.groupBox8.Controls.Add(this.LblNlimit);
            this.groupBox8.Controls.Add(this.label30);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Controls.Add(this.LblPlimit);
            this.groupBox8.Controls.Add(this.label29);
            this.groupBox8.Controls.Add(this.LblEmergAlarm);
            this.groupBox8.Controls.Add(this.label26);
            this.groupBox8.Controls.Add(this.LblServoAlarm);
            this.groupBox8.Controls.Add(this.LblDAMConnState);
            this.groupBox8.Controls.Add(this.label27);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.LblBackRun);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.LblLocationRun);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Controls.Add(this.LblPLCAlarm);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.LblOriginState);
            this.groupBox8.Controls.Add(this.LblPLCConnState);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox8.Location = new System.Drawing.Point(2204, 62);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox8.Size = new System.Drawing.Size(377, 660);
            this.groupBox8.TabIndex = 2125;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "设备状态显示";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(13, 411);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 2143;
            this.label5.Text = "压力检测：";
            // 
            // LblCheckPressure
            // 
            this.LblCheckPressure.AutoSize = true;
            this.LblCheckPressure.BackColor = System.Drawing.Color.LightGreen;
            this.LblCheckPressure.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblCheckPressure.Location = new System.Drawing.Point(207, 411);
            this.LblCheckPressure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCheckPressure.Name = "LblCheckPressure";
            this.LblCheckPressure.Size = new System.Drawing.Size(149, 20);
            this.LblCheckPressure.TabIndex = 2142;
            this.LblCheckPressure.Text = "压力未到设定值";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(13, 594);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(169, 20);
            this.label28.TabIndex = 2139;
            this.label28.Text = "恒减速运行状态：";
            // 
            // LblDecRun
            // 
            this.LblDecRun.AutoSize = true;
            this.LblDecRun.BackColor = System.Drawing.Color.Transparent;
            this.LblDecRun.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblDecRun.Location = new System.Drawing.Point(207, 594);
            this.LblDecRun.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblDecRun.Name = "LblDecRun";
            this.LblDecRun.Size = new System.Drawing.Size(129, 20);
            this.LblDecRun.TabIndex = 2138;
            this.LblDecRun.Text = "未恒减速运行";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(13, 548);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(169, 20);
            this.label32.TabIndex = 2137;
            this.label32.Text = "恒加速运行状态：";
            // 
            // LblAccRun
            // 
            this.LblAccRun.AutoSize = true;
            this.LblAccRun.BackColor = System.Drawing.Color.Transparent;
            this.LblAccRun.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblAccRun.Location = new System.Drawing.Point(207, 548);
            this.LblAccRun.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblAccRun.Name = "LblAccRun";
            this.LblAccRun.Size = new System.Drawing.Size(129, 20);
            this.LblAccRun.TabIndex = 2136;
            this.LblAccRun.Text = "未恒加速运行";
            // 
            // LblNlimit
            // 
            this.LblNlimit.AutoSize = true;
            this.LblNlimit.BackColor = System.Drawing.Color.LightGreen;
            this.LblNlimit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblNlimit.Location = new System.Drawing.Point(207, 361);
            this.LblNlimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNlimit.Name = "LblNlimit";
            this.LblNlimit.Size = new System.Drawing.Size(129, 20);
            this.LblNlimit.TabIndex = 2135;
            this.LblNlimit.Text = "未触碰负极限";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(13, 361);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(129, 20);
            this.label30.TabIndex = 2134;
            this.label30.Text = "负极限状态：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(13, 315);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 2132;
            this.label3.Text = "正极限状态：";
            // 
            // LblPlimit
            // 
            this.LblPlimit.AutoSize = true;
            this.LblPlimit.BackColor = System.Drawing.Color.LightGreen;
            this.LblPlimit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblPlimit.Location = new System.Drawing.Point(207, 315);
            this.LblPlimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPlimit.Name = "LblPlimit";
            this.LblPlimit.Size = new System.Drawing.Size(129, 20);
            this.LblPlimit.TabIndex = 2131;
            this.LblPlimit.Text = "未触碰正极限";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.Location = new System.Drawing.Point(13, 269);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(149, 20);
            this.label29.TabIndex = 2130;
            this.label29.Text = "急停报警状态：";
            // 
            // LblEmergAlarm
            // 
            this.LblEmergAlarm.AutoSize = true;
            this.LblEmergAlarm.BackColor = System.Drawing.Color.LightGreen;
            this.LblEmergAlarm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblEmergAlarm.Location = new System.Drawing.Point(207, 269);
            this.LblEmergAlarm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblEmergAlarm.Name = "LblEmergAlarm";
            this.LblEmergAlarm.Size = new System.Drawing.Size(149, 20);
            this.LblEmergAlarm.TabIndex = 2129;
            this.LblEmergAlarm.Text = "未发生急停报警";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(13, 222);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(149, 20);
            this.label26.TabIndex = 2128;
            this.label26.Text = "伺服报警状态：";
            // 
            // LblServoAlarm
            // 
            this.LblServoAlarm.AutoSize = true;
            this.LblServoAlarm.BackColor = System.Drawing.Color.LightGreen;
            this.LblServoAlarm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblServoAlarm.Location = new System.Drawing.Point(207, 222);
            this.LblServoAlarm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblServoAlarm.Name = "LblServoAlarm";
            this.LblServoAlarm.Size = new System.Drawing.Size(149, 20);
            this.LblServoAlarm.TabIndex = 2127;
            this.LblServoAlarm.Text = "未发生伺服报警";
            // 
            // LblDAMConnState
            // 
            this.LblDAMConnState.AutoSize = true;
            this.LblDAMConnState.BackColor = System.Drawing.Color.Pink;
            this.LblDAMConnState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblDAMConnState.Location = new System.Drawing.Point(207, 84);
            this.LblDAMConnState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblDAMConnState.Name = "LblDAMConnState";
            this.LblDAMConnState.Size = new System.Drawing.Size(69, 20);
            this.LblDAMConnState.TabIndex = 2126;
            this.LblDAMConnState.Text = "未连接";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.SystemColors.Control;
            this.label27.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(13, 84);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(149, 20);
            this.label27.TabIndex = 2125;
            this.label27.Text = "模块连接状态：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(13, 501);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 20);
            this.label6.TabIndex = 2112;
            this.label6.Text = "折返运行状态：";
            // 
            // LblBackRun
            // 
            this.LblBackRun.AutoSize = true;
            this.LblBackRun.BackColor = System.Drawing.Color.Transparent;
            this.LblBackRun.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblBackRun.Location = new System.Drawing.Point(207, 501);
            this.LblBackRun.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblBackRun.Name = "LblBackRun";
            this.LblBackRun.Size = new System.Drawing.Size(109, 20);
            this.LblBackRun.TabIndex = 2111;
            this.LblBackRun.Text = "未折返运行";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(13, 455);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "定位运行状态：";
            // 
            // LblLocationRun
            // 
            this.LblLocationRun.AutoSize = true;
            this.LblLocationRun.BackColor = System.Drawing.Color.Transparent;
            this.LblLocationRun.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblLocationRun.Location = new System.Drawing.Point(207, 455);
            this.LblLocationRun.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblLocationRun.Name = "LblLocationRun";
            this.LblLocationRun.Size = new System.Drawing.Size(109, 20);
            this.LblLocationRun.TabIndex = 40;
            this.LblLocationRun.Text = "未定位运行";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 176);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "PLC报警状态：";
            // 
            // LblPLCAlarm
            // 
            this.LblPLCAlarm.AutoSize = true;
            this.LblPLCAlarm.BackColor = System.Drawing.Color.LightGreen;
            this.LblPLCAlarm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblPLCAlarm.Location = new System.Drawing.Point(207, 176);
            this.LblPLCAlarm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPLCAlarm.Name = "LblPLCAlarm";
            this.LblPLCAlarm.Size = new System.Drawing.Size(139, 20);
            this.LblPLCAlarm.TabIndex = 38;
            this.LblPLCAlarm.Text = "未发生PLC报警";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(13, 130);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 20);
            this.label10.TabIndex = 37;
            this.label10.Text = "原点状态：";
            // 
            // LblOriginState
            // 
            this.LblOriginState.AutoSize = true;
            this.LblOriginState.BackColor = System.Drawing.Color.Pink;
            this.LblOriginState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblOriginState.Location = new System.Drawing.Point(207, 130);
            this.LblOriginState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblOriginState.Name = "LblOriginState";
            this.LblOriginState.Size = new System.Drawing.Size(89, 20);
            this.LblOriginState.TabIndex = 4;
            this.LblOriginState.Text = "未回原点";
            // 
            // LblPLCConnState
            // 
            this.LblPLCConnState.AutoSize = true;
            this.LblPLCConnState.BackColor = System.Drawing.Color.Pink;
            this.LblPLCConnState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblPLCConnState.Location = new System.Drawing.Point(207, 38);
            this.LblPLCConnState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPLCConnState.Name = "LblPLCConnState";
            this.LblPLCConnState.Size = new System.Drawing.Size(69, 20);
            this.LblPLCConnState.TabIndex = 3;
            this.LblPLCConnState.Text = "未连接";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "PLC连接状态：";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button7.Location = new System.Drawing.Point(2248, 712);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(167, 38);
            this.button7.TabIndex = 2123;
            this.button7.Text = "test";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // TmrRefresh
            // 
            this.TmrRefresh.Interval = 200;
            this.TmrRefresh.Tick += new System.EventHandler(this.TmrRefresh_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MnsMain);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.MenuStrip MnsMain;
        public System.Windows.Forms.ToolStripMenuItem PressureCurveTSMI;
        public System.Windows.Forms.ToolStripMenuItem LoginTSMI;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button BtnCreatConnect;
        public System.Windows.Forms.Button BtnHome;
        public System.Windows.Forms.Button BtnAlarmReset;
        public System.Windows.Forms.Button BtnPause;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TxtManualSpeed;
        public System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox TxtCurCoord;
        public System.Windows.Forms.Button BtnForewardRun;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Button BtnReverseRun;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtLocationInitSpeed;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtLocationCoord;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtLocationSpeed;
        public System.Windows.Forms.Button BtnLocationRun;
        public System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox TxtBackInitSpeed;
        public System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtBackCoord;
        public System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtBackSpeed;
        public System.Windows.Forms.Button BtnBackRun;
        public System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox TxtAccPressLimit;
        public System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox TxtAccDestSpeed;
        public System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TxtAccValue;
        public System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TxtAccCurSpeed;
        public System.Windows.Forms.Button BtnAccRun;
        public System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox TxtDecPressLimit;
        public System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TxtDecDestSpeed;
        public System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TxtDecValue;
        public System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TxtDecCurSpeed;
        public System.Windows.Forms.Button BtnDecRun;
        public System.Windows.Forms.Label label23;
        public System.Windows.Forms.GroupBox groupBox8;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label LblBackRun;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label LblLocationRun;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label LblPLCAlarm;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label LblOriginState;
        public System.Windows.Forms.Label LblPLCConnState;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button7;
        public System.Windows.Forms.Label label25;
        private System.Windows.Forms.Timer TmrRefresh;
        public System.Windows.Forms.Label LblDAMConnState;
        public System.Windows.Forms.Label label27;
        public System.Windows.Forms.Label label29;
        public System.Windows.Forms.Label LblEmergAlarm;
        public System.Windows.Forms.Label label26;
        public System.Windows.Forms.Label LblServoAlarm;
        public System.Windows.Forms.Label label30;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label LblPlimit;
        public System.Windows.Forms.Label LblNlimit;
        public System.Windows.Forms.Label label28;
        public System.Windows.Forms.Label LblDecRun;
        public System.Windows.Forms.Label label32;
        public System.Windows.Forms.Label LblAccRun;
        public System.Windows.Forms.Label label31;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label35;
        public System.Windows.Forms.Label label33;
        public System.Windows.Forms.Label label41;
        public System.Windows.Forms.Label label40;
        public System.Windows.Forms.Label label34;
        public System.Windows.Forms.Label label43;
        public System.Windows.Forms.Label label42;
        public System.Windows.Forms.Label label44;
        public System.Windows.Forms.Label label45;
        public System.Windows.Forms.Label label39;
        public System.Windows.Forms.Label label38;
        public System.Windows.Forms.Label label37;
        public System.Windows.Forms.Label label36;
        public System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox TxtAccPressCycle;
        public System.Windows.Forms.Label label47;
        public System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox TxtDecPressCycle;
        public System.Windows.Forms.Label label49;
        public System.Windows.Forms.Label label50;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label LblCheckPressure;
        private System.Windows.Forms.ToolStripMenuItem TorqueCurveTSMI;
    }
}


using HalconDotNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace PhaseFraction
{
    public partial class FormMain : Form
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        //SocketClass socket = new SocketClass();
        public Button[] BarcodeButton = new Button[60];
        private ConfigClass Config =new ConfigClass();
        delegate void MsgD(string msg, LogType i, bool bWarnFormShow);
        public static FormMain MainFrm;
        public string Source;
        WarningMessage WarningMessage1;
        PLCClass PLC = PLCClass.SingletonInstance;
        public Thread tReadPlc;
        public delegate void delegateupdatestate();
        public delegate void delegateCountNum();
        public delegate void delegateDisplay(byte[] inputByte);
        public static delegateDisplay deleReceive;
        public FormPressureCurve PressureCurve = new FormPressureCurve();
        public FormTorqueCurve TorqueCurve = new FormTorqueCurve();
        public FormTempCurve TempCurve = new FormTempCurve();
        public FormCameraSet CameraSet = new FormCameraSet();
        public static  bool PLCAlarmOccur=false;
        public static bool ServoAlarmOccur = false;
        public static bool EmergencyOccur = false;
        public static bool ForewardRun = false;
        public static bool ReverseRun = false;
        //public static string ManualSpeed = String.Empty;
        //public static string LocationSpeed = String.Empty;
        //public static string LocationInitSpeed = String.Empty;
        //public static string LocationCoord = String.Empty;
        //public static string BackSpeed = String.Empty;
        //public static string BackInitSpeed = String.Empty;
        //public static string BackCoord = String.Empty;
        //public static string AccPressLimit = String.Empty;
        //public static string AccDestSpeed = String.Empty;
        //public static string AccPressCycle = String.Empty;
        //public static string AccValue = String.Empty;
        //public static string DecPressLimit = String.Empty;
        //public static string DecDestSpeed = String.Empty;
        //public static string DecPressCycle = String.Empty;
        //public static string DecValue = String.Empty;
        private readonly Stopwatch ProgramCycleTime = new Stopwatch();
        HDrawingObject DoRoi = null;
        HObject m_SrcImage = new HObject();

        /// <summary>
        ///報警信息接口；
        /// </summary>
        /// <returns></returns>
        private void AlarmEvent(string msg, LogType i, bool bWarnFormShow)
        {
            try
            {
                MsgD g = new MsgD(MsgofMainFrm);
                BeginInvoke(g, msg, i, bWarnFormShow);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        ///處理報警信息；
        /// </summary>
        /// <returns></returns>
        public void MsgofMainFrm(string msg, LogType i, bool warnFormShow)
        {
            try
            {
                switch (i)
                {
                    case LogType.ListShow: //僅顯示於List
                        ListShowAddStr(msg, (int)i);
                        if (warnFormShow)
                        {
                            WarningMessageShow(msg);
                        }
                        break;
                    case LogType.AlarmLog: //記錄於AlarmLog
                        ListShowAddStr(msg, (int)i);
                        LogClass.SingletonInstance.WriteLogEnqueue(msg, LogClass.AlarmLog);
                        if (warnFormShow)
                        {
                            WarningMessageShow(msg);
                        }
                        break;
                    case LogType.AlarmPLC: //記錄於AlarmLog
                        ListShowAddStr(msg, (int)i);
                        LogClass.SingletonInstance.WriteLogEnqueue(msg, LogClass.AlarmLog);
                        if (warnFormShow)
                        {
                            WarningMessageShow(msg);
                        }
                        break;

                    case LogType.FlowLog:  //記錄於FlowLog
                        ListShowAddStr(msg, (int)i);
                        LogClass.SingletonInstance.WriteLogEnqueue(msg, LogClass.FlowLog);
                        if (warnFormShow)
                        {
                            WarningMessageShow(msg);
                        }
                        break;
                    case LogType.FlowLogOnly:
                        LogClass.SingletonInstance.WriteLogEnqueue(msg, LogClass.FlowLog);
                        break;
                    case LogType.BarcodeLog:  
                        ListShowAddStr(msg, (int)i);
                        LogClass.SingletonInstance.WriteLogEnqueue(msg, LogClass.FlowLog);
                        if (warnFormShow)
                        {
                            WarningMessageShow(msg);
                        }
                        break;

                }
            }
            catch (Exception ex)
            {
                WarningMessageShow(ex.Message);
            }
        }
        /// <summary>
        ///彈窗提醒；
        /// </summary>
        /// <returns></returns>
        public void WarningMessageShow(string str_Renamed)
        {
            //if (Application.OpenForms["WarningMessage"] == null)
            //{
            WarningMessage1 = new WarningMessage();
            WarningMessage1.Show();
            //}
            WarningMessage1.button1.Text = str_Renamed;
            WarningMessage1.button1.BackColor = Color.Yellow;
        }

        /// <summary>
        ///List顯示；
        /// </summary>
        /// <returns></returns>
        public void ListShowAddStr(string str, int i)
        {
            if (lstMessage.InvokeRequired == false)
            {
                ListViewItem ItemAdd = new ListViewItem();
                DateTime TimeNow = DateTime.Now;
                ItemAdd.Text = TimeNow.ToString("yyyy/MM/dd HH:mm:ss.fff");
                ItemAdd.SubItems.Add(str);
                lstMessage.Items.Insert(0, ItemAdd);
            }
            //多于500條則清空
            if (lstMessage.Items.Count > 500)
            {
                lstMessage.Items.RemoveAt(lstMessage.Items.Count - 1);
            }
        }



        public FormMain()
        {
            InitializeComponent();
            //WidthX = this.Width;
            //HeightY = this.Height;
            //asc.SetTag(this);
            MainFrm = this;
        }

      
        public void InitParam()
        {
            ConfigClass config = new ConfigClass();
            Variable.IPAddress = MainClass.GetIPAddress();
            Variable.MacAddress1 = MainClass.GetMacAddress()[0];
            Variable.MacAddress2 = MainClass.GetMacAddress()[1];
            //Variable.MacAddress1 = "DLAR02000252";
            //Variable.MacAddress1 = CommClass.ReadConfig("LocalMAC1");
            //Variable.MacAddress2 = CommClass.ReadConfig("LocalMAC2");
            //Variable.Ge_Ban = CommClass.ReadConfig("Ge_Ban");
            Variable.PortName = config.ReadConfig("PortName");
            Variable.BaudRate = config.ReadConfig("BaudRate");
            Variable.DataBits = config.ReadConfig("DataBits");
            Variable.StopBits = config.ReadConfig("StopBits");
            Variable.Parity = config.ReadConfig("Parity");
                     
            this.Text = "本機MAC地址：" + Variable.MacAddress1 + "，本機IP地址：" + Variable.IPAddress;
        }

        public void OpenSerialPort()
        {
            try
            {
                StopBits stopBits;
                Parity parity;
                if (Variable.PortName == string.Empty) { Variable.PortName = "COM1"; }
                if (Variable.BaudRate == string.Empty) { Variable.BaudRate = "9600"; }
                if (Variable.DataBits == string.Empty) { Variable.DataBits = "8"; }
                if (Variable.StopBits == string.Empty) { Variable.StopBits = "1"; }
                if (Variable.Parity == string.Empty) { Variable.Parity = "0"; }

                if (serialPortScaner.IsOpen) { serialPortScaner.Close(); Thread.Sleep(500); }

                if (Variable.StopBits == "0") { stopBits = StopBits.None; }
                else if (Variable.StopBits == "1") { stopBits = StopBits.One; }
                else if (Variable.StopBits == "1.5") { stopBits = StopBits.OnePointFive; }
                else if (Variable.StopBits == "2") { stopBits = StopBits.Two; }
                else { MsgofMainFrm("串口打開失敗，請關閉程序后重開開啟！", LogType.FlowLog, true); return; }

                if (Variable.Parity == "0") { parity = Parity.None; }
                else if (Variable.Parity == "1") { parity = Parity.Odd; }
                else if (Variable.Parity == "2") { parity = Parity.Even; }
                else if (Variable.Parity == "3") { parity = Parity.Mark; }
                else if (Variable.Parity == "4") { parity = Parity.Space; }
                else { MsgofMainFrm("串口打開失敗，請關閉程序后重開開啟！", LogType.FlowLog, true); return; }

                serialPortScaner.PortName = Variable.PortName;
                serialPortScaner.BaudRate = Convert.ToInt32(Variable.BaudRate);
                serialPortScaner.DataBits = Convert.ToInt32(Variable.DataBits);
                serialPortScaner.StopBits = stopBits;
                serialPortScaner.Parity = parity;
                serialPortScaner.ReadBufferSize = 2 * 1024 * 1024;
               
                serialPortScaner.Open();
                if (serialPortScaner.IsOpen)
                {
                   
                    MsgofMainFrm("串口打開成功！", LogType.FlowLog, false);
                }
                else
                {
                   

                    MsgofMainFrm("串口打開失敗，請關閉程序后重開開啟！", LogType.FlowLog, true);
                }
            }
            catch (Exception ex)
            {
                
                MsgofMainFrm("串口打開失敗，請關閉程序后重開開啟！" + ex.Message, LogType.FlowLog, true);
            }
        }



        private void FormMain_Load(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
            MainClass.MsgofMain += AlarmEvent;
           VisionClass. MsgofVision += AlarmEvent;
            SocketClass.MessageofSocketClass += AlarmEvent;
            MouseWheel += FormMainMouseWheel;
            MainClass.instance().Init();
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text = "多相流分相含率在线测量系统，版本：" + version;
            BtnCreatConnect.Enabled = true;
          
            BtnPause.Enabled = false;
            BtnAlarmReset.Enabled = false;
         
        }

        public void FormMainMouseWheel(object sender, MouseEventArgs e)
        {
            //HSmartWindowControl控件的区域
            Rectangle rect = hSmartWindowControl1.RectangleToScreen(hSmartWindowControl1.ClientRectangle);
            //滚动时，鼠标悬停在在HSmartWindowControl控件上
            if (rect.Contains(Cursor.Position))
            {
                //缩放
                hSmartWindowControl1.HSmartWindowControl_MouseWheel(sender, e);
            }
        }

        public void ShowImage(HObject image)
        {
            if (image == null)
                return;

            //获取图像及显示窗口长宽
            HOperatorSet.GetImageSize(image, out HTuple imgWidth, out HTuple imgHeight);
            int wndWidth = hSmartWindowControl1.ClientRectangle.Width;
            int wndHeight = hSmartWindowControl1.ClientRectangle.Height;

            //计算比例
            double scale = Math.Max(1.0 * imgWidth.I / wndWidth, 1.0 * imgHeight / wndHeight);
            double w = wndWidth * scale;
            double h = wndHeight * scale;
            //居中时，Part的区域
            hSmartWindowControl1.HalconWindow.SetPart(-(h - imgHeight) / 2, -(w - imgWidth) / 2, imgHeight + (h - imgHeight.D) / 2, imgWidth + (w - imgWidth) / 2);

            //背景色
            hSmartWindowControl1.HalconWindow.SetWindowParam("background_color", "black");
            hSmartWindowControl1.HalconWindow.ClearWindow();

            hSmartWindowControl1.HalconWindow.DispObj(image);
            //画根测试线
            //HOperatorSet.GenRegionLine(out HObject line, 0, 0, imgHeight, imgWidth);
            //hSmartWindowControl1.HalconWindow.SetColor("green");
            //hSmartWindowControl1.HalconWindow.DispObj(line);
        }

        public void DrawROI()
        {
            if (DoRoi == null)
            {

                //创建一个矩形的显示实例
                DoRoi = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE1, 500, 500, 1000, 1000);
                DoRoi.SetDrawingObjectParams("color", "green");
                //挂靠实例到HSmartWindowControl控件
                hSmartWindowControl1.HalconWindow.AttachDrawingObjectToWindow(DoRoi);
            }
            else
            {
                //hSmartWindowControl1.HalconWindow.DetachDrawingObjectFromWindow(doRoi);//这里这句可以不要
                //doRoi = null;
            }

        }

        public void GenROI()
        {
            //获取矩形参数
            string[] str = { "row1", "column1", "row2", "column2" };
            HTuple val = DoRoi.GetDrawingObjectParams(str);

            //生成ROI
            HOperatorSet.GenRectangle1(out HObject roi, val[0], val[1], val[2], val[3]);
            HOperatorSet.ReduceDomain(m_SrcImage, roi, out HObject imageROI);
            ShowImage(imageROI);
        }

        public void RefreshDisplay()
        {
         

        }
        private void HomeFinishCheck()
        {

            if (PLCClass.SingletonInstance.PLCW10.Data[3])
            {
                MainClass.GoHomeFinish = true;
              
             
                MsgofMainFrm("PLC已在原点！", LogType.FlowLog, false);

            }
        }

        public void ClearBarcodeButton()
        {
            for (int i = 0; i < 60; i++)
            {
                BarcodeButton[i].BackColor = Color.Pink;
                BarcodeButton[i].Text = "";
            }
        }

        private void ButtonMouseDown(object sender, MouseEventArgs e)
        {
            string s = ((Button)sender).Name;
            string[] str = new string[3];
            int num;
            str = s.Split('-');
            num = int.Parse(str[1]);

        }
        private void ButtonHover(object sender, EventArgs e)
        {

            string s = ((Button)sender).Name;
            string[] str = new string[3];
            int num;
            str = s.Split('-');
            num = int.Parse(str[1]);
        }
        private void ButtonLeave(object sender, EventArgs e)
        {

        }

        public void Delay(int ms)
        {
            DateTime now = DateTime.Now;
            while (true)
            {
                Application.DoEvents();
                TimeSpan span = (TimeSpan)(DateTime.Now - now);
                if (span.TotalMilliseconds > ms)
                {
                    return;
                }
            }
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

       
              

        private void serialPortScaner_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(200);
            int receiveLen = serialPortScaner.BytesToRead;
            if (receiveLen < 0)
            {
                return;
            }
            else
            {
                byte[] receiveBytes = new byte[receiveLen];
                int dataLen = serialPortScaner.Read(receiveBytes, 0, receiveBytes.Length);
                if (dataLen > 0)
                {
                    deleReceive = new delegateDisplay(ReceiveByteToStr);
                    this.Invoke(deleReceive, receiveBytes);
                }
            }
        }

        public void ReceiveByteToStr(byte[] inputByte)
        {
            try
            {
                if (inputByte != null && inputByte.Length > 0)
                {
                    //string barcode = Encoding.ASCII.GetString(inputByte, 0, inputByte.Length);
                    string barcode = Encoding.UTF8.GetString(inputByte, 0, inputByte.Length);
                    barcode = barcode.Replace("\0", "");
                    barcode = barcode.Replace("\b", "");
                    barcode = barcode.Replace("\n", "");
                    barcode = barcode.Replace("\r", "");
                    barcode = barcode.Trim().ToUpper();
                    if (barcode != string.Empty)
                    {
                        SplitAndStoreData(barcode);
                    }
                }
            }
            catch (Exception ex)
            {
                MsgofMainFrm("接收數據異常！" + ex.Message, LogType.FlowLog, false);
            }
        }
              

        public void SplitAndStoreData(string receiveData)
        {
            //<000M10714174220701>A<PNLTJZKJ001#>B<000M10714174220701>C<PNLTJZKJ001#>D
            Regex regData = new Regex("^<.*");
            Regex regScanerA = new Regex(">A$");
            Regex regScanerB = new Regex(">B$");
            Regex regScanerC = new Regex(">C$");
            Regex regScanerD = new Regex(">D$");
            Regex regDeviceNo = new Regex("^PNLTJZKJ[0-9]{3}#>[ABCD]{1}$");
            Regex regBarcode = new Regex("^[0-9]{3}[MS]{1}[0-9]{14}>[ABCD]{1}$");
            Regex regLotNo = new Regex("^[MS]{1}[0-9]{9}>[ABCD]{1}$");
            MsgofMainFrm("接收數據：" + receiveData, LogType.FlowLog, false);
            if (regData.IsMatch(receiveData))
            {
                receiveData = receiveData.Substring(1, receiveData.Length - 1);
            }
            string[] dataAvary = receiveData.Split('<');
            for (int i = 0; i < dataAvary.Length; i++)
            {
                if (regDeviceNo.IsMatch(dataAvary[i]) || regBarcode.IsMatch(dataAvary[i]))
                {
                    if (regScanerA.IsMatch(dataAvary[i]))
                    {
                        if (!Variable.ScanerA.Contains(dataAvary[i]))
                        {
                            Variable.ScanerA.Add(dataAvary[i]);
                        }
                    }
                    else if (regScanerB.IsMatch(dataAvary[i]))
                    {
                        if (!Variable.ScanerB.Contains(dataAvary[i]))
                        {
                            Variable.ScanerB.Add(dataAvary[i]);
                        }
                    }
                    else if (regScanerC.IsMatch(dataAvary[i]))
                    {
                        if (!Variable.ScanerC.Contains(dataAvary[i]))
                        {
                            Variable.ScanerC.Add(dataAvary[i]);
                        }
                    }
                    else if (regScanerD.IsMatch(dataAvary[i]))
                    {
                        if (!Variable.ScanerD.Contains(dataAvary[i]))
                        {
                            Variable.ScanerD.Add(dataAvary[i]);
                        }
                    }
                }
                else if (regLotNo.IsMatch(dataAvary[i]))
                {
                    if (regScanerA.IsMatch(dataAvary[i]))
                    {
                        Variable.LotNoA = dataAvary[i].Substring(0, 10);
                        MsgofMainFrm("A掃描槍批號：" + Variable.LotNoA, LogType.FlowLog, false);
                    }
                    else if (regScanerB.IsMatch(dataAvary[i]))
                    {
                        Variable.LotNoB = dataAvary[i].Substring(0, 10);
                        MsgofMainFrm("B掃描槍批號：" + Variable.LotNoB, LogType.FlowLog, false);
                    }
                    else if (regScanerC.IsMatch(dataAvary[i]))
                    {
                        Variable.LotNoC = dataAvary[i].Substring(0, 10);
                        MsgofMainFrm("C掃描槍批號：" + Variable.LotNoC, LogType.FlowLog, false);
                    }
                    else if (regScanerD.IsMatch(dataAvary[i]))
                    {
                        Variable.LotNoD = dataAvary[i].Substring(0, 10);
                        MsgofMainFrm("D掃描槍批號：" + Variable.LotNoD, LogType.FlowLog, false);
                    }
                }
                else
                {
                    MsgofMainFrm("數據不是機臺號也不是二維碼：" + dataAvary[i], LogType.FlowLog, false);
                }
            }
        }

        public ArrayList RemoveRepeat(ArrayList inputArray)
        {
            try
            {
                for (int i = 0; i < inputArray.Count; i++)
                {
                    for (int j = inputArray.Count - 1; j > i; j--)
                    {
                        if (inputArray[i] == inputArray[j])
                        {
                            inputArray.RemoveAt(j);
                        }
                    }
                }
                return inputArray;
            }
            catch { return inputArray; }
        }
               

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        public string [] Array2Object(object obj)
        {
             return (string[])obj;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DisplayCurveWindow();
            //int accPressCycle = int.Parse(TxtAccPressCycle.Text.Trim());
            //Delay(100);
            //MainClass.instance().StartTimer(accPressCycle);

            Double ADTmp = 10.2;
            LogClass.SingletonInstance.WriteLog(ADTmp.ToString(), LogClass.PressureLog);
            LogClass.SingletonInstance.WriteLog(ADTmp.ToString(), LogClass.TorqueLog);

            //MainClass.SetPressure = -230;
        }

        private void AddBarcode_Click(object sender, EventArgs e)
        {
            if (CmsChangeState.SourceControl.BackColor == Color.Pink
                && CmsChangeState.SourceControl.Text == string.Empty)
            {
                //string s = Convert.ToString(CmsChangeState.SourceControl.Name);
                //string[] str = new string[3];
                //int num;
                //str = s.Split('-');
                //num = int.Parse(str[1]);
                CmsChangeState.SourceControl.Text = "barcode";
                CmsChangeState.SourceControl.BackColor = Color.Lime ;
                Variable.CurVehicleQt += 1;
                Variable.CurLotNoQt += 1;
            
            }
            else
            {
                MsgofMainFrm("該位置已掃描，不能再增加！" , LogType.FlowLog, false);
            }
        }

        private void DeleteBarcode_Click(object sender, EventArgs e)
        {
            if (CmsChangeState.SourceControl.BackColor == Color.Lime
                && CmsChangeState.SourceControl.Text != string.Empty)
            {
                //string s = Convert.ToString(CmsChangeState.SourceControl.Name);
                //string[] str = new string[3];
                //int num;
                //str = s.Split('-');
                //num = int.Parse(str[1]);
                CmsChangeState.SourceControl.Text = string.Empty ;
                CmsChangeState.SourceControl.BackColor = Color.Pink ;
                Variable.CurVehicleQt -= 1;
                Variable.CurLotNoQt -= 1;
               
            }
            else
            {
                MsgofMainFrm("該位置未掃描，不能再刪除！", LogType.FlowLog, false);
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            //float newX = (this.Width) / WidthX;
            //float newY = (this.Height) / HeightY;
            //asc.setControls(newX, newY, this);

        }

        private void LblLotNoTotal_Click(object sender, EventArgs e)
        {

        }

        private void PressureCurveTSMI_Click(object sender, EventArgs e)
        {
            if (PressureCurve == null || PressureCurve.IsDisposed)
            {
                PressureCurve = new FormPressureCurve();
            }
            PressureCurve.TopLevel = true;
            PressureCurve.Visible = true;
            PressureCurve.Show();
        }

        public void DisplayCurveWindow()
        {
            if (PressureCurve == null || PressureCurve.IsDisposed)
            {
                PressureCurve = new FormPressureCurve();
            }
            PressureCurve.TopLevel = true;
            PressureCurve.Visible = true;
            PressureCurve.Show();
           
        }

       

        private void BtnCreatConnect_Click(object sender, EventArgs e)
        {
            SocketClass socket = new SocketClass();
            bool ret = VisionClass.instance().ConnectCamera();
            if (ret)
            {
                LblCameraState.Text = "已连接";
                LblCameraState.BackColor = Color.LightGreen;
                MsgofMainFrm("相机连接成功!", LogType.FlowLog, false);
            }
            else
            {
                LblCameraState.Text = "未连接";
                LblCameraState.BackColor = Color.Pink;
                MsgofMainFrm("相机连接失败!", LogType.FlowLog, true);
                 return;
            }
            ret = socket.SocketServerStart(MainClass.WLANIP, MainClass.WLANPort);
            if (ret)
            {
                LblSensorState.Text = "已连接";
                LblSensorState.BackColor = Color.LightGreen;
            }
            else
            {
                LblSensorState.Text = "未连接";
                LblSensorState.BackColor = Color.Pink;
                return;
            }
            ret = MainClass.instance().CreateConnectionToPLC();
            if (ret)
            {
                PLC.PLCWrite(PLC.CreatConnection, false);

                if (PLC.PLCWrite(PLC.CreatConnection, true))
                {
                    PLC.PLCRead(PLC.PLCW1);
                    Delay(100);
                    if (PLC.PLCW1.Data[1])
                    {
                        LblPLCState.Text = "已连接";
                        LblPLCState.BackColor = Color.LightGreen;
                        MsgofMainFrm("PLC连接成功!", LogType.FlowLog, false);
                        BtnPause.Enabled = true;
                        TmrRefresh.Enabled = true;
                        BtnCreatConnect.Enabled = false;
                      
                    }
                    else
                    {
                        //MainClass.instance().CreatConnectionToPLC();
                        PLC.PLCWrite(PLC.CreatConnection, false);
                        PLC.PLCWrite(PLC.CreatConnection, true);
                        PLC.PLCRead(PLC.PLCW1);
                        Delay(100);
                        if (PLC.PLCW1.Data[1])
                        {
                            LblPLCState.Text = "已连接";
                            LblPLCState.BackColor = Color.LightGreen;
                            MsgofMainFrm("PLC连接成功!", LogType.FlowLog, false);
                          
                            BtnPause.Enabled = true;
                            BtnAlarmReset.Enabled = true;
                          
                            TmrRefresh.Enabled = true;
                            BtnCreatConnect.Enabled = false;
                          
                        }
                        else
                        {
                            LblPLCState.Text = "未连接";
                            LblPLCState.BackColor = Color.Pink;
                            MsgofMainFrm("PLC连接失败!", LogType.FlowLog, false);
                        }

                        //LblPLCConnState.Text = "未连接";
                        //LblPLCConnState.BackColor = Color.Pink;
                        //MsgofMainFrm("PLC连接失败!", LogType.FlowLog, false);
                    }
                }
                else
                {
                    LblPLCState.Text = "未连接";
                    LblPLCState.BackColor = Color.Pink;
                    MsgofMainFrm("PLC连接失败!", LogType.FlowLog, false);
                }
                Delay(500);
                PLC.PLCWrite(PLC.CreatConnection, false);
            }
            else
            {
                LblPLCState.Text = "未连接";
                LblPLCState.BackColor = Color.Pink;
                MsgofMainFrm("PLC连接失败!", LogType.FlowLog, false);
            }
        }

      

        private void button7_Click(object sender, EventArgs e)
        {
            
            //bool ret = PLC.PLCWrite(PLC.test,0.98F);

            //ret = PLC.PLCRead(PLC.test);
            //label25.Text = PLC.test.Data[0].ToString("##0.00");
           bool ret = PLC.PLCRead(PLC.CreatConnection);
            bool result = PLC.CreatConnection.Data[0];
            ret = PLC.PLCWrite(PLC.CreatConnection,true);
            ret = PLC.PLCRead(PLC.CreatConnection);
            result = PLC.CreatConnection.Data[0];
        }

        private void TmrRefresh_Tick(object sender, EventArgs e)
        {
            RefreshDisplay();
        }

       
        public bool InitMoveParam()
        {
            try
            {
                ConfigClass config = new ConfigClass();
             
                return true;
            }
            catch (Exception ex)
            {
                MsgofMainFrm("运动参数设置错误，请检查配置文件后重启程序！" + ex.Message, LogType.FlowLog, true);
                return false;
            }
        }

    

        private void BtnPause_Click(object sender, EventArgs e)
        {
            PLC.PLCWrite(PLC.Stop, false);

            if (PLC.PLCWrite(PLC.Stop, true))
            {
                MainClass.instance().StopTimer();
                MsgofMainFrm("发送停止信号成功！", LogType.FlowLog, false);
               
            }
            else
            {

                MsgofMainFrm("发送PLC停止信号失败！", LogType.FlowLog, false);
            }
            Delay(500);
            PLC.PLCWrite(PLC.Stop, false);
           
        }

        private void BtnAlarmReset_Click(object sender, EventArgs e)
        {
            PLC.PLCWrite(PLC.AlarmReset, false);

            if (PLC.PLCWrite(PLC.AlarmReset, true))
            {

                PLCAlarmOccur = false;
                ServoAlarmOccur = false;
                EmergencyOccur = false;
                MsgofMainFrm("发送PLC复位信号成功！", LogType.FlowLog, false);
              
            }
            else
            {

                MsgofMainFrm("发送PLC复位信号失败！", LogType.FlowLog, false);
            }
            Delay(500);
            PLC.PLCWrite(PLC.AlarmReset, false);
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgramCycleTime.Reset();
            ProgramCycleTime.Start();
            for (int i = 0; i < 100000000; i++) 
            {
              
            }
            MsgofMainFrm(ProgramCycleTime.ElapsedMilliseconds.ToString(), LogType.FlowLog, false);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("确定关闭程序？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                try
                {
                    MainClass.instance().StopTimer();
                  
                    PLCClass.FinsUDP.UDPClose();
                }
                catch { }
                Thread.Sleep(1000);
                //this.Close();
                //System.Environment.Exit(0);
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void TorqueCurveTSMI_Click(object sender, EventArgs e)
        {
            if (TorqueCurve == null || TorqueCurve.IsDisposed)
            {
                TorqueCurve = new FormTorqueCurve();
            }
            TorqueCurve.TopLevel = true;
            TorqueCurve.Visible = true;
            TorqueCurve.Show();
        }

        private void TempCurveTSMI_Click(object sender, EventArgs e)
        {

            if (TempCurve == null || TempCurve.IsDisposed)
            {
                TempCurve = new FormTempCurve();
            }
            TempCurve.TopLevel = true;
            TempCurve.Visible = true;
            TempCurve.Show();
        }

        private void m(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            VisionClass.instance().DisplayWindow = hSmartWindowControl1.HalconWindow;
            VisionClass.instance().IsPhoto = true;
                       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VisionClass.instance().TakePhoto();
        }

        private void CameraSetTSMI_Click(object sender, EventArgs e)
        {
            if (CameraSet == null || CameraSet.IsDisposed)
            {
                CameraSet = new FormCameraSet();
            }
            CameraSet.TopLevel = true;
            CameraSet.Visible = true;
            CameraSet.Show();
        }

        private void ucConduit7_Load(object sender, EventArgs e)
        {

        }
    }
    }


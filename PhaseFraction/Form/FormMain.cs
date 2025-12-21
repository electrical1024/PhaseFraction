using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Collections;
using System.Diagnostics;

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
            asc.controlAutoSize(this);
            MainClass.MsgofMain += AlarmEvent;
            FormPressureCurve.MsgofPressureCurve += AlarmEvent;
            MainClass.instance().Init();
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text = "压力推杆操作系统，版本：" + version;
            BtnCreatConnect.Enabled = true;
            BtnHome.Enabled = false;
            BtnPause.Enabled = false;
            BtnAlarmReset.Enabled = false;
            FormMain.MainFrm.BtnForewardRun.Enabled = false;
            FormMain.MainFrm.BtnReverseRun.Enabled = false;
            FormMain.MainFrm.BtnLocationRun.Enabled = false;
            FormMain.MainFrm.BtnBackRun.Enabled = false;
            FormMain.MainFrm.BtnAccRun.Enabled = false;
            FormMain.MainFrm.BtnDecRun.Enabled = false;
            InitMoveParam();
        }

        public void RefreshDisplay()
        {
            if (LblOriginState.BackColor == Color.Pink)
            {
                if (MainClass.GoHomeFinish)
                {
                    LblOriginState.BackColor = Color.LightGreen;
                    LblOriginState.Text = "回原点完成";
                    BtnHome.Enabled = false;
                    EnableButton(true);
                }
                else if (MainClass.GoHomeTimeout)
                {
                    MainClass.GoHomeTimeout = false;
                    BtnHome.Enabled = true;
                }
            }
            if(!PLCAlarmOccur)
            {
                if (PLC.PLCW1.Data[6])
                {
                    PLCAlarmOccur = true;
                    LblPLCAlarm.Text = "发生PLC报警";
                    LblPLCAlarm.BackColor = Color.Pink;
                    MsgofMainFrm("PLC报警，请按复位按钮！", LogType.FlowLog, true);
                }
            }

            if (!ServoAlarmOccur)
            {
                if (PLC.PLCI0.Data[3])
                {
                    LblServoAlarm.Text = "发生伺服报警";
                    LblServoAlarm.BackColor = Color.Pink;
                    ServoAlarmOccur = true;
                    MsgofMainFrm("伺服报警，请按复位按钮！", LogType.FlowLog, true);
                }
            }
            if(!EmergencyOccur)
            {
                if (PLC.PLCI0.Data[0]==false)
                {
                    EmergencyOccur = true;
                    MainClass.GoHomeFinish = false;
                    LblOriginState.BackColor = Color.Pink;
                    LblOriginState.Text = "未回原点";
                    LblEmergAlarm.Text = "发生急停报警";
                    LblEmergAlarm.BackColor = Color.Pink;
                    MsgofMainFrm("检测到急停信号，请按复位急停按钮后重新回原点！", LogType.FlowLog, true);
                    BtnHome.Enabled = true;
                    EnableButton(false);
                    BtnForewardRun.Enabled = true;
                    BtnReverseRun.Enabled = true;
                }
            }
           
            if (MainClass.LocationRunFinish)
            {
                MainClass.LocationRunFinish = false;
                EnableButton(true);
                LblLocationRun.Text = "定位运行完成";
                LblLocationRun.BackColor = Color.LightGreen;
            }
            else if (MainClass.LocationRunTimeout)
            {
                MainClass.LocationRunTimeout = false;
                EnableButton(true);
                LblLocationRun.Text = "定位运行超时";
                LblLocationRun.BackColor = Color.LightYellow;
            }
            if (MainClass.BackRunFinish)
            {
                MainClass.BackRunFinish = false;
                EnableButton(true);
                LblBackRun.Text = "折返运行完成";
                LblBackRun.BackColor = Color.LightGreen;
            }
            else if (MainClass.BackRunTimeout)
            {
                MainClass.BackRunTimeout = false;
                EnableButton(true);
                LblBackRun.Text = "折返运行超时";
                LblBackRun.BackColor = Color.LightYellow;
            }
            if (MainClass.AccRunFinish)
            {
                object obj=new object();
                EventArgs e=new EventArgs();
                
                MainClass.instance().StopTimer();
                LogClass.SingletonInstance.WriteLogEnqueue("结束采集压力数据", LogClass.PressureLog);
                MainClass.AccRunFinish = false;
                EnableButton(true);
                LblAccRun.Text = "恒加速运行完成";
                LblAccRun.BackColor = Color.LightGreen;
                PLCClass.SingletonInstance.PLCWrite(PLCClass.SingletonInstance.FlowFinish, false);
                BtnBackRun_Click(obj, e);
            }
            else if (MainClass.AccRunTimeout)
            {
                MainClass.instance().StopTimer();
                LogClass.SingletonInstance.WriteLogEnqueue("结束采集压力数据", LogClass.PressureLog);
                MainClass.AccRunTimeout = false;
                EnableButton(true);
                LblAccRun.Text = "恒加速运行超时";
                LblAccRun.BackColor = Color.LightYellow;
            }
            if (MainClass.DecRunFinish)
            {
                object obj = new object();
                EventArgs e = new EventArgs();
                
                MainClass.instance().StopTimer();
                LogClass.SingletonInstance.WriteLogEnqueue("结束采集压力数据", LogClass.PressureLog);
                MainClass.DecRunFinish = false;
                EnableButton(true);
                LblDecRun.Text = "恒减速运行完成";
                LblDecRun.BackColor = Color.LightGreen;
                PLCClass.SingletonInstance.PLCWrite(PLCClass.SingletonInstance.FlowFinish, false);
                BtnBackRun_Click(obj, e);
            }

            else if (MainClass.DecRunTimeout)
            {
                MainClass.instance().StopTimer();
                LogClass.SingletonInstance.WriteLogEnqueue("结束采集压力数据", LogClass.PressureLog);
                MainClass.DecRunTimeout = false;
                EnableButton(true);
                LblDecRun.Text = "恒减速运行超时";
                LblDecRun.BackColor = Color.LightYellow;
            }
            if (!PLC.PLCI0.Data[4])
            {
                MainClass.instance().StopTimer();
                LblPlimit.Text = "触碰正极限";
                LblPlimit.BackColor = Color.Pink;
            }
            else
            {
                LblPlimit.Text = "未触碰正极限";
                LblPlimit.BackColor = Color.LightGreen ;
            }

            if (!PLC.PLCI0.Data[5])
            {
                MainClass.instance().StopTimer();
                LblNlimit.Text = "触碰负极限";
                LblNlimit.BackColor = Color.Pink;
            }
            else
            {
                LblNlimit.Text = "未触碰负极限";
                LblNlimit.BackColor = Color.LightGreen;
            }

            if (MainClass.AccRunStart == false && MainClass.DecRunStart == false)
            {
                double adTmp = 0;
                if (MainClass.instance().ReadDAMPressure(out adTmp))
                {
                    if (adTmp > MainClass.SetPressure)
                    {
                        if (!MainClass.PressureArrival)
                        {
                            MainClass.PressureArrival = true;
                            PLCClass.SingletonInstance.PLCWrite(PLCClass.SingletonInstance.FlowFinish, true);
                        }
                    }
                    else
                    {
                        if (MainClass.PressureArrival)
                        {
                            MainClass.PressureArrival = false;
                            PLCClass.SingletonInstance.PLCWrite(PLCClass.SingletonInstance.FlowFinish, false);
                        }
                    }
                }
            }
            if (MainClass.PressureArrival)
            {
                if (LblCheckPressure.BackColor != Color.Pink)
                {
                    LblCheckPressure.BackColor = Color.Pink;
                    LblCheckPressure.Text = "压力到达设定值";
                }
            }
            else
            {
                if (LblCheckPressure.BackColor != Color.LightGreen)
                {
                    LblCheckPressure.BackColor = Color.LightGreen;
                    LblCheckPressure.Text = "压力未到设定值";
                }
            }
            if (ForewardRun)
            {
                double adTmp = 0;
                if (MainClass.instance().ReadDAMPressure(out adTmp))
                {
                    LogClass.SingletonInstance.WriteLogEnqueue(adTmp.ToString(), LogClass.ForewardLog);
                }
            }
            if (ReverseRun)
            {
                double adTmp = 0;
                if (MainClass.instance().ReadDAMPressure(out adTmp))
                {
                    LogClass.SingletonInstance.WriteLogEnqueue(adTmp.ToString(), LogClass.ReverseLog);
                }
            }
            TxtCurCoord.Text =PLC.CurCoord.Data[0].ToString(("##0.00"));
            TxtAccCurSpeed.Text = PLC.AccCurSpeed.Data[0].ToString(("##0.00"));
            TxtDecCurSpeed.Text = PLC.DecCurSpeed.Data[0].ToString(("##0.00"));

        }
        private void HomeFinishCheck()
        {

            if (PLCClass.SingletonInstance.PLCW10.Data[3])
            {
                MainClass.GoHomeFinish = true;
                BtnHome.Enabled = false;
                BtnForewardRun.Enabled = true;
                BtnReverseRun.Enabled = true;
                BtnLocationRun.Enabled = true;
                BtnBackRun.Enabled = true;
                BtnAccRun.Enabled = true;
                BtnDecRun.Enabled = true;
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

        private void BtnCreatConnect_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void BtnCreatConnect_Click(object sender, EventArgs e)
        {
            bool ret = MainClass.instance().ConnectToDAM();
            if (ret)
            {
                LblDAMConnState.Text = "已连接";
                LblDAMConnState.BackColor = Color.LightGreen;
                MsgofMainFrm("温度压力模块连接成功!", LogType.FlowLog, false);
            }
            else
            {
                LblDAMConnState.Text = "未连接";
                LblDAMConnState.BackColor = Color.Pink;
                MsgofMainFrm("温度压力模块连接失败!", LogType.FlowLog, true);
                 return;
            }
            ret = MainClass.instance().CreatConnectionToPLC();
            if (ret)
            {
                PLC.PLCWrite(PLC.CreatConnection, false);

                if (PLC.PLCWrite(PLC.CreatConnection, true))
                {
                    PLC.PLCRead(PLC.PLCW1);
                    Delay(100);
                    if (PLC.PLCW1.Data[1])
                    {
                        LblPLCConnState.Text = "已连接";
                        LblPLCConnState.BackColor = Color.LightGreen;
                        MsgofMainFrm("PLC连接成功!", LogType.FlowLog, false);
                        BtnHome.Enabled = true;
                        BtnPause.Enabled = true;
                        BtnAlarmReset.Enabled = true;
                        HomeFinishCheck();
                        TmrRefresh.Enabled = true;
                        BtnCreatConnect.Enabled = false;
                        BtnForewardRun.Enabled= true;
                        BtnReverseRun.Enabled = true;
                        PressureCurveTSMI.Enabled = true;
                        TorqueCurveTSMI.Enabled = true;
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
                            LblPLCConnState.Text = "已连接";
                            LblPLCConnState.BackColor = Color.LightGreen;
                            MsgofMainFrm("PLC连接成功!", LogType.FlowLog, false);
                            BtnHome.Enabled = true;
                            BtnPause.Enabled = true;
                            BtnAlarmReset.Enabled = true;
                            HomeFinishCheck();
                            TmrRefresh.Enabled = true;
                            BtnCreatConnect.Enabled = false;
                            BtnForewardRun.Enabled = true;
                            BtnReverseRun.Enabled = true;
                            PressureCurveTSMI.Enabled = true;
                            TorqueCurveTSMI.Enabled = true;
                        }
                        else
                        {
                            LblPLCConnState.Text = "未连接";
                            LblPLCConnState.BackColor = Color.Pink;
                            MsgofMainFrm("PLC连接失败!", LogType.FlowLog, false);
                        }

                        //LblPLCConnState.Text = "未连接";
                        //LblPLCConnState.BackColor = Color.Pink;
                        //MsgofMainFrm("PLC连接失败!", LogType.FlowLog, false);
                    }
                }
                else
                {
                    LblPLCConnState.Text = "未连接";
                    LblPLCConnState.BackColor = Color.Pink;
                    MsgofMainFrm("PLC连接失败!", LogType.FlowLog, false);
                }
                Delay(500);
                PLC.PLCWrite(PLC.CreatConnection, false);
            }
            else
            {
                LblPLCConnState.Text = "未连接";
                LblPLCConnState.BackColor = Color.Pink;
                MsgofMainFrm("PLC连接失败!", LogType.FlowLog, false);
            }
        }

        private void BtnHome_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void BtnHome_MouseUp(object sender, MouseEventArgs e)
        {
            //PLC.PLCWrite(PLC.HomeStart, false);
        }

        private void BtnPause_MouseDown(object sender, MouseEventArgs e)
        {
          
        }

        private void BtnPause_MouseUp(object sender, MouseEventArgs e)
        {
            //PLC.PLCWrite(PLC.Stop, false);
        }

        private void BtnAlarmReset_MouseDown(object sender, MouseEventArgs e)
        {
           
        }


        private void BtnAlarmReset_MouseUp(object sender, MouseEventArgs e)
        {
           
            //PLC.PLCWrite(PLC.AlarmReset, false);
            
        }

        private void BtnForewardRun_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                float curCoord = float.Parse(TxtCurCoord.Text.Trim());
                float manualSpeed = float.Parse(TxtManualSpeed.Text.Trim());
                if (manualSpeed < 0|| manualSpeed >1000) 
                {
                    MsgofMainFrm("手动速度设置错误(速度范围0-1000mm/s）！", LogType.FlowLog, true);
                    return; 
                }
                if (PLC.PLCWrite(PLC.ManualSpeed, manualSpeed))
                {
                    MsgofMainFrm("发送PLC手动速度参数成功！", LogType.FlowLog, false);
                }
                else
                {
                    MsgofMainFrm("发送PLC手动速度参数失败！", LogType.FlowLog, true);
                }
                //PLC.PLCWrite(PLC.ForewardRun, false);
                Delay(100);
                if (PLC.PLCWrite(PLC.ForewardRun, true))
                {
                    MsgofMainFrm("发送PLC正转信号成功，开始正转运行！", LogType.FlowLog, false);
                    Config.WriteINIConfig("ManualSpeed", manualSpeed.ToString());
                    LblBackRun.Text = "未折返运行";
                    LblBackRun.BackColor = Color.Transparent;
                    LblLocationRun.Text = "未定位运行";
                    LblLocationRun.BackColor = Color.Transparent;

                    LblAccRun.Text = "未恒加速运行";
                    LblAccRun.BackColor = Color.Transparent;
                    LblDecRun.Text = "未恒减速运行";
                    LblDecRun.BackColor = Color.Transparent;
                    ForewardRun = true;
                    LogClass.SingletonInstance.WriteLogEnqueue("正转运行开始", LogClass.ForewardLog);
                }
                else
                {
                    MsgofMainFrm("发送PLC正转信号失败！", LogType.FlowLog, false);
                }
            }
            catch (Exception ex)
            {
                MsgofMainFrm("发送PLC正转信号失败！ex:"+ex.Message, LogType.FlowLog, false);
            }
            //Delay(500);
            //PLC.PLCWrite(PLC.ForewardRun, false);
        }

        private void BtnReverseRun_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                float curCoord = float.Parse(TxtCurCoord.Text.Trim());
                float manualSpeed = float.Parse(TxtManualSpeed.Text.Trim());
                if (manualSpeed < 0 || manualSpeed > 1000)
                {
                    MsgofMainFrm("手动速度设置错误(速度范围0-1000mm/s）！", LogType.FlowLog, true);
                    return;
                }
                if (PLC.PLCWrite(PLC.ManualSpeed, manualSpeed))
                {
                    MsgofMainFrm("发送PLC手动速度参数成功！", LogType.FlowLog, false);


                }
                else
                {
                    MsgofMainFrm("发送PLC手动速度参数失败！", LogType.FlowLog, true);
                }
                //PLC.PLCWrite(PLC.ReverseRun, false);
                Delay(100);
                if (PLC.PLCWrite(PLC.ReverseRun, true))
                {
                    MsgofMainFrm("发送PLC反转信号成功，开始反转运行！", LogType.FlowLog, false);
                    Config.WriteINIConfig("ManualSpeed", manualSpeed.ToString());
                    LblBackRun.Text = "未折返运行";
                    LblBackRun.BackColor = Color.Transparent;
                    LblLocationRun.Text = "未定位运行";
                    LblLocationRun.BackColor = Color.Transparent;

                    LblAccRun.Text = "未恒加速运行";
                    LblAccRun.BackColor = Color.Transparent;
                    LblDecRun.Text = "未恒减速运行";
                    LblDecRun.BackColor = Color.Transparent;
                    ReverseRun = true;
                    LogClass.SingletonInstance.WriteLogEnqueue("反转运行开始", LogClass.ReverseLog);
                }
                else
                {
                    MsgofMainFrm("发送PLC反转信号失败！", LogType.FlowLog, false);
                }
            }
            catch (Exception ex)
            {
                MsgofMainFrm("发送PLC反转信号失败！ex"+ ex.Message, LogType.FlowLog, false);
            }
            //Delay(500);
            //PLC.PLCWrite(PLC.ReverseRun, false);
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

        private void BtnForewardRun_MouseUp(object sender, MouseEventArgs e)
        {
            PLC.PLCWrite(PLC.ForewardRun, false);
            PLC.PLCWrite(PLC.ManualSpeed, 0.0F);
            MsgofMainFrm("复位PLC正转信号成功，停止正转运行！", LogType.FlowLog, false);
            ForewardRun = false;
            LogClass.SingletonInstance.WriteLogEnqueue("正转运行结束", LogClass.ForewardLog);
        }

        private void BtnReverseRun_MouseUp(object sender, MouseEventArgs e)
        {
            PLC.PLCWrite(PLC.ReverseRun, false);
            PLC.PLCWrite(PLC.ManualSpeed, 0.0F);
            MsgofMainFrm("复位PLC反转信号成功，停止反转运行！", LogType.FlowLog, false);
            ReverseRun = false;
            LogClass.SingletonInstance.WriteLogEnqueue("反转运行结束", LogClass.ReverseLog);
        }

        private void EnableButton(bool enable)
        {
            if (enable)
            {
                BtnLocationRun.Enabled = true;
                BtnBackRun.Enabled = true;
                BtnAccRun.Enabled = true;
                BtnDecRun.Enabled = true;
                BtnForewardRun.Enabled = true;
                BtnReverseRun.Enabled = true;
            }
            else
            {
                BtnLocationRun.Enabled = false;
                BtnBackRun.Enabled = false;
                BtnAccRun.Enabled = false;
                BtnDecRun.Enabled = false;
                BtnForewardRun.Enabled = false;
                BtnReverseRun.Enabled = false;
            }
        }

        private void BtnLocationRun_MouseDown(object sender, MouseEventArgs e)
        {
          
        }

        private void BtnLocationRun_MouseUp(object sender, MouseEventArgs e)
        {
           
            //PLC.PLCWrite(PLC.LocationRun, false);
            //PLC.PLCWrite(PLC.LocationSpeed, 0.0F);
            //PLC.PLCWrite(PLC.LocationCoord, 0.0F);
            //PLC.PLCWrite(PLC.LocationInitSpeed, 0.0F);
        }

        private void BtnBackRun_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void BtnBackRun_MouseUp(object sender, MouseEventArgs e)
        {
            //PLC.PLCWrite(PLC.BackRun, false);
            //PLC.PLCWrite(PLC.BackSpeed, 0.0F);
            //PLC.PLCWrite(PLC.BackCoord, 0.0F);
            //PLC.PLCWrite(PLC.BackInitSpeed, 0.0F);
        }

        private void BtnAccRun_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void BtnAccRun_MouseUp(object sender, MouseEventArgs e)
        {
            //PLC.PLCWrite(PLC.AccRun, false);
            //PLC.PLCWrite(PLC.AccDestSpeed, 0.0F);
            //PLC.PLCWrite(PLC.AccValue, 0.0F);
        }

        private void BtnDecRun_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void BtnDecRun_MouseUp(object sender, MouseEventArgs e)
        {
            //PLC.PLCWrite(PLC.DecRun, false);
            //PLC.PLCWrite(PLC.DecDestSpeed, 0.0F);
            //PLC.PLCWrite(PLC.DecValue, 0.0F);
        }

        private void BtnCreatConnect_MouseUp(object sender, MouseEventArgs e)
        {
            //PLC.PLCWrite(PLC.CreatConnection, false);
            
        }

        private void TmrRefresh_Tick(object sender, EventArgs e)
        {
            RefreshDisplay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Config.WriteINIConfig("ManualSpeed", "30");
            //Config.WriteINIConfig("LocationSpeed", "31");
            //Config.WriteINIConfig("LocationCoord", "32");
            //Config.WriteINIConfig("LocationInitSpeed", "33");
            //Config.WriteINIConfig("BackSpeed", "34");
            //Config.WriteINIConfig("BackCoord", "35");
            //Config.WriteINIConfig("BackInitSpeed", "36");
            //Config.WriteINIConfig("AccDestSpeed", "37");
            //Config.WriteINIConfig("AccValue", "38");
            //Config.WriteINIConfig("AccPressLimit", "39");
            //Config.WriteINIConfig("AccPressCycle", "40");
            //Config.WriteINIConfig("DecDestSpeed", "41");
            //Config.WriteINIConfig("DecValue", "42");
            //Config.WriteINIConfig("DecPressLimit", "43");
            //Config.WriteINIConfig("DecPressCycle", "44");

            MainClass.SetPressure = 40;
        }

        private void BtnAccRun_Click(object sender, EventArgs e)
        {
            DisplayCurveWindow();
            try
            {
                float accDestSpeed = float.Parse(TxtAccDestSpeed.Text.Trim());
                float accValue = float.Parse(TxtAccValue.Text.Trim());
                float accPressLimit = float.Parse(TxtAccPressLimit.Text.Trim());
                int accPressCycle = int.Parse(TxtAccPressCycle.Text.Trim());
                if (accDestSpeed < 0 || accValue < 0 || accPressLimit < -200 || accPressCycle < 10||
                    accDestSpeed >1000 || accValue >1000 || accPressLimit >200 || accPressCycle >60000)
                {
                    MsgofMainFrm("加速运行参数设置错误（目标速度及加速度范围0-1000mm/s，压力限制范围-200~200N，采集周期10-60000us）！", LogType.FlowLog, true);
                    return;
                }
                if (PLC.PLCWrite(PLC.AccDestSpeed, accDestSpeed) && PLC.PLCWrite(PLC.AccValue, accValue))
                {
                    MsgofMainFrm("发送PLC加速运行参数成功！", LogType.FlowLog, false);
                }
                else
                {
                    MsgofMainFrm("发送PLC加速运行参数失败！", LogType.FlowLog, true);
                }
                PLC.PLCWrite(PLC.AccRun, false);
                Delay(100);
                if (PLC.PLCWrite(PLC.AccRun, true))
                {
                   // FormPressureCurve.FrmPressureCurve.InitChartTorque();
                    FormPressureCurve.FrmPressureCurve.InitChartPressure();
                    FormPressureCurve.FrmPressureCurve.ChartPressure.Series[0].Points.Clear();
                    MainClass.instance().StartPressureTimer(accPressCycle);
                    MainClass.AccRunStart = true;
                    MainClass.SetPressure = accPressLimit;
                    MainClass.PressureArrival = false;
                    EnableButton(false);
                    MsgofMainFrm("发送PLC加速运行信号成功，开始采集压力数据！", LogType.FlowLog, false);
                    LogClass.SingletonInstance.WriteLogEnqueue("开始采集压力数据", LogClass.PressureLog);

                    LblAccRun.Text = "恒加速运行开始";
                    LblAccRun.BackColor = Color.LightGreen;
                    LblLocationRun.Text = "未定位运行";
                    LblLocationRun.BackColor = Color.Transparent;
                    LblBackRun.Text = "未折返运行";
                    LblBackRun.BackColor = Color.Transparent;
                   
                    LblDecRun.Text = "未恒减速运行";
                    LblDecRun.BackColor = Color.Transparent;
                    Config.WriteINIConfig("AccDestSpeed", accDestSpeed.ToString());
                    Config.WriteINIConfig("AccValue", accValue.ToString());
                    Config.WriteINIConfig("AccPressLimit", accPressLimit.ToString());
                    Config.WriteINIConfig("AccPressCycle", accPressCycle.ToString());
                }
                else
                {
                    MsgofMainFrm("发送PLC加速运行信号失败！", LogType.FlowLog, false);
                }
            }
            catch (Exception ex)
            {
                MsgofMainFrm("发送PLC加速运行信号失败！ex"+ ex.Message, LogType.FlowLog, false);
            }
            Delay(500);
            PLC.PLCWrite(PLC.AccRun, false);
        }

        public bool InitMoveParam()
        {
            try
            {
                ConfigClass config = new ConfigClass();
                TxtManualSpeed.Text = config.ReadINIConfig("ManualSpeed", "Move");
                TxtLocationSpeed.Text = config.ReadINIConfig("LocationSpeed", "Move");
                TxtLocationInitSpeed.Text = config.ReadINIConfig("LocationInitSpeed", "Move");
                TxtLocationCoord.Text = config.ReadINIConfig("LocationCoord", "Move");
                TxtBackSpeed.Text = config.ReadINIConfig("BackSpeed", "Move");
                TxtBackInitSpeed.Text = config.ReadINIConfig("BackInitSpeed", "Move");
                TxtBackCoord.Text = config.ReadINIConfig("BackCoord", "Move");
                TxtAccPressLimit.Text = config.ReadINIConfig("AccPressLimit", "Move");
                TxtAccDestSpeed.Text = config.ReadINIConfig("AccDestSpeed", "Move");
                TxtAccPressCycle.Text = config.ReadINIConfig("AccPressCycle", "Move");
                TxtAccValue.Text = config.ReadINIConfig("AccValue", "Move");
                TxtDecPressLimit.Text = config.ReadINIConfig("DecPressLimit", "Move");
                TxtDecDestSpeed.Text = config.ReadINIConfig("DecDestSpeed", "Move");
                TxtDecPressCycle.Text = config.ReadINIConfig("DecPressCycle", "Move");
                TxtDecValue.Text = config.ReadINIConfig("DecValue", "Move");
                float accPressLimit = float.Parse(TxtAccPressLimit.Text.Trim());
                float decPressLimit = float.Parse(TxtDecPressLimit.Text.Trim());
                if (accPressLimit > 200 || accPressLimit < -200 || decPressLimit > 200 || decPressLimit < -200)
                {
                    MsgofMainFrm("加速或减速压力限制参数设定错误（正确范围-200~200），" +
                                 "请在配置文件db/Configuration.ini中修改AccPressLimit和DecPressLimit两项参数至正确范围再重启程序！", LogType.FlowLog, true);
                    return false;
                }
                if (accPressLimit < decPressLimit)
                {
                    MainClass.SetPressure = accPressLimit;
                }
                {
                    MainClass.SetPressure = decPressLimit;
                }
                return true;
            }
            catch (Exception ex)
            {
                MsgofMainFrm("运动参数设置错误，请检查配置文件后重启程序！" + ex.Message, LogType.FlowLog, true);
                return false;
            }
        }

        private void BtnLocationRun_Click(object sender, EventArgs e)
        {
            try
            {
                float locationSpeed = float.Parse(TxtLocationSpeed.Text.Trim());
                float locationCoord = float.Parse(TxtLocationCoord.Text.Trim());
                float locationInitSpeed = float.Parse(TxtLocationInitSpeed.Text.Trim());
                if (locationSpeed < 0 || locationCoord < 0 || locationInitSpeed < 0||
                    locationSpeed >1000 || locationCoord > 600 || locationInitSpeed > 1000)
                {
                    MsgofMainFrm("定位运行参数设置错误（速度及初始速度范围0-1000mm/s，坐标范围0-600mm）！", LogType.FlowLog, true);
                    return;
                }
                if (PLC.PLCWrite(PLC.LocationSpeed, locationSpeed) && PLC.PLCWrite(PLC.LocationCoord, locationCoord)
                    && PLC.PLCWrite(PLC.LocationInitSpeed, locationInitSpeed))
                {

                    MsgofMainFrm("发送PLC定位运行参数成功！", LogType.FlowLog, false);
                }
                else
                {
                    MsgofMainFrm("发送PLC定位运行参数失败！", LogType.FlowLog, true);
                }
                PLC.PLCWrite(PLC.LocationRun, false);
                Delay(100);
                if (PLC.PLCWrite(PLC.LocationRun, true))
                {
                    MainClass.LocationRunStart = true;
                    EnableButton(false);
                    LblLocationRun.Text = "定位运行开始";
                    LblLocationRun.BackColor = Color.LightGreen;
               
                    LblBackRun.Text = "未折返运行";
                    LblBackRun.BackColor = Color.Transparent;
                    LblAccRun.Text = "未恒加速运行";
                    LblAccRun.BackColor = Color.Transparent;
                    LblDecRun.Text = "未恒减速运行";
                    LblDecRun.BackColor = Color.Transparent;
                    MsgofMainFrm("发送PLC定位运行信号成功！", LogType.FlowLog, false);
                    Config.WriteINIConfig("LocationSpeed", locationSpeed.ToString());
                    Config.WriteINIConfig("LocationCoord", locationCoord.ToString());
                    Config.WriteINIConfig("LocationInitSpeed", locationInitSpeed.ToString());
                }
                else
                {
                    MsgofMainFrm("发送PLC定位运行信号失败！", LogType.FlowLog, false);
                }
            }
            catch (Exception ex)
            {
                MsgofMainFrm("发送PLC定位运行信号失败！ex"+ ex.Message, LogType.FlowLog, false);
            }
            Delay(500);
            PLC.PLCWrite(PLC.LocationRun, false);
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            object obj = null;
            MouseEventArgs mouseEvent = null;
            BtnAlarmReset_MouseDown(obj, mouseEvent);
            PLC.PLCWrite(PLC.HomeStart, false);

            if (!PLC.PLCI0.Data[0])
            {
                MsgofMainFrm("请复位急停按钮后再回原点！", LogType.AlarmLog, true);
                return;
            }
            if (PLC.PLCW1.Data[6] == false && PLC.PLCI0.Data[3] == false)
            {
                if (PLC.PLCWrite(PLC.HomeStart, true))
                {
                    BtnHome.Enabled = false;
                    MainClass.GoHomeFinish = false;
                    MainClass.GoHomeTimeout = false;
                    MainClass.GoHomeStart = true;
                    MsgofMainFrm("开始回原点！", LogType.FlowLog, false);
                    LblOriginState.Text = "回原点运行中";
                    LblOriginState.BackColor = Color.Pink;
                }
                else
                {
                    MsgofMainFrm("回原点失败！", LogType.FlowLog, true);
                }
            }
            else
            {
                MsgofMainFrm("检测到PLC或伺服报警信号，请复位后再回原点！", LogType.AlarmLog, true);
            }
            Delay(500);
            PLC.PLCWrite(PLC.HomeStart, false);
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            PLC.PLCWrite(PLC.Stop, false);

            if (PLC.PLCWrite(PLC.Stop, true))
            {
                MainClass.instance().StopTimer();
                MsgofMainFrm("发送PLC停止信号成功！", LogType.FlowLog, false);
                LblBackRun.Text = "未折返运行";
                LblBackRun.BackColor = Color.Transparent;
                LblLocationRun.Text = "未定位运行";
                LblLocationRun.BackColor = Color.Transparent;
                LblAccRun.Text = "未恒加速运行";
                LblAccRun.BackColor = Color.Transparent;
                LblDecRun.Text = "未恒减速运行";
                LblDecRun.BackColor = Color.Transparent;
            }
            else
            {

                MsgofMainFrm("发送PLC停止信号失败！", LogType.FlowLog, false);
            }
            Delay(500);
            PLC.PLCWrite(PLC.Stop, false);
            EnableButton(true);
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
                LblPLCAlarm.Text = "未发生PLC报警";
                LblPLCAlarm.BackColor = Color.LightGreen;
                LblServoAlarm.Text = "未发生伺服报警";
                LblServoAlarm.BackColor = Color.LightGreen;
                LblEmergAlarm.Text = "未发生急停报警";
                LblEmergAlarm.BackColor = Color.LightGreen;
            }
            else
            {

                MsgofMainFrm("发送PLC复位信号失败！", LogType.FlowLog, false);
            }
            Delay(500);
            PLC.PLCWrite(PLC.AlarmReset, false);
        }

        private void BtnBackRun_Click(object sender, EventArgs e)
        {
            try
            {
                float backSpeed = float.Parse(TxtBackSpeed.Text.Trim());
                float backCoord = float.Parse(TxtBackCoord.Text.Trim());
                float backInitSpeed = float.Parse(TxtBackInitSpeed.Text.Trim());
                if (backSpeed < 0 || backCoord < 0 || backInitSpeed < 0||
                    backSpeed >1000 || backCoord >600 || backInitSpeed >1000)
                {
                    MsgofMainFrm("折返运行参数设置错误（速度及初始速度范围0-1000mm/s，坐标范围0-600mm）！", LogType.FlowLog, true);
                    return;
                }
                Delay(100);
                if (PLC.PLCWrite(PLC.BackSpeed, backSpeed) && PLC.PLCWrite(PLC.BackCoord, backCoord)
                    && PLC.PLCWrite(PLC.BackInitSpeed, backInitSpeed))
                {
                    MsgofMainFrm("发送PLC折返运行参数成功！", LogType.FlowLog, false);
                }
                else
                {
                    MsgofMainFrm("发送PLC折返运行参数失败！", LogType.FlowLog, true);
                }
                PLC.PLCWrite(PLC.BackRun, false);
                Delay(100);
                if (PLC.PLCWrite(PLC.BackRun, true))
                {
                    MainClass.BackRunStart = true;
                    EnableButton(false);
                    LblBackRun.Text = "折返运行开始";
                    LblBackRun.BackColor = Color.LightGreen;
                    LblLocationRun.Text = "未定位运行";
                    LblLocationRun.BackColor = Color.Transparent;
                  
                    LblAccRun.Text = "未恒加速运行";
                    LblAccRun.BackColor = Color.Transparent;
                    LblDecRun.Text = "未恒减速运行";
                    LblDecRun.BackColor = Color.Transparent;
                    MsgofMainFrm("发送PLC折返运行信号成功！", LogType.FlowLog, false);
                    Config.WriteINIConfig("BackSpeed", backSpeed.ToString());
                    Config.WriteINIConfig("BackCoord", backCoord.ToString());
                    Config.WriteINIConfig("BackInitSpeed", backInitSpeed.ToString());
                }
                else
                {
                    MsgofMainFrm("发送PLC折返运行信号失败！", LogType.FlowLog, false);
                }
            }
            catch (Exception ex)
            {
                MsgofMainFrm("发送PLC定位运行信号失败！ex:"+ ex.Message, LogType.FlowLog, false);
            }
            Delay(500);
            PLC.PLCWrite(PLC.BackRun, false);
        }

        private void BtnDecRun_Click(object sender, EventArgs e)
        {
            DisplayCurveWindow();
            try
            {
                float decDestSpeed = float.Parse(TxtDecDestSpeed.Text.Trim());
                float decValue = float.Parse(TxtDecValue.Text.Trim());
                float decPressLimit = float.Parse(TxtDecPressLimit.Text.Trim());
                int decPressCycle = int.Parse(TxtDecPressCycle.Text.Trim());
                if (decDestSpeed < 0 || decValue < 0 || decPressLimit < -200 || decPressCycle < 10||
                    decDestSpeed >1000 || decValue >1000 || decPressLimit >200 || decPressCycle >60000)
                {
                    MsgofMainFrm("减速运行参数设置错误（目标速度及加速度范围0-1000mm/s，压力限制范围-200~200N，采集周期10-60000us）！", LogType.FlowLog, true);
                    return;
                }
                if (PLC.PLCWrite(PLC.DecDestSpeed, decDestSpeed) && PLC.PLCWrite(PLC.DecValue, decValue))
                {
                    MsgofMainFrm("发送PLC减速运行参数成功！", LogType.FlowLog, false);
                }
                else
                {
                    MsgofMainFrm("发送PLC减速运行参数失败！", LogType.FlowLog, true);
                }
                PLC.PLCWrite(PLC.DecRun, false);
                Delay(100);
                if (PLC.PLCWrite(PLC.DecRun, true))
                {
                    //FormPressureCurve.FrmPressureCurve.InitChartTorque();
                    FormPressureCurve.FrmPressureCurve.InitChartPressure();
                    FormPressureCurve.FrmPressureCurve.ChartPressure.Series[0].Points.Clear();
                    //FormPressureCurve.FrmPressureCurve.ChartTorque.Series[0].Points.Clear();
                    MainClass.instance().StartPressureTimer(decPressCycle);
                    MainClass.DecRunStart = true;
                    MainClass.PressureArrival = false;
                    MainClass.SetPressure = decPressLimit;
                    EnableButton(false);
                    MsgofMainFrm("发送PLC减速运行信号成功，开始采集压力数据！", LogType.FlowLog, false);
                    LogClass.SingletonInstance.WriteLogEnqueue("开始采集压力数据", LogClass.PressureLog);
                    LblDecRun.Text = "恒减速运行开始";
                    LblDecRun.BackColor = Color.LightGreen;
                    LblLocationRun.Text = "未定位运行";
                    LblLocationRun.BackColor = Color.Transparent;
                    LblBackRun.Text = "未折返运行";
                    LblBackRun.BackColor = Color.Transparent;
                    LblAccRun.Text = "未恒加速运行";
                    LblAccRun.BackColor = Color.Transparent;
               
                    Config.WriteINIConfig("DecDestSpeed", decDestSpeed.ToString());
                    Config.WriteINIConfig("DecValue", decValue.ToString());
                    Config.WriteINIConfig("DecPressLimit", decPressLimit.ToString());
                    Config.WriteINIConfig("DecPressCycle", decPressCycle.ToString());
                }
                else
                {
                    MsgofMainFrm("发送PLC减速运行信号失败！", LogType.FlowLog, false);
                }
            }
            catch (Exception ex)
            {
                MsgofMainFrm("发送PLC减速运行信号失败！ex:"+ ex.Message, LogType.FlowLog, false);
            }
            Delay(500);
            PLC.PLCWrite(PLC.DecRun, false);
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
                    MainClass.instance().DisconnectToDAM();
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

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Double ADTmp = 10.2;
            LogClass.SingletonInstance.WriteLog("反转开始", LogClass.ReverseLog);
            LogClass.SingletonInstance.WriteLog(ADTmp.ToString(), LogClass.ReverseLog);
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            LogClass.SingletonInstance.WriteLog("反转结束", LogClass.ReverseLog);
        }
    }
    }


using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace PhaseFraction
{

    class MainClass
    {
        public static System.Timers.Timer Maintimer;
        private readonly Stopwatch ProgramCycleTime = new Stopwatch();
        private readonly Stopwatch MachineCycleTime = new Stopwatch();
        public Thread ReadPLCThread;
        public Thread MainThread;
        public delegate void delegatetimer(object source, System.Timers.ElapsedEventArgs e);
        public delegate void DelegateBreak();
        public delegate void DelegateReadPLC();
        public delegate void DelegateMain();
        //private readonly PLCClass PLC = PLCClass.SingletonInstance;
        private static readonly ReaderWriterLock Locker = new ReaderWriterLock();
        private static readonly AutoResetEvent EventReadPLC = new AutoResetEvent(false);
        private static readonly AutoResetEvent EventMain = new AutoResetEvent(false);
        private readonly TimeoutUtilsClass TimeChk1 = new TimeoutUtilsClass();
        private readonly TimeoutUtilsClass TimeChk2 = new TimeoutUtilsClass();
        
        public static SerialPort SerialPortScaner = new SerialPort();
        public delegate void delegateDisplay(byte[] inputByte);
        public static delegateDisplay DeleReceive;
        public static Alarmshow MsgofMain = null;   //報警(寫在ggevent函數內)
        public static MainClass m_instance;
        public static int AutoGoHomeStep;
        public static int AutoLocationRunStep;
        public static int AutoBackRunStep;
        public static int AutoAccRunStep;
        public static int AutoDecRunStep;
        public static bool GoHomeStart;
        public static bool GoHomeFinish;
        public static bool GoHomeTimeout;
        public static bool LocationRunStart;
        public static bool LocationRunFinish;
        public static bool LocationRunTimeout;
        public static bool BackRunStart;
        public static bool BackRunFinish;
        public static bool BackRunTimeout;
        public static bool AccRunStart;
        public static bool AccRunFinish;
        public static bool AccRunTimeout;
        public static bool DecRunStart;
        public static bool DecRunFinish;
        public static bool DecRunTimeout;
        public static bool PressureArrival;
        public static float CurPressure;
        public static float SetPressure;
        public Thread ProcessThread = null;
        FinsCom.PlcCom OmronCom = new FinsCom.PlcCom();
        IntPtr DAMDevice;                        //设备句柄
        public static System.Timers.Timer Timer;
        Stopwatch stopwatch = new Stopwatch();
        const int iSleepTime = 150;          //延遲150ms
        public static MainClass instance() { if (m_instance == null) m_instance = new MainClass(); return m_instance; }
        public MainClass() { }
       
        public delegate void DelegateFormMain(double analogData1, double analogData2);
        public static UpdateChart DataOfChartTorque = null;
        public static UpdateChart DataOfChartPressure = null;
        public delegate void DelegateDisplay(string barcode, string lotNo = "**********", string num = "0");

        public static Int32 ADDeviceID = 1;                  //设备地址
        public static Int32 ADChannelNum = 4;                //通道号
        public static Single ADUpperRange1 = 10;                //量程最大值
        public static Single ADLowRange1 = 0;                  //量程最小值
        public static Single ADUpperRange2 = 10;                //量程最大值
        public static Single ADLowRange2 = 0;                  //量程最小值
        public static UInt32[] ADBuffer = new UInt32[32];  //采集数据缓冲区
        public static Single ADLsbType = 65535.0F;                //码值范围
        public static Double ADTmp = 0.0F;                    //码值转换后的浮值
        public static Int32 AdAddress = 256;
        public static Int32 ADComID = 1;                      //串口
        public static Int32 ADBaud = 9600;                       //波特率
        public static Int32 ADDataBits = 8;
        public static Int32 ADStopBits = 0;
        public static Int32 ADParity = 0;
        public static Int32 LoopTime = 100;
        public static Int32 Analog1 = 0;
        public static Int32 Analog2 = 1;
        public static bool IsLog = false;
        public static bool IsConnectPLC = false;
        public static string PLCIP = String.Empty ;
        public static string LocalIP = String.Empty;
        public static string WLANIP = String.Empty;
        public static int PLCPort = 9600;
        public static int LocalPort = 9600;
        public static int WLANPort = 8080;


        const Int32 MAX_PATH = 260;

        public void RunMainClass()
        {

            //Maintimer = new System.Timers.Timer(100);
            //Maintimer.Elapsed += new System.Timers.ElapsedEventHandler(Main);
            //Maintimer.AutoReset = true;
            //Maintimer.Enabled = true;

            MainThread = new Thread(Main)
            {
                IsBackground = true,
                Priority = ThreadPriority.Normal
            };
            MainThread.Start();

            ReadPLCThread = new Thread(ReadPLC)
            {
                IsBackground = true,
                Priority = ThreadPriority.Normal
            };
            ReadPLCThread.Start();
            EventReadPLC.Set();
        }

        public void Main()
        {
            //if (MainForm.MainFrm.InvokeRequired)
            //{
            //    MainForm.MainFrm.BeginInvoke(new DelegateMain(Main));
            //}
            //else
            //{
            //LogClass log = LogClass.SingletonInstance;
            while (true)
            {
                //ProgramCycleTime.Start();
                Application.DoEvents();
                //Locker.AcquireReaderLock(1000);
                EventMain.WaitOne();

                if (GoHomeStart)
                {
                    AutoGoHomeStep = GoHome(ref AutoGoHomeStep);
                }

                if (LocationRunStart)
                {
                    AutoLocationRunStep = LocationRun(ref AutoLocationRunStep);
                }

                if (BackRunStart)
                {
                    AutoBackRunStep = BackRun(ref AutoBackRunStep);
                }

                if (AccRunStart)
                {
                    AutoAccRunStep = AccRun(ref AutoAccRunStep);
                }

                if (DecRunStart)
                {
                    AutoDecRunStep = DecRun(ref AutoDecRunStep);
                }
                //log.WriteLog("ReadMain" + Convert.ToString(ProgramCycleTime.ElapsedMilliseconds), "FlowLog");
                //ProgramCycleTime.Reset();
                EventReadPLC.Set();
                //Locker.ReleaseReaderLock();

            }
            //}
        }

        public void ReadPLC()
        {
            PLCClass plc = PLCClass.SingletonInstance;
            while (true)
            {
                //ProgramCycleTime.Start();
                // Thread.Sleep(50);
                Application.DoEvents();
                //Locker.AcquireWriterLock(1000);
                EventReadPLC.WaitOne();
                plc.PLCRead(plc.PLCW1);
                plc.PLCRead(plc.BackFinish);
                plc.PLCRead(plc.PLCW10);
                plc.PLCRead(plc.PLCI0);

                plc.PLCRead(plc.CurCoord);
                plc.PLCRead(plc.AccCurSpeed);
                plc.PLCRead(plc.DecCurSpeed);

                //log.WriteLog("ReadPLC:" + Convert.ToString(ProgramCycleTime.ElapsedMilliseconds), "FlowLog");
                //ProgramCycleTime.Reset();
                //Locker.ReleaseWriterLock();
                EventMain.Set();

            }
        }

        public int GoHome(ref int step)
        {
            int returnValue;
            switch (step)
            {
                case 0:
                    TimeChk1.Reset();
                    step++;
                    break;
                case 1:
                    if (PLCClass.SingletonInstance.PLCW10.Data[3])
                    {
                        MsgofMain("回原点完成！", LogType.FlowLog, false);
                        GoHomeFinish = true;
                        GoHomeStart = false;
                        step = 0;
                    }
                    else if (TimeChk1.IsTimeout(180000, false))
                    {
                        GoHomeTimeout = true;
                        GoHomeStart = false;
                        GoHomeFinish = false;
                        MsgofMain("3分钟未收到回原点完成信号！", LogType.FlowLog, false);
                        step = 0;
                    }
                    break;
            }
            returnValue = step;
            return returnValue;
        }

        public int LocationRun(ref int step)
        {
            int returnValue;
            switch (step)
            {
                case 0:
                    TimeChk1.Reset();
                    step++;
                    break;
                case 1:
                    if (PLCClass.SingletonInstance.PLCW10.Data[7])
                    {
                        MsgofMain("定位运行完成！", LogType.FlowLog, false);
                        LocationRunFinish = true;
                        LocationRunStart = false;
                        step = 0;
                    }
                    else if (TimeChk1.IsTimeout(180000, false))
                    {
                        LocationRunTimeout = true;
                        LocationRunStart = false;
                        LocationRunFinish = false;
                        MsgofMain("3分钟未收到定位运行完成信号！", LogType.FlowLog, false);
                        step = 0;
                    }
                    break;
            }
            returnValue = step;
            return returnValue;
        }

        public int BackRun(ref int step)
        {
            int returnValue;
            switch (step)
            {
                case 0:
                    TimeChk1.Reset();
                    step++;
                    break;
                case 1:
                    if (PLCClass.SingletonInstance.BackFinish.Data[0])
                    {
                        MsgofMain("折返运行完成！", LogType.FlowLog, false);
                        BackRunFinish = true;
                        BackRunStart = false;
                        step = 0;
                    }
                    else if (TimeChk1.IsTimeout(180000, false))
                    {
                        BackRunTimeout = true;
                        BackRunStart = false;
                        BackRunFinish = false;
                        MsgofMain("3分钟未收到折返运行完成信号！", LogType.FlowLog, false);
                        step = 0;
                    }
                    break;
            }
            returnValue = step;
            return returnValue;
        }

        public int AccRun(ref int step)
        {
            int returnValue;
            switch (step)
            {
                case 0:
                    TimeChk1.Reset();
                    step++;
                    break;
                case 1:
                  
                    if (PressureArrival)
                    {
                        StopTimer();
                        PLCClass.SingletonInstance.PLCWrite(PLCClass.SingletonInstance.FlowFinish,true);
                        MsgofMain("到达压力设定值，写入PLCW1.05,加速运行完成！", LogType.FlowLog, false);
                        AccRunFinish = true;
                        AccRunStart = false;
                        step = 0;
                    }
                    else if (TimeChk1.IsTimeout(1800000, false))
                    {
                        StopTimer();
                        AccRunTimeout = true;
                        AccRunStart = false;
                        AccRunFinish = false;
                        MsgofMain("3分钟未收到加速运行完成信号！", LogType.FlowLog, false);
                        step = 0;
                    }
                    break;
            }
            returnValue = step;
            return returnValue;
        }

        public int DecRun(ref int step)
        {
            int returnValue;
            switch (step)
            {
                case 0:
                    TimeChk1.Reset();
                    step++;
                    break;
                case 1:
                    if ( PressureArrival)
                    {
                       StopTimer();
                        PLCClass.SingletonInstance.PLCWrite(PLCClass.SingletonInstance.FlowFinish, true);
                        MsgofMain("到达压力设定值，写入PLCW1.05,加速运行完成！", LogType.FlowLog, false);
                        DecRunFinish = true;
                        DecRunStart = false;
                        step = 0;
                    }
                    else if (PLCClass.SingletonInstance.PLCW10.Data[14] )
                    {
                        StopTimer();
                        MsgofMain("检测到PLCW10.14，减速运行完成！", LogType.FlowLog, false);
                        DecRunFinish = true;
                        DecRunStart = false;
                        step = 0;
                    }
                    else if (TimeChk1.IsTimeout(180000, false))
                    {
                        StopTimer();
                        DecRunTimeout = true;
                        DecRunStart = false;
                        DecRunFinish = false;
                        MsgofMain("3分钟未收到减速运行完成信号！", LogType.FlowLog, false);
                        step = 0;
                    }
                    break;
            }
            returnValue = step;
            return returnValue;
        }

        public static string[] GetMacAddress()
        {
            //string macAddress = "N/A";
            string[] macAddress = new string[10];
            List<string> macts = GetMacByNetworkInterface();
            // macts.Sum()

            //if (macts.Count > 0)
            //{
            //    macAddress = macts[0].ToString();
            //}
            if (macts.Count > 0)
            {
                for (int i = 0; i < macts.Count; i++)
                {
                    macAddress[i] = macts[i].ToString();
                }
            }

            return macAddress;
        }
        public static List<string> GetMacByNetworkInterface()
        {
            List<string> macs = new List<string>();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                macs.Add(ni.GetPhysicalAddress().ToString());
            }
            return macs;
        }
        public static string GetIPAddress()
        {
            string ipAddress = string.Empty;
            IPAddress[] ipAddressArray = new IPAddress[2];
            Regex regIP = new Regex("^10\\..*");
            try
            {
                ipAddressArray = System.Net.Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress ip in ipAddressArray)
                {
                    string srtIP = Convert.ToString(ip);
                    if (regIP.IsMatch(srtIP))
                    {
                        ipAddress = srtIP;
                        break;
                    }
                }
            }
            catch
            {
                return ipAddress;
            }
            return ipAddress;
        }


        public static T ObjectToEnum<T>(object obj)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), obj.ToString(), true);
            }
            catch
            {
                return default(T);
            }
        }

        public void SendDataToPLC()
        {

        }

        public void Init()
        {
            LogClass.SingletonInstance.LogRecord();
          
            bool ret = InitCommunicationParam();
            //if (ret) ret = ConnectToDAM();
            // if (ret) StartTimer();
            //if (ret) RunMainClass();
        }

        


        public bool InitCommunicationParam()
        {
            try
            {
                ConfigClass config = new ConfigClass();
                PLCIP = config.ReadINIConfig("PLCIP");
                LocalIP = config.ReadINIConfig("LocalIP");
                WLANIP = config.ReadINIConfig("WLANIP");
                PLCPort = int.Parse(config.ReadINIConfig("PLCPort"));
                LocalPort = int.Parse(config.ReadINIConfig("LocalPort"));
                WLANPort = int.Parse(config.ReadINIConfig("WLANPort"));

                string parity = config.ReadINIConfig("Parity");
                int baud = int.Parse(config.ReadINIConfig("BaudRate"));
                LoopTime = int.Parse(config.ReadINIConfig("LoopTime"));
                ADDeviceID = int.Parse(config.ReadINIConfig("DeviceID"));                  //设备地址
                ADChannelNum = int.Parse(config.ReadINIConfig("ChannelNum"));                //通道号
                ADUpperRange1 = Single.Parse(config.ReadINIConfig("UpperRange1"));                //量程最大值
                ADLowRange1 = Single.Parse(config.ReadINIConfig("LowRange1"));                  //量程最小值
                ADUpperRange2 = Single.Parse(config.ReadINIConfig("UpperRange2"));                //量程最大值
                ADLowRange2 = Single.Parse(config.ReadINIConfig("LowRange2"));                  //量程最小值
                ADComID = int.Parse(config.ReadINIConfig("PortName").Replace("COM", ""));
                ADDataBits = int.Parse(config.ReadINIConfig("DataBits"));
                ADStopBits = int.Parse(config.ReadINIConfig("StopBits"));
                Analog1 = int.Parse(config.ReadINIConfig("Analog1"));
                Analog2 = int.Parse(config.ReadINIConfig("Analog2"));
              
                return true;
            }
            catch (Exception ex)
            {
                MsgofMain("参数设置错误，请检查配置文件后重启程序！" + ex.Message, LogType.FlowLog, true);
                return false;
            }
        }
        public bool InitParam1()
        {
            try
            {
                ConfigClass config = new ConfigClass();
                PLCIP= config.ReadConfig("PLCIP");
                LocalIP = config.ReadConfig("LocalIP");
                PLCPort = int.Parse(config.ReadConfig("PLCPort"));
                LocalPort = int.Parse(config.ReadConfig("LocalPort"));

                string parity = config.ReadConfig("Parity");
                int baud = int.Parse(config.ReadConfig("BaudRate"));
                LoopTime = int.Parse(config.ReadConfig("LoopTime"));
                ADDeviceID = int.Parse(config.ReadConfig("DeviceID"));                  //设备地址
                ADChannelNum = int.Parse(config.ReadConfig("ChannelNum"));                //通道号
                //ADUpperRange = Single.Parse(config.ReadConfig("UpperRange"));                //量程最大值
                //ADLowRange = Single.Parse(config.ReadConfig("LowRange"));                  //量程最小值
                ADComID = int.Parse(config.ReadConfig("PortName").Replace("COM", ""));
                ADDataBits = int.Parse(config.ReadConfig("DataBits"));
                ADStopBits = int.Parse(config.ReadConfig("StopBits"));
                Analog1 = int.Parse(config.ReadConfig("Analog1"));
                Analog2 = int.Parse(config.ReadConfig("Analog2"));
                if (config.ReadConfig("IsLog") == "1") { IsLog = true; }
                if (parity == "0") { ADParity = DAM3000M.DAM3000M_PARITY_NONE; }
                else if (parity == "1") { ADParity = DAM3000M.DAM3000M_PARITY_ODD; }
                else if (parity == "2") { ADParity = DAM3000M.DAM3000M_PARITY_EVEN; }
                else
                {
                    MsgofMain("AD模块奇偶参数设置错误，请检查配置文件后重启程序！", LogType.FlowLog, true);
                    return false;
                }

                if (baud == 1200) { ADBaud = 0; }
                else if (baud == 2400) { ADBaud = 1; }
                else if (baud == 4800) { ADBaud = 2; }
                else if (baud == 9600) { ADBaud = 3; }
                else if (baud == 19200) { ADBaud = 4; }
                else if (baud == 38400) { ADBaud = 5; }
                else if (baud == 57600) { ADBaud = 6; }
                else if (baud == 115200) { ADBaud = 7; }
                else
                {
                    {
                        MsgofMain("AD模块波特率参数设置错误，请检查配置文件后重启程序！", LogType.FlowLog, true);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MsgofMain("AD模块参数设置错误，请检查配置文件后重启程序！" + ex.Message, LogType.FlowLog, true);
                return false;
            }
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

                if (SerialPortScaner.IsOpen) { SerialPortScaner.Close(); Thread.Sleep(500); }

                if (Variable.StopBits == "0") { stopBits = StopBits.None; }
                else if (Variable.StopBits == "1") { stopBits = StopBits.One; }
                else if (Variable.StopBits == "1.5") { stopBits = StopBits.OnePointFive; }
                else if (Variable.StopBits == "2") { stopBits = StopBits.Two; }
                else { MsgofMain("串口打開失敗，請關閉程序后重開開啟！", LogType.FlowLog, true); return; }

                if (Variable.Parity == "0") { parity = Parity.None; }
                else if (Variable.Parity == "1") { parity = Parity.Odd; }
                else if (Variable.Parity == "2") { parity = Parity.Even; }
                else if (Variable.Parity == "3") { parity = Parity.Mark; }
                else if (Variable.Parity == "4") { parity = Parity.Space; }
                else { MsgofMain("串口打開失敗，請關閉程序后重開開啟！", LogType.FlowLog, true); return; }

                SerialPortScaner.PortName = Variable.PortName;
                SerialPortScaner.BaudRate = Convert.ToInt32(Variable.BaudRate);
                SerialPortScaner.DataBits = Convert.ToInt32(Variable.DataBits);
                SerialPortScaner.StopBits = stopBits;
                SerialPortScaner.Parity = parity;
                SerialPortScaner.ReadBufferSize = 2 * 1024 * 1024;
                SerialPortScaner.ReceivedBytesThreshold = 1;
               
                SerialPortScaner.Open();
                if (SerialPortScaner.IsOpen)
                {
                   
                    MsgofMain("串口打開成功！", LogType.FlowLog, false);
                    SerialPortScaner.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
                }
                else
                {
                   

                    MsgofMain("串口打開失敗，請關閉程序后重開開啟！", LogType.FlowLog, true);
                }
            }
            catch (Exception ex)
            {
               
                MsgofMain("串口打開失敗，請關閉程序后重開開啟！" + ex.Message, LogType.FlowLog, true);
            }
        }



        public void ComLink()
        {
            try
            {

                FinsCom.PlcCom.ParityType parity;
                if (Variable.PortName == string.Empty) { Variable.PortName = "COM1"; }
                if (Variable.BaudRate == string.Empty) { Variable.BaudRate = "9600"; }
                if (Variable.DataBits == string.Empty) { Variable.DataBits = "7"; }
                if (Variable.StopBits == string.Empty) { Variable.StopBits = "2"; }
                if (Variable.Parity == string.Empty) { Variable.Parity = "2"; }


                if (Variable.Parity == "0") { parity = FinsCom.PlcCom.ParityType.None; }
                else if (Variable.Parity == "1") { parity = FinsCom.PlcCom.ParityType.Odd; }
                else if (Variable.Parity == "2") { parity = FinsCom.PlcCom.ParityType.Even; }
                else if (Variable.Parity == "3") { parity = FinsCom.PlcCom.ParityType.Mark; }
                else if (Variable.Parity == "4") { parity = FinsCom.PlcCom.ParityType.Space; }
                else { MsgofMain("PLC连接失败，請關閉程序后重開開啟！", LogType.FlowLog, true); return; }

                short re = 0;
                string restr = "";
                re = OmronCom.ComLink(Convert.ToUInt16(Variable.PortName.Substring(Variable.PortName.Length - 1, 1)),
                                 Convert.ToUInt32(Variable.BaudRate),
                                 Convert.ToUInt16(Variable.DataBits),
                                 Convert.ToUInt16(Variable.StopBits),
                                 parity,
                                 Convert.ToUInt16(2000),
                                 "DEMO");

                if (re == 0)
                {
                   
                    MsgofMain("PLC联接成功: " + restr, LogType.FlowLog, false);

                }
                else
                {
                   
                    MsgofMain("PLC联接失败: " + restr, LogType.FlowLog, true);

                }
            }
            catch (Exception ex)
            {
                
                MsgofMain("PLC联接失败:" + ex.Message, LogType.FlowLog, true);
            }
        }

        public void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(200);
            int receiveLen = SerialPortScaner.BytesToRead;
            if (receiveLen < 0)
            {
                return;
            }
            else
            {
                byte[] receiveBytes = new byte[receiveLen];
                int dataLen = SerialPortScaner.Read(receiveBytes, 0, receiveBytes.Length);
                if (dataLen > 0)
                {
                    //DeleReceive = new delegateDisplay(ReceiveByteToStr);
                    //this.Invoke(DeleReceive, receiveBytes);
                    ReceiveByteToStr(receiveBytes);
                }
            }
        }

        public void ReceiveByteToStr(byte[] inputByte)
        {
            Regex regBarcode = new Regex("^[0-9]{3}[MS]{1}[0-9]{14}$");
            Regex regDeviceNo = new Regex("^RTRPLASMA[0-9]{3}#$");
            Regex regGe_Ban = new Regex("^ZC0000000000000000$");
            Regex regCJ = new Regex("^CJ0000000000000000$");
            try
            {
                if (inputByte != null && inputByte.Length > 0)
                {
                    string barcode = Encoding.ASCII.GetString(inputByte, 0, inputByte.Length);
                    //string barcode = Encoding.UTF8.GetString(inputByte, 0, inputByte.Length);
                    //barcode = barcode.Replace("\0", "");
                    //barcode = barcode.Replace("\b", "");
                    //barcode = barcode.Replace("\n", "");
                    //barcode = barcode.Replace("\r", "");
                    barcode = barcode.Trim().ToUpper();
                    if (barcode != string.Empty)
                    {
                        MsgofMain("接收數據：" + barcode, LogType.FlowLog, false);
                        //if (regBarcode.IsMatch(barcode) || regDeviceNo.IsMatch(barcode))
                        //{
                        //    string arrBarcode = barcode.Substring(0, barcode.Length - 2);
                        //    if (!Variable.Barcode.Contains(arrBarcode))
                        //    {
                        //        ProcessBarcodeThread(barcode);
                        //    }
                        //    else
                        //    {
                        //        MsgofMain("該條碼重復：" + barcode, LogType.FlowLog, false);
                        //    }
                        //}
                        //else
                        //{
                        //    MsgofMain("該條碼不是設備編碼也不是物料二維碼：" + barcode, LogType.FlowLog, false);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MsgofMain("接收數據異常！" + ex.Message, LogType.FlowLog, false);
            }
        }

        public void ReceiveByteToStr1(byte[] inputByte)
        {
            Regex regBarcode = new Regex("^[0-9]{3}[MS]{1}[0-9]{14}$");
            Regex regDeviceNo = new Regex("^RTRPLASMA[0-9]{3}#$");
            Regex regGe_Ban = new Regex("^ZC0000000000000000$");
            Regex regCJ = new Regex("^CJ0000000000000000$");
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
                        MsgofMain("接收數據：" + barcode, LogType.FlowLog, false);
                        if (regBarcode.IsMatch(barcode) || regDeviceNo.IsMatch(barcode))
                        {
                            string arrBarcode = barcode.Substring(0, barcode.Length - 2);
                            if (!Variable.Barcode.Contains(arrBarcode))
                            {
                                ProcessBarcodeThread(barcode);
                            }
                            else
                            {
                                MsgofMain("該條碼重復：" + barcode, LogType.FlowLog, false);
                            }
                        }
                        else
                        {
                            MsgofMain("該條碼不是設備編碼也不是物料二維碼：" + barcode, LogType.FlowLog, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgofMain("接收數據異常！" + ex.Message, LogType.FlowLog, false);
            }
        }

        public bool UploadData(string barcode)
        {
            return true;
        }

        public void StoreBarcode(object barcode)
        {
            Regex regBarcode = new Regex("^[0-9]{3}[MS]{1}[0-9]{14}$");
            string strBarcode = (string)barcode;
            string lotNo = strBarcode.Substring(3, 10);
            WebServiceClass webSer = WebServiceClass.instance();
            if (regBarcode.IsMatch(strBarcode))
            {
                if (!Variable.IsBarcode && Variable.DeviceNo != string.Empty)
                {
                    string log = "機臺號," + Variable.DeviceNo + ",二維碼," + strBarcode;
                    MsgofMain(log, LogType.FlowLog, false);
                   
                    Variable.IsBarcode = true;
                    Variable.DeviceNo = string.Empty;
                }
                else
                {
                    MsgofMain("請先掃描機臺號再掃描二維碼！", LogType.FlowLog, true);
                }

            }
            else
            {
                Variable.DeviceNo = strBarcode;
                Variable.IsBarcode = false;
            }
        }

        public void ProcessBarcodeThread(string barcode)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(StoreBarcode));
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.AboveNormal;
            thread.Name = "ProcessBarcodeThread";
            thread.Start((object)barcode);

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
            MsgofMain("接收數據：" + receiveData, LogType.FlowLog, false);
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
                        MsgofMain("A掃描槍批號：" + Variable.LotNoA, LogType.FlowLog, false);
                    }
                    else if (regScanerB.IsMatch(dataAvary[i]))
                    {
                        Variable.LotNoB = dataAvary[i].Substring(0, 10);
                        MsgofMain("B掃描槍批號：" + Variable.LotNoB, LogType.FlowLog, false);
                    }
                    else if (regScanerC.IsMatch(dataAvary[i]))
                    {
                        Variable.LotNoC = dataAvary[i].Substring(0, 10);
                        MsgofMain("C掃描槍批號：" + Variable.LotNoC, LogType.FlowLog, false);
                    }
                    else if (regScanerD.IsMatch(dataAvary[i]))
                    {
                        Variable.LotNoD = dataAvary[i].Substring(0, 10);
                        MsgofMain("D掃描槍批號：" + Variable.LotNoD, LogType.FlowLog, false);
                    }
                }
                else
                {
                    MsgofMain("數據不是機臺號也不是二維碼：" + dataAvary[i], LogType.FlowLog, false);
                }
            }
        }

        public void ProcessData()
        {
            ProcessThread = new Thread(RunProcess);
            ProcessThread.IsBackground = true;
            ProcessThread.Priority = ThreadPriority.AboveNormal;
            ProcessThread.Start();
        }

        public void RunProcess()
        {
            Regex regDeviceNo = new Regex("^PNLTJZKJ[0-9]{3}#>[ABCD]{1}$");
            while (true)
            {
                //stopwatch.Start();
                Application.DoEvents();
                // Thread.Sleep(100);

                for (int i = 0; i < Variable.ScanerA.Count; i++)
                {
                    if (Variable.ScanerA[i] != null && regDeviceNo.IsMatch(Convert.ToString(Variable.ScanerA[i])))
                    {
                        if (i == 0)
                        {
                            //string deviceNo = Convert.ToString(Variable.ScanerA[i]);
                            //int len = Convert.ToString(Variable.ScanerA[i]).Length;
                            //Variable.DeviceNoA = deviceNo.Substring(0,len-2);
                            Variable.ScanerA.RemoveAt(0);
                            break;
                        }
                        else
                        {
                            //string deviceNo = Convert.ToString(Variable.ScanerA[i]);
                            //int len = Convert.ToString(Variable.ScanerA[i]).Length;
                            //Variable.DeviceNoA = deviceNo.Substring(0,len-2);
                            string[] uploadArray = new string[i + 1];
                            Variable.ScanerA.CopyTo(0, uploadArray, 0, i + 1);
                            Variable.ScanerA.RemoveRange(0, i + 1);
                            UploadToWebSer(uploadArray);
                            break;
                        }
                    }
                }

                for (int i = 0; i < Variable.ScanerB.Count; i++)
                {
                    if (Variable.ScanerB[i] != null && regDeviceNo.IsMatch(Convert.ToString(Variable.ScanerB[i])))
                    {
                        if (i == 0)
                        {
                            //string deviceNo = Convert.ToString(Variable.ScanerA[i]);
                            //int len = Convert.ToString(Variable.ScanerA[i]).Length;
                            //Variable.DeviceNoB = deviceNo.Substring(0, len - 2);
                            Variable.ScanerB.RemoveAt(0);
                            break;
                        }
                        else
                        {
                            //string deviceNo = Convert.ToString(Variable.ScanerA[i]);
                            //int len = Convert.ToString(Variable.ScanerA[i]).Length;
                            //Variable.DeviceNoB = deviceNo.Substring(0, len - 2);
                            string[] uploadArray = new string[i + 1];
                            Variable.ScanerB.CopyTo(0, uploadArray, 0, i + 1);
                            Variable.ScanerB.RemoveRange(0, i + 1);
                            UploadToWebSer(uploadArray);
                            break;
                        }
                    }
                }

                for (int i = 0; i < Variable.ScanerC.Count; i++)
                {
                    if (Variable.ScanerC[i] != null && regDeviceNo.IsMatch(Convert.ToString(Variable.ScanerC[i])))
                    {
                        if (i == 0)
                        {
                            //string deviceNo = Convert.ToString(Variable.ScanerA[i]);
                            //int len = Convert.ToString(Variable.ScanerA[i]).Length;
                            //Variable.DeviceNoC = deviceNo.Substring(0, len - 2);
                            Variable.ScanerC.RemoveAt(0);
                            break;
                        }
                        else
                        {
                            //string deviceNo = Convert.ToString(Variable.ScanerA[i]);
                            //int len = Convert.ToString(Variable.ScanerA[i]).Length;
                            //Variable.DeviceNoC = deviceNo.Substring(0, len - 2);
                            string[] uploadArray = new string[i + 1];
                            Variable.ScanerC.CopyTo(0, uploadArray, 0, i + 1);
                            Variable.ScanerC.RemoveRange(0, i + 1);
                            UploadToWebSer(uploadArray);
                            break;
                        }
                    }
                }

                for (int i = 0; i < Variable.ScanerD.Count; i++)
                {
                    if (Variable.ScanerD[i] != null && regDeviceNo.IsMatch(Convert.ToString(Variable.ScanerD[i])))
                    {
                        if (i == 0)
                        {
                            //string deviceNo = Convert.ToString(Variable.ScanerA[i]);
                            //int len = Convert.ToString(Variable.ScanerA[i]).Length;
                            //Variable.DeviceNoB = deviceNo.Substring(0, len - 2);
                            Variable.ScanerD.RemoveAt(0);
                            break;
                        }
                        else
                        {
                            //string deviceNo = Convert.ToString(Variable.ScanerA[i]);
                            //int len = Convert.ToString(Variable.ScanerA[i]).Length;
                            //Variable.DeviceNoB = deviceNo.Substring(0, len - 2);
                            string[] uploadArray = new string[i + 1];
                            Variable.ScanerD.CopyTo(0, uploadArray, 0, i + 1);
                            Variable.ScanerD.RemoveRange(0, i + 1);
                            UploadToWebSer(uploadArray);
                            break;
                        }
                    }
                }
                //MsgofMain(Convert.ToString(stopwatch.ElapsedMilliseconds), LogType.ListShow, false);
                //stopwatch.Reset();
            }
        }

        public void UploadToWebSer(string[] uploadArray)
        {
            object uploadObject = (object)uploadArray;
            Thread UploadThread = null;
            UploadThread = new Thread(new ParameterizedThreadStart(RunUpload));
            UploadThread.IsBackground = true;
            UploadThread.Priority = ThreadPriority.Normal;
            //string time = DateTime.Now.ToString("HH:mm:ss.fff");
            //UploadThread.Name =time;
            UploadThread.Start(uploadObject);
        }

        public void RunUpload(object uploadObject)
        {
            Regex regEms = new Regex("^DLAR[0-9]{8}$");
            Regex regDeviceNo = new Regex("^PNLTJZKJ[0-9]{3}#$");
            Regex regScanerA = new Regex(">A$");
            Regex regScanerB = new Regex(">B$");
            Regex regScanerC = new Regex(">C$");
            Regex regScanerD = new Regex(">D$");
            try
            {
                string[] uploadArray = (string[])uploadObject;
                string lotNo = uploadArray[0].Substring(3, 10);
                int len = uploadArray.Length;
                string deviceNo = uploadArray[len - 1].Substring(0, uploadArray[len - 1].Length - 2);
                string[] mainParam = WebServiceClass.instance().GetMainParam(lotNo, "SFCZ3_ZD_Lamination_Dtl");
                if (!regDeviceNo.IsMatch(deviceNo))
                {
                    MsgofMain("機臺號錯誤：" + deviceNo, LogType.FlowLog, false);
                    return;
                }
                string uploadLotNo = string.Empty;
                if (regScanerA.IsMatch(uploadArray[0])) { uploadLotNo = Variable.LotNoA; }
                else if (regScanerB.IsMatch(uploadArray[0])) { uploadLotNo = Variable.LotNoB; }
                else if (regScanerC.IsMatch(uploadArray[0])) { uploadLotNo = Variable.LotNoC; }
                else if (regScanerD.IsMatch(uploadArray[0])) { uploadLotNo = Variable.LotNoD; }
                ConfigClass config = new ConfigClass();
                string emsNo = config.ReadConfig(deviceNo, "deviceNoSettings");
                string slitNo = config.ReadConfig(mainParam[7], "partNoSettings");
                int subNo = 2;
                if (slitNo == string.Empty)
                {
                    MsgofMain("該料號未維護分條信息：" + mainParam[7], LogType.FlowLog, false);
                }
                else if (slitNo == "1")
                {
                    uploadArray = RemoveRepeat(uploadArray, 4);
                    subNo = 4;
                }

                if (regEms.IsMatch(emsNo))
                {
                    for (int i = 0; i < uploadArray.Length - 1; i++)
                    {
                        string barcode = uploadArray[i].Substring(0, uploadArray[i].Length - subNo);
                        WebServiceClass.instance().UpLoadBarcode(barcode, deviceNo, emsNo, Variable.IPAddress, mainParam[6], uploadLotNo);
                        //MsgofMain("記錄數據：" + barcode + "," + deviceNo, LogType.BarcodeLog, false);
                        //MsgofMain(barcode + "," + deviceNo + "," + Thread.CurrentThread.Name, LogType.BarcodeLog, false);
                    }
                }
                else
                {
                    MsgofMain("EMS編號設置錯誤！（格式為：DLAR02000270）實際為：" + emsNo, LogType.FlowLog, false);
                }
            }
            catch (Exception ex)
            {
                MsgofMain("RunUpload：" + ex.Message, LogType.FlowLog, false);
            }
        }

        public ArrayList RemoveRepeat(ArrayList inputArray, int num)
        {
            try
            {
                for (int i = 0; i < inputArray.Count; i++)
                {
                    for (int j = inputArray.Count - 1; j > i; j--)
                    {
                        string iArray = inputArray[i].ToString();
                        string jArray = inputArray[j].ToString();
                        string subIArray = iArray.Substring(0, iArray.Length - num);
                        string subJArray = jArray.Substring(0, jArray.Length - num);
                        if (subIArray == subJArray)
                        {
                            inputArray.RemoveAt(j);
                        }
                    }
                }
                return inputArray;
            }
            catch { return inputArray; }
        }

        public string[] RemoveRepeat(string[] inputArray, int subNum)
        {
            try
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
                    for (int j = inputArray.Length - 1; j > i; j--)
                    {
                        string iStr = inputArray[i].Substring(0, inputArray[i].Length - subNum);
                        string jStr = inputArray[j].Substring(0, inputArray[j].Length - subNum);
                        if (iStr == jStr)
                        {
                            inputArray[j] = string.Empty;
                            inputArray = inputArray.Where(str => !string.IsNullOrEmpty(str)).ToArray();
                        }
                    }
                }
                return inputArray;
            }
            catch { return inputArray; }
        }


        public string[] RemoveNull(string[] inputArray)
        {
            return inputArray = inputArray.Where(s => !string.IsNullOrEmpty(s)).ToArray();
        }

        public void StartTimer()
        {
            Timer = new System.Timers.Timer(LoopTime);
            Timer.Elapsed += new System.Timers.ElapsedEventHandler(ReadDAMPressure);
            Timer.AutoReset = true;
            Timer.Enabled = true;
           
        }
        public void StartPressureTimer(int loopTime)
        {
            Timer = new System.Timers.Timer(loopTime-5);
            Timer.Elapsed += new System.Timers.ElapsedEventHandler(ReadDAMPressure);
            Timer.AutoReset = true;
            Timer.Enabled = true;
           
        }
        public void OmronTest1(object source, System.Timers.ElapsedEventArgs e)
        {
            short i = 0;
            short re = 0;
            object[] RD = null;
            RD = new object[1];
           
            int var1 = 4;
            FinsCom.PlcCom.PlcMemory mry = (FinsCom.PlcCom.PlcMemory)var1;
            var1 = 1;
            FinsCom.PlcCom.DataType typ = (FinsCom.PlcCom.DataType)var1;

            re = OmronCom.CmdRead(1, mry, typ,
                            130, 1, ref RD);

            for (i = 0; i < RD.Length; i++)
            {
                if (!ReferenceEquals(RD[i], null))
                {
                    MsgofMain(RD[i].ToString(), LogType.FlowLog, false);
                }
                else
                {
                    MsgofMain("null", LogType.FlowLog, false);
                }
            }
        }
        public void OmronTest(object source, System.Timers.ElapsedEventArgs e)
        {
            byte[] sendData = new byte[] { 0x40, 0x30, 0x30, 0x46, 0x41, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x31, 0x38, 0x32, 0x30, 0x31, 0x46, 0x34, 0x30, 0x30, 0x30, 0x30, 0x30, 0x32, 0x30, 0x43, 0x2A, 0x0D };
            SerialPortScaner.Write(sendData, 0, sendData.Length);
            MsgofMain("写入數據：" + Variable.OmronAddress, LogType.FlowLog, false);
        }

        public void OmronTest2(object source, System.Timers.ElapsedEventArgs e)
        {
            byte[] sendData = System.Text.Encoding.ASCII.GetBytes(Variable.OmronAddress);
            byte[] byteEnter = new byte[] { 0x0A, 0x0D };
            byte[] byteMsg = sendData.Concat(byteEnter).ToArray();
            SerialPortScaner.Write(sendData, 0, sendData.Length);
            MsgofMain("写入數據：" + Variable.OmronAddress, LogType.FlowLog, false);
        }

        public void OmronTest3()
        {
            byte[] sendData1 = System.Text.Encoding.ASCII.GetBytes("@00FA00000000001018201F40000020C*");
            // byte[] byteEnter = new byte[] { 0x0A, 0x0D };
            byte[] byteEnter = new byte[] { 0x0D };
            byte[] byteMsg = sendData1.Concat(byteEnter).ToArray();


            byte[] sendData = new byte[] { 0x40, 0x30, 0x30, 0x46, 0x41, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x31, 0x38, 0x32, 0x30, 0x31, 0x46, 0x34, 0x30, 0x30, 0x30, 0x30, 0x30, 0x32, 0x30, 0x43, 0x2A, 0x0D };
            SerialPortScaner.Write(byteMsg, 0, byteMsg.Length);
            MsgofMain("写入數據：" + Variable.OmronAddress, LogType.FlowLog, false);
        }

        public void StopTimer()
        {
            try
            {
                if (Timer != null)
                {
                    if (Timer.Enabled)
                    {
                     
                        Timer.Enabled = false;
                    }
                }
            }
            catch { }

        }

        static Boolean GetADModeRange(Int32 lADMode, ref float lRangeTop, ref float lRangeButtom, ref String strUnit, long lRange)
        {
            Boolean bRet = false;

            switch (lADMode)
            {
                // 电压zz
                case DAM3000M.DAM3000M_VOLT_N15_P15: // ±15mV
                    lRangeTop = 15;
                    lRangeButtom = -15;
                    strUnit = "mV";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_VOLT_N20_P20: // ±20mV
                    lRangeTop = 20;
                    lRangeButtom = -20;
                    strUnit = "mV";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_VOLT_N30_P30: // ±30mV
                    lRangeTop = 30;
                    lRangeButtom = -30;
                    strUnit = "mV";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_VOLT_N50_P50: // ±50mV 
                    lRangeTop = 50;
                    lRangeButtom = -50;
                    strUnit = "mV";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_VOLT_N100_P100: // ±100mV 
                    lRangeTop = 100;
                    lRangeButtom = -100;
                    strUnit = "mV";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_VOLT_N150_P150: // ±150mV
                    lRangeTop = 150;
                    lRangeButtom = -150;
                    strUnit = "mV";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_VOLT_N500_P500: // ±500mV 
                    lRangeTop = 500;
                    lRangeButtom = -500;
                    strUnit = "mV";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_VOLT_N0_P400MV: // 0~400mV 
                    lRangeTop = 400;
                    lRangeButtom = 0;
                    strUnit = "mV";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_VOLT_N1_P1: // ±1V
                    lRangeTop = 1;
                    lRangeButtom = -1;
                    strUnit = "V";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_VOLT_N25_P25: // ±2.5V 
                    lRangeTop = Convert.ToSingle(2.5);
                    lRangeButtom = Convert.ToSingle(-2.5);
                    strUnit = "V";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_VOLT_N5_P5: //±5V
                    lRangeTop = 5;
                    lRangeButtom = -5;
                    strUnit = "V";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_VOLT_N10_P10: // ±10V 
                    lRangeTop = 10;
                    lRangeButtom = -10;
                    strUnit = "V";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_VOLT_N0_P5: // 0~5V
                    lRangeTop = 5;
                    lRangeButtom = 0;
                    strUnit = "V";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_VOLT_N0_P10: // 0~10V
                    lRangeTop = 10;
                    lRangeButtom = 0;
                    strUnit = "V";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_VOLT_N0_P1: // 0-1V
                    lRangeTop = 1;
                    lRangeButtom = 0;
                    strUnit = "V";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_VOLT_N0_P25: // 0-2.5V
                    if (lRange == 1)
                    {
                        lRangeTop = Convert.ToSingle(5);
                        lRangeButtom = 0;
                        strUnit = "V";
                        bRet = true;
                    }
                    else
                    {
                        lRangeTop = Convert.ToSingle(2.5);
                        lRangeButtom = 0;
                        strUnit = "V";
                        bRet = true;
                    }
                    break;

                case DAM3000M.DAM3000M_VOLT_N1_P5:// 1-5V
                    if (lRange == 1)
                    {
                        lRangeTop = 5;
                        lRangeButtom = 0;
                        strUnit = "V";
                        bRet = true;
                    }
                    else
                    {
                        lRangeTop = 5;
                        lRangeButtom = 1;
                        strUnit = "V";
                        bRet = true;
                    }
                    break;
                case DAM3000M.DAM3000M_VOLT_N0_P12:// 0-12V
                    lRangeTop = 12;
                    lRangeButtom = 0;
                    strUnit = "V";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_VOLT_N0_P20:// 0-20V
                    lRangeTop = 20;
                    lRangeButtom = 0;
                    strUnit = "V";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_VOLT_N0_P15:// 0-15V
                    lRangeTop = 15;
                    lRangeButtom = 0;
                    strUnit = "V";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_VOLT_N30_P30V:// -30～+30V
                    lRangeTop = 30;
                    lRangeButtom = -30;
                    strUnit = "V";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_VOLT_N0_P30V:// 0～+30V
                    lRangeTop = 30;
                    lRangeButtom = 0;
                    strUnit = "V";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_VOLT_N500_P500V:// -500～+500V
                    lRangeTop = 500;
                    lRangeButtom = -500;
                    strUnit = "V";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_VOLT_N0_P35:// 0～+35V
                    lRangeTop = 35;
                    lRangeButtom = 0;
                    strUnit = "V";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_VOLT_N35_P0:// -35～0V
                    lRangeTop = 0;
                    lRangeButtom = -35;
                    strUnit = "V";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_VOLT_N35_P35:// -35～35V
                    lRangeTop = 35;
                    lRangeButtom = -35;
                    strUnit = "V";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_VOLT_N20_P0V:// -20～+0V
                    lRangeTop = 0;
                    lRangeButtom = -20;
                    strUnit = "V";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_VOLT_N20_P20V:// -20～+20V
                    lRangeTop = 20;
                    lRangeButtom = -20;
                    strUnit = "V";
                    bRet = true;
                    break;
                // 	case DAM3000M.DAM3000M_VOLT_N35_P0	:// -35～0V
                // 		lRangeTop = 0;
                // 		lRangeButtom = -35;
                // 		strUnit = "V";
                // 		bRet = true;
                // 		break;
                // 	case DAM3000M.DAM3000M_VOLT_N35_P35	:// -35～0V
                // 		lRangeTop = 35;
                // 		lRangeButtom = -35;
                // 		strUnit = "V";
                // 		bRet = true;
                // 		break;
                // 电流
                case DAM3000M.DAM3000M_CUR_N0_P10: // 0~10mA
                    lRangeTop = 10;
                    lRangeButtom = 0;
                    strUnit = "mA";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_CUR_N20_P20: // ±20mA
                    lRangeTop = 20;
                    lRangeButtom = -20;
                    strUnit = "mA";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_CUR_N0_P20: //0~20mA
                    lRangeTop = 20;
                    lRangeButtom = 0;
                    strUnit = "mA";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_CUR_N4_P20: //4~20mA 
                    if (lRange == 1)
                    {
                        lRangeTop = 20;
                        lRangeButtom = 0;
                        strUnit = "mA";
                        bRet = true;
                    }
                    else
                    {
                        lRangeTop = 20;
                        lRangeButtom = 4;
                        strUnit = "mA";
                        bRet = true;
                    }
                    break;

                case DAM3000M.DAM3000M_CUR_N0_P22: //0~22mA 
                    lRangeTop = 22;
                    lRangeButtom = 0;
                    strUnit = "mA";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_CUR_N10_P10A:// -10～+10A
                    lRangeTop = 10;
                    lRangeButtom = -10;
                    strUnit = "A";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_CUR_N0_P10A:// 0～+10A
                    lRangeTop = 10;
                    lRangeButtom = 0;
                    strUnit = "A";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_CUR_N10_P0A:// -10～+0A
                    lRangeTop = 0;
                    lRangeButtom = -10;
                    strUnit = "A";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_CUR_N50_P50A:// -50～+50A
                    lRangeTop = 50;
                    lRangeButtom = -50;
                    strUnit = "A";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_CUR_N0_P50A:// 0～+50A
                    lRangeTop = 50;
                    lRangeButtom = 0;
                    strUnit = "A";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_CUR_N0_P200: //0~200mA 
                    lRangeTop = 200;
                    lRangeButtom = 0;
                    strUnit = "mA";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_CUR_N200_P0: //-200~0mA 
                    lRangeTop = 0;
                    lRangeButtom = -200;
                    strUnit = "mA";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_CUR_N200_P200: //-200~200mA 
                    lRangeTop = 200;
                    lRangeButtom = -200;
                    strUnit = "mA";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_CUR_N0_P500: //0~500mA 
                    lRangeTop = 500;
                    lRangeButtom = 0;
                    strUnit = "mA";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_CUR_N500_P0: //-500～0mA
                    lRangeTop = 0;
                    lRangeButtom = -500;
                    strUnit = "mA";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_CUR_N500_P500: //-500～500mA
                    lRangeTop = 500;
                    lRangeButtom = -500;
                    strUnit = "mA";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_CUR_N0_P1500: //0~1500mA 
                    lRangeTop = 1500;
                    lRangeButtom = 0;
                    strUnit = "mA";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_CUR_N1500_P0: //-1500 ～ 0mA
                    lRangeTop = 0;
                    lRangeButtom = -1500;
                    strUnit = "mA";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_CUR_N1500_P1500: //-1500 ～ 1500mA
                    lRangeTop = 1500;
                    lRangeButtom = -1500;
                    strUnit = "mA";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_CUR_N0_P400UA: //0~400uA 
                    lRangeTop = 400;
                    lRangeButtom = 0;
                    strUnit = "uA";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_CUR_N0_P1000: //0 ～ 1000mA
                    lRangeTop = 1000;
                    lRangeButtom = 0;
                    strUnit = "mA";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_CUR_N1000_P0: //-1000 ～ 0mA
                    lRangeTop = 0;
                    lRangeButtom = -1000;
                    strUnit = "mA";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_CUR_N1000_P1000: //-1000 ～ 1000mA
                    lRangeTop = 1000;
                    lRangeButtom = -1000;
                    strUnit = "mA";
                    bRet = true;
                    break;

                // 远传压力表电阻
                // 	case DAM3000M.DAM3000M_R_N0_R400Ω: // 0~400Ω
                // 		lRangeTop = 400;
                // 		lRangeButtom = 0;
                // 		strUnit="Ω";
                // 		bRet=true;
                // 		break;

                // 热电隅
                case DAM3000M.DAM3000M_TMC_J: // 0~1200℃
                    lRangeTop = 1200;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_TMC_K: // 0-1300℃
                    lRangeTop = 1300;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_TMC_K_EX: // -40-1300℃
                    lRangeTop = 1300;
                    lRangeButtom = -40;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_TMC_T: // -200-400℃
                    lRangeTop = 400;
                    lRangeButtom = -200;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_TMC_E: // 0-1000℃
                    lRangeTop = 1000;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_TMC_R: // 0-1700℃
                    lRangeTop = 1700;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_TMC_S: // 0-1768℃
                    lRangeTop = 1768;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_TMC_B: // 0-1800℃
                    lRangeTop = 1800;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_TMC_B_N: // 250-1800℃
                    lRangeTop = 1800;
                    lRangeButtom = 250;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_TMC_N: // 0-1300℃
                    lRangeTop = 1300;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_TMC_C: // 0-2090℃
                    lRangeTop = 2090;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_TMC_WRE: // 0-2310℃
                    lRangeTop = 2310;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                //  热电阻
                case DAM3000M.DAM3000M_RTD_PT100_385_N200_P600: // Pt100(-200～+600℃) a=0.00385
                    lRangeTop = 600;
                    lRangeButtom = -200;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_RTD_PT100_385_N100_P100: // Pt100(-100～+100℃) a=0.00385
                    lRangeTop = 100;
                    lRangeButtom = -100;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_RTD_PT100_385_N0_P100: // Pt100(0～+100℃) a=0.00385
                    lRangeTop = 100;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_RTD_PT100_385_N0_P200: // Pt100(0～+200℃) a=0.00385
                    lRangeTop = 200;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_RTD_PT100_385_N0_P600: // Pt100(0～+600℃) a=0.00385
                    lRangeTop = 600;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_RTD_PT100_3916_N200_P600: // Pt100(-200～+600℃) a=0.003916
                    lRangeTop = 600;
                    lRangeButtom = -200;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_RTD_PT100_3916_N100_P100: // Pt100(-100～+100℃) a=0.003916
                    lRangeTop = 100;
                    lRangeButtom = -100;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_RTD_PT100_3916_N0_P100: // Pt100(0～+100℃) a=0.003916
                    lRangeTop = 100;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_RTD_PT100_3916_N0_P200: // Pt100(0～+200℃) a=0.003916
                    lRangeTop = 200;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_RTD_PT100_3916_N0_P600: // Pt100(0～+600℃) a=0.003916
                    lRangeTop = 600;
                    lRangeButtom = 0;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_RTD_PT1000: // Pt1000(-200℃~600℃)
                    lRangeTop = 600;
                    lRangeButtom = -200;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_RTD_CU50: // Cu50(-50～+150℃)")
                    lRangeTop = 150;
                    lRangeButtom = -50;
                    strUnit = "℃";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_RTD_CU100: // Cu100(-50～+150℃)
                    lRangeTop = 150;
                    lRangeButtom = -50;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_RTD_BA1: // BA1	-200℃~650℃
                    lRangeTop = 650;
                    lRangeButtom = -200;
                    strUnit = "℃";
                    bRet = true;
                    break;

                case DAM3000M.DAM3000M_RTD_BA2: // BA2	-200℃~650℃
                    lRangeTop = 650;
                    lRangeButtom = -200;
                    strUnit = "℃";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_RTD_G53: // G53	-50℃～150℃		
                    lRangeTop = 150;
                    lRangeButtom = -50;
                    strUnit = "℃";
                    bRet = true;
                    break;
                case DAM3000M.DAM3000M_RTD_103AT: // 103AT	-50℃～110℃		
                    lRangeTop = 110;
                    lRangeButtom = -50;
                    strUnit = "℃";
                    bRet = true;
                    break;

            }

            return bRet;
        }

        public bool ReadDAMPressure(out double adTmp)
        {
            adTmp = 0;
            try
            {
                if (DAM3000M.DAM3000M_ReadInputRegsUInt32(DAMDevice, ADDeviceID, AdAddress, ADChannelNum, ADBuffer))
                //if(true)
                {
                    adTmp = ((ADBuffer[Analog1] / ADLsbType) * (ADUpperRange1 - ADLowRange1) + ADLowRange1);
                    if (Application.OpenForms["FormPressureCurve"] != null) DataOfChartPressure(adTmp, Analog1);
                    return true;
                }
                else
                {
                    MsgofMain("获取模块值失败，请退出程序。", LogType.FlowLog, true);
                    return false;
                }
            }
            catch (AccessViolationException ex)
            {
                MsgofMain("获取模块值失败，请退出程序。ex:" + ex.Message, LogType.FlowLog, true);
                return false;
            }
            catch (Exception ex)
            {
                MsgofMain("获取模块值失败，请退出程序。ex:" + ex.Message, LogType.FlowLog, true);
                return false;
            }
        }
        public void ReadDAMPressure(object source, System.Timers.ElapsedEventArgs e)
        {
            //ProgramCycleTime.Reset();
            //ProgramCycleTime.Start();
            try
            {
                if (DAM3000M.DAM3000M_ReadInputRegsUInt32(DAMDevice, ADDeviceID, AdAddress, ADChannelNum, ADBuffer))
                {
                    ADTmp = ((ADBuffer[Analog1] / ADLsbType) * (ADUpperRange1 - ADLowRange1) + ADLowRange1);
                    if (ADTmp > SetPressure) PressureArrival = true;
                    //AddDataToChart(ADTmp, -1);
                    DataOfChartPressure(ADTmp, Analog1);
                    if (IsLog)
                    {
                        LogClass.SingletonInstance.WriteLog(ADTmp.ToString(), LogClass.PressureLog);
                        //MsgofMain("获取模拟量1(通道" + i.ToString() + ")值:" + ADTmp.ToString(), LogType.PressureLog, false);
                    }
                }
                else
                {
                    MsgofMain("获取模块值失败，请退出程序。", LogType.FlowLog, true);
                    StopTimer();
                }
            }
            catch (Exception ex)
            {
                MsgofMain("获取模块值失败，请退出程序。ex:" + ex.Message, LogType.FlowLog, true);
                StopTimer();
            }
            //MsgofMain(ProgramCycleTime.ElapsedMilliseconds.ToString(), LogType.FlowLog, false);
            //LogClass.SingletonInstance.WriteLog(ProgramCycleTime.ElapsedMilliseconds.ToString(), LogClass.PressureLog);
        }


        public void ReadDAMTorque(object source, System.Timers.ElapsedEventArgs e)
        {
            //ProgramCycleTime.Reset();
            //ProgramCycleTime.Start();
            try
            {

                if (DAM3000M.DAM3000M_ReadInputRegsUInt32(DAMDevice, ADDeviceID, AdAddress, ADChannelNum, ADBuffer))
                {
                    ADTmp = ((ADBuffer[Analog2] / ADLsbType) * (ADUpperRange2 - ADLowRange2) + ADLowRange2);
                    //AddDataToChart(-1, ADTmp);
                    DataOfChartTorque(ADTmp, Analog2);
                    if (IsLog)
                    {
                        LogClass.SingletonInstance.WriteLog(ADTmp.ToString(), LogClass.TorqueLog);
                        //MsgofMain("获取模拟量2(通道" + i.ToString() + ")值:" + ADTmp.ToString(), LogType.PressureLog, false);
                    }
                }
                else
                {
                    MsgofMain("获取模块值失败，请退出程序。", LogType.FlowLog, true);
                    StopTimer();
                }
            }
            catch (Exception ex)
            {
                MsgofMain("获取模块值失败，请退出程序。ex:" + ex.Message, LogType.FlowLog, true);
                StopTimer();
            }
            //MsgofMain(ProgramCycleTime.ElapsedMilliseconds.ToString(), LogType.FlowLog, false);
            //LogClass.SingletonInstance.WriteLog(ProgramCycleTime.ElapsedMilliseconds.ToString(), LogClass.PressureLog);
        }

        public bool ReadDAMTorque()
        {
            //ProgramCycleTime.Reset();
            //ProgramCycleTime.Start();
            try
            {

               if (DAM3000M.DAM3000M_ReadInputRegsUInt32(DAMDevice, ADDeviceID, AdAddress, ADChannelNum, ADBuffer))
               //if(true)
                {
                    ADTmp = ((ADBuffer[Analog2] / ADLsbType) * (ADUpperRange2 - ADLowRange2) + ADLowRange2);
                    //AddDataToChart(-1, ADTmp);
                    DataOfChartTorque(ADTmp, Analog2);
                    //if (IsLog)
                    //{
                    //    LogClass.SingletonInstance.WriteLog(ADTmp.ToString(), LogClass.TorqueLog);
                    //    //MsgofMain("获取模拟量2(通道" + i.ToString() + ")值:" + ADTmp.ToString(), LogType.PressureLog, false);
                    //}
                    return true;    
                }
                else
                {
                    MsgofMain("获取模块值失败，请退出程序。", LogType.FlowLog, true);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MsgofMain("获取模块值失败，请退出程序。ex:" + ex.Message, LogType.FlowLog, true);
                return true;
            }
            //MsgofMain(ProgramCycleTime.ElapsedMilliseconds.ToString(), LogType.FlowLog, false);
            //LogClass.SingletonInstance.WriteLog(ProgramCycleTime.ElapsedMilliseconds.ToString(), LogClass.PressureLog);
        }

        public void ReadDAM(object source, System.Timers.ElapsedEventArgs e)
        {
            //ProgramCycleTime.Reset();
            //ProgramCycleTime.Start();
            try
            {

                if (DAM3000M.DAM3000M_ReadInputRegsUInt32(DAMDevice, ADDeviceID, AdAddress, ADChannelNum, ADBuffer))
                {

                    for (Int32 i = 0; i < ADChannelNum; i++)
                    {
                        if (Analog1 == i)
                        {
                            ADTmp = ((ADBuffer[i] / ADLsbType) * (ADUpperRange1 - ADLowRange1) + ADLowRange1);
                            if (ADTmp > SetPressure) PressureArrival = true;
                            //AddDataToChart(ADTmp, -1);
                            DataOfChartPressure(ADTmp, 0);
                            if (IsLog)
                            {
                                LogClass.SingletonInstance.WriteLog(ADTmp.ToString(), LogClass.PressureLog);
                                //MsgofMain("获取模拟量1(通道" + i.ToString() + ")值:" + ADTmp.ToString(), LogType.PressureLog, false);
                            }
                        }
                        else if (Analog2 == i)
                        {
                            ADTmp = ((ADBuffer[i] / ADLsbType) * (ADUpperRange2 - ADLowRange2) + ADLowRange2);
                            //AddDataToChart(-1, ADTmp);
                            DataOfChartTorque(ADTmp, 1);
                            if (IsLog)
                            {
                                LogClass.SingletonInstance.WriteLog(ADTmp.ToString(), LogClass.TorqueLog);
                                //MsgofMain("获取模拟量2(通道" + i.ToString() + ")值:" + ADTmp.ToString(), LogType.PressureLog, false);
                            }
                        }
                    }

                }
                else
                {
                    MsgofMain("获取模块值失败，请退出程序。", LogType.FlowLog, true);
                    StopTimer();
                }
            }
            catch (Exception ex)
            {
                MsgofMain("获取模块值失败，请退出程序。ex:" + ex.Message, LogType.FlowLog, true);
                StopTimer();
            }
            //MsgofMain(ProgramCycleTime.ElapsedMilliseconds.ToString(), LogType.FlowLog, false);
            //LogClass.SingletonInstance.WriteLog(ProgramCycleTime.ElapsedMilliseconds.ToString(), LogClass.PressureLog);
        }

        public void DisconnectToDAM()
        {
            // 8、释放设备(必须)**********************************************************************************
            try { DAM3000M.DAM3000M_ReleaseDevice(DAMDevice); } catch { }
           
           
        }

        public bool ConnectToDAM()
        {
            try
            {
                ////////////////////////////////////////////////////////////////////////////
                // 1、 创建设备(必须)**********************************************************************************

                DAMDevice = DAM3000M.DAM3000M_CreateDevice(ADComID);
                if ((DAMDevice == (IntPtr)0) || (DAMDevice == ((IntPtr)(-1))))
                {
                    MsgofMain("模拟量采集模块串口打开失败，请确认串口是否被占用，或者是否存在此串口，退出程序。", LogType.FlowLog, true);
                    Thread.Sleep(1000);
                    return false;
                }

                // 2、初始化设备(必须)**********************************************************************************
                if (!DAM3000M.DAM3000M_InitDevice(DAMDevice, ADBaud, ADDataBits, ADStopBits, ADParity, 500, 0))
                {
                    MsgofMain("模拟量采集模块初始化设备失败，退出", LogType.FlowLog, true);
                    Thread.Sleep(1000);
                    return false;
                }
                MsgofMain("模拟量采集模块设备初始化成功！", LogType.FlowLog, false);
                return true;
            }
            catch (Exception ex)
            {
               
                MsgofMain("串口打開失敗，請關閉程序后重開開啟！" + ex.Message, LogType.FlowLog, true);
                return false;
            }
        }
        public void AddDataToChart(double analogData1, double analogData2)
        {
            if (FormPressureCurve.FrmPressureCurve.InvokeRequired)
            {

                DelegateFormMain dele = new DelegateFormMain(AddDataToChart);
                FormPressureCurve.FrmPressureCurve.BeginInvoke(dele);
            }
            else
            {
                if (analogData1 >= 0)
                {
                    FormPressureCurve.FrmPressureCurve.ChartPressure.Series[0].Points.AddXY(DateTime.Now.ToOADate(), analogData1);
                }
                if (analogData2 >= 0)
                {
                    FormPressureCurve.FrmPressureCurve.ChartPressure.Series[1].Points.AddXY(DateTime.Now.ToOADate(), analogData2);
                }
                FormPressureCurve.FrmPressureCurve.ChartPressure.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddSeconds(1).ToOADate();   //X坐标后移1秒
                if (FormPressureCurve.FrmPressureCurve.checkBox1.Checked == true)
                    FormPressureCurve.FrmPressureCurve.ChartPressure.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddSeconds(-10).ToOADate();//此刻后10分钟作为最初X轴，
            }
        }

        public void Test()
        {
           
            MsgofMain("DAM设备初始化成功！", LogType.FlowLog, false);
        }

        public bool CreateConnectionToPLC()
        {
            try
            {
                if (PLCClass.FinsUDP.UDPOpen(PLCIP, PLCPort, LocalIP, LocalPort, 0, 0))
                {
                    IsConnectPLC = true;
                   
                   // MsgofMain("PLC连接成功", LogType.FlowLog, false);
                    return true;
                }
                else
                {
                    IsConnectPLC = false;
                    MsgofMain("PLC连接异常，请检查配置文件参数！", LogType.FlowLog, true);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MsgofMain("PLC连接异常，请检查配置文件参数！" + ex.Message , LogType.FlowLog, true);
                return false;
            }
        }
    }

    
}

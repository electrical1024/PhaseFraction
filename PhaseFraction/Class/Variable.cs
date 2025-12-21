using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO.Ports;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace PhaseFraction
{
    public enum LogType : int
    {
        ListShow = 0,
        AlarmLog = 1,
        AlarmPLC = 2,
        FlowLog = 3,
        FlowLogOnly = 4,
        BarcodeLog = 5,
        PressureLog=6,
    }
    public enum Camera : int
    {
        Camera1 = 0,
        Camera2 = 1,
        Camera3 = 2,
        Camera4 = 3,
    }
    public delegate void Alarmshow(string str, LogType i = LogType.FlowLog, bool bWarnFormShow = true);
    public delegate void Logshow(string str, string path);
    public delegate void UpdateChart(double analogData,int channel);

    class Variable
    {
        private static readonly object Locker = new object();
        public static string MacAddress = string.Empty;
        public static string MacAddress1 = string.Empty;
        public static string MacAddress2 = string.Empty;
        public static string IPAddress = string.Empty;
        public static string Camera1IP = string.Empty;
        public static string Camera1Port = string.Empty;
        public static string Camera2IP = string.Empty;
        public static string Camera2Port = string.Empty;
        public static string Camera3IP = string.Empty;
        public static string Camera3Port = string.Empty;
        public static string Camera4IP = string.Empty;
        public static string Camera4Port = string.Empty;
        public static string LocalIP = string.Empty;
        public static string LocalPort = string.Empty;
        public static string Plc1IP = string.Empty;
        public static string Plc1Port = string.Empty;
        public static string Plc2IP = string.Empty;
        public static string Plc2Port = string.Empty;
        public static string Plc3IP = string.Empty;
        public static string Plc3Port = string.Empty;
        public static string Plc4IP = string.Empty;
        public static string Plc4Port = string.Empty;
        public static string Ge_Ban = string.Empty;
        public static string CreateEmpid = string.Empty;

        public static string PortName = string.Empty;
        public static string BaudRate = string.Empty;
        public static string DataBits = string.Empty;
        public static string StopBits = string.Empty;
        public static string Parity = string.Empty;

        //public static string[] BarcodeA;
        //public static string[] BarcodeB;
        //public static string[] BarcodeC;
        //public static string[] BarcodeD;
        //public static string[] DeviceNoA;
        //public static string[] DeviceNoB;
        //public static string[] DeviceNoC;
        //public static string[] DeviceNoD;

        //public static string[] Barcode;
        //public static string[] DeviceNo;

        //public static string[] ScanerA = new string[100];
        //public static string[] ScanerB = new string[100];
        //public static string[] ScanerC = new string[100];
        //public static string[] ScanerD = new string[100];
  
        public static ArrayList ScanerA =new ArrayList();
        public static ArrayList ScanerB = new ArrayList();
        public static ArrayList ScanerC = new ArrayList();
        public static ArrayList ScanerD = new ArrayList();

        public static string OperatorA= string.Empty;
        public static string OperatorB = string.Empty;
        public static string OperatorC = string.Empty;
        public static string OperatorD = string.Empty;

        public static string LotNoA = string.Empty;
        public static string LotNoB = string.Empty;
        public static string LotNoC = string.Empty;
        public static string LotNoD = string.Empty;

        public static string DeviceNoA = string.Empty;
        public static string DeviceNoB = string.Empty;
        public static string DeviceNoC = string.Empty;
        public static string DeviceNoD = string.Empty;

       
        //public static Camera CameraNO ;
        //public static Socket SocketClient1;
        //public static Socket SocketClient2;
        //public static Socket SocketClient3;
        //public static Socket SocketClient4;

        //public static PlcClass Plc1 = new PlcClass();
        //public static PlcClass Plc2 = new PlcClass();
        //public static PlcClass Plc3 = new PlcClass();
        //public static PlcClass Plc4 = new PlcClass();

        public static bool IsConnectedToPLC1 = false;
        public static bool IsConnectedToReader1 = false;
        public static bool IsConnectedToPLC2 = false;
        public static bool IsConnectedToReader2 = false;
        public static bool IsConnectedToPLC3 = false;
        public static bool IsConnectedToReader3 = false;
        public static bool IsConnectedToPLC4 = false;
        public static bool IsConnectedToReader4 = false;

        public static bool IsDeviceNo = false;

        public static ArrayList Barcode = new ArrayList();
        public static int CurVehicleQt = 0;
        public static int CurLotNoQt = 0;
        public static string CurrentLotNo = string.Empty;
        public static bool ChangeLotNo = false;
        public static bool IsFirstMaterial = false;

        public static string DeviceNo = string.Empty;
        public static bool IsBarcode = false;

        public static string OmronAddress = string.Empty;
        public static string LoopTime = string.Empty;

       
    }
}















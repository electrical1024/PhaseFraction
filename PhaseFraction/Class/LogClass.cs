using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;

namespace PhaseFraction
{


    public sealed class LogClass
    {
        public Thread RecordThread = null;
        const int SleepTime = 150;          //延遲150ms

        public static readonly LogClass SingletonInstance;

        static LogClass() { SingletonInstance = new LogClass(); }

        private LogClass() { }

        public static LogClass Instance() { return SingletonInstance; }

        public const string FlowLog = "FlowLog";                    //工作流程保留LOG
        public const string SettingFlow = "SettingFlow";             //設置信息保留LOG
        public const string AlarmLog = "AlarmLog";                  //報警信息保留LOG
        public const string InFlowLog = "InFlowLog";                     //入庫LOG
        public const string OutFlowLog = "OutFlowLog";                  //出庫LOG
        public const string TidyFlowLog = "TidyFlowLog";                  //倒庫LOG
        public const string PressureLog = "PressureLog";
        public const string TorqueLog = "TorqueLog";
        public const string ForewardLog = "ForewardLog";
        public const string ReverseLog = "ReverseLog";

        //報警；


        private static readonly Queue LogQueue = new Queue();
        private static readonly Queue AlarmLogQueue = new Queue();
        private static readonly Queue SettingLogQueue = new Queue();    //機台設置記錄
        private static readonly Queue InLogQueue = new Queue();         //入庫記錄
        private static readonly Queue OutLogQueue = new Queue();        //出庫記錄
        private static readonly Queue TidyLogQueue = new Queue();        //倒庫記錄
        private static readonly Queue PressureLogQueue = new Queue();
        private static readonly Queue TorqueLogQueue = new Queue();
        private static readonly Queue ForewardLogQueue = new Queue();
        private static readonly Queue ReverseLogQueue = new Queue();



        public void WriteLogEnqueue(string str, string path)
        {
            if (path == "FlowLog")
            {
                object Obj1 = str;
                LogQueue.Enqueue(Obj1);
            }
            else if (path == "AlarmLog")
            {
                object Obj2 = str;
                AlarmLogQueue.Enqueue(Obj2);
            }
            else if (path == "SettingFlow")
            {
                object obj = str;
                SettingLogQueue.Enqueue(obj);
            }
            else if (path == "InFlowLog")
            {
                object obj = str;
                InLogQueue.Enqueue(obj);
            }
            else if (path == "OutFlowLog")
            {
                object obj = str;
                OutLogQueue.Enqueue(obj);
            }
            else if (path == "TidyFlowLog")
            {
                object obj = str;
                TidyLogQueue.Enqueue(obj);
            }
            else if (path == "PressureLog")
            {
                object obj = str;
                PressureLogQueue.Enqueue(obj);
            }
            else if (path == "TorqueLog")
            {
                object obj = str;
                TorqueLogQueue.Enqueue(obj);
            }
            else if (path == "ForewardLog")
            {
                object obj = str;
                ForewardLogQueue.Enqueue(obj);
            }
            else if (path == "ReverseLog")
            {
                object obj = str;
                ReverseLogQueue.Enqueue(obj);
            }
        }
        public void WriteLog(string str, string path)
        {
            try
            {
                //string LocalFilePath = $"{Directory.GetCurrentDirectory()}\\{path}\\{path}{DateTime.Now:yyyyMMdd}.csv";
                 string LocalFilePath = System.IO.Directory.GetCurrentDirectory() + @"\" + path + @"\" + path + System.DateTime.Now.ToString("yyyyMMdd") + ".csv";

                if (!Directory.Exists(Path.GetDirectoryName(LocalFilePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(LocalFilePath));
                }

                if (Directory.Exists(Path.GetDirectoryName(LocalFilePath)) && !File.Exists(LocalFilePath))
                {
                    File.Create(LocalFilePath).Close();
                }

                StreamWriter fs = new StreamWriter(LocalFilePath, true, Encoding.Default);
                //fs.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff},{str}");
                string strLog = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "," + str;
                fs.WriteLine(strLog);
                fs.Dispose();
                fs.Close();
            }
            catch
            {
                // MessageBox.Show("請關閉打開的Excel文件！");
            }
        }

        public void LogRecord()
        {
            RecordThread = new Thread(Record)
            {
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal
            };
            RecordThread.Start();
        }

        private void Record()
        {
            try
            {
                for (; ; )
                {
                    Thread.Sleep(SleepTime);
                    string strLog;
                    if (LogQueue.Count > 0)
                    {
                        strLog = LogQueue.Dequeue().ToString();
                        WriteLog(strLog, FlowLog);
                    }
                    if (AlarmLogQueue.Count > 0)
                    {
                        strLog = AlarmLogQueue.Dequeue().ToString();
                        WriteLog(strLog, AlarmLog);
                    }
                    if (SettingLogQueue.Count > 0)
                    {
                        strLog = SettingLogQueue.Dequeue().ToString();
                        WriteLog(strLog, SettingFlow);
                    }
                    if (InLogQueue.Count > 0)
                    {
                        strLog = InLogQueue.Dequeue().ToString();
                        WriteLog(strLog, InFlowLog);
                    }
                    if (OutLogQueue.Count > 0)
                    {
                        strLog = OutLogQueue.Dequeue().ToString();
                        WriteLog(strLog, OutFlowLog);
                    }
                    if (TidyLogQueue.Count > 0)
                    {
                        strLog = TidyLogQueue.Dequeue().ToString();
                        WriteLog(strLog, TidyFlowLog);
                    }
                    if (PressureLogQueue.Count > 0)
                    {
                        strLog = PressureLogQueue.Dequeue().ToString();
                        WriteLog(strLog, PressureLog);
                    }
                    if (TorqueLogQueue.Count > 0)
                    {
                        strLog = TorqueLogQueue.Dequeue().ToString();
                        WriteLog(strLog, TorqueLog);
                    }

                    if (ForewardLogQueue.Count > 0)
                    {
                        strLog = ForewardLogQueue.Dequeue().ToString();
                        WriteLog(strLog, ForewardLog);
                    }
                    if (ReverseLogQueue.Count > 0)
                    {
                        strLog = ReverseLogQueue.Dequeue().ToString();
                        WriteLog(strLog, ReverseLog);
                    }
                }
               
            }
            catch { }
        }

    }
}

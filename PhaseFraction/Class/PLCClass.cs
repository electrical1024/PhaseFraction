using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Omron;


namespace PhaseFraction
{
    public class GeneralPLC<T>  //泛型基底對象
    {
        public GeneralPLC(_eMemory address, int offset, int length, T[] data, int bOffset = 0)
        {
            Address = address;
            Offset = offset;
            Length = length;
            Data = data;
            BOffset = bOffset;
        }
        public _eMemory Address;
        public int Offset;
        public int Length;
        public T[] Data;
        public int BOffset;
    }
    public class DataType  //變數類型
    {
        public static double[] DoubleType(int length)
        {
            return new double[length];
        }
        public static float[] FloatType(int length)
        {
            return new float[length];
        }
        public static int[] IntType(int length)
        {
            return new int[length];
        }
        public static long[] LongType(int length)
        {
            return new long[length];
        }
        public static short[] ShortType(int length)
        {
            return new short[length];
        }
        public static UInt16[] Uint16Type(int length)
        {
            return new UInt16[length];
        }
        public static ulong[] ULongType(int length)
        {
            return new ulong[length];
        }
        public static ushort[] UShortType(int length)
        {
            return new ushort[length];
        }
        public static bool[] BoolType(int length)
        {
            return new bool[length];
        }
    }

    public sealed class PLCClass  //定義對象
    {
        public static readonly PLCClass SingletonInstance;
        static PLCClass() { SingletonInstance = new PLCClass(); }
        private PLCClass() { }
        private readonly MainClass Main = MainClass.instance();
        public static Alarmshow MessageOfrw = null;   //報警
        private static readonly object SyncRoot = new object();
        public static FinsUDP FinsUDP = new FinsUDP();
        //bool
        public GeneralPLC<bool> CreatConnection = new GeneralPLC<bool>(_eMemory.WR, 1, 1, DataType.BoolType(1), 0);         
        public GeneralPLC<bool> HomeStart = new GeneralPLC<bool>(_eMemory.WR, 10, 1, DataType.BoolType(1), 0);
        public GeneralPLC<bool> AlarmReset = new GeneralPLC<bool>(_eMemory.WR, 1, 1, DataType.BoolType(1), 2);
        public GeneralPLC<bool> Stop = new GeneralPLC<bool>(_eMemory.WR, 1, 1, DataType.BoolType(1), 3);
        public GeneralPLC<bool> ForewardRun = new GeneralPLC<bool>(_eMemory.WR, 2, 1, DataType.BoolType(1), 0);
        public GeneralPLC<bool> ReverseRun = new GeneralPLC<bool>(_eMemory.WR, 2, 1, DataType.BoolType(1), 1);
        public GeneralPLC<bool> LocationRun = new GeneralPLC<bool>(_eMemory.WR, 10, 1, DataType.BoolType(1), 4);
        public GeneralPLC<bool> BackRun = new GeneralPLC<bool>(_eMemory.WR, 2, 1, DataType.BoolType(1), 2);
        public GeneralPLC<bool> AccRun = new GeneralPLC<bool>(_eMemory.WR, 10, 1, DataType.BoolType(1), 8);
        public GeneralPLC<bool> DecRun = new GeneralPLC<bool>(_eMemory.WR, 10, 1, DataType.BoolType(1), 11);
        public GeneralPLC<bool> FlowFinish = new GeneralPLC<bool>(_eMemory.WR, 1, 1, DataType.BoolType(1), 5);

        public GeneralPLC<bool> PLCW1 = new GeneralPLC<bool>(_eMemory.WR, 1, 7, DataType.BoolType(7), 0);//
        public GeneralPLC<bool> ConnSuccess = new GeneralPLC<bool>(_eMemory.WR, 1, 1, DataType.BoolType(1), 1);//
        public GeneralPLC<bool> PlcAlarm = new GeneralPLC<bool>(_eMemory.WR, 1, 1, DataType.BoolType(1), 6);
        public GeneralPLC<bool> BackFinish = new GeneralPLC<bool>(_eMemory.WR, 2, 1, DataType.BoolType(1), 5);//
        public GeneralPLC<bool> PLCW10 = new GeneralPLC<bool>(_eMemory.WR, 10, 15, DataType.BoolType(15), 0);//
        public GeneralPLC<bool> HomeFinish = new GeneralPLC<bool>(_eMemory.WR, 10, 1, DataType.BoolType(1), 3);//
        public GeneralPLC<bool> LocationFinish = new GeneralPLC<bool>(_eMemory.WR, 10, 1, DataType.BoolType(1), 7);
        public GeneralPLC<bool> ForewardRuning = new GeneralPLC<bool>(_eMemory.WR, 10, 1, DataType.BoolType(1), 9);
        public GeneralPLC<bool> ReverseRuning = new GeneralPLC<bool>(_eMemory.WR, 10, 1, DataType.BoolType(1), 12);
        public GeneralPLC<bool> DecFinish = new GeneralPLC<bool>(_eMemory.WR, 10, 1, DataType.BoolType(1), 14);
        public GeneralPLC<bool> PLCI0 = new GeneralPLC<bool>(_eMemory.IO, 0, 6, DataType.BoolType(6), 0);//
        public GeneralPLC<bool> EmergencyStop = new GeneralPLC<bool>(_eMemory.IO, 0, 1, DataType.BoolType(1), 0);//
        public GeneralPLC<bool> ServoOn = new GeneralPLC<bool>(_eMemory.IO, 0, 1, DataType.BoolType(1), 2);
        public GeneralPLC<bool> ServoAlarm = new GeneralPLC<bool>(_eMemory.IO, 0, 1, DataType.BoolType(1), 3);
        public GeneralPLC<bool> PositiveLimit = new GeneralPLC<bool>(_eMemory.IO, 0, 1, DataType.BoolType(1), 4);
        public GeneralPLC<bool> NegativeLimit = new GeneralPLC<bool>(_eMemory.IO, 0, 1, DataType.BoolType(1), 5);

        //double
        public GeneralPLC<double> test1 = new GeneralPLC<double>(_eMemory.DM, 188, 1, DataType.DoubleType(1));
        //float
        public GeneralPLC<float> test = new GeneralPLC<float>(_eMemory.DM, 70, 2, DataType.FloatType(2));
        public GeneralPLC<float> ManualSpeed = new GeneralPLC<float>(_eMemory.DM, 62, 1, DataType.FloatType(1));
        public GeneralPLC<float> LocationSpeed = new GeneralPLC<float>(_eMemory.DM, 62, 1, DataType.FloatType(1));               
        public GeneralPLC<float> LocationCoord = new GeneralPLC<float>(_eMemory.DM, 64, 1, DataType.FloatType(1));             
        public GeneralPLC<float> LocationInitSpeed = new GeneralPLC<float>(_eMemory.DM, 66, 1, DataType.FloatType(1));
        public GeneralPLC<float> BackSpeed = new GeneralPLC<float>(_eMemory.DM, 92, 1, DataType.FloatType(1));
        public GeneralPLC<float> BackCoord = new GeneralPLC<float>(_eMemory.DM, 94, 1, DataType.FloatType(1));
        public GeneralPLC<float> BackInitSpeed = new GeneralPLC<float>(_eMemory.DM, 96, 1, DataType.FloatType(1));
        public GeneralPLC<float> AccDestSpeed = new GeneralPLC<float>(_eMemory.DM, 72, 1, DataType.FloatType(1));
        public GeneralPLC<float> AccValue = new GeneralPLC<float>(_eMemory.DM, 70, 1, DataType.FloatType(1));
        public GeneralPLC<float> DecDestSpeed = new GeneralPLC<float>(_eMemory.DM, 172, 1, DataType.FloatType(1));
        public GeneralPLC<float> DecValue = new GeneralPLC<float>(_eMemory.DM, 170, 1, DataType.FloatType(1));

        public GeneralPLC<float> CurCoord = new GeneralPLC<float>(_eMemory.DM, 50, 1, DataType.FloatType(1));
        public GeneralPLC<float> AccCurSpeed = new GeneralPLC<float>(_eMemory.DM, 88, 1, DataType.FloatType(1));
        public GeneralPLC<float> DecCurSpeed = new GeneralPLC<float>(_eMemory.DM, 188, 1, DataType.FloatType(1));
        //long
        public GeneralPLC<long> CTtime = new GeneralPLC<long>(_eMemory.DM, 10000, 5, DataType.LongType(5));

        public bool PLCRead(GeneralPLC<double> Obj)//5-11
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronRead(Obj.Address, Obj.Offset, Obj.Length, ref Obj.Data);
            }
            return bRe;
        }


        public bool PLCRead(GeneralPLC<float> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronRead(Obj.Address, Obj.Offset, Obj.Length, ref Obj.Data);
            }
            return bRe;
        }


        public bool PLCRead(GeneralPLC<int> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronRead(Obj.Address, Obj.Offset, Obj.Length, ref Obj.Data);
            }
            return bRe;
        }


        public bool PLCRead(GeneralPLC<long> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronRead(Obj.Address, Obj.Offset, Obj.Length, ref Obj.Data);
            }
            return bRe;
        }


        public bool PLCRead(GeneralPLC<short> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronRead(Obj.Address, Obj.Offset, Obj.Length, ref Obj.Data);
            }
            return bRe;
        }



        public bool PLCRead(GeneralPLC<uint> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronRead(Obj.Address, Obj.Offset, Obj.Length, ref Obj.Data);
            }
            return bRe;
        }


        public bool PLCRead(GeneralPLC<ulong> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronRead(Obj.Address, Obj.Offset, Obj.Length, ref Obj.Data);
            }
            return bRe;
        }


        public bool PLCRead(GeneralPLC<ushort> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronRead(Obj.Address, Obj.Offset, Obj.Length, ref Obj.Data);
            }
            return bRe;
        }


        public bool PLCRead(GeneralPLC<bool> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronRead(Obj.Address, Obj.Offset, Obj.BOffset, Obj.Length, ref Obj.Data);
            }
            return bRe;
        }



        public bool PLCWrite(GeneralPLC<double> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronWrite(Obj.Address, Obj.Offset, Obj.Length, Obj.Data);
            }
            return bRe;
        }



        public bool PLCWrite(GeneralPLC<double> Obj, double value)
        {
            bool bRe;
            Obj.Data[0] = value;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronWrite(Obj.Address, Obj.Offset, Obj.Length, Obj.Data); ;
            }
            return bRe;
        }



        public bool PLCWrite(GeneralPLC<float> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronWrite(Obj.Address, Obj.Offset, Obj.Length, Obj.Data);
            }
            return bRe;
        }

        public bool PLCWrite(GeneralPLC<float> Obj, float value)
        {
            bool bRe;
            Obj.Data[0] = value;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronWrite(Obj.Address, Obj.Offset, Obj.Length, Obj.Data);
            }
            return bRe;
        }


        public bool PLCWrite(GeneralPLC<int> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronWrite(Obj.Address, Obj.Offset, Obj.Length, Obj.Data);
            }
            return bRe;
        }


        public bool PLCWrite(GeneralPLC<long> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronWrite(Obj.Address, Obj.Offset, Obj.Length, Obj.Data);
            }
            return bRe;
        }


        public bool PLCWrite(GeneralPLC<short> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronWrite(Obj.Address, Obj.Offset, Obj.Length, Obj.Data);
            }
            return bRe;
        }



        public bool PLCWrite(GeneralPLC<uint> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronWrite(Obj.Address, Obj.Offset, Obj.Length, Obj.Data);
            }
            return bRe;
        }


        public bool PLCWrite(GeneralPLC<ulong> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronWrite(Obj.Address, Obj.Offset, Obj.Length, Obj.Data);
            }
            return bRe;
        }

        public bool PLCWrite(GeneralPLC<ushort> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronWrite(Obj.Address, Obj.Offset, Obj.Length, Obj.Data);
            }
            return bRe;
        }

        public bool PLCWrite(GeneralPLC<bool> Obj)
        {
            bool bRe;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronWrite(Obj.Address, Obj.Offset, Obj.BOffset, Obj.Length, Obj.Data);
            }
            return bRe;
        }

        public bool PLCWrite(GeneralPLC<bool> Obj, bool state)
        {
            bool bRe;
            Obj.Data[0] = state;
            lock (SyncRoot)
            {
                bRe = FinsUDP.OmronWrite(Obj.Address, Obj.Offset, Obj.BOffset, Obj.Length, Obj.Data);
            }
            return bRe;
        }


    }
}


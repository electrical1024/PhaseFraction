using System;
using System.Threading;
using HalconDotNet;


namespace PhaseFraction
{
    class VisionClass
    {
        public static Alarmshow MsgofVision = null;   //報警(寫在ggevent函數內)
        public static VisionClass m_instance;
        public static VisionClass instance()
        {
            if (m_instance == null)
                m_instance = new VisionClass();
            return m_instance;
        }
        Thread th2, th3;
        HTuple hv_AcqHandleLeft = null;         //创建相机的ID



        public bool VisionTest()
        {
            try
            {
                th2 = new Thread(ThreadFuntionVision);
                InitCamera(true);      //初始化相机 
                th2.Start();
                return true;
            }
            catch
            {
                MsgofVision("网络异常!", LogType.ListShow, true);
                return false;
            }
        }

        public void InitCamera(Boolean LeftRight)  //初始化相机 
        {
            try
            {

                //笔记本相机
                //HOperatorSet.OpenFramegrabber("DirectShow", 1, 1, 0, 0, 0, 0, "default", 8, "rgb", -1, "false", "default", "[0] 1.3M HD WebCam", 0, -1, out hv_AcqHandleLeft);
                //工控相机
                HOperatorSet.OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive", -1, "default", -1, "false", "default", "b0b35368a881_Hikrobot_MVCE12010GM", 0, -1, out hv_AcqHandleLeft);

                HObject MyImage;
                HOperatorSet.GrabImageStart(hv_AcqHandleLeft, -1);
                HOperatorSet.SetFramegrabberParam(hv_AcqHandleLeft, "TriggerMode", "Off");

                //HOperatorSet.SetFramegrabberParam(hv_AcqHandleLeft, "grab_timeout", -1);
                //HOperatorSet.SetFramegrabberParam(hv_AcqHandleLeft, "TriggerMode", "On");


            }
            catch (Exception exp)
            {
                MsgofVision(exp.Message, LogType.ListShow, true);

            }
        }

        //打开视频的线程
        public void ThreadFuntionVision()       //实时检测 
        {
            HOperatorSet.GrabImageStart(hv_AcqHandleLeft, -1);
            try
            {
                HTuple hv_HeightWin, hv_WidthWin;
                HObject MyImage;
                //设置窗口参数

                HOperatorSet.GrabImageAsync(out MyImage, hv_AcqHandleLeft, -1);
                HOperatorSet.GetImageSize(MyImage, out hv_HeightWin, out hv_WidthWin);// 获取输入图像的尺寸
                HOperatorSet.SetPart(Form1.MainForm.hWindowControl1.HalconWindow, 0, 0, hv_WidthWin, hv_HeightWin);//将获得的图像铺满整个窗口
                while (true)
                {
                    HOperatorSet.GrabImageAsync(out MyImage, hv_AcqHandleLeft, -1);
                    HOperatorSet.ClearWindow(Form1.MainForm.hWindowControl1.HalconWindow);
                    HOperatorSet.DispObj(MyImage, Form1.MainForm.hWindowControl1.HalconWindow);   //视频显示 
                    if (MyImage != null)
                    {
                        ProcessImage(MyImage);
                    }
                }
            }
            catch (Exception exp)
            {
                MsgofVision(exp.Message, LogType.ListShow, true);
            }
        }

        public void ProcessImage(HObject MyImage)
        {

            try
            {


            }
            catch (Exception exp)
            {
                MsgofVision(exp.Message, LogType.ListShow, true);
            }
        }
    }
}

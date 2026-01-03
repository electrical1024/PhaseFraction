using System;
using System.Threading;
using System.Windows.Forms;
using HalconDotNet;
using HZH_Controls;


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
        Thread CameraThread, th3;
        public HTuple AcqHandle = null;         //创建相机的ID
        public HTuple DisplayWindow = null;

        public bool IsVideo = false;
        public bool IsPhoto = false;


        public bool ConnectCamera()
        {
            try
            {
                CameraThread = new Thread(OpenCamera);
                InitCamera();      //初始化相机 
                CameraThread.Start();
                return true;
            }
            catch
            {
                MsgofVision("网络异常!", LogType.ListShow, true);
                return false;
            }
        }

        public bool InitCamera()  //初始化相机 
        {
            try
            {

                //笔记本相机
              
                //HOperatorSet.OpenFramegrabber("DirectShow", 1, 1, 0, 0, 0, 0, "default", 8, "rgb", -1, "false", "default", "[0] ", 0, -1, out hv_AcqHandle);
                //工控相机
                HOperatorSet.OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive", -1, "default", -1, "false", "default", "b0b35368a881_Hikrobot_MVCE12010GM", 0, -1, out AcqHandle);
                HOperatorSet.SetFramegrabberParam(AcqHandle, "TriggerMode", "Off");
                HOperatorSet.SetFramegrabberParam(AcqHandle, "AcquisitionMode", "Continuous");

                HOperatorSet.GrabImageStart(AcqHandle, -1);
               

                //HOperatorSet.SetFramegrabberParam(hv_AcqHandleLeft, "grab_timeout", -1);
                //HOperatorSet.SetFramegrabberParam(hv_AcqHandleLeft, "TriggerMode", "On");
              
                return true;
            }
            catch (Exception exp)
            {
                MsgofVision(exp.Message, LogType.ListShow, true);
                return false;
            }
        }

      
        public void OpenCamera()       
        {
            try
            {
                HObject image;
                while (true)
                {
                    Application.DoEvents();
                    HOperatorSet.GrabImageAsync(out image, AcqHandle, -1);
                    if (IsPhoto)
                    {
                        TakePhoto(image, DisplayWindow);
                    }
                    else if (IsVideo)
                    {
                        TakeVideo(image, DisplayWindow);
                    }
                }
            }
            catch (Exception exp)
            {
                IsVideo = false;
                IsPhoto = false;
                MsgofVision("打开相机错误" + exp.Message, LogType.ListShow, true);
            }
        }



        public void TakePhoto(HObject image, HTuple displayWindow)
        {
            if (image == null || displayWindow == null)
            {
                MsgofVision("图像或窗口为空！", LogType.ListShow, true);
                return;
            }
            try
            {
                HTuple heightWin, widthWin;
                HOperatorSet.GetImageSize(image, out heightWin, out widthWin);// 获取输入图像的尺寸
                HOperatorSet.SetPart(displayWindow, 0, 0, widthWin, heightWin);//将获得的图像铺满整个窗口

                HOperatorSet.ClearWindow(displayWindow);
                HOperatorSet.DispObj(image, displayWindow);  
               
                image.Dispose();
                IsPhoto = false;


            }
            catch (Exception exp)
            {
                MsgofVision("拍照错误：" + exp.Message, LogType.ListShow, true);
            }
        }

        public void TakeVideo(HObject image, HTuple displayWindow)      //实时检测 
        {
            try
            {
                HTuple heightWin, widthWin;
                HOperatorSet.GetImageSize(image, out heightWin, out widthWin);// 获取输入图像的尺寸
                HOperatorSet.SetPart(displayWindow, 0, 0, widthWin, heightWin);//将获得的图像铺满整个窗口
                HOperatorSet.ClearWindow(displayWindow);
                HOperatorSet.DispObj(image, displayWindow);   //视频显示 
                image.Dispose();
            }
            catch (Exception exp)
            {
                MsgofVision("录像错误："+exp.Message, LogType.ListShow, true);
            }
        }

       

        public void ProcessImage(HObject image)
        {

            try
            {


            }
            catch (Exception exp)
            {
                MsgofVision("图像处理错误：" + exp.Message, LogType.ListShow, true);
            }
        }
    }
}

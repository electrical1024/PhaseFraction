using System;
using System.Threading;
using System.Windows.Forms;
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
        HTuple hv_AcqHandle = null;         //创建相机的ID
      public  bool IsVideo=false;


        public bool ConnectCamera()
        {
            try
            {
                th2 = new Thread(TakeVideo);
                CreateConnectionToCamera();      //初始化相机 
                th2.Start();
                return true;
            }
            catch
            {
                MsgofVision("网络异常!", LogType.ListShow, true);
                return false;
            }
        }

        public bool CreateConnectionToCamera()  //初始化相机 
        {
            try
            {

                //笔记本相机
              
                HOperatorSet.OpenFramegrabber("DirectShow", 1, 1, 0, 0, 0, 0, "default", 8, "rgb", -1, "false", "default", "[0] ", 0, -1, out hv_AcqHandle);
                //工控相机
                //HOperatorSet.OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive", -1, "default", -1, "false", "default", "b0b35368a881_Hikrobot_MVCE12010GM", 0, -1, out hv_AcqHandle);
                //HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "TriggerMode", "Off");

                HObject MyImage;
                HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
               

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

        //打开视频的线程
        public void TakeVideo()       //实时检测 
        {
            IsVideo = true;
            try
            {
                HTuple hv_HeightWin, hv_WidthWin;
                HObject MyImage;
                //设置窗口参数

                HOperatorSet.GrabImageAsync(out MyImage, hv_AcqHandle, -1);
                HOperatorSet.GetImageSize(MyImage, out hv_HeightWin, out hv_WidthWin);// 获取输入图像的尺寸
                HOperatorSet.SetPart(FormMain.MainFrm.hSmartWindowControl1.HalconWindow, 0, 0, hv_WidthWin, hv_HeightWin);//将获得的图像铺满整个窗口
                while (IsVideo)
                {
                    Application.DoEvents();
                    HOperatorSet.GrabImageAsync(out MyImage, hv_AcqHandle, -1);
                    HOperatorSet.ClearWindow(FormMain.MainFrm.hSmartWindowControl1.HalconWindow);
                    HOperatorSet.DispObj(MyImage, FormMain.MainFrm.hSmartWindowControl1.HalconWindow);   //视频显示 
                   
                }
            }
            catch (Exception exp)
            {
                IsVideo = false;
                MsgofVision(exp.Message, LogType.ListShow, true);
            }
        }
        public void TakePhoto()
        {
            try
            {
                HTuple hv_HeightWin, hv_WidthWin;
                HObject MyImage;
                //设置窗口参数

                HOperatorSet.GrabImageAsync(out MyImage, hv_AcqHandle, -1);
                HOperatorSet.GetImageSize(MyImage, out hv_HeightWin, out hv_WidthWin);// 获取输入图像的尺寸
                HOperatorSet.SetPart(FormMain.MainFrm.hSmartWindowControl1.HalconWindow, 0, 0, hv_WidthWin, hv_HeightWin);//将获得的图像铺满整个窗口
               
                    HOperatorSet.ClearWindow(FormMain.MainFrm.hSmartWindowControl1.HalconWindow);
                    HOperatorSet.DispObj(MyImage, FormMain.MainFrm.hSmartWindowControl1.HalconWindow);   //视频显示 
                  
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

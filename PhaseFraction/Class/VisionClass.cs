using System;
using System.IO;
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
        public HObject CurrentImage = null;
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
                CurrentImage = image;
                HOperatorSet.ClearWindow(displayWindow);
                HOperatorSet.DispObj(CurrentImage, displayWindow);
                         

                //image.Dispose();
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
        //private void action(HObject ho_Image)
        //{


        //    // Local iconic variables 

        //    HObject ho_Rectangle;

        //    // Local control variables 

        //    HTuple hv_Width = new HTuple(), hv_Height = new HTuple();
        //    HTuple hv_WindowHandle = new HTuple(), hv_CameraParameters = new HTuple();
        //    HTuple hv_CameraPose = new HTuple(), hv_CameraParametersOut = new HTuple();
        //    HTuple hv_Row = new HTuple(), hv_Column = new HTuple();
        //    HTuple hv_Phi = new HTuple(), hv_Length1 = new HTuple();
        //    HTuple hv_Length2 = new HTuple(), hv_AmplitudeThreshold = new HTuple();
        //    HTuple hv_MsrHandle_Measure_01_0 = new HTuple(), hv_Row_Measure_01_0 = new HTuple();
        //    HTuple hv_Column_Measure_01_0 = new HTuple(), hv_Amplitude_Measure_01_0 = new HTuple();
        //    HTuple hv_Distance_Measure_01_0 = new HTuple(), hv_Column_World_Measure_01_0 = new HTuple();
        //    HTuple hv_Row_World_Measure_01_0 = new HTuple(), hv_TmpCtrl_Length = new HTuple();
        //    HTuple hv_TmpCtrl_RowFrom = new HTuple(), hv_TmpCtrl_ColumnFrom = new HTuple();
        //    HTuple hv_TmpCtrl_RowTo = new HTuple(), hv_TmpCtrl_ColumnTo = new HTuple();
        //    HTuple hv_Distance_World_Measure_01_0 = new HTuple();
        //    // Initialize local and output iconic variables 
          
        //    HOperatorSet.GenEmptyObj(out ho_Rectangle);
        //    try
        //    {
               
        //        HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
        //        HOperatorSet.SetWindowAttr("background_color", "black");
        //        HOperatorSet.OpenWindow(0, 0, hv_Width, hv_Height, 0, "visible", "", out hv_WindowHandle);
        //        HDevWindowStack.Push(hv_WindowHandle);
               
        //        if (HDevWindowStack.IsOpen())
        //        {
        //            HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
        //        }
        //        if (HDevWindowStack.IsOpen())
        //        {
        //            HOperatorSet.SetDraw(HDevWindowStack.GetActive(), "fill");
        //        }
        //        if (HDevWindowStack.IsOpen())
        //        {
        //            HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), 1);
        //        }
        //        if (HDevWindowStack.IsOpen())
        //        {
        //            HOperatorSet.SetColor(HDevWindowStack.GetActive(), "green");
        //        }
        //        hv_CameraParameters.Dispose();
        //        hv_CameraParameters = new HTuple();
        //        hv_CameraPose.Dispose();
        //        hv_CameraPose = new HTuple();
        //        hv_CameraParameters.Dispose();
        //        HOperatorSet.ReadCamPar("D:/课题/标定图片/result.cal", out hv_CameraParameters);
        //        hv_CameraPose.Dispose();
        //        HOperatorSet.ReadPose("D:/课题/标定图片/result.dat", out hv_CameraPose);
        //        hv_CameraParametersOut.Dispose();
        //        hv_CameraParametersOut = new HTuple(hv_CameraParameters);
        //        hv_Row.Dispose(); hv_Column.Dispose(); hv_Phi.Dispose(); hv_Length1.Dispose(); hv_Length2.Dispose();
        //        HOperatorSet.DrawRectangle2(hv_WindowHandle, out hv_Row, out hv_Column, out hv_Phi,
        //            out hv_Length1, out hv_Length2);
        //        ho_Rectangle.Dispose();
        //        HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_Row, hv_Column, hv_Phi,
        //            hv_Length1, hv_Length2);
        //        hv_AmplitudeThreshold.Dispose();
        //        hv_AmplitudeThreshold = 40;

        //        HOperatorSet.SetSystem("int_zooming", "true");
        //        hv_MsrHandle_Measure_01_0.Dispose();
        //        HOperatorSet.GenMeasureRectangle2(hv_Row, hv_Column, hv_Phi, hv_Length1, hv_Length2,
        //            hv_Width, hv_Height, "nearest_neighbor", out hv_MsrHandle_Measure_01_0);
        //        //gen_radial_distortion_map (Map, CameraParameters, CameraParametersOut, 'bilinear')
        //        //map_image (Image, Map, ImageMapped)
        //        //Image := ImageMapped
        //        if (HDevWindowStack.IsOpen())
        //        {
        //            HOperatorSet.SetColor(HDevWindowStack.GetActive(), "blue");
        //        }
        //        ho_Rectangle.Dispose();
        //        HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_Row, hv_Column, hv_Phi,
        //            hv_Length1, hv_Length2);
        //        hv_Row_Measure_01_0.Dispose(); hv_Column_Measure_01_0.Dispose(); hv_Amplitude_Measure_01_0.Dispose(); hv_Distance_Measure_01_0.Dispose();
        //        HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure_01_0, 2.7, hv_AmplitudeThreshold,
        //            "all", "all", out hv_Row_Measure_01_0, out hv_Column_Measure_01_0, out hv_Amplitude_Measure_01_0,
        //            out hv_Distance_Measure_01_0);
        //        if (HDevWindowStack.IsOpen())
        //        {
        //            HOperatorSet.SetColor(HDevWindowStack.GetActive(), "yellow");
        //        }
        //        using (HDevDisposeHelper dh = new HDevDisposeHelper())
        //        {
        //            HOperatorSet.DispLine(hv_WindowHandle, hv_Row_Measure_01_0.TupleSelect(0),
        //                hv_Column_Measure_01_0.TupleSelect(0), hv_Row_Measure_01_0.TupleSelect(
        //                1), hv_Column_Measure_01_0.TupleSelect(1));
        //        }
        //        hv_Column_World_Measure_01_0.Dispose(); hv_Row_World_Measure_01_0.Dispose();
        //        HOperatorSet.ImagePointsToWorldPlane(hv_CameraParameters, hv_CameraPose, hv_Row_Measure_01_0,
        //            hv_Column_Measure_01_0, 0.001, out hv_Column_World_Measure_01_0, out hv_Row_World_Measure_01_0);
        //        hv_TmpCtrl_Length.Dispose();
        //        using (HDevDisposeHelper dh = new HDevDisposeHelper())
        //        {
        //            hv_TmpCtrl_Length = new HTuple(hv_Row_World_Measure_01_0.TupleLength()
        //                );
        //        }
        //        if ((int)(new HTuple(hv_TmpCtrl_Length.TupleGreater(0))) != 0)
        //        {
        //            using (HDevDisposeHelper dh = new HDevDisposeHelper())
        //            {
        //                hv_TmpCtrl_RowFrom.Dispose();
        //                HOperatorSet.TupleSelectRange(hv_Row_World_Measure_01_0, 0, hv_TmpCtrl_Length - 2,
        //                    out hv_TmpCtrl_RowFrom);
        //            }
        //            using (HDevDisposeHelper dh = new HDevDisposeHelper())
        //            {
        //                hv_TmpCtrl_ColumnFrom.Dispose();
        //                HOperatorSet.TupleSelectRange(hv_Column_World_Measure_01_0, 0, hv_TmpCtrl_Length - 2,
        //                    out hv_TmpCtrl_ColumnFrom);
        //            }
        //            using (HDevDisposeHelper dh = new HDevDisposeHelper())
        //            {
        //                hv_TmpCtrl_RowTo.Dispose();
        //                HOperatorSet.TupleSelectRange(hv_Row_World_Measure_01_0, 1, hv_TmpCtrl_Length - 1,
        //                    out hv_TmpCtrl_RowTo);
        //            }
        //            using (HDevDisposeHelper dh = new HDevDisposeHelper())
        //            {
        //                hv_TmpCtrl_ColumnTo.Dispose();
        //                HOperatorSet.TupleSelectRange(hv_Column_World_Measure_01_0, 1, hv_TmpCtrl_Length - 1,
        //                    out hv_TmpCtrl_ColumnTo);
        //            }
        //            hv_Distance_World_Measure_01_0.Dispose();
        //            HOperatorSet.DistancePp(hv_TmpCtrl_RowFrom, hv_TmpCtrl_ColumnFrom, hv_TmpCtrl_RowTo,
        //                hv_TmpCtrl_ColumnTo, out hv_Distance_World_Measure_01_0);
        //        }
        //        using (HDevDisposeHelper dh = new HDevDisposeHelper())
        //        {
        //            //HOperatorSet.(hv_WindowHandle, ("距离:" + hv_Distance_World_Measure_01_0) + "mm",
        //            //    "image", (hv_Row_Measure_01_0.TupleSelect(0)) + 200, (((hv_Column_Measure_01_0.TupleSelect(
        //            //    1)) + (hv_Column_Measure_01_0.TupleSelect(1))) / 2) + 50, "yellow", "false");
        //        }

        //    }
        //    catch (HalconException HDevExpDefaultException)
        //    {
        //                      throw HDevExpDefaultException;
        //    }
          
        //}

    }
}

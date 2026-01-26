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
        public HTuple CamPar = new HTuple(), CamPose = new HTuple(),AmpThr = new HTuple(), Sigma=new HTuple();
        public string Transition= "all",Select= "all";

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

        public void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem, HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)

        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_GenParamName = new HTuple(), hv_GenParamValue = new HTuple();
            HTuple hv_Color_COPY_INP_TMP = new HTuple(hv_Color);
            HTuple hv_Column_COPY_INP_TMP = new HTuple(hv_Column);
            HTuple hv_CoordSystem_COPY_INP_TMP = new HTuple(hv_CoordSystem);
            HTuple hv_Row_COPY_INP_TMP = new HTuple(hv_Row);

            // Initialize local and output iconic variables 
            try
            {
                //This procedure displays text in a graphics window.
                //
                //Input parameters:
                //WindowHandle: The WindowHandle of the graphics window, where
                //   the message should be displayed.
                //String: A tuple of strings containing the text messages to be displayed.
                //CoordSystem: If set to 'window', the text position is given
                //   with respect to the window coordinate system.
                //   If set to 'image', image coordinates are used.
                //   (This may be useful in zoomed images.)
                //Row: The row coordinate of the desired text position.
                //   You can pass a single value or a tuple of values.
                //   See the explanation below.
                //   Default: 12.
                //Column: The column coordinate of the desired text position.
                //   You can pass a single value or a tuple of values.
                //   See the explanation below.
                //   Default: 12.
                //Color: defines the color of the text as string.
                //   If set to [] or '' the currently set color is used.
                //   If a tuple of strings is passed, the colors are used cyclically
                //   for every text position defined by Row and Column,
                //   or every new text line in case of |Row| == |Column| == 1.
                //Box: A tuple controlling a possible box surrounding the text.
                //   Its entries:
                //   - Box[0]: Controls the box and its color. Possible values:
                //     -- 'true' (Default): An orange box is displayed.
                //     -- 'false': No box is displayed.
                //     -- color string: A box is displayed in the given color, e.g., 'white', '#FF00CC'.
                //   - Box[1] (Optional): Controls the shadow of the box. Possible values:
                //     -- 'true' (Default): A shadow is displayed in
                //               darker orange if Box[0] is not a color and in 'white' otherwise.
                //     -- 'false': No shadow is displayed.
                //     -- color string: A shadow is displayed in the given color, e.g., 'white', '#FF00CC'.
                //
                //It is possible to display multiple text strings in a single call.
                //In this case, some restrictions apply on the
                //parameters String, Row, and Column:
                //They can only have either 1 entry or n entries.
                //Behavior in the different cases:
                //   - Multiple text positions are specified, i.e.,
                //       - |Row| == n, |Column| == n
                //       - |Row| == n, |Column| == 1
                //       - |Row| == 1, |Column| == n
                //     In this case we distinguish:
                //       - |String| == n: Each element of String is displayed
                //                        at the corresponding position.
                //       - |String| == 1: String is displayed n times
                //                        at the corresponding positions.
                //   - Exactly one text position is specified,
                //      i.e., |Row| == |Column| == 1:
                //      Each element of String is display in a new textline.
                //
                //
                //Convert the parameters for disp_text.
                if ((int)((new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                    new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(new HTuple())))) != 0)
                {

                    hv_Color_COPY_INP_TMP.Dispose();
                    hv_Column_COPY_INP_TMP.Dispose();
                    hv_CoordSystem_COPY_INP_TMP.Dispose();
                    hv_Row_COPY_INP_TMP.Dispose();
                    hv_GenParamName.Dispose();
                    hv_GenParamValue.Dispose();

                    return;
                }
                if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
                {
                    hv_Row_COPY_INP_TMP.Dispose();
                    hv_Row_COPY_INP_TMP = 12;
                }
                if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
                {
                    hv_Column_COPY_INP_TMP.Dispose();
                    hv_Column_COPY_INP_TMP = 12;
                }
                //
                //Convert the parameter Box to generic parameters.
                hv_GenParamName.Dispose();
                hv_GenParamName = new HTuple();
                hv_GenParamValue.Dispose();
                hv_GenParamValue = new HTuple();
                if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(0))) != 0)
                {
                    if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleEqual("false"))) != 0)
                    {
                        //Display no box
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamName = hv_GenParamName.TupleConcat(
                                    "box");
                                hv_GenParamName.Dispose();
                                hv_GenParamName = ExpTmpLocalVar_GenParamName;
                            }
                        }
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamValue = hv_GenParamValue.TupleConcat(
                                    "false");
                                hv_GenParamValue.Dispose();
                                hv_GenParamValue = ExpTmpLocalVar_GenParamValue;
                            }
                        }
                    }
                    else if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleNotEqual(
                        "true"))) != 0)
                    {
                        //Set a color other than the default.
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamName = hv_GenParamName.TupleConcat(
                                    "box_color");
                                hv_GenParamName.Dispose();
                                hv_GenParamName = ExpTmpLocalVar_GenParamName;
                            }
                        }
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamValue = hv_GenParamValue.TupleConcat(
                                    hv_Box.TupleSelect(0));
                                hv_GenParamValue.Dispose();
                                hv_GenParamValue = ExpTmpLocalVar_GenParamValue;
                            }
                        }
                    }
                }
                if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(1))) != 0)
                {
                    if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleEqual("false"))) != 0)
                    {
                        //Display no shadow.
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamName = hv_GenParamName.TupleConcat(
                                    "shadow");
                                hv_GenParamName.Dispose();
                                hv_GenParamName = ExpTmpLocalVar_GenParamName;
                            }
                        }
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamValue = hv_GenParamValue.TupleConcat(
                                    "false");
                                hv_GenParamValue.Dispose();
                                hv_GenParamValue = ExpTmpLocalVar_GenParamValue;
                            }
                        }
                    }
                    else if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleNotEqual(
                        "true"))) != 0)
                    {
                        //Set a shadow color other than the default.
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamName = hv_GenParamName.TupleConcat(
                                    "shadow_color");
                                hv_GenParamName.Dispose();
                                hv_GenParamName = ExpTmpLocalVar_GenParamName;
                            }
                        }
                        using (HDevDisposeHelper dh = new HDevDisposeHelper())
                        {
                            {
                                HTuple
                                  ExpTmpLocalVar_GenParamValue = hv_GenParamValue.TupleConcat(
                                    hv_Box.TupleSelect(1));
                                hv_GenParamValue.Dispose();
                                hv_GenParamValue = ExpTmpLocalVar_GenParamValue;
                            }
                        }
                    }
                }
                //Restore default CoordSystem behavior.
                if ((int)(new HTuple(hv_CoordSystem_COPY_INP_TMP.TupleNotEqual("window"))) != 0)
                {
                    hv_CoordSystem_COPY_INP_TMP.Dispose();
                    hv_CoordSystem_COPY_INP_TMP = "image";
                }
                //
                if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(""))) != 0)
                {
                    //disp_text does not accept an empty string for Color.
                    hv_Color_COPY_INP_TMP.Dispose();
                    hv_Color_COPY_INP_TMP = new HTuple();
                }
                //
                HOperatorSet.DispText(hv_WindowHandle, hv_String, hv_CoordSystem_COPY_INP_TMP,
                    hv_Row_COPY_INP_TMP, hv_Column_COPY_INP_TMP, hv_Color_COPY_INP_TMP, hv_GenParamName,
                    hv_GenParamValue);

                hv_Color_COPY_INP_TMP.Dispose();
                hv_Column_COPY_INP_TMP.Dispose();
                hv_CoordSystem_COPY_INP_TMP.Dispose();
                hv_Row_COPY_INP_TMP.Dispose();
                hv_GenParamName.Dispose();
                hv_GenParamValue.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {

                hv_Color_COPY_INP_TMP.Dispose();
                hv_Column_COPY_INP_TMP.Dispose();
                hv_CoordSystem_COPY_INP_TMP.Dispose();
                hv_Row_COPY_INP_TMP.Dispose();
                hv_GenParamName.Dispose();
                hv_GenParamValue.Dispose();

                throw HDevExpDefaultException;
            }
        }

        public void set_display_font(HTuple hv_WindowHandle, HTuple hv_Size, HTuple hv_Font, HTuple hv_Bold, HTuple hv_Slant)

        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_OS = new HTuple(), hv_Fonts = new HTuple();
            HTuple hv_Style = new HTuple(), hv_Exception = new HTuple();
            HTuple hv_AvailableFonts = new HTuple(), hv_Fdx = new HTuple();
            HTuple hv_Indices = new HTuple();
            HTuple hv_Font_COPY_INP_TMP = new HTuple(hv_Font);
            HTuple hv_Size_COPY_INP_TMP = new HTuple(hv_Size);

            // Initialize local and output iconic variables 
            try
            {
                //This procedure sets the text font of the current window with
                //the specified attributes.
                //
                //Input parameters:
                //WindowHandle: The graphics window for which the font will be set
                //Size: The font size. If Size=-1, the default of 16 is used.
                //Bold: If set to 'true', a bold font is used
                //Slant: If set to 'true', a slanted font is used
                //
                hv_OS.Dispose();
                HOperatorSet.GetSystem("operating_system", out hv_OS);
                if ((int)((new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                    new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(-1)))) != 0)
                {
                    hv_Size_COPY_INP_TMP.Dispose();
                    hv_Size_COPY_INP_TMP = 16;
                }
                if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
                {
                    //Restore previous behavior
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Size = ((1.13677 * hv_Size_COPY_INP_TMP)).TupleInt()
                                ;
                            hv_Size_COPY_INP_TMP.Dispose();
                            hv_Size_COPY_INP_TMP = ExpTmpLocalVar_Size;
                        }
                    }
                }
                else
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Size = hv_Size_COPY_INP_TMP.TupleInt()
                                ;
                            hv_Size_COPY_INP_TMP.Dispose();
                            hv_Size_COPY_INP_TMP = ExpTmpLocalVar_Size;
                        }
                    }
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Courier";
                    hv_Fonts[1] = "Courier 10 Pitch";
                    hv_Fonts[2] = "Courier New";
                    hv_Fonts[3] = "CourierNew";
                    hv_Fonts[4] = "Liberation Mono";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Consolas";
                    hv_Fonts[1] = "Menlo";
                    hv_Fonts[2] = "Courier";
                    hv_Fonts[3] = "Courier 10 Pitch";
                    hv_Fonts[4] = "FreeMono";
                    hv_Fonts[5] = "Liberation Mono";
                    hv_Fonts[6] = "DejaVu Sans Mono";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Luxi Sans";
                    hv_Fonts[1] = "DejaVu Sans";
                    hv_Fonts[2] = "FreeSans";
                    hv_Fonts[3] = "Arial";
                    hv_Fonts[4] = "Liberation Sans";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Times New Roman";
                    hv_Fonts[1] = "Luxi Serif";
                    hv_Fonts[2] = "DejaVu Serif";
                    hv_Fonts[3] = "FreeSerif";
                    hv_Fonts[4] = "Utopia";
                    hv_Fonts[5] = "Liberation Serif";
                }
                else
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple(hv_Font_COPY_INP_TMP);
                }
                hv_Style.Dispose();
                hv_Style = "";
                if ((int)(new HTuple(hv_Bold.TupleEqual("true"))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Style = hv_Style + "Bold";
                            hv_Style.Dispose();
                            hv_Style = ExpTmpLocalVar_Style;
                        }
                    }
                }
                else if ((int)(new HTuple(hv_Bold.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception.Dispose();
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Slant.TupleEqual("true"))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Style = hv_Style + "Italic";
                            hv_Style.Dispose();
                            hv_Style = ExpTmpLocalVar_Style;
                        }
                    }
                }
                else if ((int)(new HTuple(hv_Slant.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception.Dispose();
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Style.TupleEqual(""))) != 0)
                {
                    hv_Style.Dispose();
                    hv_Style = "Normal";
                }
                hv_AvailableFonts.Dispose();
                HOperatorSet.QueryFont(hv_WindowHandle, out hv_AvailableFonts);
                hv_Font_COPY_INP_TMP.Dispose();
                hv_Font_COPY_INP_TMP = "";
                for (hv_Fdx = 0; (int)hv_Fdx <= (int)((new HTuple(hv_Fonts.TupleLength())) - 1); hv_Fdx = (int)hv_Fdx + 1)
                {
                    hv_Indices.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_Indices = hv_AvailableFonts.TupleFind(
                            hv_Fonts.TupleSelect(hv_Fdx));
                    }
                    if ((int)(new HTuple((new HTuple(hv_Indices.TupleLength())).TupleGreater(
                        0))) != 0)
                    {
                        if ((int)(new HTuple(((hv_Indices.TupleSelect(0))).TupleGreaterEqual(0))) != 0)
                        {
                            hv_Font_COPY_INP_TMP.Dispose();
                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                hv_Font_COPY_INP_TMP = hv_Fonts.TupleSelect(
                                    hv_Fdx);
                            }
                            break;
                        }
                    }
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(""))) != 0)
                {
                    throw new HalconException("Wrong value of control parameter Font");
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    {
                        HTuple
                          ExpTmpLocalVar_Font = (((hv_Font_COPY_INP_TMP + "-") + hv_Style) + "-") + hv_Size_COPY_INP_TMP;
                        hv_Font_COPY_INP_TMP.Dispose();
                        hv_Font_COPY_INP_TMP = ExpTmpLocalVar_Font;
                    }
                }
                HOperatorSet.SetFont(hv_WindowHandle, hv_Font_COPY_INP_TMP);

                hv_Font_COPY_INP_TMP.Dispose();
                hv_Size_COPY_INP_TMP.Dispose();
                hv_OS.Dispose();
                hv_Fonts.Dispose();
                hv_Style.Dispose();
                hv_Exception.Dispose();
                hv_AvailableFonts.Dispose();
                hv_Fdx.Dispose();
                hv_Indices.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {

                hv_Font_COPY_INP_TMP.Dispose();
                hv_Size_COPY_INP_TMP.Dispose();
                hv_OS.Dispose();
                hv_Fonts.Dispose();
                hv_Style.Dispose();
                hv_Exception.Dispose();
                hv_AvailableFonts.Dispose();
                hv_Fdx.Dispose();
                hv_Indices.Dispose();

                throw HDevExpDefaultException;
            }
        }

        private void action1(HObject ho_Image, HTuple hv_WinH)
        {


            // Local iconic variables 

            HObject ho_Map, ho_ImageMap, ho_rect1;

            // Local control variables 

            HTuple hv_W = new HTuple(), hv_H = new HTuple();
            HTuple hv_CamPar = new HTuple();
            HTuple hv_CamPose = new HTuple(), hv_CamParOut = new HTuple();
            HTuple hv_R1 = new HTuple(), hv_C1 = new HTuple(), hv_R2 = new HTuple();
            HTuple hv_C2 = new HTuple(), hv_R11 = new HTuple(), hv_C11 = new HTuple();
            HTuple hv_R21 = new HTuple(), hv_C21 = new HTuple(), hv_RowLine = new HTuple();
            HTuple hv_ColLine = new HTuple(), hv_AmpThr = new HTuple();
            HTuple hv_RoiWLen2 = new HTuple(), hv_LRS = new HTuple();
            HTuple hv_LCS = new HTuple(), hv_LRE = new HTuple(), hv_LCE = new HTuple();
            HTuple hv_TmpR = new HTuple(), hv_TmpC = new HTuple();
            HTuple hv_TmpDr = new HTuple(), hv_TmpDc = new HTuple();
            HTuple hv_TmpPhi = new HTuple(), hv_TmpLen1 = new HTuple();
            HTuple hv_TmpLen2 = new HTuple(), hv_MsrH = new HTuple();
            HTuple hv_RowM = new HTuple(), hv_ColM = new HTuple();
            HTuple hv_AmpM = new HTuple(), hv_DisM = new HTuple();
            HTuple hv_ColWM = new HTuple(), hv_RowWM = new HTuple();
            HTuple hv_ColW1 = new HTuple(), hv_RowW1 = new HTuple();
            HTuple hv_TmpLen = new HTuple(), hv_TmpRF = new HTuple();
            HTuple hv_TmpCF = new HTuple(), hv_TmpRT = new HTuple();
            HTuple hv_TmpCT = new HTuple(), hv_DisWM = new HTuple();
            HTuple hv_DisWM1 = new HTuple();

            try
            {

                HOperatorSet.GetImageSize(ho_Image, out hv_W, out hv_H);
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "green");
                set_display_font(hv_WinH, 9, "mono", "true", "false");
                HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), 1);
                HOperatorSet.SetDraw(HDevWindowStack.GetActive(), "fill");
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
                }
                if (HDevWindowStack.IsOpen())
                {

                }
                if (HDevWindowStack.IsOpen())
                {

                }
                if (HDevWindowStack.IsOpen())
                {

                }
                hv_CamPar.Dispose();
                hv_CamPar = new HTuple();
                hv_CamPose.Dispose();
                hv_CamPose = new HTuple();
                hv_CamPar.Dispose();
                HOperatorSet.ReadCamPar("E:/课题/PhaseFraction/PhaseFraction/bin/Debug/result.cal",
                    out hv_CamPar);
                hv_CamPose.Dispose();
                HOperatorSet.ReadPose("E:/课题/PhaseFraction/PhaseFraction/bin/Debug/result.dat",
                    out hv_CamPose);
                hv_CamParOut.Dispose();
                hv_CamParOut = new HTuple(hv_CamPar);
                hv_R1.Dispose(); hv_C1.Dispose(); hv_R2.Dispose(); hv_C2.Dispose();
                HOperatorSet.DrawLine(hv_WinH, out hv_R1, out hv_C1, out hv_R2, out hv_C2);
                hv_R11.Dispose(); hv_C11.Dispose(); hv_R21.Dispose(); hv_C21.Dispose();
                HOperatorSet.DrawLine(hv_WinH, out hv_R11, out hv_C11, out hv_R21, out hv_C21);
                hv_RowLine.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_RowLine = new HTuple();
                    hv_RowLine = hv_RowLine.TupleConcat(hv_R1, hv_R2, hv_R11, hv_R21);
                }
                hv_ColLine.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_ColLine = new HTuple();
                    hv_ColLine = hv_ColLine.TupleConcat(hv_C1, hv_C1, hv_C11, hv_C21);
                }
                ho_Map.Dispose();
                HOperatorSet.GenRadialDistortionMap(out ho_Map, hv_CamPar, hv_CamParOut, "bilinear");
                hv_AmpThr.Dispose();
                hv_AmpThr = 8;
                hv_RoiWLen2.Dispose();
                hv_RoiWLen2 = 5;
                HOperatorSet.SetSystem("int_zooming", "true");
                //Measure 01: Coordinates for line Measure 01 [0]
                hv_LRS.Dispose();
                hv_LRS = 2336.85;
                hv_LCS.Dispose();
                hv_LCS = 1472.96;
                hv_LRE.Dispose();
                hv_LRE = 3019.72;
                hv_LCE.Dispose();
                hv_LCE = 1458.97;
                //Measure 01: Convert coordinates to rectangle2 type
                hv_TmpR.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_TmpR = 0.5 * (hv_LRS + hv_LRE);
                }
                hv_TmpC.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_TmpC = 0.5 * (hv_LCS + hv_LCE);
                }
                hv_TmpDr.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_TmpDr = hv_LRS - hv_LRE;
                }
                hv_TmpDc.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_TmpDc = hv_LCE - hv_LCS;
                }
                hv_TmpPhi.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_TmpPhi = hv_TmpDr.TupleAtan2(
                        hv_TmpDc);
                }
                hv_TmpLen1.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_TmpLen1 = 0.5 * ((((hv_TmpDr * hv_TmpDr) + (hv_TmpDc * hv_TmpDc))).TupleSqrt()
                        );
                }
                hv_TmpLen2.Dispose();
                hv_TmpLen2 = new HTuple(hv_RoiWLen2);
                //Measure 01: Create measure for line Measure 01 [0]
                //Measure 01: Attention: This assumes all images have the same size!
                hv_MsrH.Dispose();
                HOperatorSet.GenMeasureRectangle2(hv_TmpR, hv_TmpC, hv_TmpPhi, hv_TmpLen1,
                    hv_TmpLen2, 3036, 4024, "nearest_neighbor", out hv_MsrH);
                //Measure 01: ***************************************************************
                //Measure 01: * The code which follows is to be executed once / measurement *
                //Measure 01: ***************************************************************
                //Measure 01: Load image

                ho_ImageMap.Dispose();
                HOperatorSet.MapImage(ho_Image, ho_Map, out ho_ImageMap);
                ho_Image.Dispose();
                ho_Image = new HObject(ho_ImageMap);
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.SetColor(HDevWindowStack.GetActive(), "blue");
                }
                ho_rect1.Dispose();
                HOperatorSet.GenRectangle2ContourXld(out ho_rect1, hv_TmpR, hv_TmpC, hv_TmpPhi,
                    hv_TmpLen1, hv_TmpLen2);
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.SetColor(HDevWindowStack.GetActive(), "green");
                }

                hv_RowM.Dispose(); hv_ColM.Dispose(); hv_AmpM.Dispose(); hv_DisM.Dispose();
                HOperatorSet.MeasurePos(ho_Image, hv_MsrH, 1, hv_AmpThr, "all", "all", out hv_RowM,
                    out hv_ColM, out hv_AmpM, out hv_DisM);
                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.SetColor(HDevWindowStack.GetActive(), "yellow");
                }

                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    HOperatorSet.DispLine(hv_WinH, hv_RowM.TupleSelect(0), hv_ColM.TupleSelect(
                        0), hv_RowM.TupleSelect(1), hv_ColM.TupleSelect(1));
                }
                HOperatorSet.DispLine(hv_WinH, hv_R1, hv_C1, hv_R2, hv_C2);
                HOperatorSet.DispLine(hv_WinH, hv_R11, hv_C11, hv_R21, hv_C21);
                HOperatorSet.DispLine(hv_WinH, hv_R1, hv_C1, hv_R11, hv_C11);
                hv_ColWM.Dispose(); hv_RowWM.Dispose();
                HOperatorSet.ImagePointsToWorldPlane(hv_CamPar, hv_CamPose, hv_RowM, hv_ColM,
                    0.001, out hv_ColWM, out hv_RowWM);
                hv_ColW1.Dispose(); hv_RowW1.Dispose();
                HOperatorSet.ImagePointsToWorldPlane(hv_CamPar, hv_CamPose, hv_RowLine, hv_ColLine,
                    0.001, out hv_ColW1, out hv_RowW1);

                hv_TmpLen.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_TmpLen = new HTuple(hv_RowWM.TupleLength()
                        );
                }
                if ((int)(new HTuple(hv_TmpLen.TupleGreater(0))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_TmpRF.Dispose();
                        HOperatorSet.TupleSelectRange(hv_RowWM, 0, hv_TmpLen - 2, out hv_TmpRF);
                    }
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_TmpCF.Dispose();
                        HOperatorSet.TupleSelectRange(hv_ColWM, 0, hv_TmpLen - 2, out hv_TmpCF);
                    }
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_TmpRT.Dispose();
                        HOperatorSet.TupleSelectRange(hv_RowWM, 1, hv_TmpLen - 1, out hv_TmpRT);
                    }
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_TmpCT.Dispose();
                        HOperatorSet.TupleSelectRange(hv_ColWM, 1, hv_TmpLen - 1, out hv_TmpCT);
                    }
                    hv_DisWM.Dispose();
                    HOperatorSet.DistancePp(hv_TmpRF, hv_TmpCF, hv_TmpRT, hv_TmpCT, out hv_DisWM);
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_DisWM1.Dispose();
                    HOperatorSet.DistancePp(hv_RowW1.TupleSelect(0), hv_ColW1.TupleSelect(0), hv_RowW1.TupleSelect(
                        2), hv_ColW1.TupleSelect(2), out hv_DisWM1);
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    disp_message(hv_WinH, ("距离:" + hv_DisWM) + "mm", "image", ((hv_RowM.TupleSelect(
                        0)) + (hv_RowM.TupleSelect(1))) / 2, (hv_ColM.TupleSelect(1)) + 20, "yellow",
                        "false");
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    disp_message(hv_WinH, ("距离:" + hv_DisWM1) + "mm", "image", (hv_R1 + hv_R11) / 2,
                        hv_C1 - 400, "yellow", "false");
                }
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Image.Dispose();
                ho_Map.Dispose();
                ho_ImageMap.Dispose();
                ho_rect1.Dispose();

                hv_W.Dispose();
                hv_H.Dispose();
                hv_WinH.Dispose();
                hv_CamPar.Dispose();
                hv_CamPose.Dispose();
                hv_CamParOut.Dispose();
                hv_R1.Dispose();
                hv_C1.Dispose();
                hv_R2.Dispose();
                hv_C2.Dispose();
                hv_R11.Dispose();
                hv_C11.Dispose();
                hv_R21.Dispose();
                hv_C21.Dispose();
                hv_RowLine.Dispose();
                hv_ColLine.Dispose();
                hv_AmpThr.Dispose();
                hv_RoiWLen2.Dispose();
                hv_LRS.Dispose();
                hv_LCS.Dispose();
                hv_LRE.Dispose();
                hv_LCE.Dispose();
                hv_TmpR.Dispose();
                hv_TmpC.Dispose();
                hv_TmpDr.Dispose();
                hv_TmpDc.Dispose();
                hv_TmpPhi.Dispose();
                hv_TmpLen1.Dispose();
                hv_TmpLen2.Dispose();
                hv_MsrH.Dispose();
                hv_RowM.Dispose();
                hv_ColM.Dispose();
                hv_AmpM.Dispose();
                hv_DisM.Dispose();
                hv_ColWM.Dispose();
                hv_RowWM.Dispose();
                hv_ColW1.Dispose();
                hv_RowW1.Dispose();
                hv_TmpLen.Dispose();
                hv_TmpRF.Dispose();
                hv_TmpCF.Dispose();
                hv_TmpRT.Dispose();
                hv_TmpCT.Dispose();
                hv_DisWM.Dispose();
                hv_DisWM1.Dispose();

                throw HDevExpDefaultException;
            }
            ho_Image.Dispose();
            ho_Map.Dispose();
            ho_ImageMap.Dispose();
            ho_rect1.Dispose();

            hv_W.Dispose();
            hv_H.Dispose();
            hv_WinH.Dispose();
            hv_CamPar.Dispose();
            hv_CamPose.Dispose();
            hv_CamParOut.Dispose();
            hv_R1.Dispose();
            hv_C1.Dispose();
            hv_R2.Dispose();
            hv_C2.Dispose();
            hv_R11.Dispose();
            hv_C11.Dispose();
            hv_R21.Dispose();
            hv_C21.Dispose();
            hv_RowLine.Dispose();
            hv_ColLine.Dispose();
            hv_AmpThr.Dispose();
            hv_RoiWLen2.Dispose();
            hv_LRS.Dispose();
            hv_LCS.Dispose();
            hv_LRE.Dispose();
            hv_LCE.Dispose();
            hv_TmpR.Dispose();
            hv_TmpC.Dispose();
            hv_TmpDr.Dispose();
            hv_TmpDc.Dispose();
            hv_TmpPhi.Dispose();
            hv_TmpLen1.Dispose();
            hv_TmpLen2.Dispose();
            hv_MsrH.Dispose();
            hv_RowM.Dispose();
            hv_ColM.Dispose();
            hv_AmpM.Dispose();
            hv_DisM.Dispose();
            hv_ColWM.Dispose();
            hv_RowWM.Dispose();
            hv_ColW1.Dispose();
            hv_RowW1.Dispose();
            hv_TmpLen.Dispose();
            hv_TmpRF.Dispose();
            hv_TmpCF.Dispose();
            hv_TmpRT.Dispose();
            hv_TmpCT.Dispose();
            hv_DisWM.Dispose();
            hv_DisWM1.Dispose();

        }

        private void action(HObject ho_Image)
        {
                        // Local iconic variables 
            HObject ho_Map, ho_ImageMap, ho_rect1;
                        // Local control variables 
            HTuple hv_W = new HTuple(), hv_H = new HTuple(), hv_CamParOut = new HTuple(), hv_R1 = new HTuple(), hv_C1 = new HTuple(), hv_R2 = new HTuple(), hv_C2 = new HTuple(), hv_R11 = new HTuple(), hv_C11 = new HTuple();
            HTuple hv_R21 = new HTuple(), hv_C21 = new HTuple(), hv_RowLine = new HTuple(), hv_ColLine = new HTuple(), hv_RoiWLen2 = new HTuple(), hv_LRS = new HTuple(), hv_DisWM1 = new HTuple();
            HTuple hv_LCS = new HTuple(), hv_LRE = new HTuple(), hv_LCE = new HTuple(), hv_TmpR = new HTuple(), hv_TmpC = new HTuple(), hv_TmpDr = new HTuple(), hv_TmpDc = new HTuple(),hv_TmpPhi = new HTuple(), hv_TmpLen1 = new HTuple();
            HTuple hv_TmpLen2 = new HTuple(), hv_MsrH = new HTuple(), hv_RowM = new HTuple(), hv_ColM = new HTuple(), hv_AmpM = new HTuple(), hv_DisM = new HTuple(), hv_ColWM = new HTuple(), hv_RowWM = new HTuple(), hv_WinH = new HTuple();
            HTuple hv_ColW1 = new HTuple(), hv_RowW1 = new HTuple(), hv_TmpLen = new HTuple(), hv_TmpRF = new HTuple(), hv_TmpCF = new HTuple(), hv_TmpRT = new HTuple(), hv_TmpCT = new HTuple(), hv_DisWM = new HTuple();
         
            try
            {
                HOperatorSet.GetImageSize(ho_Image, out hv_W, out hv_H);
                HOperatorSet.SetWindowAttr("background_color", "black");
                HOperatorSet.OpenWindow(0, 0, hv_W / 5, hv_H / 5, 0, "visible", "", out hv_WinH);
                HDevWindowStack.Push(hv_WinH);
                set_display_font(hv_WinH, 9, "mono", "true", "false");
                HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
                HOperatorSet.SetDraw(HDevWindowStack.GetActive(), "fill");
                HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), 1);
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "green");
                hv_CamParOut = new HTuple(CamPar);
                HOperatorSet.DrawLine(hv_WinH, out hv_R1, out hv_C1, out hv_R2, out hv_C2);
                HOperatorSet.DrawLine(hv_WinH, out hv_R11, out hv_C11, out hv_R21, out hv_C21);
                hv_RowLine = new HTuple();
                hv_RowLine = hv_RowLine.TupleConcat(hv_R1, hv_R2, hv_R11, hv_R21);
                hv_ColLine = new HTuple();
                hv_ColLine = hv_ColLine.TupleConcat(hv_C1, hv_C1, hv_C11, hv_C21);
                HOperatorSet.GenRadialDistortionMap(out ho_Map, CamPar, hv_CamParOut, "bilinear");
                HOperatorSet.SetSystem("int_zooming", "true");
                HOperatorSet.DrawRectangle2(hv_WinH, out hv_TmpR, out hv_TmpC, out hv_TmpPhi, out hv_TmpLen1, out hv_TmpLen2);
                HOperatorSet.GenMeasureRectangle2(hv_TmpR, hv_TmpC, hv_TmpPhi, hv_TmpLen1, hv_TmpLen2, hv_W, hv_H, "nearest_neighbor", out hv_MsrH);

                HOperatorSet.MapImage(ho_Image, ho_Map, out ho_ImageMap);
                ho_Image = new HObject(ho_ImageMap);
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "blue");
                HOperatorSet.GenRectangle2ContourXld(out ho_rect1, hv_TmpR, hv_TmpC, hv_TmpPhi, hv_TmpLen1, hv_TmpLen2);
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "green");
                HOperatorSet.MeasurePos(ho_Image, hv_MsrH, 1, AmpThr, Transition, Select, out hv_RowM, out hv_ColM, out hv_AmpM, out hv_DisM);
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "yellow");
                HOperatorSet.DispLine(hv_WinH, hv_RowM.TupleSelect(0), hv_ColM.TupleSelect(0), hv_RowM.TupleSelect(1), hv_ColM.TupleSelect(1));
                HOperatorSet.DispLine(hv_WinH, hv_R1, hv_C1, hv_R2, hv_C2);
                HOperatorSet.DispLine(hv_WinH, hv_R11, hv_C11, hv_R21, hv_C21);
                HOperatorSet.DispLine(hv_WinH, hv_R1, hv_C1, hv_R11, hv_C11);
                HOperatorSet.ImagePointsToWorldPlane(CamPar, CamPose, hv_RowM, hv_ColM, 0.001, out hv_ColWM, out hv_RowWM);
                HOperatorSet.ImagePointsToWorldPlane(CamPar, CamPose, hv_RowLine, hv_ColLine, 0.001, out hv_ColW1, out hv_RowW1);
                hv_TmpLen = new HTuple(hv_RowWM.TupleLength());
                if ((int)(new HTuple(hv_TmpLen.TupleGreater(0))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_TmpRF.Dispose();
                        HOperatorSet.TupleSelectRange(hv_RowWM, 0, hv_TmpLen - 2, out hv_TmpRF);
                    }
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_TmpCF.Dispose();
                        HOperatorSet.TupleSelectRange(hv_ColWM, 0, hv_TmpLen - 2, out hv_TmpCF);
                    }
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_TmpRT.Dispose();
                        HOperatorSet.TupleSelectRange(hv_RowWM, 1, hv_TmpLen - 1, out hv_TmpRT);
                    }
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_TmpCT.Dispose();
                        HOperatorSet.TupleSelectRange(hv_ColWM, 1, hv_TmpLen - 1, out hv_TmpCT);
                    }
                    hv_DisWM.Dispose();
                    HOperatorSet.DistancePp(hv_TmpRF, hv_TmpCF, hv_TmpRT, hv_TmpCT, out hv_DisWM);
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_DisWM1.Dispose();
                    HOperatorSet.DistancePp(hv_RowW1.TupleSelect(0), hv_ColW1.TupleSelect(0), hv_RowW1.TupleSelect(
                        2), hv_ColW1.TupleSelect(2), out hv_DisWM1);
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    disp_message(hv_WinH, ("距离:" + hv_DisWM) + "mm", "image", ((hv_RowM.TupleSelect(
                        0)) + (hv_RowM.TupleSelect(1))) / 2, (hv_ColM.TupleSelect(1)) + 20, "yellow",
                        "false");
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    disp_message(hv_WinH, ("距离:" + hv_DisWM1) + "mm", "image", (hv_R1 + hv_R11) / 2,
                        hv_C1 - 400, "yellow", "false");
                }
            }
            catch (HalconException HDevExpDefaultException)
            {
              
                throw HDevExpDefaultException;
            }
          
        }
    }
}
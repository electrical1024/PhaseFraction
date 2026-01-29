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
        public HObject CurrentImage = null, CheckRect = new HObject();
        public bool IsVideo = false;
        public bool IsPhoto = false;
        public bool FindEdge = false;
        public HTuple TmpR = new HTuple(), TmpC = new HTuple(), TmpPhi = new HTuple(), TmpLen1 = new HTuple(), TmpLen2 = new HTuple();
        public HTuple LineR1 = new HTuple(), LineC1 = new HTuple(), LineR2 = new HTuple(), LineC2 = new HTuple();
        public HTuple LineR21 = new HTuple(), LineC21 = new HTuple(), LineR11 = new HTuple(), LineC11 = new HTuple();
        public HTuple CamPar = new HTuple(), CamPose = new HTuple(), AmpThr = new HTuple(), Sigma = new HTuple(), WinH = new HTuple();
        public string Transition = "all", Select = "all";
        public HTuple RowM = new HTuple(), ColM = new HTuple(), AmpM = new HTuple(), DisM = new HTuple();
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
                ProcessImage(image);

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
                MsgofVision("录像错误：" + exp.Message, LogType.ListShow, true);
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

        public void DispMessage(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem, HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)

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

        public void SetDisplayFont(HTuple hv_WindowHandle, HTuple hv_Size, HTuple hv_Font, HTuple hv_Bold, HTuple hv_Slant)

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

        public void DrawEdge(HObject image)
        {
              HTuple imageW = new HTuple(), imageH = new HTuple();
            try
            {
                HOperatorSet.GetImageSize(image, out imageW, out imageH);
                HOperatorSet.SetWindowAttr("background_color", "black");
                HOperatorSet.OpenWindow(0, 0, imageW / 4, imageH / 4, 0, "visible", "", out WinH);
                HDevWindowStack.Push(WinH);
                HOperatorSet.SetSystem("int_zooming", "true");
                SetDisplayFont(WinH, 9, "mono", "true", "false");
                HOperatorSet.DispObj(image, HDevWindowStack.GetActive());
                HOperatorSet.SetDraw(HDevWindowStack.GetActive(), "fill");
                HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), 1);
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "green");
                HOperatorSet.DrawLine(WinH, out LineR1, out LineC1, out LineR2, out LineC2);
                HOperatorSet.DispLine(WinH, LineR1, LineC1, LineR2, LineC2);
                HOperatorSet.DrawLine(WinH, out LineR11, out LineC11, out LineR21, out LineC21);
                HOperatorSet.DispLine(WinH, LineR11, LineC11, LineR21, LineC21);
                HOperatorSet.DrawRectangle2(WinH, out TmpR, out TmpC, out TmpPhi, out TmpLen1, out TmpLen2);
                HOperatorSet.GenRectangle2ContourXld(out CheckRect, TmpR, TmpC, TmpPhi, TmpLen1, TmpLen2);
                HOperatorSet.DispXld(CheckRect, WinH);
                ConfigClass config = new ConfigClass();
                config.WriteINIConfig("LineR1", Convert.ToString((double)LineR1));
                config.WriteINIConfig("LineC1", Convert.ToString((double)LineC1));
                config.WriteINIConfig("LineR2", Convert.ToString((double)LineR2));
                config.WriteINIConfig("LineC2", Convert.ToString((double)LineC2));
                config.WriteINIConfig("LineR11", Convert.ToString((double)LineR11));
                config.WriteINIConfig("LineC11", Convert.ToString((double)LineC11));
                config.WriteINIConfig("LineR21", Convert.ToString((double)LineR21));
                config.WriteINIConfig("LineC21", Convert.ToString((double)LineC21));
                config.WriteINIConfig("TmpR", Convert.ToString((double)TmpR));
                config.WriteINIConfig("TmpC", Convert.ToString((double)TmpC));
                config.WriteINIConfig("TmpPhi", Convert.ToString((double)TmpPhi));
                config.WriteINIConfig("TmpLen1", Convert.ToString((double)TmpLen1));
                config.WriteINIConfig("TmpLen2", Convert.ToString((double)TmpLen2));
            }
            catch (HalconException HDevExpDefaultException)
            {
                MsgofVision("图像处理错误：" + HDevExpDefaultException.Message, LogType.ListShow, true);
            }

        }


        public void EdgeDisplay(HObject image)
        {
            HTuple imageW = new HTuple(), imageH = new HTuple();
            HObject ho_Map, ho_ImageMap;
            HTuple hv_MsrH = new HTuple(),  hv_CamParOut = new HTuple();
            try
            {
              
                HOperatorSet.GetImageSize(image, out imageW, out imageH);
                HOperatorSet.ClearWindow(WinH);
                HOperatorSet.DispImage(image, WinH);
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "green");
                HOperatorSet.DispLine(WinH, LineR1, LineC1, LineR2, LineC2);
                HOperatorSet.DispLine(WinH, LineR11, LineC11, LineR21, LineC21);
                HOperatorSet.DispXld(CheckRect, WinH);
              
                HOperatorSet.GenMeasureRectangle2(TmpR, TmpC, TmpPhi, TmpLen1, TmpLen2, imageW, imageH, "nearest_neighbor", out hv_MsrH);
                hv_CamParOut = new HTuple(CamPar);
                HOperatorSet.GenRadialDistortionMap(out ho_Map, CamPar, hv_CamParOut, "bilinear");
                HOperatorSet.MapImage(image, ho_Map, out ho_ImageMap);
                image = new HObject(ho_ImageMap);
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "blue");
                HOperatorSet.MeasurePos(image, hv_MsrH, 1, AmpThr, Transition, Select, out RowM, out ColM, out AmpM, out DisM);
                HOperatorSet.DispCross(WinH, RowM, ColM, 16, 0);
                CurrentImage=image;
            }
            catch (HalconException HDevExpDefaultException)
            {
                MsgofVision("图像处理错误：" + HDevExpDefaultException.Message, LogType.ListShow, true);
            }
        }

        public void CalculateDistance(HObject image)
        {
            HTuple hv_DisPL1 = new HTuple(), hv_DisPL2 = new HTuple(), hv_ColW2 = new HTuple(), hv_RowW2 = new HTuple();
            HTuple hv_ColW11 = new HTuple(), hv_RowW11 = new HTuple(), hv_ColW21 = new HTuple(), hv_RowW21 = new HTuple();
            HTuple  hv_ColWM = new HTuple(), hv_RowWM = new HTuple(), hv_DisWM = new HTuple(), hv_ColW1 = new HTuple(), hv_RowW1 = new HTuple();
            try
            {

                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "yellow");
                HOperatorSet.DispLine(WinH, RowM.TupleSelect(0), ColM.TupleSelect(0), RowM.TupleSelect(1), ColM.TupleSelect(1));
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "blue");
                HOperatorSet.DispLine(WinH, RowM.TupleSelect(0), ColM.TupleSelect(0), LineR2, ColM.TupleSelect(0));
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "red");
                HOperatorSet.DispLine(WinH, RowM.TupleSelect(1), ColM.TupleSelect(1), LineR21, ColM.TupleSelect(1));
              
                HOperatorSet.ImagePointsToWorldPlane(CamPar, CamPose, RowM, ColM, 0.001, out hv_ColWM, out hv_RowWM);
                HOperatorSet.ImagePointsToWorldPlane(CamPar, CamPose, LineR1, LineC1, 0.001, out hv_ColW1, out hv_RowW1);
                HOperatorSet.ImagePointsToWorldPlane(CamPar, CamPose, LineR2, LineC2, 0.001, out hv_ColW2, out hv_RowW2);
                HOperatorSet.ImagePointsToWorldPlane(CamPar, CamPose, LineR11, LineC11, 0.001, out hv_ColW11, out hv_RowW11);
                HOperatorSet.ImagePointsToWorldPlane(CamPar, CamPose, LineR21, LineC21, 0.001, out hv_ColW21, out hv_RowW21);
                HOperatorSet.DistancePp(hv_RowWM.TupleSelect(0), hv_ColWM.TupleSelect(0), hv_RowWM.TupleSelect(1), hv_ColWM.TupleSelect(1), out hv_DisWM);
                HOperatorSet.DistancePl(hv_RowWM.TupleSelect(0), hv_ColWM.TupleSelect(0), hv_RowW1,hv_ColW1, hv_RowW2, hv_ColW2, out hv_DisPL1);
                HOperatorSet.DistancePl(hv_RowWM.TupleSelect(1), hv_ColWM.TupleSelect(1), hv_RowW11, hv_ColW11, hv_RowW21, hv_ColW21, out hv_DisPL2);

                DispMessage(WinH, ("距离:" + hv_DisWM) + "mm", "image", ((RowM.TupleSelect(0)) + (RowM.TupleSelect(1))) / 2, (ColM.TupleSelect(1)) + 20, "yellow", "false");
                DispMessage(WinH, ("距离:" + hv_DisPL1) + "mm", "image", (RowM.TupleSelect(0) + LineR2) / 2, ColM.TupleSelect(0) + 20, "blue", "false");
                DispMessage(WinH, ("距离:" + hv_DisPL2) + "mm", "image", (RowM.TupleSelect(1) + LineR21) / 2, ColM.TupleSelect(1) + 20, "red", "false");
            }
            catch (HalconException HDevExpDefaultException)
            {
                MsgofVision("图像处理错误：" + HDevExpDefaultException.Message, LogType.ListShow, true);
            }
        }

        public void AutoCalLevel2(HObject image)
        {
            HObject ho_Map, ho_ImageMap;
            HTuple hv_MsrH = new HTuple(), hv_CamParOut = new HTuple(), imageW = new HTuple(), imageH = new HTuple();
            HTuple hv_DisPL1 = new HTuple(), hv_DisPL2 = new HTuple(), hv_ColW2 = new HTuple(), hv_RowW2 = new HTuple();
            HTuple hv_ColW11 = new HTuple(), hv_RowW11 = new HTuple(), hv_ColW21 = new HTuple(), hv_RowW21 = new HTuple();
            HTuple hv_ColWM = new HTuple(), hv_RowWM = new HTuple(), hv_DisWM = new HTuple(), hv_ColW1 = new HTuple(), hv_RowW1 = new HTuple();
            HTuple rowM = new HTuple(), colM = new HTuple(), ampM = new HTuple(), disM = new HTuple();
            try
            {
                HOperatorSet.GetImageSize(image, out imageW, out imageH);
                HOperatorSet.GenMeasureRectangle2(TmpR, TmpC, TmpPhi, TmpLen1, TmpLen2, imageW, imageH, "nearest_neighbor", out hv_MsrH);
                hv_CamParOut = new HTuple(CamPar);
                HOperatorSet.GenRadialDistortionMap(out ho_Map, CamPar, hv_CamParOut, "bilinear");
                HOperatorSet.MapImage(image, ho_Map, out ho_ImageMap);
                image = new HObject(ho_ImageMap);
                HOperatorSet.MeasurePos(image, hv_MsrH, 1, AmpThr, Transition, Select, out rowM, out colM, out ampM, out disM);

                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "yellow");
                HOperatorSet.DispLine(WinH, rowM.TupleSelect(0), colM.TupleSelect(0), rowM.TupleSelect(1), colM.TupleSelect(1));
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "blue");
                HOperatorSet.DispLine(WinH, rowM.TupleSelect(0), colM.TupleSelect(0), LineR2, colM.TupleSelect(0));
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), "red");
                HOperatorSet.DispLine(WinH, rowM.TupleSelect(1), colM.TupleSelect(1), LineR21, colM.TupleSelect(1));

                HOperatorSet.ImagePointsToWorldPlane(CamPar, CamPose, RowM, ColM, 0.001, out hv_ColWM, out hv_RowWM);
                HOperatorSet.ImagePointsToWorldPlane(CamPar, CamPose, LineR1, LineC1, 0.001, out hv_ColW1, out hv_RowW1);
                HOperatorSet.ImagePointsToWorldPlane(CamPar, CamPose, LineR2, LineC2, 0.001, out hv_ColW2, out hv_RowW2);
                HOperatorSet.ImagePointsToWorldPlane(CamPar, CamPose, LineR11, LineC11, 0.001, out hv_ColW11, out hv_RowW11);
                HOperatorSet.ImagePointsToWorldPlane(CamPar, CamPose, LineR21, LineC21, 0.001, out hv_ColW21, out hv_RowW21);
                HOperatorSet.DistancePp(hv_RowWM.TupleSelect(0), hv_ColWM.TupleSelect(0), hv_RowWM.TupleSelect(1), hv_ColWM.TupleSelect(1), out hv_DisWM);
                HOperatorSet.DistancePl(hv_RowWM.TupleSelect(0), hv_ColWM.TupleSelect(0), hv_RowW1, hv_ColW1, hv_RowW2, hv_ColW2, out hv_DisPL1);
                HOperatorSet.DistancePl(hv_RowWM.TupleSelect(1), hv_ColWM.TupleSelect(1), hv_RowW11, hv_ColW11, hv_RowW21, hv_ColW21, out hv_DisPL2);

                DispMessage(WinH, ("距离:" + hv_DisWM) + "mm", "image", ((rowM.TupleSelect(0)) + (rowM.TupleSelect(1))) / 2, (colM.TupleSelect(1)) + 20, "yellow", "false");
                DispMessage(WinH, ("距离:" + hv_DisPL1) + "mm", "image", (rowM.TupleSelect(0) + LineR2) / 2, colM.TupleSelect(0) + 20, "blue", "false");
                DispMessage(WinH, ("距离:" + hv_DisPL2) + "mm", "image", (rowM.TupleSelect(1) + LineR21) / 2, colM.TupleSelect(1) + 20, "red", "false");
            }
            catch (HalconException HDevExpDefaultException)
            {
                MsgofVision("图像处理错误：" + HDevExpDefaultException.Message, LogType.ListShow, true);
            }
        }

        public void CloseWindow()
        {
            try
            {
                HalconAPI.CancelDraw();
              
                HOperatorSet.CloseWindow(WinH);
                       
            }
            catch (HalconException HDevExpDefaultException)
            {
                MsgofVision("图像处理错误：" + HDevExpDefaultException.Message, LogType.ListShow, true);
            }
        }
    }
}
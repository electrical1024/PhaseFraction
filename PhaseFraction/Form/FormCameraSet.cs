using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhaseFraction
{
    public partial class FormCameraSet : Form
    {
        public FormCameraSet()
        {
            InitializeComponent();
        }
        HDrawingObject DoRoi = null;
        HObject m_SrcImage = new HObject();
        HSmartWindowControl SmartWindowControl = null;
        private void BtnPhoto_Click(object sender, EventArgs e)
        {
            VisionClass.instance().DisplayWindow=FormMain.MainFrm.hSmartWindowControl1.HalconWindow;    
            VisionClass.instance().IsPhoto=true;
                    }

        private void Btnvideo_Click(object sender, EventArgs e)
        {
            if (Btnvideo.Text == "开始录像")
            {
                Btnvideo.Text = "停止录像";
                VisionClass.instance().DisplayWindow = FormMain.MainFrm.hSmartWindowControl1.HalconWindow;
                VisionClass.instance().IsVideo = true;
            }
            else 
            {
                Btnvideo.Text = "开始录像";
                VisionClass.instance().IsVideo =  false;
            }
        }

        private void FormCameraSet_Load(object sender, EventArgs e)
        {
            Btnvideo.Text = "开始录像";
            SmartWindowControl= FormMain.MainFrm.hSmartWindowControl1;
        }

        private void FormCameraSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisionClass.instance().IsVideo = false;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "images|*.tiff;*.tif;*.bmp;*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                HOperatorSet.ReadImage(out m_SrcImage, dialog.FileName);
                //HTuple width, height;
                //HOperatorSet.GetImageSize(m_SrcImage, out width, out height);
                //HOperatorSet.DispObj(m_SrcImage, hSmartWindowControl1.HalconWindow);
                ShowImage(m_SrcImage);
            }
        }
        public void ShowImage(HObject image)
        {
            if (image == null)
                return;

            //获取图像及显示窗口长宽
            HOperatorSet.GetImageSize(image, out HTuple imgWidth, out HTuple imgHeight);
            int wndWidth = SmartWindowControl.ClientRectangle.Width;
            int wndHeight = SmartWindowControl.ClientRectangle.Height;

            //计算比例
            double scale = Math.Max(1.0 * imgWidth.I / wndWidth, 1.0 * imgHeight / wndHeight);
            double w = wndWidth * scale;
            double h = wndHeight * scale;
            //居中时，Part的区域
            SmartWindowControl.HalconWindow.SetPart(-(h - imgHeight) / 2, -(w - imgWidth) / 2, imgHeight + (h - imgHeight.D) / 2, imgWidth + (w - imgWidth) / 2);

            //背景色
            SmartWindowControl.HalconWindow.SetWindowParam("background_color", "black");
            SmartWindowControl.HalconWindow.ClearWindow();

            SmartWindowControl.HalconWindow.DispObj(image);
            //画根测试线
            //HOperatorSet.GenRegionLine(out HObject line, 0, 0, imgHeight, imgWidth);
            //hSmartWindowControl1.HalconWindow.SetColor("green");
            //hSmartWindowControl1.HalconWindow.DispObj(line);
        }

        public void DrawROI()
        {
            if (DoRoi == null)
            {

                //创建一个矩形的显示实例
                DoRoi = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE1, 500, 500, 1000, 1000);
                DoRoi.SetDrawingObjectParams("color", "green");
                //挂靠实例到HSmartWindowControl控件
                SmartWindowControl.HalconWindow.AttachDrawingObjectToWindow(DoRoi);
            }
            else
            {
                //hSmartWindowControl1.HalconWindow.DetachDrawingObjectFromWindow(doRoi);//这里这句可以不要
                //doRoi = null;
            }

        }

        public void GenROI()
        {
            //获取矩形参数
            string[] str = { "row1", "column1", "row2", "column2" };
            HTuple val = DoRoi.GetDrawingObjectParams(str);

            //生成ROI
            HOperatorSet.GenRectangle1(out HObject roi, val[0], val[1], val[2], val[3]);
            HOperatorSet.ReduceDomain(m_SrcImage, roi, out HObject imageROI);
            ShowImage(imageROI);
        }

        private void BtnDrawRoi_Click(object sender, EventArgs e)
        {
            DrawROI();
        }

        private void BtnGenRoi_Click(object sender, EventArgs e)
        {
            GenROI();
        }
    }
}

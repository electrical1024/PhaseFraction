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

        private void BtnPhoto_Click(object sender, EventArgs e)
        {
            VisionClass.instance().TakePhoto();
        }

        private void Btnvideo_Click(object sender, EventArgs e)
        {
            if (Btnvideo.Text == "开始录像")
            {
                Btnvideo.Text = "停止录像";
                VisionClass.instance().TakeVideo();
            }
            else 
            {
                Btnvideo.Text = "开始录像";
                VisionClass.instance().IsVideo = false;
            }
        }

        private void FormCameraSet_Load(object sender, EventArgs e)
        {
            Btnvideo.Text = "开始录像";
        }

        private void FormCameraSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisionClass.instance().IsVideo = false;
        }
    }
}

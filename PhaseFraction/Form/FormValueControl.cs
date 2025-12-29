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
    public partial class FormValueControl : Form
    {
        public FormValueControl()
        {
            InitializeComponent();
        }

        private void BtnByPassValue_Click(object sender, EventArgs e)
        {
            if (BtnByPassValue.Text == "打开旁路电磁阀")
            {
                BtnByPassValue.Text = "关闭旁路电磁阀";
                
            }
            else
            {
                BtnByPassValue.Text = "打开旁路电磁阀";
                
            }
        }
    }
}

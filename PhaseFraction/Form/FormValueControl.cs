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
        PLCClass PLC = PLCClass.SingletonInstance;
        private void BtnByPassValue_Click(object sender, EventArgs e)
        {
            if (BtnByPassValue.Text == "打开直通电磁阀")
            {
                BtnByPassValue.Text = "关闭直通电磁阀";
                PLC.PLCWrite(PLC.ByPassValue, true);
            }
            else
            {
                BtnByPassValue.Text = "打开直通电磁阀";
                PLC.PLCWrite(PLC.ByPassValue, false);
            }
        }

        private void BtnOutGasValue_Click(object sender, EventArgs e)
        {
            if (BtnOutGasValue.Text == "打开排气电磁阀")
            {
                BtnOutGasValue.Text = "关闭排气电磁阀";
                PLC.PLCWrite(PLC.OutGasValue, true);
            }
            else
            {
                BtnOutGasValue.Text = "打开排气电磁阀";
                PLC.PLCWrite(PLC.OutGasValue, false);
            }
        }

        private void BtnInLiquidValue_Click(object sender, EventArgs e)
        {
            if (BtnInLiquidValue.Text == "打开进液电磁阀")
            {
                BtnInLiquidValue.Text = "关闭进液电磁阀";
                PLC.PLCWrite(PLC.InLiquidValue, true);
            }
            else
            {
                BtnInLiquidValue.Text = "打开进液电磁阀";
                PLC.PLCWrite(PLC.InLiquidValue, false);
            }
        }

        private void BtnOutLiquidValue_Click(object sender, EventArgs e)
        {
            if (BtnOutLiquidValue.Text == "打开出液电磁阀")
            {
                BtnOutLiquidValue.Text = "关闭出液电磁阀";
                PLC.PLCWrite(PLC.OutLiquidValue, true);
            }
            else
            {
                BtnOutLiquidValue.Text = "打开出液电磁阀";
                PLC.PLCWrite(PLC.OutLiquidValue, false);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhaseFraction
{
    class TimeoutUtilsClass
    {
        //超時小工具
        private DateTime timeBegin;
        //構造函數初始化開始時間為當前時間
        public TimeoutUtilsClass()
        {
            timeBegin = DateTime.Now;
        }
        //計算是否從初始化或重置到現在超時 millSeconds 毫秒
        public bool IsTimeout(System.UInt32 millSeconds, bool reset)
        {
            if (reset)
            {
                Reset();
                return false;
            }
            else
            {
                try
                {
                    System.Threading.Thread.Sleep(5);
                    if (DateTime.Now.Subtract(timeBegin).TotalMilliseconds > millSeconds)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
        //重置開始時間
        public void Reset()
        {
            try
            {
                System.Threading.Thread.Sleep(5);
                timeBegin = DateTime.Now;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //得到當前逝去的時間
        public System.UInt64 GetTimeElasped()
        {
            try
            {
                System.Threading.Thread.Sleep(5);
                return (System.UInt32)DateTime.Now.Subtract(timeBegin).TotalMilliseconds;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return (System.UInt32)0;
            }
        }
    }
}

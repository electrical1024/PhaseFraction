using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhaseFraction
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool creatNew;
            System.Threading.Mutex m = new System.Threading.Mutex(true, Application.ProductName, out creatNew);
            if (creatNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("程序已在运行中!", "提示:");
                return;
            }
        }
    }
}

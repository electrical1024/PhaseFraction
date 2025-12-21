using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace PhaseFraction
{
      public partial class WarningMessage : Form
      {
            public WarningMessage()
            {
                  InitializeComponent();
            }

            private void button1_Click(object sender, EventArgs e)
            {
                  this.Close();
                  this.Dispose();
            }
      }
}

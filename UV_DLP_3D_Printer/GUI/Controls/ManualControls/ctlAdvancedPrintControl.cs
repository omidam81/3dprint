using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI.Controls.ManualControls
{
    public partial class ctlAdvancedPrintControl : UserControl
    {
        public ctlAdvancedPrintControl()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(new OpenFileDialog().ShowDialog() == DialogResult.OK)
            {
                //send file for print;
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI.Controls.ManualControls
{
    public partial class ctlCheckPowder : UserControl
    {
       
        public ctlCheckPowder()
        {
            InitializeComponent();
        }

        

        private void btnCleanPrintHead_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The feed powder available is 23cm", "info");
        }

        private void btnCapping_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The space available is 7cm", "info");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The fluid available is 8 L", "info");
        }
    }
}

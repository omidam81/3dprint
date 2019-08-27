using System;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI.Controls.ManualControls
{
    public partial class ctlStandardManual : UserControl
    {
        public ctlStandardManual()
        {
            InitializeComponent();
        }

        private void btnHomePrintHeads_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction.PLC.HomeXY();
        }

        private void btnHomeFeed_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction.PLC.HomeZ1();
        }

        private void btnHomePrint_Click(object sender, EventArgs e)
        {
           var result= MessageBox.Show("The printbed will move all the way up, Please be sure to depowder the printing bed first","info",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(result==DialogResult.OK)
            UVDLPApp.Instance().IntegrationFunction.PLCFunction.PLC.HomeZ2();
        }

        private void btnHomeAll_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("The printbed will move all the way up and the printheads will go to home position, Please be sure to depowdering the printig bed first and remove objects the printhead path", "info", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
                UVDLPApp.Instance().IntegrationFunction.PLCFunction.PLC.HomeAll();
        }

        private void btnMoveFeeding_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction.PLC.StepZ1(5);
        }

        private void btnMovePrinting_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction.PLC.StepZ1(-5);

            ///UVDLPApp.Instance().IntegrationFunction.PLCFunction.PLC.StepZ2((float)numctlParameter1.Value);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction.PLC.StepZ2(5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction.PLC.StepZ2(-5);
        }
    }
}

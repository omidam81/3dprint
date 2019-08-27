using System;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI.Controls.ManualControls
{
    public partial class ctlSeviceStation : UserControl
    {
       
        public ctlSeviceStation()
        {
            InitializeComponent();
        }

        

        private void btnCleanPrintHead_Click(object sender, EventArgs e)
        {
            //    UVDLPApp.Instance().IntegrationFunction.PLCFunction
            //      .PLC.ChangeVelocityX((float)ctlXspeed.Value);
        }

        private void btnCapping_Click(object sender, EventArgs e)
        {
            //    UVDLPApp.Instance().IntegrationFunction.PLCFunction
            //      .PLC.ChangeVelocityX((float)ctlXspeed.Value);
        }

        
    }
}

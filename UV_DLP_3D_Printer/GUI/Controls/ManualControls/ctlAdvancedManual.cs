using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI.CustomGUI;

namespace UV_DLP_3D_Printer.GUI.Controls.ManualControls
{
    public partial class ctlAdvancedManual : UserControl
    {
        public ctlAdvancedManual()
        {
            InitializeComponent();
           // UVDLPApp.Instance().m_gui_config.AddControl("ctlManualControl", ctlStandardManual);
        }

        private void ctlMoveX_ValueChanged(object sender, decimal newval)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction.ChangePosX((float)ctlMoveX.Value);
        }

        private void ctlMoveY_ValueChanged(object sender, decimal newval)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction.ChangePosY((float)ctlMoveY.Value);

        }

        

        private void btnSpread_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction
                .PLC.SpreadCycle(Convert.ToInt32(numAmountLayers.Value));
        }

        private void btnMoveXaxis_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction
                .PLC.ChangePosX((float)ctlMoveX.Value);
        }

        private void btnMoveYaxis_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction
                .PLC.ChangePosY((float)ctlMoveY.Value);
        }

        private void btnMoveFeed_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction
               .PLC.StepZ1(Convert.ToInt32(txtMoveFeed));
        }

        private void btnMovePrinting_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction
               .PLC.StepZ2(Convert.ToInt32(txtMovePrinting));
        }

        private void btnXspeed_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction
              .PLC.ChangeVelocityX((float)ctlXspeed.Value);
        }

        private void btnYspeed_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction
             .PLC.ChangeVelocityY((float)ctlYspeed.Value);
        }

        private void btnZspeed_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction
             .PLC.ChangeVelocityZ((float)ctlZspeed.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

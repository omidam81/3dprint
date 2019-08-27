using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI.CustomGUI;
using UV_DLP_3D_Printer.Device_Interface.AutoDetect;
namespace UV_DLP_3D_Printer.GUI.Controls.ManualControls
{
    public partial class ctlMainManual : UserControl
    {
        public ctlMainManual()
        {
            InitializeComponent();
            //UVDLPApp.Instance().m_gui_config.AddControl("ctlManualControl", ctlManualControl1);
            if (!(DesignMode))
            {
                var com = SerialAutodetect.Instance().DeterminePort(UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_connection.speed);
                if (com.Equals(((DesignMode) ? "Invalid" : UVDLPApp.Instance().resman.GetString("Invalid", UVDLPApp.Instance().cul))))
                {
                    ctlStandardManual1.Enabled = ctlFluidSuply1.Enabled =
                        ctlCheckPowder1.Enabled = ctlTemprature1.Enabled =
                        ctlAdvancedManual1.Enabled = ctlSeviceStation1.Enabled = false;
                }
                else
                {
                    ctlAdvancedPritControl1.Enabled = ctlStandardManual1.Enabled = ctlFluidSuply1.Enabled =
                        ctlCheckPowder1.Enabled = ctlTemprature1.Enabled =
                        ctlAdvancedManual1.Enabled = ctlSeviceStation1.Enabled = true;
                }
            }
        }

        private void ctlMainManual_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}

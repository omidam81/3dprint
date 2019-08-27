using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer;
using UV_DLP_3D_Printer.GUI.CustomGUI;
using UV_DLP_3D_Printer.Device_Interface.AutoDetect;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlManualControl : ctlUserPanel
    {
        // component support holds a string with a letter for each supported axis by HW
        // X, Y, Z, T (tilt), E (Extruder), H (Head heater), B (Bed heater), G (gcode panel), P (projector control)
        string mComponentSupport;
        bool mComponentSupportChanged = true;
        public ctlManualControl()
        {
            InitializeComponent();
            //ApplyStyle(Style);
            mComponentSupport = "XYZPG";

            cMCTilt.ReturnValues = new float[] { 1, 10, 100 };
            UVDLPApp.Instance().AppEvent += new AppEventDelegate(AppEv);
            UVDLPApp.Instance().m_gui_config.AddControl("flowTop_manual_control", flowTop);
            SetTexts();
            //if (!(DesignMode))
            //{
            //    var com = SerialAutodetect.Instance().DeterminePort(UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_connection.speed);
            //    if (com.Equals(((DesignMode) ? "Invalid" : UVDLPApp.Instance().resman.GetString("Invalid", UVDLPApp.Instance().cul))))
            //    {
            //        ctlStandardManual1.Enabled =ctlFluidSuply1.Enabled=
            //            ctlCheckPowder1.Enabled = ctlTemprature1.Enabled =
            //            ctlAdvancedManual1.Enabled = ctlSeviceStation1.Enabled = false;
            //    }
            //    else
            //    {
            //        ctlStandardManual1.Enabled = ctlFluidSuply1.Enabled =
            //            ctlCheckPowder1.Enabled = ctlTemprature1.Enabled =
            //            ctlAdvancedManual1.Enabled = ctlSeviceStation1.Enabled = true;
            //    }
            //}
        }

        private void SetTexts()
        {
            this.cMCXY.Title = ((DesignMode) ? "XYAxis" : UVDLPApp.Instance().resman.GetString("XYAxis", UVDLPApp.Instance().cul));
            this.cMCXY.Unit = ((DesignMode) ? "Mm" : UVDLPApp.Instance().resman.GetString("Mm", UVDLPApp.Instance().cul));
            this.cMCZ.Title = ((DesignMode) ? "ZAxis" : UVDLPApp.Instance().resman.GetString("ZAxis", UVDLPApp.Instance().cul));
            this.cMCZ.Unit = ((DesignMode) ? "Mm" : UVDLPApp.Instance().resman.GetString("Mm", UVDLPApp.Instance().cul));
            this.cMCExtruder.Title = ((DesignMode) ? "Extrude" : UVDLPApp.Instance().resman.GetString("Extrude", UVDLPApp.Instance().cul));
            this.cMCExtruder.Unit = ((DesignMode) ? "Mm" : UVDLPApp.Instance().resman.GetString("Mm", UVDLPApp.Instance().cul));
            this.cMCTilt.Title = ((DesignMode) ? "Tilt" : UVDLPApp.Instance().resman.GetString("Tilt", UVDLPApp.Instance().cul));
            this.cMCTilt.Unit = ((DesignMode) ? "Mm" : UVDLPApp.Instance().resman.GetString("Mm", UVDLPApp.Instance().cul));
            this.cMCTempExtruder.Title = ((DesignMode) ? "Heater_" : UVDLPApp.Instance().resman.GetString("Heater_", UVDLPApp.Instance().cul));
            this.cMCTempPlatform.Title = ((DesignMode) ? "Platform_" : UVDLPApp.Instance().resman.GetString("Platform_", UVDLPApp.Instance().cul));
            this.cMCTempPlatform.Title = ((DesignMode) ? "Platform_" : UVDLPApp.Instance().resman.GetString("Platform_", UVDLPApp.Instance().cul));
            this.cOnOffMotors.Title = ((DesignMode) ? "Motors" : UVDLPApp.Instance().resman.GetString("Motors", UVDLPApp.Instance().cul));
            this.cOnOffManGcode.Title = ((DesignMode) ? "ManualGcode" : UVDLPApp.Instance().resman.GetString("ManualGcode", UVDLPApp.Instance().cul));
            this.cOnOffHeater.Title = ((DesignMode) ? "Heater" : UVDLPApp.Instance().resman.GetString("Heater", UVDLPApp.Instance().cul));
            this.cOnOffPlatform.Title = ((DesignMode) ? "Platform" : UVDLPApp.Instance().resman.GetString("Platform", UVDLPApp.Instance().cul));
            this.cOnOffMonitorTemp.Title = ((DesignMode) ? "MonitorTemp" : UVDLPApp.Instance().resman.GetString("MonitorTemp", UVDLPApp.Instance().cul));
            this.cShutter.Title = ((DesignMode) ? "Shutter" : UVDLPApp.Instance().resman.GetString("Shutter", UVDLPApp.Instance().cul));


        }

        public override void ApplyStyle(GuiControlStyle ct)
        {
            base.ApplyStyle(ct);
            flowTop.BackColor = ct.BackColor;
            flowData1.BackColor = ct.BackColor;
        }

        CallbackHandler Callback
        {
            get { return UVDLPApp.Instance().m_callbackhandler; }
        }

        /// <summary>
        /// This changes the visibility of the components on the screen
        /// </summary>
        public string ComponentSupport 
        {
            get 
            {
                return mComponentSupport;
            }
            set 
            {
                if (mComponentSupport != value)
                {
                    mComponentSupport = value;
                    mComponentSupportChanged = true;
                    if (Visible)
                        UpdateComponentDisplay();
                }
            }
        }

        public void AppEv(eAppEvent ev, string s)
        {
            switch (ev)
            {
                case eAppEvent.eMachineConfigChanged:
                    ComponentSupport = UVDLPApp.Instance().m_printerinfo.MachineControls;
                    break;
            }
        }

        void UpdateComponentDisplay()
        {
            cMCExtruder.Visible = false;
            cMCTempExtruder.Visible = false;
            cMCTempPlatform.Visible = false;
            cMCTilt.Visible = false;
            cMCXY.Visible = false;
            cMCZ.Visible = false;

            cOnOffMonitorTemp.Visible = false;
            cOnOffHeater.Visible = false;
            cOnOffPlatform.Visible = false;
            cOnOffMotors.Visible = false; // turn off for now... - smh 08/19/2014
            cOnOffManGcode.Visible = false;
            cShutter.Visible = false;

            ctlParamXYrate.Visible = false;
            ctlParamZrate.Visible = false;
            ctlParamExtrudeRate.Visible = false;

            cGCodeManual.Visible = false;
            cProjectorControl.Visible = false;

            flowBot.Visible = true;
            flowData1.Visible = true;
            flowData2.Visible = true;
            flowLeft.Visible = true;
            flowMain.Visible = true;
            flowRight.Visible = true;
            flowTop.Visible = true;

            foreach (char ch in mComponentSupport)
            {
                switch (ch)
                {
                    case 'X':
                    case 'Y':
                        cMCXY.Visible = false;
                        // cOnOffMotors.Visible = true;// turn off the motor on/off switch - smh 08/19/2014
                        ctlParamXYrate.Visible = false;
                        break;
                    case 'Z':
                        cMCZ.Visible = false;
                        ctlParamZrate.Visible = false;
                        break;
                    case 'T':
                        cMCTilt.Visible = false;
                        //cOnOffMotors.Visible = true; // turn off the motor on/off switch - smh 08/19/2014
                        ctlParamXYrate.Visible = false; // turn on the rate for the x/tilt axis
                        break;
                    case 'E':
                        cMCExtruder.Visible = false;
                        // cOnOffMotors.Visible = true;// turn off the motor on/off switch - smh 08/19/2014
                        ctlParamExtrudeRate.Visible = false;
                        break;
                    case 'H':
                        cMCTempExtruder.Visible = false;
                         cOnOffHeater.Visible = false;
                        cOnOffMonitorTemp.Visible = false;
                        break;
                    case 'B':
                        cMCTempPlatform.Visible = false;
                        cOnOffPlatform.Visible = false;
                        cOnOffMonitorTemp.Visible = false;
                        break;
                    case 'P':
                        cProjectorControl.Visible = false;
                        break;
                    case 'G':
                        cOnOffManGcode.Visible = false;
                        cGCodeManual.Visible = cOnOffManGcode.IsOn;
                        break;
                    case 'D':
                        cOnOffMotors.Visible = false;// turn on the motor on/off switch
                        break;
                    case 'S':
                        cShutter.Visible = false;
                        break;
                }
            }

            FitSize();
        }

        void FitSize()
        {
            PackFlowPanelRecurse(flowMain);

            Size = new Size(flowMain.Width+flowMain.Margin.Left + flowMain.Margin.Right, 
                flowMain.Height + flowMain.Margin.Top + flowMain.Margin.Bottom);
        }

        void PackFlowPanelRecurse(FlowLayoutPanel flp)
        {
            foreach (Control ctl in flp.Controls)
            {
                if (ctl is FlowLayoutPanel)
                    PackFlowPanelRecurse((FlowLayoutPanel)ctl);
            }
            PackFlowPanel(flp);
        }

        void PackFlowPanel(FlowLayoutPanel flp)
        {
            //int w = 0;
            //int h = 0;
            //foreach (Control ctl in flp.Controls)
            //{
            //    int cw = ctl.Width + ctl.Margin.Left + ctl.Margin.Right;
            //    int ch = ctl.Height + ctl.Margin.Top + ctl.Margin.Bottom;
            //    if (ctl.Visible)
            //    {
            //        if ((flp.FlowDirection == FlowDirection.LeftToRight) || (flp.FlowDirection == FlowDirection.RightToLeft))
            //        {
            //            w += cw;
            //            if (h < ch) h = ch;
            //        }
            //        else
            //        {
            //            if (w < cw) w = cw;
            //            h += ch;
            //        }
            //    }
            //}
            //if ((w == 0) || (h == 0))
            //{
            //    flp.Visible = false;
            //}
            //else
            //{
            //    flp.Visible = true;
            //    flp.Width = w + flp.Padding.Left + flp.Padding.Right;
            //    flp.Height = h + flp.Padding.Top + flp.Padding.Bottom;
            //}
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if ((Parent != null) && (Parent.BackColor != null))
            {
                foreach (Control ctl in flowLeft.Controls)
                    ctl.BackColor = Parent.BackColor;
                foreach (Control ctl in flowBot.Controls)
                    ctl.BackColor = Parent.BackColor;
                foreach (Control ctl in flowTop.Controls)
                    ctl.BackColor = Parent.BackColor;
            }
            if (UVDLPApp.Instance().m_printerinfo.MachineControls != null)
                ComponentSupport = UVDLPApp.Instance().m_printerinfo.MachineControls;
            UpdateComponentDisplay();
            try
            {
                double res = (double)Callback.Activate("MCCmdGetZRate");
                ctlParamZrate.Value = (decimal)res;
                res = (double)Callback.Activate("MCCmdGetXYRate");
                ctlParamXYrate.Value = (decimal)res;
            }
            catch {}
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (mComponentSupportChanged)
            {
                UpdateComponentDisplay();
                mComponentSupportChanged = false;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if ((Parent == null) || (Parent.BackColor == null))
            {
                base.OnPaintBackground(e);
                return;
            }
            Brush br = new SolidBrush(Parent.BackColor);
            e.Graphics.FillRectangle(br, 0, 0, Width, Height);
        }

        private void ctlOnOffMotors_StateChange(object obj, bool state)
        {
            string cmd = state ? "MCCmdMotorOn" : "MCCmdMotorOff";
            Callback.Activate(cmd, this);
        }

        private void cShutter_StateChange(object obj, bool state)
        {
            string cmd = state ? "MCCmdShutterOpen" : "MCCmdShutterClose";
            Callback.Activate(cmd, this);
        }
        
        private void ctlOnOffHeater_StateChange(object obj, bool state)
        {
        }

        private void ctlOnOffPlatform_StateChange(object obj, bool state)
        {
        }

        private void ctlParamZrate_ValueChanged(object sender, decimal newval)
        {
            Callback.Activate("MCCmdSetZRate", this, (double)newval);
        }                      

        private void ctlParamXYrate_ValueChanged(object sender, decimal newval)
        {
            Callback.Activate("MCCmdSetXYRate", this, (double)newval);
        }

        private void ctlManGcode_StateChange(object obj, bool state)
        {
            cGCodeManual.Visible = state;
            FitSize();
        }

        private void cMCXY_MotorMove(object sender, MachineControlAxis axis, float val)
        {
            switch (axis)
            {
                case MachineControlAxis.X:
                case MachineControlAxis.Tilt:
                    Callback.Activate("MCCmdMoveX", this, (double)val);
                    break;
                case MachineControlAxis.Y:
                    Callback.Activate("MCCmdMoveY", this, (double)val);
                    break;
                case MachineControlAxis.Z:
                    Callback.Activate("MCCmdMoveZ", this, (double)val);
                    break;
                case MachineControlAxis.Extruder:
                    Callback.Activate("MCCmdExtrude", this, (double)val);
                    break;
            }
        }

        private void cMCXY_MotorHome(object sender, MachineControlAxis axis)
        {
            switch (axis)
            {
                case MachineControlAxis.X:
                case MachineControlAxis.Tilt:
                    Callback.Activate("MCCmdXHome", this, null);
                    break;
                case MachineControlAxis.Y:
                    Callback.Activate("MCCmdYHome", this, null);
                    break;
                case MachineControlAxis.Z:
                    Callback.Activate("MCCmdZHome", this, null);
                    break;
                case MachineControlAxis.All:
                    Callback.Activate("MCCmdAllHome", this, null);
                    break;
            }
        }

        private void cGCodeManual_Load(object sender, EventArgs e)
        {

        }

        private void ctlManualControl_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.tabControl1.Dock = DockStyle.Fill;
        }

        private void ctlStandardManual1_Load(object sender, EventArgs e)
        {

        }
    }
}

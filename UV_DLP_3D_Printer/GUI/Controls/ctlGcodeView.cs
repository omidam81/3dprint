using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.Slicing;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlGcodeView : UserControl
    {
        public ctlGcodeView()
        {
            InitializeComponent();
            UVDLPApp.Instance().AppEvent += new AppEventDelegate(AppEventDel);
            UVDLPApp.Instance().m_slicer.Slice_Event += new Slicer.SliceEvent(SliceEv);
            SetTexts();
        }

        private void SetTexts()
        {
            this.ctlToolTip1.SetToolTip(this.ctlImageButton1, ((DesignMode) ? "SaveGCodeFile" : UVDLPApp.Instance().resman.GetString("SaveGCodeFile", UVDLPApp.Instance().cul)));
            this.ctlToolTip1.SetToolTip(this.buttConfig, ((DesignMode) ? "LoadGCodeFile" : UVDLPApp.Instance().resman.GetString("LoadGCodeFile", UVDLPApp.Instance().cul)));
            this.txtGCode.Font = new System.Drawing.Font(((DesignMode) ? "CourierNew" : UVDLPApp.Instance().resman.GetString("CourierNew", UVDLPApp.Instance().cul)), 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        public override string Text
        {
            get
            {
                return txtGCode.Text;
            }
            set
            {
                txtGCode.Text = value;
            }
        }

        private void buttConfig_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = ((DesignMode) ? "GCodeFilesGcodeGcodeAllFiles" :UVDLPApp.Instance().resman.GetString("GCodeFilesGcodeGcodeAllFiles", UVDLPApp.Instance().cul));
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    UVDLPApp.Instance().LoadGCode(openFileDialog1.FileName);
                    // txtGCode.Text = UVDLPApp.Instance().m_gcode.RawGCode;
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        private void ctlImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // get the gcode from the textbox, save it...
                    UVDLPApp.Instance().m_gcode.RawGCode = txtGCode.Text;
                    UVDLPApp.Instance().SaveGCode(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }
        private void SliceEv(Slicer.eSliceEvent ev, int layer, int totallayers, SliceFile sf)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(delegate() { SliceEv(ev, layer, totallayers, sf); }));
                }
                else
                {
                    switch (ev)
                    {
                        case Slicer.eSliceEvent.eSliceStarted:
                            Text = "";
                            break;
                        case Slicer.eSliceEvent.eSliceCompleted:
                            //show the gcode
                            Text = UVDLPApp.Instance().m_gcode.RawGCode;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        /*
          This handles specific events triggered by the app
          */
        private void AppEventDel(eAppEvent ev, String Message)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(delegate() { AppEventDel(ev, Message); }));
                }
                else
                {
                    switch (ev)
                    {

                      case eAppEvent.eGCodeLoaded:
                          DebugLogger.Instance().LogRecord(Message);
                          Text = UVDLPApp.Instance().m_gcode.RawGCode;
                          break;
                      case eAppEvent.eGCodeSaved:
                          DebugLogger.Instance().LogRecord(Message);
                          break;
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }

        }

    }
}

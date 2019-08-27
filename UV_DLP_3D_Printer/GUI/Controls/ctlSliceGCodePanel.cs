using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI.CustomGUI;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlSliceGCodePanel : ctlUserPanel
    {
        public ctlSliceGCodePanel()
        {
            InitializeComponent();
            RegisterCallbacks();
            ctlTitleViewSlice.Checked = true;
            ShowSliceView_Click(null,null);
            SetTexts();
        }

        private void SetTexts()
        {
            this.ctlTitleViewSlice.Text = ((DesignMode) ? "SliceView" : UVDLPApp.Instance().resman.GetString("SliceView", UVDLPApp.Instance().cul));
            this.ctlTitleViewGCode.Text = ((DesignMode) ? "GCodeView" : UVDLPApp.Instance().resman.GetString("GCodeView", UVDLPApp.Instance().cul));
        }

        public ctlSliceView ctlSliceViewctl
        {
            get {return ctlSliceView1;}
        }

        public void AddControls()
        {
            UVDLPApp.Instance().m_gui_config.AddControl(ctlGcodeView1);
            UVDLPApp.Instance().m_gui_config.AddControl(ctlSliceView1);
        }

        private void RegisterCallbacks()
        {
            // the main tab buttons
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("ShowSliceView", ShowSliceView_Click, null, ((DesignMode) ? "ViewSliceDisplay" :UVDLPApp.Instance().resman.GetString("ViewSliceDisplay", UVDLPApp.Instance().cul)));
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("ShowGCodeView", ShowGCodeView_Click, null, ((DesignMode) ? "ViewGCodeDisplay" :UVDLPApp.Instance().resman.GetString("ViewGCodeDisplay", UVDLPApp.Instance().cul)));
        }
        private void ShowSliceView_Click(object sender, object vars) 
        {
            ctlSliceView1.BringToFront();
            ctlTitleViewGCode.Checked = false;
            ctlTitleViewSlice.Checked = true;
        }
        private void ShowGCodeView_Click(object sender, object vars)
        {
            ctlGcodeView1.BringToFront();
            ctlTitleViewSlice.Checked = false; // uncheck the other
            ctlTitleViewGCode.Checked = true;
        }
        public override void ApplyStyle(GuiControlStyle ct)
        {
            base.ApplyStyle(ct);
            if (ct.BackColor.IsValid())
                flowLayoutPanel2.BackColor = ct.BackColor;
            if (ct.ForeColor.IsValid())
                flowLayoutPanel2.ForeColor = ct.ForeColor;
        }
    }
}

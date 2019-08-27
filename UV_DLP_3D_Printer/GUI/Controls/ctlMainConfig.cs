using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI.CustomGUI;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlMainConfig : ctlUserPanel
    {
        private enum eConfView
        {
            eSlice,
            eMachine,
            eNone,
            eSoftwareConfig
        }
        private eConfView m_eView;

        public ctlMainConfig()
        {
            InitializeComponent();            
            RegisterCallbacks();
            HideControls();
            m_eView = eConfView.eNone;
            ClickViewConfMachine(null, null);
            //UVDLPApp.Instance().m_gui_config.AddControl(((DesignMode) ? "Guimachineconfig" :UVDLPApp.Instance().resman.GetString("Guimachineconfig", UVDLPApp.Instance().cul)), ctlMachineConfig1);
            //UVDLPApp.Instance().m_gui_config.AddControl(((DesignMode) ? "Guimachineconfigparent" :UVDLPApp.Instance().resman.GetString("Guimachineconfigparent", UVDLPApp.Instance().cul)), pnlMachineConfig);
            //UVDLPApp.Instance().m_gui_config.AddControl("ctlSliceProfileConfig", ctlSliceProfileConfig);
            //UVDLPApp.Instance().m_gui_config.AddControl("ctlToolpathGenConfig1", ctlToolpathGenConfig1); // the slice profile settings
            //UVDLPApp.Instance().m_gui_config.AddControl("pnlToolpathGenConfig", pnlToolpathGenConfig); // the slice profile settings parent
            //UVDLPApp.Instance().m_gui_config.AddControl("ctlTitleMachineConfig", ctlMachineConfigView);
            //UVDLPApp.Instance().m_gui_config.AddControl("ctlTitleSliceProfile", ctlSliceProfileConfig);
            //UVDLPApp.Instance().m_gui_config.AddControl("ctlTitleMachineConfig", ctlMachineConfigView1);
            //UVDLPApp.Instance().m_gui_config.AddControl("ctlTitleSliceProfile", ctlSliceProfileConfig1);

            //ctlToolpathGenConfig1.RegisterControls();
            //ctlMachineConfig1.RegisterControls();
            
            //
            
            SetTexts();
        }

        private void SetTexts()
        {
            //this.ctlMachineConfigView.Text = ((DesignMode) ? "ConfigureMachine" : UVDLPApp.Instance().resman.GetString("ConfigureMachine", UVDLPApp.Instance().cul));
            //this.ctlSliceProfileConfig.Text = ((DesignMode) ? "ConfigureSlicingProfile" : UVDLPApp.Instance().resman.GetString("ConfigureSlicingProfile", UVDLPApp.Instance().cul));
        }
        private void HideControls() 
        {
            /*
            ctlMachineConfig1.Dock = DockStyle.None;
            ctlMachineConfig1.Visible = false;

            ctlToolpathGenConfig1.Dock = DockStyle.None;
            ctlToolpathGenConfig1.Visible = false;
            */
           // pnlToolpathGenConfig.Dock = DockStyle.None;
            //pnlToolpathGenConfig.Visible = false;

            //pnlMachineConfig.Dock = DockStyle.None;
            //pnlMachineConfig.Visible = false;

        }
        private void SetupView(eConfView view) 
        {
            //if (m_eView == view) return;
            //HideControls();
            //m_eView = view;
            //switch (m_eView)
            //{
            //    case eConfView.eSlice:
            //        pnlToolpathGenConfig.Dock = DockStyle.Fill;
            //        pnlToolpathGenConfig.Visible = true;
            //        break;
            //    case eConfView.eMachine:
            //        pnlMachineConfig.Dock = DockStyle.Fill;
            //        pnlMachineConfig.Visible = true;
            //        break;
            //}
        }
        private void RegisterCallbacks() 
        {
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("ClickViewConfMachine", ClickViewConfMachine, null, ((DesignMode) ? "ConfigureMachine" :UVDLPApp.Instance().resman.GetString("ConfigureMachine", UVDLPApp.Instance().cul)));
            UVDLPApp.Instance().m_callbackhandler.RegisterCallback("ClickViewSliceConfig", ClickViewSliceConfig, null, ((DesignMode) ? "ConfigureSlicingProfile" :UVDLPApp.Instance().resman.GetString("ConfigureSlicingProfile", UVDLPApp.Instance().cul)));
        
        }

        public void ClickviewSofwareConfig(object sender, object vars)
        {
            SetupView(eConfView.eSoftwareConfig);
            //ctlMachineConfigView.Checked = false;
            //ctlSliceProfileConfig.Checked = false;
        }
        private void ClickViewConfMachine(object sender, object vars)
        {
            SetupView(eConfView.eMachine);
            //ctlMachineConfigView.Checked = true;
            //ctlSliceProfileConfig1.ChangeState(false);

        }
        private void ClickViewSliceConfig(object sender, object vars)
        {
            SetupView(eConfView.eSlice);
            //ctlMachineConfigView1.ChangeState(false);
            //ctlSliceProfileConfig.Checked = true;
        }

        public override void ApplyStyle(GuiControlStyle ct)
        {
            base.ApplyStyle(ct);
            //if (ct.BackColor.IsValid())
            //    flowLayoutPanel1.BackColor = Wcolor.BackColor;
            //if (ct.ForeColor.IsValid())
            //    flowLayoutPanel1.ForeColor = Wcolor.ForeColor;
            //this.BackColor = Control.DefaultBackColor;
            //this.ForeColor = Control.DefaultForeColor;
            //ctlMachineConfigView.ApplyStyle(ct);
            //ctlSliceProfileConfig.ApplyStyle(ct);

            //pnlMachineConfig.BackColor = Wcolor.BackColor;// Control.DefaultBackColor;
            //pnlMachineConfig.ForeColor = Wcolor.ForeColor;// Control.DefaultForeColor;
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

        private void ctlMachineConfig1_Load(object sender, EventArgs e)
        {

        }
    }
}
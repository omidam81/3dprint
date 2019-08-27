using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.GUI.CustomGUI;
using UV_DLP_3D_Printer.Configs;
using UV_DLP_3D_Printer.Drivers;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlProjectorControl : ctlRFrame //ctlAnchorable
    {
        public ctlProjectorControl()
        {
            InitializeComponent();
            UVDLPApp.Instance().AppEvent += new AppEventDelegate(AppEventDel);
            UpdateProjectorCommands();
            //UpdateProjConnected();
            PopulateDisplays();
            SetTexts();
        }

        private void SetTexts()
        {
            this.cmdSendProj.Text = ((DesignMode) ? "Send" : UVDLPApp.Instance().resman.GetString("Send", UVDLPApp.Instance().cul));
            this.cmdEditPC.Text = ((DesignMode) ? "EditCommands" : UVDLPApp.Instance().resman.GetString("EditCommands", UVDLPApp.Instance().cul));
            this.cmdHide.Text = ((DesignMode) ? "Hide" : UVDLPApp.Instance().resman.GetString("Hide", UVDLPApp.Instance().cul));
            this.cmdShowBlank.Text = ((DesignMode) ? "ShowBlank" : UVDLPApp.Instance().resman.GetString("ShowBlank", UVDLPApp.Instance().cul));
            this.cmdShowBlank.Text = ((DesignMode) ? "ShowBlank" : UVDLPApp.Instance().resman.GetString("ShowBlank", UVDLPApp.Instance().cul));
            this.cmdShowCalib.Text = ((DesignMode) ? "ShowCalibration" : UVDLPApp.Instance().resman.GetString("ShowCalibration", UVDLPApp.Instance().cul));
            this.labelManipType.Text = ((DesignMode) ? "ProjectorControl" : UVDLPApp.Instance().resman.GetString("ProjectorControl", UVDLPApp.Instance().cul));

        }

        private void PopulateDisplays() 
        {
            cmbDisplays.Items.Clear();
            foreach(MonitorConfig mc in UVDLPApp.Instance().m_printerinfo.m_lstMonitorconfigs)
            {
                cmbDisplays.Items.Add(mc.Monitorid);
            }
        }
        /*
        public override void ApplyStyle(ControlStyle ct)
        {
            //base.ApplyStyle(ct);
            if (ct.ForeColor != ControlStyle.NullColor)
            {
            }
            if (ct.BackColor != ControlStyle.NullColor)
            {
               // BackColor = ct.BackColor;
            }
            if (ct.FrameColor != ControlStyle.NullColor)
            {
            }
        }
         */
        /// <summary>
        /// Disables/enables items based on up to date configuration) -SHS
        /// </summary>
        public void UpdateControl()
        {
            /*
            if (UVDLPApp.Instance().m_printerinfo.m_monitorconfig.m_displayconnectionenabled == false)
            {
                cmdConnect.Enabled = false;
                cmdSendProj.Enabled = false;
            }
            else
            {
                cmdConnect.Enabled = true;
                cmdSendProj.Enabled = true;
            }
            */
        }
        private void AppEventDel(eAppEvent ev, String Message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { AppEventDel(ev, Message); }));
            }
            else
            {
                switch (ev)
                {
                    case eAppEvent.eDisplayConnected:
                    case eAppEvent.eDisplayDisconnected:
                        UpdateProjConnected();
                        break;
                }
            }
        }
        private void cmdEditPC_Click(object sender, EventArgs e)
        {
            frmProjCommand frm = new frmProjCommand();
            frm.ShowDialog();
            frm.Dispose();
            // now update list of commands
            UpdateProjectorCommands();
        }
        private void UpdateProjectorCommands()
        {
            try
            {
                cmbCommands.Items.Clear();
                foreach (ProjectorCommand cmd in UVDLPApp.Instance().m_proj_cmd_lst.m_commands)
                {
                    cmbCommands.Items.Add(cmd.name);
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        private void UpdateProjConnected()
        {
            try
            {
                int idx = cmbDisplays.SelectedIndex;
                if(idx == -1)return;
                MonitorConfig mc = UVDLPApp.Instance().m_printerinfo.m_lstMonitorconfigs[idx];
                //magic needs to happen here with the serial connection to the monitor
                /*
                if (UVDLPApp.Instance().m_deviceinterface.ConnectedProjector)
                {
                    cmdConnect.Text = "Disconnect Monitor";
                }
                else
                {
                    cmdConnect.Text = "Connect Monitor";
                }
                 */ 
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        private void cmdConnect_Click(object sender, EventArgs e)
        {
            /*
            if (UVDLPApp.Instance().m_deviceinterface.ConnectedProjector == false)
            {
                UVDLPApp.Instance().m_deviceinterface.ConfigureProjector(UVDLPApp.Instance().m_printerinfo.m_monitorconfig.m_displayconnection);
                if (UVDLPApp.Instance().m_deviceinterface.ConnectProjector())
                {
                    UpdateProjConnected();
                }
            }
            else
            {
                UVDLPApp.Instance().m_deviceinterface.DisconnectProjector();
                UpdateProjConnected();
            }
             * */
        }

        private void cmdHide_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eHideDLP, ((DesignMode) ? "HideDLP" :UVDLPApp.Instance().resman.GetString("HideDLP", UVDLPApp.Instance().cul)));
        }

        private void cmdShowCalib_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eShowCalib, ((DesignMode) ? "ShowCalibration" :UVDLPApp.Instance().resman.GetString("ShowCalibration", UVDLPApp.Instance().cul)));
        }

        private void cmdShowBlank_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eShowBlank, ((DesignMode) ? "ShowBlank" :UVDLPApp.Instance().resman.GetString("ShowBlank", UVDLPApp.Instance().cul)));
        }

        private void cmdSendProj_Click(object sender, EventArgs e)
        {
            try
            {
                
                // get the index from the combo box
                int idx = cmbCommands.SelectedIndex;
                if (idx == -1) return;
                ProjectorCommand cmd = UVDLPApp.Instance().m_proj_cmd_lst.m_commands[idx];
                byte[] dat = cmd.GetBytes();
                if (dat != null)
                {
                    int idx2 = cmbDisplays.SelectedIndex;
                    if (idx2 == -1) return;
                    MonitorConfig mc = UVDLPApp.Instance().m_printerinfo.m_lstMonitorconfigs[idx2];
                    //mc.m_displayconnection.
                    //get the correct projector driver
                    DeviceDriver prjdrv = UVDLPApp.Instance().m_deviceinterface.GetDriver(idx2);
                    if (prjdrv.Connected)
                    {
                        prjdrv.Write(dat, dat.Length); // write it                       
                    }
                    else 
                    {
                        MessageBox.Show(((DesignMode) ? "ProjectorDriverNotConnected" :UVDLPApp.Instance().resman.GetString("ProjectorDriverNotConnected", UVDLPApp.Instance().cul)));
                    }
                }                
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmbDisplays_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProjConnected();
        }
    }
}

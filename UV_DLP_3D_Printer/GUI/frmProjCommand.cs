using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmProjCommand : Form
    {
        private ProjectorCommand m_pc;
        public frmProjCommand()
        {
            InitializeComponent();
            m_pc = null;
            SetData();
            DisplayCommandList();
            SetTexts();
        }

        private void SetTexts()
        {
            this.label1.Text = ((DesignMode) ? "Name" : UVDLPApp.Instance().resman.GetString("Name", UVDLPApp.Instance().cul));
            this.cmdDone.Text = ((DesignMode) ? "Done" : UVDLPApp.Instance().resman.GetString("Done", UVDLPApp.Instance().cul));
            this.cmdApply.Text = ((DesignMode) ? "Apply" : UVDLPApp.Instance().resman.GetString("Apply", UVDLPApp.Instance().cul));
            this.label2.Text = ((DesignMode) ? "HexCommand" : UVDLPApp.Instance().resman.GetString("HexCommand", UVDLPApp.Instance().cul));
            this.chkHex.Text = ((DesignMode) ? "Hex" : UVDLPApp.Instance().resman.GetString("Hex", UVDLPApp.Instance().cul));
            this.label3.Text = ((DesignMode) ? "Commands" : UVDLPApp.Instance().resman.GetString("Commands", UVDLPApp.Instance().cul));
            this.cmdAdd.Text = ((DesignMode) ? "Add" : UVDLPApp.Instance().resman.GetString("Add", UVDLPApp.Instance().cul));
            this.cmdDelete.Text = ((DesignMode) ? "Delete" : UVDLPApp.Instance().resman.GetString("Delete", UVDLPApp.Instance().cul));
            this.Command.Name = ((DesignMode) ? "Command" : UVDLPApp.Instance().resman.GetString("Command", UVDLPApp.Instance().cul));
            this.Command.Text = ((DesignMode) ? "Command" : UVDLPApp.Instance().resman.GetString("Command", UVDLPApp.Instance().cul));
            this.Text = ((DesignMode) ? "ProjectorCommands" : UVDLPApp.Instance().resman.GetString("ProjectorCommands", UVDLPApp.Instance().cul));
        }

        private void SetData() 
        {
            if (m_pc == null) return;
            chkHex.Checked = m_pc.hex;
            txtCommand.Text = m_pc.command;
            txtName.Text = m_pc.name;
        }
        private bool GetData() 
        {
            if (m_pc == null) return false;
            try
            {
                string ts = txtCommand.Text;
                ts = ts.Replace(" ", string.Empty);
                byte[] tmp = Utility.HexStringToByteArray(ts);
                if (tmp == null) return false;
                m_pc.hex = chkHex.Checked;                
                m_pc.command = txtCommand.Text;
                m_pc.name = txtName.Text; 
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
                return false;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (GetData()) 
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void lbCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the name of the 
            if (lbCommands.SelectedIndex == -1)
            {
                cmdDelete.Enabled = false;
                return;
            }
            else 
            {
                cmdDelete.Enabled = true;
            }
            string name = lbCommands.SelectedItem.ToString();
            foreach (ProjectorCommand cmd in UVDLPApp.Instance().m_proj_cmd_lst.m_commands) 
            {
                if (cmd.name.Equals(name)) 
                {
                    m_pc = cmd;
                    SetData();
                }
            }
        }
        private void DisplayCommandList() 
        {
            lbCommands.Items.Clear();
            foreach (ProjectorCommand cmd in UVDLPApp.Instance().m_proj_cmd_lst.m_commands) 
            {
                lbCommands.Items.Add(cmd.name);
            }
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //prjcmdlst 
            ProjectorCommand cmd = new ProjectorCommand();
            UVDLPApp.Instance().m_proj_cmd_lst.m_commands.Add(cmd);
            DisplayCommandList();
            UVDLPApp.Instance().SaveProjectorCommands(UVDLPApp.Instance().m_appconfig.ProjectorCommandsFile);
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            if (!GetData())
            {
                MessageBox.Show(((DesignMode) ? "PleaseCheckInput" :UVDLPApp.Instance().resman.GetString("PleaseCheckInput", UVDLPApp.Instance().cul)));
            }
            else
            {
                DisplayCommandList();
                UVDLPApp.Instance().SaveProjectorCommands(UVDLPApp.Instance().m_appconfig.ProjectorCommandsFile);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (lbCommands.SelectedIndex == -1) return;
            ProjectorCommand cmd =  UVDLPApp.Instance().m_proj_cmd_lst.m_commands[lbCommands.SelectedIndex];
            UVDLPApp.Instance().m_proj_cmd_lst.m_commands.Remove(cmd);
            DisplayCommandList();
            UVDLPApp.Instance().SaveProjectorCommands(UVDLPApp.Instance().m_appconfig.ProjectorCommandsFile);
        }

    }
}

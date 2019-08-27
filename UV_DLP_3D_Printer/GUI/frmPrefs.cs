using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmPrefs : Form
    {
        public frmPrefs()
        {
            InitializeComponent();
            SetData();
            SetTexts();
        }

        private void SetTexts()
        {
            this.cmdOK.Text = (DesignMode)
                ? "OK"
                : ((DesignMode) ? "OK" : UVDLPApp.Instance().resman.GetString("OK", UVDLPApp.Instance().cul));
            this.cmdCancel.Text = (DesignMode)
                ? "Cancel"
                : ((DesignMode) ? "Cancel" : UVDLPApp.Instance().resman.GetString("Cancel", UVDLPApp.Instance().cul));
            this.cmdselectfore.Text = (DesignMode)
                ? "Select"
                : ((DesignMode) ? "Select" : UVDLPApp.Instance().resman.GetString("Select", UVDLPApp.Instance().cul));
            this.label1.Text = (DesignMode)
                ? "ForegroundColor"
                : ((DesignMode)
                    ? "ForegroundColor"
                    : UVDLPApp.Instance().resman.GetString("ForegroundColor", UVDLPApp.Instance().cul));
            this.label1.Text = (DesignMode)
                ? "ForegroundColor"
                : ((DesignMode)
                    ? "ForegroundColor"
                    : UVDLPApp.Instance().resman.GetString("ForegroundColor", UVDLPApp.Instance().cul));
            this.label2.Text = ((DesignMode)
                ? "BackgroundColor"
                : UVDLPApp.Instance().resman.GetString("BackgroundColor", UVDLPApp.Instance().cul));
            this.cmdselectback.Text = ((DesignMode)
                ? "Select"
                : UVDLPApp.Instance().resman.GetString("Select", UVDLPApp.Instance().cul));
            this.grpDebug.Text = ((DesignMode)
                ? "Debugging"
                : UVDLPApp.Instance().resman.GetString("Debugging", UVDLPApp.Instance().cul));
            this.chkIgnoreGCRsp.Text = ((DesignMode)
                ? "IgnoreGCodeResponses"
                : UVDLPApp.Instance().resman.GetString("IgnoreGCodeResponses", UVDLPApp.Instance().cul));
            this.chkDriverLog.Text = ((DesignMode)
                ? "LogDriverDebuggingToCommLog"
                : UVDLPApp.Instance().resman.GetString("LogDriverDebuggingToCommLog", UVDLPApp.Instance().cul));
            this.Text = ((DesignMode)
                ? "ProgramPreferences"
                : UVDLPApp.Instance().resman.GetString("ProgramPreferences", UVDLPApp.Instance().cul));
        }
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                lblSlic3rlocation.Text = openFileDialog1.FileName;
            }
        }
         * */
        private void SetData() 
        {
            //lblSlic3rlocation.Text = UVDLPApp.Instance().m_appconfig.m_slic3rloc;
            panelback.BackColor = UVDLPApp.Instance().m_appconfig.m_backgroundcolor;
            panelfore.BackColor = UVDLPApp.Instance().m_appconfig.m_foregroundcolor;
            chkDriverLog.Checked = UVDLPApp.Instance().m_appconfig.m_driverdebuglog;
            chkIgnoreGCRsp.Checked = UVDLPApp.Instance().m_appconfig.m_ignore_response;
           // txtSlic3rParams.Text = UVDLPApp.Instance().m_appconfig.m_slic3rparameters;
        }
        private void GetData() 
        {
            //UVDLPApp.Instance().m_appconfig.m_slic3rloc = lblSlic3rlocation.Text;
            UVDLPApp.Instance().m_appconfig.m_backgroundcolor = panelback.BackColor;
            UVDLPApp.Instance().m_appconfig.m_foregroundcolor = panelfore.BackColor;
            UVDLPApp.Instance().m_appconfig.m_driverdebuglog = chkDriverLog.Checked;
            UVDLPApp.Instance().m_appconfig.m_ignore_response = chkIgnoreGCRsp.Checked;
            //UVDLPApp.Instance().m_appconfig.m_slic3rparameters = txtSlic3rParams.Text;
            UVDLPApp.Instance().SaveAppConfig();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            GetData();

            UVDLPApp.Instance().m_appconfig.m_Selected_Language = cmbCulters.SelectedItem.ToString();
            UVDLPApp.Instance().m_appconfig.Save(UVDLPApp.Instance().m_apppath + UVDLPApp.m_pathsep + UVDLPApp.m_appconfigname);
            MessageBox.Show(UVDLPApp.Instance().resman.GetString("RestratMessageBox", CultureInfo.CreateSpecificCulture(UVDLPApp.Instance().m_appconfig.m_Selected_Language)));

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdselectfore_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = panelfore.BackColor;
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                panelfore.BackColor = colorDialog1.Color;
            }
        }

        private void cmdselectback_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = panelback.BackColor;
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                panelback.BackColor = colorDialog1.Color;
            }
        }

        private void frmPrefs_Load(object sender, EventArgs e)
        {
            var m_Selected_Language = UVDLPApp.Instance().m_appconfig.m_Selected_Language;
            var m_Languages = UVDLPApp.Instance().m_appconfig.m_Languages;
            var i = 0;
            foreach (string language in m_Languages.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                cmbCulters.Items.Add(language.Trim());
                i++;
            }
            cmbCulters.SelectedText = m_Selected_Language;
            cmbCulters.SelectedItem = m_Selected_Language;
        }
    }
}

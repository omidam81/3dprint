using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.Plugin;
using CreationWorkshop.Licensing;
using UV_DLP_3D_Printer.Licensing;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmPluginManager : Form
    {
        PluginEntry ipsel;
        public frmPluginManager()
        {
            InitializeComponent();
            SetupPlugins();
            ipsel = null;
            UpdateButtons();

            SetTexts();
        }

        private void SetTexts()
        {
            this.label1.Text = ((DesignMode) ? "InstalledPlugIns" : UVDLPApp.Instance().resman.GetString("InstalledPlugIns", UVDLPApp.Instance().cul));
            this.clmName.Text = ((DesignMode) ? "Name" : UVDLPApp.Instance().resman.GetString("Name", UVDLPApp.Instance().cul));
            this.clmLicensed.Text = ((DesignMode) ? "Licensed" : UVDLPApp.Instance().resman.GetString("Licensed", UVDLPApp.Instance().cul));
            this.clmVersion.Text = ((DesignMode) ? "Version" : UVDLPApp.Instance().resman.GetString("Version", UVDLPApp.Instance().cul));
            this.clmDescription.Text = ((DesignMode) ? "Description" : UVDLPApp.Instance().resman.GetString("Description", UVDLPApp.Instance().cul));
            this.cmdEnable.Text = ((DesignMode) ? "Enable" : UVDLPApp.Instance().resman.GetString("Enable", UVDLPApp.Instance().cul));
            this.Text = ((DesignMode) ? "PluginAndLicensingManagement" : UVDLPApp.Instance().resman.GetString("PluginAndLicensingManagement", UVDLPApp.Instance().cul));
        }

        public void SetupPlugins()
        {
            lvplugins.Items.Clear();
            foreach (PluginEntry ip in UVDLPApp.Instance().m_plugins)
            {
                ListViewItem lvi = new ListViewItem(ip.m_plugin.Name);
                lvi.SubItems.Add(ip.m_licensed.ToString());
                lvi.SubItems.Add(ip.m_enabled.ToString());
                lvi.SubItems.Add(ip.m_plugin.GetString(((DesignMode) ? "Version" :UVDLPApp.Instance().resman.GetString("Version", UVDLPApp.Instance().cul))));
                lvi.SubItems.Add(ip.m_plugin.GetString(((DesignMode) ? "Description" :UVDLPApp.Instance().resman.GetString("Description", UVDLPApp.Instance().cul))));
                lvplugins.Items.Add(lvi);
            }
        }

        private void UpdateButtons() 
        {
            if (ipsel == null)
            {
                cmdEnable.Enabled = false;
                return;
            }
            else 
            {
                cmdEnable.Enabled = true;
            }
            if (ipsel.m_licensed)
            {
                cmdLicense.Enabled = false;
            }
            else 
            {
                cmdLicense.Enabled = true;
            }
            if (ipsel.m_enabled)
            {
                cmdEnable.Text = ((DesignMode) ? "Disable" :UVDLPApp.Instance().resman.GetString("Disable", UVDLPApp.Instance().cul));
            }
            else 
            {
                cmdEnable.Text = ((DesignMode) ? "Enable" :UVDLPApp.Instance().resman.GetString("Enable", UVDLPApp.Instance().cul));
            }
        }

        private void lvplugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvplugins.SelectedIndices.Count >0 )
            {
                int idx = lvplugins.SelectedIndices[0];
                ipsel = UVDLPApp.Instance().m_plugins[idx];
                UpdateButtons();
            }
        }


        private void cmdLicense_Click(object sender, EventArgs e)
        {
            // get the text string from 
            string license = txtLicense.Text;
            license = license.Trim();
            if (license.Length != 32) 
            {
                MessageBox.Show(((DesignMode) ? "InvalidLicensePleaseReCheck" :UVDLPApp.Instance().resman.GetString("InvalidLicensePleaseReCheck", UVDLPApp.Instance().cul)));
                return;
            }
            LicenseKey lk = new LicenseKey();
            try
            {
                lk.Init(license);
                if (lk.valid)
                {
                    txtLicense.Text = "";
                    //should really check, vendor id against plugin vendor id
                    KeyRing.Instance().m_keys.Add(lk);
                    string licensefile = UVDLPApp.Instance().m_apppath + UVDLPApp.m_pathsep + "licenses.key";
                    if (KeyRing.Instance().Save(licensefile))
                    {
                        MessageBox.Show(((DesignMode) ? "LicenseAddedToKeyringRestartToTakeEffect" :UVDLPApp.Instance().resman.GetString("LicenseAddedToKeyringRestartToTakeEffect", UVDLPApp.Instance().cul)));
                    }
                    else
                    {
                        MessageBox.Show(((DesignMode) ? "ErrorSavingKeyring" :UVDLPApp.Instance().resman.GetString("ErrorSavingKeyring", UVDLPApp.Instance().cul)));
                    }
                }
                else
                {
                    MessageBox.Show(((DesignMode) ? "InvalidLicensePleaseReCheck" :UVDLPApp.Instance().resman.GetString("InvalidLicensePleaseReCheck", UVDLPApp.Instance().cul)));
                }
            }
            catch (Exception) 
            {
                MessageBox.Show(((DesignMode) ? "ErrorValidatingLicensePleaseReCheck" :UVDLPApp.Instance().resman.GetString("ErrorValidatingLicensePleaseReCheck", UVDLPApp.Instance().cul)));
            }
        }

        private void cmdEnable_Click(object sender, EventArgs e)
        {
            if (ipsel == null)
            {
                return;
            }
            if (cmdEnable.Text.Contains(((DesignMode) ? "Disable" :UVDLPApp.Instance().resman.GetString("Disable", UVDLPApp.Instance().cul))))
            {
                //disable the current ipsel
                ipsel.m_enabled = false;
            }
            else 
            {
                ipsel.m_enabled = true;
            }
            // save the enabled status
            UVDLPApp.Instance().m_pluginstates.Save(); // save the state of the plugin enabled statuses
            //now refresh the buttons
            UpdateButtons();
            //refresh the plugin list as well
            SetupPlugins();
        }
    }
}

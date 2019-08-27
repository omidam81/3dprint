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
    public partial class frmProfileName : Form
    {

        public frmProfileName()
        {
            InitializeComponent();

            SetTexts();
        }

        private void SetTexts()
        {
            this.button1.Text = ((DesignMode) ? "OK" : UVDLPApp.Instance().resman.GetString("OK", UVDLPApp.Instance().cul));
            this.label1.Text = ((DesignMode) ? "PleaseEnterANameForYourNewProfile" : UVDLPApp.Instance().resman.GetString("PleaseEnterANameForYourNewProfile", UVDLPApp.Instance().cul));
            this.Text = ((DesignMode) ? "ProfileName" : UVDLPApp.Instance().resman.GetString("ProfileName", UVDLPApp.Instance().cul));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        public String ProfileName 
        {
            get
            {
                return txtProfilename.Text;
            }
        }
    }
}

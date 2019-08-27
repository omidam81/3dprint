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
    public partial class frmAmfSmoothing : Form
    {
        
        public frmAmfSmoothing()
        {
            InitializeComponent();
            comboSmooth.SelectedIndex = 2;
            setTexts();
        }

        private void setTexts()
        {
            this.label1.Text = ((DesignMode) ? "AMFSmoothingLevel" : UVDLPApp.Instance().resman.GetString("AMFSmoothingLevel", UVDLPApp.Instance().cul));
            this.comboSmooth.Font = new System.Drawing.Font(((DesignMode) ? "Arial" : UVDLPApp.Instance().resman.GetString("Arial", UVDLPApp.Instance().cul)), 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOK.Text = ((DesignMode) ? "OK" : UVDLPApp.Instance().resman.GetString("OK", UVDLPApp.Instance().cul));
        }

        public int SmoothLevel
        {
            get { return comboSmooth.SelectedIndex; }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}

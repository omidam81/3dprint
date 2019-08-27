using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public partial class ctlConfig : ctlUserPanel
    {
        public ctlConfig()
        {
            InitializeComponent();
            SetTexts();
        }

        private void SetTexts()
        {
            this.lblTitle.Text = ((DesignMode)
                ? "Configuration"
                : UVDLPApp.Instance().resman.GetString("Configuration", UVDLPApp.Instance().cul));
        }

        public override void ApplyStyle(GuiControlStyle ct)
        {
            base.ApplyStyle(ct);
            if (ct.ForeColor.IsValid())
            {
            }
            if (ct.BackColor.IsValid())
            {
                //BackColor = Wcolor.BackColor;
            }
            if (ct.FrameColor.IsValid())
            {
                //flowLayoutPanel5.BackColor = Wcolor.BackColor;
            }

        }

        private void ctlImageButton1_Load(object sender, EventArgs e)
        {

        }
    }
}

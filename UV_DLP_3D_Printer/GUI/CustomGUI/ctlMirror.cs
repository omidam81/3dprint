using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Engine3D;

namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    public partial class ctlMirror : ctlUserPanel //UserControl
    {
        public ctlMirror()
        {
            InitializeComponent();
            SetTexts();
        }

        private void SetTexts()
        {
            this.lblX.Font = new System.Drawing.Font(((DesignMode) ? "CourierNew" : UVDLPApp.Instance().resman.GetString("CourierNew", UVDLPApp.Instance().cul)), 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.Text = ((DesignMode) ? "_X___" : UVDLPApp.Instance().resman.GetString("_X___", UVDLPApp.Instance().cul));
            this.lblY.Text = ((DesignMode) ? "_Y___" : UVDLPApp.Instance().resman.GetString("_Y___", UVDLPApp.Instance().cul));
            this.lblZ.Font = new System.Drawing.Font(((DesignMode) ? "CourierNew" : UVDLPApp.Instance().resman.GetString("CourierNew", UVDLPApp.Instance().cul)), 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZ.Text = ((DesignMode) ? "Z" : UVDLPApp.Instance().resman.GetString("Z", UVDLPApp.Instance().cul));
            //treeScene.BackColor = Color.FromArgb(255, 238, 238, 238);
            //treeScene.ForeColor = ctlTitle1.ForeColor = Color.FromArgb(255, 58, 85, 85);// ct.ForeColor;

            //panel1.BackColor = Color.FromArgb(255, 224, 224, 224);
            //manipObject.BackColor = Color.FromArgb(255, 238, 238, 238);
            BackColor = lblX.BackColor = lblY.BackColor= lblZ.BackColor =
               flowLayoutPanel2.BackColor = Color.FromArgb(255, 238, 238, 238);
            flowLayoutPanel1.BackColor= Color.FromArgb(255, 224, 224, 224);
            //BackColor = ct.BackColor;
            //flowLayoutPanel2.BackColor = ct.BackColor;
            //lblX.BackColor = ct.BackColor;
            //lblY.BackColor = ct.BackColor;
            //lblZ.BackColor = ct.BackColor;
        }

        private void ctlTitle1_Click(object sender, EventArgs e)
        {
            if (ctlTitle1.Checked)
            {
                this.Height = ctlTitle1.Height + flowLayoutPanel1.Height + (3 * 5);
            }
            else
            {
                this.Height = ctlTitle1.Height + 5;
            }
        }

        private void lblX_Click(object sender, EventArgs e)
        {
            Object3d o = UVDLPApp.Instance().SelectedObject;
            if (o != null) 
            {
                o.Scale(-1.0f, 1.0f, 1.0f);
                o.FlipWinding(); 
                o.Update();
            }
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");
        }

        private void lblY_Click(object sender, EventArgs e)
        {
            Object3d o = UVDLPApp.Instance().SelectedObject;
            if (o != null)
            {
                o.Scale(1.0f, -1.0f, 1.0f);
                o.FlipWinding();
                o.Update();
            }
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");
        }

        private void lblZ_Click(object sender, EventArgs e)
        {
            Object3d o = UVDLPApp.Instance().SelectedObject;
            if (o != null)
            {
                o.Scale(1.0f, 1.0f, -1.0f);
                o.FlipWinding();
                o.Update();
            }
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eReDraw, "");
        }

        public override void ApplyStyle(GuiControlStyle ct)
        {
            base.ApplyStyle(ct);
            if (ct.ForeColor.IsValid())
            {
                lblX.ForeColor = ct.ForeColor;
                lblY.ForeColor = ct.ForeColor;
                lblZ.ForeColor = ct.ForeColor;
            }
            if (ct.BackColor.IsValid())
            {
                BackColor = ct.BackColor;
                flowLayoutPanel2.BackColor = ct.BackColor;
                lblX.BackColor = ct.BackColor;
                lblY.BackColor = ct.BackColor;
                lblZ.BackColor = ct.BackColor;
            }
            if (ct.FrameColor.IsValid())
            {
                flowLayoutPanel1.BackColor = ct.FrameColor;
            }

        }

        private void ctlMirror_Resize(object sender, EventArgs e)
        {
            ctlTitle1.Width = ctlTitle1.Parent.Width -6 ;
            flowLayoutPanel1.Width = flowLayoutPanel1.Parent.Width -6;
        }

        public override void RegisterSubControls(string parentName)
        {
            UVDLPApp.Instance().m_gui_config.AddButton(parentName + ((DesignMode) ? "_Title" :UVDLPApp.Instance().resman.GetString("_Title", UVDLPApp.Instance().cul)), ctlTitle1);
        }

    }
}

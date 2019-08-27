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
    public partial class ctlMove : ctlUserPanel
    {
        public ctlMove()
        {
            InitializeComponent();
            SetTexts();
        }

        private void SetTexts()
        {
            this.label8.Text = ((DesignMode) ? "Move_" : UVDLPApp.Instance().resman.GetString("Move_", UVDLPApp.Instance().cul));
            this.ctlToolTip1.SetToolTip(this.buttOnPlatform, ((DesignMode) ? "PutObjectOnPlatform" : UVDLPApp.Instance().resman.GetString("PutObjectOnPlatform", UVDLPApp.Instance().cul)));
            this.ctlToolTip1.SetToolTip(this.buttArrange, ((DesignMode) ? "ArrangeObjectsOnPlatform" : UVDLPApp.Instance().resman.GetString("ArrangeObjectsOnPlatform", UVDLPApp.Instance().cul)));
            this.label9.Font = new System.Drawing.Font(((DesignMode) ? "Arial" : UVDLPApp.Instance().resman.GetString("Arial", UVDLPApp.Instance().cul)), 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label9.Text = ((DesignMode) ? "X_______" : UVDLPApp.Instance().resman.GetString("X_______", UVDLPApp.Instance().cul));
            this.textMoveX.Font = new System.Drawing.Font(((DesignMode) ? "Arial" : UVDLPApp.Instance().resman.GetString("Arial", UVDLPApp.Instance().cul)), 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textMoveX.Text = ((DesignMode) ? "_100" : UVDLPApp.Instance().resman.GetString("_100", UVDLPApp.Instance().cul));
            this.label10.Font = new System.Drawing.Font(((DesignMode) ? "Arial" : UVDLPApp.Instance().resman.GetString("Arial", UVDLPApp.Instance().cul)), 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textMoveY.Font = new System.Drawing.Font(((DesignMode) ? "Arial" : UVDLPApp.Instance().resman.GetString("Arial", UVDLPApp.Instance().cul)), 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label11.Font = new System.Drawing.Font(((DesignMode) ? "Arial" : UVDLPApp.Instance().resman.GetString("Arial", UVDLPApp.Instance().cul)), 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textMoveZ.Font = new System.Drawing.Font(((DesignMode) ? "Arial" : UVDLPApp.Instance().resman.GetString("Arial", UVDLPApp.Instance().cul)), 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textMoveZ.Text = ((DesignMode) ? "_100" : UVDLPApp.Instance().resman.GetString("_100", UVDLPApp.Instance().cul));
            //label8.ForeColor = 
            //label9.ForeColor =
            //label10.ForeColor = 
            //label11.ForeColor = 
            //textMoveX.ValidColor = 
            //textMoveY.ValidColor = 
            //textMoveZ.ValidColor = Wcolor.ForeColor;
            //BackColor = 
            //flowLayoutPanel2.BackColor =
            //flowLayoutPanel7.BackColor = 
            //flowLayoutPanel8.BackColor = 
            //flowLayoutPanel10.BackColor = Wcolor.BackColor;
        }

        public void FixForeColor(Color clr)
        {
            label9.ForeColor = clr;
            label10.ForeColor = clr;
            label11.ForeColor = clr;
        }

        protected void MoveObject(ctlTextBox var, float x, float y, float z)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float val = var.FloatVal;
                x *= val;
                y *= val;
                z *= val;
                UVDLPApp.Instance().SelectedObject.Translate(x, y, z, true);
                //UVDLPApp.Instance().m_undoer.SaveTranslation(UVDLPApp.Instance().SelectedObject, x, y, z); // moved to translate function
                //UVDLPApp.Instance().SelectedObject.Update(); // make sure we update                        // moved to translate function
                //ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eUpdateSelectedObject, ((DesignMode) ? "Updateobject" :UVDLPApp.Instance().resman.GetString("Updateobject", UVDLPApp.Instance().cul)));
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void buttXMinus_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveX, -1, 0, 0);
        }

        private void buttYMinus_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveY, 0, -1, 0);
        }

        private void buttZMinus_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveZ, 0, 0, -1);
        }

        private void buttXPlus_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveX, 1, 0, 0);
        }

        private void buttYPlus_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveY, 0, 1, 0);
        }

        private void buttZPlus_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveZ, 0, 0, 1);
        }

        private void buttCenter_Click(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().SelectedObject == null) return;
            Point3d center = UVDLPApp.Instance().SelectedObject.CalcCenter();
            UVDLPApp.Instance().SelectedObject.Translate((float)-center.x, (float)-center.y, (float)-center.z, true);
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eUpdateSelectedObject, ((DesignMode) ? "Updateobject" :UVDLPApp.Instance().resman.GetString("Updateobject", UVDLPApp.Instance().cul)));
        }

        private void buttOnPlatform_Click(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().SelectedObject == null)
                return;
            Point3d center = UVDLPApp.Instance().SelectedObject.CalcCenter();
            UVDLPApp.Instance().SelectedObject.FindMinMax();
            float zlev = (float)UVDLPApp.Instance().SelectedObject.m_min.z;
            float zmove = -zlev; 
            UVDLPApp.Instance().SelectedObject.Translate(0, 0, zmove, true);
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eUpdateSelectedObject, ((DesignMode) ? "Updateobject" :UVDLPApp.Instance().resman.GetString("Updateobject", UVDLPApp.Instance().cul)));
        }


        public override void ApplyStyle(GuiControlStyle ct)
        {
            base.ApplyStyle(ct);
            if (ct.ForeColor.IsValid())
            {
                label8.ForeColor = ct.ForeColor;
                label9.ForeColor = ct.ForeColor;
                label10.ForeColor = ct.ForeColor;
                label11.ForeColor = ct.ForeColor;
                textMoveX.ValidColor = ct.ForeColor;
                textMoveY.ValidColor = ct.ForeColor;
                textMoveZ.ValidColor = ct.ForeColor;
            }
            if (ct.BackColor.IsValid())
            {
                BackColor = ct.BackColor;
                flowLayoutPanel2.BackColor = ct.BackColor;
                textMoveX.BackColor = ct.BackColor;
                textMoveY.BackColor = ct.BackColor;
                textMoveZ.BackColor = ct.BackColor;
            }
            if (ct.FrameColor.IsValid())
            {
                flowLayoutPanel1.BackColor = ct.FrameColor;
                flowLayoutPanel7.BackColor = ct.FrameColor;
                flowLayoutPanel8.BackColor = ct.FrameColor;
                flowLayoutPanel10.BackColor = ct.FrameColor;
            }
        }

        private void buttArrange_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().Engine3D.RearrangeObjects();
        }

    }
}

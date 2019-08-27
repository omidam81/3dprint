using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Engine3D;

namespace UV_DLP_3D_Printer.GUI.CustomGUI.Expanding
{
    public partial class ctlMoveExpand : ctlUserPanel
    {
        private Timer XPlusTimer;
        private Timer XMinusTimer;
        private Timer YPlusTimer;
        private Timer YMinusTimer;
        private Timer ZPlusTimer;
        private Timer ZMinusTimer;

        /// <summary>
        /// The delay in milliseconds regular interval
        /// </summary>
        public int LoSpeedWait = 290;

        /// <summary>
        /// The delay in milliseconds simulate mouse clicks
        /// </summary>
        public int HiSpeedWait = 30;

        public ctlMoveExpand()
        {
            InitializeComponent();
            XPlusTimer = new Timer();
            YPlusTimer = new Timer();
            ZPlusTimer = new Timer();

            XMinusTimer = new Timer();
            YMinusTimer = new Timer();
            ZMinusTimer = new Timer();

            XPlusTimer.Interval = HiSpeedWait;
            YPlusTimer.Interval = HiSpeedWait;
            ZPlusTimer.Interval = HiSpeedWait;

            XMinusTimer.Interval = HiSpeedWait;
            YMinusTimer.Interval = HiSpeedWait;
            ZMinusTimer.Interval = HiSpeedWait;

            XPlusTimer.Tick += new System.EventHandler(XPlusTimer_Tick);
            YPlusTimer.Tick += new System.EventHandler(YPlusTimer_Tick);
            ZPlusTimer.Tick += new System.EventHandler(ZPlusTimer_Tick);

            XMinusTimer.Tick += new System.EventHandler(XMinusTimer_Tick);
            YMinusTimer.Tick += new System.EventHandler(YMinusTimer_Tick);
            ZMinusTimer.Tick += new System.EventHandler(ZMinusTimer_Tick);


            //textMoveX.ValidColor = ct.ForeColor;
            //textMoveY.ValidColor = ct.ForeColor;
            //textMoveZ.ValidColor = ct.ForeColor;

            //BackColor =
            //flowLayoutPanel2.BackColor = 
            //textMoveX.BackColor = 
            //textMoveY.BackColor = 
            //textMoveZ.BackColor = Wcolor.BackColor;

            //flowLayoutPanel1.BackColor = 
            //flowLayoutPanel7.BackColor = 
            //flowLayoutPanel8.BackColor = 
            //flowLayoutPanel10.BackColor = Wcolor.BackColor;
            //register our button so it can be skinned
            //UVDLPApp.Instance().m_gui_config.AddButton("move", ctlTitle1.Button); gets style from control
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
                //UVDLPApp.Instance().m_undoer.SaveTranslation(UVDLPApp.Instance().SelectedObject, x, y, z);  // moved to translate function
                //UVDLPApp.Instance().SelectedObject.Update(); // make sure we update                         // moved to translate function
                //ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eUpdateSelectedObject, "updateobject");
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void buttXPlus_MouseDown(object sender, MouseEventArgs e)
        {
            XPlusTimer.Tag = DateTime.Now;
            XPlusTimer.Start();
        }

        private void buttXPlus_MouseUp(object sender, MouseEventArgs e)
        {
            XPlusTimer.Stop();
            XPlusTimer.Interval = HiSpeedWait;
        }

        private void buttYPlus_MouseDown(object sender, MouseEventArgs e)
        {
            YPlusTimer.Tag = DateTime.Now;
            YPlusTimer.Start();
        }

        private void buttYPlus_MouseUp(object sender, MouseEventArgs e)
        {
            YPlusTimer.Stop();
            YPlusTimer.Interval = HiSpeedWait;
        }

        private void buttZPlus_MouseDown(object sender, MouseEventArgs e)
        {
            ZPlusTimer.Tag = DateTime.Now;
            ZPlusTimer.Start();
        }

        private void buttZPlus_MouseUp(object sender, MouseEventArgs e)
        {
            ZPlusTimer.Stop();
            ZPlusTimer.Interval = HiSpeedWait;
        }

        private void buttXMinus_MouseDown(object sender, MouseEventArgs e)
        {
            XMinusTimer.Tag = DateTime.Now;
            XMinusTimer.Start();
        }

        private void buttXMinus_MouseUp(object sender, MouseEventArgs e)
        {
            XMinusTimer.Stop();
            XMinusTimer.Interval = HiSpeedWait;
        }

        private void buttYMinus_MouseDown(object sender, MouseEventArgs e)
        {
            YMinusTimer.Tag = DateTime.Now;
            YMinusTimer.Start();
        }

        private void buttYMinus_MouseUp(object sender, MouseEventArgs e)
        {
            YMinusTimer.Stop();
            YMinusTimer.Interval = HiSpeedWait;
        }

        private void buttZMinus_MouseDown(object sender, MouseEventArgs e)
        {
            ZMinusTimer.Tag = DateTime.Now;
            ZMinusTimer.Start();
        }

        private void buttZMinus_MouseUp(object sender, MouseEventArgs e)
        {
            ZMinusTimer.Stop();
            ZMinusTimer.Interval = HiSpeedWait;
        }

        private void buttMoveX_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveX, 1, 0, 0);
        }

        private void buttMoveY_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveY, 0, 1, 0);
        }

        private void buttMoveZ_Click(object sender, EventArgs e)
        {
            MoveObject(textMoveZ, 0, 0, 1);
        }

        private void buttCenter_Click(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().SelectedObject == null) return;
            Point3d center = UVDLPApp.Instance().SelectedObject.CalcCenter();
            UVDLPApp.Instance().SelectedObject.Translate((float)-center.x, (float)-center.y, (float)-center.z, true);
            //UVDLPApp.Instance().m_undoer.SaveTranslation(UVDLPApp.Instance().SelectedObject, (float)-center.x, (float)-center.y, (float)-center.z);
            //UVDLPApp.Instance().SelectedObject.Update(); // make sure we update
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eUpdateSelectedObject, "updateobject");
        }

        private void buttOnPlatform_Click(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().SelectedObject == null)
                return;
            Point3d center = UVDLPApp.Instance().SelectedObject.CalcCenter();
            UVDLPApp.Instance().SelectedObject.FindMinMax();
            float zlev = (float)UVDLPApp.Instance().SelectedObject.m_min.z;
            //float epsilon = .05f; // add in a the level of 1 slice
            //float zmove = -zlev - epsilon; // SHS - place object flat on platform, no epsilon
            float zmove = -zlev;
            //UVDLPApp.Instance().SelectedObject.Translate((float)0, (float)0, (float)-zlev);
            //UVDLPApp.Instance().SelectedObject.Translate((float)0, (float)0, (float)-epsilon);
            UVDLPApp.Instance().SelectedObject.Translate(0, 0, zmove, true);
            //UVDLPApp.Instance().m_undoer.SaveTranslation(UVDLPApp.Instance().SelectedObject, 0, 0, zmove);
            //UVDLPApp.Instance().SelectedObject.Update(); // make sure we update
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eUpdateSelectedObject, "updateobject");
        }

        private void XPlusTimer_Tick(object sender, EventArgs e)
        {
            XPlusTimer.Interval = LoSpeedWait;
            try
            {
                float fval = float.Parse(textMoveX.Text);
                fval += 1;
                textMoveX.Text = fval.ToString();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }
        }

        private void YPlusTimer_Tick(object sender, EventArgs e)
        {
            YPlusTimer.Interval = LoSpeedWait;
            try
            {
                float fval = float.Parse(textMoveY.Text);
                fval += 1;
                textMoveY.Text = fval.ToString();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }
        }

        private void ZPlusTimer_Tick(object sender, EventArgs e)
        {
            ZPlusTimer.Interval = LoSpeedWait;
            try
            {
                float fval = float.Parse(textMoveZ.Text);
                fval += 1;
                textMoveZ.Text = fval.ToString();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }
        }

        private void XMinusTimer_Tick(object sender, EventArgs e)
        {
            XMinusTimer.Interval = LoSpeedWait;
            try
            {
                float fval = float.Parse(textMoveX.Text);
                fval -= 1;
                textMoveX.Text = fval.ToString();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }
        }

        private void YMinusTimer_Tick(object sender, EventArgs e)
        {
            YMinusTimer.Interval = LoSpeedWait;
            try
            {
                float fval = float.Parse(textMoveY.Text);
                fval -= 1;
                textMoveY.Text = fval.ToString();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }
        }

        private void ZMinusTimer_Tick(object sender, EventArgs e)
        {
            ZMinusTimer.Interval = LoSpeedWait;
            try
            {
                float fval = float.Parse(textMoveZ.Text);
                fval -= 1;
                textMoveZ.Text = fval.ToString();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }
        }

        public override void ApplyStyle(GuiControlStyle ct)
        {
            base.ApplyStyle(ct);
            if (ct.ForeColor.IsValid())
            {
                //label8.ForeColor = ct.ForeColor;
                ctlTitle1.ForeColor = ct.ForeColor;
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

        private void ctlTitle1_Click(object sender, EventArgs e)
        {
            if (ctlTitle1.Checked)
            {
                //expand
                //this.Height = 244 + 5;
                int h = ctlTitle1.Height;
                h += flowLayoutPanel1.Height;
                h += flowLayoutPanel7.Height;
                h += flowLayoutPanel8.Height;
                h += flowLayoutPanel10.Height;
                h += 3 * 8;
                Height = h;
            }
            else 
            {
                // 
                this.Height = ctlTitle1.Height + 5;
            }
        }

        private void ctlMoveExpand_Resize(object sender, EventArgs e)
        {
            //1,7,8,10,title
            ctlTitle1.Width = ctlTitle1.Parent.Width - 6;
            flowLayoutPanel1.Width = flowLayoutPanel1.Parent.Width - 6;
            flowLayoutPanel7.Width = flowLayoutPanel7.Parent.Width - 6;
            flowLayoutPanel8.Width = flowLayoutPanel8.Parent.Width - 6;
            flowLayoutPanel10.Width = flowLayoutPanel10.Parent.Width - 6;
        }

        private void buttArrange_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().Engine3D.RearrangeObjects();
        }

        public override void RegisterSubControls(string parentName)
        {
            UVDLPApp.Instance().m_gui_config.AddButton(parentName + ".title", ctlTitle1);
        }
    }
}

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
    public partial class ctlRotate : ctlUserPanel
    {
        private Timer XPlusTimer;
        private Timer XMinusTimer;
        private Timer YPlusTimer;
        private Timer YMinusTimer;
        private Timer ZPlusTimer;
        private Timer ZMinusTimer;

        /// <summary>
        /// The delay in milliseconds between repeats regular interval
        /// </summary>
        public int LoSpeedWait = 290;

        /// <summary>
        /// The delay in milliseconds imulate mouse clicks
        /// </summary>
        public int HiSpeedWait = 30;

        public ctlRotate()
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

            //UVDLPApp.Instance().m_gui_config.AddButton("rotate", ctlTitle1.Button); // get style from control

            SetTexts();

            
                //textRotateY.ValidColor = ct.ForeColor;
                //textRotateZ.ValidColor = ct.ForeColor;
            
                //BackColor = 
                //flowLayoutPanel2.BackColor = 
                //textRotateX.BackColor = 
                //textRotateY.BackColor = 
                //textRotateZ.BackColor = Wcolor.BackColor;
            
                //flowLayoutPanel7.BackColor = 
                //flowLayoutPanel8.BackColor = 
                //flowLayoutPanel10.BackColor = Wcolor.BackColor;

        }

        private void SetTexts()
        {
            this.ctlTitle1.Text = ((DesignMode) ? "Rotate" : UVDLPApp.Instance().resman.GetString("Rotate", UVDLPApp.Instance().cul));
            this.label9.Text = ((DesignMode) ? "X_" : UVDLPApp.Instance().resman.GetString("X_", UVDLPApp.Instance().cul));
            this.textRotateX.Text = ((DesignMode) ? "_900" : UVDLPApp.Instance().resman.GetString("_900", UVDLPApp.Instance().cul));
            this.label10.Text = ((DesignMode) ? "Y" : UVDLPApp.Instance().resman.GetString("Y", UVDLPApp.Instance().cul));
            this.textRotateY.Text = ((DesignMode) ? "_900" : UVDLPApp.Instance().resman.GetString("_900", UVDLPApp.Instance().cul));
            this.label11.Text = ((DesignMode) ? "Z" : UVDLPApp.Instance().resman.GetString("Z", UVDLPApp.Instance().cul));
            this.textRotateZ.Text = ((DesignMode) ? "_900" : UVDLPApp.Instance().resman.GetString("_900", UVDLPApp.Instance().cul));

        }

        public void FixForeColor(Color clr)
        {
            label9.ForeColor = clr;
            label10.ForeColor = clr;
            label11.ForeColor = clr;
        }
        protected void RotateObject(ctlTextBox var, float x, float y, float z)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float val = var.FloatVal * 0.0174532925f;
                x *= val;
                y *= val;
                z *= val;
                UVDLPApp.Instance().SelectedObject.Rotate(x, y, z);
                UVDLPApp.Instance().m_undoer.SaveRotation(UVDLPApp.Instance().SelectedObject, x, y, z);
                UVDLPApp.Instance().SelectedObject.Update(); // make sure we update
                //ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eUpdateSelectedObject, ((DesignMode) ? "Updateobject" : UVDLPApp.Instance().resman.GetString("Updateobject", UVDLPApp.Instance().cul)));
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void buttRotateX_Click(object sender, EventArgs e)
        {
            RotateObject(textRotateX, 1, 0, 0);
        }

        private void buttRotateY_Click(object sender, EventArgs e)
        {
            RotateObject(textRotateY, 0, 1, 0);
        }

        private void buttRotateZ_Click(object sender, EventArgs e)
        {
            RotateObject(textRotateZ, 0, 0, 1);
        }

        /// <summary>
        /// XPlus Behavior when MouseDown is pressed
        /// introduced for continuous mousepress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void XPlusTimer_Tick(object sender, EventArgs e)
        {
            XPlusTimer.Interval = LoSpeedWait;
            try
            {
                float fval = float.Parse(textRotateX.Text);
                fval += 5;
                //specific behavior towards rotation when > 360 go to 0 ?
                if (CheckValue(fval))
                {
                    textRotateX.Text = fval.ToString();
                }
                else
                {
                    textRotateX.Text = "0";
                }
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
                float fval = float.Parse(textRotateY.Text);
                fval += 5;
                if (CheckValue(fval))
                {
                    textRotateY.Text = fval.ToString();
                }
                else
                {
                    textRotateY.Text = "0";
                }
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
                float fval = float.Parse(textRotateZ.Text);
                fval += 5;
                if (CheckValue(fval))
                {
                    textRotateZ.Text = fval.ToString();
                }
                else
                {
                    textRotateZ.Text = "0";
                }
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
                float fval = float.Parse(textRotateX.Text);
                fval -= 5;
                if (CheckValue(fval))
                {
                    textRotateX.Text = fval.ToString();
                }
                else
                {
                    textRotateX.Text = "0";
                }
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
                float fval = float.Parse(textRotateY.Text);
                fval -= 5;
                if (CheckValue(fval))
                {
                    textRotateY.Text = fval.ToString();
                }
                else
                {
                    textRotateY.Text = "0";
                }
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
                float fval = float.Parse(textRotateZ.Text);
                fval -= 5;
                if (CheckValue(fval))
                {
                    textRotateZ.Text = fval.ToString();
                }
                else
                {
                    textRotateZ.Text = "0";
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }

        }

        private Boolean CheckValue(float newvalue)
        {
            if (newvalue < -360 || newvalue > 360)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void ApplyStyle(GuiControlStyle ct)
        {
            base.ApplyStyle(ct);
            if (ct.ForeColor.IsValid())
            {
                ctlTitle1.ForeColor = ct.ForeColor;
                label9.ForeColor = ct.ForeColor;
                label10.ForeColor = ct.ForeColor;
                label11.ForeColor = ct.ForeColor;
                textRotateX.ValidColor = ct.ForeColor;
                textRotateY.ValidColor = ct.ForeColor;
                textRotateZ.ValidColor = ct.ForeColor;
            }
            if (ct.BackColor.IsValid())
            {
                BackColor = ct.BackColor;
                flowLayoutPanel2.BackColor = ct.BackColor;
                textRotateX.BackColor = ct.BackColor;
                textRotateY.BackColor = ct.BackColor;
                textRotateZ.BackColor = ct.BackColor;
            }
            if (ct.FrameColor.IsValid())
            {
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
                //this.Height = 186 + 5;
                int h = ctlTitle1.Height;
                h += flowLayoutPanel7.Height;
                h += flowLayoutPanel8.Height;
                h += flowLayoutPanel10.Height;
                h += 3 * 7;// vertical margins 
                this.Height = h;
            }
            else
            {
                // 
                this.Height = ctlTitle1.Height + 5;
            }
        }

        private void ctlRotate_Resize(object sender, EventArgs e)
        {
            ctlTitle1.Width = ctlTitle1.Parent.Width - 6;
            flowLayoutPanel7.Width = flowLayoutPanel7.Parent.Width - 6;
            flowLayoutPanel8.Width = flowLayoutPanel8.Parent.Width - 6;
            flowLayoutPanel10.Width = flowLayoutPanel10.Parent.Width - 6;
        }

        public override void RegisterSubControls(string parentName)
        {
            UVDLPApp.Instance().m_gui_config.AddButton(parentName + ".title", ctlTitle1);
        }
    }
}

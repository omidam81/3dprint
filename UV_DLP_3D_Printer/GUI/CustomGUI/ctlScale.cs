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
    public partial class ctlScale : ctlUserPanel
    {
        private Timer AllPlusTimer;
        private Timer XPlusTimer;
        private Timer XMinusTimer;
        private Timer YPlusTimer;
        private Timer YMinusTimer;
        private Timer ZPlusTimer;
        private Timer ZMinusTimer;
        private Timer AllMinusTimer;

        /// <summary>
        /// The delay in milliseconds between repeats regular interval
        /// </summary>
        public int LoSpeedWait = 290;

        /// <summary>
        /// The delay in milliseconds imulate mouse clicks
        /// </summary>
        public int HiSpeedWait = 30;
        public ctlScale()
        {
            InitializeComponent();

            //Initialise Timers for all the buttons in Scale
            AllPlusTimer = new Timer();
            XPlusTimer = new Timer();
            YPlusTimer = new Timer();
            ZPlusTimer = new Timer();

            AllMinusTimer = new Timer();
            XMinusTimer = new Timer();
            YMinusTimer = new Timer();
            ZMinusTimer = new Timer();

            //Set default value for Timer Intervals
            AllPlusTimer.Interval = HiSpeedWait;
            XPlusTimer.Interval = HiSpeedWait;
            YPlusTimer.Interval = HiSpeedWait;
            ZPlusTimer.Interval = HiSpeedWait;

            AllMinusTimer.Interval = HiSpeedWait;
            XMinusTimer.Interval = HiSpeedWait;
            YMinusTimer.Interval = HiSpeedWait;
            ZMinusTimer.Interval = HiSpeedWait;

            AllPlusTimer.Tick += new System.EventHandler(AllPlusTimer_Tick);
            XPlusTimer.Tick += new System.EventHandler(XPlusTimer_Tick);
            YPlusTimer.Tick += new System.EventHandler(YPlusTimer_Tick);
            ZPlusTimer.Tick += new System.EventHandler(ZPlusTimer_Tick);

            AllMinusTimer.Tick += new System.EventHandler(AllMinusTimer_Tick);
            XMinusTimer.Tick += new System.EventHandler(XMinusTimer_Tick);
            YMinusTimer.Tick += new System.EventHandler(YMinusTimer_Tick);
            ZMinusTimer.Tick += new System.EventHandler(ZMinusTimer_Tick);
            //UVDLPApp.Instance().m_gui_config.AddButton("scale", ctlTitle1.Button); // get its style from control
            SetTexts();


            
                //labelManipType.ForeColor = ct.ForeColor;
                //ctlTitle1.ForeColor = 
                //label5.ForeColor = 
                //label6.ForeColor = 
                //label7.ForeColor = 
                //label12.ForeColor = Wcolor.ForeColor;
                //textScaleX.ValidColor = ct.ForeColor;
                //textScaleY.ValidColor = ct.ForeColor;
                //textScaleZ.ValidColor = ct.ForeColor;
                //textScaleAll.ValidColor = ct.ForeColor;
                //BackColor = 
                //ctlTitle1.BackColor =   
                //manipObject.BackColor = 
                //textScaleX.BackColor =  
                //textScaleY.BackColor =  
                //textScaleZ.BackColor =  
                //textScaleAll.BackColor = Wcolor.BackColor;
                //flowLayoutPanel1.BackColor = 
                //flowLayoutPanel2.BackColor = 
                //flowLayoutPanel3.BackColor = 
                //flowLayoutPanel4.BackColor = 
                //flowLayoutPanel5.BackColor = Wcolor.BackColor;
        }

        private void SetTexts()
        {
            this.label12.Text = ((DesignMode) ? "All" : UVDLPApp.Instance().resman.GetString("All", UVDLPApp.Instance().cul));
            this.textScaleAll.Text = ((DesignMode) ? "_1000" : UVDLPApp.Instance().resman.GetString("_1000", UVDLPApp.Instance().cul));
            this.textScaleX.Text = ((DesignMode) ? "_1000" : UVDLPApp.Instance().resman.GetString("_1000", UVDLPApp.Instance().cul));
            this.label6.Text = ((DesignMode) ? "Y_" : UVDLPApp.Instance().resman.GetString("Y_", UVDLPApp.Instance().cul));
            this.textScaleY.Text = ((DesignMode) ? "_1000" : UVDLPApp.Instance().resman.GetString("_1000", UVDLPApp.Instance().cul));
            this.label7.Text = ((DesignMode) ? "Z" : UVDLPApp.Instance().resman.GetString("Z", UVDLPApp.Instance().cul));
            this.textScaleZ.Text = ((DesignMode) ? "_1000" : UVDLPApp.Instance().resman.GetString("_1000", UVDLPApp.Instance().cul));
            this.ctlTitle1.Text = ((DesignMode) ? "Scale" : UVDLPApp.Instance().resman.GetString("Scale", UVDLPApp.Instance().cul));

        }

        public void FixForeColor(Color clr)
        {
            label5.ForeColor = clr;
            label6.ForeColor = clr;
            label7.ForeColor = clr;
            label12.ForeColor = clr;
        }
        protected void ScaleObject(ctlTextBox var, float x, float y, float z)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                float val = var.FloatVal / 100f;
                x = (x == 0) ? 1 : x * val;
                y = (y == 0) ? 1 : y * val;
                z = (z == 0) ? 1 : z * val; 
                UVDLPApp.Instance().SelectedObject.Scale(x, y, z);
                UVDLPApp.Instance().m_undoer.SaveScale(UVDLPApp.Instance().SelectedObject, x, y, z);
                UVDLPApp.Instance().SelectedObject.Update(); // make sure we update
                //ShowObjectInfo();
                UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eUpdateSelectedObject, ((DesignMode) ? "Updateobject" :UVDLPApp.Instance().resman.GetString("Updateobject", UVDLPApp.Instance().cul)));

            }
            catch (Exception)
            {

            }
        }

        private void buttScaleAll_Click(object sender, EventArgs e)
        {
            ScaleObject(textScaleAll, 1, 1, 1);
        }

        private void buttScaleX_Click(object sender, EventArgs e)
        {
            ScaleObject(textScaleX, 1, 0, 0);
        }

        private void buttScaleY_Click(object sender, EventArgs e)
        {
            ScaleObject(textScaleY, 0, 1, 0);
        }

        private void buttScaleZ_Click(object sender, EventArgs e)
        {
            ScaleObject(textScaleZ, 0, 0, 1);
        }

        private void buttAllPlus_MouseUp(object sender, MouseEventArgs e)
        {
            AllPlusTimer.Stop();
            AllPlusTimer.Interval = HiSpeedWait;
        }

        private void buttAllPlus_MouseDown(object sender, MouseEventArgs e)
        {
            AllPlusTimer.Tag = DateTime.Now;
            AllPlusTimer.Start();
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

            if (UVDLPApp.Instance().SelectedObject == null)
                return;
            float scale = 25.4f;
            UVDLPApp.Instance().SelectedObject.Scale(scale, scale, scale);
            UVDLPApp.Instance().m_undoer.SaveScale(UVDLPApp.Instance().SelectedObject, scale, scale, scale);
            UVDLPApp.Instance().SelectedObject.Update(); // make sure we update
            //ShowObjectInfo();
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eUpdateSelectedObject, ((DesignMode) ? "Updateobject" :UVDLPApp.Instance().resman.GetString("Updateobject", UVDLPApp.Instance().cul)));

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

        private void buttAllMinus_MouseUp(object sender, MouseEventArgs e)
        {
            AllMinusTimer.Stop();
            AllMinusTimer.Interval = HiSpeedWait;
        }

        private void buttAllMinus_MouseDown(object sender, MouseEventArgs e)
        {
            AllMinusTimer.Tag = DateTime.Now;
            AllMinusTimer.Start();
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

        private void AllPlusTimer_Tick(object sender, EventArgs e)
        {
            AllPlusTimer.Interval = LoSpeedWait;
            try
            {
                float fval = float.Parse(textScaleAll.Text);
                fval += 10.0f;
                textScaleAll.Text = fval.ToString();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }
        }

        private void AllMinusTimer_Tick(object sender, EventArgs e)
        {
            AllMinusTimer.Interval = LoSpeedWait;
            try
            {
                float fval = float.Parse(textScaleAll.Text);
                if (fval >= 20) //value may not go below 10
                {
                    fval -= 10.0f;
                }
                textScaleAll.Text = fval.ToString();
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }
        }

        private void XPlusTimer_Tick(object sender, EventArgs e)
        {
            XPlusTimer.Interval = LoSpeedWait;
            try
            {
                float fval = float.Parse(textScaleX.Text);
                fval += 10.0f;
                textScaleX.Text = fval.ToString();
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
                float fval = float.Parse(textScaleX.Text);
                if (fval >= 20) //value may not go below 10
                {
                    fval -= 10.0f;
                }
                textScaleX.Text = fval.ToString();
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
                float fval = float.Parse(textScaleY.Text);
                if (fval >= 20) //value may not go below 10
                {
                    fval += 10.0f;
                }
                textScaleY.Text = fval.ToString();
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
                float fval = float.Parse(textScaleY.Text);
                if (fval >= 20) //value may not go below 10
                {
                    fval -= 10.0f;
                }
                textScaleY.Text = fval.ToString();
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
                float fval = float.Parse(textScaleZ.Text);
                fval += 10.0f;
                textScaleZ.Text = fval.ToString();
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
                float fval = float.Parse(textScaleZ.Text);
                if (fval >= 20) //value may not go below 10
                {
                    fval -= 10.0f;
                }
                textScaleZ.Text = fval.ToString();
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
                //labelManipType.ForeColor = ct.ForeColor;
                ctlTitle1.ForeColor = ct.ForeColor;
                label5.ForeColor = ct.ForeColor;
                label6.ForeColor = ct.ForeColor;
                label7.ForeColor = ct.ForeColor;
                label12.ForeColor = ct.ForeColor;
                textScaleX.ValidColor = ct.ForeColor;
                textScaleY.ValidColor = ct.ForeColor;
                textScaleZ.ValidColor = ct.ForeColor;
                textScaleAll.ValidColor = ct.ForeColor;
            }
            if (ct.BackColor.IsValid())
            {
                BackColor = ct.BackColor;
                ctlTitle1.BackColor = ct.BackColor;
                manipObject.BackColor = ct.BackColor;
                textScaleX.BackColor = ct.BackColor;
                textScaleY.BackColor = ct.BackColor;
                textScaleZ.BackColor = ct.BackColor;
                textScaleAll.BackColor = ct.BackColor;
            }
            if (ct.FrameColor.IsValid())
            {
                flowLayoutPanel1.BackColor = ct.FrameColor;
                flowLayoutPanel2.BackColor = ct.FrameColor;
                flowLayoutPanel3.BackColor = ct.FrameColor;
                flowLayoutPanel4.BackColor = ct.FrameColor;                
                flowLayoutPanel5.BackColor = ct.FrameColor;
            }

        }

        private void ctlTitle1_Click(object sender, EventArgs e)
        {
            if (ctlTitle1.Checked)
            {
                //this.Height = 225 + 5;
                int h = ctlTitle1.Height + flowLayoutPanel1.Height;
                h += flowLayoutPanel2.Height;
                h += flowLayoutPanel3.Height;
                h += flowLayoutPanel4.Height;
                h += flowLayoutPanel5.Height;
                h += 3 * 7; // vertical margins
                this.Height = h;
            }
            else
            {
                this.Height = ctlTitle1.Height + 5;
            }
        }

        private void ctlScale_Resize(object sender, EventArgs e)
        {
            try
            {
                ctlTitle1.Width = ctlTitle1.Parent.Width - 6;
                flowLayoutPanel1.Width = flowLayoutPanel1.Parent.Width - 6;
                flowLayoutPanel2.Width = flowLayoutPanel2.Parent.Width - 6;
                flowLayoutPanel3.Width = flowLayoutPanel3.Parent.Width - 6;
                flowLayoutPanel4.Width = flowLayoutPanel4.Parent.Width - 6;
                flowLayoutPanel5.Width = flowLayoutPanel5.Parent.Width - 6;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
        }

        private void buttmm2inch_Click(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().SelectedObject == null)
                return;
            float scale = 25.4f;
            UVDLPApp.Instance().SelectedObject.Scale(scale, scale, scale);
            UVDLPApp.Instance().m_undoer.SaveScale(UVDLPApp.Instance().SelectedObject, scale, scale, scale);
            UVDLPApp.Instance().SelectedObject.Update(); // make sure we update
            //ShowObjectInfo();
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eUpdateSelectedObject, "updateobject");
        }

        private void buttinch2mm_Click(object sender, EventArgs e)
        {

            if (UVDLPApp.Instance().SelectedObject == null)
                return;
            float scale = 1.0f/25.4f;
            UVDLPApp.Instance().SelectedObject.Scale(scale, scale, scale);
            UVDLPApp.Instance().m_undoer.SaveScale(UVDLPApp.Instance().SelectedObject, scale, scale, scale);
            UVDLPApp.Instance().SelectedObject.Update(); // make sure we update
            //ShowObjectInfo();
            UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eUpdateSelectedObject, "updateobject");

        }

        public override void RegisterSubControls(string parentName)
        {
            UVDLPApp.Instance().m_gui_config.AddButton(parentName + ".title", ctlTitle1);
        }
    }
}

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
    public partial class frmBuildSizeCalib : Form
    {
        float platoformsizeX, platoformsizeY;
        public float calcplatoformsizeX, calcplatoformsizeY;
        float modelsizeX, modelsizeY;
        float measuredmodelsizeX, measuredmodelsizeY;
        public void setPlatformSize(float x, float y)
        {
            platoformsizeX = x;
            platoformsizeY = y;
            SetData();
            CalcNewSize();
        }
        public void setModelSize(float x, float y)
        {
            modelsizeX = x;
            modelsizeY = y;
            SetData();
            CalcNewSize();
        }
        public frmBuildSizeCalib()
        {
            InitializeComponent();
            CalcNewSize();
            SetData();

            SetTexts();
        }

        private void SetTexts()
        {
            this.cmdOK.Text = ((DesignMode) ? "OK" : UVDLPApp.Instance().resman.GetString("OK", UVDLPApp.Instance().cul));
            this.modelgroup.Text = ((DesignMode) ? "ModelSizeMm" : UVDLPApp.Instance().resman.GetString("ModelSizeMm", UVDLPApp.Instance().cul));
            this.txtmodely.Text = ((DesignMode) ? "_20" : UVDLPApp.Instance().resman.GetString("_20", UVDLPApp.Instance().cul));
            this.label2.Text = ((DesignMode) ? "YSize" : UVDLPApp.Instance().resman.GetString("YSize", UVDLPApp.Instance().cul));
            this.label2.Text = ((DesignMode) ? "YSize" : UVDLPApp.Instance().resman.GetString("YSize", UVDLPApp.Instance().cul));
            this.txtmodelx.Text = ((DesignMode) ? "_20" : UVDLPApp.Instance().resman.GetString("_20", UVDLPApp.Instance().cul));
            this.label1.Text = ((DesignMode) ? "XSize" : UVDLPApp.Instance().resman.GetString("XSize", UVDLPApp.Instance().cul));
            this.groupBox2.Text = ((DesignMode) ? "MeasuredSizeMm" : UVDLPApp.Instance().resman.GetString("MeasuredSizeMm", UVDLPApp.Instance().cul));
            this.txtmeasuredy.Text = ((DesignMode) ? "_20" : UVDLPApp.Instance().resman.GetString("_20", UVDLPApp.Instance().cul));
            this.txtmeasuredx.Text = ((DesignMode) ? "_20" : UVDLPApp.Instance().resman.GetString("_20", UVDLPApp.Instance().cul));
            this.label4.Text = ((DesignMode) ? "XSize" : UVDLPApp.Instance().resman.GetString("XSize", UVDLPApp.Instance().cul));
            this.cmdCancel.Text = ((DesignMode) ? "Cancel" : UVDLPApp.Instance().resman.GetString("Cancel", UVDLPApp.Instance().cul));
            this.groupBox1.Text = ((DesignMode) ? "CurrentBuildPlatformSize" : UVDLPApp.Instance().resman.GetString("CurrentBuildPlatformSize", UVDLPApp.Instance().cul));
            this.lblBuildSizeY.Text = ((DesignMode) ? "YSize" : UVDLPApp.Instance().resman.GetString("YSize", UVDLPApp.Instance().cul));
            this.lblBuildSizeY.Text = ((DesignMode) ? "YSize" : UVDLPApp.Instance().resman.GetString("YSize", UVDLPApp.Instance().cul));
            this.lblBuildSizeX.Text = ((DesignMode) ? "XSize" : UVDLPApp.Instance().resman.GetString("XSize", UVDLPApp.Instance().cul));
            this.groupBox3.Text = ((DesignMode) ? "NewBuildPlatformSize" : UVDLPApp.Instance().resman.GetString("NewBuildPlatformSize", UVDLPApp.Instance().cul));
            this.lblNewBuildSizeY.Text = ((DesignMode) ? "YSize" : UVDLPApp.Instance().resman.GetString("YSize", UVDLPApp.Instance().cul));
            this.Text = ((DesignMode) ? "BuildSizeCalibration" : UVDLPApp.Instance().resman.GetString("BuildSizeCalibration", UVDLPApp.Instance().cul));
            this.label3.Text = ((DesignMode) ? "YSize" : UVDLPApp.Instance().resman.GetString("YSize", UVDLPApp.Instance().cul));
            this.lblNewBuildSizeY.Text = ((DesignMode) ? "YSize" : UVDLPApp.Instance().resman.GetString("YSize", UVDLPApp.Instance().cul));
        }

        private void CalcNewSize() 
        {
            try
            {
                GetData(); // get the current data
                //make some calculations
                //calcplatoformsizeX = measuredmodelsizeX / platoformsizeX;
                // scale is measuredsize / modelsize
                // scale is modelsize / measuredsize
                //                float scaleX = modelsizeX / measuredmodelsizeX;
                //                float scaleY = modelsizeY / measuredmodelsizeY;
                
                float scaleX = measuredmodelsizeX / modelsizeX;
                float scaleY = measuredmodelsizeY / modelsizeY;
                calcplatoformsizeX = scaleX * platoformsizeX;
                calcplatoformsizeY = scaleY * platoformsizeY;
                SetData();
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
        }
        private void SetData()
        {
            lblBuildSizeX.Text = platoformsizeX.ToString();
            lblBuildSizeY.Text = platoformsizeY.ToString();
            lblNewBuildSizeX.Text = calcplatoformsizeX.ToString();
            lblNewBuildSizeY.Text = calcplatoformsizeY.ToString();
        }
        private void GetData() 
        {
            try
            {
                measuredmodelsizeX = float.Parse(txtmeasuredx.Text);
                measuredmodelsizeY = float.Parse(txtmeasuredy.Text);
                modelsizeX = float.Parse(txtmodelx.Text);
                modelsizeY = float.Parse(txtmodely.Text);
            }
            catch (Exception ) 
            {
                //DebugLogger.Instance().LogError(ex);
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            GetData();
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void txtmeasuredx_TextChanged(object sender, EventArgs e)
        {
            CalcNewSize();
        }

        private void txtmeasuredy_TextChanged(object sender, EventArgs e)
        {
            CalcNewSize();

        }

        private void txtmodelx_TextChanged(object sender, EventArgs e)
        {
            CalcNewSize();
        }

        private void txtmodely_TextChanged(object sender, EventArgs e)
        {
            CalcNewSize();
        }
    }
}

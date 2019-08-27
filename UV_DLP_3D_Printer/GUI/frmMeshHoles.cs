using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Engine3D;
namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmMeshHoles : Form
    {
        public frmMeshHoles()
        {
            InitializeComponent();
            SetTexts();
        }

        private void SetTexts()
        {
            this.cmdCheck.Text = ((DesignMode) ? "Report_" : UVDLPApp.Instance().resman.GetString("Report_", UVDLPApp.Instance().cul));
            this.lblReport.Text = ((DesignMode) ? "Report_" : UVDLPApp.Instance().resman.GetString("Report_", UVDLPApp.Instance().cul));
            this.Text = ((DesignMode) ? "CheckMeshForHoles" : UVDLPApp.Instance().resman.GetString("CheckMeshForHoles", UVDLPApp.Instance().cul));
        }

        private void cmdCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().SelectedObject == null)
                    return;
                List<Polygon> holes = UVDLPApp.Instance().SelectedObject.FindHoles();
                if (holes.Count > 0)
                {
                    lblReport.Text = ((DesignMode) ? "MeshHasHolesHoles" :UVDLPApp.Instance().resman.GetString("MeshHasHolesHoles", UVDLPApp.Instance().cul)) + holes.Count;
                }
                else
                {
                    lblReport.Text = ((DesignMode) ? "NoHolesDetected" :UVDLPApp.Instance().resman.GetString("NoHolesDetected", UVDLPApp.Instance().cul));
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
    }
}

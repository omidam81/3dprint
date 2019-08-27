using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI.ExportControls
{
    public partial class ctlExportB9Creator : UserControl
    {
        public ctlExportB9Creator()
        {
            InitializeComponent();
            SetTexts();
        }

        private void SetTexts()
        {
            this.label1.Text = ((DesignMode) ? "SceneName" : UVDLPApp.Instance().resman.GetString("SceneName", UVDLPApp.Instance().cul));
            this.label2.Text = ((DesignMode) ? "Description_" : UVDLPApp.Instance().resman.GetString("Description_", UVDLPApp.Instance().cul));
            this.label3.Text = ((DesignMode) ? "B9CreatorJobFileParameters" : UVDLPApp.Instance().resman.GetString("B9CreatorJobFileParameters", UVDLPApp.Instance().cul));
            this.label4.Text = ((DesignMode) ? "Optional" : UVDLPApp.Instance().resman.GetString("Optional", UVDLPApp.Instance().cul));
        }

        public string SceneName
        {
            get { return textName.Text; }
            set { textName.Text = value; }
        }

        public string Description
        {
            get { return textDescription.Text; }
            set { textDescription.Text = value; }
        }
    }
}

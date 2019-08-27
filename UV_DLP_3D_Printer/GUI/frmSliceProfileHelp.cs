﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmSliceProfileHelp : Form
    {
        public frmSliceProfileHelp()
        {
            InitializeComponent();
            SetTexts();
        }

        private void SetTexts()
        {
            this.Text = ((DesignMode) ? "SlicingProfileHelp" : UVDLPApp.Instance().resman.GetString("SlicingProfileHelp", UVDLPApp.Instance().cul));
        }
    }
}

﻿namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    partial class ctlCollapse
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttCollapse = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageButton();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttCollapse
            // 
            this.buttCollapse.Checked = false;
            this.buttCollapse.CheckImage = Properties.Resource_s.buttChecked;
            this.buttCollapse.Gapx = 5;
            this.buttCollapse.Gapy = 5;
            this.buttCollapse.GLBackgroundImage = null;
            this.buttCollapse.GLImage = null;
            this.buttCollapse.GLVisible = false;
            this.buttCollapse.GuiAnchor = null;
            this.buttCollapse.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttCollapse.Image = Properties.Resource_s.buttPlus;
            this.buttCollapse.Location = new System.Drawing.Point(0, 0);
            this.buttCollapse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttCollapse.Name = "buttCollapse";
            this.buttCollapse.Size = new System.Drawing.Size(48, 48);
            this.buttCollapse.StyleName = null;
            this.buttCollapse.TabIndex = 0;
            this.buttCollapse.Text = null;
            this.buttCollapse.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.buttCollapse.Click += new System.EventHandler(this.buttCollapse_Click);
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.buttCollapse);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(200, 96);
            this.pnlTitle.TabIndex = 2;
            // 
            // ctlCollapse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ctlCollapse";
            this.Size = new System.Drawing.Size(200, 185);
            this.pnlTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctlImageButton buttCollapse;
        private System.Windows.Forms.Panel pnlTitle;
    }
}

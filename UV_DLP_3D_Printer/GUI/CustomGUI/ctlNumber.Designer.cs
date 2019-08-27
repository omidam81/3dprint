namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    partial class ctlNumber
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
            this.textData = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlTextBox();
            this.buttPlus = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageEx();
            this.buttMinus = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageEx();
            this.scrollData = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlHScroll();
            ((System.ComponentModel.ISupportInitialize)(this.buttPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttMinus)).BeginInit();
            this.SuspendLayout();
            // 
            // textData
            // 
            this.textData.BackColor = System.Drawing.Color.Navy;
            this.textData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textData.DisableExceptions = true;
            this.textData.ErrorColor = System.Drawing.Color.Red;
            this.textData.FloatVal = 10F;
            this.textData.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textData.ForeColor = System.Drawing.Color.White;
            this.textData.IntVal = 1;
            this.textData.Location = new System.Drawing.Point(37, 5);
            this.textData.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textData.MaxFloat = 500F;
            this.textData.MaxInt = 1000;
            this.textData.MinFloat = -500F;
            this.textData.MinInt = 1;
            this.textData.Name = "textData";
            this.textData.Size = new System.Drawing.Size(60, 28);
            this.textData.TabIndex = 5;
            this.textData.Text = "10.0";
            this.textData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textData.ValidColor = System.Drawing.Color.White;
            this.textData.ValueType = UV_DLP_3D_Printer.GUI.CustomGUI.ctlTextBox.EValueType.Float;
            this.textData.TextChanged += new System.EventHandler(this.textData_TextChanged);
            // 
            // buttPlus
            // 
            this.buttPlus.BackColor = System.Drawing.Color.Transparent;
            this.buttPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttPlus.HoverImage = global::UV_DLP_3D_Printer.Properties.Resources.buttPlusH;
            this.buttPlus.Image = global::UV_DLP_3D_Printer.Properties.Resource_s.buttPlus;
            this.buttPlus.IsToggle = false;
            this.buttPlus.Location = new System.Drawing.Point(261, 5);
            this.buttPlus.MainImage = global::UV_DLP_3D_Printer.Properties.Resource_s.buttPlus;
            this.buttPlus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttPlus.Name = "buttPlus";
            this.buttPlus.OnClickCallback = null;
            this.buttPlus.Size = new System.Drawing.Size(28, 28);
            this.buttPlus.TabIndex = 6;
            this.buttPlus.TabStop = false;
            this.buttPlus.Click += new System.EventHandler(this.buttPlus_Click);
            this.buttPlus.DoubleClick += new System.EventHandler(this.buttPlus_Click);
            // 
            // buttMinus
            // 
            this.buttMinus.BackColor = System.Drawing.Color.Transparent;
            this.buttMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttMinus.HoverImage = global::UV_DLP_3D_Printer.Properties.Resources.butMinusH;
            this.buttMinus.Image = global::UV_DLP_3D_Printer.Properties.Resource_s.butMinus;
            this.buttMinus.IsToggle = false;
            this.buttMinus.Location = new System.Drawing.Point(3, 5);
            this.buttMinus.MainImage = global::UV_DLP_3D_Printer.Properties.Resource_s.butMinus;
            this.buttMinus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttMinus.Name = "buttMinus";
            this.buttMinus.OnClickCallback = null;
            this.buttMinus.Size = new System.Drawing.Size(28, 28);
            this.buttMinus.TabIndex = 3;
            this.buttMinus.TabStop = false;
            this.buttMinus.Click += new System.EventHandler(this.buttMinus_Click);
            this.buttMinus.DoubleClick += new System.EventHandler(this.buttMinus_Click);
            // 
            // scrollData
            // 
            this.scrollData.BackColor = System.Drawing.Color.Navy;
            this.scrollData.Checked = false;
            this.scrollData.ForeColor = System.Drawing.Color.RoyalBlue;
            this.scrollData.Gapx = 5;
            this.scrollData.Gapy = 5;
            this.scrollData.GLBackgroundImage = null;
            this.scrollData.GLVisible = false;
            this.scrollData.GuiAnchor = null;
            this.scrollData.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.scrollData.Increment = 10;
            this.scrollData.Location = new System.Drawing.Point(103, 3);
            this.scrollData.Name = "scrollData";
            this.scrollData.Size = new System.Drawing.Size(152, 32);
            this.scrollData.StyleName = null;
            this.scrollData.TabIndex = 7;
            this.scrollData.Value = 0;
            this.scrollData.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.scrollData.Visible = false;
            this.scrollData.ValueChanged += new System.EventHandler(this.scrollData_ValueChanged);
            // 
            // ctlNumber
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.Controls.Add(this.scrollData);
            this.Controls.Add(this.buttPlus);
            this.Controls.Add(this.textData);
            this.Controls.Add(this.buttMinus);
            this.MinimumSize = new System.Drawing.Size(20, 5);
            this.Name = "ctlNumber";
            this.Size = new System.Drawing.Size(292, 39);
            this.Resize += new System.EventHandler(this.ctlNumber_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.buttPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttMinus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctlImageEx buttMinus;
        private ctlTextBox textData;
        private ctlImageEx buttPlus;
        private ctlHScroll scrollData;
    }
}

namespace UV_DLP_3D_Printer.GUI.Controls
{
    partial class ctlUserParamEdit
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
            this.lvParams = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cmdDelParam = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageEx();
            this.cmdNewParam = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageEx();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdNewParam)).BeginInit();
            this.SuspendLayout();
            // 
            // lvParams
            // 
            this.lvParams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvParams.Location = new System.Drawing.Point(6, 23);
            this.lvParams.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lvParams.Name = "lvParams";
            this.lvParams.Size = new System.Drawing.Size(294, 79);
            this.lvParams.TabIndex = 0;
            this.lvParams.UseCompatibleStateImageBehavior = false;
            this.lvParams.View = System.Windows.Forms.View.Details;
            this.lvParams.SelectedIndexChanged += new System.EventHandler(this.lvParams_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 169;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 217;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 122);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(136, 20);
            this.txtName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "User Parameters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "Value";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(6, 159);
            this.txtValue.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtValue.Size = new System.Drawing.Size(294, 92);
            this.txtValue.TabIndex = 68;
            // 
            // cmdDelParam
            // 
            this.cmdDelParam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdDelParam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdDelParam.HoverImage = global::UV_DLP_3D_Printer.Properties.Resources.butMinusH;
            this.cmdDelParam.Image = global::UV_DLP_3D_Printer.Properties.Resource_s.butMinus;
            this.cmdDelParam.IsToggle = false;
            this.cmdDelParam.Location = new System.Drawing.Point(304, 23);
            this.cmdDelParam.MainImage = global::UV_DLP_3D_Printer.Properties.Resource_s.butMinus;
            this.cmdDelParam.Name = "cmdDelParam";
            this.cmdDelParam.OnClickCallback = null;
            this.cmdDelParam.Size = new System.Drawing.Size(26, 26);
            this.cmdDelParam.TabIndex = 67;
            this.cmdDelParam.TabStop = false;
            this.cmdDelParam.Click += new System.EventHandler(this.cmdDelParam_Click);
            // 
            // cmdNewParam
            // 
            this.cmdNewParam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdNewParam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdNewParam.HoverImage = global::UV_DLP_3D_Printer.Properties.Resources.buttPlusH;
            this.cmdNewParam.Image = global::UV_DLP_3D_Printer.Properties.Resource_s.buttPlus;
            this.cmdNewParam.IsToggle = false;
            this.cmdNewParam.Location = new System.Drawing.Point(146, 122);
            this.cmdNewParam.MainImage = global::UV_DLP_3D_Printer.Properties.Resource_s.buttPlus;
            this.cmdNewParam.Name = "cmdNewParam";
            this.cmdNewParam.OnClickCallback = null;
            this.cmdNewParam.Size = new System.Drawing.Size(26, 26);
            this.cmdNewParam.TabIndex = 66;
            this.cmdNewParam.TabStop = false;
            this.cmdNewParam.Click += new System.EventHandler(this.cmdNewParam_Click);
            // 
            // ctlUserParamEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.cmdDelParam);
            this.Controls.Add(this.cmdNewParam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lvParams);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "ctlUserParamEdit";
            this.Size = new System.Drawing.Size(370, 270);
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdNewParam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvParams;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomGUI.ctlImageEx cmdDelParam;
        private CustomGUI.ctlImageEx cmdNewParam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;

    }
}

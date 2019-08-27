namespace UV_DLP_3D_Printer.GUI
{
    partial class frmPrefs
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.cmdselectfore = new System.Windows.Forms.Button();
            this.panelfore = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelback = new System.Windows.Forms.Panel();
            this.cmdselectback = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpDebug = new System.Windows.Forms.GroupBox();
            this.chkIgnoreGCRsp = new System.Windows.Forms.CheckBox();
            this.chkDriverLog = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCulters = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.grpDebug.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(246, 290);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(124, 56);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "Ok";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(378, 290);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(112, 56);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmdselectfore
            // 
            this.cmdselectfore.Location = new System.Drawing.Point(62, 162);
            this.cmdselectfore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdselectfore.Name = "cmdselectfore";
            this.cmdselectfore.Size = new System.Drawing.Size(112, 62);
            this.cmdselectfore.TabIndex = 6;
            this.cmdselectfore.Text = "Select";
            this.cmdselectfore.UseVisualStyleBackColor = true;
            this.cmdselectfore.Click += new System.EventHandler(this.cmdselectfore_Click);
            // 
            // panelfore
            // 
            this.panelfore.Location = new System.Drawing.Point(62, 77);
            this.panelfore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelfore.Name = "panelfore";
            this.panelfore.Size = new System.Drawing.Size(112, 77);
            this.panelfore.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Foreground Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Background Color";
            // 
            // panelback
            // 
            this.panelback.Location = new System.Drawing.Point(268, 77);
            this.panelback.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(112, 77);
            this.panelback.TabIndex = 10;
            // 
            // cmdselectback
            // 
            this.cmdselectback.Location = new System.Drawing.Point(268, 162);
            this.cmdselectback.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdselectback.Name = "cmdselectback";
            this.cmdselectback.Size = new System.Drawing.Size(112, 62);
            this.cmdselectback.TabIndex = 9;
            this.cmdselectback.Text = "Select";
            this.cmdselectback.UseVisualStyleBackColor = true;
            this.cmdselectback.Click += new System.EventHandler(this.cmdselectback_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelback);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmdselectfore);
            this.groupBox2.Controls.Add(this.panelfore);
            this.groupBox2.Controls.Add(this.cmdselectback);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(18, 19);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(472, 238);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Slice Color Selection";
            // 
            // grpDebug
            // 
            this.grpDebug.Controls.Add(this.chkIgnoreGCRsp);
            this.grpDebug.Controls.Add(this.chkDriverLog);
            this.grpDebug.Location = new System.Drawing.Point(500, 19);
            this.grpDebug.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDebug.Name = "grpDebug";
            this.grpDebug.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDebug.Size = new System.Drawing.Size(442, 238);
            this.grpDebug.TabIndex = 13;
            this.grpDebug.TabStop = false;
            this.grpDebug.Text = "Debugging";
            this.grpDebug.Visible = false;
            // 
            // chkIgnoreGCRsp
            // 
            this.chkIgnoreGCRsp.AutoSize = true;
            this.chkIgnoreGCRsp.Location = new System.Drawing.Point(10, 81);
            this.chkIgnoreGCRsp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkIgnoreGCRsp.Name = "chkIgnoreGCRsp";
            this.chkIgnoreGCRsp.Size = new System.Drawing.Size(291, 29);
            this.chkIgnoreGCRsp.TabIndex = 1;
            this.chkIgnoreGCRsp.Text = "Ignore GCode Responses";
            this.chkIgnoreGCRsp.UseVisualStyleBackColor = true;
            // 
            // chkDriverLog
            // 
            this.chkDriverLog.AutoSize = true;
            this.chkDriverLog.Location = new System.Drawing.Point(10, 38);
            this.chkDriverLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDriverLog.Name = "chkDriverLog";
            this.chkDriverLog.Size = new System.Drawing.Size(393, 29);
            this.chkDriverLog.TabIndex = 0;
            this.chkDriverLog.Text = "Log Driver Debugging To Comm Log";
            this.chkDriverLog.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCulters);
            this.groupBox1.Controls.Add(this.lblLanguage);
            this.groupBox1.Location = new System.Drawing.Point(18, 277);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(74, 110);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Language Setting";
            this.groupBox1.Visible = false;
            // 
            // cmbCulters
            // 
            this.cmbCulters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCulters.FormattingEnabled = true;
            this.cmbCulters.Location = new System.Drawing.Point(240, 37);
            this.cmbCulters.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmbCulters.Name = "cmbCulters";
            this.cmbCulters.Size = new System.Drawing.Size(302, 33);
            this.cmbCulters.TabIndex = 3;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(22, 44);
            this.lblLanguage.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(204, 25);
            this.lblLanguage.TabIndex = 2;
            this.lblLanguage.Text = "Software Language:";
            // 
            // frmPrefs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 365);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpDebug);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrefs";
            this.Text = "Program Preferences";
            this.Load += new System.EventHandler(this.frmPrefs_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpDebug.ResumeLayout(false);
            this.grpDebug.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button cmdselectfore;
        private System.Windows.Forms.Panel panelfore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button cmdselectback;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpDebug;
        private System.Windows.Forms.CheckBox chkIgnoreGCRsp;
        private System.Windows.Forms.CheckBox chkDriverLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCulters;
        private System.Windows.Forms.Label lblLanguage;
    }
}
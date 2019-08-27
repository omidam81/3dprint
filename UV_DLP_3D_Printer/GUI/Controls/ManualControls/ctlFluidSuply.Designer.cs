namespace UV_DLP_3D_Printer.GUI.Controls.ManualControls
{
    partial class ctlFluidSuply
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetPurgePressure = new System.Windows.Forms.Button();
            this.btnSetPurgeTime = new System.Windows.Forms.Button();
            this.btnPurgeCommand = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStopPurgeCommand = new System.Windows.Forms.Button();
            this.drpPurgeCommand = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSetPurgePressure = new System.Windows.Forms.NumericUpDown();
            this.txtSetPurgeTime = new System.Windows.Forms.NumericUpDown();
            this.ctlRFrame1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlRFrame();
            ((System.ComponentModel.ISupportInitialize)(this.txtSetPurgePressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSetPurgeTime)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(20, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(232, 20);
            this.lblTitle.TabIndex = 72;
            this.lblTitle.Text = "Fluid supply";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(20, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 78;
            this.label2.Text = "Set purge time :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(20, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 15);
            this.label1.TabIndex = 76;
            this.label1.Text = "Set purge pressure :";
            // 
            // btnSetPurgePressure
            // 
            this.btnSetPurgePressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSetPurgePressure.Location = new System.Drawing.Point(226, 38);
            this.btnSetPurgePressure.Name = "btnSetPurgePressure";
            this.btnSetPurgePressure.Size = new System.Drawing.Size(37, 23);
            this.btnSetPurgePressure.TabIndex = 83;
            this.btnSetPurgePressure.Text = "OK";
            this.btnSetPurgePressure.UseVisualStyleBackColor = true;
            this.btnSetPurgePressure.Click += new System.EventHandler(this.btnSetPurgePressure_Click);
            // 
            // btnSetPurgeTime
            // 
            this.btnSetPurgeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSetPurgeTime.Location = new System.Drawing.Point(226, 64);
            this.btnSetPurgeTime.Name = "btnSetPurgeTime";
            this.btnSetPurgeTime.Size = new System.Drawing.Size(37, 23);
            this.btnSetPurgeTime.TabIndex = 84;
            this.btnSetPurgeTime.Text = "OK";
            this.btnSetPurgeTime.UseVisualStyleBackColor = true;
            this.btnSetPurgeTime.Click += new System.EventHandler(this.btnSetPurgeTime_Click);
            // 
            // btnPurgeCommand
            // 
            this.btnPurgeCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnPurgeCommand.Location = new System.Drawing.Point(226, 90);
            this.btnPurgeCommand.Name = "btnPurgeCommand";
            this.btnPurgeCommand.Size = new System.Drawing.Size(37, 23);
            this.btnPurgeCommand.TabIndex = 87;
            this.btnPurgeCommand.Text = "OK";
            this.btnPurgeCommand.UseVisualStyleBackColor = true;
            this.btnPurgeCommand.Click += new System.EventHandler(this.btnPurgeCommand_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(20, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 15);
            this.label3.TabIndex = 85;
            this.label3.Text = "PurgeCommand :";
            // 
            // btnStopPurgeCommand
            // 
            this.btnStopPurgeCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnStopPurgeCommand.Location = new System.Drawing.Point(19, 158);
            this.btnStopPurgeCommand.Name = "btnStopPurgeCommand";
            this.btnStopPurgeCommand.Size = new System.Drawing.Size(244, 23);
            this.btnStopPurgeCommand.TabIndex = 88;
            this.btnStopPurgeCommand.Text = "Stop Purge Command";
            this.btnStopPurgeCommand.UseVisualStyleBackColor = true;
            this.btnStopPurgeCommand.Click += new System.EventHandler(this.btnStopPurgeCommand_Click);
            // 
            // drpPurgeCommand
            // 
            this.drpPurgeCommand.FormattingEnabled = true;
            this.drpPurgeCommand.Items.AddRange(new object[] {
            "Soft",
            "Hard ",
            "Deairing"});
            this.drpPurgeCommand.Location = new System.Drawing.Point(139, 92);
            this.drpPurgeCommand.Name = "drpPurgeCommand";
            this.drpPurgeCommand.Size = new System.Drawing.Size(81, 21);
            this.drpPurgeCommand.TabIndex = 89;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(19, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 23);
            this.button1.TabIndex = 90;
            this.button1.Text = "Purge";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button2.Location = new System.Drawing.Point(19, 193);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(244, 23);
            this.button2.TabIndex = 91;
            this.button2.Text = "Drain System";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtSetPurgePressure
            // 
            this.txtSetPurgePressure.Location = new System.Drawing.Point(139, 41);
            this.txtSetPurgePressure.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.txtSetPurgePressure.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtSetPurgePressure.Name = "txtSetPurgePressure";
            this.txtSetPurgePressure.Size = new System.Drawing.Size(79, 20);
            this.txtSetPurgePressure.TabIndex = 102;
            this.txtSetPurgePressure.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // txtSetPurgeTime
            // 
            this.txtSetPurgeTime.Location = new System.Drawing.Point(139, 67);
            this.txtSetPurgeTime.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.txtSetPurgeTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSetPurgeTime.Name = "txtSetPurgeTime";
            this.txtSetPurgeTime.Size = new System.Drawing.Size(79, 20);
            this.txtSetPurgeTime.TabIndex = 102;
            this.txtSetPurgeTime.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // ctlRFrame1
            // 
            this.ctlRFrame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ctlRFrame1.Location = new System.Drawing.Point(3, 3);
            this.ctlRFrame1.Name = "ctlRFrame1";
            this.ctlRFrame1.Size = new System.Drawing.Size(271, 224);
            this.ctlRFrame1.TabIndex = 82;
            // 
            // ctlFluidSuply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.txtSetPurgeTime);
            this.Controls.Add(this.txtSetPurgePressure);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.drpPurgeCommand);
            this.Controls.Add(this.btnStopPurgeCommand);
            this.Controls.Add(this.btnPurgeCommand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSetPurgeTime);
            this.Controls.Add(this.btnSetPurgePressure);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctlRFrame1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ctlFluidSuply";
            this.Size = new System.Drawing.Size(277, 235);
            ((System.ComponentModel.ISupportInitialize)(this.txtSetPurgePressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSetPurgeTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CustomGUI.ctlRFrame ctlRFrame1;
        private System.Windows.Forms.Button btnSetPurgePressure;
        private System.Windows.Forms.Button btnSetPurgeTime;
        private System.Windows.Forms.Button btnPurgeCommand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStopPurgeCommand;
        private System.Windows.Forms.ComboBox drpPurgeCommand;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown txtSetPurgePressure;
        private System.Windows.Forms.NumericUpDown txtSetPurgeTime;
    }
}

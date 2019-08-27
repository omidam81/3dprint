namespace UV_DLP_3D_Printer.GUI.Controls.ManualControls
{
    partial class ctlCheckPowder
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
            this.btnCleanPrintHead = new System.Windows.Forms.Button();
            this.btnCapping = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ctlRFrame1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlRFrame();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(22, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTitle.Size = new System.Drawing.Size(176, 20);
            this.lblTitle.TabIndex = 72;
            this.lblTitle.Text = "Check level";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCleanPrintHead
            // 
            this.btnCleanPrintHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCleanPrintHead.Location = new System.Drawing.Point(22, 36);
            this.btnCleanPrintHead.Name = "btnCleanPrintHead";
            this.btnCleanPrintHead.Size = new System.Drawing.Size(233, 23);
            this.btnCleanPrintHead.TabIndex = 88;
            this.btnCleanPrintHead.Text = "Feeding Box";
            this.btnCleanPrintHead.UseVisualStyleBackColor = true;
            this.btnCleanPrintHead.Click += new System.EventHandler(this.btnCleanPrintHead_Click);
            // 
            // btnCapping
            // 
            this.btnCapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCapping.Location = new System.Drawing.Point(22, 70);
            this.btnCapping.Name = "btnCapping";
            this.btnCapping.Size = new System.Drawing.Size(233, 23);
            this.btnCapping.TabIndex = 89;
            this.btnCapping.Text = "Printing Box";
            this.btnCapping.UseVisualStyleBackColor = true;
            this.btnCapping.Click += new System.EventHandler(this.btnCapping_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(22, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 23);
            this.button1.TabIndex = 90;
            this.button1.Text = "Fluid";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctlRFrame1
            // 
            this.ctlRFrame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ctlRFrame1.Location = new System.Drawing.Point(3, 3);
            this.ctlRFrame1.Name = "ctlRFrame1";
            this.ctlRFrame1.Size = new System.Drawing.Size(271, 153);
            this.ctlRFrame1.TabIndex = 82;
            // 
            // ctlCheckPowder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCapping);
            this.Controls.Add(this.btnCleanPrintHead);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctlRFrame1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ctlCheckPowder";
            this.Size = new System.Drawing.Size(281, 179);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private CustomGUI.ctlRFrame ctlRFrame1;
        private System.Windows.Forms.Button btnCleanPrintHead;
        private System.Windows.Forms.Button btnCapping;
        private System.Windows.Forms.Button button1;
    }
}

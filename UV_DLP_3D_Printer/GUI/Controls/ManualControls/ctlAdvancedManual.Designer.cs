namespace UV_DLP_3D_Printer.GUI.Controls.ManualControls
{
    partial class ctlAdvancedManual
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctlMoveX = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ctlMoveY = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.ctlXspeed = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.ctlYspeed = new System.Windows.Forms.NumericUpDown();
            this.btnZspeed = new System.Windows.Forms.Button();
            this.ctlZspeed = new System.Windows.Forms.NumericUpDown();
            this.btnYspeed = new System.Windows.Forms.Button();
            this.btnXspeed = new System.Windows.Forms.Button();
            this.btnMoveYaxis = new System.Windows.Forms.Button();
            this.btnMoveXaxis = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtMovePrinting = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMoveFeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSpread = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numAmountLayers = new System.Windows.Forms.NumericUpDown();
            this.btnMoveFeed = new System.Windows.Forms.Button();
            this.btnMovePrinting = new System.Windows.Forms.Button();
            this.ctlRFrame1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlRFrame();
            this.label10 = new System.Windows.Forms.Label();
            this.ctlRFrame2 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlRFrame();
            this.ok = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numSpreadSpeed = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ctlMoveX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlMoveY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlXspeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlYspeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlZspeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmountLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpreadSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(16, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 94;
            this.label3.Text = "Move X-axis :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(16, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 97;
            this.label4.Text = "Move Y-axis :";
            // 
            // ctlMoveX
            // 
            this.ctlMoveX.Location = new System.Drawing.Point(126, 35);
            this.ctlMoveX.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.ctlMoveX.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ctlMoveX.Name = "ctlMoveX";
            this.ctlMoveX.Size = new System.Drawing.Size(98, 20);
            this.ctlMoveX.TabIndex = 96;
            this.ctlMoveX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(16, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 100;
            this.label6.Text = "X speed :";
            // 
            // ctlMoveY
            // 
            this.ctlMoveY.Location = new System.Drawing.Point(126, 71);
            this.ctlMoveY.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.ctlMoveY.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ctlMoveY.Name = "ctlMoveY";
            this.ctlMoveY.Size = new System.Drawing.Size(98, 20);
            this.ctlMoveY.TabIndex = 99;
            this.ctlMoveY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(16, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.TabIndex = 103;
            this.label7.Text = "Y speed :";
            // 
            // ctlXspeed
            // 
            this.ctlXspeed.Location = new System.Drawing.Point(126, 107);
            this.ctlXspeed.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.ctlXspeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ctlXspeed.Name = "ctlXspeed";
            this.ctlXspeed.Size = new System.Drawing.Size(98, 20);
            this.ctlXspeed.TabIndex = 102;
            this.ctlXspeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.Location = new System.Drawing.Point(16, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 106;
            this.label8.Text = "Z speed :";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // ctlYspeed
            // 
            this.ctlYspeed.Location = new System.Drawing.Point(126, 143);
            this.ctlYspeed.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.ctlYspeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ctlYspeed.Name = "ctlYspeed";
            this.ctlYspeed.Size = new System.Drawing.Size(98, 20);
            this.ctlYspeed.TabIndex = 105;
            this.ctlYspeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnZspeed
            // 
            this.btnZspeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnZspeed.Location = new System.Drawing.Point(238, 175);
            this.btnZspeed.Name = "btnZspeed";
            this.btnZspeed.Size = new System.Drawing.Size(41, 23);
            this.btnZspeed.TabIndex = 82;
            this.btnZspeed.Text = "OK";
            this.btnZspeed.UseVisualStyleBackColor = true;
            this.btnZspeed.Click += new System.EventHandler(this.btnZspeed_Click);
            // 
            // ctlZspeed
            // 
            this.ctlZspeed.Location = new System.Drawing.Point(126, 179);
            this.ctlZspeed.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ctlZspeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ctlZspeed.Name = "ctlZspeed";
            this.ctlZspeed.Size = new System.Drawing.Size(98, 20);
            this.ctlZspeed.TabIndex = 108;
            this.ctlZspeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnYspeed
            // 
            this.btnYspeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnYspeed.Location = new System.Drawing.Point(238, 139);
            this.btnYspeed.Name = "btnYspeed";
            this.btnYspeed.Size = new System.Drawing.Size(41, 23);
            this.btnYspeed.TabIndex = 80;
            this.btnYspeed.Text = "OK";
            this.btnYspeed.UseVisualStyleBackColor = true;
            this.btnYspeed.Click += new System.EventHandler(this.btnYspeed_Click);
            // 
            // btnXspeed
            // 
            this.btnXspeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnXspeed.Location = new System.Drawing.Point(238, 103);
            this.btnXspeed.Name = "btnXspeed";
            this.btnXspeed.Size = new System.Drawing.Size(41, 23);
            this.btnXspeed.TabIndex = 79;
            this.btnXspeed.Text = "OK";
            this.btnXspeed.UseVisualStyleBackColor = true;
            this.btnXspeed.Click += new System.EventHandler(this.btnXspeed_Click);
            // 
            // btnMoveYaxis
            // 
            this.btnMoveYaxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnMoveYaxis.Location = new System.Drawing.Point(238, 68);
            this.btnMoveYaxis.Name = "btnMoveYaxis";
            this.btnMoveYaxis.Size = new System.Drawing.Size(41, 23);
            this.btnMoveYaxis.TabIndex = 76;
            this.btnMoveYaxis.Text = "OK";
            this.btnMoveYaxis.UseVisualStyleBackColor = true;
            this.btnMoveYaxis.Click += new System.EventHandler(this.btnMoveYaxis_Click);
            // 
            // btnMoveXaxis
            // 
            this.btnMoveXaxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnMoveXaxis.Location = new System.Drawing.Point(238, 32);
            this.btnMoveXaxis.Name = "btnMoveXaxis";
            this.btnMoveXaxis.Size = new System.Drawing.Size(41, 23);
            this.btnMoveXaxis.TabIndex = 75;
            this.btnMoveXaxis.Text = "OK";
            this.btnMoveXaxis.UseVisualStyleBackColor = true;
            this.btnMoveXaxis.Click += new System.EventHandler(this.btnMoveXaxis_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(16, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(257, 20);
            this.lblTitle.TabIndex = 72;
            this.lblTitle.Text = "Move Printer";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // txtMovePrinting
            // 
            this.txtMovePrinting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMovePrinting.Location = new System.Drawing.Point(126, 251);
            this.txtMovePrinting.Name = "txtMovePrinting";
            this.txtMovePrinting.Size = new System.Drawing.Size(100, 21);
            this.txtMovePrinting.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(16, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 78;
            this.label2.Text = "Move printing";
            // 
            // txtMoveFeed
            // 
            this.txtMoveFeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMoveFeed.Location = new System.Drawing.Point(126, 220);
            this.txtMoveFeed.Name = "txtMoveFeed";
            this.txtMoveFeed.Size = new System.Drawing.Size(100, 21);
            this.txtMoveFeed.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(16, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 76;
            this.label1.Text = "Move feed";
            // 
            // btnSpread
            // 
            this.btnSpread.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSpread.Location = new System.Drawing.Point(224, 345);
            this.btnSpread.Name = "btnSpread";
            this.btnSpread.Size = new System.Drawing.Size(59, 23);
            this.btnSpread.TabIndex = 2;
            this.btnSpread.Text = "Spread";
            this.btnSpread.UseVisualStyleBackColor = true;
            this.btnSpread.Click += new System.EventHandler(this.btnSpread_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(20, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Amount of layers";
            // 
            // numAmountLayers
            // 
            this.numAmountLayers.Location = new System.Drawing.Point(130, 348);
            this.numAmountLayers.Name = "numAmountLayers";
            this.numAmountLayers.Size = new System.Drawing.Size(82, 20);
            this.numAmountLayers.TabIndex = 87;
            // 
            // btnMoveFeed
            // 
            this.btnMoveFeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnMoveFeed.Location = new System.Drawing.Point(238, 218);
            this.btnMoveFeed.Name = "btnMoveFeed";
            this.btnMoveFeed.Size = new System.Drawing.Size(41, 23);
            this.btnMoveFeed.TabIndex = 83;
            this.btnMoveFeed.Text = "OK";
            this.btnMoveFeed.UseVisualStyleBackColor = true;
            this.btnMoveFeed.Click += new System.EventHandler(this.btnMoveFeed_Click);
            // 
            // btnMovePrinting
            // 
            this.btnMovePrinting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnMovePrinting.Location = new System.Drawing.Point(238, 252);
            this.btnMovePrinting.Name = "btnMovePrinting";
            this.btnMovePrinting.Size = new System.Drawing.Size(41, 23);
            this.btnMovePrinting.TabIndex = 84;
            this.btnMovePrinting.Text = "OK";
            this.btnMovePrinting.UseVisualStyleBackColor = true;
            this.btnMovePrinting.Click += new System.EventHandler(this.btnMovePrinting_Click);
            // 
            // ctlRFrame1
            // 
            this.ctlRFrame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ctlRFrame1.Location = new System.Drawing.Point(3, 3);
            this.ctlRFrame1.Name = "ctlRFrame1";
            this.ctlRFrame1.Size = new System.Drawing.Size(297, 288);
            this.ctlRFrame1.TabIndex = 82;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(16, 313);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(257, 20);
            this.label10.TabIndex = 109;
            this.label10.Text = "Spread powder";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctlRFrame2
            // 
            this.ctlRFrame2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ctlRFrame2.Location = new System.Drawing.Point(3, 307);
            this.ctlRFrame2.Name = "ctlRFrame2";
            this.ctlRFrame2.Size = new System.Drawing.Size(297, 126);
            this.ctlRFrame2.TabIndex = 110;
            // 
            // ok
            // 
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ok.Location = new System.Drawing.Point(224, 384);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(59, 23);
            this.ok.TabIndex = 112;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.Location = new System.Drawing.Point(20, 388);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 15);
            this.label9.TabIndex = 111;
            this.label9.Text = "Spread speed";
            // 
            // numSpreadSpeed
            // 
            this.numSpreadSpeed.Location = new System.Drawing.Point(130, 388);
            this.numSpreadSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSpreadSpeed.Name = "numSpreadSpeed";
            this.numSpreadSpeed.Size = new System.Drawing.Size(82, 20);
            this.numSpreadSpeed.TabIndex = 113;
            this.numSpreadSpeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ctlAdvancedManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.ok);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numSpreadSpeed);
            this.Controls.Add(this.btnSpread);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numAmountLayers);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ctlRFrame2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ctlMoveX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ctlMoveY);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ctlXspeed);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ctlYspeed);
            this.Controls.Add(this.btnZspeed);
            this.Controls.Add(this.ctlZspeed);
            this.Controls.Add(this.btnYspeed);
            this.Controls.Add(this.btnMoveXaxis);
            this.Controls.Add(this.btnMoveYaxis);
            this.Controls.Add(this.btnXspeed);
            this.Controls.Add(this.btnMovePrinting);
            this.Controls.Add(this.btnMoveFeed);
            this.Controls.Add(this.txtMovePrinting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMoveFeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctlRFrame1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ctlAdvancedManual";
            this.Size = new System.Drawing.Size(306, 473);
            ((System.ComponentModel.ISupportInitialize)(this.ctlMoveX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlMoveY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlXspeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlYspeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlZspeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmountLayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpreadSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtMovePrinting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMoveFeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSpread;
        private System.Windows.Forms.Label label5;
        private CustomGUI.ctlRFrame ctlRFrame1;
        private System.Windows.Forms.Button btnMoveYaxis;
        private System.Windows.Forms.Button btnMoveXaxis;
        private System.Windows.Forms.Button btnMoveFeed;
        private System.Windows.Forms.Button btnMovePrinting;
        private System.Windows.Forms.Button btnZspeed;
        private System.Windows.Forms.Button btnYspeed;
        private System.Windows.Forms.Button btnXspeed;
        private System.Windows.Forms.NumericUpDown numAmountLayers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ctlMoveX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ctlMoveY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown ctlXspeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown ctlYspeed;
        private System.Windows.Forms.NumericUpDown ctlZspeed;
        private System.Windows.Forms.Label label10;
        private CustomGUI.ctlRFrame ctlRFrame2;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numSpreadSpeed;
    }
}

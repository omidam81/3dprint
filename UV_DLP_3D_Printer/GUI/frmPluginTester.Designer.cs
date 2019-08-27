namespace UV_DLP_3D_Printer.GUI
{
    partial class frmPluginTester
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
            this.lvplugins = new System.Windows.Forms.ListView();
            this.lvcontents = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvplugins
            // 
            this.lvplugins.Location = new System.Drawing.Point(20, 27);
            this.lvplugins.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvplugins.MultiSelect = false;
            this.lvplugins.Name = "lvplugins";
            this.lvplugins.Size = new System.Drawing.Size(228, 81);
            this.lvplugins.TabIndex = 0;
            this.lvplugins.UseCompatibleStateImageBehavior = false;
            this.lvplugins.View = System.Windows.Forms.View.List;
            this.lvplugins.SelectedIndexChanged += new System.EventHandler(this.lvplugins_SelectedIndexChanged);
            // 
            // lvcontents
            // 
            this.lvcontents.Location = new System.Drawing.Point(20, 130);
            this.lvcontents.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvcontents.MultiSelect = false;
            this.lvcontents.Name = "lvcontents";
            this.lvcontents.Size = new System.Drawing.Size(228, 149);
            this.lvcontents.TabIndex = 1;
            this.lvcontents.UseCompatibleStateImageBehavior = false;
            this.lvcontents.View = System.Windows.Forms.View.List;
            this.lvcontents.SelectedIndexChanged += new System.EventHandler(this.lvcontents_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "PlugIn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Plugin Contents";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(292, 27);
            this.lblData.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(16, 13);
            this.lblData.TabIndex = 4;
            this.lblData.Text = "...";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(286, 166);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 126);
            this.panel1.TabIndex = 6;
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(286, 58);
            this.pic1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(84, 92);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 5;
            this.pic1.TabStop = false;
            // 
            // frmPluginTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 301);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvcontents);
            this.Controls.Add(this.lvplugins);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmPluginTester";
            this.Text = "PlugIn Tester";
            this.Load += new System.EventHandler(this.frmPluginTester_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvplugins;
        private System.Windows.Forms.ListView lvcontents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Panel panel1;
    }
}
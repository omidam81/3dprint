﻿namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    partial class sMiiCtrl
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
            this.lbMiiCommands = new System.Windows.Forms.ListBox();
            this.cmdSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMiiCommands
            // 
            this.lbMiiCommands.FormattingEnabled = true;
            this.lbMiiCommands.Location = new System.Drawing.Point(3, 3);
            this.lbMiiCommands.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbMiiCommands.Name = "lbMiiCommands";
            this.lbMiiCommands.Size = new System.Drawing.Size(274, 160);
            this.lbMiiCommands.TabIndex = 0;
            // 
            // cmdSend
            // 
            this.cmdSend.Location = new System.Drawing.Point(78, 167);
            this.cmdSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(110, 29);
            this.cmdSend.TabIndex = 1;
            this.cmdSend.Text = "Send Command";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // sMiiCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdSend);
            this.Controls.Add(this.lbMiiCommands);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "sMiiCtrl";
            this.Size = new System.Drawing.Size(285, 207);
            this.Load += new System.EventHandler(this.sMiiCtrl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbMiiCommands;
        private System.Windows.Forms.Button cmdSend;
    }
}

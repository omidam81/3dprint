namespace UV_DLP_3D_Printer.GUI.CustomGUI
{
    partial class ctlScene
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuObject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdRemoveObject = new System.Windows.Forms.ToolStripMenuItem();
            this.manipObject = new System.Windows.Forms.FlowLayoutPanel();
            this.ctlTitle1 = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlTitle();
            this.treeScene = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdDelete = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageEx();
            this.cmdCopy = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageEx();
            this.cmdNewScene = new UV_DLP_3D_Printer.GUI.CustomGUI.ctlImageEx();
            this.contextMenuObject.SuspendLayout();
            this.manipObject.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdNewScene)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuObject
            // 
            this.contextMenuObject.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuObject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdRemoveObject});
            this.contextMenuObject.Name = "contextMenuStrip1";
            this.contextMenuObject.Size = new System.Drawing.Size(156, 26);
            // 
            // cmdRemoveObject
            // 
            this.cmdRemoveObject.Name = "cmdRemoveObject";
            this.cmdRemoveObject.Size = new System.Drawing.Size(155, 22);
            this.cmdRemoveObject.Text = "Remove Object";
            this.cmdRemoveObject.Click += new System.EventHandler(this.cmdRemoveObject_Click);
            // 
            // manipObject
            // 
            this.manipObject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.manipObject.Controls.Add(this.ctlTitle1);
            this.manipObject.Controls.Add(this.treeScene);
            this.manipObject.Controls.Add(this.panel1);
            this.manipObject.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.manipObject.Location = new System.Drawing.Point(0, 0);
            this.manipObject.Name = "manipObject";
            this.manipObject.Size = new System.Drawing.Size(252, 342);
            this.manipObject.TabIndex = 21;
            // 
            // ctlTitle1
            // 
            this.ctlTitle1.BackColor = System.Drawing.Color.Transparent;
            this.ctlTitle1.Checked = false;
            this.ctlTitle1.CheckImage = global::UV_DLP_3D_Printer.Properties.Resource_s.buttStateTrig;
            this.ctlTitle1.Gapx = 0;
            this.ctlTitle1.Gapy = 0;
            this.ctlTitle1.GLBackgroundImage = null;
            this.ctlTitle1.GLImage = null;
            this.ctlTitle1.GLVisible = false;
            this.ctlTitle1.GuiAnchor = null;
            this.ctlTitle1.HorizontalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.ctlTitle1.Image = global::UV_DLP_3D_Printer.Properties.Resource_s.buttTreeview;
            this.ctlTitle1.Location = new System.Drawing.Point(3, 3);
            this.ctlTitle1.Name = "ctlTitle1";
            this.ctlTitle1.Size = new System.Drawing.Size(243, 45);
            this.ctlTitle1.StyleName = null;
            this.ctlTitle1.TabIndex = 2;
            this.ctlTitle1.Text = "Scene";
            this.ctlTitle1.VerticalAnchor = UV_DLP_3D_Printer.GUI.CustomGUI.ctlAnchorable.AnchorTypes.None;
            this.ctlTitle1.Click += new System.EventHandler(this.ctlTitle1_Click);
            // 
            // treeScene
            // 
            this.treeScene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeScene.BackColor = System.Drawing.Color.RoyalBlue;
            this.treeScene.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeScene.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeScene.ForeColor = System.Drawing.Color.Black;
            this.treeScene.Location = new System.Drawing.Point(3, 54);
            this.treeScene.Name = "treeScene";
            this.treeScene.Size = new System.Drawing.Size(243, 240);
            this.treeScene.TabIndex = 1;
            this.treeScene.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeScene_NodeMouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdDelete);
            this.panel1.Controls.Add(this.cmdCopy);
            this.panel1.Controls.Add(this.cmdNewScene);
            this.panel1.Location = new System.Drawing.Point(3, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 38);
            this.panel1.TabIndex = 4;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.Color.Transparent;
            this.cmdDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdDelete.HoverImage = global::UV_DLP_3D_Printer.Properties.Resources.butMinusH;
            this.cmdDelete.Image = global::UV_DLP_3D_Printer.Properties.Resource_s.butMinus;
            this.cmdDelete.IsToggle = false;
            this.cmdDelete.Location = new System.Drawing.Point(49, 4);
            this.cmdDelete.MainImage = global::UV_DLP_3D_Printer.Properties.Resource_s.butMinus;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.OnClickCallback = null;
            this.cmdDelete.Size = new System.Drawing.Size(32, 32);
            this.cmdDelete.TabIndex = 66;
            this.cmdDelete.TabStop = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdCopy
            // 
            this.cmdCopy.BackColor = System.Drawing.Color.Transparent;
            this.cmdCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCopy.HoverImage = global::UV_DLP_3D_Printer.Properties.Resources.buttPlusH;
            this.cmdCopy.Image = global::UV_DLP_3D_Printer.Properties.Resource_s.buttPlus;
            this.cmdCopy.IsToggle = false;
            this.cmdCopy.Location = new System.Drawing.Point(3, 4);
            this.cmdCopy.MainImage = global::UV_DLP_3D_Printer.Properties.Resource_s.buttPlus;
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.OnClickCallback = null;
            this.cmdCopy.Size = new System.Drawing.Size(32, 32);
            this.cmdCopy.TabIndex = 65;
            this.cmdCopy.TabStop = false;
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
            // 
            // cmdNewScene
            // 
            this.cmdNewScene.BackColor = System.Drawing.Color.Transparent;
            this.cmdNewScene.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdNewScene.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdNewScene.HoverImage = global::UV_DLP_3D_Printer.Properties.Resources.buttXH;
            this.cmdNewScene.Image = global::UV_DLP_3D_Printer.Properties.Resource_s.buttX;
            this.cmdNewScene.IsToggle = false;
            this.cmdNewScene.Location = new System.Drawing.Point(203, 4);
            this.cmdNewScene.MainImage = global::UV_DLP_3D_Printer.Properties.Resource_s.buttX;
            this.cmdNewScene.Name = "cmdNewScene";
            this.cmdNewScene.OnClickCallback = null;
            this.cmdNewScene.Size = new System.Drawing.Size(32, 32);
            this.cmdNewScene.TabIndex = 67;
            this.cmdNewScene.TabStop = false;
            this.cmdNewScene.Click += new System.EventHandler(this.cmdNewScene_Click);
            // 
            // ctlScene
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.manipObject);
            this.Name = "ctlScene";
            this.Size = new System.Drawing.Size(260, 348);
            this.StyleName = "";
            this.Resize += new System.EventHandler(this.ctlScene_Resize);
            this.contextMenuObject.ResumeLayout(false);
            this.manipObject.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdNewScene)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel manipObject;
        private System.Windows.Forms.TreeView treeScene;
        private System.Windows.Forms.ContextMenuStrip contextMenuObject;
        private System.Windows.Forms.ToolStripMenuItem cmdRemoveObject;
        private ctlTitle ctlTitle1;
        private ctlImageEx cmdCopy;
        private ctlImageEx cmdDelete;
        private ctlImageEx cmdNewScene;
        private System.Windows.Forms.Panel panel1;

    }
}

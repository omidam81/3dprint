using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI.Controls.ManualControls
{
    public partial class ctlFluidSuply : UserControl
    {
       class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        List<Item> list;
        public ctlFluidSuply()
        {
            InitializeComponent();
            list = new List<Item>();
            list.Add(new Item { Id = 1, Name = "Soft Purge" });
            list.Add(new Item { Id = 2, Name = "Hard Purge" });
            list.Add(new Item { Id = 4, Name = "De-airing Purge" });
            drpPurgeCommand.DataSource = list.ToList();
            drpPurgeCommand.DisplayMember = "name";
            drpPurgeCommand.ValueMember = "Id";
        }

        

        private void btnMoveFeed_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction
               .PLC.StepZ1(Convert.ToInt32(txtSetPurgePressure));
        }

        private void btnMovePrinting_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.PLCFunction
               .PLC.StepZ2((int)txtSetPurgePressure.Value);
        }

        private void btnSetPurgePressure_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.Fluid
               .setPurgePressure(Convert.ToInt32(txtSetPurgePressure));
        }

        private void btnSetPurgeTime_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.Fluid
              .setPurgeTime(Convert.ToInt32(txtSetPurgeTime));
        }

        private void btnPurgeCommand_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.Fluid
              .PurgeCommand(Convert.ToInt32(drpPurgeCommand.SelectedValue));
        }

        private void btnStopPurgeCommand_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().IntegrationFunction.Fluid
              .PurgeCommand(3);
        }
    }
}

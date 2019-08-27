using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            //label1.Parent = pictureBox1;
            //label1.BackColor = Color.Transparent;
            //label2.Parent = pictureBox1;
            //label2.BackColor = Color.Transparent;
            //label3.Parent = pictureBox1;
            //label3.BackColor = Color.Transparent;
            //label4.Parent = pictureBox1;
            //label4.BackColor = Color.Transparent;
            //version.Parent = pictureBox1;
            //version.BackColor = Color.Transparent;
            //version.Text = ((DesignMode) ? "Version" :UVDLPApp.Instance().resman.GetString("Version", UVDLPApp.Instance().cul)) + Application.ProductVersion;
            LoadAbout();
            SetTexts();

        }

        private void SetTexts()
        {
            //this.label2.Text = ((DesignMode) ? "FreeForNonCommercialUse" : UVDLPApp.Instance().resman.GetString("FreeForNonCommercialUse", UVDLPApp.Instance().cul));
            ////this.label1.Text = ((DesignMode) ? "CreationWorkshop" : UVDLPApp.Instance().resman.GetString("CreationWorkshop", UVDLPApp.Instance().cul));
            //this.label3.Text = ((DesignMode) ? "SteveHernandezAkaPacManFan" : UVDLPApp.Instance().resman.GetString("SteveHernandezAkaPacManFan", UVDLPApp.Instance().cul));
            //this.label4.Text = ((DesignMode) ? "ShaiSegar" : UVDLPApp.Instance().resman.GetString("ShaiSegar", UVDLPApp.Instance().cul));
            //this.Text = ((DesignMode) ? "About" : UVDLPApp.Instance().resman.GetString("About", UVDLPApp.Instance().cul));
        }

        private void LoadAbout() 
        {
            Bitmap bmp = UVDLPApp.Instance().GetPluginImage("About");
             if (bmp != null)
             {
                 //label1.Hide();
                 //label2.Hide();
                 //label3.Hide();
                 //label4.Hide();
                 //version.Hide();
                 //cmdDonate.Hide();
                 pictureBox1.Image = bmp;
             }
        }
        private void cmdDonate_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "";

                string business = "pacmanfan321@gmail.com";  // your paypal email
                string description = ((DesignMode) ? "Donation" :UVDLPApp.Instance().resman.GetString("Donation", UVDLPApp.Instance().cul));            // '%20' represents a space. remember HTML!
                string country = "US";                  // AU, US, etc.
                string currency = "USD";                 // AUD, USD, etc.

                url += "https://www.paypal.com/cgi-bin/webscr" +
                    "?cmd=" + "_donations" +
                    "&business=" + business +
                    ((DesignMode) ? "Lc" :UVDLPApp.Instance().resman.GetString("Lc", UVDLPApp.Instance().cul)) + country +
                    ((DesignMode) ? "Item_name" :UVDLPApp.Instance().resman.GetString("Item_name", UVDLPApp.Instance().cul)) + description +
                    ((DesignMode) ? "Currency_code" :UVDLPApp.Instance().resman.GetString("Currency_code", UVDLPApp.Instance().cul)) + currency +
                    ((DesignMode) ? "BnPP2dDonationsBF" :UVDLPApp.Instance().resman.GetString("BnPP2dDonationsBF", UVDLPApp.Instance().cul));

                System.Diagnostics.Process.Start(url);
                //System.Diagnostics.Process.Start(target);
            }
            catch(Exception ex)
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}

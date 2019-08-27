using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using UV_DLP_3D_Printer.GUI.CustomGUI;
using UV_DLP_3D_Printer.Configs;
using UV_DLP_3D_Printer._3DEngine;

namespace UV_DLP_3D_Printer.GUI.Controls
{
    public partial class ctlToolpathGenConfig : UserControl //ctlUserPanel// 
    {
        System.Windows.Forms.TabPage m_gcodetab;
        public ctlToolpathGenConfig()
        {
            try
            {
                InitializeComponent();            
                m_gcodetab = tabOptions.TabPages["tbGCode"];
                PopulateProfiles();
               // lbGCodeSection.SelectedIndex = 0;
            }catch(Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }
            SetTexts();
        }

        private void SetTexts()
        {
            this.tabOptions.Font = new System.Drawing.Font(((DesignMode) ? "MicrosoftSansSerif" : UVDLPApp.Instance().resman.GetString("MicrosoftSansSerif", UVDLPApp.Instance().cul)), 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOptions.Text = ((DesignMode) ? "Options" : UVDLPApp.Instance().resman.GetString("Options", UVDLPApp.Instance().cul));
            //this.grpProfile.Text = ((DesignMode) ? "MachineProfile" : UVDLPApp.Instance().resman.GetString("MachineProfile", UVDLPApp.Instance().cul));
            this.label15.Text = ((DesignMode) ? "Notes" : UVDLPApp.Instance().resman.GetString("Notes", UVDLPApp.Instance().cul));
            this.cmdHelp.Text = ((DesignMode) ? "Help" : UVDLPApp.Instance().resman.GetString("Help", UVDLPApp.Instance().cul));
            //this.grpExport.Text = ((DesignMode) ? "ExportOptions" : UVDLPApp.Instance().resman.GetString("ExportOptions", UVDLPApp.Instance().cul));
            this.labelExportPreview.Text = ((DesignMode) ? "ExportPreview" : UVDLPApp.Instance().resman.GetString("ExportPreview", UVDLPApp.Instance().cul));
            this.chkExport.Text = ((DesignMode) ? "ExportToCWS" : UVDLPApp.Instance().resman.GetString("ExportToCWS", UVDLPApp.Instance().cul));
            this.chkExportPNG.Text = ((DesignMode) ? "ExportToDisk" : UVDLPApp.Instance().resman.GetString("ExportToDisk", UVDLPApp.Instance().cul));
            this.comboExportSvg.Items.AddRange(new object[] {
            ((DesignMode) ? "None" :UVDLPApp.Instance().resman.GetString("None", UVDLPApp.Instance().cul)),
            ((DesignMode) ? "CompoundPath" :UVDLPApp.Instance().resman.GetString("CompoundPath", UVDLPApp.Instance().cul)),
            ((DesignMode) ? "FilledPolygons" :UVDLPApp.Instance().resman.GetString("FilledPolygons", UVDLPApp.Instance().cul)),
            ((DesignMode) ? "CompoundPathOld" :UVDLPApp.Instance().resman.GetString("CompoundPathOld", UVDLPApp.Instance().cul)),
            ((DesignMode) ? "FilledPolygonsOld" :UVDLPApp.Instance().resman.GetString("FilledPolygonsOld", UVDLPApp.Instance().cul))}); this.labelExportSvg.Text = ((DesignMode) ? "ExportSVG" : UVDLPApp.Instance().resman.GetString("ExportSVG", UVDLPApp.Instance().cul));
            //this.groupBox5.Text = ((DesignMode) ? "Settings" : UVDLPApp.Instance().resman.GetString("Settings", UVDLPApp.Instance().cul));
            this.label21.Text = ((DesignMode) ? "OutlineWidthOutsetPix" : UVDLPApp.Instance().resman.GetString("OutlineWidthOutsetPix", UVDLPApp.Instance().cul));
            this.label20.Text = ((DesignMode) ? "OutlineWidthInsetPix" : UVDLPApp.Instance().resman.GetString("OutlineWidthInsetPix", UVDLPApp.Instance().cul));
            this.chkOutlines.Text = ((DesignMode) ? "EnableSliceOutlines" : UVDLPApp.Instance().resman.GetString("EnableSliceOutlines", UVDLPApp.Instance().cul));
            this.label158.Text = ((DesignMode) ? "BottomExposureMs" : UVDLPApp.Instance().resman.GetString("BottomExposureMs", UVDLPApp.Instance().cul));
            this.lblLayerTime.Text = ((DesignMode) ? "ExposureTimeMs" : UVDLPApp.Instance().resman.GetString("ExposureTimeMs", UVDLPApp.Instance().cul));
            this.label1.Text = ((DesignMode) ? "SliceThicknessMm" : UVDLPApp.Instance().resman.GetString("SliceThicknessMm", UVDLPApp.Instance().cul));
            this.label8.Text = ((DesignMode) ? "BottomLayers" : UVDLPApp.Instance().resman.GetString("BottomLayers", UVDLPApp.Instance().cul));
            this.chkantialiasing.Text = ((DesignMode) ? "EnableAntiAliasing" : UVDLPApp.Instance().resman.GetString("EnableAntiAliasing", UVDLPApp.Instance().cul));
            this.groupBox2.Text = ((DesignMode) ? "ResinProfiles" : UVDLPApp.Instance().resman.GetString("ResinProfiles", UVDLPApp.Instance().cul));
            this.buttResinCalib.Text = ((DesignMode) ? "Calibrate" : UVDLPApp.Instance().resman.GetString("Calibrate", UVDLPApp.Instance().cul));
            this.label18.Text = ((DesignMode) ? "Resin" : UVDLPApp.Instance().resman.GetString("Resin", UVDLPApp.Instance().cul));
            this.txtResinPriceL.Text = ((DesignMode) ? "_50_" : UVDLPApp.Instance().resman.GetString("_50_", UVDLPApp.Instance().cul));
            //this.label17.Text = ((DesignMode) ? "PricePerLiter" : UVDLPApp.Instance().resman.GetString("PricePerLiter", UVDLPApp.Instance().cul));
            this.groupBox3.Text = ((DesignMode) ? "ImageReflection" : UVDLPApp.Instance().resman.GetString("ImageReflection", UVDLPApp.Instance().cul));
            this.chkReflectY.Text = ((DesignMode) ? "ReflectY" : UVDLPApp.Instance().resman.GetString("ReflectY", UVDLPApp.Instance().cul));
            this.chkReflectX.Text = ((DesignMode) ? "ReflectX" : UVDLPApp.Instance().resman.GetString("ReflectX", UVDLPApp.Instance().cul));
            this.chkReflectX.Text = ((DesignMode) ? "ReflectX" : UVDLPApp.Instance().resman.GetString("ReflectX", UVDLPApp.Instance().cul));
            this.grpLift.Text = ((DesignMode) ? "LiftAndSequence" : UVDLPApp.Instance().resman.GetString("LiftAndSequence", UVDLPApp.Instance().cul));
            this.cmdAutoCalc.Text = ((DesignMode) ? "AutoCalc" : UVDLPApp.Instance().resman.GetString("AutoCalc", UVDLPApp.Instance().cul));
            this.label10.Text = ((DesignMode) ? "ZLiftDistanceMm" : UVDLPApp.Instance().resman.GetString("ZLiftDistanceMm", UVDLPApp.Instance().cul));
            this.label12.Text = ((DesignMode) ? "BuildDirection" : UVDLPApp.Instance().resman.GetString("BuildDirection", UVDLPApp.Instance().cul));
            this.label5.Text = ((DesignMode) ? "LiftAndSequenceTimeMs" : UVDLPApp.Instance().resman.GetString("LiftAndSequenceTimeMs", UVDLPApp.Instance().cul));
            this.cmdApply.Text = ((DesignMode) ? "ApplyChanges" : UVDLPApp.Instance().resman.GetString("ApplyChanges", UVDLPApp.Instance().cul));
            this.groupBox1.Text = ((DesignMode) ? "ImagePixelOffsets" : UVDLPApp.Instance().resman.GetString("ImagePixelOffsets", UVDLPApp.Instance().cul));
            this.label4.Text = ((DesignMode) ? "YOffset" : UVDLPApp.Instance().resman.GetString("YOffset", UVDLPApp.Instance().cul));
            this.label4.Text = ((DesignMode) ? "YOffset" : UVDLPApp.Instance().resman.GetString("YOffset", UVDLPApp.Instance().cul));
            this.label3.Text = ((DesignMode) ? "XOffset" : UVDLPApp.Instance().resman.GetString("XOffset", UVDLPApp.Instance().cul));
            this.tbGCode.Text = ((DesignMode) ? "GCode__" : UVDLPApp.Instance().resman.GetString("GCode__", UVDLPApp.Instance().cul));
            this.button1.Text = ((DesignMode) ? "Help" : UVDLPApp.Instance().resman.GetString("Help", UVDLPApp.Instance().cul));
            this.label16.Text = ((DesignMode) ? "GCodeSection" : UVDLPApp.Instance().resman.GetString("GCodeSection", UVDLPApp.Instance().cul));
            this.lbGCodeSection.Items.AddRange(new object[] {
            ((DesignMode) ? "Start" :UVDLPApp.Instance().resman.GetString("Start", UVDLPApp.Instance().cul)),
            ((DesignMode) ? "PreSlice" :UVDLPApp.Instance().resman.GetString("PreSlice", UVDLPApp.Instance().cul)),
            ((DesignMode) ? "Lift" :UVDLPApp.Instance().resman.GetString("Lift", UVDLPApp.Instance().cul)),
            ((DesignMode) ? "End" :UVDLPApp.Instance().resman.GetString("End", UVDLPApp.Instance().cul))}); this.cmdReloadGCode.Text = ((DesignMode) ? "Reload" : UVDLPApp.Instance().resman.GetString("Reload", UVDLPApp.Instance().cul));
            this.cmdSaveGCode.Text = ((DesignMode) ? "Save" : UVDLPApp.Instance().resman.GetString("Save", UVDLPApp.Instance().cul));
            this.txtGCode.Font = new System.Drawing.Font(((DesignMode) ? "CourierNew" : UVDLPApp.Instance().resman.GetString("CourierNew", UVDLPApp.Instance().cul)), 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Font = new System.Drawing.Font(((DesignMode) ? "MicrosoftSansSerif" : UVDLPApp.Instance().resman.GetString("MicrosoftSansSerif", UVDLPApp.Instance().cul)), 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        /// <summary>
        /// This lock/unlock pair is for plugin that wish to restrict user's ability
        /// to change too much on the slicing profile screen
        /// </summary>
        public void LockAllButExposure() 
        {
            try
            {
                grpLift.Hide();
                groupBox3.Hide(); // image reflection
                //grpExport.Hide();                
                tabOptions.TabPages.Remove(m_gcodetab);
                //TabControl
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogError(ex);
            }
        }

        public void UnlockAll() 
        {
            try
            {
                grpLift.Show();
                groupBox3.Show(); // image reflection
                //grpExport.Show();
                //tabOptions.TabPages["tbGCode"].Show();
                tabOptions.TabPages.Add(m_gcodetab);
            }
            catch (Exception ex)                       
            {
                DebugLogger.Instance().LogError(ex);
            }
        }
       private SliceBuildConfig m_config = null;
        // this populates the profile in use and the combo 
       private void PopulateProfiles() 
       {
           try
           {
               cmbSliceProfiles.Items.Clear();
               
               foreach (string prof in UVDLPApp.Instance().SliceProfiles())
               {
                   cmbSliceProfiles.Items.Add(prof);
               
               }
               //get the current profile name
               string curprof = UVDLPApp.Instance().GetCurrentSliceProfileName();
               cmbSliceProfiles.SelectedItem = curprof;
               
           }
           catch (Exception ex) 
           {
               DebugLogger.Instance().LogError(ex.Message);
           }
       }
       private string CurPrefGcodePath() 
       {
           try
           {
               string shortname = cmbSliceProfiles.SelectedItem.ToString();
               string fname = UVDLPApp.Instance().m_PathProfiles;
               fname += UVDLPApp.m_pathsep + shortname + UVDLPApp.m_pathsep;
               return fname;
           }
           catch (Exception ex) 
           {
               DebugLogger.Instance().LogError(ex.Message);
               return "";
           }
       }

       private String GetSlicingFilename(string shortname)
       {
           string fname = UVDLPApp.Instance().m_PathProfiles;
           fname += UVDLPApp.m_pathsep + shortname + ((DesignMode) ? "Slicing" :UVDLPApp.Instance().resman.GetString("Slicing", UVDLPApp.Instance().cul));
           return fname;
       }

        private SliceBuildConfig LoadProfile(string shortname) 
        {
            SliceBuildConfig profile = new SliceBuildConfig();
            try
            {
                string fname = GetSlicingFilename(shortname);
                if (!profile.Load(fname))
                {
                    DebugLogger.Instance().LogError(((DesignMode) ? "CouldNotLoad" :UVDLPApp.Instance().resman.GetString("CouldNotLoad", UVDLPApp.Instance().cul)) + fname);
                    return null;
                }
                else 
                {
                    UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eSlicedLoaded, ((DesignMode) ? "SliceProfileLoaded" :UVDLPApp.Instance().resman.GetString("SliceProfileLoaded", UVDLPApp.Instance().cul)));
                    UVDLPApp.Instance().RaiseAppEvent(eAppEvent.eSliceProfileChanged, ((DesignMode) ? "SliceProfileLoaded" :UVDLPApp.Instance().resman.GetString("SliceProfileLoaded", UVDLPApp.Instance().cul)));
                    return profile;
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
            return null;
        }
        private void SetValues() 
        {            
            chkExport.Checked = m_config.export;
            comboExportSvg.SelectedIndex = m_config.exportsvg;
            comboExportPreview.SelectedItem = m_config.exportpreview.ToString();
            chkExportPNG.Checked = m_config.exportpng;
            chkExport_CheckedChanged(null, null);
            txtAAVal.Text = "" + m_config.aaval.ToString();
            txtBlankTime.Text = m_config.blanktime_ms.ToString();
            txtXOffset.Text = m_config.XOffset.ToString();
            txtYOffset.Text = m_config.YOffset.ToString();
            txtLiftDistance.Text = m_config.liftdistance.ToString();
            txtSlideTilt.Text = m_config.slidetiltval.ToString();
            chkantialiasing.Checked = m_config.antialiasing;
            txtliftfeed.Text = m_config.liftfeedrate.ToString();
            txtbottomliftfeed.Text = m_config.bottomliftfeedrate.ToString();

            txtretractfeed.Text = m_config.liftretractrate.ToString();
            chkReflectX.Checked = m_config.m_flipX;
            chkReflectY.Checked = m_config.m_flipY;
            txtNotes.Text = m_config.m_notes;
            chkOutlines.Checked = m_config.m_createoutlines;
            txtOutlineWidthInset.Text = m_config.m_outlinewidth_inset.ToString();
            txtOutlineWidthInset.Enabled = chkOutlines.Checked;
            txtOutlineWidthOutset.Text = m_config.m_outlinewidth_outset.ToString();
            txtOutlineWidthOutset.Enabled = chkOutlines.Checked;
            // resin
            UpdateResinList();
            SetResinValues();


            UpdatePowderList();
            SetPowderValues();


            UpdateFluidList();
            SetFluidValues();



            cmbBuildDirection.Items.Clear();
            foreach(String name in Enum.GetNames(typeof(SliceBuildConfig.eBuildDirection)))
            {
                cmbBuildDirection.Items.Add(name);
            }
            cmbBuildDirection.SelectedItem = m_config.direction.ToString();
        }

        private void SetResinValues()
        {
            txtZThick.Text = "" + String.Format("{0:0.000}", m_config.ZThick);
            txtLayerTime.Text = "" + m_config.layertime_ms;
            txtFirstLayerTime.Text = m_config.firstlayertime_ms.ToString();
            //txtResinPriceL.Text = m_config.m_resinprice.ToString();
            txtnumbottom.Text = m_config.numfirstlayers.ToString();

            //txtWallThickness.Text = m_config.m_wall_thickness.ToString();
            numWallThickness.Value =(decimal) m_config.m_wall_thickness;
            txtSpeedPrint.Text = m_config.m_speed_printing.ToString();
            txtSpeedSpareading.Text = m_config.m_speed_spareading.ToString();
            txtBottomLayyer.Text = m_config.m_bottom_layers.ToString();
            txtRollerSpeed.Text = m_config.m_roller_speed.ToString();
            txtFeedthickness.Text = m_config.m_feed_thickness.ToString();

        }


        private void UpdatePowderList()
        {
            combopowder.Items.Clear();
            int i = 0;
            foreach (KeyValuePair<string, PowderConfig> entry in m_config.powders)
            {
                combopowder.Items.Add(entry.Key);
                if (entry.Key == m_config.selectedpowder)
                    combopowder.SelectedIndex = i;
                i++;
            }
        }

        private void UpdateFluidList()
        {
            comboFluid.Items.Clear();
            int i = 0;
            foreach (KeyValuePair<string, FluidConfig> entry in m_config.fluids)
            {
                comboFluid.Items.Add(entry.Key);
                if (entry.Key == m_config.selectedfluid)
                    comboFluid.SelectedIndex = i;
                i++;
            }
        }


        private void UpdateResinList()
        {
            comboResin.Items.Clear();
            int i = 0;
            foreach (KeyValuePair<string, InkConfig> entry in m_config.inks)
            {
                comboResin.Items.Add(entry.Key);
                if (entry.Key == m_config.selectedInk)
                    comboResin.SelectedIndex = i;
                i++;
            }
        }

        private bool GetValues() 
        {
            try
            {
                
                m_config.m_exportopt = "ZIP";
                m_config.blanktime_ms = int.Parse(txtBlankTime.Text);
                m_config.XOffset = int.Parse(txtXOffset.Text);
                m_config.YOffset = int.Parse(txtYOffset.Text);
                m_config.liftdistance = double.Parse(txtLiftDistance.Text);
                m_config.slidetiltval = double.Parse(txtSlideTilt.Text);
                m_config.antialiasing = chkantialiasing.Checked;
                m_config.liftfeedrate = double.Parse(txtliftfeed.Text);
                m_config.bottomliftfeedrate = double.Parse(txtbottomliftfeed.Text);
                m_config.liftretractrate = double.Parse(txtretractfeed.Text);
                m_config.m_flipX = chkReflectX.Checked;
                m_config.m_flipY = chkReflectY.Checked;
                m_config.m_notes = txtNotes.Text;
                m_config.aaval = double.Parse(txtAAVal.Text);
                //m_config.direction = (SliceBuildConfig.eBuildDirection)Enum.Parse(typeof(SliceBuildConfig.eBuildDirection), cmbBuildDirection.SelectedItem.ToString());
                m_config.export = chkExport.Checked;
                m_config.exportsvg = comboExportSvg.SelectedIndex;
                m_config.exportpng = chkExportPNG.Checked;
                m_config.exportpreview = (PreviewGenerator.ePreview)Enum.Parse(typeof(PreviewGenerator.ePreview), comboExportPreview.SelectedItem.ToString());
                // resin
                m_config.ZThick = Single.Parse(txtZThick.Text);
                m_config.layertime_ms = int.Parse(txtLayerTime.Text);
                m_config.firstlayertime_ms = int.Parse(txtFirstLayerTime.Text);
                m_config.numfirstlayers = int.Parse(txtnumbottom.Text);
                //m_config.m_resinprice = double.Parse(txtResinPriceL.Text);
                m_config.m_createoutlines = chkOutlines.Checked;

                m_config.m_feed_thickness = double.Parse(txtFeedthickness.Text);
                m_config.m_speed_spareading = double.Parse(txtSpeedSpareading.Text);
                m_config.m_speed_printing = double.Parse(txtSpeedPrint.Text);
                m_config.m_bottom_layers = double.Parse(txtBottomLayyer.Text);
                m_config.m_roller_speed = double.Parse(txtRollerSpeed.Text);
                //m_config.m_wall_thickness = double.Parse(txtWallThickness.Text);
                m_config.m_wall_thickness = chkDepowderingWall.Checked?(double)numWallThickness.Value:0;



                m_config.m_outlinewidth_inset = double.Parse(txtOutlineWidthInset.Text);
                m_config.m_outlinewidth_outset = double.Parse(txtOutlineWidthOutset.Text);

                //m_config.m_fluidPrice = double.Parse(txtFluidPriceL.Text);
                //m_config.m_powderPrice = double.Parse(txtPowderPriceL.Text);

                m_config.UpdateCurrentInk();

                m_config.UpdateCurrentPowder();
                m_config.UpdateCurrentFluid();

                return true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(((DesignMode) ? "PleaseCheckInputParameters" :UVDLPApp.Instance().resman.GetString("PleaseCheckInputParameters", UVDLPApp.Instance().cul)) + ex.Message, ((DesignMode) ? "InputError" :UVDLPApp.Instance().resman.GetString("InputError", UVDLPApp.Instance().cul)));
                return false;
            }
        }

        private void cmdAutoCalc_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetValues())
                {
                    double zlift = m_config.liftdistance; // in mm
                    double zliftrate = m_config.liftfeedrate; // in mm/m
                    double zliftretract = m_config.liftretractrate; // in mm/m
                    double tilt = m_config.slidetiltval; // in mm
                    double totalpath = Math.Sqrt(tilt * tilt + zlift * zlift);
                    zliftrate /= 60.0d;     // to convert to mm/s
                    zliftretract /= 60.0d;  // to convert to mm/s


                    double tval = 0;
                    double settlingtime = 1500.0d; // 500 ms
                    tval = (totalpath / zliftrate);
                    tval += (totalpath / zliftretract);
                    tval *= 1000.0d; // convert to ms
                    tval += settlingtime;
                    int itval = (int)tval;
                    itval = (itval / 100 + 1) * 100;  // round to the nearest 0.1 second
                    String stime = itval.ToString();
                    txtBlankTime.Text = stime;

                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            if(m_config == null) return;
            if(cmbSliceProfiles.SelectedIndex == -1) return;
            try
            {
                if (GetValues())
                {
                    string shortname = cmbSliceProfiles.SelectedItem.ToString();
                    string fname = GetSlicingFilename(shortname);
                    m_config.Save(fname);
                    // make sure main build params are updated if needed
                    if (cmbSliceProfiles.SelectedItem.ToString() == shortname)
                    {
                        UVDLPApp.Instance().LoadBuildSliceProfile(fname);
                    }
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmbSliceProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the item
            if (cmbSliceProfiles.SelectedIndex == -1)
            {
                //blank items
                return;
            }
            else 
            {
                //set this profile to be the active one for the program                
                string shortname = cmbSliceProfiles.SelectedItem.ToString();
                string fname = GetSlicingFilename(shortname);
                UVDLPApp.Instance().LoadBuildSliceProfile(fname); // load it globally
                try
                {
                    m_config = LoadProfile(shortname); // and again here for this control
                    if (m_config != null)
                    {
                        SetValues();
                        lbGCodeSection_SelectedIndexChanged(this, null);
                    }
                }
                catch (Exception ex) 
                {
                    DebugLogger.Instance().LogError(ex);
                }

            }
        }
        private void cmdNew_Click(object sender, EventArgs e)
        {
            // prompt for a new name
            frmProfileName frm = new frmProfileName();
            if (frm.ShowDialog() == DialogResult.OK) 
            {
                //create a new profile
                SliceBuildConfig bf = new SliceBuildConfig();
                //save it
                string shortname = frm.ProfileName;
                string fname = GetSlicingFilename(shortname);
                if (!bf.Save(fname)) 
                {
                    MessageBox.Show(((DesignMode) ? "ErrorSavingNewProfile" :UVDLPApp.Instance().resman.GetString("ErrorSavingNewProfile", UVDLPApp.Instance().cul)) + fname);
                }
                //re-display the new list
                PopulateProfiles();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string shortname = cmbSliceProfiles.SelectedItem.ToString();
                if (shortname.ToLower().Contains(((DesignMode) ? "Default" :UVDLPApp.Instance().resman.GetString("Default", UVDLPApp.Instance().cul))))
                {
                    MessageBox.Show(((DesignMode) ? "CannotDeleteDefaultProfile" :UVDLPApp.Instance().resman.GetString("CannotDeleteDefaultProfile", UVDLPApp.Instance().cul)));
                }
                else
                {

                    string fname = GetSlicingFilename(shortname);
                    File.Delete(fname); // delete the file
                    //string pname = UVDLPApp.Instance().m_PathProfiles + UVDLPApp.m_pathsep + shortname;
                   // Directory.Delete(pname, true); // no longer creating specific directories for profiles - gcode is now embedded
                    //choose another profile to select as main profile
                    cmbSliceProfiles.SelectedIndex = 0; //set to the first profile...
                    PopulateProfiles();
                    //cmbSliceProfiles
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        /// <summary>
        /// this index changes when the user selects an item from the list of GCode file segements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbGCodeSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGCode.Text = GCodeSection2GCode();
        }

        private string GCodeSection2GCode()
        {
            if (lbGCodeSection.SelectedIndex == -1) return "";
            switch (lbGCodeSection.SelectedItem.ToString())
            {
                case "Start":           return m_config.HeaderCode;
                case "Pre-Slice":       return m_config.PreSliceCode;
                case "Lift":            return m_config.LiftCode;
                case "End": return m_config.FooterCode;
                case "Layer": return m_config.LayerCode;
            }
            return "";
        }
        /*
        private string GCodeSection2FName() 
        {
            if (lbGCodeSection.SelectedIndex == -1) return "";
            switch (lbGCodeSection.SelectedItem.ToString()) 
            {
                case "Start":           return "start.gcode";
                case "Pre-Slice":       return "preslice.gcode";
                case "Lift":            return "lift.gcode";
                case "End":             return "end.gcode";
                case "Open-Shutter":    return "openshutter.gcode";
                case "Close-Shutter":   return "closeshutter.gcode";
            }
            return "";
        }
        */
        private void cmdSaveGCode_Click(object sender, EventArgs e)
        {
            try
            {
                // save the gcode to the right section
                string gcode = txtGCode.Text;
                if (lbGCodeSection.SelectedIndex == -1) return;
                switch (lbGCodeSection.SelectedItem.ToString())
                {
                    case "Start": m_config.HeaderCode = gcode; break;
                    case "Pre-Slice": m_config.PreSliceCode = gcode; break;
                    case "Lift": m_config.LiftCode = gcode; break;
                    case "End": m_config.FooterCode = gcode; break;
                }
               // m_config.SaveFile(CurPrefGcodePath() + GCodeSection2FName(), gcode);
                //really just need to save the profile name here.
                // make sure main build params are updated if needed
                string shortname = cmbSliceProfiles.SelectedItem.ToString();
                string fname = GetSlicingFilename(shortname);
                m_config.Save(fname);

                shortname = cmbSliceProfiles.SelectedItem.ToString();
                if (cmbSliceProfiles.SelectedItem.ToString() == shortname)
                {
                    UVDLPApp.Instance().LoadBuildSliceProfile(GetSlicingFilename(shortname));
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }

        private void cmdReloadGCode_Click(object sender, EventArgs e)
        {
            txtGCode.Text = GCodeSection2GCode();
        }

        private void chkExport_CheckedChanged(object sender, EventArgs e)
        {
            //groupBox2.Enabled = chkExport.Checked;
            comboExportSvg.Enabled = chkExport.Checked;
            chkExportPNG.Enabled = chkExport.Checked;
            //comboExportPreview.Enabled = chkExport.Checked;
            labelExportSvg.Enabled = chkExport.Checked;
            //labelExportPreview.Enabled = chkExport.Checked;
        }


        private void chkantialiasing_CheckedChanged(object sender, EventArgs e)
        {
            txtAAVal.Enabled = chkantialiasing.Checked;
        }

        private void comboResin_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_config.SetCurrentInk(comboResin.SelectedItem.ToString());
            SetResinValues();
        }

        private void cmdNewResin_Click(object sender, EventArgs e)
        {
            frmProfileName frm = new frmProfileName();
            frm.Text = ((DesignMode) ? "NewResinProfile" :UVDLPApp.Instance().resman.GetString("NewResinProfile", UVDLPApp.Instance().cul));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //create a new resin profile
                string res = m_config.AddNewResin(frm.ProfileName);
                if (res != "OK")
                {
                    MessageBox.Show(res, ((DesignMode) ? "Error" :UVDLPApp.Instance().resman.GetString("Error", UVDLPApp.Instance().cul)));
                    return;
                }
                UpdateResinList();
                SetResinValues();
                //comboResin.Items.Add(frm.ProfileName);
                //comboResin.SelectedIndex = comboResin.Items.Count - 1;
            }
        }

        private void cmdDelResin_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, ((DesignMode) ? "AreYouSureYouWantToDeleteThisResinProfile" :UVDLPApp.Instance().resman.GetString("AreYouSureYouWantToDeleteThisResinProfile", UVDLPApp.Instance().cul)), ((DesignMode) ? "ConfirmDelete" :UVDLPApp.Instance().resman.GetString("ConfirmDelete", UVDLPApp.Instance().cul)), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string res = m_config.RemoveSelectedInk();
            if (res != "OK")
            {
                string[] strs = res.Split('|');
                MessageBox.Show(strs[0], strs.Length > 1 ? strs[1] : ((DesignMode) ? "Error" :UVDLPApp.Instance().resman.GetString("Error", UVDLPApp.Instance().cul)));
            }
            UpdateResinList();
            SetResinValues();
        }

        private void buttResinCalib_Click(object sender, EventArgs e)
        {
            frmCalibResin frmCalib = new frmCalibResin();
            frmCalib.ShowDialog();
        }

        private void txtAAVal_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            frmSliceProfileHelp frm = new frmSliceProfileHelp();
            frm.ShowDialog();

        }

        private void chkOutlines_CheckedChanged(object sender, EventArgs e)
        {
            txtOutlineWidthInset.Enabled = chkOutlines.Checked;
            txtOutlineWidthOutset.Enabled = chkOutlines.Checked;
        }

        public void RegisterControls()
        {
            GuiConfigManager guiconf = UVDLPApp.Instance().m_gui_config;
            guiconf.AddControl("ctlToolpathGenConfig1.tbGCode",tbGCode);   
            guiconf.AddControl("ctlToolpathGenConfig1.tbOptions", tbOptions);
            guiconf.AddControl("ctlToolpathGenConfig1.panelExposure", panelExposure);
            //guiconf.AddControl("ctlToolpathGenConfig1.grpExport", grpExport);
            guiconf.AddControl("ctlToolpathGenConfig1.grpLift", grpLift);
        }

        private void cmdNewPowder_Click(object sender, EventArgs e)
        {
            frmProfileName frm = new frmProfileName();
            frm.Text = ((DesignMode) ? "NewPowderProfile" : UVDLPApp.Instance().resman.GetString("NewPowderProfile", UVDLPApp.Instance().cul));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //create a new resin profile
                string res = m_config.AddNewPowder(frm.ProfileName);
                if (res != "OK")
                {
                    MessageBox.Show(res, ((DesignMode) ? "Error" : UVDLPApp.Instance().resman.GetString("Error", UVDLPApp.Instance().cul)));
                    return;
                }
                UpdatePowderList();
                SetPowderValues();
                //comboResin.Items.Add(frm.ProfileName);
                //comboResin.SelectedIndex = comboResin.Items.Count - 1;
            }

        }

        private void SetPowderValues()
        {
            //txtPowderPriceL.Text = m_config.m_powderPrice.ToString();
        }

        private void cmdNewFluid_Click(object sender, EventArgs e)
        {
            frmProfileName frm = new frmProfileName();
            frm.Text = ((DesignMode) ? "NewFluidProfile" : UVDLPApp.Instance().resman.GetString("NewFluidProfile", UVDLPApp.Instance().cul));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //create a new resin profile
                string res = m_config.AddNewFluid(frm.ProfileName);
                if (res != "OK")
                {
                    MessageBox.Show(res, ((DesignMode) ? "Error" : UVDLPApp.Instance().resman.GetString("Error", UVDLPApp.Instance().cul)));
                    return;
                }
                UpdateFluidList();
                SetFluidValues();
                //comboResin.Items.Add(frm.ProfileName);
                //comboResin.SelectedIndex = comboResin.Items.Count - 1;
            }
        }

        private void SetFluidValues()
        {
            //txtFluidPriceL.Text = m_config.m_fluidPrice.ToString();

        }

        private void cmdDelPowder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, ((DesignMode) ? "AreYouSureYouWantToDeleteThisPowderProfile" : UVDLPApp.Instance().resman.GetString("AreYouSureYouWantToDeleteThisResinProfile", UVDLPApp.Instance().cul)), ((DesignMode) ? "ConfirmDelete" : UVDLPApp.Instance().resman.GetString("ConfirmDelete", UVDLPApp.Instance().cul)), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string res = m_config.RemoveSelectedPowder();
            if (res != "OK")
            {
                string[] strs = res.Split('|');
                MessageBox.Show(strs[0], strs.Length > 1 ? strs[1] : ((DesignMode) ? "Error" : UVDLPApp.Instance().resman.GetString("Error", UVDLPApp.Instance().cul)));
            }
            UpdateResinList();
            SetResinValues();
        }

        private void cmdDelFluid_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, ((DesignMode) ? "AreYouSureYouWantToDeleteThisFluidProfile" : UVDLPApp.Instance().resman.GetString("AreYouSureYouWantToDeleteThisResinProfile", UVDLPApp.Instance().cul)), ((DesignMode) ? "ConfirmDelete" : UVDLPApp.Instance().resman.GetString("ConfirmDelete", UVDLPApp.Instance().cul)), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string res = m_config.RemoveSelectedFluid();
            if (res != "OK")
            {
                string[] strs = res.Split('|');
                MessageBox.Show(strs[0], strs.Length > 1 ? strs[1] : ((DesignMode) ? "Error" : UVDLPApp.Instance().resman.GetString("Error", UVDLPApp.Instance().cul)));
            }
            UpdateResinList();
            SetResinValues();
        }

        private void combopowder_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_config.SetCurrentPowder(combopowder.SelectedItem.ToString());
            SetPowderValues();
        }

        private void comboFluid_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_config.SetCurrentFluid(comboFluid.SelectedItem.ToString());
            SetFluidValues();
        }

        private void ctlToolpathGenConfig_Load(object sender, EventArgs e)
        {
            tabOptions.TabPages.Remove(tbGCode);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.BackColor = Color.White;
            base.OnPaint(e);
        }

        private void chkDepowderingWall_CheckedChanged(object sender, EventArgs e)
        {
            numWallThickness.Enabled = chkDepowderingWall.Checked;
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}